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
            if (node.Alias is null)
            {
                _tableSources.Add(node);
            }
            node.AcceptChildren(this);
        }
        public override void ExplicitVisit(BuiltInFunctionTableReference node)
        {
            if (node.Alias is null)
            {
                _tableSources.Add(node);
            }
            node.AcceptChildren(this);
        }
        public override void ExplicitVisit(FullTextTableReference node)
        {
            if (node.Alias is null)
            {
                _tableSources.Add(node);
            }
            node.AcceptChildren(this);
        }
        public override void ExplicitVisit(GlobalFunctionTableReference node)
        {
            if (node.Alias is null)
            {
                _tableSources.Add(node);
            }
            node.AcceptChildren(this);
        }
        public override void ExplicitVisit(InternalOpenRowset node)
        {
            if (node.Alias is null)
            {
                _tableSources.Add(node);
            }
            node.AcceptChildren(this);
        }
        public override void ExplicitVisit(NamedTableReference node)
        {
            if (node.Alias is null)
            {
                _tableSources.Add(node);
            }
            node.AcceptChildren(this);
        }
        public override void ExplicitVisit(OpenJsonTableReference node)
        {
            if (node.Alias is null)
            {
                _tableSources.Add(node);
            }
            node.AcceptChildren(this);
        }
        public override void ExplicitVisit(OpenQueryTableReference node)
        {
            if (node.Alias is null)
            {
                _tableSources.Add(node);
            }
            node.AcceptChildren(this);
        }
        public override void ExplicitVisit(OpenRowsetTableReference node)
        {
            if (node.Alias is null)
            {
                _tableSources.Add(node);
            }
            node.AcceptChildren(this);
        }
        public override void ExplicitVisit(OpenXmlTableReference node)
        {
            if (node.Alias is null)
            {
                _tableSources.Add(node);
            }
            node.AcceptChildren(this);
        }
        public override void ExplicitVisit(PivotedTableReference node)
        {
            if (node.Alias is null)
            {
                _tableSources.Add(node);
            }
            node.AcceptChildren(this);
        }
        public override void ExplicitVisit(SemanticTableReference node)
        {
            if (node.Alias is null)
            {
                _tableSources.Add(node);
            }
            node.AcceptChildren(this);
        }
        public override void ExplicitVisit(UnpivotedTableReference node)
        {
            if (node.Alias is null)
            {
                _tableSources.Add(node);
            }
            node.AcceptChildren(this);
        }
        public override void ExplicitVisit(VariableTableReference node)
        {
            if (node.Alias is null)
            {
                _tableSources.Add(node);
            }
            node.AcceptChildren(this);
        }

        public override void ExplicitVisit(BulkOpenRowset node)
        {
            if (node.Alias is null)
            {
                _tableSources.Add(node);
            }
            node.AcceptChildren(this);
        }
        public override void ExplicitVisit(ChangeTableChangesTableReference node)
        {
            if (node.Alias is null)
            {
                _tableSources.Add(node);
            }
            node.AcceptChildren(this);
        }
        public override void ExplicitVisit(ChangeTableVersionTableReference node)
        {
            if (node.Alias is null)
            {
                _tableSources.Add(node);
            }
            node.AcceptChildren(this);
        }
        public override void ExplicitVisit(DataModificationTableReference node)
        {
            if (node.Alias is null)
            {
                _tableSources.Add(node);
            }
            node.AcceptChildren(this);
        }
        public override void ExplicitVisit(InlineDerivedTable node)
        {
            if (node.Alias is null)
            {
                _tableSources.Add(node);
            }
            node.AcceptChildren(this);
        }
        public override void ExplicitVisit(QueryDerivedTable node)
        {
            if (node.Alias is null)
            {
                _tableSources.Add(node);
            }
            node.AcceptChildren(this);
        }
        public override void ExplicitVisit(SchemaObjectFunctionTableReference node)
        {
            if (node.Alias is null)
            {
                _tableSources.Add(node);
            }
            node.AcceptChildren(this);
        }
        public override void ExplicitVisit(VariableMethodCallTableReference node)
        {
            if (node.Alias is null)
            {
                _tableSources.Add(node);
            }
            node.AcceptChildren(this);
        }
    }
}