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
using System.Linq;

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

    [LocalizedExportCodeAnalysisRule(EnforceIndexKeyColumnSeparationRule.RuleId,
        RuleConstants.ResourceBaseName,                                  // Name of the resource file to look up displayname and description in
        RuleConstants.EnforceIndexKeyColumnSeparation_RuleName,                    // ID used to look up the display name inside the resources file
        RuleConstants.EnforceIndexKeyColumnSeparation_ProblemDescription,          // ID used to look up the description inside the resources file
        Category = RuleConstants.CategoryDatabaseStructures,             // Rule category (e.g. "Design", "Naming")
        RuleScope = SqlRuleScope.Element)]                               // This rule targets specific elements rather than the whole model
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
                DMVRuleSetup.RuleSetup(ruleExecutionContext, out problems, out TSqlModel model,
                    out TSqlFragment sqlFragment, out TSqlObject modelElement);
                string elementName = RuleUtils.GetElementName(ruleExecutionContext);

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

                string selfSchema = modelElement.Name.Parts[0];
                string selfName = modelElement.Name.Parts[2]; //  is this right ?

                //var owningObjectSchema = modelElement.Name.Parts[0]; // modelElement.GetParent().Name.Parts[0];
                //var owningObjectTable  = modelElement.Name.Parts[1]; // modelElement.GetParent().Name.Parts[1];

                var owningObjectSchema = modelElement.GetParent(DacQueryScopes.All).Name.Parts[0];
                var owningObjectTable = modelElement.GetParent(DacQueryScopes.All).Name.Parts[1];

                List<TSqlObject> pks = ModelIndexAndKeysUtils.GetPrimaryKeys(owningObjectSchema, owningObjectTable);
                List<TSqlObject> indexes = ModelIndexAndKeysUtils.GetIndexes(owningObjectSchema, owningObjectTable);
                List<TSqlObject> uniqueConstraints =
                    ModelIndexAndKeysUtils.GetUniqueConstraints(owningObjectSchema, owningObjectTable);

                List<string> LeadingEdgeIndexColumns = new();
                var columns = modelElement.GetReferenced(Index.Columns);
                List<string> x = columns.Select(n => n.Name.Parts.Last()).ToList();
                LeadingEdgeIndexColumns.AddRange(x);

                bool foundMoreInclusiveIndex = false;
                foreach (var v in pks)
                {
                    // if this 'index' isn't the index underlying the pk, check it.
                    // is this right/needed/wasted effort ?
                    if (!v.Name.HasName || !SqlRuleUtils.ObjectNameMatches(v, owningObjectTable, owningObjectSchema))
                    {
                        var pk_columns = v.GetReferenced(PrimaryKeyConstraint.Columns);
                        List<string> PKLeadingEdgeIndexColumns = pk_columns.Select(c => c.Name.Parts.Last()).ToList();

                        foundMoreInclusiveIndex =
                            DetermineIfThisIndexIsSubsumedByTheOtherIndex(LeadingEdgeIndexColumns,
                                PKLeadingEdgeIndexColumns);
                        if (foundMoreInclusiveIndex)
                        {
                            break;
                        }
                    }
                }

                if (!foundMoreInclusiveIndex)
                {
                    foreach (var v in indexes)
                    {
                        // if this 'index' isn't the index we're checking - check it.
                        if (!(SqlRuleUtils.ObjectNameMatches(v, owningObjectTable, selfSchema) // this static method only partially matches what we want to check but use it anyway
                              && SqlComparer.SQLModel_StringCompareEqual(v.Name.Parts[2], selfName)
                            )
                        )
                        {
                            var idx_columns = v.GetReferenced(Index.Columns);
                            List<string> OtherLeadingEdgeIndexColumns = idx_columns.Select(c => c.Name.Parts.Last()).ToList();

                            foundMoreInclusiveIndex =
                                DetermineIfThisIndexIsSubsumedByTheOtherIndex(LeadingEdgeIndexColumns,
                                    OtherLeadingEdgeIndexColumns);
                            if (foundMoreInclusiveIndex)
                            {
                                break;
                            }
                        }
                    }
                }

                if (!foundMoreInclusiveIndex)
                {
                    foreach (var v in uniqueConstraints)
                    {
                        // if this 'index' isn't the index we're checking - check it.
                        if (!v.Name.HasName || !SqlRuleUtils.ObjectNameMatches(v, selfName, selfSchema))
                        {
                            var un_columns = v.GetReferenced(UniqueConstraint.Columns);
                            List<string> ConstraintLeadingEdgeIndexColumns = un_columns.Select(c => c.Name.Parts.Last()).ToList();

                            foundMoreInclusiveIndex =
                                DetermineIfThisIndexIsSubsumedByTheOtherIndex(LeadingEdgeIndexColumns,
                                    ConstraintLeadingEdgeIndexColumns);
                            if (foundMoreInclusiveIndex)
                            {
                                break;
                            }
                        }
                    }
                }

                var issues = new List<TSqlFragment>();

                if (foundMoreInclusiveIndex)
                {
                    issues.Add(sqlFragment);
                }

                RuleDescriptor ruleDescriptor = ruleExecutionContext.RuleDescriptor;
                RuleUtils.UpdateProblems(problems, modelElement, elementName, issues, ruleDescriptor);

            }
            catch { } // DMVRuleSetup.RuleSetup barfs on 'hidden' temporal history tables 'defined' in sub-projects

            return problems;
        }

        private static bool DetermineIfThisIndexIsSubsumedByTheOtherIndex(List<string> TheseKeysColumns, List<string> TheOtherKeysColumns)
        {
            bool foundIndexThatMatchesAKey = false;

            List<int> allPos = ModelIndexAndKeysUtils.GetCorrespondingKeyPositions(TheseKeysColumns, TheOtherKeysColumns);
            // matchedPos lists the columns in TheseKeysColumns that were actually found in TheseKeysColumns
            List<int> matchedPos = allPos.Where(n => n != -1).Select(n => n).ToList();

            // If this index is just a restatement of another index 
            // same columns in potentially different order
            // it's irrelevant
            // else if its a a strict sublist of another index 
            // it's irrelevant
            // not quite sure about the included columns issue yet
            // if every key in this index was found in the corresponding position in the other index
            // its a problem
            if (TheseKeysColumns.Count == TheOtherKeysColumns.Count
                && allPos.Count == matchedPos.Count
                && matchedPos.Count > 0
                && matchedPos.Count - 1 == matchedPos.Max())
            {
                foundIndexThatMatchesAKey = true;
            }
            else if (TheseKeysColumns.Count < TheOtherKeysColumns.Count
                //everything returned was a match
                && allPos.Count == matchedPos.Count
                //there was a match
                && matchedPos.Count > 0
                //everything matched matched matched in the first n columns
                && matchedPos.Count - 1 == matchedPos.Max()
                )
            {
                const bool matchedOneForOne = true;
                //for (int i = 0; i < allPos.Count; i++)
                //{
                //    if ( allPos[i] != i) {
                //        matchedOneForOne = false ;
                //        break ;
                //    }
                //}
                foundIndexThatMatchesAKey = matchedOneForOne;
            }

            return foundIndexThatMatchesAKey;
        }
    }
}
