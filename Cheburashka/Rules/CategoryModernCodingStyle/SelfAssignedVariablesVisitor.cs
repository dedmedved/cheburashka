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
        public IList<TSqlFragment> SqlFragments() { return AssignmentSetClauses.ToList(); }

        public override void ExplicitVisit(AssignmentSetClause node)
        {
            if (node.AssignmentKind == AssignmentKind.Equals)
            {
                bool hasBinaryExpression = false;
                BinaryExpression expr = null;
                if (node.NewValue is BinaryExpression value)
                {
                    hasBinaryExpression = true;
                    expr = value;
                }

                if (node.NewValue is ParenthesisExpression)
                {
                    hasBinaryExpression = SQLFragmentExtensions.ExtractFromParenthesisExpression(node.NewValue, out BinaryExpression expr2);
                    expr = expr2;
                }

                if (hasBinaryExpression)
                {
                    if (HasCommutativeOperator(expr) == true)
                    {
                        if ((node.Variable is not null && assignmentVariableMatchesFirstOrSecondExpressionElement(node, expr))
                            // This needs all kinds of checks to ensure the column is really the same on both sides
                            || (node.Column is not null && assignmentColumnMatchesFirstOrSecondExpressionElement(node, expr))
                           )
                        {
                            AssignmentSetClauses.Add(node);
                        }
                    }
                    else if (HasCommutativeOperator(expr) == false)
                    {
                        if ((node.Variable is not null && assignmentVariableMatchesFirstExpressionElement(node, expr))
                            // This needs all kinds of checks to ensure the column is really the same on both sides
                            || (node.Column is not null && assignmentColumnMatchesFirstExpressionElement(node, expr))
                           )
                        {
                            AssignmentSetClauses.Add(node);
                        }
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
                if (binaryExpression.FirstExpression is ColumnReferenceExpression columnReferenceExpression1)
                {
                    return AssignmentColumnMatchesFirstOrSecondExpressionElement(node, columnReferenceExpression1);
                }
                if (binaryExpression.SecondExpression is ColumnReferenceExpression columnReferenceExpression2)
                {
                    return AssignmentColumnMatchesFirstOrSecondExpressionElement(node, columnReferenceExpression2);
                }
                return false;

            }

            static bool assignmentColumnMatchesFirstExpressionElement(AssignmentSetClause node,
                BinaryExpression binaryExpression)
            {
                if (binaryExpression.FirstExpression is ColumnReferenceExpression columnReferenceExpression1)
                {
                    return AssignmentColumnMatchesFirstOrSecondExpressionElement(node, columnReferenceExpression1);
                }
                return false;
            }
        }

        private static bool AssignmentColumnMatchesFirstOrSecondExpressionElement(AssignmentSetClause node, ColumnReferenceExpression columnReferenceExpression2)
        {
            return SqlRuleUtils.DoColumnReferencesMatch(node.Column.MultiPartIdentifier, columnReferenceExpression2.MultiPartIdentifier);
        }



        public override void ExplicitVisit(SetVariableStatement node)
        {
            if (node.AssignmentKind == AssignmentKind.Equals) {
                var hasBinaryExpression = false;
                BinaryExpression expr = null;
                if ( node.Expression is BinaryExpression expression){
                    hasBinaryExpression = true;
                    expr = expression;
                }

                if (node.Expression is ParenthesisExpression) {

                    hasBinaryExpression = SQLFragmentExtensions.ExtractFromParenthesisExpression(node.Expression, out BinaryExpression expr2);
                    expr = expr2;
                }
                if (hasBinaryExpression)
                {
                    if (HasCommutativeOperator(expr) == false
                        && expr?.FirstExpression is VariableReference variableReference
                        && variableReference.SQLModel_StringCompareEqual(node.Variable)
                        )
                    {
                        AssignmentSetClauses.Add(node.Variable);
                    }
                    else if (HasCommutativeOperator(expr) == true                   
                        && ((expr?.FirstExpression is VariableReference variableReference1
                              && variableReference1.SQLModel_StringCompareEqual(node.Variable)
                              )
                           || (expr?.SecondExpression is VariableReference variableReference2
                              && variableReference2.SQLModel_StringCompareEqual(node.Variable)
                              )
                           )
                        )
                    {
                        AssignmentSetClauses.Add(node.Variable);
                    }
                }
            }
        }

        private static bool? HasCommutativeOperator(BinaryExpression binaryExpression)
        {
            return binaryExpression.BinaryExpressionType switch
            {
                BinaryExpressionType.Add or BinaryExpressionType.Multiply or BinaryExpressionType.BitwiseAnd or BinaryExpressionType.BitwiseOr or BinaryExpressionType.BitwiseXor => true,
                BinaryExpressionType.Subtract or BinaryExpressionType.Divide or BinaryExpressionType.Modulo => false,
                _ => null,
            };
        }
    }
}
