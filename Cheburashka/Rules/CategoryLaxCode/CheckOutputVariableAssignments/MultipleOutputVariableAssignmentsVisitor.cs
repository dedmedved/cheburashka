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
    internal class MultipleOutputVariableAssignmentsVisitor : TSqlConcreteFragmentVisitor,
        ICheburashkaTSqlConcreteFragmentVisitor
    {
        private readonly Dictionary<string, List<VariableReference>> variableUsages = new(SqlComparer.Comparer);
        private readonly Dictionary<string, int> variableCounts = new(SqlComparer.Comparer);
    

    public IList<VariableReference> MultipleOutputVariables()
    {
        List<VariableReference> values = new();
        foreach (var key in variableCounts.Keys.Where(key => variableCounts[key] > 1))
        {
            values.AddRange(variableUsages[key]);
        }
        return values;
    }

    public IList<TSqlFragment> SqlFragments() { return MultipleOutputVariables().Cast<TSqlFragment>().ToList(); }
        public override void ExplicitVisit(ExecuteSpecification node)
        {
            if (node.Variable is not null)
            {
                if (variableUsages.ContainsKey(node.Variable.Name))
                {
                    variableCounts[node.Variable.Name]++;
                    variableUsages[node.Variable.Name].Add(node.Variable);
                }
                else
                {
                    variableCounts.Add(node.Variable.Name, 1);
                    variableUsages.Add(node.Variable.Name,new List<VariableReference>{node.Variable});
                }
            }
            node.AcceptChildren(this);
        }
        public override void ExplicitVisit(ExecuteParameter node)
        {
            if (node.IsOutput && node.ParameterValue is VariableReference vr)
            {
                if (variableUsages.ContainsKey(vr.Name))
                {
                    variableCounts[vr.Name]++;
                    variableUsages[vr.Name].Add(vr);
                }
                else
                {
                    variableCounts.Add(vr.Name, 1);
                    variableUsages.Add(vr.Name, new List<VariableReference> {vr});
                }
            }
        }
    }
}
