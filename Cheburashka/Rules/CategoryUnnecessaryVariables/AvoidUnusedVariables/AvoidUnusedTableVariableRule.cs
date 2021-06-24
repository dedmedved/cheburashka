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
using System.Globalization;
using System.Linq;

namespace Cheburashka
{
    /// <summary>
    /// <para>
    /// This is a SQL rule which returns a warning message 
    /// whenever there is an unused table variable in a routine.
    /// </para>
    /// <para>
    /// Note that this uses a Localized export attribute, and hence the rule name and description will be
    /// localized if resource files for different languages are used
    /// </para>
    /// </summary>

    [LocalizedExportCodeAnalysisRule(AvoidUnusedTableVariableRule.RuleId,
        RuleConstants.ResourceBaseName,                                     // Name of the resource file to look up displayname and description in
        RuleConstants.AvoidUnusedTableVariable_RuleName,                    // ID used to look up the display name inside the resources file
        RuleConstants.AvoidUnusedTableVariable_ProblemDescription,          // ID used to look up the description inside the resources file
        Category = RuleConstants.CategoryUnnecessaryVariables,              // Rule category (e.g. "Design", "Naming")
        RuleScope = SqlRuleScope.Element)]                                  // This rule targets specific elements rather than the whole model
    public sealed class AvoidUnusedTableVariableRule : SqlCodeAnalysisRule
    {
        /// <summary>
        /// The Rule ID should resemble a fully-qualified class name. In the Visual Studio UI
        /// rules are grouped by "Namespace + Category", and each rule is shown using "Short ID: DisplayName".
        /// For this rule, it will be 
        /// shown as "DM0004: Unused Table Variables point to potential coding errors."
        /// </summary>
        public const string RuleId = RuleConstants.AvoidUnusedTableVariable_RuleId;

        public AvoidUnusedTableVariableRule()
        {
            SupportedElementTypes = SqlRuleUtils.GetCodeContainingClasses();
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
            DMVRuleSetup.RuleSetup(ruleExecutionContext, out List<SqlRuleProblem> problems, out _, out TSqlFragment sqlFragment, out TSqlObject modelElement);

            string elementName = RuleUtils.GetElementName(ruleExecutionContext);

            // The rule execution context has all the objects we'll need, including the fragment representing the object,
            // and a descriptor that lets us access rule metadata
            RuleDescriptor ruleDescriptor = ruleExecutionContext.RuleDescriptor;

            DMVSettings.RefreshModelBuiltInCache(ruleExecutionContext.SchemaModel);

            // visitor to get the declarations of table variables
            var tableVariableDeclarations = DmTSqlFragmentVisitor.Visit(sqlFragment, new TableVariableDeclarationVisitor()).Cast<Identifier>().ToList();
            // visitor to get parameter names - these look like variables and need removing
            // from variable references before we use them
            var namedParameters = DmTSqlFragmentVisitor.Visit(sqlFragment, new NamedParameterUsageVisitor()).Cast<VariableReference>().ToList();
            // visitor to get the occurrences of variables
            var allVariableLikeReferences = DmTSqlFragmentVisitor.Visit(sqlFragment, new VariableTableReferenceVisitor()).Cast<VariableReference>().ToList();
            // remove all named parameters from the list of referenced variables
            IList<VariableReference> variableReferences = allVariableLikeReferences.Except(namedParameters, new SqlVariableReferenceComparer()).ToList();

            var objects = new Dictionary<string, Identifier>(SqlComparer.Comparer);
            var counts = new Dictionary<string, int>(SqlComparer.Comparer);

            foreach (Identifier variableDeclaration in tableVariableDeclarations) // variable declarations are unique collation-wise so add will work w/o error
            {
                objects.Add(variableDeclaration.Value, variableDeclaration);
            }

            foreach (VariableReference variableReference in variableReferences)
            {
                if (!counts.ContainsKey(variableReference.Name))// only need to notice the first occurrence
                {
                    counts.Add(variableReference.Name, 1);
                }
            }

            foreach (var key in objects.Keys)
            {
                if ((counts.ContainsKey(key) && counts[key] == 0)
                   || !counts.ContainsKey(key)
                   )
                {
                    var problem =
                        new SqlRuleProblem(
                            string.Format(CultureInfo.CurrentCulture, ruleDescriptor.DisplayDescription, elementName)
                            , modelElement
                            , sqlFragment);

                    RuleUtils.UpdateProblemPosition(modelElement, problem, objects[key]);
                    problems.Add(problem);
                }
            }

            return problems;
        }
    }
}
