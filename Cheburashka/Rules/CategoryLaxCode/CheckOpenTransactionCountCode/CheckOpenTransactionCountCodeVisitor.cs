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
    internal class CheckOpenTransactionCountCodeVisitor : TSqlConcreteFragmentVisitor, ICheburashkaTSqlConcreteFragmentVisitor
    {
        public CheckOpenTransactionCountCodeVisitor()
        {
            Expressions = new List<BooleanExpression>();
        }

        public IList<BooleanExpression> Expressions { get; }
        public IList<TSqlFragment> SqlFragments() { return Expressions.Cast<TSqlFragment>().ToList(); }
        public override void ExplicitVisit(IfStatement node)
        {
            Expressions.Add(node.Predicate);
        }
        public override void ExplicitVisit(WhileStatement node)
        {
            Expressions.Add(node.Predicate);
        }
    }
}
