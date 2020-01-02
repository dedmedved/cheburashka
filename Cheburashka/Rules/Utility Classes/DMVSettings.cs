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
    class DMVSettings
    {
        private static int                      _CacheRefreshIntervalSeconds = 15;

        private static DateTime                 _lastConstraintsAndIndexesCacheRefresh;
        private static DateTime                 _lastInsertColumnCacheRefresh;
        private static SqlServerVersion?        _modelVersion ;


        public static bool AllowClusterOnPrimaryKey = true;        // these used to be settable via a config file - we aren't re-introducing that just yet
        public static bool AllowClusterOnForeignKey = true;        // these used to be settable via a config file - we aren't re-introducing that just yet

        //private static IEnumerable<TSqlObject>  _builtinDataTypes;

        private static IEnumerable<TSqlObject>              ts;
        private static IEnumerable<TSqlObject>              vs;

        private static IEnumerable<TSqlObject>              tables;
        private static IEnumerable<TSqlObject>              views;


        private static Dictionary<String, List<TSqlObject>> _tablesColumnsCache;

        private static IEnumerable<TSqlObject>              _indexesCache;
        private static IEnumerable<TSqlObject>              _primaryKeyConstraints;
        private static IEnumerable<TSqlObject>              _foreignKeyConstraints;
        private static IEnumerable<TSqlObject>              _uniqueConstraints;
        private static IEnumerable<TSqlObject>              _checkConstraints;



        public static void RefreshModelBuiltInCache(TSqlModel model)
        {
            if (_modelVersion == null || _modelVersion != model.Version)
            {
                _modelVersion = model.Version;
                SqlRuleUtils.SetBuiltinDataTypes(model);
                SqlRuleUtils.SetSS2008R2_SystemDatabaseObject(model);
            }
        }

        public static void RefreshConstraintsAndIndexesCache(TSqlModel model)
        {

            // in case initialiser doesn't work.
            if (_lastConstraintsAndIndexesCacheRefresh == null ||
                 DateTime.Compare(_lastConstraintsAndIndexesCacheRefresh.Add(TimeSpan.FromSeconds(_CacheRefreshIntervalSeconds)), DateTime.Now) == -1
               )
            {
                IEnumerable<TSqlObject> idxs = model.GetObjects(DacQueryScopes.UserDefined, Index.TypeClass); 
                IEnumerable<TSqlObject> pkcs = model.GetObjects(DacQueryScopes.UserDefined, PrimaryKeyConstraint.TypeClass); 
                IEnumerable<TSqlObject> fkcs = model.GetObjects(DacQueryScopes.UserDefined, ForeignKeyConstraint.TypeClass); 
                IEnumerable<TSqlObject> ukcs = model.GetObjects(DacQueryScopes.UserDefined, UniqueConstraint.TypeClass); 
                IEnumerable<TSqlObject> chks = model.GetObjects(DacQueryScopes.UserDefined, CheckConstraint.TypeClass); 

                // Only store 2-part name, or unnamed  ie local stuff.

                _indexesCache           = idxs; 
                _primaryKeyConstraints  = pkcs; 
                _foreignKeyConstraints  = fkcs; 
                _uniqueConstraints      = ukcs; 
                _checkConstraints       = chks; 

            }
            else
            {
                // bump value - until we have clear elapsed window of xx secs don't refresh
                _lastConstraintsAndIndexesCacheRefresh = DateTime.Now;
            }

        }

        public static IList<TSqlObject> tableColumns(string SchemaAndTableName)
        {
            if (_tablesColumnsCache.ContainsKey(SchemaAndTableName))
            {
                return _tablesColumnsCache[SchemaAndTableName].AsReadOnly();
            }
            else
            {
                List<TSqlObject> x = new List<TSqlObject>();
                return x;
            }
        }

        public static IEnumerable<TSqlObject> getIndexes => _indexesCache;
        public static IEnumerable<TSqlObject> getPrimaryKeys => _primaryKeyConstraints;
        public static IEnumerable<TSqlObject> getForeignKeys => _foreignKeyConstraints;
        public static IEnumerable<TSqlObject> getUniqueConstraints => _uniqueConstraints;
        public static IEnumerable<TSqlObject> getCheckConstraints => _checkConstraints;
    }
}
