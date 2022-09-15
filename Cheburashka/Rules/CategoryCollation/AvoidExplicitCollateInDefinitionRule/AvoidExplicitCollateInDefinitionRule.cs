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
    /// whenever there is a schema object referred to without the schema name.
    /// </para>
    /// <para>
    /// Note that this uses a Localized export attribute, and hence the rule name and description will be
    /// localized if resource files for different languages are used
    /// </para>
    /// </summary>

    [LocalizedExportCodeAnalysisRule(AvoidExplicitCollateInDefinitionRule.RuleId,
        RuleConstants.ResourceBaseName,                                         // Name of the resource file to look up display name and description in
        RuleConstants.AvoidExplicitCollateInDefinitionRuleName,                 // ID used to look up the display name inside the resources file
        RuleConstants.AvoidExplicitCollateInDefinitionProblemDescription,       // ID used to look up the description inside the resources file
        Category = RuleConstants.CategoryCollation,                             // Rule category (e.g. "Design", "Naming")
        RuleScope = SqlRuleScope.Element)]                                      // This rule targets specific elements rather than the whole model
    public sealed class AvoidExplicitCollateInDefinitionRule : SqlCodeAnalysisRule
    {
        /// <summary>
        /// <para>
        /// The Rule ID should resemble a fully-qualified class name. In the Visual Studio UI
        /// rules are grouped by "Namespace + Category", and each rule is shown using "Short ID: DisplayName".
        /// </para>
        /// <para>
        /// For this rule, it will be 
        /// shown as "DM0021: Avoid specifying collations unless absolutely necessary.  Rely on the collation defined in the project or target database."
        /// </para>
        /// </summary>
        public const string RuleId = RuleConstants.AvoidExplicitCollateInDefinitionRuleId;

        public AvoidExplicitCollateInDefinitionRule()
        {
            SupportedElementTypes = SqlRuleUtils.GetExpressionContainingClasses(); 
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
                DmvRuleSetup.RuleSetup(ruleExecutionContext, out problems, out TSqlModel model,out TSqlFragment sqlFragment, out TSqlObject modelElement);
                string elementName = RuleUtils.GetElementName(ruleExecutionContext);
                // visitor to get the columns
                var collateExpressions = DmTSqlFragmentVisitor.Visit(sqlFragment, new AvoidExplicitCollateVisitor());
                // The rule execution context has all the objects we'll need, including the fragment representing the object,
                // and a descriptor that lets us access rule metadata
                RuleDescriptor ruleDescriptor = ruleExecutionContext.RuleDescriptor;
                RuleUtils.UpdateProblems(problems, modelElement, elementName, collateExpressions, ruleDescriptor);
            }
            catch
            {
            } // DMVRuleSetup.RuleSetup barfs on 'hidden' temporal history tables 'defined' in sub-projects

            return problems;
            }
    }
}
