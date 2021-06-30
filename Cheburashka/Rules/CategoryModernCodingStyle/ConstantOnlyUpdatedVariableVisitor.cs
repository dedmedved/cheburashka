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

    internal class ConstantOnlyUpdatedVariableVisitor : TSqlConcreteFragmentVisitor, ICheburashkaTSqlConcreteFragmentVisitor
    {

        // The first assignment we find to a variable
        private readonly Dictionary<string, TSqlFragment> variableAssignments = new(SqlComparer.Comparer);
        // The second assignment we find to a variable, or an assignment we don't like
        private readonly Dictionary<string, TSqlFragment> invalidVariableAssignments = new(SqlComparer.Comparer);

        private bool ignoreAllVisitedVariables = false;

        public IList<TSqlFragment> VariableAssignments()
        {
            var singleValidAssignmentKeys = variableAssignments.Keys.Except(invalidVariableAssignments.Keys, SqlComparer.Comparer);
            List<TSqlFragment> sqlFragments = new();
            foreach (var v in singleValidAssignmentKeys)
            {
                sqlFragments.Add(variableAssignments[v]);
            }
            return sqlFragments;
        }

        public IList<TSqlFragment> SqlFragments()
        {
            return VariableAssignments();
        }

        public override void ExplicitVisit(SetVariableStatement node)
        {
            UpdateDictionariesWithExpression(node.Variable,node.Expression,node.AssignmentKind,node);
        }

        public override void ExplicitVisit(SelectStatement node)
        {
            // only visit the SelectSetVariable nodes if this statement has no from clause
            // and is a simple query expression no unions, no nested barcketed expressions
            // keep it simple
            if ( node.QueryExpression is QuerySpecification {FromClause: null})
            {
                node.AcceptChildren(this);
            }
            else
            {
                ignoreAllVisitedVariables = true;
                node.AcceptChildren(this);
                ignoreAllVisitedVariables = false;
            }
        }

        public override void ExplicitVisit(SelectSetVariable node)
        {
            if (ignoreAllVisitedVariables)
                //if the select statement has a from clause, ignroe everything we meet.
                //(so far thats the only condition triggering this logic)
                AddVariableToListOfIgnoredVariables(node.Variable); 
            else 
                //As above - only where we have no from clause - so we're certain the variable assignment happens
                UpdateDictionariesWithExpression(node.Variable, node.Expression, node.AssignmentKind,node);
        }

        public override void ExplicitVisit(ExecuteSpecification node)
        {
            if ( ! string.IsNullOrEmpty(node.Variable?.Name))
                AddVariableToListOfIgnoredVariables(node.Variable);
            // recurse into parameters
            node.AcceptChildren(this);
        }

        public override void ExplicitVisit(ExecuteParameter node)
        {
            if (node.IsOutput && !string.IsNullOrEmpty(node.Variable?.Name))
                AddVariableToListOfIgnoredVariables(node.Variable);
        }

        //can't be an assignment set clause - the update might update no rows
        public override void ExplicitVisit(AssignmentSetClause node)
        {
            if (node.Variable is not null )
                AddVariableToListOfIgnoredVariables(node.Variable);
            //UpdateDictionariesWithExpression(node.Variable, node.NewValue, node.AssignmentKind,node);
        }
        //can't be a fetch clause - the fetch might not return anything
        //and assigning constants to variable in a fetch will be a target of anothert rule
        public override void ExplicitVisit(FetchCursorStatement node)
        {
            if (node.IntoVariables is not null)
            {
                foreach (var v in node.IntoVariables.Where(n => n is not null))
                {
                    AddVariableToListOfIgnoredVariables(v);
                }
            }
        }

        public override void ExplicitVisit(BeginDialogStatement node)
        {
            if (node.Handle is null || string.IsNullOrEmpty(node.Handle.Name)) return;
            AddVariableToListOfIgnoredVariables(node.Handle);
        }

        public override void ExplicitVisit(ReceiveStatement node)
        {
            if (node.SelectElements is null) return;
            var setVariables = node.SelectElements.Where(n => n is SelectSetVariable ssv).Cast<SelectSetVariable>().ToList().Select(n => n.Variable);
            foreach (var variable in setVariables)
            {
                AddVariableToListOfIgnoredVariables(variable);
            }
        }

        public override void ExplicitVisit(DeclareVariableElement node)
        {
            if (node is not ProcedureParameter && node.Value is not null)
            {
                AddVariableToListOfIgnoredVariables(node.VariableName);
            }
            //if (node is ProcedureParameter)
            //{
            //    AddVariableToListOfIgnoredVariables(node.VariableName);
            //}
        }
        public override void ExplicitVisit(ProcedureParameter node)
        {
            AddVariableToListOfIgnoredVariables(node.VariableName);
        }

        private void UpdateDictionariesWithExpression(VariableReference var, ScalarExpression expression, AssignmentKind assignment, TSqlFragment source)
        {
            if (var is null || expression is null) return;
//            if (expression is Literal && assignment == AssignmentKind.Equals
            // the expression can now be a literal expression 
            if (assignment == AssignmentKind.Equals
            )
            {
                var referencedVariables = DmTSqlFragmentVisitor.Visit(expression, new VariableReferenceVisitor());
                // if the scalar expression doesnt contain any variables its safe to consider it to be an initialisation expression
                if ( ! referencedVariables.Any())
                {
                    if (!variableAssignments.ContainsKey(var.Name))
                    {
                        variableAssignments.Add(var.Name, source);
                    }
                    else
                    {
                        AddVariableToListOfIgnoredVariables(var);
                    }
                }
                else
                {
                    AddVariableToListOfIgnoredVariables(var);
                }
            }
            else
            {
                AddVariableToListOfIgnoredVariables(var);
            }
        }

        private void AddVariableToListOfIgnoredVariables(VariableReference var)
        {
            if (var is null) return;
            if (!invalidVariableAssignments.ContainsKey(var.Name))
                invalidVariableAssignments.Add(var.Name,
                    new StringLiteral()); // doesnt matter what kind of literal we add here, we just need to record a usage which breaks our limited criteria
        }
        private void AddVariableToListOfIgnoredVariables(Identifier var)
        {
            if (var is null) return;
            if (!invalidVariableAssignments.ContainsKey(var.Value))
                invalidVariableAssignments.Add(var.Value,
                    new StringLiteral()); // doesnt matter what kind of literal we add here, we just need to record a usage which breaks our limited criteria
        }
    }
}
