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
    internal class NonDeterministicSystemFunctionVisitor : TSqlConcreteFragmentVisitor, ICheburashkaTSqlConcreteFragmentVisitor
    {
        public NonDeterministicSystemFunctionVisitor()
        {
            NonDeterministicSystemFunctions = new List<FunctionCall>();
        }

        public List<FunctionCall> NonDeterministicSystemFunctions { get; }
        public IList<TSqlFragment> SqlFragments() { return NonDeterministicSystemFunctions.Cast<TSqlFragment>().ToList(); }
        public override void ExplicitVisit(FunctionCall node)
        {
            // This list is a bit hap-hazard
            // try to catch stuff that might change from line to line
            // in the code, and not per-execution
            // error-handling code is the most likely to be wrongly identified
            // as a constant initialisation
            if ( node.FunctionName.Value.SQLModel_StringCompareEqual("ROWCOUNT")
              || node.FunctionName.Value.SQLModel_StringCompareEqual("ERROR")
              || node.FunctionName.Value.SQLModel_StringCompareEqual("TRANCOUNT")
              || node.FunctionName.Value.SQLModel_StringCompareEqual("IDENTITY")
              || node.FunctionName.Value.SQLModel_StringCompareEqual("ERROR_NUMBER")
              || node.FunctionName.Value.SQLModel_StringCompareEqual("ERROR_MESSAGE")
              || node.FunctionName.Value.SQLModel_StringCompareEqual("ERROR_PROCEDURE")
              || node.FunctionName.Value.SQLModel_StringCompareEqual("ERROR_SEVERITY")
              || node.FunctionName.Value.SQLModel_StringCompareEqual("ERROR_STATE")
              || node.FunctionName.Value.SQLModel_StringCompareEqual("ERROR_LINE")
              || node.FunctionName.Value.SQLModel_StringCompareEqual("CURSOR_ROWS")
              || node.FunctionName.Value.SQLModel_StringCompareEqual("FETCH_STATUS")
              || node.FunctionName.Value.SQLModel_StringCompareEqual("CURSOR_STATUS")
            )
            {
                NonDeterministicSystemFunctions.Add(node);
            }
        }
    }
}
