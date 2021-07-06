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
    /// whenever a stored procedure or trigger uses raiserror rather than throw. 
    /// This rule only applies to SQL stored procedures, and triggers.
    /// </para>
    /// <para>
    /// Note that this uses a Localized export attribute, and hence the rule name and description will be
    /// localized if resource files for different languages are used
    /// </para>
    /// </summary>
    [LocalizedExportCodeAnalysisRule(PreferConstantInitialisationRule.RuleId,
        RuleConstants.ResourceBaseName,                                     // Name of the resource file to look up displayname and description in
        RuleConstants.PreferConstantInitialisation_RuleName,                // ID used to look up the display name inside the resources file
        RuleConstants.PreferConstantInitialisation_ProblemDescription,      // ID used to look up the description inside the resources file
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
        public const string RuleId = RuleConstants.PreferConstantInitialisation_RuleId;

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

            DMVSettings.RefreshModelBuiltInCache(ruleExecutionContext.SchemaModel);


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

            var parameters = sqlFragment is CreateProcedureStatement createProcedureStatement ? createProcedureStatement.Parameters.ToList()
                           : sqlFragment is CreateFunctionStatement  createFunctionStatement  ? createFunctionStatement.Parameters.ToList()
                           : new List<ProcedureParameter>();

            // find all unset parameters -- these feed into our list of permitted variable 'things'
            var nonAssignedParameters = DmTSqlFragmentVisitor.Visit(sqlFragment, new NonUpdatedParameterVisitor(parameters)).Cast<ProcedureParameter>().Select(n => n.VariableName.Value).ToList();
            // find all initialised-only variables -- these feed into our list of permitted variable 'things'
            // only allow variables intialised from literal expressions and parameters ( for now ) - we might get our heads around the full chaining of initialisers
            // again disallow anything intialised in a control structure - yeah.
            var initialisedVariableVisitor = new InitialisedOnlyVariablesVisitor(nonAssignedParameters);
            sqlFragment.Accept(initialisedVariableVisitor);

            eliminate any of these set in any invalid context;

            var initialisedOnlyVariables = initialisedVariableVisitor.InitialisedOnlyVariables();
            // check they aren't initialised in possibly unexecuted code. - but that means beinbg fixed to return sql fragments and variabel names
            var validanitialisedOnlyVariables = new List<TSqlFragment>();
            foreach (var v in initialisedOnlyVariables)
            {
                var ifFree = !ifs.Any(i => i.SQLModel_Contains(v));
                var whileFree = !whiles.Any(i => i.SQLModel_Contains(v));
                var catchFree = true;
                foreach (var statementList in catchLists)
                {
                    var thisCatchIsFree = !statementList.Statements.Any(i => i.SQLModel_Contains(v));
                    ;
                    if (!thisCatchIsFree)
                    {
                        catchFree = false;
                        break;
                    }
                }

                if (ifFree && whileFree && catchFree)
                {
                    validanitialisedOnlyVariables.Add(v);
                }
            }

            nonAssignedParameters.AddRange(initialisedOnlyVariables);

            // get all candidate initialisations
            var singlySetLiteralVariableFragments = DmTSqlFragmentVisitor.Visit(sqlFragment, new ConstantOnlyUpdatedVariableVisitor(nonAssignedParameters));
            var issues = new List<TSqlFragment>();

            // check they aren't initialised in possibly unexecuted code.
            foreach (var v in singlySetLiteralVariableFragments)
            {
                var ifFree = !ifs.Any(i => i.SQLModel_Contains(v));
                var whileFree = !whiles.Any(i => i.SQLModel_Contains(v));
                var catchFree = true;
                foreach (var statementList in catchLists)
                {
                    var thisCatchIsFree = ! statementList.Statements.Any(i => i.SQLModel_Contains(v)); ;
                    if (!thisCatchIsFree)
                    {
                        catchFree = false;
                        break;
                    }
                }

                if (ifFree && whileFree && catchFree)
                {
                    issues.Add(v);
                }
            }

            RuleUtils.UpdateProblems(problems, modelElement, elementName, issues, ruleDescriptor);

            return problems;
        }
    }
}
