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
using Microsoft.SqlServer.Dac.Model;


namespace Cheburashka
{
    internal static class ModelIndexAndKeysUtils
    {

        public static List<int> GetCorrespondingKeyPositions(List<string> searchedForKeys, List<string> searchedLocation)
        {
            // Look for the columns in SearchedForKeys in the list of columns SearchedLocation.
            string[] ar = searchedLocation.ToArray();

            List<int> res = new();
            foreach (var sk in searchedForKeys)
            {
                // if we find the col in the SearchedLocation, record its position (o-based) in res.
                int pos = Array.FindIndex(ar, mem => SqlComparer.SQLModel_StringCompareEqual(sk, mem));
                res.Add(pos);
            }
            return res;
        }


        public static List<TSqlObject> GetForeignKeys(string owningObjectSchema, string owningObjectTable)
        {
            var fks = new List<TSqlObject>();
            foreach (var fk in DmvSettings.GetForeignKeys)
            {
                if (fk.IsLocalObject())
                {
//                    TSqlObject definingTable = fk.GetReferenced(ForeignKeyConstraint.ForeignTable).FirstOrDefault();
                    TSqlObject definingTable = fk.GetReferenced(ForeignKeyConstraint.Host).FirstOrDefault();
                    if (SqlRuleUtils.ObjectNameMatches(definingTable, owningObjectTable, owningObjectSchema)) {
                        fks.Add(fk);
                    }
                }
            }
            return fks;
        }

        
        public static List<TSqlObject> GetPrimaryKeys(string owningObjectSchema, string owningObjectTable)
        {
            var pks = new List<TSqlObject>();
            foreach (var pk in DmvSettings.GetPrimaryKeys)
            {
                if (pk.IsLocalObject())
                {
                    TSqlObject definingTable = pk.GetParent();
                    if (SqlRuleUtils.ObjectNameMatches(definingTable, owningObjectTable, owningObjectSchema))
                    {
                        pks.Add(pk);
                    }
                }
            }
            return pks;
        }

        public static List<TSqlObject> GetClusteredPrimaryKeys(string owningObjectSchema, string owningObjectTable)
        {
            var pks = new List<TSqlObject>();
            foreach (var pk in DmvSettings.GetPrimaryKeys)
            {
                if (pk.IsLocalObject())
                {
                    TSqlObject definingTable = pk.GetParent();
                    if (SqlComparer.SQLModel_StringCompareEqual(definingTable.Name.Parts[0], owningObjectSchema)
                    && SqlComparer.SQLModel_StringCompareEqual(definingTable.Name.Parts[1], owningObjectTable)
                    && (bool?) pk.GetProperty(PrimaryKeyConstraint.Clustered) == true 
                    )
                    {
                        pks.Add(pk);
                    }
                }
            }
            return pks;

        }

        public static List<TSqlObject> GetIndexes(string owningObjectSchema, string owningObjectTable)
        {
            var indexes = new List<TSqlObject>();
            foreach (var index in DmvSettings.GetIndexes)
            {
                if (index.IsLocalObject())
                {
                    TSqlObject definingTable = index.GetParent();
                    if (SqlRuleUtils.ObjectNameMatches(definingTable, owningObjectTable, owningObjectSchema))
                    {
                        indexes.Add(index);
                    }
                }
            }
            return indexes;
        }
        public static List<TSqlObject> GetClusteredIndexes(string owningObjectSchema, string owningObjectTable)
        {
            var indexes = new List<TSqlObject>();
            foreach (var index in DmvSettings.GetIndexes)
            {
                if (index.IsLocalObject())
                {
                    TSqlObject definingTable = index.GetParent();
                    if (SqlRuleUtils.ObjectNameMatches(definingTable, owningObjectTable, owningObjectSchema)
                    && (bool?)index.GetProperty(Index.Clustered) == true
                    )
                    {
                        indexes.Add(index);
                    }
                }
            }
            return indexes;
        }

        public static List<TSqlObject> GetUniqueConstraints(string owningObjectSchema, string owningObjectTable)
        {
            var uniqueConstraints = new List<TSqlObject>();
            foreach (var uniqueConstraint in DmvSettings.GetUniqueConstraints)
            {
                if (uniqueConstraint.IsLocalObject())
                {
                    TSqlObject definingTable = uniqueConstraint.GetParent();
                    if (SqlRuleUtils.ObjectNameMatches(definingTable, owningObjectTable, owningObjectSchema))
                    {
                        uniqueConstraints.Add(uniqueConstraint);
                    }
                }
            }
            return uniqueConstraints;
        }
        public static List<TSqlObject> GetClusteredUniqueConstraints(string owningObjectSchema, string owningObjectTable)
        {
            var uniqueConstraints = new List<TSqlObject>();
            foreach (var uniqueConstraint in DmvSettings.GetUniqueConstraints)
            {
                if (uniqueConstraint.IsLocalObject())
                {
                    TSqlObject definingTable = uniqueConstraint.GetParent();
                    if (SqlRuleUtils.ObjectNameMatches(definingTable, owningObjectTable, owningObjectSchema)
                    && (bool?)uniqueConstraint.GetProperty(UniqueConstraint.Clustered) == true
                    )
                    {
                        uniqueConstraints.Add(uniqueConstraint);
                    }
                }
            }
            return uniqueConstraints;
        }

        //public static List<String> getClusteredKeyColumns(string owningObjectSchema, string owningObjectTable)
        //{
        //    //find clustered constraints - making sure we're not looking at ourselves when we do do !!!!
        //    List<String> ClusterColumns = new List<String>();

        //    List<ISqlPrimaryKeyConstraint> clusteredpks = DMVSettings.getPrimaryKeys
        //                                    .Where(n => (n.DefiningTable.Name.ExternalParts is null || n.DefiningTable.Name.ExternalParts.Count == 0)
        //                                              && SqlComparer.SQLModel_StringCompareEqual(n.DefiningTable.Name.Parts[0], owningObjectSchema)
        //                                              && SqlComparer.SQLModel_StringCompareEqual(n.DefiningTable.Name.Parts[1], owningObjectTable)
        //                                              && n.IsClustered
        //                                              ).Select(n => n).ToList();

        //    List<ISqlIndex> clusteredindexes = DMVSettings.getIndexes
        //                                                .Where(n => (n.Name.ExternalParts is null
        //                                                         || n.Name.ExternalParts.Count == 0
        //                                                         )
        //                                                      && SqlComparer.SQLModel_StringCompareEqual(n.IndexedObject.Name.Parts[0], owningObjectSchema)
        //                                                      && SqlComparer.SQLModel_StringCompareEqual(n.IndexedObject.Name.Parts[1], owningObjectTable)
        //                                                      && n.IsClustered
        //                                                  ).Select(n => n).ToList();

        //    List<ISqlUniqueConstraint> uniqueClusterConstraints = DMVSettings.getUniqueConstraints
        //                                                .Where(n =>
        //                                                        (     n.Name                        is null
        //                                                        || (  n.Name.ExternalParts          is null
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

    }
}
public static class ExternalNameExtensions
{
    public static bool IsLocalObject(this TSqlObject obj)
    {
        return (obj.Name.ExternalParts?.Count ?? 0) == 0;
    }
}