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

    internal class TempTableMergeIntoVisitor : TSqlConcreteFragmentVisitor, ICheburashkaTSqlConcreteFragmentVisitor
    {
        public TempTableMergeIntoVisitor()
        {
            TempTableNames = new List<Identifier>();
        }

        public IList<Identifier> TempTableNames { get; }
        public IList<TSqlFragment> SqlFragments() { return TempTableNames.Cast<TSqlFragment>().ToList(); }

        public override void ExplicitVisit(SelectStatement node)
        {
            if (node.Into?.IsLocalTempTableName() == true
            )
            {
                TempTableNames.Add(node.Into.BaseIdentifier);
            }
        }
        public override void ExplicitVisit(InsertStatement node)
        {
            if (node.InsertSpecification.Target is NamedTableReference insertTableReference
            && insertTableReference.IsLocalTempTableName())
            {
                TempTableNames.Add(insertTableReference.SchemaObject.BaseIdentifier);
            }
            node.AcceptChildren(this);  // there may be a contained merge statement with an output clause feeding this insert
        }
        public override void ExplicitVisit(MergeSpecification node)
        {
            if (node.Target is NamedTableReference mergeTargetTableReference
            && mergeTargetTableReference.IsLocalTempTableName()
            && node.ActionClauses.Any(n => n.Action is InsertMergeAction insetMergeAction)
            )
            {
                TempTableNames.Add(mergeTargetTableReference.SchemaObject.BaseIdentifier);
            }
            node.AcceptChildren(this);
        }
        public override void ExplicitVisit(OutputIntoClause node)
        {
            if (node.IntoTable is NamedTableReference outputIntoTableReference
            && outputIntoTableReference.IsLocalTempTableName()
            )
            {
                TempTableNames.Add(outputIntoTableReference.SchemaObject.BaseIdentifier);
            }
            node.AcceptChildren(this);
        }
    }
}