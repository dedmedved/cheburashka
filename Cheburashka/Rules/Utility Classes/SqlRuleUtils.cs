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
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using Microsoft.SqlServer.Dac.Model;
using static System.String;

namespace Cheburashka
{
    public static class SqlRuleUtils
    {
        private static readonly List<string> StoredProceduresOfWhichWeIgnoreTheReturnStatus = Initialisers.IgnorableReturnStatusStoredProcedures();

        private static readonly List<string> BuiltinDataTypesThatParseAsIdentifiers = new()
        {
            "sysname"
        ,"hierarchyid"
        };

        private static readonly List<string> SystemDatabasesThatNeedNoSchemaQualification = new()
        {
            "msdb"
        ,"master"
        };

        private static readonly List<string> SystemTablesThatNeedNoSchemaQualification = new()
        {"Inserted"
        ,"Deleted"
        };

        private static List<string> _builtinDataTypes = new();

        private static readonly List<string> BuiltinAggregateFunctions = new()
        {"avg"
        ,"min"
        ,"max"
        ,"checksum_agg"
        ,"sum"
        ,"count"
        ,"count_big"
        ,"stdev"
        ,"stdevp"
        ,"grouping"
        ,"var"
        ,"varp"
        };

        private static readonly List<string> DateParts = new()
        {"year"
        ,"yy"
        ,"yyyy"
        ,"quarter"
        ,"qq"
        ,"q"
        ,"month"
        ,"mm"
        ,"m"
        ,"dayofyear"
        ,"dy"
        ,"y"
        ,"day"
        ,"dd"
        ,"d"
        ,"week"
        ,"wk"
        ,"ww"
        ,"weekday"
        ,"dw"
        ,"hour"
        ,"hh"
        ,"minute"
        ,"mi"
        ,"n"
        ,"second"
        ,"ss"
        ,"s"
        ,"millisecond"
        ,"ms"
        };

        private static HashSet<string> _hashSs2008R2SystemObjectNames; //= new HashSet<String>(SqlComparer.Comparer);

        //need to double-check these and pick them up dynamically if possible from master/msdb dacpacs
        private static List<string> _ss2008R2SystemObjectNames = new();

        /// <summary>
        /// Determine if an sp needs to have its return value checked.
        /// </summary>
        /// <param name="objectName">object name to check</param>
        public static bool IgnoreTheReturnValueOf(string objectName)
        {
            return StoredProceduresOfWhichWeIgnoreTheReturnStatus.Contains(GetNormalisedName(objectName), SqlComparer.Comparer);
        }

