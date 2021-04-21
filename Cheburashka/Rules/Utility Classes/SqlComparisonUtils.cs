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

using Microsoft.SqlServer.TransactSql.ScriptDom;
using System.Collections.Generic;


namespace Cheburashka
{
    public static class SqlComparisonUtils
    {
        //public static bool SQLModel_Contains(SqlObjectFragment fragment1, SqlObjectFragment fragment2)
        //{
        //    return
        //        ((fragment1.FirstTokenIndex <= fragment2.FirstTokenIndex) &&
        //          (fragment1.LastTokenIndex >= fragment2.LastTokenIndex)
        //        );
        //}
        //public static bool StrictlyContains(SqlObjectFragment fragment1, SqlObjectFragment fragment2)
        //{
        //    return
        //        ((fragment1.FirstTokenIndex < fragment2.FirstTokenIndex) &&
        //          (fragment1.LastTokenIndex > fragment2.LastTokenIndex)
        //        );
        //}
        //public static bool SemiContains(SqlObjectFragment fragment1, SqlObjectFragment fragment2)
        //{
        //    return (
        //             ((fragment1.FirstTokenIndex <= fragment2.FirstTokenIndex) &&
        //              (fragment1.LastTokenIndex > fragment2.LastTokenIndex)
        //             )
        //           ||
        //             ((fragment1.FirstTokenIndex < fragment2.FirstTokenIndex) &&
        //              (fragment1.LastTokenIndex >= fragment2.LastTokenIndex)
        //             )
        //           );
        //}
        //public static bool SQLModel_Equals(SqlObjectFragment fragment1, SqlObjectFragment fragment2)
        //{
        //    return
        //        ((fragment1.FirstTokenIndex == fragment2.FirstTokenIndex) &&
        //          (fragment1.LastTokenIndex == fragment2.LastTokenIndex)
        //        );
        //}
        //public static bool StartsWith(SqlObjectFragment fragment1, SqlObjectFragment fragment2)
        //{
        //    return
        //        ((fragment1.FirstTokenIndex == fragment2.FirstTokenIndex) &&
        //          (fragment1.LastTokenIndex >= fragment2.LastTokenIndex)
        //        );
        //}
        //public static bool EndsWith(SqlObjectFragment fragment1, SqlObjectFragment fragment2)
        //{
        //    return
        //        ((fragment1.FirstTokenIndex <= fragment2.FirstTokenIndex) &&
        //          (fragment1.LastTokenIndex == fragment2.LastTokenIndex)
        //        );
        //}
        //public static bool Intersects(SqlObjectFragment fragment1, SqlObjectFragment fragment2)
        //{
        //    return
        //        (((fragment1.FirstTokenIndex <= fragment2.FirstTokenIndex) &&
        //            (fragment1.LastTokenIndex >= fragment2.FirstTokenIndex)
        //          )
        //          ||
        //          ((fragment1.FirstTokenIndex <= fragment2.LastTokenIndex) &&
        //            (fragment1.LastTokenIndex >= fragment2.LastTokenIndex)
        //          )
        //        );
        //}


        /// <summary>
        /// /////////////////////
        /// </summary>
        /// <param name="fragment1"></param>
        /// <param name="fragment2"></param>
        /// <returns></returns>


        public static bool SQLModel_Contains(this TSqlFragment fragment1, SqlObjectFragment fragment2)
        {
            return
                ((fragment1.FirstTokenIndex <= fragment2.FirstTokenIndex) &&
                  (fragment1.LastTokenIndex >= fragment2.LastTokenIndex)
                );
        }
        public static bool StrictlyContains(this TSqlFragment fragment1, SqlObjectFragment fragment2)
        {
            return
                ((fragment1.FirstTokenIndex < fragment2.FirstTokenIndex) &&
                  (fragment1.LastTokenIndex > fragment2.LastTokenIndex)
                );
        }
        public static bool SemiContains(this TSqlFragment fragment1, SqlObjectFragment fragment2)
        {
            return (
                     ((fragment1.FirstTokenIndex <= fragment2.FirstTokenIndex) &&
                      (fragment1.LastTokenIndex > fragment2.LastTokenIndex)
                     )
                   ||
                     ((fragment1.FirstTokenIndex < fragment2.FirstTokenIndex) &&
                      (fragment1.LastTokenIndex >= fragment2.LastTokenIndex)
                     )
                   );
        }
        public static bool SQLModel_Equals(this TSqlFragment fragment1, SqlObjectFragment fragment2)
        {
            return
                ((fragment1.FirstTokenIndex == fragment2.FirstTokenIndex) &&
                  (fragment1.LastTokenIndex == fragment2.LastTokenIndex)
                );
        }
        public static bool StartsWith(this TSqlFragment fragment1, SqlObjectFragment fragment2)
        {
            return
                ((fragment1.FirstTokenIndex == fragment2.FirstTokenIndex) &&
                  (fragment1.LastTokenIndex >= fragment2.LastTokenIndex)
                );
        }
        public static bool EndsWith(this TSqlFragment fragment1, SqlObjectFragment fragment2)
        {
            return
                ((fragment1.FirstTokenIndex <= fragment2.FirstTokenIndex) &&
                  (fragment1.LastTokenIndex == fragment2.LastTokenIndex)
                );
        }
        public static bool Intersects(this TSqlFragment fragment1, SqlObjectFragment fragment2)
        {
            return
                (((fragment1.FirstTokenIndex <= fragment2.FirstTokenIndex) &&
                    (fragment1.LastTokenIndex >= fragment2.FirstTokenIndex)
                  )
                  ||
                  ((fragment1.FirstTokenIndex <= fragment2.LastTokenIndex) &&
                    (fragment1.LastTokenIndex >= fragment2.LastTokenIndex)
                  )
                );
        }

