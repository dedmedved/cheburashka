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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Dac;
using Microsoft.SqlServer.Dac.CodeAnalysis;
using Microsoft.SqlServer.Dac.Model;
using Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Cheburashka
{
    class ModelIndexAndKeysUtils
    {

        public static List<Int32> getCorrespondingKeyPositions(List<String> SearchedForKeys, List<String> SearchedLocation)
        {
            // Look for the columns in SearchedForKeys in the list of columns SearchedLocation.
            String[] ar = SearchedLocation.ToArray();

            List<Int32> res = new List<Int32>();
            foreach (var sk in SearchedForKeys)
            {
                // if we find the col in the SearchedLocation, record its position (o-based) in res.
                Int32 pos = Array.FindIndex(ar, mem => SqlComparer.SQLModel_StringCompareEqual(sk, mem));
                res.Add(pos);
            }
            return res;
        }


        //public static List<ISqlForeignKeyConstraint> getForeignKeys(string owningObjectSchema, string owningObjectTable)
        //{
        //    return DMVSettings.getForeignKeys
        //                                    .Where(n => (     n.Name                        == null
        //                                                || (  n.Name.ExternalParts          == null
        //                                                   || n.Name.ExternalParts.Count    == 0
        //                                                   )
        //                                                )
        //                                                && SqlComparer.SQLModel_StringCompareEqual(n.DefiningTable.Name.Parts[0], owningObjectSchema)
        //                                                && SqlComparer.SQLModel_StringCompareEqual(n.DefiningTable.Name.Parts[1], owningObjectTable)
        //                                        ).Select(n => n).ToList();

        //}

        
        //public static List<ISqlPrimaryKeyConstraint> getPrimaryKeys(string owningObjectSchema, string owningObjectTable)
        //{
        //    return DMVSettings.getPrimaryKeys
        //                                    .Where(n => (     n.Name                        == null
        //                                                || (  n.Name.ExternalParts          == null
        //                                                   || n.Name.ExternalParts.Count    == 0
        //                                                   )
        //                                                )
        //                                                && SqlComparer.SQLModel_StringCompareEqual(n.DefiningTable.Name.Parts[0], owningObjectSchema)
        //                                                && SqlComparer.SQLModel_StringCompareEqual(n.DefiningTable.Name.Parts[1], owningObjectTable)
        //                                      ).Select(n => n).ToList();

        //}
        //public static List<ISqlPrimaryKeyConstraint> getClusteredPrimaryKeys(string owningObjectSchema, string owningObjectTable)
        //{
        //    return DMVSettings.getPrimaryKeys
        //                                    .Where(n => (     n.Name                        == null
        //                                                || (  n.Name.ExternalParts          == null
        //                                                   || n.Name.ExternalParts.Count    == 0
        //                                                   )
        //                                                )
        //                                                && SqlComparer.SQLModel_StringCompareEqual(n.DefiningTable.Name.Parts[0], owningObjectSchema)
        //                                                && SqlComparer.SQLModel_StringCompareEqual(n.DefiningTable.Name.Parts[1], owningObjectTable)
        //                                                && n.IsClustered
        //                                      ).Select(n => n).ToList();

        //}

        //public static List<ISqlIndex> getIndexes(string owningObjectSchema, string owningObjectTable)
        //{
        //    return DMVSettings.getIndexes
        //                                     .Where(n => (n.Name.ExternalParts == null
        //                                              || n.Name.ExternalParts.Count == 0
        //                                              )
        //                                           && SqlComparer.SQLModel_StringCompareEqual(n.IndexedObject.Name.Parts[0], owningObjectSchema)
        //                                           && SqlComparer.SQLModel_StringCompareEqual(n.IndexedObject.Name.Parts[1], owningObjectTable)
        //                                       ).Select(n => n).ToList();

        //}
        //public static List<ISqlIndex> getClusteredIndexes(string owningObjectSchema, string owningObjectTable)
        //{
        //    return DMVSettings.getIndexes
        //                                     .Where(n => (n.Name.ExternalParts == null
        //                                              || n.Name.ExternalParts.Count == 0
        //                                              )
        //                                           && SqlComparer.SQLModel_StringCompareEqual(n.IndexedObject.Name.Parts[0], owningObjectSchema)
        //                                           && SqlComparer.SQLModel_StringCompareEqual(n.IndexedObject.Name.Parts[1], owningObjectTable)
        //                                           && n.IsClustered
        //                                       ).Select(n => n).ToList();

        }

        //public static List<ISqlUniqueConstraint> getUniqueConstraints(string owningObjectSchema, string owningObjectTable)
        //{
        //    return DMVSettings.getUniqueConstraints
        //                            .Where(n => 
        //                                    (     n.Name                        == null 
        //                                    || (  n.Name.ExternalParts          == null
        //                                       || n.Name.ExternalParts.Count    == 0
        //                                       )
        //                                    )
        //                                    && SqlComparer.SQLModel_StringCompareEqual(n.DefiningTable.Name.Parts[0], owningObjectSchema)
        //                                    && SqlComparer.SQLModel_StringCompareEqual(n.DefiningTable.Name.Parts[1], owningObjectTable)
        //                              ).Select(n => n).ToList();

        //}
        //public static List<ISqlUniqueConstraint> getClusteredUniqueConstraints(string owningObjectSchema, string owningObjectTable)
        //{
        //    return DMVSettings.getUniqueConstraints
        //                            .Where(n =>
        //                                    (     n.Name                        == null
        //                                    || (  n.Name.ExternalParts          == null
        //                                       || n.Name.ExternalParts.Count    == 0
        //                                       )
        //                                    )
        //                                    && SqlComparer.SQLModel_StringCompareEqual(n.DefiningTable.Name.Parts[0], owningObjectSchema)
        //                                    && SqlComparer.SQLModel_StringCompareEqual(n.DefiningTable.Name.Parts[1], owningObjectTable)
        //                                    && n.IsClustered
        //                              ).Select(n => n).ToList();

        //}

        //public static List<String> getClusteredKeyColumns(string owningObjectSchema, string owningObjectTable)
        //{
        //    //find clustered constraints - making sure we're not looking at ourselves when we do do !!!!
        //    List<String> ClusterColumns = new List<String>();

        //    List<ISqlPrimaryKeyConstraint> clusteredpks = DMVSettings.getPrimaryKeys
        //                                    .Where(n => (n.DefiningTable.Name.ExternalParts == null || n.DefiningTable.Name.ExternalParts.Count == 0)
        //                                              && SqlComparer.SQLModel_StringCompareEqual(n.DefiningTable.Name.Parts[0], owningObjectSchema)
        //                                              && SqlComparer.SQLModel_StringCompareEqual(n.DefiningTable.Name.Parts[1], owningObjectTable)
        //                                              && n.IsClustered
        //                                              ).Select(n => n).ToList();

        //    List<ISqlIndex> clusteredindexes = DMVSettings.getIndexes
        //                                                .Where(n => (n.Name.ExternalParts == null
        //                                                         || n.Name.ExternalParts.Count == 0
        //                                                         )
        //                                                      && SqlComparer.SQLModel_StringCompareEqual(n.IndexedObject.Name.Parts[0], owningObjectSchema)
        //                                                      && SqlComparer.SQLModel_StringCompareEqual(n.IndexedObject.Name.Parts[1], owningObjectTable)
        //                                                      && n.IsClustered
        //                                                  ).Select(n => n).ToList();

        //    List<ISqlUniqueConstraint> uniqueClusterConstraints = DMVSettings.getUniqueConstraints
        //                                                .Where(n =>
        //                                                        (     n.Name                        == null
        //                                                        || (  n.Name.ExternalParts          == null
        //                                                           || n.Name.ExternalParts.Count    == 0
        //                                                           )
        //                                                        )
        //                                                        && SqlComparer.SQLModel_StringCompareEqual(n.DefiningTable.Name.Parts[0], owningObjectSchema)
        //                                                        && SqlComparer.SQLModel_StringCompareEqual(n.DefiningTable.Name.Parts[1], owningObjectTable)
        //                                                        && n.IsClustered
        //                                                  ).Select(n => n).ToList();

        //    bool clusteredindexExists            = (clusteredindexes.Count > 0);
        //    bool clusteredUniqueConstraintExists = (uniqueClusterConstraints.Count > 0);
        //    bool clusteredPrimaryKeyExists       = (clusteredpks.Count > 0);


        //    if (clusteredPrimaryKeyExists || clusteredindexExists || clusteredUniqueConstraintExists)
        //    {
        //        if (clusteredPrimaryKeyExists)
        //        {
        //            ISqlPrimaryKeyConstraint v = clusteredpks[0];
        //            foreach (var c in v.ColumnSpecifications)
        //            {
        //                String lastElement = "";
        //                foreach (var n in c.Column.Name.Parts)
        //                {
        //                    lastElement = n;
        //                }
        //                ClusterColumns.Add(lastElement);
        //            }
        //        }
        //        else if (clusteredindexExists)
        //        {
        //            ISqlIndex v = clusteredindexes[0];
        //            foreach (var c in v.ColumnSpecifications)
        //            {
        //                String lastElement = "";
        //                foreach (var n in c.Column.Name.Parts)
        //                {
        //                    lastElement = n;
        //                }
        //                ClusterColumns.Add(lastElement);
        //            }
        //        }
        //        else if (clusteredUniqueConstraintExists)
        //        {
        //            ISqlUniqueConstraint v = uniqueClusterConstraints[0];
        //            foreach (var c in v.ColumnSpecifications)
        //            {
        //                String lastElement = "";
        //                foreach (var n in c.Column.Name.Parts)
        //                {
        //                    lastElement = n;
        //                }
        //                ClusterColumns.Add(lastElement);
        //            }
        //        }

        //    }
        //    return ClusterColumns;
        //}

    //}
}
