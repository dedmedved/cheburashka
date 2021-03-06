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

using System.Collections.Generic;
using Microsoft.SqlServer.Dac.CodeAnalysis;
using Microsoft.SqlServer.Dac.Model;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Cheburashka
{
    /// <summary>
    /// <para>This is a SQL rule which returns a warning message 
    /// whenever a RETURN statement is not found in a subroutine body. 
    /// This rule only applies to SQL stored procedures.
    /// </para>
    /// <para>
    /// Note that this uses a Localized export attribute, and hence the rule name and description will be
    /// localized if resource files for different languages are used
    /// </para>
    /// </summary>
    [LocalizedExportCodeAnalysisRule(RuleId,
        RuleConstants.ResourceBaseName,                                 // Name of the resource file to look up displayname and description in
        RuleConstants.EnforceReturn_RuleName,                           // ID used to look up the display name inside the resources file
        RuleConstants.EnforceReturn_ProblemDescription,                 // ID used to look up the description inside the resources file
        Category = RuleConstants.CategoryNonStrictCodingStyle,                // Rule category (e.g. "Design", "Naming")
        RuleScope = SqlRuleScope.Element)]                              // This rule targets specific elements rather than the whole model
    public sealed class EnforceReturnRule : SqlCodeAnalysisRule
    {
        /// <summary>
        /// The Rule ID should resemble a fully-qualified class name. In the Visual Studio UI
        /// rules are grouped by "Namespace + Category", and each rule is shown using "Short ID: DisplayName".
        /// For this rule, it will be 
        /// shown as "DM0027: Stored Procedures need at least one Return statement."
        /// </summary>
        public const string RuleId = RuleConstants.EnforceReturn_RuleId;

        public EnforceReturnRule()
        {
            SupportedElementTypes = SqlRuleUtils.GetProcedureClasses();
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

            DMVSettings.RefreshModelBuiltInCache(ruleExecutionContext.SchemaModel);

            var createProcedureStatement = sqlFragment as CreateProcedureStatement; //should always work fingers crossed.
            var code = createProcedureStatement?.StatementList;
            var problemExists = code is null || InvalidUseOfReturn(code);

            // Create problems for each return not found 
            RuleUtils.UpdateProblems(problemExists,problems, modelElement, elementName, sqlFragment, ruleDescriptor);

            return problems;
        }

        private bool InvalidUseOfReturn(StatementList code)
        {
            var cnt = code.Statements.Count;

            switch (cnt)
            {
                case 0:
                    return true;
                default:
                {
                    var lastStatementIdx = cnt - 1;
                    return code.Statements[lastStatementIdx] switch
                    {   // can only be true at first level of code in an sp, but that will do.
                        BeginEndAtomicBlockStatement statement => InvalidUseOfReturn(statement.StatementList),
                        BeginEndBlockStatement statement => InvalidUseOfReturn(statement.StatementList),
                        ReturnStatement => false,
                        _ => true
                    };
                }
            }
        }
    }
}
