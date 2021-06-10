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
    /// whenever a RETURN statement without a return value appears inside a subroutine body. 
    /// This rule only applies to SQL stored procedures.
    /// </para>
    /// <para>
    /// Note that this uses a Localized export attribute, and hence the rule name and description will be
    /// localized if resource files for different languages are used
    /// </para>
    /// </summary>
    [LocalizedExportCodeAnalysisRule(CheckOpenTransactionCountCodeRule.RuleId,
        RuleConstants.ResourceBaseName,                                     // Name of the resource file to look up displayname and description in
        RuleConstants.CheckOpenTransactionCountCode_RuleName,               // ID used to look up the display name inside the resources file
        RuleConstants.CheckOpenTransactionCountCode_ProblemDescription,     // ID used to look up the description inside the resources file
        Category = RuleConstants.CategoryBasics,                            // Rule category (e.g. "Design", "Naming")
        RuleScope = SqlRuleScope.Element)]                                  // This rule targets specific elements rather than the whole model
    public sealed class CheckOpenTransactionCountCodeRule : SqlCodeAnalysisRule
    {
        /// <summary>
        /// The Rule ID should resemble a fully-qualified class name. In the Visual Studio UI
        /// rules are grouped by "Namespace + Category", and each rule is shown using "Short ID: DisplayName".
        /// For this rule, it will be 
        /// shown as "DM0045: Neither @@trancount not xact_state() by themselves give the full picture of the number of open transaction.  Check both."
        /// </summary>
        public const string RuleId = RuleConstants.CheckOpenTransactionCountCode_RuleId;

        public CheckOpenTransactionCountCodeRule()
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

            List<SqlRuleProblem> problems = new();

            TSqlObject modelElement = ruleExecutionContext.ModelElement;

            string elementName = RuleUtils.GetElementName(ruleExecutionContext, modelElement);

            // The rule execution context has all the objects we'll need, including the fragment representing the object,
            // and a descriptor that lets us access rule metadata
            TSqlFragment sqlFragment = ruleExecutionContext.ScriptFragment;

            DMVSettings.RefreshModelBuiltInCache(ruleExecutionContext.SchemaModel);

            // visitor to get the occurrences of if and while statement expressions
            var checkOpenTransactionCountCodeVisitor = new CheckOpenTransactionCountCodeVisitor();
            sqlFragment.Accept(checkOpenTransactionCountCodeVisitor);
            var expressions = checkOpenTransactionCountCodeVisitor.Expressions;

            var issues = new List<TSqlFragment>();
            foreach ( var expr in expressions) {

                var trancountVisitor = new TrancountVisitor();
                var xact_stateVisitor = new Xact_StateVisitor();

                expr.Accept(trancountVisitor);
                expr.Accept(xact_stateVisitor);
                // This is a really poor way of checking for epxressoin correctness - but in general its the best that can be done
                if (   (trancountVisitor.Expressions.Count >  0 && xact_stateVisitor.Expressions.Count == 0)
                    || (trancountVisitor.Expressions.Count == 0 && xact_stateVisitor.Expressions.Count >  0)
                    ) {
                    issues.Add(expr);
                }
            }

            // Create problems for each unused label found 
            RuleDescriptor ruleDescriptor = ruleExecutionContext.RuleDescriptor;
            RuleUtils.UpdateProblems(problems, modelElement, elementName, issues, ruleDescriptor);
            return problems;
        }
    }
}
