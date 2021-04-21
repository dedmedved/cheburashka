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
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System.Collections.ObjectModel;

namespace Cheburashka
{
    public class SQLExpressionDependency
    {
        private readonly List<VariableReference> _dependencies;

        public SQLExpressionDependency()
        {
            Variable = new VariableReference();
            _dependencies = new List<VariableReference>();
        }
        public SQLExpressionDependency(VariableReference variable, TSqlFragment context = null, string contextClass = null)
        {
            Variable = variable ?? throw new ArgumentNullException(nameof(variable));
            _dependencies = new List<VariableReference>();
            Context = context;
            ContextClass = contextClass;
        }


        public VariableReference Variable { get; set; }
        public TSqlFragment Context { get; set; }
        public string ContextClass { get; set; }

        public ReadOnlyCollection<VariableReference> Dependencies =>
            //set { _dependencies = value; } // not used - yet - remove
            _dependencies.AsReadOnly();


        public void AddDependency(VariableReference variable)
        {
            if (variable == null) throw new ArgumentNullException(nameof(variable));
            _dependencies.Add(variable);
        }
        public void AddDependencies(IList<VariableReference> variables)
        {
            _dependencies.AddRange(variables);
        }



    }
}

