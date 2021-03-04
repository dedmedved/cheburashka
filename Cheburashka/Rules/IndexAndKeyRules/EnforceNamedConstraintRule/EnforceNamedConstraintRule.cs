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
using Microsoft.SqlServer.Dac;
using Microsoft.SqlServer.Dac.CodeAnalysis;
using Microsoft.SqlServer.Dac.Model;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.IO;

using Cheburashka;

namespace Cheburashka
{
    /// <summary>
    /// <para>
    /// This is a SQL rule which returns a warning message 
    /// whenever there is an un-named constraint
    /// </para>
    /// <para>
    /// Note that this uses a Localized export attribute, and hence the rule name and description will be
    /// localized if resource files for different languages are used
    /// </para>
    /// </summary>

    [LocalizedExportCodeAnalysisRule(EnforceNamedConstraintRule.RuleId,
        RuleConstants.ResourceBaseName,                                  // Name of the resource file to look up displayname and description in
        RuleConstants.EnforceNamedConstraint_RuleName,                   // ID used to look up the display name inside the resources file
        RuleConstants.EnforceNamedConstraint_ProblemDescription,         // ID used to look up the description inside the resources file
        Category = RuleConstants.CategoryDatabaseStructures,             // Rule category (e.g. "Design", "Naming")
        RuleScope = SqlRuleScope.Element)]                               // This rule targets specific elements rather than the whole model
    public sealed class EnforceNamedConstraintRule: SqlCodeAnalysisRule
    {
        /// <summary>
        /// The Rule ID should resemble a fully-qualified class name. In the Visual Studio UI
        /// rules are grouped by "Namespace + Category", and each rule is shown using "Short ID: DisplayName".
        /// For this rule, it will be 
        /// shown as "DM0022: Avoid unnamed constraints.  These are assigned meaningless system-generated names at time of deployment."
        /// </summary>
        public const string RuleId = RuleConstants.EnforceNamedConstraintRuleId;

        public EnforceNamedConstraintRule()
        {
            // This rule supports Table,Triggers and Procedures. Only those objects will be passed to the Analyze method

            //[SupportedElementType(typeof(ISqlProcedure))]
            //[SupportedElementType(typeof(ISqlTrigger))]
            //[SupportedElementType(typeof(ISqlFunction))]
            //[SupportedElementType(typeof(ISqlView))]
            //[SupportedElementType(typeof(ISqlTable))]

            SupportedElementTypes = new[]
            {
                // Note: can use the ModelSchema definitions, or access the TypeClass for any of these types
                ModelSchema.Table,
                ModelSchema.Procedure,
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

            List<SqlRuleProblem> problems = new List<SqlRuleProblem>();

            try
            {

                DMVRuleSetup.RuleSetup(ruleExecutionContext, out problems, out TSqlModel model,
                    out TSqlFragment sqlFragment, out TSqlObject modelElement);

                // If we can't find the file then assume we're in a composite model
                // and the elements are defined there and
                // should be analysed there
                if (modelElement.GetSourceInformation() is null)
                {
                    return problems;
                }

                string elementName = RuleUtils.GetElementName(ruleExecutionContext, modelElement);

                // Get Database Schema and name of this model element.
                DMVRuleSetup.GetLocalObjectNameParts(modelElement, out string objectSchema, out string objectName);

                DMVSettings.RefreshModelBuiltInCache(model);

                // visitor to get the occurrences of constraints we want to be named
                EnforceNamedConstraintVisitor enforceNamedConstraintVisitor = new EnforceNamedConstraintVisitor();
                sqlFragment.Accept(enforceNamedConstraintVisitor);
                List<ConstraintDefinition>
                    constraints = enforceNamedConstraintVisitor.Constraints; //.Cast<TSqlFragment>().ToList();

                // visitor to get the occurrences of table variable declarations we are not interested in 
                EnforceNamedConstraintDeclareTableVisitor enforceNamedConstraintDeclareTableVisitor =
                    new EnforceNamedConstraintDeclareTableVisitor();
                sqlFragment.Accept(enforceNamedConstraintDeclareTableVisitor);
                List<TSqlFragment> tableDeclarations = enforceNamedConstraintDeclareTableVisitor.Objects;

                // every unnamed constraint ( outside of table declaration ) is a problem.
                List<ConstraintDefinition> issues = constraints
                    .Where(cons => !tableDeclarations.Any(dec => SqlComparisonUtils.SQLModel_Contains(dec, cons)))
                    .Select(n => n).ToList();

                // Create problems for each constraint wo a name
                RuleDescriptor ruleDescriptor = ruleExecutionContext.RuleDescriptor;
                foreach (TSqlFragment issue in issues)
                {
                    var problem = new SqlRuleProblem(
                        String.Format(CultureInfo.CurrentCulture, ruleDescriptor.DisplayDescription, elementName)
                        , modelElement
                        , sqlFragment);

                    RuleUtils.UpdateProblemPosition(modelElement, problem, (TSqlFragment) issue);
                    problems.Add(problem);
                }

            }
            catch { } // DMVRuleSetup.RuleSetup barfs on 'hidden' temporal history tables 'defined' in sub-projects

            return problems;
        }
    }
}
