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
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Cheburashka
{
    internal class EnforceNamedConstraintDeclareTableVisitor : TSqlConcreteFragmentVisitor
    {
        private readonly List<TSqlFragment> _objects;
        
        public EnforceNamedConstraintDeclareTableVisitor()
        {
            _objects = new List<TSqlFragment>();
        }
        public List<TSqlFragment> Objects
        {
            get { return _objects; }
        }

        public override void ExplicitVisit(DeclareTableVariableStatement node)
        {
            _objects.Add(node);
        }
        public override void ExplicitVisit(CreateTableStatement node)
        {
            if (node.SchemaObjectName.BaseIdentifier.Value.StartsWith(@"#"))
            {
                _objects.Add(node);
            }
        }
        public override void ExplicitVisit(AlterTableAddTableElementStatement node)
        {
            if (node.SchemaObjectName.BaseIdentifier.Value.StartsWith(@"#"))
            {
                _objects.Add(node);
            }
        }
        public override void ExplicitVisit(AlterTableConstraintModificationStatement node)
        {
            if (node.SchemaObjectName.BaseIdentifier.Value.StartsWith(@"#"))
            {
                _objects.Add(node);
            }
        }
        public override void ExplicitVisit(CreateFunctionStatement node)
        {
            if (node.ReturnType != null)
            {
                if (node.ReturnType is TableValuedFunctionReturnType || node.ReturnType is SelectFunctionReturnType)
                {
                    _objects.Add(node.ReturnType);
                }
            }
        }
        public override void ExplicitVisit(AlterFunctionStatement node)
        {
            if (node.ReturnType != null)
            {
                if (node.ReturnType is TableValuedFunctionReturnType || node.ReturnType is SelectFunctionReturnType)
                {
                    _objects.Add(node.ReturnType);
                }
            }
        }

    }

}

