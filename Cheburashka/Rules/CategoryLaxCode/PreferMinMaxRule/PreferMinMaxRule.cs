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
using Microsoft.SqlServer.Dac.CodeAnalysis;
using Microsoft.SqlServer.Dac.Model;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Cheburashka
{
    /// <summary>
    /// <para>
    /// This is a SQL rule which returns a warning message 
    /// whenever there is a scalar subquery which should be supported by a unique constraint
    /// </para>
    /// <para>
    /// Note that this uses a Localized export attribute, and hence the rule name and description will be
    /// localized if resource files for different languages are used
    /// </para>
    /// </summary>

    [LocalizedExportCodeAnalysisRule( PreferMinMaxRule.RuleId,
        RuleConstants.ResourceBaseName,                                             // Name of the resource file to look up display name and description in
        RuleConstants.PreferMinMaxRuleName,                                         // ID used to look up the display name inside the resources file
        RuleConstants.PreferMinMaxProblemDescription,                               // ID used to look up the description inside the resources file
        Category = RuleConstants.CategoryEfficiency,                                // Rule category (e.g. "Design", "Naming")
        RuleScope = SqlRuleScope.Element)]                                          // This rule targets specific elements rather than the whole model
    public sealed class PreferMinMaxRule : SqlCodeAnalysisRule
    {
        /// <summary>
        /// The Rule ID should resemble a fully-qualified class name. In the Visual Studio UI
        /// rules are grouped by "Namespace + Category", and each rule is shown using "Short ID: DisplayName".
        /// For this rule, it will be 
        /// shown as "DM0071: Prefer using MIN and MAX to Select top 1 Col ... order by Col. Aggregate functions MIN() and MAX() are more efficent."
        /// </summary>
        public const string RuleId = RuleConstants.PreferMinMaxRuleId;

        public PreferMinMaxRule()
        {
            SupportedElementTypes = SqlRuleUtils.GetCodeAndViewContainingClasses();
        }

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext ruleExecutionContext)
        {
            DmvRuleSetup.RuleSetup(ruleExecutionContext, out var problems, out TSqlModel model, out TSqlFragment sqlFragment, out TSqlObject modelElement);
            // Get Model collation 
            SqlComparer.Comparer = ruleExecutionContext.SchemaModel.CollationComparer;

            string elementName = RuleUtils.GetElementName(ruleExecutionContext);
            // The rule execution context has all the objects we'll need, including the fragment representing the object,
            // and a descriptor that lets us access rule metadata
            DmvSettings.RefreshModelBuiltInCache(ruleExecutionContext.SchemaModel);

            // get normal query and subquery separately
            var SingleColumnQueryTop1OrderSubQueries = DmTSqlFragmentVisitor.Visit(sqlFragment, new SingleColumnQueryTop1OrderByVisitor());
            RuleDescriptor ruleDescriptor = ruleExecutionContext.RuleDescriptor;
            RuleUtils.UpdateProblems( problems, modelElement, elementName, SingleColumnQueryTop1OrderSubQueries, ruleDescriptor);

            return problems;
        }
    }
}