        /// <summary>
        /// /////////////////////
        /// </summary>
        /// <param name="fragment1"></param>
        /// <param name="fragment2"></param>
        /// <returns></returns>


        public static bool SQLModel_Contains(SqlObjectFragment fragment1, TSqlFragment fragment2)
        {
            return
                ((fragment1.FirstTokenIndex <= fragment2.FirstTokenIndex) &&
                  (fragment1.LastTokenIndex >= fragment2.LastTokenIndex)
                );
        }
        public static bool StrictlyContains(SqlObjectFragment fragment1, TSqlFragment fragment2)
        {
            return
                ((fragment1.FirstTokenIndex < fragment2.FirstTokenIndex) &&
                  (fragment1.LastTokenIndex > fragment2.LastTokenIndex)
                );
        }
        public static bool SemiContains(SqlObjectFragment fragment1, TSqlFragment fragment2)
        {
            return (
                     ((fragment1.FirstTokenIndex <= fragment2.FirstTokenIndex) &&
                      (fragment1.LastTokenIndex > fragment2.LastTokenIndex)
                     )
                   ||
                     ((fragment1.FirstTokenIndex < fragment2.FirstTokenIndex) &&
                      (fragment1.LastTokenIndex >= fragment2.LastTokenIndex)
                     )
                   );
        }
        public static bool SQLModel_Equals(SqlObjectFragment fragment1, TSqlFragment fragment2)
        {
            return
                ((fragment1.FirstTokenIndex == fragment2.FirstTokenIndex) &&
                  (fragment1.LastTokenIndex == fragment2.LastTokenIndex)
                );
        }
        public static bool StartsWith(SqlObjectFragment fragment1, TSqlFragment fragment2)
        {
            return
                ((fragment1.FirstTokenIndex == fragment2.FirstTokenIndex) &&
                  (fragment1.LastTokenIndex >= fragment2.LastTokenIndex)
                );
        }
        public static bool EndsWith(SqlObjectFragment fragment1, TSqlFragment fragment2)
        {
            return
                ((fragment1.FirstTokenIndex <= fragment2.FirstTokenIndex) &&
                  (fragment1.LastTokenIndex == fragment2.LastTokenIndex)
                );
        }
        public static bool Intersects(SqlObjectFragment fragment1, TSqlFragment fragment2)
        {
            return
                (((fragment1.FirstTokenIndex <= fragment2.FirstTokenIndex) &&
                    (fragment1.LastTokenIndex >= fragment2.FirstTokenIndex)
                  )
                  ||
                  ((fragment1.FirstTokenIndex <= fragment2.LastTokenIndex) &&
                    (fragment1.LastTokenIndex >= fragment2.LastTokenIndex)
                  )
                );
        }


        /// <summary>
        /// /////////////////////
        /// </summary>
        /// <param name="fragment1"></param>
        /// <param name="fragment2"></param>
        /// <returns></returns>

