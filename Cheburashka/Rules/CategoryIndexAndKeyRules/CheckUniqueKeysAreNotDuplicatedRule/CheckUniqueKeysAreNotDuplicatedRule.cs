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
    [LocalizedExportCodeAnalysisRule(CheckUniqueKeysAreNotDuplicatedRule.RuleId,
        RuleConstants.ResourceBaseName,                                                 // Name of the resource file to look up displayname and description in
        RuleConstants.CheckUniqueKeysAreNotDuplicated_RuleName,                   // ID used to look up the display name inside the resources file
        RuleConstants.CheckUniqueKeysAreNotDuplicated_ProblemDescription,         // ID used to look up the description inside the resources file
        Category = RuleConstants.CategoryDatabaseStructures,                            // Rule category (e.g. "Design", "Naming")
        RuleScope = SqlRuleScope.Element)]                                              // This rule targets specific elements rather than the whole model
    public sealed class CheckUniqueKeysAreNotDuplicatedRule : SqlCodeAnalysisRule
    {
        /// <summary>
        /// <para>
        /// The Rule ID should resemble a fully-qualified class name. In the Visual Studio UI
        /// rules are grouped by "Namespace + Category", and each rule is shown using "Short ID: DisplayName".
        /// </para>
        /// <para>
        /// For this rule, it will be 
        /// shown as "DM0019. Unique constraints and indexes shouldn't be over-constrained."
        /// </para>
        /// </summary>
        public const string RuleId = RuleConstants.CheckUniqueKeysAreNotDuplicatedRuleId;

        public CheckUniqueKeysAreNotDuplicatedRule()
        {
            // This rule supports Tables. Only those objects will be passed to the Analyze method
            SupportedElementTypes = new[]
            {
                // Note: can use the ModelSchema definitions, or access the TypeClass for any of these types
                 ModelSchema.PrimaryKeyConstraint
                ,ModelSchema.Index
                ,ModelSchema.UniqueConstraint
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

                DMVSettings.RefreshModelBuiltInCache(model);
                // Refresh cached index/constraints/tables lists from Model
                //DMVSettings.RefreshColumnCache(model);
                DMVSettings.RefreshConstraintsAndIndexesCache(model);

                // If this element is a nameless constraint, and we can't identify it by a position in a source file, there's nothing much we can do apart from return an empty list of problems.
                if ((modelElement.ObjectType == UniqueConstraint.TypeClass ||
                     modelElement.ObjectType == PrimaryKeyConstraint.TypeClass) && !modelElement.Name.HasName)
                {
                    if (modelElement.GetSourceInformation() == null)
                    {
                        return problems;
                    }
                }

                var parentObjectSchema = modelElement.GetParent(DacQueryScopes.All).Name.Parts[0];
                var parentObjectName = modelElement.GetParent(DacQueryScopes.All).Name.Parts[1];
                var structureColumnsVisitor = new StructureColumnsVisitor();

                List<string> thisIndexOrConstraintColumns = new();
                //what is this all about ?????
                if (sqlFragment != null)
                {
                    sqlFragment.Accept(structureColumnsVisitor);
                    thisIndexOrConstraintColumns = structureColumnsVisitor.Objects;
                }
                else
                {
                    ModelRelationshipClass y = (modelElement.ObjectType == UniqueConstraint.TypeClass) ? UniqueConstraint.Columns
                                                : PrimaryKeyConstraint.Columns
                                                ;

                    thisIndexOrConstraintColumns = modelElement
                                               .GetReferencedRelationshipInstances(y)
                                               .Where(n => n.ObjectName.HasName).Select(n => n.ObjectName.Parts.Last()).ToList();
                }


                bool unique = true;
                if (modelElement.ObjectType == Index.TypeClass)
                {
                    unique = (bool?)modelElement.GetProperty(Index.Unique) == true;
                }

                if (unique)
                {
                    List<TSqlFragment> issues = new();
                    List<string> leadingEdgeIndexColumns = new();

                    foreach (var c in thisIndexOrConstraintColumns)
                    {
                        leadingEdgeIndexColumns.Add(c);
                    }

                    List<TSqlObject> pks = ModelIndexAndKeysUtils.GetPrimaryKeys(parentObjectSchema, parentObjectName);
                    List<TSqlObject> indexes = ModelIndexAndKeysUtils.GetIndexes(parentObjectSchema, parentObjectName);
                    List<TSqlObject> uniqueConstraints =
                        ModelIndexAndKeysUtils.GetUniqueConstraints(parentObjectSchema, parentObjectName);

                    bool foundMoreConciseUniqueCondition = false;
                    foreach (var v in pks) // dummy loop - could only execute once.
                    {
                        //if this object being checked is an index or unique constraint we already know it isn't the primary key so check the primary key for commonality
                        if (modelElement.ObjectType == UniqueConstraint.TypeClass ||
                            modelElement.ObjectType == Index.TypeClass)
                        {
                            var columnSpecifications =
                                v.GetReferencedRelationshipInstances(PrimaryKeyConstraint.Columns,
                                    DacQueryScopes.UserDefined);
                            List<string> sortedPrimaryKeyColumns = columnSpecifications
                                .OrderBy(col => col.ObjectName.Parts[2], SqlComparer.Comparer)
                                .Select(n => n.ObjectName.Parts[2]).ToList();
                            List<string> pkLeadingEdgeIndexColumns = new();
                            pkLeadingEdgeIndexColumns.AddRange(sortedPrimaryKeyColumns);

                            foundMoreConciseUniqueCondition =
                                DetermineIfThisConstraintIsImpliedByTheOtherConstraint(leadingEdgeIndexColumns,
                                    pkLeadingEdgeIndexColumns);
                            if (foundMoreConciseUniqueCondition)
                            {
                                break;
                            }
                        }
                    }

                    if (!foundMoreConciseUniqueCondition)
                    {
                        //loop over unique indexes
                        foreach (var v in indexes.Where(n => (bool?) n.GetProperty(Index.Unique) == true)
                            .Select(n => n))
                        {
                            //if this object is a pk or uk it isn't an index  and cant be this object we currently checking
                            //if this object is index then if it don't have the same name it isn't this were currently checking
                            //so do  the columns checks.
                            if (modelElement.ObjectType == UniqueConstraint.TypeClass ||
                                modelElement.ObjectType == PrimaryKeyConstraint.TypeClass
                                || (!modelElement.Name.ToString().SQLModel_StringCompareEqual(v.Name.ToString()))
                            )
                            {
                                var columnSpecifications =
                                    v.GetReferencedRelationshipInstances(Index.Columns, DacQueryScopes.UserDefined);
                                List<string> sortedUniqueIndexColumns = columnSpecifications
                                    .OrderBy(col => col.ObjectName.Parts[2], SqlComparer.Comparer)
                                    .Select(n => n.ObjectName.Parts[2]).ToList();
                                List<string> otherLeadingEdgeIndexColumns = new();
                                otherLeadingEdgeIndexColumns.AddRange(sortedUniqueIndexColumns);

                                foundMoreConciseUniqueCondition =
                                    DetermineIfThisConstraintIsImpliedByTheOtherConstraint(leadingEdgeIndexColumns,
                                        otherLeadingEdgeIndexColumns);
                                if (foundMoreConciseUniqueCondition)
                                {
                                    break;
                                }
                            }
                        }
                    }

                    if (!foundMoreConciseUniqueCondition)
                    {
                        foreach (var v in uniqueConstraints)
                        {
                            //if this object is a pk or index it isn't an uk and cant be this object we currently checking
                            //if this object is uk then if it don't have the same name it isn't this were currently checking
                            //so do  the columns checks.
                            if (modelElement.ObjectType == PrimaryKeyConstraint.TypeClass ||
                                modelElement.ObjectType == Index.TypeClass
                                || ((modelElement.ObjectType == UniqueConstraint.TypeClass &&
                                     v.ObjectType == UniqueConstraint.TypeClass)
                                    && (!modelElement.Name.ToString().SQLModel_StringCompareEqual(v.Name.ToString())
                                    )
                                )
                            )
                            {
                                var uniqueConstraintColumns =
                                    v.GetReferencedRelationshipInstances(UniqueConstraint.Columns,
                                        DacQueryScopes.UserDefined);
                                List<string> sortedUniqueConstraintColumns = uniqueConstraintColumns
                                    .OrderBy(col => col.ObjectName.Parts[2], SqlComparer.Comparer)
                                    .Select(n => n.ObjectName.Parts[2]).ToList();
                                List<string> ConstraintLeadingEdgeIndexColumns = new();
                                ConstraintLeadingEdgeIndexColumns.AddRange(sortedUniqueConstraintColumns);

                                foundMoreConciseUniqueCondition =
                                    DetermineIfThisConstraintIsImpliedByTheOtherConstraint(leadingEdgeIndexColumns,
                                        ConstraintLeadingEdgeIndexColumns);
                                if (foundMoreConciseUniqueCondition)
                                {
                                    break;
                                }
                            }
                        }
                    }

                    if (foundMoreConciseUniqueCondition)
                    {
                        sqlFragment ??= new UniqueConstraintDefinition();

                        issues.Add(sqlFragment);
                    }

                    // The rule execution context has all the objects we'll need, including the fragment representing the object,
                    // and a descriptor that lets us access rule metadata
                    RuleDescriptor ruleDescriptor = ruleExecutionContext.RuleDescriptor;

                    // Create problems for each object
                    foreach (TSqlFragment issue in issues)
                    {
                        SqlRuleProblem problem =
                            new(
                                string.Format(CultureInfo.CurrentCulture, ruleDescriptor.DisplayDescription,
                                    elementName)
                                , modelElement
                                , sqlFragment);
                        RuleUtils.UpdateProblemPosition(modelElement, problem, issue);
                        problems.Add(problem);
                    }
                }
            }
            catch
            {
            } // DMVRuleSetup.RuleSetup barfs on 'hidden' temporal history tables 'defined' in sub-projects

            return problems;
            }

private static bool DetermineIfThisConstraintIsImpliedByTheOtherConstraint(List<string> theseKeysColumns, List<string> theOtherKeysColumns)
        {
            bool foundIndexThatMatchesAKey = false;

            List<int> allPos = ModelIndexAndKeysUtils.GetCorrespondingKeyPositions(theOtherKeysColumns, theseKeysColumns);
            List<int> matchedPos = allPos.Where(n => n != -1).Select(n => n).ToList();

            if (theseKeysColumns.Count >= theOtherKeysColumns.Count
                && allPos.Count == matchedPos.Count
                && matchedPos.Count > 0
                )
            {
                foundIndexThatMatchesAKey = true;
            }

            return foundIndexThatMatchesAKey;
        }
    }
}
