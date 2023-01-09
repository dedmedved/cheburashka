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

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.SqlServer.Dac.Model;

namespace Cheburashka
{
    static class DmvSettings
    {
        private const int CacheRefreshIntervalSeconds = 15;

        private static DateTime                 _lastConstraintsAndIndexesCacheRefresh = DateTime.Now.AddSeconds(-(CacheRefreshIntervalSeconds+10)) ;
        //private static readonly DateTime        LastInsertColumnCacheRefresh;
        private static SqlServerVersion?        _modelVersion ;

        //public static bool AllowClusterOnPrimaryKey = true;        // these used to be settable via a config file - we aren't re-introducing that just yet
        //public static bool AllowClusterOnForeignKey = true;        // these used to be settable via a config file - we aren't re-introducing that just yet

        //private static IEnumerable<TSqlObject>  _builtinDataTypes;

        //private static readonly IEnumerable<TSqlObject>              Ts;
        //private static readonly IEnumerable<TSqlObject>              Vs;

        //private static readonly IEnumerable<TSqlObject>              Tables;
        //private static readonly IEnumerable<TSqlObject>              Views;

        private static readonly Dictionary<string, List<TSqlObject>> TablesColumnsCache;

        private static IList<TSqlObject>              _proceduresCache;
        private static IList<TSqlObject>              _tablesCache;
        private static IList<TSqlObject>              _viewsCache;
        private static IList<TSqlObject>              _indexesCache;
        private static IList<TSqlObject>              _primaryKeyConstraints;
        private static IList<TSqlObject>              _foreignKeyConstraints;
        private static IList<TSqlObject>              _uniqueConstraints;
        private static IList<TSqlObject>              _checkConstraints;
        //private static IList<TSqlObject>              _defaultConstraints;

        public static void RefreshModelBuiltInCache(TSqlModel model)
        {
            if (_modelVersion is null || _modelVersion != model.Version)
            {
                _modelVersion = model.Version;
                SqlRuleUtils.SetBuiltinDataTypes(model);
                SqlRuleUtils.SetSS2008R2_SystemDatabaseObject(model);
            }
        }

        public static void RefreshConstraintsAndIndexesCache(TSqlModel model)
        {
            if ( DateTime.Compare(_lastConstraintsAndIndexesCacheRefresh.Add(TimeSpan.FromSeconds(CacheRefreshIntervalSeconds)), DateTime.Now) == -1
               )
            {
                IList<TSqlObject> prcs = model.GetObjects(DacQueryScopes.UserDefined, Procedure.TypeClass).ToList();
                IList<TSqlObject> tbls = model.GetObjects(DacQueryScopes.UserDefined, Table.TypeClass).ToList();
                IList<TSqlObject>  vws = model.GetObjects(DacQueryScopes.UserDefined, View.TypeClass).ToList();
                IList<TSqlObject> idxs = model.GetObjects(DacQueryScopes.UserDefined, Index.TypeClass).ToList();
                IList<TSqlObject> pkcs = model.GetObjects(DacQueryScopes.UserDefined, PrimaryKeyConstraint.TypeClass).ToList();
                IList<TSqlObject> fkcs = model.GetObjects(DacQueryScopes.UserDefined, ForeignKeyConstraint.TypeClass).ToList();
                IList<TSqlObject> ukcs = model.GetObjects(DacQueryScopes.UserDefined, UniqueConstraint.TypeClass).ToList();
                IList<TSqlObject> chks = model.GetObjects(DacQueryScopes.UserDefined, CheckConstraint.TypeClass).ToList();
                //IList<TSqlObject> dfts = model.GetObjects(DacQueryScopes.UserDefined, DefaultConstraint.TypeClass).ToList();

                // Only store 2-part name, or unnamed  ie local stuff.

                _proceduresCache        = prcs ;
                _tablesCache            = tbls ;
                _viewsCache             = vws ;
                _indexesCache           = idxs ;
                _primaryKeyConstraints  = pkcs ;
                _foreignKeyConstraints  = fkcs ;
                _uniqueConstraints      = ukcs ;
                _checkConstraints       = chks ;
                //_defaultConstraints     = dfts ;
            }
            else
            {
                // bump value - until we have clear elapsed window of xx secs don't refresh
                _lastConstraintsAndIndexesCacheRefresh = DateTime.Now;
            }
        }

        public static IList<TSqlObject> TableColumns(string schemaAndTableName)
        {
            if (TablesColumnsCache.ContainsKey(schemaAndTableName))
            {
                return TablesColumnsCache[schemaAndTableName].AsReadOnly();
            }
            else
            {
                List<TSqlObject> x = new();
                return x;
            }
        }

        public static IList<TSqlObject> GetProcedures => _proceduresCache;
        public static IList<TSqlObject> GetTables => _tablesCache;
        public static IList<TSqlObject> GetViews => _viewsCache;
        public static IList<TSqlObject> GetIndexes => _indexesCache;
        public static IList<TSqlObject> GetPrimaryKeys => _primaryKeyConstraints;
        public static IList<TSqlObject> GetForeignKeys => _foreignKeyConstraints;
        public static IList<TSqlObject> GetUniqueConstraints => _uniqueConstraints;
        public static IList<TSqlObject> GetCheckConstraints => _checkConstraints;
        //public static IList<TSqlObject> GetDefaultConstraints => _defaultConstraints;
    }
}
