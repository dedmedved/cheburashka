﻿//------------------------------------------------------------------------------
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
    

    internal class NamedParameterUsageVisitor : TSqlConcreteFragmentVisitor
    {
        public NamedParameterUsageVisitor()
        {
            NamedParameters = new List<VariableReference>();
        }

        public IList<VariableReference> NamedParameters { get; private set; }

        public override void ExplicitVisit(ExecuteParameter node)
        {
            VariableReference pv = node.Variable ;
//            if (PV != null && PV.LiteralType == LiteralType.Variable)
            if (pv != null )
            {
                NamedParameters.Add(pv);
            }

        }

    }
}