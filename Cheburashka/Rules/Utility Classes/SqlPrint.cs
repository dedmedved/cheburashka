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

using System.IO;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Cheburashka
{
    public static class SqlPrint
    {
        public static void SQLModel_DebugPrint(this TSqlFragment element, string filespec, bool overwrite = false)
        {
            if (overwrite)
            {
                using StreamWriter w = File.CreateText(filespec);
                w.WriteLine("called");
                for (int i = element.FirstTokenIndex; i <= element.LastTokenIndex; i++)
                {
                    w.Write("[" + element.ScriptTokenStream[i].TokenType + "] " + element.ScriptTokenStream[i].Text + " ");
                }
                w.WriteLine();
            }
            else
            {
                using StreamWriter w = File.AppendText(filespec);
                w.WriteLine("called");
                for (int i = element.FirstTokenIndex; i <= element.LastTokenIndex; i++)
                {
                    w.Write("[" + element.ScriptTokenStream[i].TokenType + "] " + element.ScriptTokenStream[i].Text + " ");
                }
                w.WriteLine();
            }

        }
        public static void SQLModel_DebugPrint(this string element, string filespec, bool overwrite = false)
        {
            if (overwrite)
            {
                using StreamWriter w = File.CreateText(filespec);
                w.WriteLine(element);
            }
            else
            {
                using StreamWriter w = File.AppendText(filespec);
                w.WriteLine(element);
            }

        }

    }
}
