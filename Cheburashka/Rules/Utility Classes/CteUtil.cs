﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

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
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System.Collections.Generic;


namespace Cheburashka
{
    public class CteUtil : SqlObjectFragment
    {
        public CteUtil()
        {
            ExpressionNames = new List<Identifier>();
            ExpressionNamesAsStrings = new List<string>();
        }
        public CteUtil(int firstTokenIndex
                      , int lastTokenIndex
                      , int startOffset
                      , int fragmentLength
                      )
            : base(firstTokenIndex, lastTokenIndex, startOffset, fragmentLength)
        {
            ExpressionNames = new List<Identifier>();
            ExpressionNamesAsStrings = new List<string>();
        }


        public List<Identifier> ExpressionNames { get; }
        public List<string> ExpressionNamesAsStrings { get; }


        public void Add(Identifier identifier)
        {
            ExpressionNames.Add(identifier);
            ExpressionNamesAsStrings.Add(identifier.Value);
        }


    }
}