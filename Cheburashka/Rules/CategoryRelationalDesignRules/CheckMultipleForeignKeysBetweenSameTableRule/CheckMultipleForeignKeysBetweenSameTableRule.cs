﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

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
using Microsoft.SqlServer.Dac.CodeAnalysis;
using Microsoft.SqlServer.Dac.Model;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System.Collections.Generic;
using System.Linq;

namespace Cheburashka
{
    /// <summary>
    /// <para>
    /// This is a SQL rule which returns a warning message 
    /// whenever there is are two tables in a model linked by more than one foreign key.
    /// It's not wrong to do this, but it might represent an inadequately normalised design.
    /// </para>
    /// <para>
    /// Note that this uses a Localized export attribute, and hence the rule name and description will be
    /// localized if resource files for different languages are used
    /// </para>
    /// </summary>

    [LocalizedExportCodeAnalysisRule(CheckMultipleForeignKeysBetweenSameTableRule.RuleId,
        RuleConstants.ResourceBaseName,                                                         // Name of the resource file to look up displayname and description in
        RuleConstants.CheckMultipleForeignKeysBetweenTheSameTable_RuleName,                     // ID used to look up the display name inside the resources file
        RuleConstants.CheckMultipleForeignKeysBetweenTheSameTable_ProblemDescription,           // ID used to look up the description inside the resources file
        Category = RuleConstants.CategoryRelationalDesignKeys,                                  // Rule category (e.g. "Design", "Naming")
        RuleScope = SqlRuleScope.Element)]                                                      // This rule targets specific elements rather than the whole model
    public sealed class CheckMultipleForeignKeysBetweenSameTableRule: SqlCodeAnalysisRule
    {
        /// <summary>
        /// <para>
        /// The Rule ID should resemble a fully-qualified class name. In the Visual Studio UI
        /// rules are grouped by "Namespace + Category", and each rule is shown using "Short ID: DisplayName".
        /// </para>
        /// <para>
        /// For this rule, it will be 
        /// shown as "DM0035: Apart from tables modeling graph structures, and role-playing tables, it's unusual to find multiple relationships between two tables.  It may indicate a non-normal database design."
        /// </para>
        /// </summary>
        public const string RuleId = RuleConstants.CheckMultipleForeignKeysBetweenTheSameTable_RuleId;

        public CheckMultipleForeignKeysBetweenSameTableRule()
        {
            SupportedElementTypes = SqlRuleUtils.GetForeignKeyConstraintClass();
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
                DMVRuleSetup.RuleSetup(ruleExecutionContext, out problems, out TSqlModel model,
                    out TSqlFragment sqlFragment, out TSqlObject modelElement);
                string elementName = RuleUtils.GetElementName(ruleExecutionContext);
                if (sqlFragment is CreateTableStatement createTableStatement && (createTableStatement.AsNode ||
                    createTableStatement.AsEdge || createTableStatement.AsFileTable))
                {
                    return problems;
                }

                // If we can't find the file then assume we're in a composite model
                // and the elements are defined there and
                // should be analysed there
                if (modelElement.GetSourceInformation() is null)
                {
                    return problems;
                }

                // Get Database Schema and name of this model element.
                //string owningObjectSchema = modelElement.Name.Parts[0];
                //string owningObjectTable = modelElement.Name.Parts[1];

                DMVSettings.RefreshModelBuiltInCache(model);
                DMVSettings.RefreshConstraintsAndIndexesCache(model);
                var allFKs =
                    DMVSettings
                        .GetForeignKeys; 

                TSqlObject table = modelElement;

                // Get a reference to the main temporal table. 
                var mainTables = table.GetReferencing(Table.TemporalSystemVersioningHistoryTable).ToList();
                //TSqlObject mainTable;
                //string mainTableschema ;
                //string mainTablename ;
                // if there is a main table
                // this is a history table and can be ignored 'ish
                // for the purpose of fk rules
                if (mainTables.Count > 0)
                {
                    return problems;
                }

                var fksCount = 0  ;

                var thisForeignTable = modelElement.GetReferenced(ForeignKeyConstraint.ForeignTable).ToList();
                var thisHostTable = modelElement.GetReferenced(ForeignKeyConstraint.Host).ToList();

                var thisForeignTableschema = thisForeignTable[0].Name.Parts[0];
                var thisForeignTablename = thisForeignTable[0].Name.Parts[1];

                var thisHostTableschema = thisHostTable[0].Name.Parts[0];
                var thisHostTablename = thisHostTable[0].Name.Parts[1];

                bool multipleFKS = false;

                foreach (var thing in allFKs)
                {
                    var host = thing.GetReferenced(ForeignKeyConstraint.Host).ToList();
                    var foreignTable = thing.GetReferenced(ForeignKeyConstraint.ForeignTable).ToList();

                    if (host.Count > 0 && foreignTable.Count > 0)
                    {
                        var hostschema = host[0].Name.Parts[0];
                        var hostname = host[0].Name.Parts[1];

                        var foreignTableschema = foreignTable[0].Name.Parts[0];
                        var foreignTablename = foreignTable[0].Name.Parts[1];

                        if (hostname.SQLModel_StringCompareEqual(thisHostTablename)
                            && hostschema.SQLModel_StringCompareEqual(thisHostTableschema)
                            && foreignTablename.SQLModel_StringCompareEqual(thisForeignTablename)
                            && foreignTableschema.SQLModel_StringCompareEqual(thisForeignTableschema)
                        )
                        { 
                            fksCount++;
                        }
                        if (fksCount > 1) {
                            multipleFKS = true;
                            break;
                        }
                    }
                }

                // The rule execution context has all the objects we'll need, including the fragment representing the object,
                // and a descriptor that lets us access rule metadata
                RuleDescriptor ruleDescriptor = ruleExecutionContext.RuleDescriptor;
                RuleUtils.UpdateProblems(multipleFKS,problems, modelElement, elementName, sqlFragment, ruleDescriptor);
            }
            catch { } // DMVRuleSetup.RuleSetup barfs on 'hidden' temporal history tables 'defined' in sub-projects

            return problems;
        }
    }
}
