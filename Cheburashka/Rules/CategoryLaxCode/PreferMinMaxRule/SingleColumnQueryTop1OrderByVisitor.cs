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
    internal class SingleColumnQueryTop1OrderByVisitor : TSqlConcreteFragmentVisitor, ICheburashkaTSqlConcreteFragmentVisitor
    {
        public SingleColumnQueryTop1OrderByVisitor()
        {
            SingleColumnQueryTop1OrderQueries = new List<QuerySpecification>();
        }
        public List<QuerySpecification > SingleColumnQueryTop1OrderQueries { get; }
        public IList<TSqlFragment> SqlFragments() { return SingleColumnQueryTop1OrderQueries.Cast<TSqlFragment>().ToList(); }
        public override void ExplicitVisit(QuerySpecification  node)
        {
            List<QuerySpecification> querySpecifications = new();
            SqlGatherQuery.GetQuery(node, ref querySpecifications);
            if (querySpecifications.Count == 1      //rule out intersect/union/except - it gets too hard to handle top 1 inside a union etc
                && querySpecifications[0] is { ForClause: null, GroupByClause: null, TopRowFilter: { Percent: false } topRowFilter } query 
                && query.SelectElements.Count == 1 
                && query.OrderByClause is not null 
                && query.OrderByClause is { } orderByClause 
                && orderByClause.OrderByElements.Count == 1 
                && query.SelectElements[0] is SelectScalarExpression selectScalarExpression
                )

            {
                IntegerLiteral topNCountValue;
                if (topRowFilter.Expression is IntegerLiteral integerLiteral) {
                    topNCountValue = integerLiteral;
                }
                else if (SQLFragmentExtensions.ExtractFromParenthesisExpression(topRowFilter.Expression, out topNCountValue)) { }
                if (topNCountValue?.Value == "1" ){
                    SQLFragmentExtensions.ExtractFromParenthesisExpression(selectScalarExpression.Expression, out var unwrappedSelCol);
                    SQLFragmentExtensions.ExtractFromParenthesisExpression(orderByClause.OrderByElements[0].Expression, out var unwrappedOrdCol);
                    var selcol = new SQLFragmentAsList(unwrappedSelCol);
                    var ordcol = new SQLFragmentAsList(unwrappedOrdCol);
                    
                    if (selcol.Elements.SequenceEqual(ordcol.Elements, SqlComparer.Comparer)
                        || orderByClause.OrderByElements[0].Expression is IntegerLiteral { Value: "1" })
                    {
                        SingleColumnQueryTop1OrderQueries.Add(node);
                    }
                }
            }
            node.AcceptChildren(this);
        }

    }
}