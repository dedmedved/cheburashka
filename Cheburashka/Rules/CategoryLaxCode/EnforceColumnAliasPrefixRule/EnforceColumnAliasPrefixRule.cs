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
using ColumnType = Microsoft.SqlServer.TransactSql.ScriptDom.ColumnType;


namespace Cheburashka
{
    /// <summary>
    /// <para>
    /// This is a SQL rule which returns a warning message 
    /// whenever there is an unprefixed column in a statement where disambiguation is required.
    /// </para>
    /// <para>
    /// Note that this uses a Localized export attribute, and hence the rule name and description will be
    /// localized if resource files for different languages are used
    /// </para>
    /// </summary>

    [LocalizedExportCodeAnalysisRule( EnforceColumnPrefixRule.RuleId,
        RuleConstants.ResourceBaseName,                                     // Name of the resource file to look up display name and description in
        RuleConstants.EnforceColumnPrefixRuleName,                          // ID used to look up the display name inside the resources file
        RuleConstants.EnforceColumnPrefixProblemDescription,                // ID used to look up the description inside the resources file
        Category = RuleConstants.CategoryNonStrictCodingStyleNames,         // Rule category (e.g. "Design", "Naming")
        RuleScope = SqlRuleScope.Element)]                                  // This rule targets specific elements rather than the whole model
    public sealed class EnforceColumnPrefixRule : SqlCodeAnalysisRule
    {
        /// <summary>
        /// The Rule ID should resemble a fully-qualified class name. In the Visual Studio UI
        /// rules are grouped by "Namespace + Category", and each rule is shown using "Short ID: DisplayName".
        /// For this rule, it will be 
        /// shown as "DM0046: Columns should be prefixed with the alias of the source where disambiguation is required."
        /// </summary>
        public const string RuleId = RuleConstants.EnforceColumnPrefixRuleId;

