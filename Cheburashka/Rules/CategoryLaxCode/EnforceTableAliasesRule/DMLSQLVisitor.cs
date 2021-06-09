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
using System.Linq;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Cheburashka
{

    internal class DMLSQLVisitor : TSqlConcreteFragmentVisitor
    {
        private readonly List<TSqlFragment> _targets;

        public DMLSQLVisitor()
        {
            _targets = new List<TSqlFragment>();
        }
        public List<TSqlFragment> DMLs => _targets;

        public override void ExplicitVisit(DeleteStatement node)
        {
            _targets.Add(node);
        }
        public override void ExplicitVisit(UpdateStatement node)
        {
            _targets.Add(node);
        }
        public override void ExplicitVisit(MergeStatement node)
        {
            _targets.Add(node);
        }
        public override void ExplicitVisit(InsertStatement node)
        {
            // We want to ignore any source-less select statement that occurs in the context of an insert statement
            // This logic is so horribly back to front.
            // also any insert .. values 
            if (node.InsertSpecification.InsertSource is SelectInsertSource select)
            {
                List<QuerySpecification> querySpecifications = new List<QuerySpecification>();
                SQLGatherQuery.GetQuery(select.Select, ref querySpecifications);
                _targets.AddRange(querySpecifications.FindAll(SqlCheck.HasFromClause));
            }
            // if its a values clause it can contain scalar sub-queries (I suppose) - so don't return it an elimination context.
            else if (node.InsertSpecification.InsertSource is ValuesInsertSource) { }
            // give up - just add it in
            else
            {
                _targets.Add(node);
            }
            node.AcceptChildren(this);
        }

        //public override void ExplicitVisit(DataModificationTableReference node){
        //    List<QuerySpecification> querySpecifications = new();
        //    switch (node.DataModificationSpecification)
        //    {
        //        case InsertSpecification insertSpecification:
        //            {
        //                if (insertSpecification?.InsertSource is SelectInsertSource select)
        //                {
        //                    SQLGatherQuery.GetQuery(select.Select, ref querySpecifications);
        //                    List<QuerySpecification> qss = querySpecifications.FindAll(SqlCheck.HasFromClause);// && SqlCheck.HasNoIntoClause(n));
        //                    _targets.AddRange(qss);
        //                }
        //                break;
        //            }
        //    //    case MergeSpecification:
        //    //        {
        //    //            var ispec = node.DataModificationSpecification as MergeSpecification;
        //    //            if (ispec. .InsertSource is SelectInsertSource select)
        //    //            {
        //    //                SQLGatherQuery.GetQuery(select.Select, ref querySpecifications);
        //    //            }
        //    //            break;
        //    //        }
        //    //    case UpdateSpecification:
        //    //        break;
        //    //    case DeleteSpecification:
        //    //        break;
        //    }
        //    //node.AcceptChildren(this);

        //    //SQLGatherQuery.GetQuery(node.DataModificationSpecification.Target.

        //    //.QueryExpression, ref querySpecifications);
        //    //List<QuerySpecification> qss = querySpecifications.FindAll(n => SqlCheck.HasFromClause(n));// && SqlCheck.HasNoIntoClause(n));
        //    //_targets.AddRange(qss);
        //    _targets.Add(node);
        //}

        public override void ExplicitVisit(SelectStatement node)
        {
            // We want to ignore select statements that don't select from anything.
            // Assignment selects has the same status for us here as do set = (subquery) 
            List<QuerySpecification> querySpecifications = new();
            SQLGatherQuery.GetQuery(node.QueryExpression, ref querySpecifications);
            _targets.AddRange(querySpecifications.FindAll(SqlCheck.HasFromClause));
        }
    }
}