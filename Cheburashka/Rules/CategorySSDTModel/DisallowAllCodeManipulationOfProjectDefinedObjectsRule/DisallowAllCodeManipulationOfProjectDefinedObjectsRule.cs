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
using static System.String;

namespace Cheburashka
{
    [LocalizedExportCodeAnalysisRule(DisallowAllCodeManipulationOfProjectDefinedObjectsRule.RuleId,
        RuleConstants.ResourceBaseName,                                                         // Name of the resource file to look up displayname and description in
        RuleConstants.DisallowAllCodeManipulationOfProjectDefinedObjects_RuleName,              // ID used to look up the display name inside the resources file
        RuleConstants.DisallowAllCodeManipulationOfProjectDefinedObjects_ProblemDescription,    // ID used to look up the description inside the resources file
        Category = RuleConstants.CategorySSDTModel,                                             // Rule category (e.g. "Design", "Naming")
        RuleScope = SqlRuleScope.Element)]                                                      // This rule targets specific elements rather than the whole model
    public sealed class DisallowAllCodeManipulationOfProjectDefinedObjectsRule : SqlCodeAnalysisRule
    {
        /// <summary>
        /// <para>
        /// The Rule ID should resemble a fully-qualified class name. In the Visual Studio UI
        /// rules are grouped by "Namespace + Category", and each rule is shown using "Short ID: DisplayName".
        /// </para>
        /// <para>
        /// For this rule, it will be 
        /// shown as "DM0031. Objects defined in the project should not be altered at run-time."
        /// </para>
        /// </summary>
        public const string RuleId = RuleConstants.DisallowAllCodeManipulationOfProjectDefinedObjects_RuleId;

        public DisallowAllCodeManipulationOfProjectDefinedObjectsRule()
        {
            // This rule supports Tables. Only those objects will be passed to the Analyze method
            SupportedElementTypes = new[]
            {
                // Note: can use the ModelSchema definitions, or access the TypeClass for any of these types
                 ModelSchema.Procedure
                ,ModelSchema.DmlTrigger
                ,ModelSchema.DatabaseDdlTrigger
            };
        }

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

                //ISqlIndex idx = sqlElement as ISqlIndex;
                //ISqlPrimaryKeyConstraint pk = sqlElement as ISqlPrimaryKeyConstraint;
                //ISqlUniqueConstraint uk = sqlElement as ISqlUniqueConstraint;

                // visitor to get the occurrences of statements 
                AlterIndexStatementVisitor alterIndexStatementVisitor = new AlterIndexStatementVisitor();
                sqlFragment.Accept(alterIndexStatementVisitor);
                List<AlterIndexStatement> alterIndexStatements = alterIndexStatementVisitor.Objects;

                AlterTableConstraintModificationStatementVisitor alterTableConstraintModificationStatementVisitor =
                    new AlterTableConstraintModificationStatementVisitor();
                sqlFragment.Accept(alterTableConstraintModificationStatementVisitor);
                List<AlterTableConstraintModificationStatement> alterTableConstraintModificationStatements =
                    alterTableConstraintModificationStatementVisitor.Objects;

                AlterTableAddTableElementStatementVisitor alterTableAddTableElementStatementVisitor =
                    new AlterTableAddTableElementStatementVisitor();
                sqlFragment.Accept(alterTableAddTableElementStatementVisitor);
                List<AlterTableAddTableElementStatement> alterTableAddTableElementStatements =
                    alterTableAddTableElementStatementVisitor.Objects;

                AlterTableAlterColumnStatementVisitor alterTableAlterColumnStatementVisitor =
                    new AlterTableAlterColumnStatementVisitor();
                sqlFragment.Accept(alterTableAlterColumnStatementVisitor);
                List<AlterTableAlterColumnStatement> alterTableAlterColumnStatements =
                    alterTableAlterColumnStatementVisitor.Objects;

                AlterTableDropTableElementStatementVisitor alterTableDropTableElementStatementVisitor =
                    new AlterTableDropTableElementStatementVisitor();
                sqlFragment.Accept(alterTableDropTableElementStatementVisitor);
                List<AlterTableDropTableElementStatement> alterTableDropTableElementStatements =
                    alterTableDropTableElementStatementVisitor.Objects;

                //DropClusteredConstraintFragmentOptionVisitor dropClusteredConstraintFragmentOptionVisitor = new DropClusteredConstraintFragmentOptionVisitor();
                //sqlFragment.Accept(dropClusteredConstraintFragmentOptionVisitor);
                //List<DropClusteredConstraintFragmentOption> dropClusteredConstraintFragmentOptions = dropClusteredConstraintFragmentOptionVisitor.Objects;

