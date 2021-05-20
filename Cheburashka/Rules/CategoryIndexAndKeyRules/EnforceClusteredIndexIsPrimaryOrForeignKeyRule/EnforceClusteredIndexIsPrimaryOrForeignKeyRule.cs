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
using Microsoft.SqlServer.Dac.CodeAnalysis;
using Microsoft.SqlServer.Dac.Model;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;


namespace Cheburashka
{
    /// <summary>
    /// <para>
    /// This is a SQL rule which returns a warning message 
    /// whenever there is an clustered index which is not a primary or foreign key
    /// </para>
    /// <para>
    /// Note that this uses a Localized export attribute, and hence the rule name and description will be
    /// localized if resource files for different languages are used
    /// </para>
    /// </summary>

    [LocalizedExportCodeAnalysisRule(EnforceClusteredIndexIsPrimaryOrForeignKeyRule.RuleId,
        RuleConstants.ResourceBaseName,                                                 // Name of the resource file to look up displayname and description in
        RuleConstants.EnforceClusteredIndexIsPrimaryOrForeignKey_RuleName,                   // ID used to look up the display name inside the resources file
        RuleConstants.EnforceClusteredIndexIsPrimaryOrForeignKey_ProblemDescription,         // ID used to look up the description inside the resources file
        Category = RuleConstants.CategoryDatabaseStructures,                            // Rule category (e.g. "Design", "Naming")
        RuleScope = SqlRuleScope.Element)]                                              // This rule targets specific elements rather than the whole model
    public sealed class EnforceClusteredIndexIsPrimaryOrForeignKeyRule : SqlCodeAnalysisRule
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
        public const string RuleId = RuleConstants.EnforceClusteredIndexIsPrimaryOrForeignKeyRuleId;

