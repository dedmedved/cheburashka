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
    internal class SelectIntoColumnExpressionVisitor : TSqlConcreteFragmentVisitor, ICheburashkaTSqlConcreteFragmentVisitor
    {
        public SelectIntoColumnExpressionVisitor()
        {
            Objects = new List<PrimaryExpression>();
        }
        public List<PrimaryExpression> Objects { get; }
        public IList<TSqlFragment> SqlFragments() { return Objects.Cast<TSqlFragment>().ToList(); }
        private void HandlePrimaryExpression(PrimaryExpression node)
        {
            if (node.Collation is not null && !string.Equals(node.Collation.Value, "database_default", System.StringComparison.OrdinalIgnoreCase))
                Objects.Add(node);
        }
        public override void ExplicitVisit(SelectScalarExpression node)
        {
            if ( node.Expression is not null )
                node.AcceptChildren(this);
        }
        public override void ExplicitVisit(AtTimeZoneCall node) => HandlePrimaryExpression(node);
        //public override void ExplicitVisit(CaseExpression node)
        //{
        //    if (node.Collation is not null && !string.Equals(node.Collation.Value, "database_default", System.StringComparison.OrdinalIgnoreCase))
        //        Objects.Add(node);
        //}
        public override void ExplicitVisit(SearchedCaseExpression node) => HandlePrimaryExpression(node);
        public override void ExplicitVisit(SimpleCaseExpression node) => HandlePrimaryExpression(node);
        public override void ExplicitVisit(CastCall node) => HandlePrimaryExpression(node);
        public override void ExplicitVisit(CoalesceExpression node) => HandlePrimaryExpression(node);
        public override void ExplicitVisit(ColumnReferenceExpression node) => HandlePrimaryExpression(node);
        public override void ExplicitVisit(ConvertCall node) => HandlePrimaryExpression(node);
        public override void ExplicitVisit(FunctionCall node) => HandlePrimaryExpression(node);
        public override void ExplicitVisit(IIfCall node) => HandlePrimaryExpression(node);
        public override void ExplicitVisit(LeftFunctionCall node) => HandlePrimaryExpression(node);
        public override void ExplicitVisit(NextValueForExpression node) => HandlePrimaryExpression(node);
        public override void ExplicitVisit(NullIfExpression node) => HandlePrimaryExpression(node);
        public override void ExplicitVisit(OdbcFunctionCall node) => HandlePrimaryExpression(node);
        public override void ExplicitVisit(ParameterlessCall node) => HandlePrimaryExpression(node);
        public override void ExplicitVisit(ParenthesisExpression node) => HandlePrimaryExpression(node);
        public override void ExplicitVisit(ParseCall node) => HandlePrimaryExpression(node);
        public override void ExplicitVisit(PartitionFunctionCall node) => HandlePrimaryExpression(node);
        public override void ExplicitVisit(RightFunctionCall node) => HandlePrimaryExpression(node);
        public override void ExplicitVisit(ScalarSubquery node) => HandlePrimaryExpression(node);
        public override void ExplicitVisit(TryCastCall node) => HandlePrimaryExpression(node);
        public override void ExplicitVisit(TryConvertCall node) => HandlePrimaryExpression(node);
        public override void ExplicitVisit(TryParseCall node) => HandlePrimaryExpression(node);
        public override void ExplicitVisit(UserDefinedTypePropertyAccess node) => HandlePrimaryExpression(node);
        //public override void ExplicitVisit(ValueExpression node)
        //{
        //    if (node.Collation is not null && !string.Equals(node.Collation.Value, "database_default", System.StringComparison.OrdinalIgnoreCase))
        //        Objects.Add(node);
        //}
        public override void ExplicitVisit(GlobalVariableExpression node) => HandlePrimaryExpression(node);
        //public override void ExplicitVisit(Literal node)
        //{
        //    if (node.Collation is not null && !string.Equals(node.Collation.Value, "database_default", System.StringComparison.OrdinalIgnoreCase))
        //        Objects.Add(node);
        //}
        public override void ExplicitVisit(BinaryLiteral node) => HandlePrimaryExpression(node);
        public override void ExplicitVisit(DefaultLiteral node) => HandlePrimaryExpression(node);
        public override void ExplicitVisit(IdentifierLiteral node) => HandlePrimaryExpression(node);
        public override void ExplicitVisit(IntegerLiteral node) => HandlePrimaryExpression(node);
        public override void ExplicitVisit(MaxLiteral node) => HandlePrimaryExpression(node);
        public override void ExplicitVisit(MoneyLiteral node) => HandlePrimaryExpression(node);
        public override void ExplicitVisit(NullLiteral node) => HandlePrimaryExpression(node);
        public override void ExplicitVisit(NumericLiteral node) => HandlePrimaryExpression(node);
        public override void ExplicitVisit(OdbcLiteral node) => HandlePrimaryExpression(node);
        public override void ExplicitVisit(RealLiteral node) => HandlePrimaryExpression(node);
        public override void ExplicitVisit(StringLiteral node) => HandlePrimaryExpression(node);
    }
}