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

            // visitor to get the occurrences of if and while statement expressions
            EnforceTableAliasVisitor enforceTableAliasVisitor = new EnforceTableAliasVisitor();
            sqlFragment.Accept(enforceTableAliasVisitor);
            List<TableReferenceWithAlias> allTableSources = enforceTableAliasVisitor.TableSources;

            //Check things we don't want to look inside (columns in update and delete statements with only one table)
            //Ditto select statements and CTE subqueries
            SingleSourceSQLVisitor singleSourceSQLVisitor = new SingleSourceSQLVisitor();
            sqlFragment.Accept(singleSourceSQLVisitor);
            List<TSqlFragment> allSingleSourceStatements = singleSourceSQLVisitor.SingleSourceSQLs;

            //Now work out what are the top level single source subqueries..............
            //First find all DMLS - we don't want to consider any single data source subqueries in any of these
            //Those !have! to be qualified with a prefix
            DMLSQLVisitor dMLSQLVisitor = new DMLSQLVisitor();
            sqlFragment.Accept(dMLSQLVisitor);
            List<TSqlFragment> allDMLs = dMLSQLVisitor.DMLs;

            //Now find all Subqueries not in another subquery that have no more than one data source
            SingleSourceSubQueryQuerySpecificationVisitor singleSourceSubQueryVisitor = new SingleSourceSubQueryQuerySpecificationVisitor();
            sqlFragment.Accept(singleSourceSubQueryVisitor);
            List<TSqlFragment> singleSourceSubQueries = singleSourceSubQueryVisitor.SingleSourceSubQueryQuerySpecifications;

            //Eliminate any that are within the scope of an DML statement.
            List<TSqlFragment> nonContainedSingleSourceSubQueries = new List<TSqlFragment>();
            foreach (var sub in singleSourceSubQueries)
            {
                if (!allDMLs.Any(dml => SqlComparisonUtils.SQLModel_Contains(dml, sub)))
                {
                    nonContainedSingleSourceSubQueries.Add(sub);
                }
            }
            // Add these top level single source subqueries to our list
            allSingleSourceStatements.AddRange(nonContainedSingleSourceSubQueries);

            // Now all we need are top level inline views
            SingleSourceQueryDerivedTableQuerySpecificationVisitor singleSourceQueryDerivedTableQuerySpecificationVisitor = new SingleSourceQueryDerivedTableQuerySpecificationVisitor();
            sqlFragment.Accept(singleSourceQueryDerivedTableQuerySpecificationVisitor);
            List<TSqlFragment> singleSourceQueryDerivedTableQuerySpecifications = singleSourceQueryDerivedTableQuerySpecificationVisitor.SingleSourceQueryDerivedTableQuerySpecifications;

            // We need to find top level inline views that are part of an apply
            // So - find Applies
            ApplySingleSourceQueryDefinitionVisitor applyTableSourceVisitor = new ApplySingleSourceQueryDefinitionVisitor();
            sqlFragment.Accept(applyTableSourceVisitor);
            List<TSqlFragment> applyTableSources = applyTableSourceVisitor.ApplySingleSourceQueryDefinitions;

            //If the inline query is an apply query,
            //Eliminate it, as it must always contain aliased tables.
            List<TSqlFragment> nonApplyContainedSingleSourceQueryDerivedTableQuerySpecifications = new List<TSqlFragment>();
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

            // Now we need to gather all subqueries.
            SubQueryVisitor subQueryVisitor = new SubQueryVisitor();
            sqlFragment.Accept(subQueryVisitor);
            List<ScalarSubquery> subQuerys = subQueryVisitor.SubQueries;

            // Now we need to gather all applies.
            ApplyTableSourceVisitor applyTableSourceVisitor2 = new ApplyTableSourceVisitor();
            sqlFragment.Accept(applyTableSourceVisitor2);
            List<TSqlFragment> applyTableSources2 = applyTableSourceVisitor2.ApplyTableSources;

            //We also need all CTES - to help eliminate subqueries down the line
            CTEVisitor cteVisitor = new CTEVisitor();
            sqlFragment.Accept(cteVisitor);
            List<TSqlFragment> ctes = cteVisitor.CTES;

            // Create problems for each unaliased table name found 
            foreach (var tableSource in allTableSources)
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
                    // And not in any intervening subquery or apply clause - where we need to enforce the alias
                    // And also check that the single source quep has no direct sub queries itself.
                    if ((!subQuerys.Any(subQuery => SqlComparisonUtils.SemiContains(tightestContainer, subQuery)
                                                    && SqlComparisonUtils.StrictlyContains(subQuery, tableSource)
                                            )
                            )
                        && (!applyTableSources2.Any(ats => SqlComparisonUtils.SemiContains(tightestContainer, ats)
                                                            && SqlComparisonUtils.StrictlyContains(ats, tableSource)
                                                    )
                            )
                        )
                    {
                        // we also need to eliminate subqueries in CTES in top-level containers from consideration
                        List<ScalarSubquery> containedSubQuerys =
                             subQuerys.FindAll(subQuery => SqlComparisonUtils.SemiContains(tightestContainer, subQuery)
                                             && (!ctes.Any(cte => SqlComparisonUtils.SQLModel_Contains(tightestContainer, cte)
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
                            // if we find a subquery in this single source quep - we can't ignore the table source
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
                    RuleDescriptor ruleDescriptor = ruleExecutionContext.RuleDescriptor;
                    RuleUtils.UpdateProblems(!ignoreThisTableSourceHere, problems, modelElement, elementName, tableSource, ruleDescriptor);
                }
            }
            return problems;
        }
    }
}