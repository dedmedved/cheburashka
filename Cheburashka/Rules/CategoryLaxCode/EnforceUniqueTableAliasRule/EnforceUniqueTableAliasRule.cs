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
    /// whenever a data source an alias appears multiple times inside DML.
    /// This rule only applies to any DML containing object
    /// </para>
    /// <para>
    /// Note that this uses a Localized export attribute, and hence the rule name and description will be
    /// localized if resource files for different languages are used
    /// </para>
    /// </summary>
    [LocalizedExportCodeAnalysisRule(EnforceUniqueTableAliasRule.RuleId,
        RuleConstants.ResourceBaseName,                                     // Name of the resource file to look up displayname and description in
        RuleConstants.EnforceUniqueTableAliasRuleName,                      // ID used to look up the display name inside the resources file
        RuleConstants.EnforceUniqueTableAliasProblemDescription,            // ID used to look up the description inside the resources file
        Category = RuleConstants.CategoryNonStrictCodingStyleNames,         // Rule category (e.g. "Design", "Naming")
        RuleScope = SqlRuleScope.Element)]                                  // This rule targets specific elements rather than the whole model
    public sealed class EnforceUniqueTableAliasRule : SqlCodeAnalysisRule
    {
        /// <summary>
        /// The Rule ID should resemble a fully-qualified class name. In the Visual Studio UI
        /// rules are grouped by "Namespace + Category", and each rule is shown using "Short ID: DisplayName".
        /// For this rule, it will be 
        /// shown as "DM0056: Avoiding using the same table alias multiple times in a single SQL statement."
        /// </summary>
        public const string RuleId = RuleConstants.EnforceUniqueTableAliasRuleId;

        public EnforceUniqueTableAliasRule()
        {
            SupportedElementTypes = SqlRuleUtils.GetCodeAndViewContainingClasses();
        }

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext ruleExecutionContext)
        {
            // Get Model collation 
            SqlComparer.Comparer = ruleExecutionContext.SchemaModel.CollationComparer;
            List<TSqlFragment> issues = new();
            List<SqlRuleProblem> problems = new();
            TSqlObject modelElement = ruleExecutionContext.ModelElement;

            string elementName = RuleUtils.GetElementName(ruleExecutionContext);
            // The rule execution context has all the objects we'll need, including the fragment representing the object,
            // and a descriptor that lets us access rule metadata
            TSqlFragment sqlFragment = ruleExecutionContext.ScriptFragment;
            DmvSettings.RefreshModelBuiltInCache(ruleExecutionContext.SchemaModel);

            //Find all DMLs and top-level SET statements source by a sub-query
            var allDmLs = DmTSqlFragmentVisitor.Visit(sqlFragment, new DmlsqlVisitor());
            var allSetSqlFragments = DmTSqlFragmentVisitor.Visit(sqlFragment, new SetEqualFromSubQueryVisitor());

            foreach (var dml in allDmLs)
            {
                var aliases = DmTSqlFragmentVisitor.Visit(dml, new EnforceUniqueTableAliasVisitor()).Cast<Identifier>();
                var duplicates = new Dictionary<string, List<Identifier>>(SqlComparer.Comparer);
                foreach (var alias in aliases)
                {
                    if (!duplicates.ContainsKey(alias.Value))
                    {
                        duplicates.Add(alias.Value, new List<Identifier>());
                    }
                    duplicates[alias.Value].Add(alias);
                }

                foreach (var k in duplicates.Keys.Where(n => duplicates[n].Count > 1))
                {
                    issues.AddRange(duplicates[k]);
                }
            }

            foreach ( var setSqlFragment in allSetSqlFragments )
            {
                var aliases = DmTSqlFragmentVisitor.Visit(setSqlFragment, new EnforceUniqueTableAliasVisitor()).Cast<Identifier>();
                var duplicates = new Dictionary<string, List<Identifier>>(SqlComparer.Comparer);
                foreach (var alias in aliases)
                {
                    if (!duplicates.ContainsKey(alias.Value))
                    {
                        duplicates.Add(alias.Value, new List<Identifier>());
                    }
                    duplicates[alias.Value].Add(alias);
                }

                foreach (var k in duplicates.Keys.Where(n => duplicates[n].Count > 1))
                {
                    issues.AddRange(duplicates[k]);
                }
            }

            RuleDescriptor ruleDescriptor = ruleExecutionContext.RuleDescriptor;
            RuleUtils.UpdateProblems( problems, modelElement, elementName, issues, ruleDescriptor);

            return problems;
        }
    }
}