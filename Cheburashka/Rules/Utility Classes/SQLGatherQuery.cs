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
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Cheburashka

{
    public static class SqlGatherQuery
    {
        public static void GetQuery(QueryExpression node, ref List<QuerySpecification> nodes)
        {
            if (node is QueryParenthesisExpression qp) { SqlGatherQuery.GetQuery(qp, ref nodes); }
            else if (node is BinaryQueryExpression bqe) { SqlGatherQuery.GetQuery(bqe, ref nodes); }
            else if (node is QuerySpecification qs) { SqlGatherQuery.GetQuery(qs, ref nodes); }
        }
        public static void GetQuery(ScalarSubquery node, ref List<QuerySpecification> nodes)
        {
            if (node.QueryExpression is QueryParenthesisExpression qp) { SqlGatherQuery.GetQuery(qp, ref nodes); }
            else if (node.QueryExpression is BinaryQueryExpression bqe) { SqlGatherQuery.GetQuery(bqe, ref nodes); }
            else if (node.QueryExpression is QuerySpecification qs) { SqlGatherQuery.GetQuery(qs, ref nodes); }
        }
        public static void GetQuery(QueryParenthesisExpression node, ref List<QuerySpecification> nodes)
        {
            if (node.QueryExpression is QueryParenthesisExpression qp) { SqlGatherQuery.GetQuery(qp, ref nodes); }
            else if (node.QueryExpression is BinaryQueryExpression bqe) { SqlGatherQuery.GetQuery(bqe, ref nodes); }
            else if (node.QueryExpression is QuerySpecification qs) { SqlGatherQuery.GetQuery(qs, ref nodes); }
        }
        public static void GetQuery(BinaryQueryExpression node, ref List<QuerySpecification> nodes)
        {
            if (node.FirstQueryExpression is QueryParenthesisExpression qp1) { SqlGatherQuery.GetQuery(qp1, ref nodes); }
            else if (node.FirstQueryExpression is BinaryQueryExpression bqe1) { SqlGatherQuery.GetQuery(bqe1, ref nodes); }
            else if (node.FirstQueryExpression is QuerySpecification qs1) { SqlGatherQuery.GetQuery(qs1, ref nodes); }

            if (node.SecondQueryExpression is QueryParenthesisExpression qp2) { SqlGatherQuery.GetQuery(qp2, ref nodes); }
            else if (node.SecondQueryExpression is BinaryQueryExpression bqe2) { SqlGatherQuery.GetQuery(bqe2, ref nodes); }
            else if (node.SecondQueryExpression is QuerySpecification qs2) { SqlGatherQuery.GetQuery(qs2, ref nodes); }
        }
        public static void GetQuery(QuerySpecification node, ref List<QuerySpecification> nodes)
        {
            //var fromClauseTableReferences = node?.FromClause?.TableReferences;
            //// Handle the special case of a DML Output as a data source - these only occur inside insert statements ?
            //// And can't be joined to or have an apply clause
            //if (fromClauseTableReferences?.Count == 1 && fromClauseTableReferences[0] is DataModificationTableReference)
            //{
            //    var x = fromClauseTableReferences[0] as DataModificationTableReference;
            //    switch (x?.DataModificationSpecification)
            //    {
            //        case InsertSpecification insertSpecification:
            //        {
            //            if (insertSpecification?.InsertSource is SelectInsertSource select)
            //            {
            //                SQLGatherQuery.GetQuery(select.Select, ref nodes);
            //            }
            //            break;
            //        }
            //        case MergeSpecification mergeSpecification:
            //        {
            //            SQLGatherQuery.GetQuery(mergeSpecification, ref nodes);
            //            break;
            //        }
            //        case UpdateSpecification updateSpecification:
            //        {
            //            SQLGatherQuery.GetQuery(updateSpecification.FromClause.TableReferences, ref nodes);
            //            break;
            //        }
            //        case DeleteSpecification deleteSpecification:
            //        {
            //            SQLGatherQuery.GetQuery(deleteSpecification.FromClause.TableReferences, ref nodes);
            //            break;
            //        }
            //    }
            //}
            //// otherwise use existing gather query logic to pull out the query specifications 
            //else
            //{
                nodes.Add(node);
            //}

        }
    }
}


