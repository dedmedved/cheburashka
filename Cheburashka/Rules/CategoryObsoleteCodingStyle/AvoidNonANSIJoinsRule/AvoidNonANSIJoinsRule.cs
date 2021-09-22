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

namespace Cheburashka
{
    /// <summary>
    /// <para>
    /// This is a SQL rule which returns a warning message 
    /// whenever a non ANSI join expression appears inside a subroutine body. 
    /// This rule only applies to SQL views, stored procedures, functions and triggers.
    /// </para>
    /// <para>
    /// Note that this uses a Localized export attribute, and hence the rule name and description will be
    /// localized if resource files for different languages are used
    /// </para>
    /// </summary>
    [LocalizedExportCodeAnalysisRule(AvoidNonAnsiJoinsRule.RuleId,
        RuleConstants.ResourceBaseName,                                 // Name of the resource file to look up displayname and description in
        RuleConstants.AvoidNonAnsiJoinsRuleName,                             // ID used to look up the display name inside the resources file
        RuleConstants.AvoidNonAnsiJoinsProblemDescription,                   // ID used to look up the description inside the resources file
        Category = RuleConstants.CategoryObsoleteCodingStyle,           // Rule category (e.g. "Design", "Naming")
        RuleScope = SqlRuleScope.Element)]                              // This rule targets specific elements rather than the whole model
    public sealed class AvoidNonAnsiJoinsRule : SqlCodeAnalysisRule
    {
        /// <summary>
        /// The Rule ID should resemble a fully-qualified class name. In the Visual Studio UI
        /// rules are grouped by "Namespace + Category", and each rule is shown using "Short ID: DisplayName".
        /// For this rule, it will be 
        /// shown as "DM0043: Avoid non-ANSI joins.  Use ANSI syntax, or T-SQL Apply."
        /// </summary>
        public const string RuleId = RuleConstants.AvoidNonAnsiJoinsRuleId;

        public AvoidNonAnsiJoinsRule()
        {
            SupportedElementTypes = SqlRuleUtils.GetCodeAndViewContainingClasses();
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

            TSqlObject modelElement = ruleExecutionContext.ModelElement;

            string elementName = RuleUtils.GetElementName(ruleExecutionContext);

            // The rule execution context has all the objects we'll need, including the fragment representing the object,
            // and a descriptor that lets us access rule metadata
            TSqlFragment sqlFragment = ruleExecutionContext.ScriptFragment;
            RuleDescriptor ruleDescriptor = ruleExecutionContext.RuleDescriptor;

            DmvSettings.RefreshModelBuiltInCache(ruleExecutionContext.SchemaModel);

            // visitor to get the occurrences of non-ANSI join expressions
            var issues = DmTSqlFragmentVisitor.Visit(sqlFragment, new NonAnsiJoinVisitor());
            // Create problems for each non-ANSI join usage found 
            RuleUtils.UpdateProblems(problems, modelElement, elementName, issues, ruleDescriptor);
            return problems;
        }
    }
}
