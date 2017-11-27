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
using System.IO;
using System.Text.RegularExpressions;

namespace Cheburashka
{

    internal class VariableUsageVisitor : TSqlConcreteFragmentVisitor
    {
//        static Regex sqlVariableRegex = new Regex("(sql:variable(\"@\\w*?\"))");
        //        static Regex sqlVariableRegex = new Regex("variable");

        static Regex sqlVariableRegex = new Regex("sql:variable\\(\"(?<variableName>@\\w*?)\"\\)");

        public VariableUsageVisitor()
        {
            VariableReferences = new List<VariableReference>();
        }

        public IList<VariableReference> VariableReferences { get; private set; }

        public override void ExplicitVisit(VariableReference node)
        {
            VariableReferences.Add(node);
        }

        //TODO Implement this with a new class to handle variable references in code.
        public override void ExplicitVisit(FunctionCall node) {
            node.SQLModel_DebugPrint(@"C:\temp\p.out");
            if (node.CallTarget != null) {
                foreach (var p in node.Parameters) {
//                                        p.SQLModel_DebugPrint(@"C:\temp\p.out");
                    var matches = new List<VariableReference>();
                    if (p.ScriptTokenStream[p.FirstTokenIndex].TokenType == TSqlTokenType.AsciiStringLiteral) {
                        foreach (Match match in sqlVariableRegex.Matches(p.ScriptTokenStream[p.FirstTokenIndex].Text)) {
                                                        //match.Value.SQLModel_DebugPrint(@"C:\temp\p.out");
                                                        //match.Groups[1].Captures[0].Value.SQLModel_DebugPrint(@"C:\temp\p.out");
                            var variableName = match.Groups[1].Captures[0].Value;
                            var x = new VariableReference();
                            x.Name = variableName;
                            matches.Add(x);
                            VariableReferences.Add(x);
                        }
                    }
                }
            }
            node.AcceptChildren(this);
        }
    }
}
