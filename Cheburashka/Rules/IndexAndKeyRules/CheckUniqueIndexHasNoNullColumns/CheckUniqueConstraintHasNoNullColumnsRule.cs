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
    /// <para>
    /// This is a SQL rule which returns a warning message 
    /// whenever there is an un-clustered table in a model.
    /// </para>
    /// <para>
    /// Note that this uses a Localized export attribute, and hence the rule name and description will be
    /// localized if resource files for different languages are used
    /// </para>
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
        /// <para>
        /// The Rule ID should resemble a fully-qualified class name. In the Visual Studio UI
        /// rules are grouped by "Namespace + Category", and each rule is shown using "Short ID: DisplayName".
        /// </para>
        /// <para>
        /// For this rule, it will be 
        /// shown as "DM0018: Tables should normally be clustered and not heap."
        /// </para>
        /// </summary>
        public const string RuleId = RuleConstants.CheckUniqueConstraintHasNoNullColumnsRuleId;

        public CheckUniqueConstraintHasNoNullColumnsRule()
        {
            // This rule supports Tables. Only those objects will be passed to the Analyze method
            SupportedElementTypes = new[]
            {
                // Note: can use the ModelSchema definitions, or access the TypeClass for any of these types
                ModelSchema.Table
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
            try
            {
                DMVRuleSetup.RuleSetup(ruleExecutionContext, out problems, out TSqlModel model,
                    out TSqlFragment sqlFragment, out TSqlObject modelElement);
                string elementName = RuleUtils.GetElementName(ruleExecutionContext, modelElement);

                // If we can't find the file then assume we're in a composite model
                // and the elements are defined there and
                // should be analysed there
                if (modelElement.GetSourceInformation() is null)
                {
                    return problems;
                }

                DMVSettings.RefreshModelBuiltInCache(model);
                // Refresh cached index/constraints/tables lists from Model
                //DMVSettings.RefreshColumnCache(model);
                DMVSettings.RefreshConstraintsAndIndexesCache(model);

                var allIndexes = model.GetObjects(DacQueryScopes.UserDefined, Index.TypeClass).ToList();

                // visitor to get the occurrences of statements that create constraints etc where we need the parent object name
                CheckUniqueConstraintParentObjectVisitor checkUniqueConstraintParentObjectVisitor =
                    new CheckUniqueConstraintParentObjectVisitor();
                sqlFragment.Accept(checkUniqueConstraintParentObjectVisitor);
                List<TSqlFragment> parentSources = checkUniqueConstraintParentObjectVisitor.Objects;

                // visitor to get the columns
                CheckUniqueConstraintHasNoNullColumnsVisitor checkUniqueConstraintHasNoNullColumnsVisitor =
                    new CheckUniqueConstraintHasNoNullColumnsVisitor();
                sqlFragment.Accept(checkUniqueConstraintHasNoNullColumnsVisitor);
                List<ColumnWithSortOrder> indexColumns = checkUniqueConstraintHasNoNullColumnsVisitor.Objects;

                var issues = new List<TSqlFragment>();

                foreach (var ps in parentSources)
                {
                    dynamic parent = ps as CreateTableStatement;
                    if (parent == null)
                    {
                        parent = ps as AlterTableAddTableElementStatement;
                    }

                    if (parent != null)
                    {
                        if (parent.SchemaObjectName != null)
                        {
                            string parentName = parent.SchemaObjectName.BaseIdentifier.Value;
                            string schemaName = "";
                            if (parent.SchemaObjectName.SchemaIdentifier != null)
                            {
                                schemaName = parent.SchemaObjectName.SchemaIdentifier.Value;
                            }

                            // tableColumns cannot be null, but can be empty if the object can't be found in the model definition.
                            // this will happen for dynamically created objects and missing objects.
                            //TSqlObject table = model.GetObjects(DacQueryScopes.UserDefined, Table.TypeClass).ToList();
                            IEnumerable<TSqlObject> tables = model
                                    .GetObjects(DacQueryScopes.UserDefined, Table.TypeClass)
                                    .Where(n => n.Name.Parts[0].SQLModel_StringCompareEqual(schemaName) &&
                                                n.Name.Parts[1].SQLModel_StringCompareEqual(parentName))
                                ;
                            TSqlObject table = tables.SingleOrDefault();

                            try
                            {
                                var tableColumns = table.GetReferencedRelationshipInstances(Table.Columns)
                                    .Where(n => n.Object.GetProperty<bool?>(Column.Nullable) == true)
                                    .Select(n => n.ObjectName).ToList();

                                if (tableColumns.Count != 0)
                                {
                                    IEnumerable<ColumnWithSortOrder> nullableIndexColumns = from iCOl in indexColumns
                                        from tCol in tableColumns
                                        where SqlComparer.SQLModel_StringCompareEqual(
                                            iCOl.Column.MultiPartIdentifier
                                                .Identifiers[iCOl.Column.MultiPartIdentifier.Identifiers.Count - 1]
                                                .Value, tCol.Parts[2])
                                        //where tCol.IsNullable
                                        //where tCol.Object.GetReferenced(Column.DataType).FirstOrDefault().GetProperty<bool?>(DataType.UddtNullable)
                                        select iCOl;

                                    foreach (var c in nullableIndexColumns)
                                    {
                                        issues.Add(c);
                                    }
                                }
                            }
                            catch
                            {
                            }
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
                            string.Format(CultureInfo.CurrentCulture, ruleDescriptor.DisplayDescription, elementName)
                            , modelElement
                            , sqlFragment);

                    //RuleUtils.UpdateProblemPosition(modelElement, problem, ((Identifier) objects[key]));
                    problems.Add(problem);
                }
            }
            catch
            {
            } // DMVRuleSetup.RuleSetup barfs on 'hidden' temporal history tables 'defined' in sub-projects

            return problems;
        }
    }
}





