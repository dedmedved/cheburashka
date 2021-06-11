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
    internal class EnforceTableAliasVisitor : TSqlConcreteFragmentVisitor
    {
        private readonly List<TSqlFragment> _tableSources;

        public EnforceTableAliasVisitor()
        {
            _tableSources = new List<TSqlFragment>();
        }

        public List<TSqlFragment> TableSources => _tableSources;

        public override void ExplicitVisit(AdHocTableReference node)
        {
            HandleNode(node);
        }
        public override void ExplicitVisit(BuiltInFunctionTableReference node)
        {
            HandleNode(node);
        }
        public override void ExplicitVisit(FullTextTableReference node)
        {
            HandleNode(node);
        }
        public override void ExplicitVisit(GlobalFunctionTableReference node)
        {
            HandleNode(node);
        }
        public override void ExplicitVisit(InternalOpenRowset node)
        {
            HandleNode(node);
        }

        // I can't believe I need to do this to prevent it picking up the TableReference which doesn't carry an alias
        public override void ExplicitVisit(MergeSpecification node)
        {
            if (node.TableAlias is null)
            {
                _tableSources.Add(node.Target);
            }
            node.TableReference.Accept(this);
            node.SearchCondition.Accept(this);
            foreach (var clause in node.ActionClauses)
            {
                clause.Accept(this);
            }
        }
        // this clause is broken for merge statement target nodes
        public override void ExplicitVisit(NamedTableReference node)
        {
            HandleNode(node);
        }
        public override void ExplicitVisit(OpenJsonTableReference node)
        {
            HandleNode(node);
        }
        public override void ExplicitVisit(OpenQueryTableReference node)
        {
            HandleNode(node);
        }
        public override void ExplicitVisit(OpenRowsetTableReference node)
        {
            HandleNode(node);
        }
        public override void ExplicitVisit(OpenXmlTableReference node)
        {
            HandleNode(node);
        }
        public override void ExplicitVisit(PivotedTableReference node)
        {
            HandleNode(node);
        }
        public override void ExplicitVisit(SemanticTableReference node)
        {
            HandleNode(node);
        }
        public override void ExplicitVisit(UnpivotedTableReference node)
        {
            HandleNode(node);
        }
        public override void ExplicitVisit(VariableTableReference node)
        {
            HandleNode(node);
        }

        public override void ExplicitVisit(BulkOpenRowset node)
        {
            HandleNode(node);
        }
        public override void ExplicitVisit(ChangeTableChangesTableReference node)
        {
            HandleNode(node);
        }
        public override void ExplicitVisit(ChangeTableVersionTableReference node)
        {
            HandleNode(node);
        }
        public override void ExplicitVisit(DataModificationTableReference node)
        {
            HandleNode(node);
        }
        public override void ExplicitVisit(InlineDerivedTable node)
        {
            HandleNode(node);
        }
        public override void ExplicitVisit(QueryDerivedTable node)
        {
            HandleNode(node);
        }
        public override void ExplicitVisit(SchemaObjectFunctionTableReference node)
        {
            HandleNode(node);
        }
        public override void ExplicitVisit(VariableMethodCallTableReference node)
        {
            HandleNode(node);
        }

        void HandleNode(TableReferenceWithAliasAndColumns node)
        {
            if (node.Alias is null)
            {
                _tableSources.Add(node);
            }
            node.AcceptChildren(this);
        }
        void HandleNode(TableReferenceWithAlias node)
        {
            if (node.Alias is null)
            {
                _tableSources.Add(node);
            }
            node.AcceptChildren(this);
        }
    }
}