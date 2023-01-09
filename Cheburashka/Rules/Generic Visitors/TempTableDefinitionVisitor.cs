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

    internal class TempTableDefinitionVisitor : TSqlConcreteFragmentVisitor, ICheburashkaTableDetailsVisitor
    {
        public TempTableDefinitionVisitor() { _TableDetails = new List<TableDetails>(); }
        public IList<TableDetails> _TableDetails { get; }
        public IList<TableDetails> TableDetails() { return _TableDetails.ToList(); }
        public override void ExplicitVisit(CreateTableStatement node)
        {
            if ( node.SchemaObjectName.IsAnyTempTableName()            )
                _TableDetails.Add(new TableDetails(node.SchemaObjectName.BaseIdentifier,node.Definition));
        }

        // at some point we might be clever enough to work out the table definition here
        // but given the larger scope is we're looking for inserts into temp table
        // its probably not going to be an issue
        //public override void ExplicitVisit(SelectStatement node)
        //{
        //    if (node.Into?.IsLocalTempTableName() == true
        //    )
        //    {
        //        TableVariableNames.Add(node.Into.BaseIdentifier);
        //    }
        //}

    }
}