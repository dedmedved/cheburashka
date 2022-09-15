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

    internal class SelfAssignedVariablesVisitor : TSqlConcreteFragmentVisitor, ICheburashkaTSqlConcreteFragmentVisitor
    {

        public SelfAssignedVariablesVisitor()
        {
            AssignmentSetClauses = new List<TSqlFragment>();
        }

        public List<TSqlFragment> AssignmentSetClauses { get; }
        public IList<TSqlFragment> SqlFragments() { return AssignmentSetClauses.Cast<TSqlFragment>().ToList(); }
        public override void ExplicitVisit(AssignmentSetClause node)
        {
            if (node.AssignmentKind == AssignmentKind.Equals
                && node.NewValue is BinaryExpression binaryExpression)
            {
                if (HasCommutativeOperator(binaryExpression) == true)
                {
                    if (  ( node.Variable is not null && assignmentVariableMatchesFirstOrSecondExpressionElement(node, binaryExpression)) 
                        // This needs all kinds of checks to ensure the column is really the same on both sides
                        || (node.Column is not null && assignmentColumnMatchesFirstOrSecondExpressionElement(node, binaryExpression))
                        )
                    {
                        AssignmentSetClauses.Add(node);
                    }
                }
                else if (HasCommutativeOperator(binaryExpression) == false)
                {
                    if (  ( node.Variable is not null && assignmentVariableMatchesFirstExpressionElement(node, binaryExpression))
                        // This needs all kinds of checks to ensure the column is really the same on both sides
                         || (node.Column is not null && assignmentColumnMatchesFirstExpressionElement(node, binaryExpression))
                       )
                    {
                        AssignmentSetClauses.Add(node);
                    }
                }
            }

            static bool assignmentVariableMatchesFirstOrSecondExpressionElement(AssignmentSetClause node, BinaryExpression binaryExpression)
            {
                return (binaryExpression.FirstExpression is VariableReference variableReference1
                                             && variableReference1.SQLModel_StringCompareEqual(node.Variable)
                                             )
                                           || (binaryExpression.SecondExpression is VariableReference variableReference2
                                             && variableReference2.SQLModel_StringCompareEqual(node.Variable)
                                             );
            }
            static bool assignmentVariableMatchesFirstExpressionElement(AssignmentSetClause node, BinaryExpression binaryExpression)
            {
                return binaryExpression.FirstExpression is VariableReference variableReference1
                                             && variableReference1.SQLModel_StringCompareEqual(node.Variable)
                                             ;
            }

            static bool assignmentColumnMatchesFirstOrSecondExpressionElement(AssignmentSetClause node, BinaryExpression binaryExpression)
            {
                return (binaryExpression.FirstExpression is ColumnReferenceExpression columnReferenceExpression1
                                            && node.Column.MultiPartIdentifier.Identifiers.Last().SQLModel_StringCompareEqual(columnReferenceExpression1.MultiPartIdentifier.Identifiers.Last())
                                              )
                                           || (binaryExpression.SecondExpression is ColumnReferenceExpression columnReferenceExpression2
                                               && node.Column.MultiPartIdentifier.Identifiers.Last().SQLModel_StringCompareEqual(columnReferenceExpression2.MultiPartIdentifier.Identifiers.Last()))
                                             ;
            }
            static bool assignmentColumnMatchesFirstExpressionElement(AssignmentSetClause node, BinaryExpression binaryExpression)
            {
                return binaryExpression.FirstExpression is ColumnReferenceExpression columnReferenceExpression1
                                            && node.Column.MultiPartIdentifier.Identifiers.Last().SQLModel_StringCompareEqual(columnReferenceExpression1.MultiPartIdentifier.Identifiers.Last())
                                             ;
            }
        }
        public override void ExplicitVisit(SetVariableStatement node)
        {
            if (node.AssignmentKind == AssignmentKind.Equals
                && node.Expression is BinaryExpression binaryExpression 
                && node.Variable is not null
                )
            {
                if (HasCommutativeOperator(binaryExpression) == false
                    && binaryExpression.FirstExpression is VariableReference variableReference
                    && variableReference.SQLModel_StringCompareEqual(node.Variable)
                    )
                {
                    AssignmentSetClauses.Add(node.Variable);
                }
                else if (HasCommutativeOperator(binaryExpression) == true                   
                    && ((binaryExpression.FirstExpression is VariableReference variableReference1
                          && variableReference1.SQLModel_StringCompareEqual(node.Variable)
                          )
                       || (binaryExpression.SecondExpression is VariableReference variableReference2
                          && variableReference2.SQLModel_StringCompareEqual(node.Variable)
                          )
                       )
                    )
                {
                    AssignmentSetClauses.Add(node.Variable);
                }
            }
        }

        private static bool? HasCommutativeOperator(BinaryExpression binaryExpression)
        {
            if (binaryExpression.BinaryExpressionType is BinaryExpressionType.Add || binaryExpression.BinaryExpressionType is BinaryExpressionType.Multiply )
                return true;
            if (binaryExpression.BinaryExpressionType is BinaryExpressionType.Subtract || binaryExpression.BinaryExpressionType is BinaryExpressionType.Divide )
                return false;
            return null;
        }
    }
}

