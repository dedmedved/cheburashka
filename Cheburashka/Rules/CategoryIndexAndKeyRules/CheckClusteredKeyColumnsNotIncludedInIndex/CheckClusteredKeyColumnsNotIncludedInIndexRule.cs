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
    /// whenever the tail of an index is the head of the clustered index
    /// or there are clustered index columns in the included columns of the index
    /// This rule only applies to Indexes
    /// </summary>

    [LocalizedExportCodeAnalysisRule(CheckClusteredKeyColumnsNotIncludedInIndexRule.RuleId,
        RuleConstants.ResourceBaseName, // Name of the resource file to look up displayname and description in
        RuleConstants.CheckClusteredKeyColumnsNotIncludedInIndex_RuleName, // ID used to look up the display name inside the resources file
        RuleConstants.CheckClusteredKeyColumnsNotIncludedInIndex_ProblemDescription, // ID used to look up the description inside the resources file
        Category = RuleConstants.CategoryDatabaseStructures, // Rule category (e.g. "Design", "Naming")
        RuleScope = SqlRuleScope.Element)] // This rule targets specific elements rather than the whole model
    public sealed class CheckClusteredKeyColumnsNotIncludedInIndexRule : SqlCodeAnalysisRule
    {
        /// <summary>
        /// <para>
        /// The Rule ID should resemble a fully-qualified class name. In the Visual Studio UI
        /// rules are grouped by "Namespace + Category", and each rule is shown using "Short ID: DisplayName".
        /// </para>
        /// <para>
        /// For this rule, it will be 
        /// shown as "DM0020: Clustered Key Columns need not be explicitly included in a non-unique Index on a Clustered Table.  The clustering columns are already added to the end of the index leaf entry."
        /// </para>
        /// </summary>
        public const string RuleId = RuleConstants.CheckClusteredKeyColumnsNotIncludedInIndexRuleId;

        public CheckClusteredKeyColumnsNotIncludedInIndexRule()
        {
            // This rule supports Tables. Only those objects will be passed to the Analyze method
            SupportedElementTypes = new[]
            {
                // Note: can use the ModelSchema definitions, or access the TypeClass for any of these types
                ModelSchema.Index
                // if the clustering keys are in a pk or unique constraint, there's not much we can recommend
                //presumably they need to be there
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

                // Get Database Schema and name of this model element.
                //string selfSchema = modelElement.Name.Parts[0];
                //string selfTable = modelElement.Name.Parts[1];

                //var allIndexes = model.GetObjects(DacQueryScopes.UserDefined, Index.TypeClass).ToList();
                //var thisIndex = model.GetObjects(DacQueryScopes.UserDefined, Index.TypeClass).Where(( n => n.Name.Parts[0] == selfSchema && n.Name.Parts[1] == selfTable)).Take(1);

                CheckClusteredKeyColumnsNotIncludedInIndexClusteredVisitor
                    checkClusteredKeyColumnsNotIncludedInIndexClusteredVisitor =
                        new();
                sqlFragment.Accept(checkClusteredKeyColumnsNotIncludedInIndexClusteredVisitor);
                var isClustered = checkClusteredKeyColumnsNotIncludedInIndexClusteredVisitor.Objects;

                CheckClusteredKeyColumnsNotIncludedInIndexUniquenessVisitor
                    checkClusteredKeyColumnsNotIncludedInIndexUniquenessVisitor =
                        new();
                sqlFragment.Accept(checkClusteredKeyColumnsNotIncludedInIndexUniquenessVisitor);
                var isUnique = checkClusteredKeyColumnsNotIncludedInIndexUniquenessVisitor.Objects;

                CheckClusteredKeyColumnsNotIncludedInIndexVisitor_IncludedIndexColumns
                    checkClusteredKeyColumnsNotIncludedInIndexVisitor_IncludedIndexColumns =
                        new();
                sqlFragment.Accept(checkClusteredKeyColumnsNotIncludedInIndexVisitor_IncludedIndexColumns);
                var includeColumns = checkClusteredKeyColumnsNotIncludedInIndexVisitor_IncludedIndexColumns.Objects;

                //var issues = new List<String>();
                var issueFound = false;

                if (!isClustered && !isUnique)
                {
                    // visitor to get the occurrences of statements that create constraints etc where we need the parent object name
                    CheckClusteredKeyColumnsNotIncludedInIndexVisitor checkClusteredKeyColumnsNotIncludedInIndexVisitor
                        =
                        new();
                    sqlFragment.Accept(checkClusteredKeyColumnsNotIncludedInIndexVisitor);
                    List<Identifier> indexColumns = checkClusteredKeyColumnsNotIncludedInIndexVisitor.Objects;

                    CheckClusteredKeyColumnsNotIncludedInIndexParentObjectVisitor
                        checkClusteredKeyColumnsNotIncludedInIndexParentObjectVisitor =
                            new();
                    sqlFragment.Accept(checkClusteredKeyColumnsNotIncludedInIndexParentObjectVisitor);
                    var parentTable = checkClusteredKeyColumnsNotIncludedInIndexParentObjectVisitor.Objects;

                    string owningObjectSchema = parentTable.SchemaIdentifier.Value;
                    string owningObjectTable = parentTable.BaseIdentifier.Value;

                    //owningObjectSchema.SQLModel_DebugPrint(@"c:\temp\xx.txt");
                    //owningObjectTable.SQLModel_DebugPrint(@"c:\temp\xx.txt");

                    bool bFoundClusteredIndex =
                        RuleUtils.FindClusteredIndex(model, owningObjectSchema, owningObjectTable,
                            out TSqlObject clusteredIndex,
                            out List<ObjectIdentifier> clusteredIndexColumns);
                    if (bFoundClusteredIndex)
                    {
                        //try
                        //{
                        List<string> c1 = clusteredIndexColumns.AsEnumerable().Select(n => n.Parts[2]).ToList();
                        List<string> c2 = indexColumns.Select(n => n.Value).ToList();
                        List<string> c2Include = includeColumns.Select(n => n.Value).ToList();

                        //allow the lead column to be a clustered index member, as we need to be able to have
                        //different indexes key on different leading edges
                        //but then check the tail columns
                        var (c2Head, c2Tail) = c2; // uses ListUtil.Deconstruct - magic !
                        //IEnumerable<String> common = c1.Intersect(c2_tail, SqlComparer.Comparer);
                        //IEnumerable<String> common2 = c1.Intersect(c2_include, SqlComparer.Comparer);
                        //issues.AddRange(common);
                        //issues.AddRange(common2);
                        if (c1.Intersect(c2Tail, SqlComparer.Comparer).Any() ||
                            c1.Intersect(c2Include, SqlComparer.Comparer).Any())
                        {
                            issueFound = true;
                        }

                        //}
                        //catch
                        //{
                        //}
                    }

                    // The rule execution context has all the objects we'll need, including the fragment representing the object,
                    // and a descriptor that lets us access rule metadata
                    RuleDescriptor ruleDescriptor = ruleExecutionContext.RuleDescriptor;

                    // Create problems for each object
                    //foreach (TSqlFragment issue in issues) {
                    RuleUtils.UpdateProblems(issueFound, problems, modelElement, elementName, sqlFragment, ruleDescriptor);
                }
            }
            catch
            {
            } // DMVRuleSetup.RuleSetup barfs on 'hidden' temporal history tables 'defined' in sub-projects

            return problems;
        }
    }
}




