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
    internal class VariableLengthDataSpecificationsVisitor : TSqlConcreteFragmentVisitor, ICheburashkaTSqlConcreteFragmentVisitor
    {
        public VariableLengthDataSpecificationsVisitor()
        {
            EmptyvariableLengthDataSpecifications = new List<SqlDataTypeReference>();
        }

        public IList<SqlDataTypeReference> EmptyvariableLengthDataSpecifications { get; }
        public IList<TSqlFragment> SqlFragments() { return EmptyvariableLengthDataSpecifications.Cast<TSqlFragment>().ToList(); }
        public override void ExplicitVisit(ConvertCall node)
        {
            if (node.DataType is SqlDataTypeReference sqlDataTypeReference)
            {
                HandleReference(sqlDataTypeReference);
            }
        }
        public override void ExplicitVisit(TryConvertCall node)
        {
            if (node.DataType is SqlDataTypeReference sqlDataTypeReference)
            {
                HandleReference(sqlDataTypeReference);
            }
        }
        public override void ExplicitVisit(CastCall node)
        {
            if (node.DataType is SqlDataTypeReference sqlDataTypeReference)
            {
                HandleReference(sqlDataTypeReference);
            }
        }
        public override void ExplicitVisit(TryCastCall node)
        {
            if (node.DataType is SqlDataTypeReference sqlDataTypeReference)
            {
                HandleReference(sqlDataTypeReference);
            }
        }
        public override void ExplicitVisit(DeclareVariableElement node)
        {
            if (node.DataType is SqlDataTypeReference sqlDataTypeReference)
            {
                HandleReference(sqlDataTypeReference);
            }
        }
        void HandleReference(SqlDataTypeReference node)
        {
            if ((node.Parameters?.Count ?? 0) == 0 )
            {
                switch (node.SqlDataTypeOption)
                {
                    case SqlDataTypeOption.Binary:
                    case SqlDataTypeOption.Char:
                    case SqlDataTypeOption.Decimal:
                    case SqlDataTypeOption.Float:
                    case SqlDataTypeOption.NChar:
                    case SqlDataTypeOption.Numeric:
                    case SqlDataTypeOption.NVarChar:
                    case SqlDataTypeOption.VarBinary:
                    case SqlDataTypeOption.VarChar:
                        EmptyvariableLengthDataSpecifications.Add(node);
                        break;

                    case SqlDataTypeOption.Bit:
                    case SqlDataTypeOption.Cursor:
                    case SqlDataTypeOption.Image:
                    case SqlDataTypeOption.Text:
                    case SqlDataTypeOption.NText:
                    case SqlDataTypeOption.DateTime:
                    case SqlDataTypeOption.DateTime2:           // yeah they are variable but lets not sweat it for these
                    case SqlDataTypeOption.DateTimeOffset:      // yeah they are variable but lets not sweat it for these
                    case SqlDataTypeOption.Int:
                    case SqlDataTypeOption.Money:
                    case SqlDataTypeOption.None:
                    case SqlDataTypeOption.Real:
                    case SqlDataTypeOption.SmallDateTime:
                    case SqlDataTypeOption.SmallInt:
                    case SqlDataTypeOption.SmallMoney:
                    case SqlDataTypeOption.Sql_Variant:
                    case SqlDataTypeOption.Table:
                    case SqlDataTypeOption.Time:
                    case SqlDataTypeOption.Timestamp:
                    case SqlDataTypeOption.TinyInt:
                    case SqlDataTypeOption.UniqueIdentifier:
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
