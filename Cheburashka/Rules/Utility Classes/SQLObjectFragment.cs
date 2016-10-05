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

namespace Cheburashka
{
    abstract public class SqlObjectFragment
    {
        // ReSharper disable InconsistentNaming
        // ReSharper restore InconsistentNaming

        protected SqlObjectFragment()
        {
            FirstTokenIndex = 0;
            LastTokenIndex = 0;
            StartOffset = 0;
            FragmentLength = 0;
        }
        protected SqlObjectFragment(int firstTokenIndex
                                , int lastTokenIndex
                                , int startOffset
                                , int fragmentLength
                                )
        {
            FirstTokenIndex = firstTokenIndex;
            LastTokenIndex = lastTokenIndex;
            StartOffset = startOffset;
            FragmentLength = fragmentLength;
        }

        public int FirstTokenIndex { get; set; }

        public int LastTokenIndex { get; set; }

        public int StartOffset { get; set; }

        public int FragmentLength { get; set; }
    }
}
