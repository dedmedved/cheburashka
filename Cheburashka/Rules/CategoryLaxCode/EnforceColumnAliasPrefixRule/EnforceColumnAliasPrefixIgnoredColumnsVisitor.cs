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
using System.Linq;

namespace Cheburashka
{
    internal class EnforceColumnAliasPrefixIgnoredColumnsVisitor : TSqlConcreteFragmentVisitor, ICheburashkaTSqlConcreteFragmentVisitor
    {
        private readonly List<TSqlFragment> _columns;

        public EnforceColumnAliasPrefixIgnoredColumnsVisitor()
        {
            _columns = new List<TSqlFragment>();
        }
        public List<TSqlFragment> Columns => _columns;
        public IList<TSqlFragment> SqlFragments() { return Columns.Cast<TSqlFragment>().ToList(); }
        public override void ExplicitVisit(CreateIndexStatement node)
        {
            _columns.AddRange(node.Columns.Select(n=>n.Column));
            node.AcceptChildren(this);
        }
        public override void ExplicitVisit(UniqueConstraintDefinition node)
        {
            _columns.AddRange(node.Columns.Select(n=>n.Column));
            node.AcceptChildren(this);
        }

        public override void ExplicitVisit(OutputIntoClause node)
        {
            if (node.IntoTable is not null)
                _columns.AddRange(node.IntoTableColumns);
            node.AcceptChildren(this);
        }

        public override void ExplicitVisit(InsertSpecification node)
        {
            if (node.InsertSource is SelectInsertSource source)
            {
                // handle inserting from another dml's output clause
                // in this case there is only one data source and no columns
                // need qualifying
                var querySpecification = source.Select as QuerySpecification ;
                var fromClauseTableReferences = querySpecification?.FromClause?.TableReferences;
                if (fromClauseTableReferences?.Count == 1 && fromClauseTableReferences[0] is DataModificationTableReference)
                {
                    _columns.AddRange(querySpecification.SelectElements);
                    if (querySpecification.WhereClause is not null) 
                        _columns.Add(querySpecification.WhereClause.SearchCondition);
                    if (querySpecification.GroupByClause is not null) 
                        _columns.AddRange(querySpecification.GroupByClause.GroupingSpecifications);
                    if (querySpecification.HavingClause is not null) 
                        _columns.Add(querySpecification.HavingClause.SearchCondition);
                    if (querySpecification.TopRowFilter is not null) 
                        _columns.Add(querySpecification.TopRowFilter.Expression);
                }
                node.AcceptChildren(this);
            }
        }

        public override void ExplicitVisit(InsertStatement node)
        {
            _columns.AddRange(node.InsertSpecification.Columns);
            node.AcceptChildren(this);
        }
//        public override void ExplicitVisit(UpdateStatement node)
        public override void ExplicitVisit(UpdateSpecification node)
        {
            foreach (var setClause in node.SetClauses)
            {
                var setColumnClause = setClause as AssignmentSetClause;
                if (setColumnClause?.Column is not null)
                {
                    _columns.Add(setColumnClause.Column);
                }
            }
            node.AcceptChildren(this);
        }

        public override void ExplicitVisit(InsertMergeAction node)
        {
            foreach (var col in node.Columns)
            {
                _columns.Add(col);
            }

            if (node.Source.RowValues != null)
                foreach (var rv in node.Source.RowValues)
                {
                    foreach (var cv in rv.ColumnValues)
                    {
                        if (cv is ColumnReferenceExpression colRef)
                        {
                            _columns.Add(colRef);
                        }
                    }
                }
            node.AcceptChildren(this);
        }
        public override void ExplicitVisit(UpdateMergeAction node)
        {
            foreach (var setClause in node.SetClauses)
            {
                var setColumnClause = setClause as AssignmentSetClause;
                if (setColumnClause?.Column is not null)
                {
                    _columns.Add(setColumnClause.Column);
                }
            }
            node.AcceptChildren(this);
        }
    }
}



