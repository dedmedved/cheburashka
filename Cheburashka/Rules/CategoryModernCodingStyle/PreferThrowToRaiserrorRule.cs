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
    [LocalizedExportCodeAnalysisRule(PreferThrowToRaiserrorRule.RuleId,
        RuleConstants.ResourceBaseName,                                     // Name of the resource file to look up displayname and description in
        RuleConstants.PreferThrowToRaiserrorRuleName,                     // ID used to look up the display name inside the resources file
        RuleConstants.PreferThrowToRaiserrorProblemDescription,            // ID used to look up the description inside the resources file
        Category = RuleConstants.CategoryModernCodingStyle,                 // Rule category (e.g. "Design", "Naming")
        RuleScope = SqlRuleScope.Element)]                                  // This rule targets specific elements rather than the whole model
    public sealed class PreferThrowToRaiserrorRule : SqlCodeAnalysisRule
    {
        /// <summary>
        /// The Rule ID should resemble a fully-qualified class name. In the Visual Studio UI
        /// rules are grouped by "Namespace + Category", and each rule is shown using "Short ID: DisplayName".
        /// For this rule, it will be 
        /// shown as "DM0048: Prefer using Throw to Raiserror when raising an error."
        /// </summary>
        public const string RuleId = RuleConstants.PreferThrowToRaiserrorRuleId;

        public PreferThrowToRaiserrorRule() {
            SupportedElementTypes = SqlRuleUtils.GetStateAlteringContainingClasses();
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

            //Casting is rubbish - but safe
            List<DeclareVariableElement> initialisedVars = DmTSqlFragmentVisitor.Visit(sqlFragment, new InitialisationContextVisitor()).Cast<DeclareVariableElement>().ToList();
            // get all assignments to variables
            var setVariables = DmSqlExpressionDependencyVisitor.Visit(sqlFragment, new UpdatedVariableVisitor());

            // restrict initialisedVariableNames to anything that is an int type and has been assigned an int value <= 10
            var initialisedVariableNames = initialisedVars.Where(n=> n.DataType is SqlDataTypeReference dataTypeReference 
                                                                                    && ( dataTypeReference.SqlDataTypeOption == SqlDataTypeOption.TinyInt
                                                                                    || dataTypeReference.SqlDataTypeOption == SqlDataTypeOption.SmallInt
                                                                                    || dataTypeReference.SqlDataTypeOption == SqlDataTypeOption.Int
                                                                                    || dataTypeReference.SqlDataTypeOption == SqlDataTypeOption.BigInt
                                                                                    )
                                                                                    && n.Value is IntegerLiteral literal && int.TryParse(literal.Value, out int litVal ) && litVal <= 10
                                                                                )
                                                                         .Select(n => n.VariableName.Value).ToList();

            var setVariableNames = setVariables.Select(n => n.Variable.Name);
            var variableNames = initialisedVariableNames.ToList();
            var onlyInitialisedVariableNames = variableNames.Except(setVariableNames,SqlComparer.Comparer);

            // visitor to get the occurrences of raiserror statements - that might cause a transfer of control
            var raiseErrorStatements = DmTSqlFragmentVisitor.Visit(sqlFragment, new RaiserrorVisitor()).Cast<RaiseErrorStatement>().ToList();
            // eliminate raiserror statements where the errorlevel is one of the initialised variables with a value <= 10 
            var nonIssues = raiseErrorStatements.Where(n => n.SecondParameter is VariableReference)
                                                .Select(n => n)
                                                .Where( n => onlyInitialisedVariableNames.Any( name => name.SQLModel_StringCompareEqual(((VariableReference)n.SecondParameter).Name)));
            var issues = raiseErrorStatements.Except(nonIssues).Cast<TSqlFragment>().ToList();

            RuleUtils.UpdateProblems(problems, modelElement, elementName, issues, ruleDescriptor);

            return problems;
        }
    }
}
