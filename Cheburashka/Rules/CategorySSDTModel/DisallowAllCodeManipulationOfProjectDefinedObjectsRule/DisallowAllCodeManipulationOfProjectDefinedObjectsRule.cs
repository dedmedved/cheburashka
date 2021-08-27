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
using static System.String;

namespace Cheburashka
{
    [LocalizedExportCodeAnalysisRule(DisallowAllCodeManipulationOfProjectDefinedObjectsRule.RuleId,
        RuleConstants.ResourceBaseName,                                                             // Name of the resource file to look up displayname and description in
        RuleConstants.DisallowAllCodeManipulationOfProjectDefinedObjectsRuleName,                   // ID used to look up the display name inside the resources file
        RuleConstants.DisallowAllCodeManipulationOfProjectDefinedObjectsProblemDescription,         // ID used to look up the description inside the resources file
        Category = RuleConstants.CategorySsdtModel,                                                 // Rule category (e.g. "Design", "Naming")
        RuleScope = SqlRuleScope.Element)]                                                          // This rule targets specific elements rather than the whole model
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
        public const string RuleId = RuleConstants.DisallowAllCodeManipulationOfProjectDefinedObjectsRuleId;

        public DisallowAllCodeManipulationOfProjectDefinedObjectsRule()
        {
            SupportedElementTypes = SqlRuleUtils.GetStateAlteringContainingClasses();
        }

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext ruleExecutionContext)
        {
            // Get Model collation 
            SqlComparer.Comparer = ruleExecutionContext.SchemaModel.CollationComparer;

            List<SqlRuleProblem> problems = new();

            try
            {
                DmvRuleSetup.RuleSetup(ruleExecutionContext, out problems, out TSqlModel model,
                    out TSqlFragment sqlFragment, out TSqlObject modelElement);
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

                var alterIndexStatements = DmTSqlFragmentVisitor.Visit(sqlFragment, new AlterIndexStatementVisitor()).Cast<AlterIndexStatement>().ToList();
                var alterTableConstraintModificationStatements = DmTSqlFragmentVisitor.Visit(sqlFragment, new AlterTableConstraintModificationStatementVisitor()).Cast<AlterTableConstraintModificationStatement>().ToList();

                AlterTableAddTableElementStatementVisitor alterTableAddTableElementStatementVisitor = new();
                sqlFragment.Accept(alterTableAddTableElementStatementVisitor);
                List<AlterTableAddTableElementStatement> alterTableAddTableElementStatements = alterTableAddTableElementStatementVisitor.Objects;

                AlterTableAlterColumnStatementVisitor alterTableAlterColumnStatementVisitor = new();
                sqlFragment.Accept(alterTableAlterColumnStatementVisitor);
                List<AlterTableAlterColumnStatement> alterTableAlterColumnStatements = alterTableAlterColumnStatementVisitor.Objects;

                AlterTableDropTableElementStatementVisitor alterTableDropTableElementStatementVisitor = new();
                sqlFragment.Accept(alterTableDropTableElementStatementVisitor);
                List<AlterTableDropTableElementStatement> alterTableDropTableElementStatements = alterTableDropTableElementStatementVisitor.Objects;

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

                var allTables = DmvSettings.GetTables;
                var allIndexes = DmvSettings.GetIndexes;
                var allPrimaryKeys = DmvSettings.GetPrimaryKeys;
                var allUniqueConstraints = DmvSettings.GetUniqueConstraints;
                var allForeignKeys = DmvSettings.GetForeignKeys;
                var allCheckConstraints = DmvSettings.GetCheckConstraints;

                foreach (var dropTableStatement in dropTableStatements)
                {
                    foreach (var obj in dropTableStatement.Objects)
                    {
                        CheckAllProjectDefinedTables(obj, allTables, issues, dropTableStatement);
                    }
                }

                foreach (var createIndexStatement in createIndexStatements)
                {
                    CheckAllProjectDefinedTables(createIndexStatement.OnName, allTables, issues, createIndexStatement);
                }

                foreach (var dropIndexStatement in dropIndexStatements)
                {
                    foreach (var dropIndexClause in dropIndexStatement.DropIndexClauses)
                    {
                        SchemaObjectName schemaObject = null;
                        string indexName = null;
                        bool processIndexDropStatement = false;
//                        if (!(dropIndexClause is not DropIndexClause dic))
                        if (dropIndexClause is DropIndexClause dic)
                        {
                            processIndexDropStatement = dic.Object.IsLocalObject();
                            schemaObject = dic.Object;
                            indexName = dic.Index.Value;
                        }
                        else if (dropIndexClause is BackwardsCompatibleDropIndexClause oldDic)
                        {
//                          if (!(dropIndexClause is not BackwardsCompatibleDropIndexClause oldDic))
                            processIndexDropStatement = oldDic.Index.IsLocalObject();
                            schemaObject = oldDic.Index;
                            indexName = oldDic.Index.ChildIdentifier.Value;
                        }

                        if (processIndexDropStatement)
                        {
                            CheckDroppedOrAlteredIndexes(allIndexes, issues, dropIndexClause, schemaObject, indexName);
                        }
                    }
                }

                foreach (var alterIndexStatement in alterIndexStatements.Where(n => n.OnName.IsLocalObject()))
                {
                    if (alterIndexStatement.Name.Value is not null
                    )
                    {
                        CheckDroppedOrAlteredIndexes(allIndexes
                                                    , issues
                                                    , alterIndexStatement
                                                    , alterIndexStatement.OnName
                                                    , alterIndexStatement.Name.Value);
                    }
                }

                foreach (var alterTableConstraintModificationStatement in alterTableConstraintModificationStatements.Where(n => n.SchemaObjectName.IsLocalObject()))
                {
                    // internal objects only
                    foreach (var consName in alterTableConstraintModificationStatement.ConstraintNames)
                    {
                        if (CheckAlterTableStatement(allPrimaryKeys, issues, alterTableConstraintModificationStatement, consName)) { }
                        else if (CheckAlterTableStatement(allForeignKeys, issues, alterTableConstraintModificationStatement, consName)) { }
                        else if (CheckAlterTableStatement(allUniqueConstraints, issues, alterTableConstraintModificationStatement, consName)) { }
                        else if (CheckAlterTableStatement(allCheckConstraints, issues, alterTableConstraintModificationStatement, consName)) { }
                    }
                }

                foreach (var alterTableAddTableElementStatement in alterTableAddTableElementStatements.Where(n => n.SchemaObjectName.IsLocalObject()))
                {
                    CheckAllProjectDefinedTables(alterTableAddTableElementStatement.SchemaObjectName, allTables, issues, alterTableAddTableElementStatement);
                }

                foreach (var alterTableAlterColumnStatement in alterTableAlterColumnStatements.Where(n => n.SchemaObjectName.IsLocalObject()))
                {
                    CheckAllProjectDefinedTables(alterTableAlterColumnStatement.SchemaObjectName, allTables, issues, alterTableAlterColumnStatement);
                }

                foreach (var alterTableDropTableElementStatement in alterTableDropTableElementStatements.Where(n => n.SchemaObjectName.IsLocalObject()))
                {
                    foreach (var dropElement in alterTableDropTableElementStatement.AlterTableDropTableElements
                        .Where(n => n.TableElementType == TableElementType.Constraint).Select(n => n)
                    )
                    {
                        if (CheckAlterTableStatement(allPrimaryKeys, issues, alterTableDropTableElementStatement, dropElement.Name)) { }
                        else if (CheckAlterTableStatement(allForeignKeys, issues, alterTableDropTableElementStatement, dropElement.Name)) { }
                        else if (CheckAlterTableStatement(allUniqueConstraints, issues, alterTableDropTableElementStatement, dropElement.Name)) { }
                    }
                }

                // The rule execution context has all the objects we'll need, including the fragment representing the object,
                // and a descriptor that lets us access rule metadata
                RuleDescriptor ruleDescriptor = ruleExecutionContext.RuleDescriptor;
                // Create problems for each object
                RuleUtils.UpdateProblems(problems, modelElement, elementName, issues, ruleDescriptor);
            }
            catch
            {
            } // DMVRuleSetup.RuleSetup barfs on 'hidden' temporal history tables 'defined' in sub-projects

            return problems;

        }

        private static void CheckAllProjectDefinedTables(SchemaObjectName schemaObject, IList<TSqlObject> allObjectsToMatch, List<TSqlFragment> issues, TSqlFragment statement)
        {
            List<TSqlObject> objs = allObjectsToMatch
                .Where(n => n.Name?.HasName == true
                            && SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[0], (schemaObject.SchemaIdentifier?.Value ?? "dbo") )
                            && SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[1], schemaObject.BaseIdentifier.Value)
                )
                .Select(n => n).ToList();

            if (objs.Count > 0)
            {
                issues.Add(statement);
            }

        }
        // making this a function breaks all kinds of rules but it needs to short-cicuit further executoin for the sake of efficiency
        private static bool CheckAlterTableStatement(IList<TSqlObject> allObjectsToMatch, List<TSqlFragment> issues, AlterTableStatement alterTableStatement, Identifier alteredElement)
        {
            List<TSqlObject> objs = allObjectsToMatch
                .Where(n => n.Name?.HasName == true
                            && SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[0], (alterTableStatement.SchemaObjectName.SchemaIdentifier?.Value ?? "dbo"))
                            && SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[1], alteredElement.Value)
                )
                .Select(n => n).ToList();
            if (objs.Count > 0)
            {
                issues.Add(alterTableStatement);
            }
            return objs.Count > 0;
        }
        private static void CheckDroppedOrAlteredIndexes(IList<TSqlObject> allObjectsToMatch, List<TSqlFragment> issues, TSqlFragment statement, SchemaObjectName schemaObject, /*string schemaName, string tableName,*/ string objectName)
        {
            List<TSqlObject> objs = allObjectsToMatch
                .Where(n => SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[2], objectName)
                            && SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[1], schemaObject.BaseIdentifier.Value)
                            && SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[0], (schemaObject.SchemaIdentifier?.Value ?? "dbo"))
                )
                .Select(n => n).ToList();
            if (objs.Count > 0)
            {
                issues.Add(statement);
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

