// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

//------------------------------------------------------------------------------
// <copyright company="DMV">
//   Copyright 2014 Ded Medved
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.SqlServer.Dac.CodeAnalysis;
using Microsoft.SqlServer.Dac.Model;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Cheburashka
{
    /// <summary>
    /// <para>
    /// This is a SQL rule which returns a warning message 
    /// whenever there is au unused variable in a routine.
    /// </para>
    /// <para>
    /// Note that this uses a Localized export attribute, and hence the rule name and description will be
    /// localized if resource files for different languages are used
    /// </para>
    /// </summary>

    [LocalizedExportCodeAnalysisRule(AvoidOnePartNamesRule.RuleId,
        RuleConstants.ResourceBaseName,                                     // Name of the resource file to look up display name and description in
        RuleConstants.AvoidOnePartNames_RuleName,                           // ID used to look up the display name inside the resources file
        RuleConstants.AvoidOnePartNames_ProblemDescription,                 // ID used to look up the description inside the resources file
        Category = RuleConstants.CategoryNonStrictCodingStyleNames,         // Rule category (e.g. "Design", "Naming")
        RuleScope = SqlRuleScope.Element)]                                  // This rule targets specific elements rather than the whole model
    public sealed class AvoidOnePartNamesRule : SqlCodeAnalysisRule
    {
        /// <summary>
        /// <para>
        /// The Rule ID should resemble a fully-qualified class name. In the Visual Studio UI
        /// rules are grouped by "Namespace + Category", and each rule is shown using "Short ID: DisplayName".
        /// </para>
        /// <para>
        /// For this rule, it will be 
        /// shown as "DM0029: Always include the schema name when referencing an object."
        /// </para>
        /// </summary>
        public const string RuleId = RuleConstants.AvoidOnePartNames_RuleId;

        public AvoidOnePartNamesRule()
        {
            SupportedElementTypes = SqlRuleUtils.GetPotentialSchemaLessNameContextClasses();
        }

        /// <summary>
        /// For element-scoped rules the Analyze method is executed once for every matching object in the model. 
        /// </summary>
        /// <param name="ruleExecutionContext">The context object contains the TSqlObject being analyzed, a TSqlFragment
        /// that's the AST representation of the object, the current rule's descriptor, and a reference to the model being
        /// analyzed.
        /// </param>
        /// <returns>A list of problems should be returned. These will be displayed in the Visual Studio error list</returns>
        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext ruleExecutionContext)
        {
            // Get Model collation 
            SqlComparer.Comparer = ruleExecutionContext.SchemaModel.CollationComparer;

            List<SqlRuleProblem> problems = new();

            try
            {
                TSqlObject modelElement = ruleExecutionContext.ModelElement;

                string elementName = RuleUtils.GetElementName(ruleExecutionContext);

                // The rule execution context has all the objects we'll need, including the fragment representing the object,
                // and a descriptor that lets us access rule metadata
                TSqlFragment sqlFragment = ruleExecutionContext.ScriptFragment;
                RuleDescriptor ruleDescriptor = ruleExecutionContext.RuleDescriptor;

                DMVSettings.RefreshModelBuiltInCache(ruleExecutionContext.SchemaModel);

                // visitor to get the occurrences of single part table names
                var onePartNames = DmTSqlFragmentVisitor.Visit(sqlFragment, new AvoidOnePartNameVisitor());
                var updateStatements = DmTSqlFragmentVisitor.Visit(sqlFragment, new UpdateStatementForTargetVisitor());
                var deleteStatements = DmTSqlFragmentVisitor.Visit(sqlFragment, new DeleteStatementForTargetVisitor());
                var mergeStatements = DmTSqlFragmentVisitor.Visit(sqlFragment, new MergeStatementForTargetVisitor());

                List<TSqlFragment> allStatements = new();
                allStatements.AddRange(updateStatements);
                allStatements.AddRange(deleteStatements);
                allStatements.AddRange(mergeStatements);

                var dataTypes = DmTSqlFragmentVisitor.Visit(sqlFragment, new DataTypeVisitor());
                IList<CteUtil> cteUtilFragments = SqlRuleUtils.CteStatements(sqlFragment).ToList();
                var serviceBrokerContexts = DmTSqlFragmentVisitor.Visit(sqlFragment, new ExcludedTwoPartNamesContextsVisitor());

                // Create problems for each one part object name source found 
                foreach (SchemaObjectName tableSource in onePartNames.Cast<SchemaObjectName>()) // the cast should work
                {
                    string tableSourceIdentifier = tableSource.ScriptTokenStream[tableSource.LastTokenIndex].Text;
                    // Check the name isn't a builtin sql type
                    bool foundSurroundingDeclaration = dataTypes.Any(v => v.SQLModel_Contains(tableSource));
                    // Check the name isn't an update or delete or merge statement target
                    if (!foundSurroundingDeclaration)
                    {
                        foundSurroundingDeclaration = allStatements.Any(v => v.SQLModel_Contains(tableSource));
                    }

                    //// Check the name isn't literally 'sysname' etc
                    if (!foundSurroundingDeclaration)
                    {
                        if (tableSource.FirstTokenIndex == tableSource.LastTokenIndex &&
                            SqlRuleUtils.IsBuiltinDataTypeThatParsesAsAnIdentifier(
                                tableSource.ScriptTokenStream[tableSource.FirstTokenIndex].Text)
                            )
                        {
                            foundSurroundingDeclaration = true;
                        }
                    }

                    // Check we aren't looking in master or msdb.
                    if (!foundSurroundingDeclaration)
                    {
                        if (tableSource.DatabaseIdentifier is not null)
                        {
                            foundSurroundingDeclaration = SqlRuleUtils.IsSystemDatabaseThatNeedNoSchemaQualification(tableSource.DatabaseIdentifier.Value);
                        }
                    }

                    // Check it isn't a built-in system object
                    if (!foundSurroundingDeclaration)
                    {
                        foundSurroundingDeclaration = SqlRuleUtils.Is_SS2008R2_SystemDatabaseObject(tableSourceIdentifier);
                    }
                    // Check it isn't Deleted or Inserted
                    if (!foundSurroundingDeclaration)
                    {
                        foundSurroundingDeclaration = SqlRuleUtils.IsSystemTableThatNeedNoSchemaQualification(tableSource.BaseIdentifier.Value);
                    }
                    // Check the name isn't a CTE name in an update........... target
                    if (!foundSurroundingDeclaration)
                    {
                        {
                            if (tableSourceIdentifier is null) throw new Exception("null tableSourceIdentifier");

                            tableSourceIdentifier = tableSourceIdentifier.GetNormalisedName();
                            foundSurroundingDeclaration =
                                cteUtilFragments.Any(v => SqlComparisonUtils.SQLModel_Contains(v, tableSource)
                                                         && v.ExpressionNamesAsStrings.Contains(tableSourceIdentifier, SqlComparer.Comparer)
                                                    );
                        }
                    }
                    // Check it isn't picked up as a service broker contract or service or whatever.
                    if (!foundSurroundingDeclaration)
                    {
                        foundSurroundingDeclaration = serviceBrokerContexts.Any(v => v.SQLModel_Contains(tableSource));
                    }

                    RuleUtils.UpdateProblems(!foundSurroundingDeclaration, problems, modelElement, elementName, tableSource, ruleDescriptor);
                }

                // may need to sweep user defined type separately
                // needs new visitor

                // now to look inside literal arguments to system functions.
                // this is totally independent of the above search.
               var literalOnePartNameContexts = DmTSqlFragmentVisitor.Visit(sqlFragment, new SchemaNameAcceptingFunctionsVisitor());
                // Create problems for each one part object name source found 
                // check each against list of builtin that might be passed to typeid
                RuleUtils.UpdateProblems(problems, modelElement, elementName, literalOnePartNameContexts, ruleDescriptor);

                // now to look inside literal arguments to system procedures.
                // this is totally independent of the above search.
                var literalOnePartNameStoredProcsContexts = DmTSqlFragmentVisitor.Visit(sqlFragment, new SchemaNameAcceptingProceduresVisitor());
                // Create problems for each one part object name source found 
                // check each against list of builtin that might be passed to typeid
                RuleUtils.UpdateProblems(problems, modelElement, elementName, literalOnePartNameStoredProcsContexts, ruleDescriptor);
            }
            catch
            {
            } // DMVRuleSetup.RuleSetup barfs on 'hidden' temporal history tables 'defined' in sub-projects

            return problems;
            }
    }
}
