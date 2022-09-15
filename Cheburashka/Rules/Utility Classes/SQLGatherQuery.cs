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
            if (node is QueryParenthesisExpression qp) { GetQuery(qp, ref nodes); }
            else if (node is BinaryQueryExpression bqe) { GetQuery(bqe, ref nodes); }
            else if (node is QuerySpecification qs) { GetQuery(qs, ref nodes); }
        }
        public static void GetQuery(ScalarSubquery node, ref List<QuerySpecification> nodes)
        {
            if (node.QueryExpression is QueryParenthesisExpression qp) { GetQuery(qp, ref nodes); }
            else if (node.QueryExpression is BinaryQueryExpression bqe) { GetQuery(bqe, ref nodes); }
            else if (node.QueryExpression is QuerySpecification qs) { GetQuery(qs, ref nodes); }
        }
        public static void GetQuery(QueryParenthesisExpression node, ref List<QuerySpecification> nodes)
        {
            if (node.QueryExpression is QueryParenthesisExpression qp) { GetQuery(qp, ref nodes); }
            else if (node.QueryExpression is BinaryQueryExpression bqe) { GetQuery(bqe, ref nodes); }
            else if (node.QueryExpression is QuerySpecification qs) { GetQuery(qs, ref nodes); }
        }
        public static void GetQuery(BinaryQueryExpression node, ref List<QuerySpecification> nodes)
        {
            if (node.FirstQueryExpression is QueryParenthesisExpression qp1) { GetQuery(qp1, ref nodes); }
            else if (node.FirstQueryExpression is BinaryQueryExpression bqe1) { GetQuery(bqe1, ref nodes); }
            else if (node.FirstQueryExpression is QuerySpecification qs1) { GetQuery(qs1, ref nodes); }

            if (node.SecondQueryExpression is QueryParenthesisExpression qp2) { GetQuery(qp2, ref nodes); }
            else if (node.SecondQueryExpression is BinaryQueryExpression bqe2) { GetQuery(bqe2, ref nodes); }
            else if (node.SecondQueryExpression is QuerySpecification qs2) { GetQuery(qs2, ref nodes); }
        }
        public static void GetQuery(QuerySpecification node, ref List<QuerySpecification> nodes)
        {
            nodes.Add(node);
        }

        public static List<(SchemaObjectName,Identifier)> GetSpecificationSchemaTableReferences(IList<TableReference> TableReferences){
            List<(SchemaObjectName,Identifier)> values = new();
            foreach (var tableReference in TableReferences)
            {
                if ( tableReference is JoinParenthesisTableReference joinParenthesisTableReference) 
                {
                    List<TableReference> localTables = new() { joinParenthesisTableReference.Join };
                    values.AddRange(GetSpecificationSchemaTableReferences(localTables));
                }
                else if ( tableReference is JoinTableReference joinTableReference) // might need to subclass down to UnqualifiedJoin and QualifiedJoin
                {
                    List<TableReference> localTables = new() { joinTableReference.FirstTableReference, joinTableReference.SecondTableReference };
                    values.AddRange(GetSpecificationSchemaTableReferences(localTables));
                }
                else if ( tableReference is NamedTableReference /*TableReferenceWithAlias*/ namedTableReference) 
                {
                    values.Add((namedTableReference.SchemaObject,namedTableReference.Alias));
                }
                else if ( tableReference is TableReferenceWithAliasAndColumns /*TableReferenceWithAlias*/ tableReferenceWithAliasAndColumns) // this is another deep dark twisted set of inheritances
                {}
                else if ( tableReference is OdbcQualifiedJoinTableReference odbcQualifiedJoinTableReference 
                || tableReference is AdHocTableReference adHocTableReference //TableReferenceWithAlias
                || tableReference is BuiltInFunctionTableReference builtInFunctionTableReference //TableReferenceWithAlias
                || tableReference is FullTextTableReference fullTextTableReference //TableReferenceWithAlias
                || tableReference is GlobalFunctionTableReference globalFunctionTableReference //TableReferenceWithAlias
                || tableReference is InternalOpenRowset internalOpenRowset //TableReferenceWithAlias
                || tableReference is OpenJsonTableReference openJsonTableReference //TableReferenceWithAlias
                || tableReference is OpenRowsetTableReference openRowsetTableReference //TableReferenceWithAlias
                || tableReference is OpenXmlTableReference openXmlTableReference //TableReferenceWithAlias
                || tableReference is PivotedTableReference pivotedTableReference //TableReferenceWithAlias
                || tableReference is SemanticTableReference semanticTableReference //TableReferenceWithAlias
                || tableReference is UnpivotedTableReference unpivotedTableReference //TableReferenceWithAlias
                || tableReference is VariableTableReference variableTableReference //TableReferenceWithAlias
                ) {}

            }
            return values;
        }
    }
}


