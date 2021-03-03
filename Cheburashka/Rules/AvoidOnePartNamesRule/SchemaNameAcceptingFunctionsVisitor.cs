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
using System;
using System.Text.RegularExpressions;

namespace Cheburashka
{
    internal class SchemaNameAcceptingFunctionsVisitor : TSqlConcreteFragmentVisitor
    {
        public SchemaNameAcceptingFunctionsVisitor()
        {
            OnePartNames = new List<FunctionCall>();
        }

        public IList<FunctionCall> OnePartNames { get; }

        public override void ExplicitVisit(FunctionCall node)
        {
            if (   node.FunctionName.Value.SQLModel_StringCompareEqual("object_id")
                || node.FunctionName.Value.SQLModel_StringCompareEqual("index_col")
                || node.FunctionName.Value.SQLModel_StringCompareEqual("type_id")
               )
            {
                //node.SQLModel_DebugPrint(@"c:\temp\object_id.txt");
                if (node.Parameters[0] is StringLiteral objName)
                {
                    //objName.SQLModel_DebugPrint(@"c:\temp\object_id.txt");
                    var sLit = objName.Value;
                    // only continue with this check if we're not calling type_id against a built-in datatype
                    if ((node.FunctionName.Value.SQLModel_StringCompareEqual("type_id")
                         && !SqlRuleUtils.IsBuiltinDataTypes(sLit)
                         )
                         || !node.FunctionName.Value.SQLModel_StringCompareEqual("type_id")
                        )
                    {
                        if (objName.Value.EmptySchemaNameInLiteral()) { OnePartNames.Add(node); }
                    }
                }
            }
        }
    }
}