        /// <summary>
        /// Determine if a database name is a builtin system object that needs no schema qualification when 
        /// referencing sub-objects.  
        /// </summary>
        /// <param name="objectName">object name to check</param>
        public static bool IsSystemTableThatNeedNoSchemaQualification(string objectName)
        {
            return SystemTablesThatNeedNoSchemaQualification.Contains(GetNormalisedName(objectName), StringComparer.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Set Builtin datatypes
        /// </summary>
        /// <param name="model">model to extract objects from</param>
        public static void SetBuiltinDataTypes(TSqlModel model)
        {
            IEnumerable<TSqlObject> allSysObjects = model.GetObjects(DacQueryScopes.BuiltIn, DataType.TypeClass);
            SqlRuleUtils._builtinDataTypes = allSysObjects.Select(n => n.Name.Parts[0]).ToList();
        }

        /// <summary>
        /// Determine if a datatype name is a builtin datatype.
        /// </summary>
        /// <param name="objectName">object name to check</param>
        public static bool IsBuiltinDataTypes(string objectName)
        {
            return _builtinDataTypes.Contains(GetNormalisedName(objectName), StringComparer.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Determine if a database name is a builtin system object that needs no schema qualification when 
        /// referencing sub-objects.  
        /// </summary>
        /// <param name="objectName">object name to check</param>
        public static bool IsSystemDatabaseThatNeedNoSchemaQualification(string objectName)
        {
            return SystemDatabasesThatNeedNoSchemaQualification.Contains(GetNormalisedName(objectName), SqlComparer.Comparer);
        }

        /// <summary>
        /// Sets the current sysprocs to ignore for schema name presence checking
        /// </summary>
        /// <param name="model">model to extract objects from</param>
        public static void SetSS2008R2_SystemDatabaseObject(TSqlModel model)
        {
            IEnumerable<TSqlObject> allSysObjects      = model.GetObjects(DacQueryScopes.System, Procedure.TypeClass);
            SqlRuleUtils._ss2008R2SystemObjectNames    = allSysObjects.Select(n => n.Name.Parts[1]).ToList();
            _hashSs2008R2SystemObjectNames             = new HashSet<string>(_ss2008R2SystemObjectNames, SqlComparer.Comparer);
        }

        /// <summary>
        /// Determine if a database object name is a builtin system object.  
        /// </summary>
        /// <param name="objectName">object name to check</param>
        public static bool Is_SS2008R2_SystemDatabaseObject(string objectName)
        {
            //SqlComparer.Comparer should be populated by the first time we get called!
            //fill the hash-table on first call from list
            //we need the deferred create as we don't know the model collation until runtime
            //there may be better methods frankly.
            //if (_HashSS2008R2_SystemObjectNames is null)
            //{
            //    _HashSS2008R2_SystemObjectNames = new HashSet<String>(SS2008R2_SystemObjectNames, SqlComparer.Comparer);
            //}
            return _hashSs2008R2SystemObjectNames.Contains(GetNormalisedName(objectName));
        }

        /// <summary>
        /// Determine if 'something' is a builtin name that parses as a user defined name.  
        /// </summary>
        /// <param name="objectName">object name to check</param>
        public static bool IsBuiltinDataTypeThatParsesAsAnIdentifier(string objectName)
        {
            return BuiltinDataTypesThatParseAsIdentifiers.Contains(GetNormalisedName(objectName), StringComparer.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Determine if 'something' is a builtin aggregate function.
        /// This ought to include user-defined functions too.  But that's too hard. way too hard.
        /// </summary>
        /// <param name="objectName">object name to check</param>
        public static bool IsBuiltInAggregateFunction(string objectName)
        {
            return BuiltinAggregateFunctions.Contains(GetNormalisedName(objectName), StringComparer.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Determine if an unquoted literal name-like object is a datepart name
        /// This really ought to be a context dependent check.  But that's too hard.
        /// </summary>
        /// <param name="objectName">object name to check</param>
        public static bool IsDatePart(string objectName)
        {
            return DateParts.Contains(GetNormalisedName(objectName), StringComparer.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Gather all the occurrences of CTEs.
        /// </summary>
        /// <param name="sqlFragment">sql to analyse</param>
        public static ReadOnlyCollection<CteUtil> CteStatements(TSqlFragment sqlFragment)
        {
            List<CteUtil> bits = new();

            var svisitor = new SelectWithCTEVisitor();
            sqlFragment.Accept(svisitor);
            List<CteUtil> sCteUtilFragments = svisitor.CteUtilFragments;
            bits.AddRange(sCteUtilFragments);

            var ivisitor = new InsertWithCTEVisitor();
            sqlFragment.Accept(ivisitor);
            List<CteUtil> iCteUtilFragments = ivisitor.CteUtilFragments;
            bits.AddRange(iCteUtilFragments);

            var uvisitor = new UpdateWithCTEVisitor();
            sqlFragment.Accept(uvisitor);
            List<CteUtil> uCteUtilFragments = uvisitor.CteUtilFragments;
            bits.AddRange(uCteUtilFragments);

            var dvisitor = new DeleteWithCTEVisitor();
            sqlFragment.Accept(dvisitor);
            List<CteUtil> dCteUtilFragments = dvisitor.CteUtilFragments;
            bits.AddRange(dCteUtilFragments);

            var mvisitor = new MergeWithCTEVisitor();
            sqlFragment.Accept(mvisitor);
            List<CteUtil> mCteUtilFragments = mvisitor.CteUtilFragments;
            bits.AddRange(mCteUtilFragments);

            return bits.ToList().AsReadOnly();
        }

        public static string GetNormalisedName(this string objectName)
        {
            string normalisedObjectName = objectName;
            Match match = Regex.Match(normalisedObjectName, @"^(?:(?:\[.*\])|(?:"".*""))$", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                normalisedObjectName = normalisedObjectName.Substring(1, normalisedObjectName.Length - 2);
            }
            return normalisedObjectName;
        }

        private static readonly Regex ObjectNameRegex = new(@" ( (?: (?: (?: ""[^ . "" ]* "" ) | (?: \[ [^ . \[ \] ]* \] ) | (?: [^.]* ) ) [.] ) | (?: (?: "" [^ . "" ]* "" ) | (?: \[ [^ . \[ \] ]+ \] ) | (?: [^.]+ ) $ ) )", RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase | RegexOptions.Singleline);

        private static string ExtractSchemaNameFromLiteralString(this string sLit)
        {
            MatchCollection m = ObjectNameRegex.Matches(sLit);

            var schema = m.Count >= 2 ? m[m.Count - 2].Groups[0].Value : "";
            if (!IsNullOrEmpty(schema))
            {
                schema = schema.TrimEnd(new char['.']);
            }

            return schema;
        }

        public static bool EmptySchemaNameInLiteral(this string sLit)
        {
            var schema = sLit.ExtractSchemaNameFromLiteralString();
            return schema?.Length == 0
                || schema == "[]"
                || schema == @"""";
        }


        public static ReadOnlyCollection<ModelTypeClass> GetCodeContainingClasses() => Array.AsReadOnly<ModelTypeClass>(new ModelTypeClass[7]
        {
                ModelSchema.ExtendedProcedure,
                ModelSchema.Procedure,
                ModelSchema.TableValuedFunction,
                ModelSchema.ScalarFunction,
                ModelSchema.DatabaseDdlTrigger,
                ModelSchema.DmlTrigger,
                ModelSchema.ServerDdlTrigger
        });
        public static ReadOnlyCollection<ModelTypeClass> GetParameterizedCodeContainingClasses() => Array.AsReadOnly<ModelTypeClass>(new ModelTypeClass[4]
        {
                ModelSchema.ExtendedProcedure,
                ModelSchema.Procedure,
                ModelSchema.TableValuedFunction,
                ModelSchema.ScalarFunction,
        });
        public static ReadOnlyCollection<ModelTypeClass> GetCodeAndViewContainingClasses() => Array.AsReadOnly<ModelTypeClass>(new ModelTypeClass[8]
        {
                ModelSchema.View,
                ModelSchema.ExtendedProcedure,
                ModelSchema.Procedure,
                ModelSchema.TableValuedFunction,
                ModelSchema.ScalarFunction,
                ModelSchema.DatabaseDdlTrigger,
                ModelSchema.DmlTrigger,
                ModelSchema.ServerDdlTrigger
        });
        //ModelSchema.ExtendedProcedure,

        public static ReadOnlyCollection<ModelTypeClass> GetDataTypeUsingClasses() => Array.AsReadOnly<ModelTypeClass>(new ModelTypeClass[9]
        {
                ModelSchema.Table,
                ModelSchema.View,
                ModelSchema.ExtendedProcedure,
                ModelSchema.Procedure,
                ModelSchema.TableValuedFunction,
                ModelSchema.ScalarFunction,
                ModelSchema.DatabaseDdlTrigger,
                ModelSchema.DmlTrigger,
                ModelSchema.ServerDdlTrigger
        });

        public static ReadOnlyCollection<ModelTypeClass> GetProcedureClasses() => Array.AsReadOnly<ModelTypeClass>(new ModelTypeClass[2]
        {
                ModelSchema.ExtendedProcedure,
                ModelSchema.Procedure
        });

        public static ReadOnlyCollection<ModelTypeClass> GetStateAlteringContainingClasses() => Array.AsReadOnly<ModelTypeClass>(new ModelTypeClass[5]
        {
                ModelSchema.ExtendedProcedure,
                ModelSchema.Procedure,
                ModelSchema.DatabaseDdlTrigger,
                ModelSchema.DmlTrigger,
                ModelSchema.ServerDdlTrigger
        });

        public static ReadOnlyCollection<ModelTypeClass> GetPrimaryKeyConstraintClass() => Array.AsReadOnly<ModelTypeClass>(new ModelTypeClass[1]
        {
                ModelSchema.PrimaryKeyConstraint
        });
        public static ReadOnlyCollection<ModelTypeClass> GetForeignKeyConstraintClass() => Array.AsReadOnly<ModelTypeClass>(new ModelTypeClass[1]
        {
                ModelSchema.ForeignKeyConstraint
        });
        public static ReadOnlyCollection<ModelTypeClass> GetTableClass() => Array.AsReadOnly<ModelTypeClass>(new ModelTypeClass[1]
        {
                ModelSchema.Table
        });
        public static ReadOnlyCollection<ModelTypeClass> GetIndexClass() => Array.AsReadOnly<ModelTypeClass>(new ModelTypeClass[1]
        {
                ModelSchema.Index
        });

        public static ReadOnlyCollection<ModelTypeClass> GetIndexLikeClasses() => Array.AsReadOnly<ModelTypeClass>(new ModelTypeClass[3]
        {
                ModelSchema.PrimaryKeyConstraint,
                ModelSchema.Index,
                ModelSchema.UniqueConstraint
        });

        public static ReadOnlyCollection<ModelTypeClass> GetConstraintDefiningClasses() => Array.AsReadOnly<ModelTypeClass>(new ModelTypeClass[6]
        {
                ModelSchema.Table,
                ModelSchema.ExtendedProcedure,
                ModelSchema.Procedure,
                ModelSchema.DatabaseDdlTrigger,
                ModelSchema.DmlTrigger,
                ModelSchema.ServerDdlTrigger
        });

        public static ReadOnlyCollection<ModelTypeClass> GetPotentialSchemaLessNameContextClasses() => Array.AsReadOnly<ModelTypeClass>(new ModelTypeClass[9]
        {
                ModelSchema.Table,
                ModelSchema.View,
                ModelSchema.Index,
                ModelSchema.Procedure,
                ModelSchema.TableValuedFunction,
                ModelSchema.ScalarFunction,
                ModelSchema.DatabaseDdlTrigger,
                ModelSchema.DmlTrigger,
                ModelSchema.ServerDdlTrigger
        });
        public static ReadOnlyCollection<ModelTypeClass> GetDMLTriggerClass() => Array.AsReadOnly<ModelTypeClass>(new ModelTypeClass[1]
        {
            ModelSchema.DmlTrigger
        });

        public static bool ObjectNameMatches(TSqlObject tab, string tableName, string schemaName)
        {
            return tab.Name.Parts[1].SQLModel_StringCompareEqual(tableName)
                   && tab.Name.Parts[0].SQLModel_StringCompareEqual(schemaName);
        }
        public static bool ObjectNameMatches(TSqlObject table1, TSqlObject table2)
        {
            return table1.Name.Parts[1].SQLModel_StringCompareEqual(table2.Name.Parts[1])
                   && table1.Name.Parts[0].SQLModel_StringCompareEqual(table2.Name.Parts[0]);
        }
        ///// <summary>
        ///// Gets the set of classes representing a potential source of columns. Tables, Views, Functions can all be
        ///// a source for this
        ///// </summary>
        ///// <returns>The <see cref="T:Microsoft.SqlServer.Dac.Model.ModelTypeClass" />es representing view, subroutines and triggers</returns>
        //public static ReadOnlyCollection<ModelTypeClass> GetColumnSourceClasses() => Array.AsReadOnly<ModelTypeClass>(new ModelTypeClass[5]
        //{
        //    ModelSchema.Table,
        //    ModelSchema.FileTable,
        //    ModelSchema.View,
        //    ModelSchema.TableValuedFunction,
        //    ModelSchema.Queue
        //});

    }
}