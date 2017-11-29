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
using Microsoft.SqlServer.Dac;
using Microsoft.SqlServer.Dac.CodeAnalysis;
using Microsoft.SqlServer.Dac.Model;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.IO;

using Cheburashka;

namespace Cheburashka
{
    /// <summary>
    /// This is a SQL rule which returns a warning message 
    /// whenever there is a clustered key column in a trailing position in another index.
    /// This rule only applies to Indexes
    /// </summary>


    [LocalizedExportCodeAnalysisRule(CheckClusteredKeyColumnsNotIncludedInIndexRule.RuleId,
        RuleConstants.ResourceBaseName,                                                 // Name of the resource file to look up displayname and description in
        RuleConstants.CheckClusteredKeyColumnsNotIncludedInIndex_RuleName,              // ID used to look up the display name inside the resources file
        RuleConstants.CheckClusteredKeyColumnsNotIncludedInIndex_ProblemDescription,    // ID used to look up the description inside the resources file
        Category = RuleConstants.CategoryDatabaseStructures,                            // Rule category (e.g. "Design", "Naming")
        RuleScope = SqlRuleScope.Element)]                                              // This rule targets specific elements rather than the whole model
    public sealed class CheckClusteredKeyColumnsNotIncludedInIndexRule : SqlCodeAnalysisRule
    {

        /// <summary>
        /// The Rule ID should resemble a fully-qualified class name. In the Visual Studio UI
        /// rules are grouped by "Namespace + Category", and each rule is shown using "Short ID: DisplayName".
        /// For this rule, it will be 
        /// shown as "DM0018: Tables should normally be clustered and not heap."
        /// </summary>
        public const string RuleId = RuleConstants.CheckClusteredKeyColumnsNotIncludedInIndexRuleId;

        public CheckClusteredKeyColumnsNotIncludedInIndexRule() {
            // This rule supports Tables. Only those objects will be passed to the Analyze method
            SupportedElementTypes = new[]
            {
                // Note: can use the ModelSchema definitions, or access the TypeClass for any of these types
                ModelSchema.Index
                // if the clustering keys are in a pk or unique constraint, there's not much we can recommend
                //presumably they need to be there

            };
        }

