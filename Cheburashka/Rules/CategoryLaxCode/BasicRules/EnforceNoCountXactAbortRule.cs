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
using System.Linq;
using Microsoft.SqlServer.Dac.CodeAnalysis;
using Microsoft.SqlServer.Dac.Model;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Cheburashka
{
    /// <summary>
    /// <para>This is a SQL rule which returns a warning message 
    /// whenever multiple RETURN statements are found in a subroutine body. 
    /// This rule only applies to SQL stored procedures.
    /// </para>
    /// <para>
    /// Note that this uses a Localized export attribute, and hence the rule name and description will be
    /// localized if resource files for different languages are used
    /// </para>
    /// </summary>
    [LocalizedExportCodeAnalysisRule(RuleId,
        RuleConstants.ResourceBaseName,                                 // Name of the resource file to look up displayname and description in
        RuleConstants.EnforceNoCountXactAbortRuleName,                  // ID used to look up the display name inside the resources file
        RuleConstants.EnforceNoCountXactAbortProblemDescription,        // ID used to look up the description inside the resources file
        Category = RuleConstants.CategoryNonStrictCodingStyle,          // Rule category (e.g. "Design", "Naming")
        RuleScope = SqlRuleScope.Element)]                              // This rule targets specific elements rather than the whole model
    public sealed class EnforceNoCountXactAbortRule : SqlCodeAnalysisRule
    {
        /// <summary>
        /// The Rule ID should resemble a fully-qualified class name. In the Visual Studio UI
        /// rules are grouped by "Namespace + Category", and each rule is shown using "Short ID: DisplayName".
        /// For this rule, it will be 
        /// shown as "DM0060: NoCount On and Xact_Abort On should be set at the start of Procedures and Triggers."
        /// </summary>
        public const string RuleId = RuleConstants.EnforceNoCountXactAbortRuleId;

        public EnforceNoCountXactAbortRule()
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

            DmvSettings.RefreshModelBuiltInCache(ruleExecutionContext.SchemaModel);

            var code = sqlFragment is CreateProcedureStatement createProcedureStatement
                    ? createProcedureStatement.StatementList
                        : sqlFragment is CreateTriggerStatement createTriggerStatement &&
                          createTriggerStatement.TriggerObject.TriggerScope == TriggerScope.Normal
                    ? createTriggerStatement.StatementList
                            : null;

            var seenXactAbortOn = false;
            var seenNoCountOn = false;
            var problemExists = code?.Statements.Count > 0 && ! CheckXactAbortAndNoCountAreInFirst2Statements(code, ref seenXactAbortOn, ref seenNoCountOn);
            RuleUtils.UpdateProblems(problemExists,problems, modelElement, elementName, sqlFragment, ruleDescriptor);

            return problems;
        }
        private bool CheckXactAbortAndNoCountAreInFirst2Statements(StatementList code, ref bool seenXactAbort, ref bool seenNoCount)
        {
            // we need to be able to handle madness like this - 
            /*

              begin
              set no_count on
              set no_count off
              set no_count on
              begin
              begin
              set xact_abort,no_count on
              end
              end
              select ........................

             
             * which is mad - but valid
             */

            var cnt = code.Statements.Count;
            var lastIdx = cnt - 1;
            switch (cnt)
            {
                case 0:
                    return true; // shouldn't ever hit this condition except for empty trigger/proc definitions which are handled by the caller anyway
                default:
                    {
                        var statementIdx = 0;
                        // keep going until we stop processing set statements ( or nested set statements via a block of some kind)
                        while ( statementIdx <= lastIdx && 
                                (     code.Statements[statementIdx] is PredicateSetStatement
                                 ||   code.Statements[statementIdx] is BeginEndAtomicBlockStatement
                                 ||   code.Statements[statementIdx] is BeginEndBlockStatement
                                 ||   code.Statements[statementIdx] is TryCatchStatement
                                ))
                        {
                            if (code.Statements[statementIdx] is PredicateSetStatement setCommandStatement)
                            {
                                if (setCommandStatement.IsOn)
                                {
                                    seenXactAbort |= setCommandStatement.Options.HasFlag(SetOptions.XactAbort);
                                    seenNoCount |= setCommandStatement.Options.HasFlag(SetOptions.NoCount);
                                }
                                else  // (!setCommandStatement.IsOn)
                                {
                                    seenXactAbort &= ! setCommandStatement.Options.HasFlag(SetOptions.XactAbort);
                                    seenNoCount &= ! setCommandStatement.Options.HasFlag(SetOptions.NoCount);
                                }
                            }

                            else if (code.Statements[statementIdx] is BeginEndAtomicBlockStatement beginEndAtomicBlockStatement)
                            {
                                var res = CheckXactAbortAndNoCountAreInFirst2Statements(beginEndAtomicBlockStatement.StatementList, ref seenXactAbort, ref seenNoCount);
                                if (!res) return false;
                            }
                            else if (code.Statements[statementIdx] is BeginEndBlockStatement beginEndBlockStatement)
                            {
                                var res = CheckXactAbortAndNoCountAreInFirst2Statements(beginEndBlockStatement.StatementList, ref seenXactAbort, ref seenNoCount);
                                if (!res) return false;
                            }
                            else if (code.Statements[statementIdx] is TryCatchStatement tryCatchStatement)
                            {
                                var res = CheckXactAbortAndNoCountAreInFirst2Statements(tryCatchStatement.TryStatements, ref seenXactAbort, ref seenNoCount);
                                if (!res) return false;
                            }
                            statementIdx++;
                        }

                        return seenXactAbort && seenNoCount; // if we run out of suitable statements to process return the final individual values as a measure of success.

                    }
            }
        }
    }
}
