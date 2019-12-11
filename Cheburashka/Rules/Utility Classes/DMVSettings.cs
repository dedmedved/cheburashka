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
        private static int                      _CacheRefreshIntervalSeconds = 5;

        private static DateTime                 _LastConstraintsAndIndexesCacheRefresh;
        private static DateTime                 _LastInsertColumnCacheRefresh;
        private static SqlServerVersion?        _ModelVersion ;


        public static bool AllowClusterOnPrimaryKey = true;        // these used to be settable via a config file - we aren't re-introducing that just yet
        public static bool AllowClusterOnForeignKey = true;        // these used to be settable via a config file - we aren't re-introducing that just yet

        //private static IEnumerable<TSqlObject>  _builtinDataTypes;

        private static IEnumerable<TSqlObject>              ts;
        private static IEnumerable<TSqlObject>              vs;

        private static IEnumerable<TSqlObject>              tables;
        private static IEnumerable<TSqlObject>              views;


        private static Dictionary<String, List<TSqlObject>> _tablesColumnsCache;

        private static IEnumerable<TSqlObject>              _IndexesCache;
        private static IEnumerable<TSqlObject>              _PrimaryKeyConstraints;
        private static IEnumerable<TSqlObject>              _ForeignKeyConstraints;
        private static IEnumerable<TSqlObject>              _UniqueConstraints;



        public static void RefreshModelBuiltInCache(TSqlModel model)
        {
            if (_ModelVersion == null || _ModelVersion != model.Version)
            {
                _ModelVersion = model.Version;
                SqlRuleUtils.SetBuiltinDataTypes(model);
                SqlRuleUtils.SetSS2008R2_SystemDatabaseObject(model);
            }
        }

        public static void RefreshConstraintsAndIndexesCache(TSqlModel model)
        {

            // in case initialiser doesn't work.
            if (_LastConstraintsAndIndexesCacheRefresh == null ||
                 DateTime.Compare(_LastConstraintsAndIndexesCacheRefresh.Add(TimeSpan.FromSeconds(_CacheRefreshIntervalSeconds)), DateTime.Now) == -1
               )
            {
                IEnumerable<TSqlObject> idxs = model.GetObjects(DacQueryScopes.UserDefined, Index.TypeClass); //model.GetElements(typeof(ISqlIndex), 0);
                IEnumerable<TSqlObject> pkcs = model.GetObjects(DacQueryScopes.UserDefined, PrimaryKeyConstraint.TypeClass); //model.GetElements(typeof(ISqlPrimaryKeyConstraint), 0);
                IEnumerable<TSqlObject> fkcs = model.GetObjects(DacQueryScopes.UserDefined, ForeignKeyConstraint.TypeClass); //model.GetElements(typeof(ISqlForeignKeyConstraint), 0);
                IEnumerable<TSqlObject> ukcs = model.GetObjects(DacQueryScopes.UserDefined, UniqueConstraint.TypeClass); //model.GetElements(typeof(ISqlUniqueConstraint), 0);

                // Only store 2-part name, or unnamed  ie local stuff.

                _IndexesCache           = idxs; //.Cast<ISqlIndex>().Where(n => n.Name != null && (n.Name.ExternalParts == null || n.Name.ExternalParts.Count == 0)).Select(n => n);
                _PrimaryKeyConstraints  = pkcs; //.Cast<ISqlPrimaryKeyConstraint>().Where(n => (n.DefiningTable.Name.ExternalParts == null || n.DefiningTable.Name.ExternalParts.Count == 0)).Select(n => n);
                _ForeignKeyConstraints  = fkcs; //.Cast<ISqlForeignKeyConstraint>().Where(n => (n.DefiningTable.Name.ExternalParts == null || n.DefiningTable.Name.ExternalParts.Count == 0)).Select(n => n);
                _UniqueConstraints      = ukcs; //.Cast<ISqlUniqueConstraint>().Where(n => (n.DefiningTable.Name.ExternalParts == null || n.DefiningTable.Name.ExternalParts.Count == 0)).Select(n => n);

            }
            else
            {
                // bump value - until we have clear elapsed window of xx secs don't refresh
                _LastConstraintsAndIndexesCacheRefresh = DateTime.Now;
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

        public static IList<TSqlObject> getIndexes
        {
            get { return _IndexesCache.ToList().AsReadOnly(); }
        }
        public static IList<TSqlObject> getPrimaryKeys
        {
            get { return _PrimaryKeyConstraints.ToList().AsReadOnly(); }
        }
        public static IList<TSqlObject> getForeignKeys
        {
            get { return _ForeignKeyConstraints.ToList().AsReadOnly(); }
        }
        public static IList<TSqlObject> getUniqueConstraints
        {
            get { return _UniqueConstraints.ToList().AsReadOnly(); }
        }

    }
}
