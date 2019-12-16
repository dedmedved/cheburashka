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
    [LocalizedExportCodeAnalysisRule(CheckUniqueKeysAreNotDuplicatedRule.RuleId,
        RuleConstants.ResourceBaseName,                                                 // Name of the resource file to look up displayname and description in
        RuleConstants.CheckUniqueKeysAreNotDuplicated_RuleName,                   // ID used to look up the display name inside the resources file
        RuleConstants.CheckUniqueKeysAreNotDuplicated_ProblemDescription,         // ID used to look up the description inside the resources file
        Category = RuleConstants.CategoryDatabaseStructures,                            // Rule category (e.g. "Design", "Naming")
        RuleScope = SqlRuleScope.Element)]                                              // This rule targets specific elements rather than the whole model
    public sealed class CheckUniqueKeysAreNotDuplicatedRule : SqlCodeAnalysisRule
    {
        /// <summary>
        /// The Rule ID should resemble a fully-qualified class name. In the Visual Studio UI
        /// rules are grouped by "Namespace + Category", and each rule is shown using "Short ID: DisplayName".
        /// For this rule, it will be 
        /// shown as "DM0019. Unique constraints and indexes shouldn't be over-constrained."
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
                ,ModelSchema.Table
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
            string owningObjectSchema;
            string owningObjectTable;

            DMVRuleSetup.getOwningObject(modelElement, out owningObjectSchema, out owningObjectTable);

            //ISqlIndex idx = sqlElement as ISqlIndex;
            //ISqlPrimaryKeyConstraint pk = sqlElement as ISqlPrimaryKeyConstraint;
            //ISqlUniqueConstraint uk = sqlElement as ISqlUniqueConstraint;


            //List<ColumnDefinition> colSpec = null;
            String SourceName = null;
            int StartColumn = 0;
            int StartLine = 0;

            bool unique = true;
            SourceName = modelElement.GetSourceInformation().SourceName;
            StartColumn = modelElement.GetSourceInformation().StartColumn;
            StartLine = modelElement.GetSourceInformation().StartLine;
            owningObjectSchema = modelElement.GetParent().Name.Parts[0];
            owningObjectTable = modelElement.GetParent().Name.Parts[1];

            var structureColumnsVisitor = new StructureColumnsVisitor();

            List<string> indexColumns = new List<string>(); 
            if (sqlFragment != null) { 
                sqlFragment.Accept(structureColumnsVisitor);
                indexColumns = structureColumnsVisitor.Objects;
            }
            else {
                if (modelElement.ObjectType == UniqueConstraint.TypeClass ) {
                    indexColumns = modelElement.GetReferencedRelationshipInstances(UniqueConstraint.Columns).Where(n => n.ObjectName.HasName).Select(n => n.ObjectName.Parts.Last()).ToList();
                }
                else if (modelElement.ObjectType == PrimaryKeyConstraint.TypeClass)
                {
                    indexColumns = modelElement.GetReferencedRelationshipInstances(PrimaryKeyConstraint.Columns).Where(n => n.ObjectName.HasName).Select(n => n.ObjectName.Parts.Last()).ToList();
                }
            }

            if (modelElement.ObjectType == Index.TypeClass)
            {
                unique = (Boolean?)modelElement.GetProperty(Index.Unique) == true;
            }

            if (unique)
            {
                var issues = new List<TSqlFragment>();

                List<String> LeadingEdgeIndexColumns = new List<String>();

                foreach (var c in indexColumns)
                {
                    LeadingEdgeIndexColumns.Add(c);//.Value);
                }


                List<TSqlObject> pks                        = ModelIndexAndKeysUtils.getPrimaryKeys(owningObjectSchema, owningObjectTable);
                List<TSqlObject> indexes                    = ModelIndexAndKeysUtils.getIndexes(owningObjectSchema, owningObjectTable);
                List<TSqlObject> uniqueConstraints          = ModelIndexAndKeysUtils.getUniqueConstraints(owningObjectSchema, owningObjectTable);


                bool foundMoreConciseUniqueCondition = false;
                foreach (var v in pks)  // dummy loop - could only execute once.
                {
                    // if this 'index' isn't the index we're checking - check it.
                    if (v.GetSourceInformation().SourceName != SourceName || ( v.GetSourceInformation().StartColumn != StartColumn || v.GetSourceInformation().StartLine != StartLine) )  /// shit but it's all we have !!!
                    {
                        var columnSpecifications = v.GetReferencedRelationshipInstances(PrimaryKeyConstraint.Columns, DacQueryScopes.UserDefined);
                        List<String> sortedPrimaryKeyColumns = columnSpecifications.OrderBy(col => col.ObjectName.Parts[2], SqlComparer.Comparer).Select(n => n.ObjectName.Parts[2]).ToList();
                        List<String> PKLeadingEdgeIndexColumns = new List<String>();
                        PKLeadingEdgeIndexColumns.AddRange(sortedPrimaryKeyColumns);

                        foundMoreConciseUniqueCondition = determineIfThisConstraintIsImpliedByTheOtherConstraint(LeadingEdgeIndexColumns, PKLeadingEdgeIndexColumns);
                        if (foundMoreConciseUniqueCondition)
                        {
                            break;
                        }
                    }
                }
                if (!foundMoreConciseUniqueCondition)
                {
                    //loop over unique indexes
                    foreach (var v in indexes.Where( n => (bool?) n.GetProperty(Index.Unique) == true).Select(n=>n) )
                    {
                        // if this 'index' isn't the index we're checking - check it.
                        if (v.GetSourceInformation().SourceName != SourceName || (v.GetSourceInformation().StartColumn != StartColumn || v.GetSourceInformation().StartLine != StartLine))  /// shit but it's all we have !!!
                        {
                            var columnSpecifications = v.GetReferencedRelationshipInstances(Index.Columns, DacQueryScopes.UserDefined);
                            List<String> sortedUniqueIndexColumns = columnSpecifications.OrderBy(col => col.ObjectName.Parts[2], SqlComparer.Comparer).Select(n => n.ObjectName.Parts[2]).ToList();
                            List<String> OtherLeadingEdgeIndexColumns = new List<String>();
                            OtherLeadingEdgeIndexColumns.AddRange(sortedUniqueIndexColumns);

                            foundMoreConciseUniqueCondition = determineIfThisConstraintIsImpliedByTheOtherConstraint(LeadingEdgeIndexColumns, OtherLeadingEdgeIndexColumns);
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
                        // if this 'index' isn't the index we're checking - check it.
                        if (v.GetSourceInformation().SourceName != SourceName || (v.GetSourceInformation().StartColumn != StartColumn || v.GetSourceInformation().StartLine != StartLine))  /// shit but it's all we have !!!
                        {
                            var uniqueConstraintColumns = v.GetReferencedRelationshipInstances(UniqueConstraint.Columns, DacQueryScopes.UserDefined);
                            List<String> sortedUniqueConstraintColumns = uniqueConstraintColumns.OrderBy(col => col.ObjectName.Parts[2], SqlComparer.Comparer).Select(n => n.ObjectName.Parts[2]).ToList();
                            List<String> ConstraintLeadingEdgeIndexColumns = new List<String>();
                            ConstraintLeadingEdgeIndexColumns.AddRange(sortedUniqueConstraintColumns);

                            foundMoreConciseUniqueCondition = determineIfThisConstraintIsImpliedByTheOtherConstraint(LeadingEdgeIndexColumns, ConstraintLeadingEdgeIndexColumns);
                            if (foundMoreConciseUniqueCondition)
                            {
                                break;
                            }
                        }
                    }
                }
                if (foundMoreConciseUniqueCondition)
                {
                    if (sqlFragment == null ){
                        sqlFragment = new UniqueConstraintDefinition();
                    }
                    issues.Add(sqlFragment);
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

                    problems.Add(problem);
                }

            }
            return problems;
        }

        private static bool determineIfThisConstraintIsImpliedByTheOtherConstraint(List<String> TheseKeysColumns, List<String> TheOtherKeysColumns)
        {
            bool foundIndexThatMatchesAKey = false;

            List<Int32> allPos = ModelIndexAndKeysUtils.getCorrespondingKeyPositions(TheOtherKeysColumns, TheseKeysColumns);
            List<Int32> matchedPos = allPos.Where(n => n != -1).Select(n => n).ToList();

            if (TheseKeysColumns.Count >= TheOtherKeysColumns.Count
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
