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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.SqlServer.Dac.CodeAnalysis;
using Microsoft.SqlServer.Dac.Model;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Cheburashka
{
    /// <summary>
    /// <para>
    /// This is a SQL rule which returns a warning message 
    /// whenever there is a scalar subquery which should be supported by a unique constraint
    /// </para>
    /// <para>
    /// Note that this uses a Localized export attribute, and hence the rule name and description will be
    /// localized if resource files for different languages are used
    /// </para>
    /// </summary>

    [LocalizedExportCodeAnalysisRule( PreferMergeUsesExceptForChangeDetectionRule.RuleId,
        RuleConstants.ResourceBaseName,                                             // Name of the resource file to look up display name and description in
        RuleConstants.PreferMergeUsesExceptForChangeDetectionRuleName,              // ID used to look up the display name inside the resources file
        RuleConstants.PreferMergeUsesExceptForChangeDetectionProblemDescription,    // ID used to look up the description inside the resources file
        Category = RuleConstants.CategoryNonStrictCodingStyle,                      // Rule category (e.g. "Design", "Naming")
        RuleScope = SqlRuleScope.Element)]                                          // This rule targets specific elements rather than the whole model
    public sealed class PreferMergeUsesExceptForChangeDetectionRule : SqlCodeAnalysisRule
    {
        /// <summary>
        /// The Rule ID should resemble a fully-qualified class name. In the Visual Studio UI
        /// rules are grouped by "Namespace + Category", and each rule is shown using "Short ID: DisplayName".
        /// For this rule, it will be 
        /// shown as "DM0075: Prefer to use SELECT ... EXCEPT SELECT ... to detect row differences in MERGE statements."
        /// </summary>
        public const string RuleId = RuleConstants.PreferMergeUsesExceptForChangeDetectionRuleId;

        public PreferMergeUsesExceptForChangeDetectionRule()
        {
            SupportedElementTypes = SqlRuleUtils.GetStateAlteringContainingClasses();
        }

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext ruleExecutionContext)
        {
            DmvRuleSetup.RuleSetup(ruleExecutionContext, out var problems, out TSqlModel model, out TSqlFragment sqlFragment, out TSqlObject modelElement);
            //try {
            // Get Model collation 
            SqlComparer.Comparer = ruleExecutionContext.SchemaModel.CollationComparer;

            string elementName = RuleUtils.GetElementName(ruleExecutionContext);
            // The rule execution context has all the objects we'll need, including the fragment representing the object,
            // and a descriptor that lets us access rule metadata
            DmvSettings.RefreshModelBuiltInCache(ruleExecutionContext.SchemaModel);

            // get normal query and subquery separately
            var MergeStatements = DmTSqlFragmentVisitor.Visit(sqlFragment, new MergeStatementVisitor()).Cast<MergeStatement>().ToList();//.Cast<MergeStatement>();
            var invalidMerges = new List<TSqlFragment>();
            foreach (var mergeStatement in MergeStatements)
            {
                var foundValidUpdate = true;
                foreach (var actionClause in mergeStatement.MergeSpecification.ActionClauses.Where( n => n.Action is UpdateMergeAction && n.Condition == MergeCondition.Matched))
                {
                    var expression = actionClause.SearchCondition;
                    // walk the expression looking for an exists clause that contain a select except select with no from 
                    foundValidUpdate = FindExistsSelectExceptSelect(expression);
                    if (foundValidUpdate) break;
                }
                if (!foundValidUpdate)
                {
                    invalidMerges.Add(mergeStatement);
                }
            }
            RuleDescriptor ruleDescriptor = ruleExecutionContext.RuleDescriptor;
            RuleUtils.UpdateProblems( problems, modelElement, elementName, invalidMerges, ruleDescriptor);
            //}
            //catch( Exception e )
            //{
            //    using StreamWriter w = File.AppendText(@"c:\temp\err.out");
            //    w.WriteLine(e.Message);
            //    w.WriteLine(e.StackTrace);
            //    w.WriteLine(e.InnerException);
            //    w.WriteLine(e.Source);
            //    w.WriteLine(e.TargetSite);
            //    foreach ( var v in e.Data)
            //    {
            //        w.WriteLine(v);
            //    }
            //    w.WriteLine(e.TargetSite);
            //    w.WriteLine();

            //}
            return problems;
        }

        private bool FindExistsSelectExceptSelect(BooleanExpression expression)
        {
            switch (expression)
            {
                case BooleanBinaryExpression booleanBinaryExpression:
                    return FindExistsSelectExceptSelect(booleanBinaryExpression.FirstExpression) || FindExistsSelectExceptSelect(booleanBinaryExpression.SecondExpression);
                case BooleanNotExpression booleanNotExpression:
                    return FindExistsSelectExceptSelect(booleanNotExpression.Expression);
                case ExistsPredicate existsPredicate:
                    return FindExistsSelectExceptSelect(existsPredicate.Subquery.QueryExpression, true);
                default:
                    return false;
            }
        }
        private bool FindExistsSelectExceptSelect(QueryExpression expression, bool calledFromExists)
        {
            switch (expression)
            {
                case QueryParenthesisExpression queryParenthesisExpression:
                    return FindExistsSelectExceptSelect(queryParenthesisExpression.QueryExpression, calledFromExists);
                case BinaryQueryExpression binaryQueryExpression:
                    return binaryQueryExpression.BinaryQueryExpressionType == BinaryQueryExpressionType.Except && FindExistsSelectExceptSelect(binaryQueryExpression.FirstQueryExpression,false) && FindExistsSelectExceptSelect(binaryQueryExpression.SecondQueryExpression,false);
                case QuerySpecification querySpecification:
                    return (calledFromExists || querySpecification.FromClause is null || querySpecification.FromClause.TableReferences.Count == 0) //if called from exists - from clause can exist otherwise not
                           && querySpecification.GroupByClause is null 
                           && querySpecification.HavingClause is null
                           && querySpecification.OrderByClause is null
                           && querySpecification.TopRowFilter is null
                           && querySpecification.OffsetClause is null
                           && querySpecification.UniqueRowFilter is UniqueRowFilter.NotSpecified 
                           && querySpecification.OrderByClause is null
                           && querySpecification.WhereClause is null
                           && querySpecification.ForClause is null
                           ;

                default:
                    return false;
            }
        }
    }
}
