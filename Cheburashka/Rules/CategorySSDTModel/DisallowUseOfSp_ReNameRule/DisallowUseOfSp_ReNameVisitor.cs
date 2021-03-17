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
    internal class DisallowUseOfSp_ReNameVisitor : TSqlConcreteFragmentVisitor
    {
        public DisallowUseOfSp_ReNameVisitor()
        {
            ExecuteSpecifications = new List<ExecuteSpecification>();
        }

        public IList<ExecuteSpecification> ExecuteSpecifications { get; }

        public override void ExplicitVisit(ExecuteSpecification node)
        {
        // TODO - look inside dynamic sql strings
        // TODO - check for simple variable usage where procedure reference is a variable
            if (node.ExecutableEntity is ExecutableProcedureReference &&
                    ((ExecutableProcedureReference)node.ExecutableEntity).ProcedureReference != null)
            {
                TSqlFragment pr = ((ExecutableProcedureReference)node.ExecutableEntity).ProcedureReference;
                string spName = pr.ScriptTokenStream[pr.LastTokenIndex].Text;
                //TSqlParserToken name = pr.ScriptTokenStream[pr.LastTokenIndex];
                if (SqlComparer.SQLModel_StringCompareEqual(spName,"sp_rename")) // this has to be in all lowercase in sensitive collations
                {
                    ExecuteSpecifications.Add(node);
                }
            }
        }
    }
}
