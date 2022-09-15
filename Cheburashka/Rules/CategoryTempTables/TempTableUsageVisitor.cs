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

    internal class TempTableUsageVisitor : TSqlConcreteFragmentVisitor, ICheburashkaTSqlConcreteFragmentVisitor
    {
        public TempTableUsageVisitor()
        {
            TempTableUsages = new List<Identifier>();
        }

        public IList<Identifier> TempTableUsages { get; }
        public IList<TSqlFragment> SqlFragments() { return TempTableUsages.Cast<TSqlFragment>().ToList(); }
        public override void ExplicitVisit(NamedTableReference node)
        {
            if (  node.SchemaObject.BaseIdentifier.Value.StartsWith("#")
             && ! node.SchemaObject.BaseIdentifier.Value.StartsWith("##")
            )
            {
                TempTableUsages.Add(node.SchemaObject.BaseIdentifier);
            }
        }
        //overrides where we don't want to pick up temp table references or visit dependent clauses
        public override void ExplicitVisit(CreateTableStatement _)
        {
            // Method intentionally left empty.
        }
        public override void ExplicitVisit(AlterTableAddTableElementStatement _)
        {
            // Method intentionally left empty.
        }
        public override void ExplicitVisit(AlterTableAlterColumnStatement _)
        {
            // Method intentionally left empty.
        }
        public override void ExplicitVisit(AlterTableAlterIndexStatement _)
        {
            // Method intentionally left empty.
        }
        public override void ExplicitVisit(AlterTableAlterPartitionStatement _)
        {
            // Method intentionally left empty.
        }
        public override void ExplicitVisit(AlterTableChangeTrackingModificationStatement _)
        {
            // Method intentionally left empty.
        }
        public override void ExplicitVisit(AlterTableConstraintModificationStatement _)
        {
            // Method intentionally left empty.
        }
        public override void ExplicitVisit(AlterTableDropTableElementStatement _)
        {
            // Method intentionally left empty.
        }
        public override void ExplicitVisit(AlterTableFileTableNamespaceStatement _)
        {
            // Method intentionally left empty.
        }
        public override void ExplicitVisit(AlterTableRebuildStatement _)
        {
            // Method intentionally left empty.
        }
        public override void ExplicitVisit(AlterTableSetStatement _)
        {
            // Method intentionally left empty.
        }
        public override void ExplicitVisit(AlterTableSwitchStatement _)
        {
            // Method intentionally left empty.
        }
        public override void ExplicitVisit(AlterTableTriggerModificationStatement _)
        {
            // Method intentionally left empty.
        }
        public override void ExplicitVisit(CreateIndexStatement _)
        {
            // Method intentionally left empty.
        }
        public override void ExplicitVisit(AlterIndexStatement _)
        {
            // Method intentionally left empty.
        }
        public override void ExplicitVisit(DropIndexStatement _)
        {
            // Method intentionally left empty.
        }













    }
}