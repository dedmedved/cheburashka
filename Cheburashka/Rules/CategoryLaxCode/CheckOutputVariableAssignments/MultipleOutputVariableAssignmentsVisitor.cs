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

        private readonly Dictionary<string, List<VariableReference>> _variableUsages = new(SqlComparer.Comparer);
        private readonly Dictionary<string, int> _variableCounts = new(SqlComparer.Comparer);

        public MultipleOutputVariableAssignmentsVisitor()
        {
            MultipleOutputVariables = new List<VariableReference>();
        }
        public IList<VariableReference> MultipleOutputVariables { get; }

        public IList<TSqlFragment> SqlFragments() { return MultipleOutputVariables.Cast<TSqlFragment>().ToList(); }

        public override void ExplicitVisit(ExecuteSpecification node)
        {
            _variableCounts.Clear();
            _variableUsages.Clear();

            if (node.Variable is not null)
            {
                RecordDetailsOfUse(node.Variable);
            }
            // iterate over parameters
            node.AcceptChildren(this);

            foreach (var key in _variableCounts.Keys.Where(key => _variableCounts[key] > 1))
            {
                foreach (var v in _variableUsages[key])
                {
                    MultipleOutputVariables.Add(v);
                }
            }
        }
        public override void ExplicitVisit(ExecuteParameter node)
        {
            if (node.IsOutput && node.ParameterValue is VariableReference vr)
            {
                RecordDetailsOfUse(vr);
            }
        }

        private void RecordDetailsOfUse(VariableReference vr)
        {
            if (_variableUsages.ContainsKey(vr.Name))
            {
                _variableCounts[vr.Name]++;
                _variableUsages[vr.Name].Add(vr);
            }
            else
            {
                _variableCounts.Add(vr.Name, 1);
                _variableUsages.Add(vr.Name, new List<VariableReference> {vr});
            }
        }
    }
}
