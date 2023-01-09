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

using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Cheburashka
{
    internal class BooleanExpressionEqualityFilterVisitor : TSqlConcreteFragmentVisitor
    {
        public bool ValidAndedEqualityBooleanExpression { get; set; } = true;
        private int NestedNotCount { get; set; } = 0;

        public override void ExplicitVisit(BooleanComparisonExpression node)
        {
            // NOT == is also != 
            // and 
            // NOT != is also ==
            if (NestedNotCount % 2 == 0 && node.ComparisonType != BooleanComparisonType.Equals)
            {
                ValidAndedEqualityBooleanExpression = false;
            }
            else if (NestedNotCount % 2 == 1 && node.ComparisonType != BooleanComparisonType.NotEqualToBrackets && node.ComparisonType != BooleanComparisonType.NotEqualToExclamation)
            {
                ValidAndedEqualityBooleanExpression = false;
            }
        }
        public override void ExplicitVisit(BooleanNotExpression node)
        {
            NestedNotCount++;
            if (node.Expression is BooleanComparisonExpression)
            {
                node.Expression.Accept(this);
            }
            else if (node.Expression is BooleanNotExpression)
            {
                node.Expression.Accept(this);
            }
            else if (node.Expression is BooleanParenthesisExpression)
            {
                node.Expression.Accept(this);
            }
            else if (node.Expression is BooleanBinaryExpression bexpr) {
                // disallow expressions like not not not ( a=1 and b=2)
                // not (( not (not (a=1 and b=2)) ))
                if ( NestedNotCount % 2 == 1 && bexpr.BinaryExpressionType is BooleanBinaryExpressionType.And)
                {
                    ValidAndedEqualityBooleanExpression = false;
                }
                else   {
                    node.Expression.Accept(this);
                }
            }
            else {
                ValidAndedEqualityBooleanExpression = false;
            }
            NestedNotCount--;
        }

        public override void ExplicitVisit(BooleanParenthesisExpression node)
        {
            node.AcceptChildren(this);
        }

        public override void ExplicitVisit(SubqueryComparisonPredicate node)
        {
            if (node.ComparisonType != BooleanComparisonType.Equals) { ValidAndedEqualityBooleanExpression = false; }
        }
        public override void ExplicitVisit(BooleanBinaryExpression node)
        {
            if (node.BinaryExpressionType == BooleanBinaryExpressionType.And)
            {
                node.AcceptChildren(this);
            }
            else
            {
                ValidAndedEqualityBooleanExpression = false;
            }
        }

      
        public override void ExplicitVisit(BooleanExpressionSnippet node) { ValidAndedEqualityBooleanExpression = false; } //??
        public override void ExplicitVisit(BooleanIsNullExpression node) { ValidAndedEqualityBooleanExpression = false; }
        public override void ExplicitVisit(BooleanTernaryExpression node) { ValidAndedEqualityBooleanExpression = false; }
        public override void ExplicitVisit(EventDeclarationCompareFunctionParameter node) { ValidAndedEqualityBooleanExpression = false; }
        public override void ExplicitVisit(ExistsPredicate  node) { ValidAndedEqualityBooleanExpression = false; }
        public override void ExplicitVisit(FullTextPredicate node) { ValidAndedEqualityBooleanExpression = false; }
        public override void ExplicitVisit(GraphMatchCompositeExpression  node) { ValidAndedEqualityBooleanExpression = false; }
        public override void ExplicitVisit(GraphMatchExpression  node) { ValidAndedEqualityBooleanExpression = false; }
        public override void ExplicitVisit(GraphMatchLastNodePredicate  node) { ValidAndedEqualityBooleanExpression = false; }
        public override void ExplicitVisit(GraphMatchNodeExpression  node) { ValidAndedEqualityBooleanExpression = false; }
        public override void ExplicitVisit(GraphMatchPredicate  node) { ValidAndedEqualityBooleanExpression = false; }
        public override void ExplicitVisit(GraphMatchRecursivePredicate  node) { ValidAndedEqualityBooleanExpression = false; }
        public override void ExplicitVisit(GraphRecursiveMatchQuantifier  node) { ValidAndedEqualityBooleanExpression = false; }
        public override void ExplicitVisit(InPredicate node) { ValidAndedEqualityBooleanExpression = false; }
        public override void ExplicitVisit(LikePredicate node) { ValidAndedEqualityBooleanExpression = false; }
        public override void ExplicitVisit(TSEqualCall  node) { ValidAndedEqualityBooleanExpression = false; }
        public override void ExplicitVisit(UpdateCall  node) { ValidAndedEqualityBooleanExpression = false; }
    }
}