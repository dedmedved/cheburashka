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

    internal class TempTableUpdateVisitor : TSqlConcreteFragmentVisitor, ICheburashkaTSqlConcreteFragmentVisitor
    {
        public TempTableUpdateVisitor()
        {
            TempTableNames = new List<SchemaObjectName>();
        }

        public IList<SchemaObjectName> TempTableNames { get; }
        public IList<TSqlFragment> SqlFragments() { return TempTableNames.Cast<TSqlFragment>().ToList(); }

        public override void ExplicitVisit(UpdateSpecification node)
        {
            if (node.Target is NamedTableReference namedTableReference)
            {
                if (namedTableReference.SchemaObject.IsLocalTempTableName())
                {
                    TempTableNames.Add(namedTableReference.SchemaObject);
                }
                else // check that if the target is and alias it isn't an alias to a temp table ( or vice versa)
                {
                    List<(SchemaObjectName, Identifier)> schemaLikeTableReferences = SqlGatherQuery.GetSpecificationSchemaTableReferences(node.FromClause.TableReferences);
                    var tempTablePairExists = schemaLikeTableReferences.Exists( n=>n.Item1.IsLocalTempTableName() && SqlComparer.SQLModel_StringCompareEqual(namedTableReference.SchemaObject.BaseIdentifier.Value, n.Item2.Value));
                    if (tempTablePairExists ) {
                        var tempTablePair = schemaLikeTableReferences.First(n => n.Item1.IsLocalTempTableName() && SqlComparer.SQLModel_StringCompareEqual(namedTableReference.SchemaObject.BaseIdentifier.Value, n.Item2.Value));
                        TempTableNames.Add(tempTablePair.Item1);
                    }
                }
            }
        }
    }
}