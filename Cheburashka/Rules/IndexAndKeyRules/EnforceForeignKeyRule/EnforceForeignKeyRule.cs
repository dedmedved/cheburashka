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
    /// whenever there is an table in a model without a Foreign key.
    /// </para>
    /// <para>
    /// Note that this uses a Localized export attribute, and hence the rule name and description will be
    /// localized if resource files for different languages are used
    /// </para>
    /// </summary>

    [LocalizedExportCodeAnalysisRule(EnforceForeignKeyRule.RuleId,
        RuleConstants.ResourceBaseName,                                  // Name of the resource file to look up displayname and description in
        RuleConstants.EnforceForeignKey_RuleName,                        // ID used to look up the display name inside the resources file
        RuleConstants.EnforceForeignKey_ProblemDescription,              // ID used to look up the description inside the resources file
        Category = RuleConstants.CategoryDatabaseStructures,             // Rule category (e.g. "Design", "Naming")
        RuleScope = SqlRuleScope.Element)]                               // This rule targets specific elements rather than the whole model
    public sealed class EnforceForeignKeyRule: SqlCodeAnalysisRule
    {
        /// <summary>
        /// The Rule ID should resemble a fully-qualified class name. In the Visual Studio UI
        /// rules are grouped by "Namespace + Category", and each rule is shown using "Short ID: DisplayName".
        /// For this rule, it will be 
        /// shown as "DM0033: Tables should normally have a Foreign Key relationship with at least one other table."
        /// </summary>
        public const string RuleId = RuleConstants.EnforceForeignKey_RuleId;

        public EnforceForeignKeyRule()
        {
            // This rule supports Tables. Only those objects will be passed to the Analyze method
            SupportedElementTypes = new[]
            {
                // Note: can use the ModelSchema definitions, or access the TypeClass for any of these types
                ModelSchema.Table
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
            TSqlModel           model;
            TSqlObject          modelElement;
            TSqlFragment        sqlFragment;

            DMVRuleSetup.RuleSetup(ruleExecutionContext, out problems, out model, out sqlFragment, out modelElement);
            string elementName = RuleUtils.GetElementName(ruleExecutionContext, modelElement);

            // Get Database Schema and name of this model element.
            string owningObjectSchema = modelElement.Name.Parts[0];
            string owningObjectTable = modelElement.Name.Parts[1];

            DMVSettings.RefreshModelBuiltInCache(model);

            var allFKs = DMVSettings.GetForeignKeys;// model.GetObjects(DacQueryScopes.UserDefined, ForeignKeyConstraint.TypeClass).ToList();

            bool bFoundForeignKey = false;

            foreach (var thing in allFKs)   {
                if (!bFoundForeignKey) {
                    TSqlObject tab = thing.GetReferenced(ForeignKeyConstraint.Host).ToList()[0];
                    TSqlObject tab2 = thing.GetReferenced(ForeignKeyConstraint.ForeignTable).ToList()[0];

                    if (    (   tab.Name.Parts[1].SQLModel_StringCompareEqual(owningObjectTable)
                        &&      tab.Name.Parts[0].SQLModel_StringCompareEqual(owningObjectSchema))
                        ||  (   tab2.Name.Parts[1].SQLModel_StringCompareEqual(owningObjectTable)
                        &&      tab2.Name.Parts[0].SQLModel_StringCompareEqual(owningObjectSchema))
                        )
                    {
                        bFoundForeignKey = true;
                        //break;
                    }
                }
            }

            // The rule execution context has all the objects we'll need, including the fragment representing the object,
            // and a descriptor that lets us access rule metadata
            RuleDescriptor ruleDescriptor = ruleExecutionContext.RuleDescriptor;

            if (!bFoundForeignKey)
            {
                SqlRuleProblem problem =
                new SqlRuleProblem(
                        String.Format(CultureInfo.CurrentCulture, ruleDescriptor.DisplayDescription, elementName)
                        , modelElement
                        , sqlFragment);

                //RuleUtils.UpdateProblemPosition(modelElement, problem, ((Identifier) objects[key]));
                problems.Add(problem);
            }

            return problems;
        }
    }

    //    #endregion
}
