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


    [LocalizedExportCodeAnalysisRule(EnforceIndexKeyColumnSeparationRule.RuleId,
        RuleConstants.ResourceBaseName,                                  // Name of the resource file to look up displayname and description in
        RuleConstants.EnforceIndexKeyColumnSeparation_RuleName,                    // ID used to look up the display name inside the resources file
        RuleConstants.EnforceIndexKeyColumnSeparation_ProblemDescription,          // ID used to look up the description inside the resources file
        Category = RuleConstants.CategoryDatabaseStructures,             // Rule category (e.g. "Design", "Naming")
        RuleScope = SqlRuleScope.Element)]                               // This rule targets specific elements rather than the whole model
    public sealed class EnforceIndexKeyColumnSeparationRule : SqlCodeAnalysisRule
    {
        /// <summary>
        /// The Rule ID should resemble a fully-qualified class name. In the Visual Studio UI
        /// rules are grouped by "Namespace + Category", and each rule is shown using "Short ID: DisplayName".
        /// For this rule, it will be 
        /// shown as "DM0016: Avoid indexes with keys that are just a permutation of another key, or form the leading edge of another key."
        /// </summary>
        public const string RuleId = RuleConstants.EnforceIndexKeyColumnSeparationRuleId;

        public EnforceIndexKeyColumnSeparationRule()
        {
            // This rule supports Tables. Only those objects will be passed to the Analyze method
            SupportedElementTypes = new[]
            {
                // Note: can use the ModelSchema definitions, or access the TypeClass for any of these types
                ModelSchema.Index
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
            // Refresh cached index/constraints/tables lists from Model
            //DMVSettings.RefreshColumnCache(model);
            DMVSettings.RefreshConstraintsAndIndexesCache(model);

            string selfSchema = modelElement.Name.Parts[0];
            string selfName   = modelElement.Name.Parts[2];

            var SourceName = modelElement.GetSourceInformation().SourceName;
            var StartColumn = modelElement.GetSourceInformation().StartColumn;
            var StartLine = modelElement.GetSourceInformation().StartLine;
            var owningObjectSchema = modelElement.GetParent().Name.Parts[0];
            var owningObjectTable = modelElement.GetParent().Name.Parts[1];

            List<TSqlObject> pks                = ModelIndexAndKeysUtils.getPrimaryKeys(owningObjectSchema, owningObjectTable);
            List<TSqlObject> indexes            = ModelIndexAndKeysUtils.getIndexes(owningObjectSchema, owningObjectTable);
            List<TSqlObject> uniqueConstraints  = ModelIndexAndKeysUtils.getUniqueConstraints(owningObjectSchema, owningObjectTable);


            List<String> LeadingEdgeIndexColumns = new List<String>();
            var columns = modelElement.GetReferenced(Index.Columns);
            List<String> x = columns.Select(n => n.Name.Parts.Last().ToString()).ToList();
            LeadingEdgeIndexColumns.AddRange(x);

            bool foundMoreInclusiveIndex = false;
            foreach (var v in pks)
            {
                // if this 'index' isn't the index underlying the pk, check it.
                // is this right/needed/wasted effort ?
                if (v.Name == null || !(SqlComparer.SQLModel_StringCompareEqual(v.Name.Parts[0], selfSchema)
                                            && SqlComparer.SQLModel_StringCompareEqual(v.Name.Parts[1], selfName)
                                            )
                    )
                {
                    var pk_columns = v.GetReferenced(PrimaryKeyConstraint.Columns);
                    List<String> PKLeadingEdgeIndexColumns = new List<String>();
                    foreach (var c in pk_columns)
                    {
                        String lastElement = "";
                        foreach (var n in c.Name.Parts)
                        {
                            lastElement = n;
                        }
                        PKLeadingEdgeIndexColumns.Add(lastElement);
                    }
                    foundMoreInclusiveIndex = determineIfThisIndexIsSubsumedByTheOtherIndex(LeadingEdgeIndexColumns, PKLeadingEdgeIndexColumns);
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
                    if (!(SqlComparer.SQLModel_StringCompareEqual(v.Name.Parts[0], selfSchema)
                           && SqlComparer.SQLModel_StringCompareEqual(v.Name.Parts[1], owningObjectTable)
                           && SqlComparer.SQLModel_StringCompareEqual(v.Name.Parts[2], selfName)
                           )
                        )
                    {
                        var idx_columns = v.GetReferenced(Index.Columns);
                        List<String> OtherLeadingEdgeIndexColumns = new List<String>();
                        foreach (var c in idx_columns)
                        {
                            String lastElement = "";
                            foreach (var n in c.Name.Parts)
                            {
                                lastElement = n;
                            }
                            OtherLeadingEdgeIndexColumns.Add(lastElement);
                        }
                        foundMoreInclusiveIndex = determineIfThisIndexIsSubsumedByTheOtherIndex(LeadingEdgeIndexColumns, OtherLeadingEdgeIndexColumns);
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
                    if (v.Name == null || !(SqlComparer.SQLModel_StringCompareEqual(v.Name.Parts[0], selfSchema)
                                                && SqlComparer.SQLModel_StringCompareEqual(v.Name.Parts[1], selfName)
                                                )
                        )
                    {
                        var un_columns = v.GetReferenced(UniqueConstraint.Columns);
                        List<String> ConstraintLeadingEdgeIndexColumns = new List<String>();
                        foreach (var c in un_columns)
                        {
                            String lastElement = "";
                            foreach (var n in c.Name.Parts)
                            {
                                lastElement = n;
                            }
                            ConstraintLeadingEdgeIndexColumns.Add(lastElement);
                        }
                        foundMoreInclusiveIndex = determineIfThisIndexIsSubsumedByTheOtherIndex(LeadingEdgeIndexColumns, ConstraintLeadingEdgeIndexColumns);
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

            // Create problems for each object
            foreach (TSqlFragment issue in issues)
            {
                SqlRuleProblem problem =
                new SqlRuleProblem(
                        String.Format(CultureInfo.CurrentCulture, ruleDescriptor.DisplayDescription, elementName)
                        , modelElement
                        , sqlFragment);

                problems.Add(problem);
            }
            return problems;
        }
        private static bool determineIfThisIndexIsSubsumedByTheOtherIndex(List<String> TheseKeysColumns, List<String> TheOtherKeysColumns)
        {
            bool foundIndexThatMatchesAKey = false;

            List<Int32> allPos = ModelIndexAndKeysUtils.getCorrespondingKeyPositions(TheseKeysColumns, TheOtherKeysColumns);
            // matchedPos lists the columns in TheseKeysColumns that were actually found in TheseKeysColumns
            List<Int32> matchedPos = allPos.Where(n => n != -1).Select(n => n).ToList();

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
                bool matchedOneForOne = true;
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
