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
using Microsoft.SqlServer.Dac.CodeAnalysis;
using Microsoft.SqlServer.Dac.Model;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System.Collections.Generic;
using System.Linq;

namespace Cheburashka
{
    /// <summary>
    /// <para>
    /// This is a SQL rule which returns a warning message 
    /// whenever there is a potential duplicate index or constraint in a model.
    /// </para> 
    /// <para>
    /// Note that this uses a Localized export attribute, and hence the rule name and description will be
    /// localized if resource files for different languages are used
    /// </para>
    /// </summary>

    [LocalizedExportCodeAnalysisRule(EnforceIndexKeyColumnSeparationRule.RuleId,
        RuleConstants.ResourceBaseName,                                     // Name of the resource file to look up displayname and description in
        RuleConstants.EnforceIndexKeyColumnSeparationRuleName,              // ID used to look up the display name inside the resources file
        RuleConstants.EnforceIndexKeyColumnSeparationProblemDescription,    // ID used to look up the description inside the resources file
        Category = RuleConstants.CategoryDatabaseStructures,                // Rule category (e.g. "Design", "Naming")
        RuleScope = SqlRuleScope.Element)]                                  // This rule targets specific elements rather than the whole model
    public sealed class EnforceIndexKeyColumnSeparationRule : SqlCodeAnalysisRule
    {
        /// <summary>
        /// <para>
        /// The Rule ID should resemble a fully-qualified class name. In the Visual Studio UI
        /// rules are grouped by "Namespace + Category", and each rule is shown using "Short ID: DisplayName".
        /// </para>
        /// <para>
        /// For this rule, it will be 
        /// shown as "DM0016: Avoid indexes with keys that are just a permutation of another key, or form the leading edge of another key."
        /// </para>
        /// </summary>
        public const string RuleId = RuleConstants.EnforceIndexKeyColumnSeparationRuleId;

