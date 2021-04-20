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

using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Linq;
using Microsoft.SqlServer.Dac;
using Microsoft.SqlServer.Dac.CodeAnalysis;
using Microsoft.SqlServer.Dac.Model;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Cheburashka
{
    internal static class RuleUtils
    {
        /// <summary>
        /// Gets a formatted element name with the default style <see cref="ElementNameStyle.EscapedFullyQualifiedName"/>
        /// </summary>
        public static string GetElementName(SqlRuleExecutionContext ruleExecutionContext, TSqlObject modelElement)
        {
            return GetElementName(modelElement, ruleExecutionContext, ElementNameStyle.EscapedFullyQualifiedName);
        }

        /// <summary>
        /// Gets a formatted element name
        /// </summary>
        public static string GetElementName(TSqlObject modelElement, SqlRuleExecutionContext ruleExecutionContext, ElementNameStyle style)
        {
            // Get the element name using the built in DisplayServices. This provides a number of useful formatting options to
            // make a name user-readable
            var displayServices = ruleExecutionContext.SchemaModel.DisplayServices;
            string elementName = displayServices.GetElementName(modelElement, style);
            return elementName;
        }

        /// <summary>
        /// Compute the start Line/Col and the end Line/Col to update problem info
        /// </summary>
        /// <param name="modelElement">object the problem was found in</param>
        /// <param name="problem">problem found</param>
        /// <param name="obj">object within the modelelement</param>
//        public static void UpdateProblemPosition(TSqlObject modelElement, SqlRuleProblem problem, int offset, int length)
        public static void UpdateProblemPosition(TSqlObject modelElement, SqlRuleProblem problem, TSqlFragment obj)
        {
            if (modelElement != null && problem != null && obj != null)
            {
                if (modelElement.GetSourceInformation() != null)
                {
                    string fileName = modelElement.GetSourceInformation().SourceName;
                    if (!string.IsNullOrEmpty(fileName))
                    {
                        string fullScript = ReadFileContent(fileName);

                        if (fullScript != null)
                        {
                            if (ComputeLineColumn(fullScript, obj.StartOffset, obj.FragmentLength, out int startLine, out int startColumn, out _, out _))
                            {
                                problem.SetSourceInformation(new SourceInformation(fileName, startLine + 1, startColumn + 1));
                            }
                            else
                            {
                                Debug.WriteLine("Could not compute line and column");
                            }
                        }
                        else
                        {
                            Debug.WriteLine("Could not obtain filename");
                        }
                    }
                    else
                    {
                        Debug.WriteLine("Could not compute line and column");
                    }
                }
            }
        }

        /// <summary>
        /// Read file content from a file.
        /// </summary>
        /// <param name="filePath"> file path </param>
        /// <returns> file content in a string </returns>
        public static string ReadFileContent(string filePath)
        {
            //  Verify that the file exists first.
            if (!File.Exists(filePath))
            {
                Debug.WriteLine($"Cannot find the file: '{filePath}'");
                return string.Empty;
            }

            string content;
            StreamReader reader = null;
            try
            {
                reader = new StreamReader(filePath);
                content = reader.ReadToEnd();
            }
            finally
            {
                reader?.Close();
            }

            return content;
        }

        /// This method converts offset from ScriptDom to line\column in script files.
        /// A line is defined as a sequence of characters followed by a carriage return ("\r"), 
        /// a line feed ("\n"), or a carriage return immediately followed by a line feed. 
        public static bool ComputeLineColumn(string text, int offset, int length,
                                            out int startLine, out int startColumn, out int endLine, out int endColumn)
        {
            const char LF = '\n';
            const char CR = '\r';

            // Setting the initial value of line and column to 0 since VS auto-increments by 1.
            startLine = 0;
            startColumn = 0;
            endLine = 0;
            endColumn = 0;

            int textLength = text.Length;

            if (offset < 0 || length < 0 || offset + length > textLength)
            {
                return false;
            }

            for (int charIndex = 0; charIndex < length + offset; ++charIndex)
            {
                char currentChar = text[charIndex];
                bool afterOffset = charIndex >= offset;
                if (currentChar == LF)
                {
                    ++endLine;
                    endColumn = 0;
                    if (!afterOffset)
                    {
                        ++startLine;
                        startColumn = 0;
                    }
                }
                else if (currentChar == CR)
                {
                    // CR/LF combination, consuming LF.
                    if ((charIndex + 1 < textLength) && (text[charIndex + 1] == LF))
                    {
                        ++charIndex;
                    }

                    ++endLine;
                    endColumn = 0;
                    if (!afterOffset)
                    {
                        ++startLine;
                        startColumn = 0;
                    }
                }
                else
                {
                    ++endColumn;
                    if (!afterOffset)
                    {
                        ++startColumn;
                    }
                }
            }

            return true;
        }

        public static bool FindClusteredIndex(TSqlModel model, string owningObjectSchema, string owningObjectTable, out TSqlObject clusteredIndex)
        {
            var allIndexes = model.GetObjects(DacQueryScopes.UserDefined, Index.TypeClass).ToList();
            clusteredIndex = null;
            bool bFoundClusteredIndex = false;
            if (!bFoundClusteredIndex)
            {
                foreach (var thing in allIndexes)
                {
                    if (!bFoundClusteredIndex) //TODO: V3022 https://www.viva64.com/en/w/V3022 Expression '!bFoundClusteredIndex' is always true.
                    {
                        TSqlObject tab = thing.GetReferenced(Index.IndexedObject).ToList()[0];
                        if (tab.Name.Parts[1].SQLModel_StringCompareEqual(owningObjectTable)
                            && tab.Name.Parts[0].SQLModel_StringCompareEqual(owningObjectSchema)
                            && thing.GetProperty<bool>(Index.Clustered)
                        )
                        {
                            clusteredIndex = thing;
                            bFoundClusteredIndex = true;
                            break;
                        }
                    }
                }
            }
            if (!bFoundClusteredIndex)
            {
                var allPKs = model.GetObjects(DacQueryScopes.UserDefined, PrimaryKeyConstraint.TypeClass).ToList();
                foreach (var thing in allPKs)
                {
                    if (!bFoundClusteredIndex) //TODO: V3022 https://www.viva64.com/en/w/V3022 Expression '!bFoundClusteredIndex' is always true.
                    {
                        TSqlObject tab = thing.GetReferenced(PrimaryKeyConstraint.Host).ToList()[0];
                        if (tab.Name.Parts[1].SQLModel_StringCompareEqual(owningObjectTable)
                            && tab.Name.Parts[0].SQLModel_StringCompareEqual(owningObjectSchema)
                            && thing.GetProperty<bool>(PrimaryKeyConstraint.Clustered)
                        )
                        {
                            clusteredIndex = thing;
                            bFoundClusteredIndex = true;
                            break;
                        }
                    }
                }
            }
            if (!bFoundClusteredIndex)
            {
                var allUNs = model.GetObjects(DacQueryScopes.UserDefined, UniqueConstraint.TypeClass).ToList();
                foreach (var thing in allUNs)
                {
                    if (!bFoundClusteredIndex) //TODO: V3022 https://www.viva64.com/en/w/V3022 Expression '!bFoundClusteredIndex' is always true.
                    {
                        TSqlObject tab = thing.GetReferenced(UniqueConstraint.Host).ToList()[0];
                        if (tab.Name.Parts[1].SQLModel_StringCompareEqual(owningObjectTable)
                            && tab.Name.Parts[0].SQLModel_StringCompareEqual(owningObjectSchema)
                            && thing.GetProperty<bool>(UniqueConstraint.Clustered)
                        )
                        {
                            clusteredIndex = thing;
                            bFoundClusteredIndex = true;
                            break;
                        }
                    }
                }
            }

            return bFoundClusteredIndex;
        }

    public static bool FindClusteredIndex(TSqlModel model, string owningObjectSchema, string owningObjectTable, out TSqlObject clusteredIndex , out IList<ObjectIdentifier> columns)
        {
            var allIndexes = model.GetObjects(DacQueryScopes.UserDefined, Index.TypeClass).ToList();
            clusteredIndex = null;
            columns = new List<ObjectIdentifier>();
            bool bFoundClusteredIndex = false;
            if (!bFoundClusteredIndex)
            {
                foreach (var thing in allIndexes)
                {
                    if (!bFoundClusteredIndex) //TODO: V3022 https://www.viva64.com/en/w/V3022 Expression '!bFoundClusteredIndex' is always true.
                    {
                        TSqlObject tab = thing.GetReferenced(Index.IndexedObject).ToList()[0];
                        if (tab.Name.Parts[1].SQLModel_StringCompareEqual(owningObjectTable)
                            && tab.Name.Parts[0].SQLModel_StringCompareEqual(owningObjectSchema)
                            && thing.GetProperty<bool>(Index.Clustered)
                        )

                        {
                            var c = thing.GetReferencedRelationshipInstances(
                                Index.ColumnsRelationship.RelationshipClass, DacQueryScopes.UserDefined);
                            foreach (var v in c.ToList())
                            {
                                columns.Add(v.ObjectName);
                            }
                            //                            columns = thing.GetChildren().Cast<ColumnWithSortOrder>();

                            clusteredIndex = thing;
                            bFoundClusteredIndex = true;
                            break;
                        }
                    }
                }
            }
            if (!bFoundClusteredIndex)
            {
                var allPKs = model.GetObjects(DacQueryScopes.UserDefined, PrimaryKeyConstraint.TypeClass).ToList();
                foreach (var thing in allPKs)
                {
                    if (!bFoundClusteredIndex) //TODO: V3022 https://www.viva64.com/en/w/V3022 Expression '!bFoundClusteredIndex' is always true.
                    {
                        TSqlObject tab = thing.GetReferenced(PrimaryKeyConstraint.Host).ToList()[0];
                        if (tab.Name.Parts[1].SQLModel_StringCompareEqual(owningObjectTable)
                            && tab.Name.Parts[0].SQLModel_StringCompareEqual(owningObjectSchema)
                            && thing.GetProperty<bool>(PrimaryKeyConstraint.Clustered)
                        )
                        {
                            var c = thing.GetReferencedRelationshipInstances(
                                PrimaryKeyConstraint.ColumnsRelationship.RelationshipClass, DacQueryScopes.UserDefined);
                            foreach (var v in c.ToList())
                            {
                                columns.Add(v.ObjectName);
                            }

                            //                            columns = thing.GetChildren().Cast<ColumnWithSortOrder>();
                            clusteredIndex = thing;
                            bFoundClusteredIndex = true;
                            break;
                        }
                    }
                }
            }
            if (!bFoundClusteredIndex)
            {
                var allUNs = model.GetObjects(DacQueryScopes.UserDefined, UniqueConstraint.TypeClass).ToList();
                foreach (var thing in allUNs)
                {
                    if (!bFoundClusteredIndex) //TODO: V3022 https://www.viva64.com/en/w/V3022 Expression '!bFoundClusteredIndex' is always true.
                    {
                        TSqlObject tab = thing.GetReferenced(UniqueConstraint.Host).ToList()[0];
                        if (tab.Name.Parts[1].SQLModel_StringCompareEqual(owningObjectTable)
                            && tab.Name.Parts[0].SQLModel_StringCompareEqual(owningObjectSchema)
                            && thing.GetProperty<bool>(UniqueConstraint.Clustered)
                        )
                        {
                            var c = thing.GetReferencedRelationshipInstances(
                                UniqueConstraint.ColumnsRelationship.RelationshipClass, DacQueryScopes.UserDefined);
                            foreach (var v in c.ToList())
                            {
                                columns.Add(v.ObjectName);
                            }
                            //columns = thing.GetChildren().Cast<ColumnWithSortOrder>();
                            clusteredIndex = thing;
                            bFoundClusteredIndex = true;
                            break;
                        }
                    }
                }
            }

            return bFoundClusteredIndex;
        }
    }
}
