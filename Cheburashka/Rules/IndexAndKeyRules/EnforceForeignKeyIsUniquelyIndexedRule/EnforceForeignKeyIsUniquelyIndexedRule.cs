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
    /// This is a SQL rule which returns a warning message 
    /// whenever there is an un-clustered table in a model.
    /// 
    /// Note that this uses a Localized export attribute, and hence the rule name and description will be
    /// localized if resource files for different languages are used
    /// </summary>


    [LocalizedExportCodeAnalysisRule(EnforceForeignKeyIsUniquelyIndexedRule.RuleId,
        RuleConstants.ResourceBaseName,                                         // Name of the resource file to look up displayname and description in
        RuleConstants.EnforceForeignKeyIsUniquelyIndexed_RuleName,              // ID used to look up the display name inside the resources file
        RuleConstants.EnforceForeignKeyIsUniquelyIndexed_ProblemDescription,    // ID used to look up the description inside the resources file
        Category = RuleConstants.CategoryDatabaseStructures,                    // Rule category (e.g. "Design", "Naming")
        RuleScope = SqlRuleScope.Element)]                                      // This rule targets specific elements rather than the whole model
    public sealed class EnforceForeignKeyIsUniquelyIndexedRule : SqlCodeAnalysisRule
    {

        /// <summary>
        /// The Rule ID should resemble a fully-qualified class name. In the Visual Studio UI
        /// rules are grouped by "Namespace + Category", and each rule is shown using "Short ID: DisplayName".
        /// For this rule, it will be 
        /// shown as "DM0034: Foreign Keys should be supported by an appropriate unique index.  Each combination of the Foreign Key columns defines a unique subset of the data in the table."
        /// </summary>
        public const string RuleId = RuleConstants.EnforceForeignKeyIsUniquelyIndexed_RuleId;

        public EnforceForeignKeyIsUniquelyIndexedRule()
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

            DMVRuleSetup.RuleSetup(ruleExecutionContext, out problems, out TSqlModel model, out TSqlFragment sqlFragment, out TSqlObject modelElement);

            // If we can't find the file then assume we're in a composite model
            // and the elements are defined there and
            // should be analysed there
            if (modelElement.GetSourceInformation() is null)
            {
                return problems;
            }
            string elementName = RuleUtils.GetElementName(ruleExecutionContext, modelElement);

            DMVSettings.RefreshModelBuiltInCache(model);
            DMVSettings.RefreshConstraintsAndIndexesCache(model);

            var ClusterColumns = new List<string>();

            var fkTables = modelElement.GetReferenced(ForeignKeyConstraint.ForeignTable).ToList();
            var hostTables = modelElement.GetReferenced(ForeignKeyConstraint.Host).ToList();

            // if we can't retrieve this information - compound model etc - crap out early

            if ( hostTables.Count == 0 || fkTables.Count == 0 )
            {
                return problems;
            }
            var hostColumns = modelElement.GetReferenced(ForeignKeyConstraint.Columns);
//            var fkColumns = modelElement.GetReferenced(ForeignKeyConstraint.ForeignColumns);

            var hostTable = hostTables[0];
//            var fkTable = fkTables[0];

            List<string> x = hostColumns.Select(n => n.Name.Parts.Last().ToString()).ToList();

            var ForeignKeyColumns = new List<string>();
            ForeignKeyColumns.AddRange(x);

            // Get Database Schema and name of this model element.
            //SchemaObjectName parentTable = hostTable.Name.Parts[1];
            string owningObjectSchema = hostTable.Name.Parts[0];
            string owningObjectTable = hostTable.Name.Parts[1];

            // get all unique indexes
// no !     var allIndexes = model.GetObjects(DacQueryScopes.UserDefined, Index.TypeClass).Where( n => (bool) n.GetProperty(Index.Unique)).ToList();
            var allIndexes = model.GetObjects(DacQueryScopes.UserDefined, Index.TypeClass).ToList();

            var theseIndexes = new List<TSqlObject>();

            bool foundIndexThatMatchesAKey = false;

            foreach (var thing in allIndexes)
            {
                TSqlObject tab = thing.GetReferenced(Index.IndexedObject).ToList()[0];
                if (tab.Name.Parts[1].SQLModel_StringCompareEqual(owningObjectTable)
                    && tab.Name.Parts[0].SQLModel_StringCompareEqual(owningObjectSchema)
                )
                {
                    theseIndexes.Add(thing);
                }
            }

            var clusteredIndexFound = false;
            foreach (var index in theseIndexes)
            {
                var cols = index.GetReferencedRelationshipInstances(
                    Index.ColumnsRelationship.RelationshipClass, DacQueryScopes.UserDefined);
                clusteredIndexFound = (bool) index.GetProperty(Index.Clustered);
                if (clusteredIndexFound)
                {
                    foreach (var v in cols)
                    {
                        ClusterColumns.Add(v.ObjectName.Parts[2]);
                    }
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
                    thesePK.Add(thing);
                    break;
                }
            }
            if (!clusteredIndexFound)
            {
                foreach (var pk in thesePK)
                {
                    var cols = pk.GetReferencedRelationshipInstances(
                        PrimaryKeyConstraint.Columns, DacQueryScopes.UserDefined);
                    clusteredIndexFound = (bool) pk.GetProperty(PrimaryKeyConstraint.Clustered);
                    if (clusteredIndexFound)
                    {
                        foreach (var v in cols)
                        {
                            ClusterColumns.Add(v.ObjectName.Parts[2]);
                        }
                    }

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
                    theseUN.Add(thing);
                }
            }
            if (!clusteredIndexFound)
            {
                foreach (var un in theseUN)
                {
                    var cols = un.GetReferencedRelationshipInstances(
                        UniqueConstraint.Columns, DacQueryScopes.UserDefined);
                    clusteredIndexFound = (bool)un.GetProperty(UniqueConstraint.Clustered);
                    if (clusteredIndexFound)
                    {
                        foreach (var v in cols)
                        {
                            ClusterColumns.Add(v.ObjectName.Parts[2]);
                        }
                    }
                }
            }

            foreach (var index in theseIndexes)
            {
                var uniqIdx = (bool)index.GetProperty(Index.Unique);
                if (uniqIdx)
                {
                    List<string> leadingEdgeIndexColumns = new List<string>();
                    var cols = index.GetReferencedRelationshipInstances(
                        Index.Columns, DacQueryScopes.UserDefined);
                    var clustered = (bool)index.GetProperty(Index.Clustered);

                    foreach (var v in cols)//.ToList())
                    {
                        leadingEdgeIndexColumns.Add(v.ObjectName.Parts[2]);
                    }

                    foundIndexThatMatchesAKey = CheckThatForeignKeysAreCoveredByIndex(ClusterColumns, ForeignKeyColumns, clustered, leadingEdgeIndexColumns);
                    if (foundIndexThatMatchesAKey)
                    {
                        break;
                    }
                }
            }
            if (!foundIndexThatMatchesAKey)
            {
                foreach (var pk in thesePK)
                {
                    List<string> leadingEdgeIndexColumns = new List<string>();
                    var cols = pk.GetReferencedRelationshipInstances(
                        PrimaryKeyConstraint.Columns, DacQueryScopes.UserDefined);
                    var clustered = (bool)pk.GetProperty(PrimaryKeyConstraint.Clustered);

                    foreach (var v in cols)
                    {
                        leadingEdgeIndexColumns.Add(v.ObjectName.Parts[2]);
                    }

                    foundIndexThatMatchesAKey = CheckThatForeignKeysAreCoveredByIndex(ClusterColumns, ForeignKeyColumns, clustered, leadingEdgeIndexColumns);
                    if (foundIndexThatMatchesAKey)
                    {
                        break;
                    }
                }
            }
            if (!foundIndexThatMatchesAKey)
            {
                foreach (var un in theseUN)
                {
                    List<string> leadingEdgeIndexColumns = new List<string>();
                    var cols = un.GetReferencedRelationshipInstances(
                        UniqueConstraint.Columns, DacQueryScopes.UserDefined);
                    var clustered = (bool)un.GetProperty(UniqueConstraint.Clustered);

                    foreach (var v in cols)
                    {
                        leadingEdgeIndexColumns.Add(v.ObjectName.Parts[2]);
                    }

                    foundIndexThatMatchesAKey = CheckThatForeignKeysAreCoveredByIndex(ClusterColumns, ForeignKeyColumns, clustered, leadingEdgeIndexColumns);
                    if (foundIndexThatMatchesAKey)
                    {
                        break;
                    }
                }
            }
    

            if (!foundIndexThatMatchesAKey)
            {
                // The rule execution context has all the objects we'll need, including the fragment representing the object,
                // and a descriptor that lets us access rule metadata
                RuleDescriptor ruleDescriptor = ruleExecutionContext.RuleDescriptor;

                SqlRuleProblem problem =
                    new SqlRuleProblem(
                        string.Format(CultureInfo.CurrentCulture, ruleDescriptor.DisplayDescription, elementName)
                        , modelElement
                        , sqlFragment);

                //RuleUtils.UpdateProblemPosition(modelElement, problem, ((Identifier) objects[key]));
                problems.Add(problem);
            }

            return problems;
        }


        private static bool CheckThatForeignKeysAreCoveredByIndex(List<string> ClusterColumns, List<string> ForeignKeyColumns, bool ThisIndexIsClustered, List<string> LeadingEdgeIndexColumns) {
            bool foundIndexThatMatchesAKey = false;

            List<int> allPos = ModelIndexAndKeysUtils.GetCorrespondingKeyPositions(ForeignKeyColumns, LeadingEdgeIndexColumns);
            List<int> matchedPos = allPos.Where(n => n != -1).Select(n => n).ToList();

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
            else if (!ThisIndexIsClustered && ClusterColumns.Count > 0) {
                // the leading edge columns must still have been found in the first n columns of the index
                // and there must be no other trailing elements in the actual key of the index.
                // and I'm still making these rules up on the fly.
                // adjusted for 0-based arrays
                if (matchedPos.Count == LeadingEdgeIndexColumns.Count
                    && matchedPos.Count > 0
                    && matchedPos.Count - 1 == matchedPos.Max()
                    ) {
                    string[] arForeignKeyColumns = ForeignKeyColumns.ToArray();
                    List<string> unMatchedForeignKeyColumns = new List<string>();
                    for (int i = 0; i < allPos.Count; i++) {
                        if (allPos[i] == -1) {
                            unMatchedForeignKeyColumns.Add(arForeignKeyColumns[i]);
                        }
                    }

                    List<int> remainingPos = ModelIndexAndKeysUtils.GetCorrespondingKeyPositions(unMatchedForeignKeyColumns, ClusterColumns);
                    List<int> remainingAndMatchedToClusteringKeyPos = remainingPos.Where(n => n != -1).Select(n => n).ToList();

                    // if we found all the unmatched columns in the cluster key we're home and dry !
                    if (remainingAndMatchedToClusteringKeyPos.Count == remainingPos.Count) {
                        foundIndexThatMatchesAKey = true;
                    }
                }
            }

            return foundIndexThatMatchesAKey;
        }
    }
}
