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
using System.Collections.ObjectModel;

namespace Cheburashka
{
    internal class ParameterDeclarationVisitor : TSqlConcreteFragmentVisitor
    {
        private readonly List<ProcedureParameter> _targets;

        #region ctor
        public ParameterDeclarationVisitor()
        {
            _targets = new List<ProcedureParameter>();
        }
        #endregion

        #region properties
        public ReadOnlyCollection<ProcedureParameter> ParameterDeclarations => _targets.AsReadOnly();

        #endregion

        #region overrides
        public override void ExplicitVisit(AlterFunctionStatement node)
        {
            foreach (var p in node.Parameters)
            {
                _targets.Add(p);
            }
        }
        public override void ExplicitVisit(CreateFunctionStatement node)
        {
            foreach (var p in node.Parameters)
            {
                _targets.Add(p);
            }
        }
        public override void ExplicitVisit(AlterProcedureStatement node)
        {
            foreach (var p in node.Parameters)
            {
                _targets.Add(p);
            }
        }
        public override void ExplicitVisit(CreateProcedureStatement node)
        {
            foreach (var p in node.Parameters)
            {
                _targets.Add(p);
            }
        }
        #endregion

    }


}