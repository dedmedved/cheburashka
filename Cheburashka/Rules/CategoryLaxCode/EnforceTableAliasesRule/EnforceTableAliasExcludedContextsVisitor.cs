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
    internal class EnforceTableAliasExcludedContextsVisitor : TSqlConcreteFragmentVisitor
    {
        private List<TSqlFragment> _excludedFragments;

        public EnforceTableAliasExcludedContextsVisitor()
        {
            _excludedFragments = new List<TSqlFragment>();
        }

        public List<TSqlFragment> ExcludedFragments => _excludedFragments;

        public override void ExplicitVisit(OutputIntoClause node)
        {
            if (node.IntoTable is not null)
            {
                _excludedFragments.Add(node.IntoTable);
            }
        }
        public override void ExplicitVisit(InsertStatement node)
        {
            if (node.InsertSpecification.Target is not null)
            {
                _excludedFragments.Add(node.InsertSpecification.Target);
            }
            node.AcceptChildren(this);
        }
        public override void ExplicitVisit(MergeStatement node)
        {
            if (node.MergeSpecification.Target is not null)
            {
                _excludedFragments.Add(node.MergeSpecification.Target);
            }
            node.AcceptChildren(this);
        }
        public override void ExplicitVisit(DeleteStatement node)
        {
            if (node.DeleteSpecification.Target is not null)
            {
                _excludedFragments.Add(node.DeleteSpecification.Target);
            }
            node.AcceptChildren(this);
        }
        public override void ExplicitVisit(UpdateStatement node)
        {
            if (node.UpdateSpecification.Target is not null)
            {
                _excludedFragments.Add(node.UpdateSpecification.Target);
            }
            node.AcceptChildren(this);
        }
        public override void ExplicitVisit(DataModificationTableReference node)
        {
            if (node.DataModificationSpecification.Target is not null)
            {
                _excludedFragments.Add(node.DataModificationSpecification.Target);
            }
            node.AcceptChildren(this);
        }
        
    }
}