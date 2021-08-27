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
using Microsoft.SqlServer.Dac.CodeAnalysis;
using Microsoft.SqlServer.Dac.Model;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System.Linq;

namespace Cheburashka
{
    /// <summary>
    /// <para>
    /// This is a SQL rule which returns a warning message 
    /// whenever an assignment is detected which could be moved to the variable declaration
    /// This rule only applies to SQL stored procedures, functions, and triggers.
    /// </para>
    /// <para>
    /// Note that this uses a Localized export attribute, and hence the rule name and description will be
    /// localized if resource files for different languages are used
    /// </para>
    /// </summary>
    [LocalizedExportCodeAnalysisRule(PreferConstantInitialisationRule.RuleId,
        RuleConstants.ResourceBaseName,                                     // Name of the resource file to look up displayname and description in
        RuleConstants.PreferConstantInitialisationRuleName,                 // ID used to look up the display name inside the resources file
        RuleConstants.PreferConstantInitialisationProblemDescription,       // ID used to look up the description inside the resources file
        Category = RuleConstants.CategoryModernCodingStyle,                 // Rule category (e.g. "Design", "Naming")
        RuleScope = SqlRuleScope.Element)]                                  // This rule targets specific elements rather than the whole model
    public sealed class PreferConstantInitialisationRule : SqlCodeAnalysisRule
    {
        /// <summary>
        /// The Rule ID should resemble a fully-qualified class name. In the Visual Studio UI
        /// rules are grouped by "Namespace + Category", and each rule is shown using "Short ID: DisplayName".
        /// For this rule, it will be 
        /// shown as "DM0049: Variables set to constant values and never reset, are best set on declaration."
        /// </summary>
        public const string RuleId = RuleConstants.PreferConstantInitialisationRuleId;

        public PreferConstantInitialisationRule() {
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

            string elementName = RuleUtils.GetElementName(ruleExecutionContext);

            // The rule execution context has all the objects we'll need, including the fragment representing the object,
            // and a descriptor that lets us access rule metadata
            TSqlFragment sqlFragment = ruleExecutionContext.ScriptFragment;
            RuleDescriptor ruleDescriptor = ruleExecutionContext.RuleDescriptor;

            DmvSettings.RefreshModelBuiltInCache(ruleExecutionContext.SchemaModel);


            // anything with gotos is too hard to handle - skip for now
            var gotos = DmTSqlFragmentVisitor.Visit(sqlFragment, new GotoVisitor());
            if (gotos.Any())
                return problems;

            // get ifs and whiles and catches
            var ifs = DmTSqlFragmentVisitor.Visit(sqlFragment, new IfStatementVisitor());
            var whiles = DmTSqlFragmentVisitor.Visit(sqlFragment, new WhileStatementVisitor());
            var catchStatementVisitor = new CatchStatementVisitor();
            sqlFragment.Accept(catchStatementVisitor);
            var catchLists = catchStatementVisitor.CatchStatements;

            // Get parameters
            var parameters = sqlFragment switch
            {
                CreateProcedureStatement createProcedureStatement => createProcedureStatement.Parameters.ToList(),
                CreateFunctionStatement createFunctionStatement => createFunctionStatement.Parameters.ToList(),
                _ => new List<ProcedureParameter>()
            };

            // find all unset parameters -- these feed into our list of permitted variable 'things'
            var nonAssignedParametersAndVariables = DmTSqlFragmentVisitor.Visit(sqlFragment, new NonUpdatedParameterVisitor(parameters))
                                                                          .Cast<ProcedureParameter>().ToList();
            // find all initialised-only variables -- these feed into our list of permitted variable 'things'
            // only allow variables initialised from literal expressions and parameters ( for now ) - we might get our heads around the full chaining of initialisers
            // again disallow anything initialised in a control structure - yeah.

            var bInitialisedVariableStillToFind = true;
            var initialisedOnlyVariablesCount = nonAssignedParametersAndVariables.Count;
            List<string> nonAssignedParametersAndVariablesNames = nonAssignedParametersAndVariables.Select(n => n.VariableName.Value).ToList();
            while (bInitialisedVariableStillToFind)
            {
                var initialisedOnlyVariables = DmTSqlFragmentVisitor.Visit(sqlFragment
                                                                          , new InitialisedOnlyVariablesVisitor(nonAssignedParametersAndVariablesNames))
                                                                    .Cast<DeclareVariableElement>().ToList();
                // check they aren't initialised in possibly un-executed code.
                //nonAssignedParametersAndVariablesNames = initialisedOnlyVariables.Select(n => n.VariableName.Value).ToList();
                foreach (var v in initialisedOnlyVariables)
                {
                    // improve the add if missing logic - currently it sucks but most variable lists are short anyway
                    IfFree(ifs, v, whiles, catchLists, out var ifFree, out var whileFree, out var catchFree);
                    if (ifFree && whileFree && catchFree && ! nonAssignedParametersAndVariablesNames.Any( n => v.VariableName.Value.SQLModel_StringCompareEqual(n)))
                    {
                        nonAssignedParametersAndVariablesNames.Add(v.VariableName.Value);
                    }
                }

                bInitialisedVariableStillToFind = nonAssignedParametersAndVariablesNames.Count != initialisedOnlyVariablesCount;

                initialisedOnlyVariablesCount = nonAssignedParametersAndVariablesNames.Count;

            }


            // get all candidate initialisations
            var candidateConstantAssignments = nonAssignedParametersAndVariablesNames;
            var bAssignedConstantsStillToFind = true;
            var permissibleVariablesCount = nonAssignedParametersAndVariables.Count;
            var issues = new List<TSqlFragment>();

            while (bAssignedConstantsStillToFind)
            {
                var singlySetLiteralVariableVisitor = new ConstantOnlyUpdatedVariableVisitor(candidateConstantAssignments);
                sqlFragment.Accept(singlySetLiteralVariableVisitor);
                var singlySetLiteralVariableFragments = singlySetLiteralVariableVisitor.VariablesAndValues();

                // check they aren't initialised in possibly un-executed code.
                foreach (var v in singlySetLiteralVariableFragments.Keys)
                {
                    var sql = singlySetLiteralVariableFragments[v];
                    IfFree(ifs, sql, whiles, catchLists, out var ifFree, out var whileFree, out var catchFree);
                    if (ifFree && whileFree && catchFree && ! candidateConstantAssignments.Any(n => v.SQLModel_StringCompareEqual(n)))
                    {
                        issues.Add(sql); // yep this is ugly as well
                        candidateConstantAssignments.Add(v);
                    }
                }
                bAssignedConstantsStillToFind = candidateConstantAssignments.Count != permissibleVariablesCount;

                permissibleVariablesCount = candidateConstantAssignments.Count;
            }

            RuleUtils.UpdateProblems(problems, modelElement, elementName, issues, ruleDescriptor);

            return problems;
        }

        private static void IfFree(IEnumerable<TSqlFragment> sqlFragments, TSqlFragment v, IEnumerable<TSqlFragment> list, IEnumerable<StatementList> statementLists, out bool ifFree, out bool whileFree, out bool catchFree)
        {
            ifFree = !sqlFragments.Any(i => i.SQLModel_Contains(v));
            whileFree = !list.Any(i => i.SQLModel_Contains(v));
            catchFree = true;
            foreach (var statementList in statementLists)
            {
                var thisCatchIsFree = !statementList.Statements.Any(i => i.SQLModel_Contains(v));
                if (thisCatchIsFree) continue;
                catchFree = false;
                break;
            }
        }

    }
}
