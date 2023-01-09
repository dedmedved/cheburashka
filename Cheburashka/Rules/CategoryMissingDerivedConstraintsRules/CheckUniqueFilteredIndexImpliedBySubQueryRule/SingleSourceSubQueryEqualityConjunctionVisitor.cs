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
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Cheburashka
{
    internal class SingleSourceSubQueryEqualityConjunctionVisitor : TSqlConcreteFragmentVisitor, ICheburashkaTSqlConcreteFragmentVisitor
    {
        public SingleSourceSubQueryEqualityConjunctionVisitor()
        {
            SingleSourceSubQueryEqualityConjunctions = new List<ScalarSubquery>();
        }
        public List<ScalarSubquery> SingleSourceSubQueryEqualityConjunctions { get; }
        public IList<TSqlFragment> SqlFragments() { return SingleSourceSubQueryEqualityConjunctions.Cast<TSqlFragment>().ToList(); }
        public override void ExplicitVisit(ScalarSubquery node)
        {
            List<QuerySpecification> querySpecifications = new();
            SqlGatherQuery.GetQuery(node, ref querySpecifications);
            if (querySpecifications.Count == 1      //rule out intersect/union/except
                && querySpecifications[0] is { } query
                && SqlCheck.HasExactlyOneFromClauseTableSource(query)
                && query.ForClause is null 
                && query.FromClause.TableReferences[0] is TableReferenceWithAlias table
                && query.GroupByClause is null
                && query.TopRowFilter is null
                && query.UniqueRowFilter is UniqueRowFilter.All or UniqueRowFilter.NotSpecified 
                && query.WhereClause?.SearchCondition != null
                //todo reinstate this when vs2017 either updated or out of commission
//                && table is NamedTableReference { ForPath: false, TableSampleClause: null, TemporalClause: null }
                && table is NamedTableReference { TableSampleClause: null, TemporalClause: null }
                //todo - handle clash between schema-less table usages and ctes etc with same name in the same query
                //todo - for now ignore this problem - it is a problem as ctes etc hide schema object and not vv
                )

            //= (SELECT   COUNT (*)..
            // so no builtin aggregate functions at all - and no user defined functions to be safe -or no user defined clr functions at least
            // = != etc


            {
                var allAggregateFunctionFilterVisitor = new AggregateFunctionFilterVisitor();
                foreach (var se in query.SelectElements) { se.Accept(allAggregateFunctionFilterVisitor); }
                var noAggregateFunctions = allAggregateFunctionFilterVisitor.FunctionCalls.Count == 0;

                var booleanVisitor = new BooleanExpressionEqualityFilterVisitor();
                query.WhereClause.SearchCondition.Accept(booleanVisitor);
                var validWhereClause = booleanVisitor.ValidAndedEqualityBooleanExpression;
                if (validWhereClause && noAggregateFunctions)
                {
                    SingleSourceSubQueryEqualityConjunctions.Add(node);                
                }
            }
            node.AcceptChildren(this);
        }
    }
}