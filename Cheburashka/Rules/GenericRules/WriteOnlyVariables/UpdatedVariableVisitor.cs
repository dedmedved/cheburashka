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
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Cheburashka {

    //TODO handle XML functions
    internal class UpdatedVariableVisitor : TSqlConcreteFragmentVisitor
    {
        public UpdatedVariableVisitor()
        {
            SetVariables = new List<SQLExpressionDependency>();
        }

        public List<SQLExpressionDependency> SetVariables { get; private set; }

        public override void ExplicitVisit(SetVariableStatement node)
        {

            if (node.Variable == null  || node.Expression == null) return;
            SQLExpressionDependency ed = new SQLExpressionDependency(node.Variable,node,node.ToString());

            //Get variable references in the expression.
            var usageVisitor = new VariableUsageVisitor();
            node.Expression.Accept(usageVisitor);
            IList<VariableReference> variableReferences = usageVisitor.VariableReferences;
            //Add to dependencies
            ed.AddDependencies(variableReferences);
            SetVariables.Add(ed);
        }
        public override void ExplicitVisit(SelectSetVariable node)
        {
            if (node.Variable == null || node.Expression == null) return ;
            SQLExpressionDependency ed = new SQLExpressionDependency(node.Variable, node, node.ToString());

            //Get variable references in the expression.
            VariableUsageVisitor usageVisitor = new VariableUsageVisitor();
            node.Expression.Accept(usageVisitor);
            IList<VariableReference> variableReferences = usageVisitor.VariableReferences;
            //Add to dependencies
            ed.AddDependencies(variableReferences);
            SetVariables.Add(ed);
        }
        // This override prevents us writing a visitor for ExecuteParameter
        // The default visitor action stops.
        public override void ExplicitVisit(ExecuteSpecification node)
        {
            //node.SQLModel_DebugPrint(@"C:\temp\ExecuteStatement.out");
            if (node.Variable != null &&
                !String.IsNullOrEmpty(node.Variable.Name))
            {
                SQLExpressionDependency ed = new SQLExpressionDependency(node.Variable, node.Variable, node.Variable.ToString());
                // there are no dependencies in the sense we are using them.
                SetVariables.Add(ed);
            }
            // recurse into parameters
            node.AcceptChildren(this);
        }
        public override void ExplicitVisit(ExecuteParameter node)
        {
            //node.SQLModel_DebugPrint(@"C:\temp\ExecuteParameter.out");
            if (!node.IsOutput) return;

            if (node.ParameterValue != null)
            {
                var referenced = node.ParameterValue as VariableReference;
                if (referenced != null)
                {
                    var ed = new SQLExpressionDependency(referenced, node.ParameterValue, node.ParameterValue.ToString());
                    // there are no dependencies in the sense we are using them.
                    SetVariables.Add(ed);
                }
                else if (node.Variable != null)
                {
                    var ed = new SQLExpressionDependency(node.Variable, node.Variable, node.Variable.ToString());
                    // there are no dependencies in the sense we are using them.
                    SetVariables.Add(ed);
                }
            }
        }

        public override void ExplicitVisit(AssignmentSetClause node)
        {
            if (node.Variable == null ) return;
            SQLExpressionDependency ed = new SQLExpressionDependency(node.Variable, node, node.ToString());

            //Get variable references in the expression.
            VariableUsageVisitor usageVisitor = new VariableUsageVisitor();
            node.NewValue.Accept(usageVisitor);
            IList<VariableReference> variableReferences = usageVisitor.VariableReferences;
            //Add to dependencies
            ed.AddDependencies(variableReferences);
            SetVariables.Add(ed);
        }
        public override void ExplicitVisit(FetchCursorStatement node)
        {
            if (node.IntoVariables != null)
            {
                foreach (var v in node.IntoVariables)
                {
                    if (v != null )
                    {
                        SQLExpressionDependency ed = new SQLExpressionDependency(v, v, v.ToString());
                        SetVariables.Add(ed);
                    }
                }
            }
        }

        public override void ExplicitVisit(BeginDialogStatement node)
        {
            if (node.Handle == null || String.IsNullOrEmpty(node.Handle.Name)) return;
            SQLExpressionDependency ed = new SQLExpressionDependency(node.Handle,node.Handle,node.Handle.ToString());
            SetVariables.Add(ed);
        }
        public override void ExplicitVisit(ReceiveStatement node)
        {
            if (node.SelectElements == null) return;
            foreach (var v in node.SelectElements)
            {
                SelectSetVariable ssv = v as SelectSetVariable;
                if (ssv != null)
                {
                    SQLExpressionDependency ed = new SQLExpressionDependency(ssv.Variable,ssv,ssv.ToString());
//                    SetVariables.Add(ed);

                    //Get variable references in the expression.
                    VariableUsageVisitor usageVisitor = new VariableUsageVisitor();
                    ssv.Expression.Accept(usageVisitor);
                    IList<VariableReference> variableReferences = usageVisitor.VariableReferences;
                    //Add to dependencies
                    ed.AddDependencies(variableReferences);
                    SetVariables.Add(ed);

                }
            }
        }
    }
}
