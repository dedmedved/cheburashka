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
using System.Linq;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Cheburashka
{
    internal class AvoidOnePartNameVisitor : TSqlConcreteFragmentVisitor
    {
        public AvoidOnePartNameVisitor()
        {
            OnePartNames = new List<SchemaObjectName>();
        }

        public IList<SchemaObjectName> OnePartNames { get; }

        public override void ExplicitVisit(SchemaObjectName node)
        {
            List<Identifier> tokens = node.Identifiers.Reverse().ToList();
            Identifier tableName = node.BaseIdentifier;
            string name = tableName.Value;

            bool noSchemaInMultiPartName = false;
            if (tokens.Count > 1)
            {
                string schema = tokens.ToArray()[1].Value;
                if (string.IsNullOrEmpty(schema)) {
                    noSchemaInMultiPartName = true;
                }
            }
            else
            {
                noSchemaInMultiPartName = true;
            }
            // If name has no schema and isn't a temp table name, capture it.
            // Table variables must match something else.
            if (noSchemaInMultiPartName)
            {
                if (!name.StartsWith("#"))
                {
                    OnePartNames.Add(node);
                }
            }
        }
    }
}