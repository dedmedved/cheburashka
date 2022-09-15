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

namespace Cheburashka
{
    internal class UnnecessaryParenthesisVisitor : TSqlConcreteFragmentVisitor, ICheburashkaTSqlConcreteFragmentVisitor
    {
        public UnnecessaryParenthesisVisitor()
        {
            UnnecessaryBrackets = new List<TSqlFragment>();
        }

        public IList<TSqlFragment> UnnecessaryBrackets { get; }
        public IList<TSqlFragment> SqlFragments() { return UnnecessaryBrackets; }
        public override void ExplicitVisit(ParenthesisExpression node)
        {
            if (node.Expression is ParenthesisExpression
                )
            {
                UnnecessaryBrackets.Add(node);
            }
            node.AcceptChildren(this);
        }
        public override void ExplicitVisit(BooleanParenthesisExpression node)
        {
            if (node.Expression is ExistsPredicate
                || node.Expression is BooleanParenthesisExpression
                || node.Expression is BooleanComparisonExpression
            )
            {
                UnnecessaryBrackets.Add(node);
            }
            node.AcceptChildren(this);
        }
        
        public override void ExplicitVisit(AssignmentSetClause node)
        {
            if (node.NewValue is ParenthesisExpression)
            {
                UnnecessaryBrackets.Add(node.NewValue);
            }
            node.AcceptChildren(this);
        }
        public override void ExplicitVisit(SetVariableStatement node)
        {
            if (node.Expression is ParenthesisExpression)
            {
                UnnecessaryBrackets.Add(node.Expression);
            }
            node.AcceptChildren(this);
        }
        public override void ExplicitVisit(DeclareVariableElement node)
        {
            if (node.Value is ParenthesisExpression)
            {
                UnnecessaryBrackets.Add(node.Value);
            }
            node.AcceptChildren(this);
        }
        public override void ExplicitVisit(WhileStatement node)
        {
            if (node.Predicate is BooleanParenthesisExpression)
            {
                UnnecessaryBrackets.Add(node.Predicate);
            }
            node.AcceptChildren(this);
        }
        public override void ExplicitVisit(IfStatement node)
        {
            if (node.Predicate is BooleanParenthesisExpression)
            {
                UnnecessaryBrackets.Add(node.Predicate);
            }
            node.AcceptChildren(this);
        }
        public override void ExplicitVisit(QualifiedJoin node)
        {
            if (node.SearchCondition is BooleanParenthesisExpression)
            {
                UnnecessaryBrackets.Add(node.SearchCondition);
            }
            node.AcceptChildren(this);
        }
        public override void ExplicitVisit(WhereClause node)
        {
            if (node.SearchCondition is BooleanParenthesisExpression)
            {
                UnnecessaryBrackets.Add(node.SearchCondition);
            }
            node.AcceptChildren(this);
        }
        public override void ExplicitVisit(HavingClause node)
        {
            if (node.SearchCondition is BooleanParenthesisExpression)
            {
                UnnecessaryBrackets.Add(node.SearchCondition);
            }
            node.AcceptChildren(this);
        }
        public override void ExplicitVisit(MergeActionClause node)
        {
            if (node.SearchCondition is BooleanParenthesisExpression)
            {
                UnnecessaryBrackets.Add(node.SearchCondition);
            }
            node.AcceptChildren(this);
        }
        public override void ExplicitVisit(MergeSpecification node)
        {
            if (node.SearchCondition is BooleanParenthesisExpression)
            {
                UnnecessaryBrackets.Add(node.SearchCondition);
            }
            node.AcceptChildren(this);
        }
        public override void ExplicitVisit(QueryParenthesisExpression node)
        {
            if (node.QueryExpression is QueryParenthesisExpression)
            {
                UnnecessaryBrackets.Add(node);
            }
            node.AcceptChildren(this);
        }
        public override void ExplicitVisit(ScalarSubquery node)
        {
            if (node.QueryExpression is QueryParenthesisExpression)
            {
                UnnecessaryBrackets.Add(node);
            }
            node.AcceptChildren(this);
        }
    }
}