        public EnforceIndexKeyColumnSeparationRule()
        {
            SupportedElementTypes = SqlRuleUtils.GetIndexClass();
        }

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext ruleExecutionContext)
        {
            // Get Model collation 
            SqlComparer.Comparer = ruleExecutionContext.SchemaModel.CollationComparer;

            List<SqlRuleProblem> problems = new();

            try
            {
                DmvRuleSetup.RuleSetup(ruleExecutionContext, out problems, out TSqlModel model, out TSqlFragment sqlFragment, out TSqlObject modelElement);
                string elementName = RuleUtils.GetElementName(ruleExecutionContext);

                // If we can't find the file then assume we're in a composite model
                // and the elements are defined there and
                // should be analysed there
                if (modelElement.GetSourceInformation() is null)
                {
                    return problems;
                }

                DmvSettings.RefreshModelBuiltInCache(model);
                DmvSettings.RefreshConstraintsAndIndexesCache(model);

                string indexSchema = modelElement.Name.Parts[0];
                string indexName = modelElement.Name.Parts[2]; 

                var owningObject = modelElement.GetParent(DacQueryScopes.All);
                var owningObjectSchema = owningObject.Name.Parts[0];
                var owningObjectTable = owningObject.Name.Parts[1];

                var pks = ModelIndexAndKeysUtils.GetPrimaryKeys(owningObjectSchema, owningObjectTable);
                var indexes = ModelIndexAndKeysUtils.GetIndexes(owningObjectSchema, owningObjectTable);
                var uniqueConstraints = ModelIndexAndKeysUtils.GetUniqueConstraints(owningObjectSchema, owningObjectTable);

                var indexColumns = modelElement.GetReferenced(Index.Columns).Select(n => n.Name.Parts.Last()).ToList();

                var thisIndexHasIncludedColumns = modelElement.GetReferenced(Index.IncludedColumns).Any();
                var thisIndexIncludedColumns = modelElement.GetReferenced(Index.IncludedColumns).Select(n => n.Name.Parts.Last()).ToList();;

                List<string> clusteringIndexColumns = new();

                TSqlObject clusteredObject; // create dummy tsqlobject
                var    tableIsClustered = ExtractClusteredDetails(pks,PrimaryKeyConstraint.Clustered,PrimaryKeyConstraint.Columns,out clusteredObject, ref clusteringIndexColumns);
                if (!tableIsClustered) 
                    tableIsClustered = ExtractClusteredDetails(indexes,Index.Clustered,Index.Columns, out clusteredObject, ref clusteringIndexColumns);
                if (!tableIsClustered) 
                    tableIsClustered = ExtractClusteredDetails(uniqueConstraints,UniqueConstraint.Clustered,UniqueConstraint.Columns, out clusteredObject, ref clusteringIndexColumns);
                
                TSqlObject MoreGeneralIndexDefinition = owningObject; // create a dummy object to receive index definition - clone from a random other TSqlObject
                                                               // probably ver ver very bad practice

                var foundMoreGeneralIndex = FindMoreGeneralIndex(owningObject, indexColumns, pks, PrimaryKeyConstraint.Columns, ref MoreGeneralIndexDefinition,thisIndexIncludedColumns);
                if (!foundMoreGeneralIndex)
                    foundMoreGeneralIndex = FindMoreGeneralIndex(owningObject, indexColumns, indexes, Index.Columns, ref MoreGeneralIndexDefinition,thisIndexIncludedColumns,indexSchema,indexName);
                if (!foundMoreGeneralIndex)
                    foundMoreGeneralIndex = FindMoreGeneralIndex(owningObject, indexColumns, uniqueConstraints, UniqueConstraint.Columns, ref MoreGeneralIndexDefinition,thisIndexIncludedColumns);

                var clusteredIndexIsASupersetOfThisIndex = tableIsClustered && ThisIndexIsContainedByTheOtherIndex(indexColumns, clusteringIndexColumns);

                var issues = new List<TSqlFragment>();
                // is this right ? - it always makes my head hurt
                if (foundMoreGeneralIndex && ! ( clusteredIndexIsASupersetOfThisIndex && thisIndexHasIncludedColumns && Equals(MoreGeneralIndexDefinition, clusteredObject)) )
                    issues.Add(sqlFragment);


                RuleDescriptor ruleDescriptor = ruleExecutionContext.RuleDescriptor;
                RuleUtils.UpdateProblems(problems, modelElement, elementName, issues, ruleDescriptor);

            }
            catch (Exception e)
            { } // DMVRuleSetup.RuleSetup barfs on 'hidden' temporal history tables 'defined' in sub-projects

            return problems;
        }

        private static bool ExtractClusteredDetails(List<TSqlObject> sqlObjects, ModelPropertyClass modelPropertyClass, ModelRelationshipClass modelRelationshipClass, out TSqlObject clusteredObject, ref List<string> clusteringIndexColumns)
        {
            var tableIsClustered = sqlObjects.Any(n => (bool)n.GetProperty(modelPropertyClass));
            clusteredObject = sqlObjects.FirstOrDefault(n => (bool)n.GetProperty(modelPropertyClass));
            // sweep these up into a common method (eventually)
            if (tableIsClustered && clusteredObject != null)
            {
                var structureObjColumns = clusteredObject.GetReferenced(modelRelationshipClass);
                clusteringIndexColumns = structureObjColumns.Select(c => c.Name.Parts.Last()).ToList();
            }

            return tableIsClustered;
        }