        /// <summary>
        /// For element-scoped rules the Analyze method is executed once for every matching object in the model. 
        /// </summary>
        /// <param name="ruleExecutionContext">The context object contains the TSqlObject being analyzed, a TSqlFragment
        /// that's the AST representation of the object, the current rule's descriptor, and a reference to the model being
        /// analyzed.
        /// </param>
        /// <returns>A list of problems should be returned. These will be displayed in the Visual Studio error list</returns>
        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext ruleExecutionContext) {
            // Get Model collation 
            SqlComparer.Comparer = ruleExecutionContext.SchemaModel.CollationComparer;

            List<SqlRuleProblem> problems = new List<SqlRuleProblem>();

            TSqlModel model;
            TSqlObject modelElement;
            TSqlFragment sqlFragment;

            DMVRuleSetup.RuleSetup(ruleExecutionContext, out problems, out model, out sqlFragment, out modelElement);
            string elementName = RuleUtils.GetElementName(ruleExecutionContext, modelElement);

            DMVSettings.RefreshModelBuiltInCache(model);
            // Refresh cached index/constraints/tables lists from Model
            //DMVSettings.RefreshColumnCache(model);
            DMVSettings.RefreshConstraintsAndIndexesCache(model);

            // Get Database Schema and name of this model element.
            string selfSchema = modelElement.Name.Parts[0];
            string selfTable = modelElement.Name.Parts[1];
            string owningObjectSchema = null;
            string owningObjectTable = null;


            //var allIndexes = model.GetObjects(DacQueryScopes.UserDefined, Index.TypeClass).ToList();
            //var thisIndex = model.GetObjects(DacQueryScopes.UserDefined, Index.TypeClass).Where(( n => n.Name.Parts[0] == selfSchema && n.Name.Parts[1] == selfTable)).Take(1);



            // visitor to get the occurrences of statements that create constraints etc where we need the parent object name
            CheckClusteredKeyColumnsNotIncludedInIndexVisitor checkClusteredKeyColumnsNotIncludedInIndexVisitor = new CheckClusteredKeyColumnsNotIncludedInIndexVisitor();
            sqlFragment.Accept(checkClusteredKeyColumnsNotIncludedInIndexVisitor);
            List<ColumnWithSortOrder> indexColumns = checkClusteredKeyColumnsNotIncludedInIndexVisitor.Objects;

            // if we're a unique index, then this check doesn't apply - we need all the columns in the index to be in the index.!
            // if we're a clustered index then this rule definitely doesn't apply !!!!!!
            if (thisIX != null && !thisIX.IsUnique && !thisIX.IsClustered)
            {
                owningObjectSchema = thisIX.IndexedObject.Name.Parts[0];
                owningObjectTable = thisIX.IndexedObject.Name.Parts[1];
                List<String> ClusterColumns =
                    ModelIndexAndKeysUtils.getClusteredKeyColumns(owningObjectSchema, owningObjectTable);


                // We need to create a problem where the leading n (n>0) columns in the index are not in the clustered columns
                // And the remainder all are.
                // It's questionable as to whether indexes that then have trailing elements not in the cluster should be in our list
                // of problems.

                Boolean leadingEdgeNotInCluster = true;
                Boolean trailingEdgeInCluster = false;
                Boolean checkingLeadingEdge = true;
                Boolean checkingTrailingEdge = false;
                Boolean first = true;
                //List<String> LeadingEdgeIndexColumns = new List<String>();
                foreach (var c in thisIX.ColumnSpecifications) // in the right order we hope
                {
                    // get column name - looks to be an on-demand structure so we need this rigmarole to access it.
                    String ixColumnName = "";
                    foreach (var n in c.Column.Name.Parts)
                    {
                        ixColumnName = n;
                    }

                    if (checkingLeadingEdge)
                    {
                        if (first)
                        {
                            if (ClusterColumns.Contains(ixColumnName))
                            {
                                leadingEdgeNotInCluster = false;
                                checkingTrailingEdge = true;
                            }
                            first = false;
                        }
                        else
                        {
                            if (ClusterColumns.Contains(ixColumnName))
                            {
                                checkingLeadingEdge = false;
                                checkingTrailingEdge = true;
                            }
                        }
                    }
                    if (checkingTrailingEdge)
                    {
                        if (ClusterColumns.Contains(ixColumnName))
                        {
                            trailingEdgeInCluster = true;
                        }
                    }
                }


                if (leadingEdgeNotInCluster && trailingEdgeInCluster)
                {
                    issues.Add(sqlFragment);
                }
                else
                {
                    // if it's a 2005+ index, also check the included columns
                    ISql90Index this90IX = sqlElement as ISql90Index;
                    if (this90IX != null)
                    {
                        List<String> IncludedIndexColumns = new List<String>();
                        foreach (var c in this90IX.IncludedColumns)
                        {

                            String ixColumnName = "";
                            foreach (var n in c.Name.Parts)
                            {
                                ixColumnName = n;
                            }
                            IncludedIndexColumns.Add(ixColumnName);
                        }
                        List<String> CommonList = IncludedIndexColumns.Intersect(ClusterColumns, SqlComparer.Comparer)
                            .ToList();
                        //lazy collection - needs iterating to find if it has anything
                        bool clusteredKeyColumnFoundInIncludedColumns = false;
                        foreach (var x in CommonList)
                        {
                            clusteredKeyColumnFoundInIncludedColumns = true;
                            break;
                        }


                        if (clusteredKeyColumnFoundInIncludedColumns)
                        {
                            issues.Add(sqlFragment);
                        }
                    }
                }
            }


            // visitor to get the columns
            CheckClusteredKeyColumnsNotIncludedInIndexVisitor CheckClusteredKeyColumnsNotIncludedInIndexVisitor = new CheckClusteredKeyColumnsNotIncludedInIndexVisitor();
            sqlFragment.Accept(CheckClusteredKeyColumnsNotIncludedInIndexVisitor);
            List<ColumnWithSortOrder> indexColumns = CheckClusteredKeyColumnsNotIncludedInIndexVisitor.Objects;

            var issues = new List<TSqlFragment>();

            foreach (var ps in parentSources) {
                dynamic parent = ps as CreateTableStatement;
                if (parent == null) { parent = ps as AlterTableAddTableElementStatement; }
                if (parent != null) {
                    if (parent.SchemaObjectName != null) {
                        String parentName = parent.SchemaObjectName.BaseIdentifier.Value;
                        String schemaName = "";
                        if (parent.SchemaObjectName.SchemaIdentifier != null) {
                            schemaName = parent.SchemaObjectName.SchemaIdentifier.Value;
                        }
                        // tableColumns cannot be null, but can be empty if the object can't be found in the model definition.
                        // this will happen for dynamically created objects and missing objects.
                        //TSqlObject table = model.GetObjects(DacQueryScopes.UserDefined, Table.TypeClass).ToList();
                        IEnumerable<TSqlObject> tables = model.GetObjects(DacQueryScopes.UserDefined, Table.TypeClass)
                                                        .Where(n => n.Name.Parts[0].SQLModel_StringCompareEqual(schemaName))
                                                        .Where(n => n.Name.Parts[1].SQLModel_StringCompareEqual(parentName))
                                                        ;
                        TSqlObject table = tables.SingleOrDefault();

                        try {

                            var tableColumns = table.GetReferencedRelationshipInstances(Table.Columns)
                                .Where(n => n.Object.GetProperty<bool?>(Column.Nullable) == true)
                                .Select(n => n.ObjectName).ToList();

                            if (tableColumns.Count != 0) {
                                IEnumerable<ColumnWithSortOrder> nullableIndexColumns = from iCOl in indexColumns
                                                                                        from tCol in tableColumns
                                                                                        where SqlComparer.SQLModel_StringCompareEqual(iCOl.Column.MultiPartIdentifier.Identifiers[iCOl.Column.MultiPartIdentifier.Identifiers.Count - 1].Value, tCol.Parts[2])
                                                                                        //where tCol.IsNullable
                                                                                        //where tCol.Object.GetReferenced(Column.DataType).FirstOrDefault().GetProperty<bool?>(DataType.UddtNullable)
                                                                                        select iCOl;

                                foreach (var c in nullableIndexColumns.ToList()) {
                                    issues.Add(c);
                                }
                            }
                        }
                        catch { }
                    }
                }
            }

            // The rule execution context has all the objects we'll need, including the fragment representing the object,
            // and a descriptor that lets us access rule metadata
            RuleDescriptor ruleDescriptor = ruleExecutionContext.RuleDescriptor;

            // Create problems for each object
            foreach (TSqlFragment issue in issues) {
                SqlRuleProblem problem =
                new SqlRuleProblem(
                        String.Format(CultureInfo.CurrentCulture, ruleDescriptor.DisplayDescription, elementName)
                        , modelElement
                        , sqlFragment);

                //RuleUtils.UpdateProblemPosition(modelElement, problem, ((Identifier) objects[key]));
                problems.Add(problem);
            }

            return problems;

        }
    }


}