        public EnforceColumnPrefixRule()
        {
            SupportedElementTypes = SqlRuleUtils.GetCodeAndViewContainingClasses();
        }

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext ruleExecutionContext)
        {

        List<SqlRuleProblem> problems = new();

        try{
            // Get Model collation 
            SqlComparer.Comparer = ruleExecutionContext.SchemaModel.CollationComparer;
            TSqlObject modelElement = ruleExecutionContext.ModelElement;

            string elementName = RuleUtils.GetElementName(ruleExecutionContext);
            // The rule execution context has all the objects we'll need, including the fragment representing the object,
            // and a descriptor that lets us access rule metadata
            TSqlFragment sqlFragment = ruleExecutionContext.ScriptFragment;
            DmvSettings.RefreshModelBuiltInCache(ruleExecutionContext.SchemaModel);

            //var sql = sqlFragment.SQLModel_AsText();

            // visitor to get the ocurrences of unaliased column names
            var allUnaliasedColumns = DmTSqlFragmentVisitor.Visit(sqlFragment, new EnforceColumnAliasPrefixVisitor()).Cast<ColumnReferenceExpression>().ToList();

            //Check things we don't want to look inside (target columns), output into clauses, index creation etc
            var allSkippedColumns = DmTSqlFragmentVisitor.Visit(sqlFragment, new EnforceColumnAliasPrefixIgnoredColumnsVisitor());

            //Check things we don't want to look inside (columns in merge sources, insert, update, and delete statements with only one table)
            //Ditto select statements and CTE subqueries
            var allSingleSourceStatements = DmTSqlFragmentVisitor.Visit(sqlFragment, new SingleSourceSqlVisitor()).ToList();

            //Check things we don't want to look inside 
            //we need to exclude order by clauses separately.
            var allSingleSourceOrderBys = DmTSqlFragmentVisitor.Visit(sqlFragment, new SingleSourceOrderBySQLVisitor());

            //Now work out what are the top level single source subqueries..............
            //First find all DMLS - we don't want to consider any single data source subqueries in any of these
            //Those !have! to be qualified with a prefix
            var allDMLs = DmTSqlFragmentVisitor.Visit(sqlFragment, new DmlsqlVisitor());

            //Now find all Subqueries not in another subquery that have no more than one data source -- obsolete thinking
            //Now find all Subqueries not in another subquery that have just one data source -- scalar expressions that just wrap an expression with (select ... )
            //should be ignored.
            var singleSourceSubQueries = DmTSqlFragmentVisitor.Visit(sqlFragment, new SingleSourceSubQueryQuerySpecificationVisitor());

            //Eliminate any that are within the scope of an DML statement.
            var nonContainedSingleSourceSubQueries = singleSourceSubQueries.Where(subQuery => !allDMLs.Any(dml => dml.SQLModel_Contains(subQuery))).ToList();
            // Add these top level single source subqueries to our list
            allSingleSourceStatements.AddRange(nonContainedSingleSourceSubQueries);

            // Now all we need are top level inline views
            var singleSourceQueryDerivedTableQuerySpecifications = DmTSqlFragmentVisitor.Visit(sqlFragment, new SingleSourceQueryDerivedTableQuerySpecificationVisitor());

            // We need to find top level inline views that are part of an apply
            // So - find Applies
            var applyTableSources = DmTSqlFragmentVisitor.Visit(sqlFragment, new ApplySingleSourceQueryDefinitionVisitor());

            //If the inline query is an apply query,
            //Eliminate it, as it must always contain aliased columns.
            List<TSqlFragment> nonApplyContainedSingleSourceQueryDerivedTableQuerySpecifications = new();

            foreach (var singleSourceInLineQuery in singleSourceQueryDerivedTableQuerySpecifications)
            {
                // If the query isn't contained in any apply clause we can add it.
                // Or if it is contained in an apply clause, but there is an intervening join query
                // with no intermediate apply clause containing the query
                if (!applyTableSources.Any(applySource => applySource.SQLModel_Equals(singleSourceInLineQuery)))
                {
                    nonApplyContainedSingleSourceQueryDerivedTableQuerySpecifications.Add(singleSourceInLineQuery);
                }
            }
            allSingleSourceStatements.AddRange(nonApplyContainedSingleSourceQueryDerivedTableQuerySpecifications);

            //Check things we DO want to look inside (columns in any subquery) and other inline queries
            // Now we need to gather all subqueries.
            var subQuerys = DmTSqlFragmentVisitor.Visit(sqlFragment, new SubQueryVisitor()).Cast<ScalarSubquery>().ToList();

            // find all aggregate functions in subqueries
            // we can ignore column references in them where there is only a single source
            // so long as there is only one DISTINCT column reference in the parameters
            var aggregateFunctionCallsInSubQueriesWithOneUnaliasedColumnReference = new List<FunctionCall>();
            foreach (var subQuery in subQuerys)
            {
                // Let's make this simple for me to understand
                // we're only going to deal with straightforward (select max(val) from table) type subqueries for this exception
                if (subQuery.QueryExpression is QuerySpecification querySpecification 
                    && SqlCheck.HasExactlyOneFromClauseTableSource(querySpecification)
                    )
                {
                    var functionCalls = DmTSqlFragmentVisitor.Visit(subQuery, new AggregateFunctionVisitor()).Cast<FunctionCall>().ToList();
                    //var fc_sql = functionCalls.Cast<TSqlFragment>().Select(n => n.SQLModel_AsText()).ToList();

                    //all aggregate functions have one argument except "grouping_id" and we just aren't going to entertain that edge case
                    foreach (var functionCall in functionCalls.Where( f => ! f.FunctionName.Value.SQLModel_StringCompareEqual("grouping_id")))
                    {
                        // if there is just one distinct sql col reference in the expression and no instance is qualified with a table
                        // alias then it doesn't need to be qualified as it can only come from the single table in the subquery
                        // (otherwise its not vaild SQL)
                        var param = functionCall.Parameters[0];
                        var allColumnReferencesInAggregateQuery = DmTSqlFragmentVisitor.Visit(param, new EnforceColumnAliasPrefixVisitor()).Cast<ColumnReferenceExpression>().ToList();
                        //var allColumnReferencesInAggregateQuerysql = allColumnReferencesInAggregateQuery.Cast<TSqlFragment>().Select(n => n.SQLModel_AsText()).ToList();
                        if ( ! allColumnReferencesInAggregateQuery.Any(c => c.ColumnType != ColumnType.Regular || c.MultiPartIdentifier.Count > 1)
                            && (allColumnReferencesInAggregateQuery.Select(n=>n.MultiPartIdentifier[n.MultiPartIdentifier.Count-1].Value).Distinct().Count() == 1)
                           )
                        {
                            aggregateFunctionCallsInSubQueriesWithOneUnaliasedColumnReference.Add(functionCall);
                        }
                    }
                }
            }
            //var ccs = aggregateFunctionCallsInSubQueriesWithOneUnaliasedColumnReference.Cast<TSqlFragment>().Select(n => n.SQLModel_AsText()).ToList();


            //var ssqSql = subQuerys.Cast<TSqlFragment>().Select(n => n.SQLModel_AsText()).ToList();
            //var allSkippedColumnsSql = allSkippedColumns.Cast<TSqlFragment>().Select(n => n.SQLModel_AsText()).ToList();
            //var allColumnsSql = allUnaliasedColumns.Cast<TSqlFragment>().Select(n => n.SQLModel_AsText()).ToList();

            // Now we need to gather all applies.
            var applyTableSources2 = DmTSqlFragmentVisitor.Visit(sqlFragment, new ApplyTableSourceVisitor());

            // Create problems for each unaliased column name found 
            foreach (ColumnReferenceExpression unaliasedColumn in allUnaliasedColumns)
            {
                //var columnName = unaliasedColumn.SQLModel_AsText();

                // Check the name isn't a target column
                bool ignoreThisColumnHere = allSkippedColumns.Any(sc => sc.SQLModel_Contains(unaliasedColumn));
                // Check it isn't in a one table, one aggregate function parameter call
                if (!ignoreThisColumnHere)
                {
                    ignoreThisColumnHere = aggregateFunctionCallsInSubQueriesWithOneUnaliasedColumnReference.Any(afc => afc.SQLModel_Contains(unaliasedColumn));
                }
                // Check it isn't a datepart name - note this ought to be context dependent, but aint
                if (!ignoreThisColumnHere)
                {
                    ignoreThisColumnHere = SqlRuleUtils.IsDatePart(unaliasedColumn.ScriptTokenStream[unaliasedColumn.LastTokenIndex].Text);
                }
                // Check its not inside a single source Order By clause
                if (!ignoreThisColumnHere) { ignoreThisColumnHere = allSingleSourceOrderBys.Any(ssob => ssob.SQLModel_Contains(unaliasedColumn)); } 

                // Check its not inside a 'top-level thing'
                // unless it is in a deeper subquery, where we do want qualified columns to avoid ambiguity
                if (!ignoreThisColumnHere)
                {
                    // what is it inside.
                    List<TSqlFragment> allContainingSingleSourceStatementsAndCtes = allSingleSourceStatements.FindAll(n => n.SQLModel_Contains(unaliasedColumn));

                    //var allContainingSingleSourceStatementsAndCtesSQL = allContainingSingleSourceStatementsAndCtes.Select(n => n.SQLModel_AsText()).ToList();

                    
                    // which is it most tightly inside ?
                    // we could sort
                    // means writing another comparer
                    // let's loop for now
                    if (allContainingSingleSourceStatementsAndCtes.Count > 0)
                    {
                        TSqlFragment mostImmediateContainingSqlFragment = allContainingSingleSourceStatementsAndCtes[0];
                        foreach (var location in allContainingSingleSourceStatementsAndCtes)
                        {
                            //var locnSQL = location.SQLModel_AsText();
                            if (mostImmediateContainingSqlFragment.SQLModel_Contains(location))
                            {
                                mostImmediateContainingSqlFragment = location;
                                //var tightestContainerName = tightestContainer.SQLModel_AsText();
                            }
                        }

                        //var mostImmediateContainingSqlFragmentSQL = mostImmediateContainingSqlFragment.SQLModel_AsText();
                        if (!subQuerys.Any(subQuery =>
                                mostImmediateContainingSqlFragment.SQLModel_Contains(subQuery)
                                && subQuery.SQLModel_Contains(unaliasedColumn)
                            )
                            && !applyTableSources2.Any(ats =>
                                mostImmediateContainingSqlFragment.SQLModel_Contains(ats)
                                && ats.SQLModel_Contains(unaliasedColumn)
                            )
                        )
                        {
                            ignoreThisColumnHere = true;
                        }
                    }
                }
                RuleDescriptor ruleDescriptor = ruleExecutionContext.RuleDescriptor;
                RuleUtils.UpdateProblems(!ignoreThisColumnHere, problems, modelElement, elementName, unaliasedColumn, ruleDescriptor);
            }
        }
        catch (System.Exception e) {
   
        }
        finally {}

        return problems;
        }
    }
}