                //DropClusteredConstraintStateOptionVisitor dropClusteredConstraintStateOptionVisitor = new DropClusteredConstraintStateOptionVisitor();
                //sqlFragment.Accept(dropClusteredConstraintStateOptionVisitor);
                //List<DropClusteredConstraintStateOption> dropClusteredConstraintStateOptions = dropClusteredConstraintStateOptionVisitor.Objects;

                CreateIndexStatementVisitor createIndexStatementVisitor = new CreateIndexStatementVisitor();
                sqlFragment.Accept(createIndexStatementVisitor);
                List<CreateIndexStatement> createIndexStatements = createIndexStatementVisitor.Objects;
                DropIndexStatementVisitor dropIndexStatementVisitor = new DropIndexStatementVisitor();
                sqlFragment.Accept(dropIndexStatementVisitor);
                List<DropIndexStatement> dropIndexStatements = dropIndexStatementVisitor.Objects;
                DropTableStatementVisitor dropTableStatementVisitor = new DropTableStatementVisitor();
                sqlFragment.Accept(dropTableStatementVisitor);
                List<DropTableStatement> dropTableStatements = dropTableStatementVisitor.Objects;

                // some of this logic should be migrated into the visitors
                // particularly the stuff re external names.
                // as this is how we do it elsewhere
                List<TSqlFragment> issues = new List<TSqlFragment>();
                // try to speed things up, by not retrieving element where we don't have an alter.

                var allTables = DMVSettings.GetTables;

                //var allIndexes              = (alterIndexStatements.Count > 0                       || dropIndexStatements.Count > 0                 ) ? DMVSettings.GetIndexes           : new List<TSqlObject>();
                //var allPrimaryKeys          = (alterTableConstraintModificationStatements.Count > 0 || alterTableDropTableElementStatements.Count > 0) ? DMVSettings.GetPrimaryKeys       : new List<TSqlObject>();
                //var allUniqueConstraints    = (alterTableConstraintModificationStatements.Count > 0 || alterTableDropTableElementStatements.Count > 0) ? DMVSettings.GetUniqueConstraints : new List<TSqlObject>();
                //var allForeignKeys          = (alterTableConstraintModificationStatements.Count > 0 || alterTableDropTableElementStatements.Count > 0) ? DMVSettings.GetForeignKeys       : new List<TSqlObject>();
                //var allCheckConstraints     = (alterTableConstraintModificationStatements.Count > 0 || alterTableDropTableElementStatements.Count > 0) ? DMVSettings.GetCheckConstraints  : new List<TSqlObject>();

                var allIndexes = DMVSettings.GetIndexes;
                var allPrimaryKeys = DMVSettings.GetPrimaryKeys;
                var allUniqueConstraints = DMVSettings.GetUniqueConstraints;
                var allForeignKeys = DMVSettings.GetForeignKeys;
                var allCheckConstraints = DMVSettings.GetCheckConstraints;

                foreach (var dropTableStatement in dropTableStatements)
                {
                    foreach (var obj in dropTableStatement.Objects) {
                        var schema = obj.SchemaIdentifier != null
                            ? obj.SchemaIdentifier.Value
                            : "dbo";
                        var table = obj.BaseIdentifier.Value;
                        List<TSqlObject> tbls = allTables.Where(n => n.Name?.HasName == true
                                                                     && SqlComparer.SQLModel_StringCompareEqual(
                                                                         n.Name.Parts[0],
                                                                         schema)
                                                                     && SqlComparer.SQLModel_StringCompareEqual(
                                                                         n.Name.Parts[1],
                                                                         table)
                        ).Select(n => n).ToList();

                        if (tbls.Count > 0)
                        {
                            issues.Add(dropTableStatement);
                        }
                    }
                }

                foreach (var createIndexStatement in createIndexStatements)
                {
                    var schema = createIndexStatement.OnName.SchemaIdentifier != null
                        ? createIndexStatement.OnName.SchemaIdentifier.Value
                        : "dbo";
                    var table = createIndexStatement.OnName.BaseIdentifier.Value;
                    List<TSqlObject> tbls = allTables.Where(n => n.Name?.HasName == true
                                                                 && SqlComparer.SQLModel_StringCompareEqual(
                                                                     n.Name.Parts[0],
                                                                     schema)
                                                                 && SqlComparer.SQLModel_StringCompareEqual(
                                                                     n.Name.Parts[1],
                                                                     table)
                    ).Select(n => n).ToList();

                    if (tbls.Count > 0)
                    {
                        issues.Add(createIndexStatement);
                    }
                }

