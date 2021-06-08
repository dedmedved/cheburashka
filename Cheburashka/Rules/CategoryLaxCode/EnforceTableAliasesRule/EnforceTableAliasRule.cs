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
using Microsoft.SqlServer.Dac.CodeAnalysis;
using Microsoft.SqlServer.Dac.Model;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System.Collections.Generic;
using System.Linq;

namespace Cheburashka
{
    /// <summary>
    /// <para>
    /// This is a SQL rule which returns a warning message 
    /// whenever a data source without an alias appears inside DML.
    /// This rule only applies to SQL stored procedures.
    /// </para>
    /// <para>
    /// Note that this uses a Localized export attribute, and hence the rule name and description will be
    /// localized if resource files for different languages are used
    /// </para>
    /// </summary>
    [LocalizedExportCodeAnalysisRule(EnforceTableAliasRule.RuleId,
        RuleConstants.ResourceBaseName,                                     // Name of the resource file to look up displayname and description in
        RuleConstants.EnforceTableAlias_RuleName,                           // ID used to look up the display name inside the resources file
        RuleConstants.EnforceTableAlias_ProblemDescription,                 // ID used to look up the description inside the resources file
        Category = RuleConstants.CategoryBasics,                            // Rule category (e.g. "Design", "Naming")
        RuleScope = SqlRuleScope.Element)]                                  // This rule targets specific elements rather than the whole model
    public sealed class EnforceTableAliasRule : SqlCodeAnalysisRule
    {
        /// <summary>
        /// The Rule ID should resemble a fully-qualified class name. In the Visual Studio UI
        /// rules are grouped by "Namespace + Category", and each rule is shown using "Short ID: DisplayName".
        /// For this rule, it will be 
        /// shown as "DM0047: "
        /// </summary>
        public const string RuleId = RuleConstants.EnforceTableAlias_RuleId;