        private static bool FindMoreGeneralIndex(TSqlObject owningObject, List<string> thisIndexesLeadingEdgeColumns, List<TSqlObject> otherStructureObjects, ModelRelationshipClass modelRelationshipClass, ref TSqlObject IndexDefinition, List<string> IndexIncludedColumns, string indexSchema = null, string indexName = null)
        {
            var foundMoreGeneralIndex = false;
            foreach (var v in otherStructureObjects)
            {
                // have to handle indexes differently to pks/uniq constraints - in a separate sub-clause in the IF
                // due to differently implemented naming conventions/ structures
                if (modelRelationshipClass == Index.Columns && !(SqlRuleUtils.ObjectNameMatches(v, owningObject.Name.Parts[1], indexSchema)
                                                                 && indexName.SQLModel_StringCompareEqual(v.Name.Parts[2])
                        )
                || !v.Name.HasName || !SqlRuleUtils.ObjectNameMatches(v, owningObject)
               )
                {
                    var structureObjColumns = v.GetReferenced(modelRelationshipClass);//;
                    List<string> structureObjLeadingEdgeColumns = structureObjColumns.Select(c => c.Name.Parts.Last()).ToList();

                    if (modelRelationshipClass == Index.Columns) // and of course only indexes have included columns
                                                                 // and we can't handle PK/UN as if they were special indexes without included columns
                                                                 // we get an exception
                    {
                        var structureObjIncludedColumns = v.GetReferenced(Index.IncludedColumns);
                        List<string> structureObjIncludedColumnNames = structureObjIncludedColumns.Select(c => c.Name.Parts.Last()).ToList();

                        // if we're processing indexes and this index has included columns
                        // then a more general index has to have a super set of those included columns
                        foundMoreGeneralIndex = structureObjIncludedColumnNames.Any() 
                            ? ThisIndexIsContainedByTheOtherIndex(thisIndexesLeadingEdgeColumns, structureObjLeadingEdgeColumns, IndexIncludedColumns, structureObjIncludedColumnNames) 
                            : ThisIndexIsContainedByTheOtherIndex(thisIndexesLeadingEdgeColumns, structureObjLeadingEdgeColumns);
                        if (foundMoreGeneralIndex)
                        {
                            IndexDefinition = v;
                            break;
                        }
                    }
                    else
                    {
                        foundMoreGeneralIndex = ThisIndexIsContainedByTheOtherIndex(thisIndexesLeadingEdgeColumns, structureObjLeadingEdgeColumns);
                        if (foundMoreGeneralIndex)
                        {
                            IndexDefinition = v;
                            break;
                        }

                    }
                }
            }
            return foundMoreGeneralIndex;
        }
        private static bool ThisIndexIsContainedByTheOtherIndex(List<string> theseKeysColumns, List<string> theOtherKeysColumns,List<string>theseIncludedColumns,List<string>otherIncludedColumns)
        {
            var foundIndexThatMatchesAKey = ThisIndexIsContainedByTheOtherIndex(theseKeysColumns,theOtherKeysColumns)
                                            // && all these included columns are in the other indexe's included columns
                                            // LETS (for now) NOT go down the path of checking they might be in the more general indexe's keys as well
                                            && theseIncludedColumns.All(thisIncludedColumn => otherIncludedColumns.Exists( otherIncludedColumn => otherIncludedColumn.SQLModel_StringCompareEqual(thisIncludedColumn ))) ;
            return foundIndexThatMatchesAKey;
        }

        private static bool ThisIndexIsContainedByTheOtherIndex(List<string> theseKeysColumns, List<string> theOtherKeysColumns)
        {
            // exclusions - 
            // an index isn't subsumed by another index if -
            // this index is a covering index ( has included colums )
            // the other index is a clustered index
            bool foundIndexThatMatchesAKey = false;

            List<int> allPos = ModelIndexAndKeysUtils.GetCorrespondingKeyPositions(theseKeysColumns, theOtherKeysColumns);
            // matchedPos lists the columns in TheseKeysColumns that were actually found in TheseKeysColumns
            List<int> matchedPos = allPos.Where(n => n != -1).Select(n => n).ToList();

            // If this index is just a restatement of another index 
            // same columns in potentially different order
            // it's irrelevant
            // else if its a strict sublist of another index 
            // it's irrelevant
            // not quite sure about the included columns issue yet
            // if every key in this index was found in the corresponding position in the other index
            // its a problem
            if (theseKeysColumns.Count == theOtherKeysColumns.Count
                && allPos.Count == matchedPos.Count
                && matchedPos.Count > 0
                && matchedPos.Count - 1 == matchedPos.Max())
            {
                foundIndexThatMatchesAKey = true;
            }
            else if (theseKeysColumns.Count < theOtherKeysColumns.Count
                //everything returned was a match
                && allPos.Count == matchedPos.Count
                //there was a match
                && matchedPos.Count > 0
                //everything matched matched matched in the first n columns
                && matchedPos.Count - 1 == matchedPos.Max()
                )
            {
                foundIndexThatMatchesAKey = true;
            }

            return foundIndexThatMatchesAKey;
        }
    }
}