        public static bool SQLModel_Contains(this TSqlFragment fragment1, TSqlFragment fragment2)
        {
            return
                ((fragment1.FirstTokenIndex <= fragment2.FirstTokenIndex) &&
                  (fragment1.LastTokenIndex >= fragment2.LastTokenIndex)
                );
        }
        //public static bool StrictlyContains(this TSqlFragment fragment1, TSqlFragment fragment2)
        //{
        //    return
        //        ((fragment1.FirstTokenIndex < fragment2.FirstTokenIndex) &&
        //          (fragment1.LastTokenIndex > fragment2.LastTokenIndex)
        //        );
        //}
        //public static bool SemiContains(this TSqlFragment fragment1, TSqlFragment fragment2)
        //{
        //    return (
        //             ((fragment1.FirstTokenIndex <= fragment2.FirstTokenIndex) &&
        //              (fragment1.LastTokenIndex > fragment2.LastTokenIndex)
        //             )
        //           ||
        //             ((fragment1.FirstTokenIndex < fragment2.FirstTokenIndex) &&
        //              (fragment1.LastTokenIndex >= fragment2.LastTokenIndex)
        //             )
        //           );
        //}
        public static bool SQLModel_Equals(this TSqlFragment fragment1, TSqlFragment fragment2)
        {
            return
                ((fragment1.FirstTokenIndex == fragment2.FirstTokenIndex) &&
                  (fragment1.LastTokenIndex == fragment2.LastTokenIndex)
                );
        }
        //public static bool StartsWith(this TSqlFragment fragment1, TSqlFragment fragment2)
        //{
        //    return
        //        ((fragment1.FirstTokenIndex == fragment2.FirstTokenIndex) &&
        //          (fragment1.LastTokenIndex >= fragment2.LastTokenIndex)
        //        );
        //}
        //public static bool EndsWith(this TSqlFragment fragment1, TSqlFragment fragment2)
        //{
        //    return
        //        ((fragment1.FirstTokenIndex <= fragment2.FirstTokenIndex) &&
        //          (fragment1.LastTokenIndex == fragment2.LastTokenIndex)
        //        );
        //}
        //public static bool Intersects(this TSqlFragment fragment1, TSqlFragment fragment2)
        //{
        //    return
        //        (((fragment1.FirstTokenIndex <= fragment2.FirstTokenIndex) &&
        //            (fragment1.LastTokenIndex >= fragment2.FirstTokenIndex)
        //          )
        //          ||
        //          ((fragment1.FirstTokenIndex <= fragment2.LastTokenIndex) &&
        //            (fragment1.LastTokenIndex >= fragment2.LastTokenIndex)
        //          )
        //        );
        //}



        //////////////

        //// really obscure code - to compare model elements with sqlfragment elements
        //// ie is a name in a piece of sql 

        //public static bool SQLModel_Contains(ModelCollationComparer cmp, string defaultSchema, this TSqlFragment fragment1, ModelIdentifier fragment2)
        //{
        //    //match last element of name
        //    //work backwards, matching schema as supplied.
        //    int lastElement = fragment2.Parts.Count-1;

        //    List<String> sql = new List<string>() ;

        //    for ( int i = fragment1.FirstTokenIndex; i <= fragment1.LastTokenIndex;i++) {
        //        sql.Add(fragment1.ScriptTokenStream[i].Text);
        //    }
        //    List<int> matchpos = new List<string>();



        //    return
        //        ((fragment1.FirstTokenIndex <= fragment2.FirstTokenIndex) &&
        //          (fragment1.LastTokenIndex >= fragment2.LastTokenIndex)
        //        );
        //}
        //public static bool StrictlyContains(ModelCollationComparer cmp, string defaultSchema, this TSqlFragment fragment1, ModelIdentifier fragment2)
        //{
        //    return
        //        ((fragment1.FirstTokenIndex < fragment2.FirstTokenIndex) &&
        //          (fragment1.LastTokenIndex > fragment2.LastTokenIndex)
        //        );
        //}
        //public static bool SemiContains(ModelCollationComparer cmp, string defaultSchema, this TSqlFragment fragment1, ModelIdentifier fragment2)
        //{
        //    return (
        //             ((fragment1.FirstTokenIndex <= fragment2.FirstTokenIndex) &&
        //              (fragment1.LastTokenIndex > fragment2.LastTokenIndex)
        //             )
        //           ||
        //             ((fragment1.FirstTokenIndex < fragment2.FirstTokenIndex) &&
        //              (fragment1.LastTokenIndex >= fragment2.LastTokenIndex)
        //             )
        //           );
        //}
        //public static bool SQLModel_Equals(ModelCollationComparer cmp, string defaultSchema, this TSqlFragment fragment1, ModelIdentifier fragment2)
        //{
        //    return
        //        ((fragment1.FirstTokenIndex == fragment2.FirstTokenIndex) &&
        //          (fragment1.LastTokenIndex == fragment2.LastTokenIndex)
        //        );
        //}
        //public static bool StartsWith(ModelCollationComparer cmp, string defaultSchema, this TSqlFragment fragment1, ModelIdentifier fragment2)
        //{
        //    return
        //        ((fragment1.FirstTokenIndex == fragment2.FirstTokenIndex) &&
        //          (fragment1.LastTokenIndex >= fragment2.LastTokenIndex)
        //        );
        //}
        //public static bool EndsWith(ModelCollationComparer cmp, string defaultSchema, this TSqlFragment fragment1, ModelIdentifier fragment2)
        //{
        //    return
        //        ((fragment1.FirstTokenIndex <= fragment2.FirstTokenIndex) &&
        //          (fragment1.LastTokenIndex == fragment2.LastTokenIndex)
        //        );
        //}
        //public static bool Intersects(ModelCollationComparer cmp, string defaultSchema, this TSqlFragment fragment1, ModelIdentifier fragment2)
        //{
        //    return
        //        (((fragment1.FirstTokenIndex <= fragment2.FirstTokenIndex) &&
        //            (fragment1.LastTokenIndex >= fragment2.FirstTokenIndex)
        //          )
        //          ||
        //          ((fragment1.FirstTokenIndex <= fragment2.LastTokenIndex) &&
        //            (fragment1.LastTokenIndex >= fragment2.LastTokenIndex)
        //          )
        //        );
        //}
    }
    //////////////

