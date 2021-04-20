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

        public static List<int> GetCorrespondingKeyPositions(List<string> SearchedForKeys, List<string> SearchedLocation)
        {
            // Look for the columns in SearchedForKeys in the list of columns SearchedLocation.
            string[] ar = SearchedLocation.ToArray();

            List<int> res = new();
            foreach (var sk in SearchedForKeys)
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
            foreach (var fk in DMVSettings.GetForeignKeys)
            { 
                if ( fk.Name?.ExternalParts == null || fk.Name.ExternalParts.Count == 0)
                {
//                    TSqlObject definingTable = fk.GetReferenced(ForeignKeyConstraint.ForeignTable).FirstOrDefault();
                    TSqlObject definingTable = fk.GetReferenced(ForeignKeyConstraint.Host).FirstOrDefault();
                    if (SqlComparer.SQLModel_StringCompareEqual(definingTable.Name.Parts[0], owningObjectSchema)
                    && SqlComparer.SQLModel_StringCompareEqual(definingTable.Name.Parts[1], owningObjectTable)
                    ) {
                        fks.Add(fk);
                    }
                }
            }
            return fks;
        }

        
        public static List<TSqlObject> GetPrimaryKeys(string owningObjectSchema, string owningObjectTable)
        {
            var pks = new List<TSqlObject>();
            foreach (var pk in DMVSettings.GetPrimaryKeys)
            {
                if (pk.Name?.ExternalParts == null || pk.Name.ExternalParts.Count == 0)
                {
                    TSqlObject definingTable = pk.GetParent();
                    if (SqlComparer.SQLModel_StringCompareEqual(definingTable.Name.Parts[0], owningObjectSchema)
                    && SqlComparer.SQLModel_StringCompareEqual(definingTable.Name.Parts[1], owningObjectTable)
                    )
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
            foreach (var pk in DMVSettings.GetPrimaryKeys)
            {
                if (pk.Name?.ExternalParts == null || pk.Name.ExternalParts.Count == 0)
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
            foreach (var index in DMVSettings.GetIndexes)
            {
                if (index.Name?.ExternalParts == null || index.Name.ExternalParts.Count == 0)
                {
                    TSqlObject definingTable = index.GetParent();
                    if (SqlComparer.SQLModel_StringCompareEqual(definingTable.Name.Parts[0], owningObjectSchema)
                    && SqlComparer.SQLModel_StringCompareEqual(definingTable.Name.Parts[1], owningObjectTable)
                    )
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
            foreach (var index in DMVSettings.GetIndexes)
            {
                if (index.Name?.ExternalParts == null || index.Name.ExternalParts.Count == 0)
                {
                    TSqlObject definingTable = index.GetParent();
                    if (SqlComparer.SQLModel_StringCompareEqual(definingTable.Name.Parts[0], owningObjectSchema)
                    && SqlComparer.SQLModel_StringCompareEqual(definingTable.Name.Parts[1], owningObjectTable)
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
            var unique_constraints = new List<TSqlObject>();
            foreach (var unique_constraint in DMVSettings.GetUniqueConstraints)
            {
                if (unique_constraint.Name?.ExternalParts == null || unique_constraint.Name.ExternalParts.Count == 0)
                {
                    TSqlObject definingTable = unique_constraint.GetParent();
                    if (SqlComparer.SQLModel_StringCompareEqual(definingTable.Name.Parts[0], owningObjectSchema)
                    && SqlComparer.SQLModel_StringCompareEqual(definingTable.Name.Parts[1], owningObjectTable)
                    )
                    {
                        unique_constraints.Add(unique_constraint);
                    }
                }
            }
            return unique_constraints;
        }
        public static List<TSqlObject> GetClusteredUniqueConstraints(string owningObjectSchema, string owningObjectTable)
        {
            var unique_constraints = new List<TSqlObject>();
            foreach (var unique_constraint in DMVSettings.GetUniqueConstraints)
            {
                if (unique_constraint.Name?.ExternalParts == null || unique_constraint.Name.ExternalParts.Count == 0)
                {
                    TSqlObject definingTable = unique_constraint.GetParent();
                    if (SqlComparer.SQLModel_StringCompareEqual(definingTable.Name.Parts[0], owningObjectSchema)
                    && SqlComparer.SQLModel_StringCompareEqual(definingTable.Name.Parts[1], owningObjectTable)
                    && (bool?)unique_constraint.GetProperty(UniqueConstraint.Clustered) == true
                    )
                    {
                        unique_constraints.Add(unique_constraint);
                    }
                }
            }
            return unique_constraints;
        }

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

    }
}
