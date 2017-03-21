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
    /// whenever there is an un-clustered table in a model.
    /// 
    /// Note that this uses a Localized export attribute, and hence the rule name and description will be
    /// localized if resource files for different languages are used
    /// </summary>


    [LocalizedExportCodeAnalysisRule(CheckUniqueConstraintHasNoNullColumnsRule.RuleId,
        RuleConstants.ResourceBaseName,                                                 // Name of the resource file to look up displayname and description in
        RuleConstants.CheckUniqueConstraintHasNoNullColumns_RuleName,                   // ID used to look up the display name inside the resources file
        RuleConstants.CheckUniqueConstraintHasNoNullColumns_ProblemDescription,         // ID used to look up the description inside the resources file
        Category = RuleConstants.CategoryDatabaseStructures,                            // Rule category (e.g. "Design", "Naming")
        RuleScope = SqlRuleScope.Element)]                                              // This rule targets specific elements rather than the whole model
    public sealed class CheckUniqueConstraintHasNoNullColumnsRule: SqlCodeAnalysisRule
    {

        /// <summary>
        /// The Rule ID should resemble a fully-qualified class name. In the Visual Studio UI
        /// rules are grouped by "Namespace + Category", and each rule is shown using "Short ID: DisplayName".
        /// For this rule, it will be 
        /// shown as "DM0018: Tables should normally be clustered and not heap."
        /// </summary>
        public const string RuleId = RuleConstants.CheckUniqueConstraintHasNoNullColumnsRuleId;

        public CheckUniqueConstraintHasNoNullColumnsRule()
        {
            // This rule supports Tables. Only those objects will be passed to the Analyze method
            SupportedElementTypes = new[]
            {
                // Note: can use the ModelSchema definitions, or access the TypeClass for any of these types
                ModelSchema.Table,
                ModelSchema.Procedure,
                ModelSchema.DatabaseDdlTrigger,
                ModelSchema.DmlTrigger,
                ModelSchema.ServerDdlTrigger
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
        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext ruleExecutionContext)
        {
            // Get Model collation 
            SqlComparer.Comparer = ruleExecutionContext.SchemaModel.CollationComparer;

            List<SqlRuleProblem> problems = new List<SqlRuleProblem>();

return problems;

            TSqlModel           model;
            TSqlObject          modelElement;
            TSqlFragment        sqlFragment;

            DMVRuleSetup.RuleSetup(ruleExecutionContext, out problems, out model, out sqlFragment, out modelElement);
            string elementName = RuleUtils.GetElementName(ruleExecutionContext, modelElement);


            // Get Database Schema and name of this model element.
            //string owningObjectSchema = modelElement.Name.Parts[0];
            //string owningObjectTable = modelElement.Name.Parts[1];

            DMVSettings.RefreshModelBuiltInCache(model);
            // Refresh cached index/constraints/tables lists from Model
            //DMVSettings.RefreshColumnCache(model);
            DMVSettings.RefreshConstraintsAndIndexesCache(model);


            var allIndexes = model.GetObjects(DacQueryScopes.UserDefined, Index.TypeClass).ToList();

            // visitor to get the occurrences of statements that create constraints etc where we need the parent object name
            CheckUniqueConstraintParentObjectVisitor checkUniqueConstraintParentObjectVisitor = new CheckUniqueConstraintParentObjectVisitor();
            sqlFragment.Accept(checkUniqueConstraintParentObjectVisitor);
            List<TSqlFragment> parentSources            = checkUniqueConstraintParentObjectVisitor.Objects;

            // visitor to get the columns
            CheckUniqueConstraintHasNoNullColumnsVisitor checkUniqueConstraintHasNoNullColumnsVisitor = new CheckUniqueConstraintHasNoNullColumnsVisitor();
            sqlFragment.Accept(checkUniqueConstraintHasNoNullColumnsVisitor);
            List<ColumnWithSortOrder> indexColumns      = checkUniqueConstraintHasNoNullColumnsVisitor.Objects;

            List<TSqlFragment> issues = new List<TSqlFragment>();

            foreach (var ps in parentSources)
            {
                dynamic parent = ps as CreateTableStatement;
                if (parent == null) { parent = ps as AlterTableAddTableElementStatement; }
                if (parent != null)
                {
                    if ( parent.SchemaObjectName != null ) 
                    {
                        String parentName = parent.SchemaObjectName.BaseIdentifier.Value;
                        String schemaName = "";
                        if (parent.SchemaObjectName.SchemaIdentifier != null)
                        {
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

                                            //.Where( tab =>  tab.Name.Parts[1].SQLModel_StringCompareEqual(owningObjectTable)
                        //&& tab.Name.Parts[0].SQLModel_StringCompareEqual(owningObjectSchema))
                        //IEnumerable<TSqlObject> tableColumns = new List<TSqlObject>();
//                        try
                        {
                            //tableColumns = DMVSettings.tableColumns(schemaName + @"." + parentName).ToList();

                            var tableColumns = table.GetReferencedRelationshipInstances(Table.Columns)
                                .Where(n => n.Object.GetReferenced(Column.DataType).FirstOrDefault().GetProperty<bool?>(DataType.UddtNullable) == true)
                                .Select(n => n.ObjectName).ToList();

                            /*
                                    private static void ShowColumnsDataType(TSqlObject table)
                                    {
                                        foreach (var child in table.GetReferencedRelationshipInstances(Table.Columns))
                                        {
                                            var type = child.Object.GetReferenced(Column.DataType).FirstOrDefault();
                                            var isNullable = type.GetProperty<bool?> (DataType.UddtNullable);
                                            var length = type.GetProperty<int?>(DataType.UddtLength);

                                            //do something useful with this information!
                                        }
                                    }
                              */

                            if (tableColumns.Count != 0)
                            {
                                IEnumerable<ColumnWithSortOrder> nullableIndexColumns = from iCOl in indexColumns
                                                                                        from tCol in tableColumns
                                                                                        where SqlComparer.SQLModel_StringCompareEqual(iCOl.Column.MultiPartIdentifier.Identifiers[iCOl.Column.MultiPartIdentifier.Identifiers.Count-1].Value, tCol.Parts[2])
                                                                                        //where tCol.IsNullable
                                                                                        //where tCol.Object.GetReferenced(Column.DataType).FirstOrDefault().GetProperty<bool?>(DataType.UddtNullable)
                                                                                        select iCOl;

                                foreach (var c in nullableIndexColumns.ToList())
                                {
                                    issues.Add(c);
                                }
                            }
                        }
//                        catch { }
                    }
                }
            }

            // The rule execution context has all the objects we'll need, including the fragment representing the object,
            // and a descriptor that lets us access rule metadata
            RuleDescriptor ruleDescriptor = ruleExecutionContext.RuleDescriptor;

            // Create problems for each object
            foreach (TSqlFragment issue in issues)
            {
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
//using Microsoft.Data.Schema.SchemaModel.Abstract;

//using System.Linq;

//namespace Neznayka
//{
//    /// <summary>
//    /// This is a SQL rule which returns a warning message 
//    /// whenever there is a ........................................
//    /// This rule only applies to .................................
//    /// </summary>

//    [DatabaseSchemaProviderCompatibility(typeof(SqlDatabaseSchemaProvider))]
//    [DataRuleAttribute(
//        NeznaykaConstants.NameSpace,
//        NeznaykaConstants.CheckUniqueConstraintHasNoNullColumnsRuleId,
//        NeznaykaConstants.ResourceBaseName,
//        NeznaykaConstants.CheckUniqueConstraintHasNoNullColumns_RuleName,
//        NeznaykaConstants.CategoryDatabaseStructures,
//        DescriptionResourceId = NeznaykaConstants.CheckUniqueConstraintHasNoNullColumns_ProblemDescription)]
//    [SupportedElementType(typeof(ISqlProcedure))]
//    [SupportedElementType(typeof(ISqlTrigger))]
//    [SupportedElementType(typeof(ISqlTable))]
//    public class CheckUniqueConstraintHasNoNullColumnsRule : StaticCodeAnalysisRule
//    {
//        #region Overrides
//        /// <summary>
//        /// Analyze the model element
//        /// </summary>
//        public override IList<DataRuleProblem> Analyze(DataRuleSetting ruleSetting, DataRuleExecutionContext context)
//        {
//            // (Re)-Load Environment settings
//            // (Re)-Load Environment settings
//            List<DataRuleProblem> problems;
//            SqlSchemaModel sqlSchemaModel;
//            ISqlModelElement sqlElement;
//            TSqlFragment sqlFragment;
//            DMVRuleSetup.RuleSetup(context, out problems, out sqlSchemaModel, out sqlElement, out sqlFragment);

//// we probably need to alter all this if we decide to cover indexes created by code.

//            // Refresh cached index/constraints/tables lists from Model
//            DMVSettings.RefreshColumnCache(sqlSchemaModel);
//            DMVSettings.RefreshConstraintsAndIndexesCache(sqlSchemaModel);
            
//            // visitor to get the occurrences of statements that create constraints etc where we need the parent object name
//            CheckUniqueConstraintParentObjectVisitor checkUniqueConstraintParentObjectVisitor = new CheckUniqueConstraintParentObjectVisitor();
//            sqlFragment.Accept(checkUniqueConstraintParentObjectVisitor);
//            List<TSqlFragment> parentSources = checkUniqueConstraintParentObjectVisitor.Objects;

//            // visitor to get the columns
//            CheckUniqueConstraintHasNoNullColumnsVisitor checkUniqueConstraintHasNoNullColumnsVisitor = new CheckUniqueConstraintHasNoNullColumnsVisitor();
//            sqlFragment.Accept(checkUniqueConstraintHasNoNullColumnsVisitor);
//            List<ColumnWithSortOrder> indexColumns = checkUniqueConstraintHasNoNullColumnsVisitor.Objects;

//            List<TSqlFragment> issues = new List<TSqlFragment>();

//            foreach (var ps in parentSources)
//            {
//                dynamic parent = ps as CreateTableStatement;
//                if (parent == null) { parent = ps as AlterTableAddTableElementStatement; }
//                if (parent != null)
//                {
//                    if ( parent.SchemaObjectName != null ) 
//                    {
//                        String parentName = parent.SchemaObjectName.BaseIdentifier.Value;
//                        String schemaName = "";
//                        if (parent.SchemaObjectName.SchemaIdentifier != null)
//                        {
//                            schemaName = parent.SchemaObjectName.SchemaIdentifier.Value;
//                        }
//                        // tableColumns cannot be null, but can be empty if the object can't be found in the model definition.
//                        // this will happen for dynamically created objects and missing objects.
//                        List<ISqlSimpleColumn> tableColumns = new List<ISqlSimpleColumn>();
////                        try
//                        {
//                            tableColumns = DMVSettings.tableColumns(schemaName + @"." + parentName).ToList();
//                            if (tableColumns.Count != 0)
//                            {
//                                IEnumerable<ColumnWithSortOrder> nullableIndexColumns = from iCOl in indexColumns
//                                                                                        from tCol in tableColumns
//                                                                                        where SqlComparer.CompareEqual(iCOl.ColumnIdentifier.Value, tCol.Name.Parts[2])
//                                                                                        where tCol.IsNullable
//                                                                                        select iCOl;

//                                foreach (var c in nullableIndexColumns.ToList())
//                                {
//                                    issues.Add(c);
//                                }
//                            }
//                        }
////                        catch { }
//                    }
//                }
//            }
//            // Create problems for each object
//            foreach (TSqlFragment issue in issues)
//            {
//                DataRuleProblem problem = new DataRuleProblem(this,
//                                            String.Format(CultureInfo.CurrentCulture, this.RuleProperties.Description, SqlRuleUtils.GetElementName(sqlSchemaModel, sqlElement)),
//                                            sqlElement);

//                SqlRuleUtils.UpdateProblemPosition(problem, issue.StartOffset, issue.FragmentLength);
//                problems.Add(problem);
//            }


//            return problems;
//        }

//        #endregion

//    }
//}
