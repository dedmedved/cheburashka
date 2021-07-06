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

    internal class InitialisedOnlyVariablesVisitor : TSqlConcreteFragmentVisitor//, ICheburashkaTSqlConcreteFragmentVisitor
    {

        public List<string> InputVariableNames;

        public InitialisedOnlyVariablesVisitor(List<string> inputVariables) => InputVariableNames = inputVariables;

        // The declarations of variables with assigned values.
        private readonly Dictionary<string, TSqlFragment> variableInitialisations = new(SqlComparer.Comparer);
        // Any assignment we find to a variable, or an assignment we don't like
        private readonly Dictionary<string, TSqlFragment> invalidVariableAssignments = new(SqlComparer.Comparer);

        //public InitialisedOnlyVariablesVisitor(List<VariableReference> variableReferences) => VariableReferences = variableReferences;

        public IList<string> InitialisedOnlyVariables()
        {
            var variablesNamesFound = variableInitialisations.Keys;
            var singleValidAssignments = variablesNamesFound.Where( V => !invalidVariableAssignments.Any(iva => iva.Key.SQLModel_StringCompareEqual(V))).ToList();
            return singleValidAssignments;
        }

        //public IList<TSqlFragment> SqlFragments()
        //{
        //    return InitialisedOnlyVariables().Cast<TSqlFragment>().ToList();
        //}

        public override void ExplicitVisit(SetVariableStatement node)
        {
            if (node.Variable is not null)
            {
                AddVariableToListOfIgnoredVariables(node.Variable.Name);
            }
        }

        public override void ExplicitVisit(DeclareVariableElement node)
        {
            if ( node.Value is not null)
            {
                UpdateDictionariesWithExpression(node.VariableName, node.Value, AssignmentKind.Equals, node);
            }
            else
            {
                AddVariableToListOfIgnoredVariables(node.VariableName.Value);
            }
        }

        public override void ExplicitVisit(SelectSetVariable node)
        {
             AddVariableToListOfIgnoredVariables(node.Variable.Name);
        }

        public override void ExplicitVisit(ExecuteSpecification node)
        {
            if (!string.IsNullOrEmpty(node.Variable?.Name))
                AddVariableToListOfIgnoredVariables(node.Variable.Name);
            // recurse into parameters
            node.AcceptChildren(this);
        }

        public override void ExplicitVisit(ExecuteParameter node)
        {
            if (node.IsOutput && !string.IsNullOrEmpty(node.Variable?.Name))
            {
                AddVariableToListOfIgnoredVariables(node.Variable.Name);
            }
        }

        //can't be an assignment set clause - the update might update no rows
        public override void ExplicitVisit(AssignmentSetClause node)
        {
            if (node.Variable is not null)
            {
                AddVariableToListOfIgnoredVariables(node.Variable.Name);
            }
        }
        //can't be a fetch clause - the fetch might not return anything
        //and assigning constants to variable in a fetch will be a target of anothert rule
        public override void ExplicitVisit(FetchCursorStatement node)
        {
            if (node.IntoVariables is not null)
            {
                foreach (var v in node.IntoVariables.Where(n => n is not null))
                {
                    AddVariableToListOfIgnoredVariables(v.Name);
                }
            }
        }

        public override void ExplicitVisit(BeginDialogStatement node)
        {
            if (node.Handle is null || string.IsNullOrEmpty(node.Handle.Name)) return;
            AddVariableToListOfIgnoredVariables(node.Handle.Name);
        }

        public override void ExplicitVisit(ReceiveStatement node)
        {
            if (node.SelectElements is null) return;
            var setVariables = node.SelectElements.Where(n => n is SelectSetVariable ssv).Cast<SelectSetVariable>().ToList().Select(n => n.Variable);
            foreach (var variable in setVariables)
            {
                AddVariableToListOfIgnoredVariables(variable.Name);
            }
        }

        private void UpdateDictionariesWithExpression(Identifier var, ScalarExpression expression, AssignmentKind assignment, TSqlFragment source)
        {
            if (var is null || expression is null) return;
            // the expression can now be a literal expression 
            if (assignment == AssignmentKind.Equals
            )
            {
                var referencedVariables = DmTSqlFragmentVisitor.Visit(expression, new VariableReferenceVisitor(InputVariableNames)).ToList();
                var disallowedNonDeterministicFunctions = DmTSqlFragmentVisitor.Visit(expression, new NonDeterministicSystemFunctionVisitor());
                // if the scalar expression doesnt contain any variables it's safe to consider it to be an initialisation expression
                if (!referencedVariables.Any() && !disallowedNonDeterministicFunctions.Any())
                {
                    if (!variableInitialisations.ContainsKey(var.Value))
                    {
                        variableInitialisations.Add(var.Value, source);
                    }
                    else
                    {
                        AddVariableToListOfIgnoredVariables(var.Value);
                    }
                }
                else
                {
                    AddVariableToListOfIgnoredVariables(var.Value);
                }
            }
            else
            {
                AddVariableToListOfIgnoredVariables(var.Value);
            }
        }

        private void AddVariableToListOfIgnoredVariables(string var)
        {
            if (var is null) return;
            if (!invalidVariableAssignments.ContainsKey(var))
                invalidVariableAssignments.Add(var,
                    new StringLiteral()); // doesnt matter what kind of literal we add here, we just need to record a usage which breaks our limited criteria
        }
    }
}