        public EnforceClusteredIndexIsPrimaryOrForeignKeyRule()
        {
            SupportedElementTypes = SqlRuleUtils.GetTableClass();
        }

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext ruleExecutionContext)
        {
            static List<string> ExtractLeadingEdgeColumns(IEnumerable<ModelRelationshipInstance> columnSpecifications)
            {
                List<string> LeadingEdgeIndexColumns = new();
                foreach (var c in columnSpecifications)
                {
                    string lastElement = c.ObjectName.Parts.Last();
                    LeadingEdgeIndexColumns.Add(lastElement);
                }

                var SortedLeadingEdgeIndexColumns = LeadingEdgeIndexColumns.OrderBy(col => col, SqlComparer.Comparer).Select(n => n)
                    .ToList();
                return SortedLeadingEdgeIndexColumns;
            }

            // Get Model collation 
            SqlComparer.Comparer = ruleExecutionContext.SchemaModel.CollationComparer;

            List<SqlRuleProblem> problems = new();

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

                // Get Database Schema and name of this model element.
                string owningObjectSchema = modelElement.Name.Parts[0];
                string owningObjectTable = modelElement.Name.Parts[1];

                DMVSettings.RefreshModelBuiltInCache(model);

                // Refresh cached index/constraints/tables lists from Model
                DMVSettings.RefreshConstraintsAndIndexesCache(model);

                List<TSqlObject> pks = ModelIndexAndKeysUtils.GetPrimaryKeys(owningObjectSchema, owningObjectTable);
                List<TSqlObject> clusteredpks =
                    ModelIndexAndKeysUtils.GetClusteredPrimaryKeys(owningObjectSchema, owningObjectTable);
                List<TSqlObject> foreignkeyconstraints =
                    ModelIndexAndKeysUtils.GetForeignKeys(owningObjectSchema, owningObjectTable);
                List<TSqlObject> clusteredindexes =
                    ModelIndexAndKeysUtils.GetClusteredIndexes(owningObjectSchema, owningObjectTable);
                List<TSqlObject> uniqueClusterConstraints =
                    ModelIndexAndKeysUtils.GetClusteredUniqueConstraints(owningObjectSchema, owningObjectTable);

                bool clusteredindexExists = (clusteredindexes.Count > 0);
                bool clusteredUniqueConstraintExists = (uniqueClusterConstraints.Count > 0);
                bool clusteredPrimaryKeyExists = (clusteredpks.Count > 0);

                bool primaryKeyExists = (pks.Count > 0);
                bool foreignKeyExists = (foreignkeyconstraints.Count > 0);

                bool foundKeyThatMatchesACluster = false;

                // only if all these conditions are true do we need to check for rule violations.
                if (   (primaryKeyExists || foreignKeyExists)
                    && (clusteredPrimaryKeyExists || clusteredindexExists || clusteredUniqueConstraintExists)
                )
                {
                    if (clusteredPrimaryKeyExists)
                    {
                        foundKeyThatMatchesACluster = true;
                    }
                    // no clustered pk but a pk does exist and a clustered something exists check it
                    else if (primaryKeyExists && (clusteredindexExists || clusteredUniqueConstraintExists))
                    {
                        bool match = false;
                        {
                            List<string> SortedLeadingEdgeIndexColumns = new();

                            if (clusteredindexExists || clusteredUniqueConstraintExists)
                            {
                                TSqlObject clusteredindex = clusteredindexExists ? clusteredindexes[0] : uniqueClusterConstraints[0];
                                ModelRelationshipClass relationshipClass = clusteredindexExists ? Index.ColumnsRelationship.RelationshipClass : UniqueConstraint.ColumnsRelationship.RelationshipClass;
                                IEnumerable<ModelRelationshipInstance> columnSpecifications;
                                columnSpecifications = clusteredindex.GetReferencedRelationshipInstances(relationshipClass, DacQueryScopes.UserDefined);
                                SortedLeadingEdgeIndexColumns = ExtractLeadingEdgeColumns(columnSpecifications);
                            }

                            //We might have a clustered index etc on the same columns as a primary key.
                            // now check the foreign key columns against the relevant clustered 'index''s columns
                            foreach (var pk in pks)
                            {
                                var columnSpecifications =
                                    pk.GetReferencedRelationshipInstances(PrimaryKeyConstraint.Columns,
                                        DacQueryScopes.UserDefined);
                                List<string> sortedPrimaryKeyColumns = columnSpecifications
                                    .OrderBy(col => col.ObjectName.Parts[2], SqlComparer.Comparer)
                                    .Select(n => n.ObjectName.Parts[2]).ToList();
                                if (SortedLeadingEdgeIndexColumns.Count >= sortedPrimaryKeyColumns.Count)
                                {
                                    List<string> leadingCols = SortedLeadingEdgeIndexColumns
                                        .Take(sortedPrimaryKeyColumns.Count).ToList();
                                    if (leadingCols.SequenceEqual(sortedPrimaryKeyColumns, SqlComparer.Comparer))
                                    {
                                        match = true;
                                        break;
                                    }
                                }
                            }
                        }
                        foundKeyThatMatchesACluster = match;
                    }

                    if (!foundKeyThatMatchesACluster)
                    {
                        // try to find a foreign key that we might be clustering on, to tick it off as OK.
                        if (foreignkeyconstraints.Count > 0)
                        {
                            bool match = false;
                            if (clusteredindexExists || clusteredUniqueConstraintExists || clusteredPrimaryKeyExists)
                            {
                                List<string> SortedLeadingEdgeIndexColumns = new();

                                {
                                    ModelRelationshipClass modelRelationshipClass = (clusteredindexExists) ? Index.ColumnsRelationship.RelationshipClass
                                    : (clusteredUniqueConstraintExists) ? UniqueConstraint.ColumnsRelationship.RelationshipClass
                                    : (clusteredPrimaryKeyExists) ? PrimaryKeyConstraint.ColumnsRelationship.RelationshipClass
                                    : null
                                    ;
                                    TSqlObject idxOrConstraint = (clusteredindexExists) ? clusteredindexes[0]
                                    : (clusteredUniqueConstraintExists) ? uniqueClusterConstraints[0]
                                    : (clusteredPrimaryKeyExists) ? clusteredpks[0]
                                    : null
                                    ;

                                    IEnumerable<ModelRelationshipInstance> columnSpecifications = idxOrConstraint.GetReferencedRelationshipInstances(modelRelationshipClass, DacQueryScopes.UserDefined);
                                    SortedLeadingEdgeIndexColumns = ExtractLeadingEdgeColumns(columnSpecifications);
                                }

                                //We might have a clustered index etc on the same columns as a primary key.
                                // now check the foreign key columns against the relevant clustered 'index''s columns
                                foreach (var fc in foreignkeyconstraints)
                                {
                                    var columnSpecifications =
                                        fc.GetReferencedRelationshipInstances(ForeignKeyConstraint.Columns,
                                            DacQueryScopes.UserDefined);
                                    // consider a foreign key to be clustered if all its columns appear as the first n columns in a
                                    // clustered index, clustered unique constraint or clustered primary key constraint.
                                    // nb a primary key can be a foreign key too when modeling 1:1 relationships.
                                    List<string> SortedForeignKeyColumns = columnSpecifications
                                        .OrderBy(col => col.ObjectName.Parts[2], SqlComparer.Comparer)
                                        .Select(n => n.ObjectName.Parts[2]).ToList();
                                    if (SortedLeadingEdgeIndexColumns.Count >= SortedForeignKeyColumns.Count)
                                    {
                                        List<string> leadingCols = SortedLeadingEdgeIndexColumns
                                            .Take(SortedForeignKeyColumns.Count).ToList();
                                        if (leadingCols.SequenceEqual(SortedForeignKeyColumns, SqlComparer.Comparer))
                                        {
                                            match = true;
                                            break;
                                        }
                                    }
                                }
                            }
                            foundKeyThatMatchesACluster = match;
                        }
                    }
                }
                // only if all these conditions are true do we need to check for rule violations.
                // otherwise by default it's a trivial success
                else
                {
                    foundKeyThatMatchesACluster = true;
                }

                // The rule execution context has all the objects we'll need, including the fragment representing the object,
                // and a descriptor that lets us access rule metadata
                RuleDescriptor ruleDescriptor = ruleExecutionContext.RuleDescriptor;
                RuleUtils.UpdateProblems(!foundKeyThatMatchesACluster,problems, modelElement, elementName, sqlFragment, ruleDescriptor);

            }
            catch { } // DMVRuleSetup.RuleSetup barfs on 'hidden' temporal history tables 'defined' in sub-projects

            return problems;
        }
    }
}