﻿//------------------------------------------------------------------------------
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
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Cheburashka
{
    internal class EnforceNamedConstraintVisitor: TSqlConcreteFragmentVisitor
    {
        private List<ConstraintDefinition > _constraints;
        public EnforceNamedConstraintVisitor()
        {
            _constraints = new List<ConstraintDefinition>();
        }

        public List<ConstraintDefinition> Constraints
        {
            get { return _constraints; }
        }
        public override void ExplicitVisit(CheckConstraintDefinition node)
        {
            if (node.ConstraintIdentifier == null || String.IsNullOrEmpty(node.ConstraintIdentifier.Value))
            {
                _constraints.Add(node);
            }
        }
        public override void ExplicitVisit(UniqueConstraintDefinition node)
        {
            if (node.ConstraintIdentifier == null || String.IsNullOrEmpty(node.ConstraintIdentifier.Value))
            {
                _constraints.Add(node);
            }
        }
        public override void ExplicitVisit(DefaultConstraintDefinition node)
        {
            if (node.ConstraintIdentifier == null || String.IsNullOrEmpty(node.ConstraintIdentifier.Value))
            {
                _constraints.Add(node);
            }
        }
        public override void ExplicitVisit(ForeignKeyConstraintDefinition node)
        {
            if (node.ConstraintIdentifier == null || String.IsNullOrEmpty(node.ConstraintIdentifier.Value))
            {
                _constraints.Add(node);
            }
        }
        //public override void ExplicitVisit(NullableConstraintDefinition node)
        //{
        //    _constraints.Add(node);
        //}

    }
}