//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Globalization;
//using Microsoft.Data.Schema.Extensibility;
//using Microsoft.Data.Schema.SchemaModel;
//using Microsoft.Data.Schema.ScriptDom.Sql;
//using Microsoft.Data.Schema.Sql.SchemaModel;
//using Microsoft.Data.Schema.Sql;
//using Microsoft.Data.Schema.StaticCodeAnalysis;
//using System.Text.RegularExpressions;

//using System.Linq;

//namespace Neznayka
//{
//    /// <summary>
//    /// This is a SQL rule which returns a warning message 
//    /// whenever there is a clustered key column in a trailing position in another index.
//    /// This rule only applies to Indexes
//    /// </summary>

//    [DatabaseSchemaProviderCompatibility(typeof(SqlDatabaseSchemaProvider))]
//    [DataRuleAttribute(
//        NeznaykaConstants.NameSpace,
//        NeznaykaConstants.CheckClusteredKeyColumnsNotIncludedInIndexRuleId,
//        NeznaykaConstants.ResourceBaseName,
//        NeznaykaConstants.CheckClusteredKeyColumnsNotIncludedInIndex_RuleName,
//        NeznaykaConstants.CategoryDatabaseStructures,
//        DescriptionResourceId = NeznaykaConstants.CheckClusteredKeyColumnsNotIncludedInIndex_ProblemDescription)]
//    //[SupportedElementType(typeof(ISqlProcedure))]
//    //[SupportedElementType(typeof(ISqlTrigger))]
//    //[SupportedElementType(typeof(ISqlFunction))]
//    //[SupportedElementType(typeof(ISqlView))]
//    //[SupportedElementType(typeof(ISqlTable))]
//    [SupportedElementType(typeof(ISqlIndex))]
//    //[SupportedElementType(typeof(ISql90Index))]
//    //[SupportedElementType(typeof(ISql100Index))]
//    //    [SupportedElementType(typeof(ISqlUniqueConstraint))]
//    public class CheckClusteredKeyColumnsNotIncludedInIndexRule : StaticCodeAnalysisRule
//    {
//        #region Overrides
//        /// <summary>
//        /// Analyze the model element
//        /// </summary>
//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1804:RemoveUnusedLocals", MessageId = "x")]
//        public override IList<DataRuleProblem> Analyze(DataRuleSetting ruleSetting, DataRuleExecutionContext context) {
//            // (Re)-Load Environment settings
//            List<DataRuleProblem> problems;
//            SqlSchemaModel sqlSchemaModel;
//            ISqlModelElement sqlElement;
//            TSqlFragment sqlFragment;
//            DMVRuleSetup.RuleSetup(context, out problems, out sqlSchemaModel, out sqlElement, out sqlFragment);

