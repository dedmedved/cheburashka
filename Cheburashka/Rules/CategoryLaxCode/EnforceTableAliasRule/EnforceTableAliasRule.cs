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
        RuleConstants.EnforceTableAliasRuleName,                   // ID used to look up the display name inside the resources file
        RuleConstants.EnforceTableAliasProblemDescription,                 // ID used to look up the description inside the resources file
        Category = RuleConstants.CategoryNonStrictCodingStyleNames,         // Rule category (e.g. "Design", "Naming")
        RuleScope = SqlRuleScope.Element)]                                  // This rule targets specific elements rather than the whole model
    public sealed class EnforceTableAliasRule : SqlCodeAnalysisRule
    {
        /// <summary>
        /// The Rule ID should resemble a fully-qualified class name. In the Visual Studio UI
        /// rules are grouped by "Namespace + Category", and each rule is shown using "Short ID: DisplayName".
        /// For this rule, it will be 
        /// shown as "DM0047: Tables, views and other data sources in DML need aliases where disambiguation is necessary."
        /// </summary>
        public const string RuleId = RuleConstants.EnforceTableAliasRuleId;

        public EnforceTableAliasRule()
        {
            SupportedElementTypes = SqlRuleUtils.GetCodeAndViewContainingClasses();
        }

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
            DmvSettings.RefreshModelBuiltInCache(ruleExecutionContext.SchemaModel);

            // visitor to get the occurrences of all insert/merge etc targets and output into clauses
            var tableAliasExcludedTableSources = DmTSqlFragmentVisitor.Visit(sqlFragment, new EnforceTableAliasExcludedContextsVisitor());
            // visitor to get the occurrences of all data source things
            var allTableSources = DmTSqlFragmentVisitor.Visit(sqlFragment, new EnforceTableAliasVisitor());
            //Check things we don't want to look inside (columns in update and delete statements with only one table)
            //Ditto select statements and CTE sub-queries
            List<TSqlFragment> allSingleSourceStatements = DmTSqlFragmentVisitor.Visit(sqlFragment, new SingleSourceSqlVisitor()).ToList();
            //Now work out what are the top level single source sub-queries..............
            //First find all DMLS - we don't want to consider any single data source sub-queries in any of these
            //Those !have! to be qualified with a prefix
            var allDmLs = DmTSqlFragmentVisitor.Visit(sqlFragment, new DmlsqlVisitor());
            //Now find all sub-queries not in another sub-query that have no more than one data source
            var singleSourceSubQueries = DmTSqlFragmentVisitor.Visit(sqlFragment, new SingleSourceSubQueryQuerySpecificationVisitor());
            //Eliminate any that are within the scope of an DML statement.
            List<TSqlFragment> nonContainedSingleSourceSubQueries = new();
            foreach (var sub in singleSourceSubQueries)
            {
                if (!allDmLs.Any(dml => dml.SQLModel_Contains(sub)))
                {
                    nonContainedSingleSourceSubQueries.Add(sub);
                }
            }
            // Add these top level single source sub-queries to our list
            allSingleSourceStatements.AddRange(nonContainedSingleSourceSubQueries);
            // Now all we need are top level inline views
            var singleSourceQueryDerivedTableQuerySpecifications = DmTSqlFragmentVisitor.Visit(sqlFragment, new SingleSourceQueryDerivedTableQuerySpecificationVisitor());
            // We need to find top level inline views that are part of an apply
            // So - find Applies
            var applyTableSources = DmTSqlFragmentVisitor.Visit(sqlFragment, new ApplySingleSourceQueryDefinitionVisitor());

            //If the inline query is an apply query,
            //Eliminate it, as it must always contain aliased tables.
            List<TSqlFragment> nonApplyContainedSingleSourceQueryDerivedTableQuerySpecifications = new();
            foreach (var singleSourceInLineQuery in singleSourceQueryDerivedTableQuerySpecifications)
            {
                // If the query isn't contained in any apply clause we can add it.
                // Or if it is contained in an apply clause, but there is an intervening join query
                // with no intermediate apply clause containing the query
                if (!applyTableSources.Any(applySource => SqlComparisonUtils.Equals(applySource, singleSourceInLineQuery))
                    )
                {
                    nonApplyContainedSingleSourceQueryDerivedTableQuerySpecifications.Add(singleSourceInLineQuery);
                }
            }
            allSingleSourceStatements.AddRange(nonApplyContainedSingleSourceQueryDerivedTableQuerySpecifications);

            // Now we need to gather all sub-queries.
            var subQueries = DmTSqlFragmentVisitor.Visit(sqlFragment, new SubQueryVisitor()).ToList();
            // Now we need to gather all applies.
            var applyTableSources2 = DmTSqlFragmentVisitor.Visit(sqlFragment, new ApplyTableSourceVisitor()).ToList();
            //We also need all CTES - to help eliminate sub-queries down the line
            var visitorCtes = DmTSqlFragmentVisitor.Visit(sqlFragment, new CteVisitor()).ToList();

            // Create problems for each un-aliased table name found 
            foreach (var tableSource in allTableSources) 
            {
                var processTableSource = true;
                foreach (var _ in tableAliasExcludedTableSources.Where(exclusion => tableSource.SQLModel_Contains(exclusion)).Select(_ => new { }))
                {
                    processTableSource = false;
                    break;
                }

                if (processTableSource)
                {
                    bool ignoreThisTableSourceHere = false;

                    // what is it inside.
                    List<TSqlFragment> containers = allSingleSourceStatements.FindAll(n => n.SQLModel_Contains(tableSource));
                    // which is it most tightly inside ?
                    // we could sort
                    // means writing another comparer
                    // let's loop for now
                    if (containers.Count > 0)
                    {
                        TSqlFragment tightestContainer = containers[0];
                        foreach (var c in containers)
                        {
                            if (tightestContainer.SQLModel_Contains(c))
                            {
                                tightestContainer = c;
                            }
                        }

                        // Check that the table source is within the scope of the single source quep
                        // And not in any intervening sub-query or apply clause - where we need to enforce the alias
                        // And also check that the single source quep has no direct sub queries itself.
                        if ((!subQueries.Any(subQuery => tightestContainer.SemiContains(subQuery)
                                                        && subQuery.StrictlyContains(tableSource)
                                                )
                                )
                            && (!applyTableSources2.Any(ats => tightestContainer.SemiContains(ats)
                                                                && ats.StrictlyContains(tableSource)
                                                        )
                                )
                            )
                        {
                            // we also need to eliminate sub-queries in CTES in top-level containers from consideration
                            var containedSubQueries =
                                 subQueries.FindAll(subQuery => tightestContainer.SemiContains(subQuery)
                                                 && (!visitorCtes.Any(cte => tightestContainer.SQLModel_Contains(cte)
                                                              && cte.SQLModel_Contains(subQuery))
                                                    )
                                                  );

                            bool foundSubQueryInSingleSourceQuep = false;

                            foreach (var sq in containedSubQueries)
                            {
                                TSqlFragment tightestSqContainer = null;
                                List<TSqlFragment> sqContainers = allSingleSourceStatements.FindAll(n => n.SQLModel_Contains(sq));
                                if (sqContainers.Count > 0)
                                {
                                    tightestSqContainer = sqContainers[0];
                                    foreach (var c in sqContainers)
                                    {
                                        if (tightestSqContainer.SQLModel_Contains(c))
                                        {
                                            tightestSqContainer = c;
                                        }
                                    }
                                }
                                // if we find a sub-query in this single source quep - we can't ignore the table source
                                if (tightestSqContainer is not null && SqlComparisonUtils.Equals(tightestSqContainer, tightestContainer))
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