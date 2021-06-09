﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

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
    internal class SingleSourceSQLVisitor : TSqlConcreteFragmentVisitor
    {
        private readonly List<TSqlFragment> _targets;

        public SingleSourceSQLVisitor()
        {
            _targets = new List<TSqlFragment>();
        }

        public List<TSqlFragment> SingleSourceSQLs => _targets;

        public override void ExplicitVisit(DeleteSpecification node)
        {
            if (SqlCheck.HasAtMostOneTableSource(node))
            {
                _targets.Add(node);
            }
            node.AcceptChildren(this);
        }
        public override void ExplicitVisit(UpdateSpecification node)
        {
            if (SqlCheck.HasAtMostOneTableSource(node))
            {
                _targets.Add(node);
            }
            node.AcceptChildren(this);
        }
        public override void ExplicitVisit(MergeSpecification node)
        {
            if (SqlCheck.HasAtMostOneTableSource(node))
            {
                _targets.Add(node);
            }
            node.AcceptChildren(this);
        }

        public override void ExplicitVisit(InsertSpecification node)
        {
            if (node.InsertSource is SelectInsertSource source)
            {
                // if the insert is from a DataModificationTableReference - dive into it
                // and pull out the real inner DML it's shielding via AcceptChildren
                // and don't return *THIS* source as a single source SQL context, because
                // for our purposes it isn't
                var querySpecification = source.Select as QuerySpecification ;
                var fromClauseTableReferences = querySpecification?.FromClause?.TableReferences;
                if (fromClauseTableReferences?.Count == 1 && fromClauseTableReferences[0] is DataModificationTableReference)
                {
                    node.AcceptChildren(this);
                }
                // otherwise use existing gather query logic to pull out the query specifications 
                else
                {
                    List<QuerySpecification> querySpecifications = new();
                    SQLGatherQuery.GetQuery(source.Select, ref querySpecifications);
                    _targets.AddRange(querySpecifications.Where(SqlCheck.HasAtMostOneTableSource).Select(sq => node));
                }
            }

        }

        public override void ExplicitVisit(SelectStatement node)
        {
            List<QuerySpecification> querySpecifications = new();
            SQLGatherQuery.GetQuery(node.QueryExpression, ref querySpecifications);
            _targets.AddRange(querySpecifications.Where(SqlCheck.HasAtMostOneTableSource));
            node.AcceptChildren(this);
        }
        public override void ExplicitVisit(CommonTableExpression node)
        {
            List<QuerySpecification> querySpecifications = new();
            SQLGatherQuery.GetQuery(node.QueryExpression, ref querySpecifications);
            _targets.AddRange(querySpecifications.Where(SqlCheck.HasAtMostOneTableSource));
            node.AcceptChildren(this);
        }
    }
}