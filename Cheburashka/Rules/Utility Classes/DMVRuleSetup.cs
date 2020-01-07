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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Dac;
using Microsoft.SqlServer.Dac.CodeAnalysis;
using Microsoft.SqlServer.Dac.Model;
using Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Cheburashka
{
    public static class DMVRuleSetup
    {
//        public static void RuleSetup(SqlRuleExecutionContext context, out List<SqlRuleProblem> problems, out SqlSchemaModel sqlSchemaModel, out TSqlObject sqlElement, out TSqlFragment sqlFragment)
        public static void RuleSetup(SqlRuleExecutionContext context, out List<SqlRuleProblem> problems, out TSqlModel model, out TSqlFragment sqlFragment, out TSqlObject modelElement)
        {
            //DMVSettings.LoadSettings();
            // Get Model collation 
            SqlComparer.Comparer = context.SchemaModel.CollationComparer;

            problems     = new List<SqlRuleProblem>();
            model        = context.SchemaModel;
            sqlFragment  = context.ScriptFragment;
            modelElement = context.ModelElement;

        }

        //public static void RefreshDDLCache(ModelStore sqlSchemaModel)
        //{
        //    //DMVSettings.RefreshColumnCache(sqlSchemaModel);
        //    //DMVSettings.RefreshConstraintsAndIndexesCache(sqlSchemaModel);
        //}

        public static void GetLocalObjectNameParts(TSqlObject sqlElement, out string objectSchema, out string objectTable)
        {
            objectSchema = sqlElement.Name.HasName ? sqlElement.Name.Parts[0] : "";
            objectTable  = sqlElement.Name.HasName ? sqlElement.Name.Parts[1] : "";
        }

    }
}
