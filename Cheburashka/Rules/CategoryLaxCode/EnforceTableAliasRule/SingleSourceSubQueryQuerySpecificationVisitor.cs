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
using System.Linq;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Cheburashka
{
    internal class SingleSourceSubQueryQuerySpecificationVisitor : TSqlConcreteFragmentVisitor, ICheburashkaTSqlConcreteFragmentVisitor
    {
        public SingleSourceSubQueryQuerySpecificationVisitor()
        {
            SingleSourceSubQueryQuerySpecifications = new List<TSqlFragment>();
        }
        public List<TSqlFragment> SingleSourceSubQueryQuerySpecifications { get; }
        public IList<TSqlFragment> SqlFragments() { return SingleSourceSubQueryQuerySpecifications.ToList(); }
        public override void ExplicitVisit(ScalarSubquery node)
        {
            List<QuerySpecification> querySpecifications = new();
            SqlGatherQuery.GetQuery(node, ref querySpecifications);
            //// Guard against this case where the top level sqlfragment is an empty (select ......) 
            //// declare @product varchar(10) = (select(((SELECT a FROM (SELECT 1 as a)p))));
            //// declare @product varchar(10) = (select(((SELECT a FROM (SELECT 1 as a)p1 cross join (select 2 as b)p2))));
            foreach (var querySpecification in querySpecifications.Where(SqlCheck.HasExactlyOneFromClauseTableSource))
            {
                SingleSourceSubQueryQuerySpecifications.Add(querySpecification);                
            }
            foreach (var querySpecification in querySpecifications.Where(SqlCheck.HasNoFromClause))
            {
                querySpecification.AcceptChildren(this);
            }
        }
    }
}