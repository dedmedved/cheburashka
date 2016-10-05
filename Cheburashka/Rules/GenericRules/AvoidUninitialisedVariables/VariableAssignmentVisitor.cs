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

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Cheburashka
{
    internal class VariableAssignmentVisitor : TSqlConcreteFragmentVisitor
    {
        public VariableAssignmentVisitor()
        {
            VariableAssignments = new List<VariableReference>();
        }

        public IList<VariableReference> VariableAssignments { get; private set; }

        public override void ExplicitVisit(SetVariableStatement node)
        {
            Debug.Assert(node != null, "node != null");
            if (node.Variable != null )
            {
                VariableAssignments.Add(node.Variable);
            }
        }

        public override void ExplicitVisit(SelectSetVariable node)
        {
            Debug.Assert(node != null, "node != null");
            if (node.Variable != null )
            {
                VariableAssignments.Add(node.Variable);
            }
        }

        public override void ExplicitVisit(ExecuteSpecification node)
        {
            Debug.Assert(node != null, "node != null");
            var execSpec = node.ExecutableEntity as ExecutableProcedureReference;
            if (execSpec != null)
            {
                IList<ExecuteParameter> parameters = execSpec.Parameters;

                //foreach (var p in parameters)
                //{
                //    p.SQLModel_DebugPrint(@"C:\temp\p.out");
                //}
            }

            //node.ExecuteSpecification.ExecuteContext.   .SQLModel_DebugPrint(@"C:\temp\ExecuteParameter.out");
            //node.SQLModel_DebugPrint(@"C:\temp\ExecuteStatement.out");
            if (node.Variable != null)
            {
                VariableAssignments.Add(node.Variable);
            }
            node.AcceptChildren(this);
        }
        public override void ExplicitVisit(ExecuteParameter node)
        {
            Debug.Assert(node != null, "node != null");
            //node.SQLModel_DebugPrint(@"C:\temp\ExecuteParameter.out");

            if (!node.IsOutput) return;

            if (node.ParameterValue != null)
            {
                var referenced = node.ParameterValue as VariableReference;
                if (referenced != null)
                {
                    VariableAssignments.Add(referenced);
                }
                else if (node.Variable != null)
                {
                    VariableAssignments.Add(node.Variable);
                }
            }
        }

        public override void ExplicitVisit(AssignmentSetClause node)
        {
            Debug.Assert(node != null, "node != null");
            if (node.Variable != null)
            {
                VariableAssignments.Add(node.Variable);
            }
        }

        public override void ExplicitVisit(FetchCursorStatement node)
        {
            Debug.Assert(node != null, "node != null");
            if (node.IntoVariables != null)
            {
                foreach (var v in node.IntoVariables)
                {
                    if (v != null)
                    {
                        VariableAssignments.Add(v);
                    }
                }
            }
        }

        public override void ExplicitVisit(BeginDialogStatement node)
        {
            Debug.Assert(node != null, "node != null");
            if (node.Handle != null && ! String.IsNullOrEmpty(node.Handle.Name))
            {
                VariableAssignments.Add(node.Handle);
            }
        }

        public override void ExplicitVisit(ReceiveStatement node)
        {
            Debug.Assert(node != null, "node != null");
            if (node.SelectElements != null)
            {
                foreach (var v in node.SelectElements)
                {
                    SelectSetVariable ssv = v as SelectSetVariable;
                    if (ssv != null)
                    {
                        VariableAssignments.Add(ssv.Variable);
                    }
                }
            }
        }
    }

}
