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
using System.IO;
using System.Diagnostics;
using System.Linq;
using Microsoft.SqlServer.Dac;
using Microsoft.SqlServer.Dac.CodeAnalysis;
using Microsoft.SqlServer.Dac.Model;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System.Globalization;


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
        /// <param name="obj">object within the model element</param>
//        public static void UpdateProblemPosition(TSqlObject modelElement, SqlRuleProblem problem, int offset, int length)
        public static void UpdateProblemPosition(TSqlObject modelElement, SqlRuleProblem problem, TSqlFragment obj)
        {
            if (modelElement is not null && problem is not null && obj is not null)
            {
                if (modelElement.GetSourceInformation() is not null)
                {
                    string fileName = modelElement.GetSourceInformation().SourceName;
                    if (!string.IsNullOrEmpty(fileName))
                    {
                        string fullScript = ReadFileContent(fileName);

                        if (fullScript is not null)
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
            if (!bFoundClusteredIndex)
            {
                var allPKs = model.GetObjects(DacQueryScopes.UserDefined, PrimaryKeyConstraint.TypeClass).ToList();
                foreach (var thing in allPKs)
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
            if (!bFoundClusteredIndex)
            {
                var allUNs = model.GetObjects(DacQueryScopes.UserDefined, UniqueConstraint.TypeClass).ToList();
                foreach (var thing in allUNs)
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

            return bFoundClusteredIndex;
        }

    public static bool FindClusteredIndex(TSqlModel model, string owningObjectSchema, string owningObjectTable, out TSqlObject clusteredIndex , out List<ObjectIdentifier> columns)
        {
            clusteredIndex = null;
            columns = new List<ObjectIdentifier>();
            bool bFoundClusteredIndex = false;
            {
                var allIndexes = model.GetObjects(DacQueryScopes.UserDefined, Index.TypeClass).ToList();
                var relClass = Index.ColumnsRelationship.RelationshipClass;
                var propertyType = Index.Clustered;
                bFoundClusteredIndex = FindClusteringObject(owningObjectSchema, owningObjectTable, ref clusteredIndex, columns, allIndexes, propertyType, relClass);
            }
            if (!bFoundClusteredIndex)
            {
                var allPKs = model.GetObjects(DacQueryScopes.UserDefined, PrimaryKeyConstraint.TypeClass).ToList();
                var relClass = PrimaryKeyConstraint.ColumnsRelationship.RelationshipClass;
                var propertyType = PrimaryKeyConstraint.Clustered;
                bFoundClusteredIndex = FindClusteringObject(owningObjectSchema, owningObjectTable, ref clusteredIndex, columns, allPKs, propertyType, relClass);
            }
            if (!bFoundClusteredIndex)
            {
                var allUNs = model.GetObjects(DacQueryScopes.UserDefined, UniqueConstraint.TypeClass).ToList();
                var relClass = UniqueConstraint.ColumnsRelationship.RelationshipClass;
                var propertyType = UniqueConstraint.Clustered;
                bFoundClusteredIndex = FindClusteringObject(owningObjectSchema, owningObjectTable, ref clusteredIndex, columns, allUNs, propertyType, relClass);
            }

            return bFoundClusteredIndex;
        }

    private static bool FindClusteringObject(string owningObjectSchema
                                            , string owningObjectTable
                                            , ref TSqlObject clusteredIndex
                                            , List<ObjectIdentifier> columns
                                            , List<TSqlObject> allIndexes
                                            , ModelPropertyClass propertyType
                                            , ModelRelationshipClass relClass)
    {
        bool bFoundClusteredIndex = false;
        foreach (var thing in allIndexes)
        {
            TSqlObject tab = thing.GetReferenced(Index.IndexedObject).ToList()[0];
            if (tab.Name.Parts[1].SQLModel_StringCompareEqual(owningObjectTable)
                && tab.Name.Parts[0].SQLModel_StringCompareEqual(owningObjectSchema)
                && thing.GetProperty<bool>(propertyType)
            )

            {
                var c = thing.GetReferencedRelationshipInstances(relClass, DacQueryScopes.UserDefined).ToList();
                columns.AddRange(c.Select(n => n.ObjectName));

                clusteredIndex = thing;
                bFoundClusteredIndex = true;
                break;
            }
        }

        return bFoundClusteredIndex;
    }

    public static void UpdateProblems(List<SqlRuleProblem> problems, TSqlObject modelElement, string elementName, List<TSqlFragment> issues, RuleDescriptor ruleDescriptor)
        {
            foreach (TSqlFragment issue in issues)
            {
                SqlRuleProblem problem =
                    new(
                        string.Format(CultureInfo.CurrentCulture, ruleDescriptor.DisplayDescription, elementName)
                        , modelElement
                        , issue);

                //RuleUtils.UpdateProblemPosition(modelElement, problem, ((Identifier) objects[key]));
                problems.Add(problem);
            }
        }
        public static void UpdateProblems(List<SqlRuleProblem> problems, TSqlObject modelElement, string elementName, TSqlFragment issue, RuleDescriptor ruleDescriptor)
        {
            SqlRuleProblem problem =
                new(
                    string.Format(CultureInfo.CurrentCulture, ruleDescriptor.DisplayDescription, elementName)
                    , modelElement
                    , issue);

            //RuleUtils.UpdateProblemPosition(modelElement, problem, ((Identifier) objects[key]));
            problems.Add(problem);
        }
        public static void UpdateProblems(bool problemExists, List<SqlRuleProblem> problems, TSqlObject modelElement, string elementName, TSqlFragment issue, RuleDescriptor ruleDescriptor)
        {
            if (problemExists)
            {
                SqlRuleProblem problem =
                    new(
                        string.Format(CultureInfo.CurrentCulture, ruleDescriptor.DisplayDescription, elementName)
                        , modelElement
                        , issue);

                //RuleUtils.UpdateProblemPosition(modelElement, problem, ((Identifier) objects[key]));
                problems.Add(problem);
            }
        }
    }
}
