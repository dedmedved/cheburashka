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

                //ISqlIndex idx = sqlElement as ISqlIndex;
                //ISqlPrimaryKeyConstraint pk = sqlElement as ISqlPrimaryKeyConstraint;
                //ISqlUniqueConstraint uk = sqlElement as ISqlUniqueConstraint;

                // visitor to get the occurrences of statements 
                AlterIndexStatementVisitor alterIndexStatementVisitor = new();
                sqlFragment.Accept(alterIndexStatementVisitor);
                List<AlterIndexStatement> alterIndexStatements = alterIndexStatementVisitor.Objects;

                AlterTableConstraintModificationStatementVisitor alterTableConstraintModificationStatementVisitor =
                    new();
                sqlFragment.Accept(alterTableConstraintModificationStatementVisitor);
                List<AlterTableConstraintModificationStatement> alterTableConstraintModificationStatements =
                    alterTableConstraintModificationStatementVisitor.Objects;

                AlterTableAddTableElementStatementVisitor alterTableAddTableElementStatementVisitor =
                    new();
                sqlFragment.Accept(alterTableAddTableElementStatementVisitor);
                List<AlterTableAddTableElementStatement> alterTableAddTableElementStatements =
                    alterTableAddTableElementStatementVisitor.Objects;

                AlterTableAlterColumnStatementVisitor alterTableAlterColumnStatementVisitor =
                    new();
                sqlFragment.Accept(alterTableAlterColumnStatementVisitor);
                List<AlterTableAlterColumnStatement> alterTableAlterColumnStatements =
                    alterTableAlterColumnStatementVisitor.Objects;

                AlterTableDropTableElementStatementVisitor alterTableDropTableElementStatementVisitor =
                    new();
                sqlFragment.Accept(alterTableDropTableElementStatementVisitor);
                List<AlterTableDropTableElementStatement> alterTableDropTableElementStatements =
                    alterTableDropTableElementStatementVisitor.Objects;

                //DropClusteredConstraintFragmentOptionVisitor dropClusteredConstraintFragmentOptionVisitor = new DropClusteredConstraintFragmentOptionVisitor();
                //sqlFragment.Accept(dropClusteredConstraintFragmentOptionVisitor);
                //List<DropClusteredConstraintFragmentOption> dropClusteredConstraintFragmentOptions = dropClusteredConstraintFragmentOptionVisitor.Objects;

                //DropClusteredConstraintStateOptionVisitor dropClusteredConstraintStateOptionVisitor = new DropClusteredConstraintStateOptionVisitor();
                //sqlFragment.Accept(dropClusteredConstraintStateOptionVisitor);
                //List<DropClusteredConstraintStateOption> dropClusteredConstraintStateOptions = dropClusteredConstraintStateOptionVisitor.Objects;

                CreateIndexStatementVisitor createIndexStatementVisitor = new();
                sqlFragment.Accept(createIndexStatementVisitor);
                List<CreateIndexStatement> createIndexStatements = createIndexStatementVisitor.Objects;
                DropIndexStatementVisitor dropIndexStatementVisitor = new();
                sqlFragment.Accept(dropIndexStatementVisitor);
                List<DropIndexStatement> dropIndexStatements = dropIndexStatementVisitor.Objects;
                DropTableStatementVisitor dropTableStatementVisitor = new();
                sqlFragment.Accept(dropTableStatementVisitor);
                List<DropTableStatement> dropTableStatements = dropTableStatementVisitor.Objects;

                // some of this logic should be migrated into the visitors
                // particularly the stuff re external names.
                // as this is how we do it elsewhere
                List<TSqlFragment> issues = new();
                // try to speed things up, by not retrieving element where we don't have an alter.

                var allTables = DMVSettings.GetTables;
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
                                                                     && SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[0],schema)
                                                                     && SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[1],table)
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
                                                                 && SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[0],schema)
                                                                 && SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[1],table)
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
                        bool processIndexDropStatement = false;
                        if (!(dropIndexClause is not DropIndexClause dic))
                        {
                            processIndexDropStatement = dic.Object.IsLocalObject();
                            schemaName = dic.Object.SchemaIdentifier != null
                                ? dic.Object.SchemaIdentifier.Value
                                : "dbo";
                            tableName = dic.Object.BaseIdentifier.Value;
                            indexName = dic.Index.Value;
                        }
                        else
                        {
                            if (!(dropIndexClause is not BackwardsCompatibleDropIndexClause olddic))
                            {
                                processIndexDropStatement = olddic.Index.IsLocalObject();
                                schemaName = olddic.Index.SchemaIdentifier != null
                                    ? olddic.Index.SchemaIdentifier.Value
                                    : "dbo";
                                tableName = olddic.Index.BaseIdentifier.Value;
                                indexName = olddic.Index.ChildIdentifier.Value;
                            }
                        }

                        if (processIndexDropStatement)
                        {
                            List<TSqlObject> ixs = FindMatchingDroppedOrAlteredIndexes(allIndexes, schemaName, tableName, indexName);
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
                    &&  alterIndexStatement.OnName.IsLocalObject()
                    )
                    {
                        List<TSqlObject> ixs = FindMatchingDroppedOrAlteredIndexes(allIndexes
                                                                    , alterIndexStatement.OnName.SchemaIdentifier.Value
                                                                    , alterIndexStatement.OnName.BaseIdentifier.Value
                                                                    , alterIndexStatement.Name.Value);
                        if (ixs.Count > 0)
                        {
                            issues.Add(alterIndexStatement);
                        }
                    }
                }

                foreach (var alterTableConstraintModificationStatement in alterTableConstraintModificationStatements)
                {
                    // internal objects only
                    if (alterTableConstraintModificationStatement.SchemaObjectName.IsLocalObject())
                    {
                        foreach (var consName in alterTableConstraintModificationStatement.ConstraintNames)
                        {
                            List<TSqlObject> pkcs = allPrimaryKeys
                                .Where(n => n.Name?.HasName == true
                                            && (alterTableConstraintModificationStatement.SchemaObjectName
                                                    .SchemaIdentifier == null ||
                                                SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[0],
                                                    alterTableConstraintModificationStatement.SchemaObjectName
                                                        .SchemaIdentifier.Value))
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
                                                        alterTableConstraintModificationStatement.SchemaObjectName.SchemaIdentifier.Value))
                                                && SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[1], consName.Value))
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
                                                            alterTableConstraintModificationStatement.SchemaObjectName.SchemaIdentifier.Value))
                                                    && SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[1], consName.Value))
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
                                                                alterTableConstraintModificationStatement.SchemaObjectName.SchemaIdentifier.Value))
                                                        && SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[1], consName.Value))
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
                    if (alterTableAddTableElementStatement.SchemaObjectName.IsLocalObject())
                    {
                        List<TSqlObject> tbls = FindMatchingAddedTableElements(allTables, alterTableAddTableElementStatement);
                        if (tbls.Count > 0)
                        {
                            issues.Add(alterTableAddTableElementStatement);
                        }
                    }
                }

                foreach (var alterTableAlterColumnStatement in alterTableAlterColumnStatements)
                {
                    // internal objects only
                    if (alterTableAlterColumnStatement.SchemaObjectName.IsLocalObject())
                        {
                            var schema = alterTableAlterColumnStatement.SchemaObjectName.SchemaIdentifier != null
                            ? alterTableAlterColumnStatement.SchemaObjectName.SchemaIdentifier.Value
                            : "dbo";
                        var table = alterTableAlterColumnStatement.SchemaObjectName.BaseIdentifier.Value;
                        List<TSqlObject> tbls = allTables.Where(n => n.Name?.HasName == true
                                                                     && SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[0], schema)
                                                                     && SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[1], table)
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
                    if (alterTableDropTableElementStatement.SchemaObjectName.IsLocalObject())
                    {
                        foreach (var dropElement in alterTableDropTableElementStatement.AlterTableDropTableElements
                            .Where(n => n.TableElementType == TableElementType.Constraint).Select(n => n)
                        )
                        {
                            List<TSqlObject> pkcs = FindMatchingDroppedTableConstraint(allPrimaryKeys, alterTableDropTableElementStatement, dropElement);
                            if (pkcs.Count > 0)
                            {
                                issues.Add(alterTableDropTableElementStatement);
                            }
                            else
                            {
                                List<TSqlObject> fkcs = FindMatchingDroppedTableConstraint(allForeignKeys, alterTableDropTableElementStatement, dropElement);
                                if (fkcs.Count > 0)
                                {
                                    issues.Add(alterTableDropTableElementStatement);
                                }
                                else
                                {
                                    List<TSqlObject> ukcs = FindMatchingDroppedTableConstraint(allUniqueConstraints, alterTableDropTableElementStatement, dropElement);
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
                        new(
                            Format(CultureInfo.CurrentCulture, ruleDescriptor.DisplayDescription, elementName)
                            , modelElement
                            , sqlFragment);
                    RuleUtils.UpdateProblemPosition(modelElement, problem, issue);
                    problems.Add(problem);
                }
            }
            catch
            {
            } // DMVRuleSetup.RuleSetup barfs on 'hidden' temporal history tables 'defined' in sub-projects

            return problems;

            static List<TSqlObject> FindMatchingDroppedTableConstraint(IList<TSqlObject> allPossibleAffectedObjects, AlterTableDropTableElementStatement alterTableDropTableElementStatement, AlterTableDropTableElement dropElement)
            {
                return allPossibleAffectedObjects
                    .Where(n => n.Name?.HasName == true
                                && (alterTableDropTableElementStatement.SchemaObjectName.SchemaIdentifier == null 
                                   || SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[0], alterTableDropTableElementStatement.SchemaObjectName.SchemaIdentifier.Value)
                                   )
                                && SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[1], dropElement.Name.Value)
                    )
                    .Select(n => n).ToList();
            }

            static List<TSqlObject> FindMatchingDroppedOrAlteredIndexes(IList<TSqlObject> allObjects, string schemaName, string tableName, string objectName)
            {
                return allObjects
                    .Where(n => SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[2], objectName)
                                && SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[1], tableName)
                                && SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[0], schemaName)
                    )
                    .Select(n => n).ToList();
            }

            static List<TSqlObject> FindMatchingAddedTableElements(IList<TSqlObject> allTables, AlterTableAddTableElementStatement alterTableAddTableElementStatement)
            {
                var table = alterTableAddTableElementStatement.SchemaObjectName.BaseIdentifier.Value;
                List<TSqlObject> tbls = allTables.Where(n => n.Name?.HasName == true
                                                             && (alterTableAddTableElementStatement.SchemaObjectName.SchemaIdentifier == null 
                                                             || SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[0], alterTableAddTableElementStatement.SchemaObjectName.SchemaIdentifier.Value)
                                                             )
                                                             && SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[1], table)
                ).Select(n => n).ToList();
                return tbls;
            }
        }
    }
}
public static class SchemaObjectNameExtensions
{
    public static bool IsLocalObject(this SchemaObjectName name)
    {
        return IsNullOrEmpty(name.ServerIdentifier?.Value)
             && IsNullOrEmpty(name.DatabaseIdentifier?.Value);
    }
}

