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
using System;
using System.Collections.Generic;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Cheburashka
{

    internal class EnforceCaptureSPReturnStatusVisitor : TSqlConcreteFragmentVisitor
    {
        public EnforceCaptureSPReturnStatusVisitor()
        {
            ExecuteSpecifications = new List<ExecuteSpecification>();
        }

        public IList<ExecuteSpecification> ExecuteSpecifications { get; private set; }

        public override void ExplicitVisit(ExecuteSpecification node)
        {
           if ((node.Variable == null)
                ||
                 ((node.Variable != null) &&
                //                   ( node.Variable.Value == "" )
                   (String.IsNullOrEmpty(node.Variable.Name))
                 )
               )
            {
                if (node.ExecutableEntity is ExecutableProcedureReference &&
                     ((ExecutableProcedureReference)node.ExecutableEntity).ProcedureReference != null)
                {
                    TSqlFragment pr = ((ExecutableProcedureReference)node.ExecutableEntity).ProcedureReference;
                    string spName = pr.ScriptTokenStream[pr.LastTokenIndex].Text;
                    //TSqlParserToken name = pr.ScriptTokenStream[pr.LastTokenIndex];
                    if (!SqlRuleUtils.IgnoreTheReturnValueOf(spName))
                    {
                        ExecuteSpecifications.Add(node);
                    }
                }
            }
        }
    }


}