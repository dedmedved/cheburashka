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
    internal class SchemaNameAcceptingProceduresVisitor : TSqlConcreteFragmentVisitor
    {
        public SchemaNameAcceptingProceduresVisitor()
        {
            OnePartNames = new List<ExecutableProcedureReference>();
        }

        public IList<ExecutableProcedureReference> OnePartNames { get; }

        public override void ExplicitVisit(ExecutableProcedureReference node)
        {
            if (   node.ProcedureReference.ProcedureReference.Name.BaseIdentifier.Value.SQLModel_StringCompareEqual("sp_depends"              )
                || node.ProcedureReference.ProcedureReference.Name.BaseIdentifier.Value.SQLModel_StringCompareEqual("sp_help"                 )
                || node.ProcedureReference.ProcedureReference.Name.BaseIdentifier.Value.SQLModel_StringCompareEqual("sp_helpconstraint"       )
                || node.ProcedureReference.ProcedureReference.Name.BaseIdentifier.Value.SQLModel_StringCompareEqual("sp_helpindex"            )
                || node.ProcedureReference.ProcedureReference.Name.BaseIdentifier.Value.SQLModel_StringCompareEqual("sp_helpstats"            )
                || node.ProcedureReference.ProcedureReference.Name.BaseIdentifier.Value.SQLModel_StringCompareEqual("sp_helptext"             )
                || node.ProcedureReference.ProcedureReference.Name.BaseIdentifier.Value.SQLModel_StringCompareEqual("sp_helptrigger"          )
                || node.ProcedureReference.ProcedureReference.Name.BaseIdentifier.Value.SQLModel_StringCompareEqual("sp_recompile"            )
                || node.ProcedureReference.ProcedureReference.Name.BaseIdentifier.Value.SQLModel_StringCompareEqual("sp_refreshview"          )
                || node.ProcedureReference.ProcedureReference.Name.BaseIdentifier.Value.SQLModel_StringCompareEqual("sp_procoption"           )
                   // this one also has problems we might never resolve
                || node.ProcedureReference.ProcedureReference.Name.BaseIdentifier.Value.SQLModel_StringCompareEqual("sp_rename"               )
                || node.ProcedureReference.ProcedureReference.Name.BaseIdentifier.Value.SQLModel_StringCompareEqual("sp_sequence_get_range"   )
                || node.ProcedureReference.ProcedureReference.Name.BaseIdentifier.Value.SQLModel_StringCompareEqual("sp_settriggerorder"      )
                || node.ProcedureReference.ProcedureReference.Name.BaseIdentifier.Value.SQLModel_StringCompareEqual("sp_tableoption"          )
                || node.ProcedureReference.ProcedureReference.Name.BaseIdentifier.Value.SQLModel_StringCompareEqual("sp_autostats"            )

                // this one also has problems we might never resolve
                || node.ProcedureReference.ProcedureReference.Name.BaseIdentifier.Value.SQLModel_StringCompareEqual("sp_indexoption")

               //-- t0o tricky to do
               //                EXEC sp_bindrule 'today', 'HumanResources.Employee.HireDate';
               //            EXEC sp_bindefault 'today', 'HumanResources.Employee.HireDate';

               )
            {
                if (node.Parameters[0].ParameterValue is StringLiteral objName)
                {
                    if (objName.Value.EmptySchemaNameInLiteral()) { OnePartNames.Add(node); }
                }
            }
        }
    }
}