                foreach (var dropIndexStatement in dropIndexStatements)
                {
                    foreach (var dropIndexClause in dropIndexStatement.DropIndexClauses)
                    {
                        string schemaName = null;
                        string tableName = null;
                        string indexName = null;
                        bool skipExternalName = false;
                        if (!(!(dropIndexClause is DropIndexClause dic)))
                        {
                            if (((dic.Object.DatabaseIdentifier != null
                                  && IsNullOrEmpty(dic.Object.DatabaseIdentifier.Value)
                                 )
                                 || dic.Object.DatabaseIdentifier == null
                                )
                                && ((dic.Object.ServerIdentifier != null
                                     && IsNullOrEmpty(dic.Object.ServerIdentifier.Value)
                                    )
                                    || dic.Object.ServerIdentifier == null
                                )
                            )
                            {
                                skipExternalName = true;
                            }

                            schemaName = dic.Object.SchemaIdentifier != null
                                ? dic.Object.SchemaIdentifier.Value
                                : "dbo";
                            tableName = dic.Object.BaseIdentifier.Value;
                            indexName = dic.Index.Value;
                        }
                        else
                        {
                            if (!(!(dropIndexClause is BackwardsCompatibleDropIndexClause olddic)))
                            {
                                if (((olddic.Index.DatabaseIdentifier != null
                                      && IsNullOrEmpty(olddic.Index.DatabaseIdentifier.Value)
                                     )
                                     || olddic.Index.DatabaseIdentifier == null
                                    )
                                    && ((olddic.Index.ServerIdentifier != null
                                         && IsNullOrEmpty(olddic.Index.ServerIdentifier.Value)
                                        )
                                        || olddic.Index.ServerIdentifier == null
                                    )
                                )
                                {
                                    skipExternalName = true;
                                }

                                schemaName = olddic.Index.SchemaIdentifier != null
                                    ? olddic.Index.SchemaIdentifier.Value
                                    : "dbo";
                                tableName = olddic.Index.BaseIdentifier.Value;
                                indexName = olddic.Index.ChildIdentifier.Value;
                            }
                        }

                        if (skipExternalName)
                        {
                            List<TSqlObject> ixs = allIndexes
                                .Where(n => SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[2], indexName)
                                            && SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[1], tableName)
                                            && SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[0], schemaName)
                                )
                                .Select(n => n).ToList();
                            if (ixs.Count > 0)
                            {
                                issues.Add(dropIndexClause);
                            }
                        }
                    }
                }

                foreach (var alterIndexStatement in alterIndexStatements)
                {
                    if (alterIndexStatement.Name.Value != null
                        // internal objects only
                        && ((alterIndexStatement.OnName.DatabaseIdentifier != null
                             && IsNullOrEmpty(alterIndexStatement.OnName.DatabaseIdentifier.Value)
                            )
                            || alterIndexStatement.OnName.DatabaseIdentifier == null
                        )
                        && ((alterIndexStatement.OnName.ServerIdentifier != null
                             && IsNullOrEmpty(alterIndexStatement.OnName.ServerIdentifier.Value)
                            )
                            || alterIndexStatement.OnName.ServerIdentifier == null
                        )
                    )
                    {
                        List<TSqlObject> ixs = allIndexes
                            .Where(n => SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[2],
                                            alterIndexStatement.Name.Value)
                                        && SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[1],
                                            alterIndexStatement.OnName.BaseIdentifier.Value)
                                        && SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[0],
                                            alterIndexStatement.OnName.SchemaIdentifier.Value)
                            )
                            .Select(n => n).ToList();
                        if (ixs.Count > 0)
                        {
                            issues.Add(alterIndexStatement);
                        }
                    }
                }

                foreach (var alterTableConstraintModificationStatement in alterTableConstraintModificationStatements)
                {
                    // internal objects only
                    if (((alterTableConstraintModificationStatement.SchemaObjectName.DatabaseIdentifier != null
                          && IsNullOrEmpty(alterTableConstraintModificationStatement.SchemaObjectName.DatabaseIdentifier
                              .Value)
                         )
                         || alterTableConstraintModificationStatement.SchemaObjectName.DatabaseIdentifier == null
                        )
                        && ((alterTableConstraintModificationStatement.SchemaObjectName.ServerIdentifier != null
                             && IsNullOrEmpty(alterTableConstraintModificationStatement.SchemaObjectName
                                 .ServerIdentifier
                                 .Value)
                            )
                            || alterTableConstraintModificationStatement.SchemaObjectName.ServerIdentifier == null
                        )
                    )
                    {
                        foreach (var consName in alterTableConstraintModificationStatement.ConstraintNames)
                        {
                            List<TSqlObject> pkcs = allPrimaryKeys
                                .Where(n => n.Name?.HasName == true
                                            && (alterTableConstraintModificationStatement.SchemaObjectName
                                                    .SchemaIdentifier == null ||
                                                SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[0],
                                                    alterTableConstraintModificationStatement.SchemaObjectName
                                                        .SchemaIdentifier
                                                        .Value))
                                            && SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[1], consName.Value)
                                )
                                .Select(n => n).ToList();

                            if (pkcs.Count > 0)
                            {
                                issues.Add(alterTableConstraintModificationStatement);
                            }
                            else
                            {
                                List<TSqlObject> fkcs = allForeignKeys
                                    .Where(n => n.Name?.HasName == true
                                                && (alterTableConstraintModificationStatement.SchemaObjectName
                                                        .SchemaIdentifier == null ||
                                                    SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[0],
                                                        alterTableConstraintModificationStatement.SchemaObjectName
                                                            .SchemaIdentifier.Value))
                                                && SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[1],
                                                    consName.Value))
                                    .Select(n => n).ToList();
                                if (fkcs.Count > 0)
                                {
                                    issues.Add(alterTableConstraintModificationStatement);
                                }
                                else
                                {
                                    List<TSqlObject> ukcs = allUniqueConstraints
                                        .Where(n => n.Name?.HasName == true
                                                    && (alterTableConstraintModificationStatement.SchemaObjectName
                                                            .SchemaIdentifier == null ||
                                                        SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[0],
                                                            alterTableConstraintModificationStatement.SchemaObjectName
                                                                .SchemaIdentifier.Value))
                                                    && SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[1],
                                                        consName.Value))
                                        .Select(n => n).ToList();
                                    if (ukcs.Count > 0)
                                    {
                                        issues.Add(alterTableConstraintModificationStatement);
                                    }
                                    else
                                    {
                                        List<TSqlObject> chks = allCheckConstraints
                                            .Where(n => n.Name?.HasName == true
                                                        && (alterTableConstraintModificationStatement.SchemaObjectName
                                                                .SchemaIdentifier == null ||
                                                            SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[0],
                                                                alterTableConstraintModificationStatement
                                                                    .SchemaObjectName
                                                                    .SchemaIdentifier.Value))
                                                        && SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[1],
                                                            consName.Value))
                                            .Select(n => n).ToList();
                                        if (chks.Count > 0)
                                        {
                                            issues.Add(alterTableConstraintModificationStatement);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                foreach (var alterTableAddTableElementStatement in alterTableAddTableElementStatements)
                {
                    // internal objects only
                    if (((alterTableAddTableElementStatement.SchemaObjectName.DatabaseIdentifier != null
                          && IsNullOrEmpty(alterTableAddTableElementStatement.SchemaObjectName.DatabaseIdentifier.Value)
                         )
                         || alterTableAddTableElementStatement.SchemaObjectName.DatabaseIdentifier == null
                        )
                        && ((alterTableAddTableElementStatement.SchemaObjectName.ServerIdentifier != null
                             && IsNullOrEmpty(
                                 alterTableAddTableElementStatement.SchemaObjectName.ServerIdentifier.Value)
                            )
                            || alterTableAddTableElementStatement.SchemaObjectName.ServerIdentifier == null
                        )
                    )
                    {
                        var schema = alterTableAddTableElementStatement.SchemaObjectName.SchemaIdentifier != null
                            ? alterTableAddTableElementStatement.SchemaObjectName.SchemaIdentifier.Value
                            : "dbo";
                        var table = alterTableAddTableElementStatement.SchemaObjectName.BaseIdentifier.Value;
                        List<TSqlObject> tbls = allTables.Where(n => n.Name?.HasName == true
                                                                     && SqlComparer.SQLModel_StringCompareEqual(
                                                                         n.Name.Parts[0], schema)
                                                                     && SqlComparer.SQLModel_StringCompareEqual(
                                                                         n.Name.Parts[1], table)
                        ).Select(n => n).ToList();

                        if (tbls.Count > 0)
                        {
                            issues.Add(alterTableAddTableElementStatement);
                        }
                    }
                }

                foreach (var alterTableAlterColumnStatement in alterTableAlterColumnStatements)
                {
                    // internal objects only
                    if (((alterTableAlterColumnStatement.SchemaObjectName.DatabaseIdentifier != null
                          && IsNullOrEmpty(alterTableAlterColumnStatement.SchemaObjectName.DatabaseIdentifier.Value)
                         )
                         || alterTableAlterColumnStatement.SchemaObjectName.DatabaseIdentifier == null
                        )
                        && ((alterTableAlterColumnStatement.SchemaObjectName.ServerIdentifier != null
                             && IsNullOrEmpty(alterTableAlterColumnStatement.SchemaObjectName.ServerIdentifier.Value)
                            )
                            || alterTableAlterColumnStatement.SchemaObjectName.ServerIdentifier == null
                        )
                    )
                    {
                        var schema = alterTableAlterColumnStatement.SchemaObjectName.SchemaIdentifier != null
                            ? alterTableAlterColumnStatement.SchemaObjectName.SchemaIdentifier.Value
                            : "dbo";
                        var table = alterTableAlterColumnStatement.SchemaObjectName.BaseIdentifier.Value;
                        List<TSqlObject> tbls = allTables.Where(n => n.Name?.HasName == true
                                                                     && SqlComparer.SQLModel_StringCompareEqual(
                                                                         n.Name.Parts[0], schema)
                                                                     && SqlComparer.SQLModel_StringCompareEqual(
                                                                         n.Name.Parts[1], table)
                        ).Select(n => n).ToList();

                        if (tbls.Count > 0)
                        {
                            issues.Add(alterTableAlterColumnStatement);
                        }
                    }
                }

                foreach (var alterTableDropTableElementStatement in alterTableDropTableElementStatements)
                {
                    // internal objects only
                    if (((alterTableDropTableElementStatement.SchemaObjectName.DatabaseIdentifier != null
                          && IsNullOrEmpty(
                              alterTableDropTableElementStatement.SchemaObjectName.DatabaseIdentifier.Value)
                         )
                         || alterTableDropTableElementStatement.SchemaObjectName.DatabaseIdentifier == null
                        )
                        && ((alterTableDropTableElementStatement.SchemaObjectName.ServerIdentifier != null
                             && IsNullOrEmpty(alterTableDropTableElementStatement.SchemaObjectName.ServerIdentifier
                                 .Value)
                            )
                            || alterTableDropTableElementStatement.SchemaObjectName.ServerIdentifier == null
                        )
                    )
                    {
                        foreach (var dropElement in alterTableDropTableElementStatement.AlterTableDropTableElements
                            .Where(n => n.TableElementType == TableElementType.Constraint).Select(n => n)
                        )
                        {
                            List<TSqlObject> pkcs = allPrimaryKeys
                                .Where(n => n.Name?.HasName == true
                                            && (alterTableDropTableElementStatement.SchemaObjectName.SchemaIdentifier ==
                                                null || SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[0],
                                                    alterTableDropTableElementStatement.SchemaObjectName
                                                        .SchemaIdentifier
                                                        .Value))
                                            && SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[1],
                                                dropElement.Name.Value)
                                )
                                .Select(n => n).ToList();

                            if (pkcs.Count > 0)
                            {
                                issues.Add(alterTableDropTableElementStatement);
                            }
                            else
                            {
                                List<TSqlObject> fkcs = allForeignKeys
                                    .Where(n => n.Name?.HasName == true
                                                && (alterTableDropTableElementStatement.SchemaObjectName
                                                        .SchemaIdentifier ==
                                                    null || SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[0],
                                                        alterTableDropTableElementStatement.SchemaObjectName
                                                            .SchemaIdentifier.Value))
                                                && SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[1],
                                                    dropElement.Name.Value))
                                    .Select(n => n).ToList();
                                if (fkcs.Count > 0)
                                {
                                    issues.Add(alterTableDropTableElementStatement);
                                }
                                else
                                {
                                    List<TSqlObject> ukcs = allUniqueConstraints
                                        .Where(n => n.Name?.HasName == true
                                                    && (alterTableDropTableElementStatement.SchemaObjectName
                                                            .SchemaIdentifier == null ||
                                                        SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[0],
                                                            alterTableDropTableElementStatement.SchemaObjectName
                                                                .SchemaIdentifier.Value))
                                                    && SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[1],
                                                        dropElement.Name.Value))
                                        .Select(n => n).ToList();
                                    if (ukcs.Count > 0)
                                    {
                                        issues.Add(alterTableDropTableElementStatement);
                                    }
                                }
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
                            Format(CultureInfo.CurrentCulture, ruleDescriptor.DisplayDescription, elementName)
                            , modelElement
                            , sqlFragment);
                    RuleUtils.UpdateProblemPosition(modelElement, problem, (TSqlFragment) issue);
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