    // Custom comparer for the Subquery class
    //class SqlSubqueryComparer : IEqualityComparer<Subquery>
    //{
    //    // sql fragments are equal if their token ranges are equal.
    //    public bool SQLModel_Equals(Subquery x, Subquery y)
    //    {
    //        //Check whether the compared objects reference the same data.
    //        if (Object.ReferenceEquals(x, y)) return true;
    //        //Check whether any of the compared objects is null.
    //        if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
    //            return false;
    //        //Check whether the sql token ranges are equal.
    //        return (SqlComparisonUtils.SQLModel_Equals(x, y));
    //    }

    //    // If SQLModel_Equals() returns true for a pair of objects 
    //    // then GetHashCode() must return the same value for these objects.

    //    public int GetHashCode(Subquery sql)
    //    {
    //        //Check whether the object is null
    //        if (Object.ReferenceEquals(sql, null)) return 0;
    //        //Calculate the hash code for the product.
    //        return sql.FirstTokenIndex;
    //    }

    //}

    internal class SqlVariableReferenceComparer : IEqualityComparer<VariableReference>
    {
        // sql fragments are equal if their token ranges are equal.
        public bool Equals(VariableReference x, VariableReference y)
        {
            //Check whether the compared objects reference the same data.
            if (ReferenceEquals(x, y)) return true;
            //Check whether any of the compared objects is null.
            if (x is null || y is null)
                return false;
            //Check whether the sql token ranges are equal.
            return (SqlComparisonUtils.SQLModel_Equals(x, y));
        }

        // If SQLModel_Equals() returns true for a pair of objects 
        // then GetHashCode() must return the same value for these objects.

        public int GetHashCode(VariableReference sql)
        {
            //Calculate the hash code for the product.
            return sql.FirstTokenIndex;
        }
    }

    class SqlLiteralComparer : IEqualityComparer<Literal>
    {
        // sql fragments are equal if their token ranges are equal.
        public bool Equals(Literal x, Literal y)
        {
            //Check whether the compared objects reference the same data.
            if (ReferenceEquals(x, y)) return true;
            //Check whether any of the compared objects is null.
            if (x is null || y is null)
                return false;
            //Check whether the sql token ranges are equal.
            return (SqlComparisonUtils.SQLModel_Equals(x, y));
        }

        // If SQLModel_Equals() returns true for a pair of objects 
        // then GetHashCode() must return the same value for these objects.

        public int GetHashCode(Literal sql)
        {
            return sql.FirstTokenIndex;
        }

    }

    class ColumnWithSortOrderNameOnlyComparer : IEqualityComparer<ColumnWithSortOrder>
    {
        // sql fragments are equal if their token ranges are equal.
        public bool Equals(ColumnWithSortOrder x, ColumnWithSortOrder y)
        {
            //Check whether the compared objects reference the same data.
            if (ReferenceEquals(x, y)) return true;
            //Check whether any of the compared objects is null.
            if (x is null || y is null)
                return false;
            //Check whether the sql token ranges are equal.
            return (SqlComparisonUtils.SQLModel_Equals(x.Column.MultiPartIdentifier[0], y.Column.MultiPartIdentifier[0]));
        }

        // If SQLModel_Equals() returns true for a pair of objects 
        // then GetHashCode() must return the same value for these objects.

        public int GetHashCode(ColumnWithSortOrder sql)
        {
            //Calculate the hash code for the product.
            return sql.FirstTokenIndex;
        }
    }

    class SqlStringComparer : IEqualityComparer<string>
    {
        // sql fragments are equal if their token ranges are equal.
        public bool Equals(string x, string y)
        {
            //Check whether the compared objects reference the same data.
            if (ReferenceEquals(x, y)) return true;
            //Check whether any of the compared objects is null.
            if (x is null || y is null)
                return false;
            //Check whether the sql token ranges are equal.
            return (x.SQLModel_StringCompareEqual(y));
        }

        // If SQLModel_Equals() returns true for a pair of objects 
        // then GetHashCode() must return the same value for these objects.

        public int GetHashCode(string sql)
        {
            //Calculate the hash code for the product.
            return sql.GetHashCode();
        }

    }


}