//            // Refresh cached index/constraints/tables lists from Model
//            DMVRuleSetup.RefreshDDLCache(sqlSchemaModel);

//            //// Get Database Schema and name of this model element.
//            //string selfSchema           = sqlElement.Name.Parts[0];
//            //string selfTable            = sqlElement.Name.Parts[1];

//            string owningObjectSchema = null;
//            string owningObjectTable = null;

//            List<TSqlFragment> issues = new List<TSqlFragment>();

//            // do unique constraints participate in this rule/law ? -- NO
//            // Neither do unique indexes
//            ISqlIndex thisIX = sqlElement as ISqlIndex;
//            // if we're a unique index, then this check doesn't apply - we need all the columns in the index to be in the index.!
//            // if we're a clustered index then this rule definitely doesn't apply !!!!!!
//            if (thisIX != null && !thisIX.IsUnique && !thisIX.IsClustered) {
//                owningObjectSchema = thisIX.IndexedObject.Name.Parts[0];
//                owningObjectTable = thisIX.IndexedObject.Name.Parts[1];
//                List<String> ClusterColumns = ModelIndexAndKeysUtils.getClusteredKeyColumns(owningObjectSchema, owningObjectTable);


//                // We need to create a problem where the leading n (n>0) columns in the index are not in the clustered columns
//                // And the remainder all are.
//                // It's questionable as to whether indexes that then have trailing elements not in the cluster should be in our list
//                // of problems.

//                Boolean leadingEdgeNotInCluster = true;
//                Boolean trailingEdgeInCluster = false;
//                Boolean checkingLeadingEdge = true;
//                Boolean checkingTrailingEdge = false;
//                Boolean first = true;
//                //List<String> LeadingEdgeIndexColumns = new List<String>();
//                foreach (var c in thisIX.ColumnSpecifications) // in the right order we hope
//                {
//                    // get column name - looks to be an on-demand structure so we need this rigmarole to access it.
//                    String ixColumnName = "";
//                    foreach (var n in c.Column.Name.Parts) {
//                        ixColumnName = n;
//                    }

//                    if (checkingLeadingEdge) {
//                        if (first) {
//                            if (ClusterColumns.Contains(ixColumnName)) {
//                                leadingEdgeNotInCluster = false;
//                                checkingTrailingEdge = true;
//                            }
//                            first = false;
//                        }
//                        else {
//                            if (ClusterColumns.Contains(ixColumnName)) {
//                                checkingLeadingEdge = false;
//                                checkingTrailingEdge = true;
//                            }
//                        }
//                    }
//                    if (checkingTrailingEdge) {
//                        if (ClusterColumns.Contains(ixColumnName)) {
//                            trailingEdgeInCluster = true;
//                        }
//                    }
//                }


//                if (leadingEdgeNotInCluster && trailingEdgeInCluster) {
//                    issues.Add(sqlFragment);
//                }
//                else {
//                    // if it's a 2005+ index, also check the included columns
//                    ISql90Index this90IX = sqlElement as ISql90Index;
//                    if (this90IX != null) {
//                        List<String> IncludedIndexColumns = new List<String>();
//                        foreach (var c in this90IX.IncludedColumns) {

//                            String ixColumnName = "";
//                            foreach (var n in c.Name.Parts) {
//                                ixColumnName = n;
//                            }
//                            IncludedIndexColumns.Add(ixColumnName);
//                        }
//                        List<String> CommonList = IncludedIndexColumns.Intersect(ClusterColumns, SqlComparer.Comparer).ToList();
//                        //lazy collection - needs iterating to find if it has anything
//                        bool clusteredKeyColumnFoundInIncludedColumns = false;
//                        foreach (var x in CommonList) {
//                            clusteredKeyColumnFoundInIncludedColumns = true;
//                            break;
//                        }


//                        if (clusteredKeyColumnFoundInIncludedColumns) {
//                            issues.Add(sqlFragment);
//                        }
//                    }
//                }


//                // Create problems for each object
//                foreach (TSqlFragment issue in issues) {
//                    DataRuleProblem problem = new DataRuleProblem(this,
//                                                String.Format(CultureInfo.CurrentCulture, this.RuleProperties.Description, SqlRuleUtils.GetElementName(sqlSchemaModel, sqlElement)),
//                                                sqlElement);

//                    SqlRuleUtils.UpdateProblemPosition(problem, issue.StartOffset, issue.FragmentLength);
//                    problems.Add(problem);
//                }
//            }
//            return problems;
//        }

//        #endregion

//    }
//}
