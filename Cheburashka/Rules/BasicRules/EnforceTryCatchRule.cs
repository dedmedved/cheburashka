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
using System.Collections.Generic;
using System.Globalization;
using Microsoft.SqlServer.Dac.CodeAnalysis;
using Microsoft.SqlServer.Dac.Model;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Cheburashka
{
    /// <summary>
    /// <para>
    /// This is a SQL rule which returns a warning message 
    /// whenever a stored procedure or trigger has no try/catch block. 
    /// This rule only applies to SQL stored procedures, and triggers.
    /// </para>
    /// <para>
    /// Note that this uses a Localized export attribute, and hence the rule name and description will be
    /// localized if resource files for different languages are used
    /// </para>
    /// </summary>
    [LocalizedExportCodeAnalysisRule(EnforceTryCatchRule.RuleId,
        RuleConstants.ResourceBaseName,                                     // Name of the resource file to look up displayname and description in
        RuleConstants.EnforceTryCatch_RuleName,                // ID used to look up the display name inside the resources file
        RuleConstants.EnforceTryCatch_ProblemDescription,      // ID used to look up the description inside the resources file
        Category = RuleConstants.CategoryBasics,           // Rule category (e.g. "Design", "Naming")
        RuleScope = SqlRuleScope.Element)]                                  // This rule targets specific elements rather than the whole model
    public sealed class EnforceTryCatchRule : SqlCodeAnalysisRule
    {
        /// <summary>
        /// The Rule ID should resemble a fully-qualified class name. In the Visual Studio UI
        /// rules are grouped by "Namespace + Category", and each rule is shown using "Short ID: DisplayName".
        /// For this rule, it will be 
        /// shown as "DM0028: Stored Procedures and Triggers need at least one Try/Catch block."
        /// </summary>
        public const string RuleId = RuleConstants.EnforceTryCatch_RuleId;

        public EnforceTryCatchRule() {
            // This rule supports Procedures, Functions and Triggers. Only those objects will be passed to the Analyze method
            SupportedElementTypes = new[]
            {
                // Note: can use the ModelSchema definitions, or access the TypeClass for any of these types
                //ModelSchema.ExtendedProcedure,
                ModelSchema.Procedure,
                //ModelSchema.TableValuedFunction, 
                //ModelSchema.ScalarFunction,
                ModelSchema.DatabaseDdlTrigger,
                ModelSchema.DmlTrigger,
                ModelSchema.ServerDdlTrigger
            };
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

            IList<SqlRuleProblem> problems = new List<SqlRuleProblem>();

            TSqlObject modelElement = ruleExecutionContext.ModelElement;

            string elementName = RuleUtils.GetElementName(ruleExecutionContext, modelElement);

            // The rule execution context has all the objects we'll need, including the fragment representing the object,
            // and a descriptor that lets us access rule metadata
            TSqlFragment sqlFragment = ruleExecutionContext.ScriptFragment;
            RuleDescriptor ruleDescriptor = ruleExecutionContext.RuleDescriptor;

            DMVSettings.RefreshModelBuiltInCache(ruleExecutionContext.SchemaModel);

            // visitor to get the occurrences of try/catch statements
            TryCatchVisitor visitor = new TryCatchVisitor();
            sqlFragment.Accept(visitor);
            List<TryCatchStatement> tryCatchStatements = visitor.TryCatchStatements;

            var createProcedureStatement = sqlFragment as CreateProcedureStatement;
            var code = createProcedureStatement?.StatementList;
            bool onlyRestrictedStatementsFound = false;  

            //only applies to sp's, triggers normally do stuff that need trapping
            if (code != null)
            {
                onlyRestrictedStatementsFound = CheckForRestrictedStatementList(code,0 );
            }
            // Create problems for each try/catch not found 
            if (    tryCatchStatements.Count == 0 
                &&  (    (createProcedureStatement is null ) 
                      || (createProcedureStatement != null && ! onlyRestrictedStatementsFound ) 
                    ) 
               )
            {
                var problem = new SqlRuleProblem(string.Format(CultureInfo.CurrentCulture, ruleDescriptor.DisplayDescription, elementName)
                                                , modelElement
                                                , sqlFragment
                                                );

                problems.Add(problem);
            }

            return problems;
        }

        private static bool CheckForRestrictedStatementList(StatementList code, int selectCount)
        {
            if (code is null ) { return true; }

            foreach ( var s in code.Statements) {
                switch (s)
                {
                    case BeginEndAtomicBlockStatement statement:        
                        if ( CheckForRestrictedStatementList(statement.StatementList, selectCount) )  continue; else return false;
                    case BeginEndBlockStatement statement:
                        if (CheckForRestrictedStatementList(statement.StatementList, selectCount)) continue; else return false;
                    case SelectStatement selectStatement:
                        if (selectStatement.Into is null)
                        {
                            if (selectCount == 0)
                            {
                                selectCount++; continue;
                            }
                            else return false;
                        }
                        else { return false; };
                    case ReturnStatement _:
                        continue;
                    case SetCommandStatement _:
                        continue;
                    case SetOnOffStatement _:
                        continue;
                    case SetTextSizeStatement _:
                        continue;
                    case SetTransactionIsolationLevelStatement _:
                        continue;
                    case SetRowCountStatement _:
                        continue;
                    case SetErrorLevelStatement _:
                        continue;
                    default:
                        return false; 
                }
            }

            return true;
        }
    }
}