        public EnforceTableAliasRule()
        {
            SupportedElementTypes = SqlRuleUtils.GetCodeAndViewContainingClasses();
        }

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext ruleExecutionContext)
        {
            // Get Model collation 
            SqlComparer.Comparer = ruleExecutionContext.SchemaModel.CollationComparer;
            List<SqlRuleProblem> problems = new List<SqlRuleProblem>();
            TSqlObject modelElement = ruleExecutionContext.ModelElement;

            string elementName = RuleUtils.GetElementName(ruleExecutionContext, modelElement);
            // The rule execution context has all the objects we'll need, including the fragment representing the object,
            // and a descriptor that lets us access rule metadata
            TSqlFragment sqlFragment = ruleExecutionContext.ScriptFragment;
            DMVSettings.RefreshModelBuiltInCache(ruleExecutionContext.SchemaModel);

            // visitor to get the occurrences of all insert/merge etc targets and output into clauses
            EnforceTableAliasExcludedContextsVisitor enforceTableAliasExcludedContextsVisitor = new();
            sqlFragment.Accept(enforceTableAliasExcludedContextsVisitor);
            List<TSqlFragment> tableAliasExcludedTableSources = enforceTableAliasExcludedContextsVisitor.ExcludedFragments;

            // visitor to get the occurrences of all data source things
            EnforceTableAliasVisitor enforceTableAliasVisitor = new();
            sqlFragment.Accept(enforceTableAliasVisitor);
            List<TSqlFragment> allTableSources = enforceTableAliasVisitor.TableSources;

            //Check things we don't want to look inside (columns in update and delete statements with only one table)
            //Ditto select statements and CTE sub-queries
            SingleSourceSQLVisitor singleSourceSQLVisitor = new();
            sqlFragment.Accept(singleSourceSQLVisitor);
            List<TSqlFragment> allSingleSourceStatements = singleSourceSQLVisitor.SingleSourceSQLs;

            //Now work out what are the top level single source sub-queries..............
            //First find all DMLS - we don't want to consider any single data source sub-queries in any of these
            //Those !have! to be qualified with a prefix
            DMLSQLVisitor dmlsqlVisitor = new();
            sqlFragment.Accept(dmlsqlVisitor);
            List<TSqlFragment> allDMLs = dmlsqlVisitor.DMLs;

            //Now find all sub-queries not in another sub-query that have no more than one data source
            SingleSourceSubQueryQuerySpecificationVisitor singleSourceSubQueryVisitor = new();
            sqlFragment.Accept(singleSourceSubQueryVisitor);
            List<TSqlFragment> singleSourceSubQueries = singleSourceSubQueryVisitor.SingleSourceSubQueryQuerySpecifications;

            //Eliminate any that are within the scope of an DML statement.
            List<TSqlFragment> nonContainedSingleSourceSubQueries = new();
            foreach (var sub in singleSourceSubQueries)
            {
                if (!allDMLs.Any(dml => SqlComparisonUtils.SQLModel_Contains(dml, sub)))
                {
                    nonContainedSingleSourceSubQueries.Add(sub);
                }
            }
            // Add these top level single source sub-queries to our list
            allSingleSourceStatements.AddRange(nonContainedSingleSourceSubQueries);

            // Now all we need are top level inline views
            SingleSourceQueryDerivedTableQuerySpecificationVisitor singleSourceQueryDerivedTableQuerySpecificationVisitor = new();
            sqlFragment.Accept(singleSourceQueryDerivedTableQuerySpecificationVisitor);
            List<TSqlFragment> singleSourceQueryDerivedTableQuerySpecifications = singleSourceQueryDerivedTableQuerySpecificationVisitor.SingleSourceQueryDerivedTableQuerySpecifications;

            // We need to find top level inline views that are part of an apply
            // So - find Applies
            ApplySingleSourceQueryDefinitionVisitor applyTableSourceVisitor = new();
            sqlFragment.Accept(applyTableSourceVisitor);
            List<TSqlFragment> applyTableSources = applyTableSourceVisitor.ApplySingleSourceQueryDefinitions;

            //If the inline query is an apply query,
            //Eliminate it, as it must always contain aliased tables.
            List<TSqlFragment> nonApplyContainedSingleSourceQueryDerivedTableQuerySpecifications = new();
            foreach (var singleSourceInLineQuery in singleSourceQueryDerivedTableQuerySpecifications)
            {
                // If the query isn't contained in any apply clause we can add it.
                // Or if it is contained in an apply clause, but there is an intervening join query
                // with no intermediate apply clause containing the query
                if ((!applyTableSources.Any(applySource => SqlComparisonUtils.Equals(applySource, singleSourceInLineQuery)))
                    )
                {
                    nonApplyContainedSingleSourceQueryDerivedTableQuerySpecifications.Add(singleSourceInLineQuery);
                }
            }
            allSingleSourceStatements.AddRange(nonApplyContainedSingleSourceQueryDerivedTableQuerySpecifications);

            // Now we need to gather all sub-queries.
            SubQueryVisitor subQueryVisitor = new();
            sqlFragment.Accept(subQueryVisitor);
            List<ScalarSubquery> subQueries = subQueryVisitor.SubQueries;

            // Now we need to gather all applies.
            ApplyTableSourceVisitor applyTableSourceVisitor2 = new();
            sqlFragment.Accept(applyTableSourceVisitor2);
            List<TSqlFragment> applyTableSources2 = applyTableSourceVisitor2.ApplyTableSources;

            //We also need all CTES - to help eliminate sub-queries down the line
            CTEVisitor cteVisitor = new();
            sqlFragment.Accept(cteVisitor);
            List<TSqlFragment> visitorCtes = cteVisitor.CTES;

            // Create problems for each un-aliased table name found 
            foreach (var tableSource in allTableSources) //.Where( ts => ( ts is NamedTableReference || ts is VariableTableReference ) 
                //&& SqlComparisonUtils.SQLModel_Contains(allenforceTableAliasExcludedTableSources.Any(ts))) )
            {
                var processTableSource = true;
                foreach (var _ in tableAliasExcludedTableSources.Where(exclusion => SqlComparisonUtils.SQLModel_Contains(tableSource, exclusion)).Select(exclusion => new { }))
                {
                    processTableSource = false;
                    break;
                }

                if (processTableSource)
                {
                    bool ignoreThisTableSourceHere = false;

                    // what is it inside.
                    List<TSqlFragment> containers = allSingleSourceStatements.FindAll(n => SqlComparisonUtils.SQLModel_Contains(n, tableSource));
                    // which is it most tightly inside ?
                    // we could sort
                    // means writing another comparer
                    // let's loop for now
                    if (containers.Count > 0)
                    {
                        TSqlFragment tightestContainer = containers[0];
                        foreach (var c in containers)
                        {
                            if (SqlComparisonUtils.SQLModel_Contains(tightestContainer, c))
                            {
                                tightestContainer = c;
                            }
                        }

                        // Check that the table source is within the scope of the single source quep
                        // And not in any intervening sub-query or apply clause - where we need to enforce the alias
                        // And also check that the single source quep has no direct sub queries itself.
                        if ((!subQueries.Any(subQuery => SqlComparisonUtils.SemiContains(tightestContainer, subQuery)
                                                        && SqlComparisonUtils.StrictlyContains(subQuery, tableSource)
                                                )
                                )
                            && (!applyTableSources2.Any(ats => SqlComparisonUtils.SemiContains(tightestContainer, ats)
                                                                && SqlComparisonUtils.StrictlyContains(ats, tableSource)
                                                        )
                                )
                            )
                        {
                            // we also need to eliminate sub-queries in CTES in top-level containers from consideration
                            List<ScalarSubquery> containedSubQuerys =
                                 subQueries.FindAll(subQuery => SqlComparisonUtils.SemiContains(tightestContainer, subQuery)
                                                 && (!visitorCtes.Any(cte => SqlComparisonUtils.SQLModel_Contains(tightestContainer, cte)
                                                              && SqlComparisonUtils.SQLModel_Contains(cte, subQuery))
                                                    )
                                                  );

                            bool foundSubQueryInSingleSourceQuep = false;

                            foreach (var sq in containedSubQuerys)
                            {
                                TSqlFragment tightest_sq_Container = null;
                                List<TSqlFragment> sq_containers = allSingleSourceStatements.FindAll(n => SqlComparisonUtils.SQLModel_Contains(n, sq));
                                if (sq_containers.Count > 0)
                                {
                                    tightest_sq_Container = sq_containers[0];
                                    foreach (var c in sq_containers)
                                    {
                                        if (SqlComparisonUtils.SQLModel_Contains(tightest_sq_Container, c))
                                        {
                                            tightest_sq_Container = c;
                                        }
                                    }
                                }
                                // if we find a sub-query in this single source quep - we can't ignore the table source
                                if (tightest_sq_Container is not null && SqlComparisonUtils.Equals(tightest_sq_Container, tightestContainer))
                                {
                                    foundSubQueryInSingleSourceQuep = true;
                                    break;
                                }
                            }
                            if (!foundSubQueryInSingleSourceQuep)
                            {
                                ignoreThisTableSourceHere = true;
                            }
                        }
                    }
                    RuleDescriptor ruleDescriptor = ruleExecutionContext.RuleDescriptor;
                    RuleUtils.UpdateProblems(!ignoreThisTableSourceHere, problems, modelElement, elementName, tableSource, ruleDescriptor);
                }
            }
            return problems;
        }
    }
}