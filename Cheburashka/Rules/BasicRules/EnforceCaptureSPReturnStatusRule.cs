﻿//------------------------------------------------------------------------------
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
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Cheburashka
{
    /// <summary>
    /// This is a SQL rule which returns a warning message 
    /// whenever a stored procedure is called and its return status is not captured. 
    /// This rule only applies to SQL stored procedures, and triggers.
    /// 
    /// Note that this uses a Localized export attribute, and hence the rule name and description will be
    /// localized if resource files for different languages are used
    /// </summary>
    [LocalizedExportCodeAnalysisRule(EnforceCaptureSPReturnStatusRule.RuleId,
        RuleConstants.ResourceBaseName,                                     // Name of the resource file to look up displayname and description in
        RuleConstants.EnforceCaptureSPReturnStatus_RuleName,                // ID used to look up the display name inside the resources file
        RuleConstants.EnforceCaptureSPReturnStatus_ProblemDescription,      // ID used to look up the description inside the resources file
        Category = RuleConstants.CategoryBasics,           // Rule category (e.g. "Design", "Naming")
        RuleScope = SqlRuleScope.Element)]                                  // This rule targets specific elements rather than the whole model
    public sealed class EnforceCaptureSPReturnStatusRule : SqlCodeAnalysisRule
    {
        /// <summary>
        /// The Rule ID should resemble a fully-qualified class name. In the Visual Studio UI
        /// rules are grouped by "Namespace + Category", and each rule is shown using "Short ID: DisplayName".
        /// For this rule, it will be 
        /// shown as "DM0026: Return status should always be retrieved.."
        /// </summary>
        public const string RuleId = RuleConstants.EnforceCaptureSPReturnStatus_RuleId;

        public EnforceCaptureSPReturnStatusRule()
        {
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

            // visitor to get the occurrences of execute statements
            EnforceCaptureSPReturnStatusVisitor visitor = new EnforceCaptureSPReturnStatusVisitor();
            sqlFragment.Accept(visitor);
            IList<ExecuteSpecification> executeSpecifications = visitor.ExecuteSpecifications;

            // Create problems for each uncaptured execute found 
            foreach (var executeSpecification in executeSpecifications)
            {
                var problem = new SqlRuleProblem( String.Format(CultureInfo.CurrentCulture, ruleDescriptor.DisplayDescription, elementName)
                                                , modelElement
                                                , executeSpecification
                                                );

                problems.Add(problem);
            }

            return problems;

        }
    }
}