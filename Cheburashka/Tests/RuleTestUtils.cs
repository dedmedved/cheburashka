﻿//------------------------------------------------------------------------------
// <copyright company="Microsoft">
//   Copyright 2013 Microsoft
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

namespace Cheburashka.Tests
{
    internal sealed class RuleTestUtils
    {
        public static void SaveStringToFile(string contents, string filename)
        {
            try
            {
                string directory = Path.GetDirectoryName(filename);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                StreamWriter streamWriter;
                FileStream fileStream;
                using (fileStream = new FileStream(filename, FileMode.Create))
                using (streamWriter = new StreamWriter(fileStream))
                {
                    streamWriter.Write(contents);
                    streamWriter.Close();
                    fileStream.Close();
                }
            }
            finally
            {
            }
        }

        public static string ReadFileToString(string filePath)
        {
            using StreamReader reader = new StreamReader(filePath);
            return reader.ReadToEnd();
        }
    }
}
