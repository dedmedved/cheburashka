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

using System;
using System.IO;
using System.Diagnostics;
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
                String fileName = null;

                fileName = modelElement.GetSourceInformation().SourceName;
                if (!String.IsNullOrEmpty(fileName))
                {
                    string fullScript = ReadFileContent(fileName);

                    if (fullScript != null)
                    {
                        int startLine = 0;
                        int startColumn = 0;
                        int endLine = 0;
                        int endColumn = 0;

                        if (ComputeLineColumn(fullScript, obj.StartOffset, obj.FragmentLength, out startLine, out startColumn, out endLine, out endColumn))
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
                Debug.WriteLine(string.Format("Cannot find the file: '{0}'", filePath));
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
                if (reader != null)
                {
                    reader.Close();
                }
            }

            return content;
        }
        /// This method converts offset from ScriptDom to line\column in script files.
        /// A line is defined as a sequence of characters followed by a carriage return ("\r"), 
        /// a line feed ("\n"), or a carriage return immediately followed by a line feed. 
        public static bool ComputeLineColumn(string text, Int32 offset, Int32 length,
                                            out Int32 startLine, out Int32 startColumn, out Int32 endLine, out Int32 endColumn)
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
                Boolean afterOffset = charIndex >= offset;
                if (currentChar == LF)
                {
                    ++endLine;
                    endColumn = 0;
                    if (afterOffset == false)
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
                    if (afterOffset == false)
                    {
                        ++startLine;
                        startColumn = 0;
                    }
                }
                else
                {
                    ++endColumn;
                    if (afterOffset == false)
                    {
                        ++startColumn;
                    }
                }
            }

            return true;
        }

    }
}