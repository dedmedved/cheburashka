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
    /// whenever there is an unused variable in a routine.
    /// </para>
    /// <para>
    /// Note that this uses a Localized export attribute, and hence the rule name and description will be
    /// localized if resource files for different languages are used
    /// </para>
    /// </summary>

    [LocalizedExportCodeAnalysisRule(AvoidUnusedVariablesRule.RuleId,
        RuleConstants.ResourceBaseName,                                     // Name of the resource file to look up displayname and description in
        RuleConstants.AvoidUnusedVariables_RuleName,                        // ID used to look up the display name inside the resources file
        RuleConstants.AvoidUnusedVariables_ProblemDescription,              // ID used to look up the description inside the resources file
        Category = RuleConstants.CategoryVariableUsage,                           // Rule category (e.g. "Design", "Naming")
        RuleScope = SqlRuleScope.Element)]                                  // This rule targets specific elements rather than the whole model
    public sealed class AvoidUnusedVariablesRule : SqlCodeAnalysisRule
    {
        /// <summary>
        /// The Rule ID should resemble a fully-qualified class name. In the Visual Studio UI
        /// rules are grouped by "Namespace + Category", and each rule is shown using "Short ID: DisplayName".
        /// For this rule, it will be 
        /// shown as "DM0002: Unused Variables point to potential coding errors."
        /// </summary>
        public const string RuleId = RuleConstants.AvoidUnusedVariables_RuleId;

        public AvoidUnusedVariablesRule()
        {
            // This rule supports Procedures. Only those objects will be passed to the Analyze method
            SupportedElementTypes = new[]
            {
                // Note: can use the ModelSchema definitions, or access the TypeClass for any of these types
                //ModelSchema.ExtendedProcedure,
                ModelSchema.Procedure,
                ModelSchema.TableValuedFunction,
                ModelSchema.ScalarFunction,

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
            DMVRuleSetup.RuleSetup(ruleExecutionContext, out List<SqlRuleProblem> problems, out _, out TSqlFragment sqlFragment, out TSqlObject modelElement);

            string elementName = RuleUtils.GetElementName(ruleExecutionContext, modelElement);

            // The rule execution context has all the objects we'll need, including the fragment representing the object,
            // and a descriptor that lets us access rule metadata

            RuleDescriptor ruleDescriptor = ruleExecutionContext.RuleDescriptor;

            DMVSettings.RefreshModelBuiltInCache(ruleExecutionContext.SchemaModel);

            // visitor to get the declarations of variables
            var declarationVisitor = new VariableDeclarationVisitor();
            sqlFragment.Accept(declarationVisitor);
            IList<Identifier> variableDeclarations = declarationVisitor.VariableDeclarations;

            // visitor to get parameter names - these look like variables and need removing
            // from variable references before we use them
            var namedParameterUsageVisitor = new NamedParameterUsageVisitor();
            sqlFragment.Accept(namedParameterUsageVisitor);
            IEnumerable<VariableReference> namedParameters = namedParameterUsageVisitor.NamedParameters;

            // visitor to get the occurrences of variables
            var usageVisitor = new VariableUsageVisitor();
            sqlFragment.Accept(usageVisitor);
            IEnumerable<VariableReference> allVariableLikeReferences = usageVisitor.VariableReferences;

            // remove all named parameters from the list of referenced variables

//TODO - work out how to eliminate based solely on name.

            IEnumerable<VariableReference> tmpVr = allVariableLikeReferences.Except(namedParameters, new SqlVariableReferenceComparer());

            List<VariableReference> variableReferences = tmpVr.ToList();

            var objects = new Dictionary<string, Identifier>(SqlComparer.Comparer);
            var counts = new Dictionary<string, int>(SqlComparer.Comparer);

            foreach (Identifier variableDeclaration in variableDeclarations)    // variable declarations are unique collation-wise so add will work w/o error
            {
                objects.Add(variableDeclaration.Value, variableDeclaration);
            }

            foreach (VariableReference variableReference in variableReferences)
            {
                if (!counts.ContainsKey(variableReference.Name)) // only need the 1st occurrence
                {
                    counts.Add(variableReference.Name, 1);
                }
            }

            foreach (var key in objects.Keys)
            {
                if (  (counts.ContainsKey(key) && counts[key] == 0)
                   || !counts.ContainsKey(key)
                   )
                {
                    SqlRuleProblem problem =
                        new(
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
