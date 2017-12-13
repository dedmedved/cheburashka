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


    [LocalizedExportCodeAnalysisRule(EnforceForeignKeyIsIndexedRule.RuleId,
        RuleConstants.ResourceBaseName,                                  // Name of the resource file to look up displayname and description in
        RuleConstants.EnforceForeignKeyIsIndexed_RuleName,                    // ID used to look up the display name inside the resources file
        RuleConstants.EnforceForeignKeyIsIndexed_ProblemDescription,          // ID used to look up the description inside the resources file
        Category = RuleConstants.CategoryDatabaseStructures,             // Rule category (e.g. "Design", "Naming")
        RuleScope = SqlRuleScope.Element)]                               // This rule targets specific elements rather than the whole model
    public sealed class EnforceForeignKeyIsIndexedRule : SqlCodeAnalysisRule
    {

        /// <summary>
        /// The Rule ID should resemble a fully-qualified class name. In the Visual Studio UI
        /// rules are grouped by "Namespace + Category", and each rule is shown using "Short ID: DisplayName".
        /// For this rule, it will be 
        /// shown as "DM0012: Tables should normally be clustered and not heap."
        /// </summary>
        public const string RuleId = RuleConstants.EnforceForeignKeyIsIndexedRuleId;

        public EnforceForeignKeyIsIndexedRule()
        {
            // This rule supports Tables. Only those objects will be passed to the Analyze method
            SupportedElementTypes = new[]
            {
                // Note: can use the ModelSchema definitions, or access the TypeClass for any of these types
                ModelSchema.ForeignKeyConstraint
            };
        }

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext ruleExecutionContext)
        {
            // Get Model collation 
            SqlComparer.Comparer = ruleExecutionContext.SchemaModel.CollationComparer;

            List<SqlRuleProblem> problems = new List<SqlRuleProblem>();
            TSqlModel model;
            TSqlObject modelElement;
            TSqlFragment sqlFragment;

            DMVRuleSetup.RuleSetup(ruleExecutionContext, out problems, out model, out sqlFragment, out modelElement);

            string elementName = RuleUtils.GetElementName(ruleExecutionContext, modelElement);

            DMVSettings.RefreshModelBuiltInCache(model);

            EnforceForeignKeyIsIndexedParentObjectVisitor enforceForeignKeyIsIndexedParentObjectVisitor =
                new EnforceForeignKeyIsIndexedParentObjectVisitor();
            sqlFragment.Accept(enforceForeignKeyIsIndexedParentObjectVisitor);

            // Get Database Schema and name of this model element.
            SchemaObjectName parentTable = enforceForeignKeyIsIndexedParentObjectVisitor.Objects;
            string owningObjectTable = parentTable.BaseIdentifier.Value;
            string owningObjectSchema = parentTable.SchemaIdentifier.Value;

            EnforceForeignKeyIsIndexedColumnsVisitor enforceForeignKeyIsIndexedColumnsVisitor =
                new EnforceForeignKeyIsIndexedColumnsVisitor();
            sqlFragment.Accept(enforceForeignKeyIsIndexedColumnsVisitor);
            IList<Identifier> columns = enforceForeignKeyIsIndexedColumnsVisitor.Objects;

            var allIndexes =
                model.GetObjects(DacQueryScopes.UserDefined, Index.TypeClass)
                    .ToList(); //.Where( n => n.GetReferenced(Index.IndexedObject).ToList()[0].Name.Parts[1].SQLModel_StringCompareEqual(owningObjectTable))
            var theseIndexes = new List<TSqlObject>();

            foreach (var thing in allIndexes)
            {
                TSqlObject tab = thing.GetReferenced(Index.IndexedObject).ToList()[0];
                if (tab.Name.Parts[1].SQLModel_StringCompareEqual(owningObjectTable)
                    && tab.Name.Parts[0].SQLModel_StringCompareEqual(owningObjectSchema)
                )
                {
                    theseIndexes.Add(tab);
                }
            }

            var allPKs = model.GetObjects(DacQueryScopes.UserDefined, PrimaryKeyConstraint.TypeClass).ToList();
            var thesePK = new List<TSqlObject>();
            foreach (var thing in allPKs)
            {
                TSqlObject tab = thing.GetReferenced(PrimaryKeyConstraint.Host).ToList()[0];
                if (tab.Name.Parts[1].SQLModel_StringCompareEqual(owningObjectTable)
                    && tab.Name.Parts[0].SQLModel_StringCompareEqual(owningObjectSchema)
                )
                {
                    thesePK.Add(tab);
                    break;
                }
            }

            var allUNs = model.GetObjects(DacQueryScopes.UserDefined, UniqueConstraint.TypeClass).ToList();
            var theseUN = new List<TSqlObject>();
            foreach (var thing in allUNs)
            {
                TSqlObject tab = thing.GetReferenced(UniqueConstraint.Host).ToList()[0];
                if (tab.Name.Parts[1].SQLModel_StringCompareEqual(owningObjectTable)
                    && tab.Name.Parts[0].SQLModel_StringCompareEqual(owningObjectSchema)
                )
                {
                    thesePK.Add(tab);
                }
            }


        }


        private static bool checkThatForeignKeysAreCoveredByIndex(List<String> ClusterColumns, List<String> ForeignKeyColumns, bool ForeignKeyIsIndexed, List<String> LeadingEdgeIndexColumns) {
            bool foundIndexThatMatchesAKey = false;

            List<Int32> allPos = ModelIndexAndKeysUtils.getCorrespondingKeyPositions(ForeignKeyColumns, LeadingEdgeIndexColumns);
            List<Int32> matchedPos = allPos.Where(n => n != -1).Select(n => n).ToList();

            // if every fk column was found in the index
            // and found within the leading n columns, we're ok.
            // we assume no duplicate columns in the fk or index.
            // adjusted for 0-based arrays
            if (matchedPos.Count == allPos.Count
                && matchedPos.Count > 0
                && matchedPos.Count - 1 == matchedPos.Max()
                ) {
                foundIndexThatMatchesAKey = true;
            }
            // else if *this* particular index is not clustered and there *are* clustered columns 
            // check that any remaining unmatched keys can be found in the included columns.
            // whilst ensuring all columns we have found live in the first n columns in the index.
            else if (!ForeignKeyIsIndexed && ClusterColumns.Count > 0) {
                // the leading edge columns must still have been found in the first n columns of the index
                // and there must be no other trailing elements in the actual key of the index.
                // and I'm still making these rules up on the fly.
                // adjusted for 0-based arrays
                if (matchedPos.Count == LeadingEdgeIndexColumns.Count()
                    && matchedPos.Count > 0
                    && matchedPos.Count - 1 == matchedPos.Max()
                    ) {
                    String[] arForeignKeyColumns = ForeignKeyColumns.ToArray();
                    List<String> unMatchedForeignKeyColumns = new List<String>();
                    for (int i = 0; i < allPos.Count; i++) {
                        if (allPos[i] == -1) {
                            unMatchedForeignKeyColumns.Add(arForeignKeyColumns[i]);
                        }
                    }

                    List<Int32> remainingPos = ModelIndexAndKeysUtils.getCorrespondingKeyPositions(unMatchedForeignKeyColumns, ClusterColumns);
                    List<Int32> remainingAndMatchedToClusteringKeyPos = remainingPos.Where(n => n != -1).Select(n => n).ToList();

                    // if we found all the unmatched columns in the cluster key we're home and dry !
                    if (remainingAndMatchedToClusteringKeyPos.Count == remainingPos.Count) {
                        foundIndexThatMatchesAKey = true;
                    }
                }
            }

            return foundIndexThatMatchesAKey;
        }

        //public override IList<DataRuleProblem> Analyze(DataRuleSetting ruleSetting, DataRuleExecutionContext context) {
        //    // (Re)-Load Environment settings

        //    List<DataRuleProblem> problems;
        //    SqlSchemaModel sqlSchemaModel;
        //    ISqlModelElement sqlElement;
        //    TSqlFragment sqlFragment;
        //    DMVRuleSetup.RuleSetup(context, out problems, out sqlSchemaModel, out sqlElement, out sqlFragment);

        //    // Refresh cached index/constraints/tables lists from Model
        //    DMVRuleSetup.RefreshDDLCache(sqlSchemaModel);

        //    ISqlForeignKeyConstraint self = sqlElement as ISqlForeignKeyConstraint;

        //    if (self != null) {
        //        //string selfSchema = self.Name.Parts[0];
        //        //string selfTable  = self.Name.Parts[1];

        //        // Get Database Schema and name of this model element.
        //        string owningObjectSchema = self.DefiningTable.Name.Parts[0];
        //        string owningObjectTable = self.DefiningTable.Name.Parts[1];

        //        List<ISqlPrimaryKeyConstraint> pks = ModelIndexAndKeysUtils.getPrimaryKeys(owningObjectSchema, owningObjectTable);
        //        List<ISqlIndex> indexes = ModelIndexAndKeysUtils.getIndexes(owningObjectSchema, owningObjectTable);
        //        List<ISqlUniqueConstraint> uniqueConstraints = ModelIndexAndKeysUtils.getUniqueConstraints(owningObjectSchema, owningObjectTable);

        //        bool indexExists = (indexes.Count > 0);
        //        bool uniqueConstraintExists = (uniqueConstraints.Count > 0);
        //        bool primaryKeyExists = (pks.Count > 0);

        //        List<String> ClusterColumns = ModelIndexAndKeysUtils.getClusteredKeyColumns(owningObjectSchema, owningObjectTable);

        //        List<TSqlFragment> issues = new List<TSqlFragment>();

        //        bool foundIndexThatMatchesAKey = false;
        //        if (indexExists || uniqueConstraintExists || primaryKeyExists) {
        //            List<String> ForeignKeyColumns = self.Columns.Select(n => n.Name.Parts[2]).ToList();

        //            if (indexExists) {
        //                foreach (var index in indexes) {
        //                    List<String> LeadingEdgeIndexColumns = new List<String>();
        //                    foreach (var c in index.ColumnSpecifications) {
        //                        String lastElement = "";
        //                        foreach (var n in c.Column.Name.Parts) {
        //                            lastElement = n;
        //                        }
        //                        LeadingEdgeIndexColumns.Add(lastElement);
        //                    }
        //                    foundIndexThatMatchesAKey = checkThatForeignKeysAreCoveredByIndex(ClusterColumns, ForeignKeyColumns, index.IsClustered, LeadingEdgeIndexColumns);
        //                    if (foundIndexThatMatchesAKey) {
        //                        break;
        //                    }
        //                }
        //            }
        //            if (uniqueConstraintExists && !foundIndexThatMatchesAKey) {
        //                foreach (var constraint in uniqueConstraints) {
        //                    List<String> LeadingEdgeIndexColumns = new List<String>();
        //                    foreach (var c in constraint.ColumnSpecifications) {
        //                        String lastElement = "";
        //                        foreach (var n in c.Column.Name.Parts) {
        //                            lastElement = n;
        //                        }
        //                        LeadingEdgeIndexColumns.Add(lastElement);
        //                    }
        //                    foundIndexThatMatchesAKey = checkThatForeignKeysAreCoveredByIndex(ClusterColumns, ForeignKeyColumns, constraint.IsClustered, LeadingEdgeIndexColumns);
        //                    if (foundIndexThatMatchesAKey) {
        //                        break;
        //                    }
        //                }
        //            }
        //            if (primaryKeyExists && !foundIndexThatMatchesAKey) {
        //                foreach (var pk in pks) {
        //                    List<String> LeadingEdgeIndexColumns = new List<String>();
        //                    foreach (var c in pk.ColumnSpecifications) {
        //                        String lastElement = "";
        //                        foreach (var n in c.Column.Name.Parts) {
        //                            lastElement = n;
        //                        }
        //                        LeadingEdgeIndexColumns.Add(lastElement);
        //                    }
        //                    foundIndexThatMatchesAKey = checkThatForeignKeysAreCoveredByIndex(ClusterColumns, ForeignKeyColumns, pk.IsClustered, LeadingEdgeIndexColumns);
        //                    if (foundIndexThatMatchesAKey) {
        //                        break;
        //                    }
        //                }
        //            }
        //        }

        //        if (!foundIndexThatMatchesAKey) {
        //            issues.Add(sqlFragment);
        //        }


        //        // Create problems for each object
        //        foreach (TSqlFragment issue in issues) {
        //            DataRuleProblem problem = new DataRuleProblem(this,
        //                                        String.Format(CultureInfo.CurrentCulture, this.RuleProperties.Description, SqlRuleUtils.GetElementName(sqlSchemaModel, sqlElement)),
        //                                        sqlElement);

        //            SqlRuleUtils.UpdateProblemPosition(problem, issue.StartOffset, issue.FragmentLength);
        //            problems.Add(problem);
        //        }

        //    }

        //    return problems;
        //}

        //private static bool checkThatForeignKeysAreCoveredByIndex(List<String> ClusterColumns, List<String> ForeignKeyColumns, bool ForeignKeyIsIndexed, List<String> LeadingEdgeIndexColumns) {
        //    bool foundIndexThatMatchesAKey = false;

        //    List<Int32> allPos = ModelIndexAndKeysUtils.getCorrespondingKeyPositions(ForeignKeyColumns, LeadingEdgeIndexColumns);
        //    List<Int32> matchedPos = allPos.Where(n => n != -1).Select(n => n).ToList();

        //    // if every fk column was found in the index
        //    // and found within the leading n columns, we're ok.
        //    // we assume no duplicate columns in the fk or index.
        //    // adjusted for 0-based arrays
        //    if (matchedPos.Count == allPos.Count
        //        && matchedPos.Count > 0
        //        && matchedPos.Count - 1 == matchedPos.Max()
        //        ) {
        //        foundIndexThatMatchesAKey = true;
        //    }
        //    // else if *this* particular index is not clustered and there *are* clustered columns 
        //    // check that any remaining unmatched keys can be found in the included columns.
        //    // whilst ensuring all columns we have found live in the first n columns in the index.
        //    else if (!ForeignKeyIsIndexed && ClusterColumns.Count > 0) {
        //        // the leading edge columns must still have been found in the first n columns of the index
        //        // and there must be no other trailing elements in the actual key of the index.
        //        // and I'm still making these rules up on the fly.
        //        // adjusted for 0-based arrays
        //        if (matchedPos.Count == LeadingEdgeIndexColumns.Count()
        //            && matchedPos.Count > 0
        //            && matchedPos.Count - 1 == matchedPos.Max()
        //            ) {
        //            String[] arForeignKeyColumns = ForeignKeyColumns.ToArray();
        //            List<String> unMatchedForeignKeyColumns = new List<String>();
        //            for (int i = 0; i < allPos.Count; i++) {
        //                if (allPos[i] == -1) {
        //                    unMatchedForeignKeyColumns.Add(arForeignKeyColumns[i]);
        //                }
        //            }

        //            List<Int32> remainingPos = ModelIndexAndKeysUtils.getCorrespondingKeyPositions(unMatchedForeignKeyColumns, ClusterColumns);
        //            List<Int32> remainingAndMatchedToClusteringKeyPos = remainingPos.Where(n => n != -1).Select(n => n).ToList();

        //            // if we found all the unmatched columns in the cluster key we're home and dry !
        //            if (remainingAndMatchedToClusteringKeyPos.Count == remainingPos.Count) {
        //                foundIndexThatMatchesAKey = true;
        //            }
        //        }
        //    }

        //    return foundIndexThatMatchesAKey;
        //}

        //#endregion

    }
}
