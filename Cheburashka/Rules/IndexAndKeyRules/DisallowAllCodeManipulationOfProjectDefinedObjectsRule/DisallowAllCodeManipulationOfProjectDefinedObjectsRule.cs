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
    [LocalizedExportCodeAnalysisRule(DisallowAllCodeManipulationOfProjectDefinedObjectsRule.RuleId,
        RuleConstants.ResourceBaseName,                                                 // Name of the resource file to look up displayname and description in
        RuleConstants.DisallowAllCodeManipulationOfProjectDefinedObjects_RuleName,                   // ID used to look up the display name inside the resources file
        RuleConstants.DisallowAllCodeManipulationOfProjectDefinedObjects_ProblemDescription,         // ID used to look up the description inside the resources file
        Category = RuleConstants.CategoryDatabaseStructures,                            // Rule category (e.g. "Design", "Naming")
        RuleScope = SqlRuleScope.Element)]                                              // This rule targets specific elements rather than the whole model
    public sealed class DisallowAllCodeManipulationOfProjectDefinedObjectsRule : SqlCodeAnalysisRule
    {

        /// The Rule ID should resemble a fully-qualified class name. In the Visual Studio UI
        /// rules are grouped by "Namespace + Category", and each rule is shown using "Short ID: DisplayName".
        /// For this rule, it will be 
        /// shown as "DM0031. Objects defined in the project should not be altered at run-time."
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
                //,ModelSchema.Table
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

            //ISqlIndex idx = sqlElement as ISqlIndex;
            //ISqlPrimaryKeyConstraint pk = sqlElement as ISqlPrimaryKeyConstraint;
            //ISqlUniqueConstraint uk = sqlElement as ISqlUniqueConstraint;

            // visitor to get the occurrences of statements 
            AlterIndexStatementVisitor alterIndexStatementVisitor = new AlterIndexStatementVisitor();
            sqlFragment.Accept(alterIndexStatementVisitor);
            List<AlterIndexStatement> alterIndexStatements = alterIndexStatementVisitor.Objects;

            AlterTableConstraintModificationStatementVisitor alterTableConstraintModificationStatementVisitor = new AlterTableConstraintModificationStatementVisitor();
            sqlFragment.Accept(alterTableConstraintModificationStatementVisitor);
            List<AlterTableConstraintModificationStatement> alterTableConstraintModificationStatements = alterTableConstraintModificationStatementVisitor.Objects;

            AlterTableDropTableElementStatementVisitor alterTableDropTableElementStatementVisitor = new AlterTableDropTableElementStatementVisitor();
            sqlFragment.Accept(alterTableDropTableElementStatementVisitor);
            List<AlterTableDropTableElementStatement> alterTableDropTableElementStatements = alterTableDropTableElementStatementVisitor.Objects;

            //DropClusteredConstraintFragmentOptionVisitor dropClusteredConstraintFragmentOptionVisitor = new DropClusteredConstraintFragmentOptionVisitor();
            //sqlFragment.Accept(dropClusteredConstraintFragmentOptionVisitor);
            //List<DropClusteredConstraintFragmentOption> dropClusteredConstraintFragmentOptions = dropClusteredConstraintFragmentOptionVisitor.Objects;

            //DropClusteredConstraintStateOptionVisitor dropClusteredConstraintStateOptionVisitor = new DropClusteredConstraintStateOptionVisitor();
            //sqlFragment.Accept(dropClusteredConstraintStateOptionVisitor);
            //List<DropClusteredConstraintStateOption> dropClusteredConstraintStateOptions = dropClusteredConstraintStateOptionVisitor.Objects;

            DropIndexStatementVisitor dropIndexStatementVisitor = new DropIndexStatementVisitor();
            sqlFragment.Accept(dropIndexStatementVisitor);
            List<DropIndexStatement> dropIndexStatements = dropIndexStatementVisitor.Objects;


            // some of this logic should be migrated into the visitors
            // particularlay the stuff re external names.
            // as this is how we do it elsewhere
            List<TSqlFragment> issues = new List<TSqlFragment>();
            var allIndexes              = model.GetObjects(DacQueryScopes.UserDefined, Index.TypeClass).ToList();
            var allPrimaryKeys          = model.GetObjects(DacQueryScopes.UserDefined, PrimaryKeyConstraint.TypeClass).ToList();
            var allUniqueConstraints    = model.GetObjects(DacQueryScopes.UserDefined, UniqueConstraint.TypeClass).ToList();
            var allForeignKeys          = model.GetObjects(DacQueryScopes.UserDefined, ForeignKeyConstraint.TypeClass).ToList();

            foreach (var dis in dropIndexStatements)
            {
                foreach (var dropIndexClause in dis.DropIndexClauses)
                {
                    DropIndexClause dic = dropIndexClause as DropIndexClause;
                    BackwardsCompatibleDropIndexClause olddic = dropIndexClause as BackwardsCompatibleDropIndexClause;
                    String schemaName = null;
                    String tableName = null;
                    String indexName = null;
                    bool SkipExternalName = false;
                    if (dic != null)
                    {
                        if (((dic.Object.DatabaseIdentifier != null
                                && String.IsNullOrEmpty(dic.Object.DatabaseIdentifier.Value)
                                )
                             || dic.Object.DatabaseIdentifier == null
                             )
                           && ((dic.Object.ServerIdentifier != null
                                 && String.IsNullOrEmpty(dic.Object.ServerIdentifier.Value)
                                )
                              || dic.Object.ServerIdentifier == null
                             )
                           )
                        {
                            SkipExternalName = true;
                        }

                        schemaName = dic.Object.SchemaIdentifier.Value;
                        tableName = dic.Object.BaseIdentifier.Value;
                        indexName = dic.Index.Value;

                    }
                    else if (olddic != null)
                    {
                        if (((olddic.Index.DatabaseIdentifier != null
                                && String.IsNullOrEmpty(olddic.Index.DatabaseIdentifier.Value)
                                )
                             || olddic.Index.DatabaseIdentifier == null
                             )
                           && ((olddic.Index.ServerIdentifier != null
                                 && String.IsNullOrEmpty(olddic.Index.ServerIdentifier.Value)
                                )
                              || olddic.Index.ServerIdentifier == null
                             )
                           )
                        {
                            SkipExternalName = true;
                        }

                        schemaName = olddic.Index.SchemaIdentifier.Value;
                        tableName = olddic.Index.BaseIdentifier.Value;
                        indexName = olddic.Index.ChildIdentifier.Value;
                    }
                    if (!SkipExternalName)
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
            foreach (var ais in alterIndexStatements)
            {
                if (ais.Name.Value != null
                    // internal objects only
                    && ((ais.OnName.DatabaseIdentifier != null
                          && String.IsNullOrEmpty(ais.OnName.DatabaseIdentifier.Value)
                         )
                       || ais.OnName.DatabaseIdentifier == null
                       )
                    && ((ais.OnName.ServerIdentifier != null
                          && String.IsNullOrEmpty(ais.OnName.ServerIdentifier.Value)
                        )
                       || ais.OnName.ServerIdentifier == null
                       )
                    )
                {
                    List<TSqlObject> ixs = allIndexes
                            .Where(n => SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[2], ais.Name.Value)
                                && SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[1], ais.OnName.BaseIdentifier.Value)
                                && SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[0], ais.OnName.SchemaIdentifier.Value)
                                  )
                            .Select(n => n).ToList();
                    if (ixs.Count > 0)
                    {
                        issues.Add(ais);
                    }
                }
            }
            foreach (var atcms in alterTableConstraintModificationStatements)
            {
                // internal objects only
                if (((atcms.SchemaObjectName.DatabaseIdentifier != null
                        && String.IsNullOrEmpty(atcms.SchemaObjectName.DatabaseIdentifier.Value)
                        )
                     || atcms.SchemaObjectName.DatabaseIdentifier == null
                     )
                   && ((atcms.SchemaObjectName.ServerIdentifier != null
                         && String.IsNullOrEmpty(atcms.SchemaObjectName.ServerIdentifier.Value)
                        )
                      || atcms.SchemaObjectName.ServerIdentifier == null
                     )
                   )
                {
                    foreach (var consName in atcms.ConstraintNames)
                    {
                        List<TSqlObject> pkcs = allPrimaryKeys
                            .Where(n => n.Name != null && n.Name.HasName 
                                     && ( atcms.SchemaObjectName.SchemaIdentifier == null || SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[0], atcms.SchemaObjectName.SchemaIdentifier.Value))
                                     && SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[1], consName.Value)
                                  )
                            .Select(n => n).ToList();

                        if (pkcs.Count > 0)
                        {
                            issues.Add(atcms);
                        }
                        else
                        {
                            List<TSqlObject> fkcs = allForeignKeys
                                .Where(n => n.Name != null && n.Name.HasName
                                      && (atcms.SchemaObjectName.SchemaIdentifier == null || SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[0], atcms.SchemaObjectName.SchemaIdentifier.Value))
                                      && SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[1], consName.Value))
                                .Select(n => n).ToList();
                            if (fkcs.Count > 0)
                            {
                                issues.Add(atcms);
                            }
                            else
                            {
                                List<TSqlObject> ukcs = allUniqueConstraints
                                    .Where(n => n.Name != null && n.Name.HasName
                                        && (atcms.SchemaObjectName.SchemaIdentifier == null || SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[0], atcms.SchemaObjectName.SchemaIdentifier.Value))
                                        && SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[1], consName.Value))
                                    .Select(n => n).ToList();
                                if (ukcs.Count > 0)
                                {
                                    issues.Add(atcms);
                                }
                            }
                        }
                    }
                }
            }

            foreach (var atdtes in alterTableDropTableElementStatements)
            {
                // internal objects only
                if (((atdtes.SchemaObjectName.DatabaseIdentifier != null
                        && String.IsNullOrEmpty(atdtes.SchemaObjectName.DatabaseIdentifier.Value)
                        )
                     || atdtes.SchemaObjectName.DatabaseIdentifier == null
                     )
                   && ((atdtes.SchemaObjectName.ServerIdentifier != null
                         && String.IsNullOrEmpty(atdtes.SchemaObjectName.ServerIdentifier.Value)
                        )
                      || atdtes.SchemaObjectName.ServerIdentifier == null
                     )
                   )
                {
                    foreach (var dropElement in atdtes.AlterTableDropTableElements
                                    .Where(n => n.TableElementType == TableElementType.Constraint).Select(n => n)
                            )
                    {
                        List<TSqlObject> pkcs = allPrimaryKeys
                            .Where(n => n.Name != null && n.Name.HasName
                                      && (atdtes.SchemaObjectName.SchemaIdentifier == null || SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[0], atdtes.SchemaObjectName.SchemaIdentifier.Value))
                                      && SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[1], dropElement.Name.Value)
                                  )
                            .Select(n => n).ToList();

                        if (pkcs.Count > 0)
                        {
                            issues.Add(atdtes);
                        }
                        else
                        {
                            List<TSqlObject> fkcs = allForeignKeys
                                .Where(n => n.Name != null && n.Name.HasName
                                      && (atdtes.SchemaObjectName.SchemaIdentifier == null || SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[0], atdtes.SchemaObjectName.SchemaIdentifier.Value))
                                      && SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[1], dropElement.Name.Value))
                                .Select(n => n).ToList();
                            if (fkcs.Count > 0)
                            {
                                issues.Add(atdtes);
                            }
                            else
                            {
                                List<TSqlObject> ukcs = allUniqueConstraints
                                    .Where(n => n.Name != null && n.Name.HasName
                                        && (atdtes.SchemaObjectName.SchemaIdentifier == null || SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[0], atdtes.SchemaObjectName.SchemaIdentifier.Value))
                                        && SqlComparer.SQLModel_StringCompareEqual(n.Name.Parts[1], dropElement.Name.Value))
                                    .Select(n => n).ToList();
                                if (ukcs.Count > 0)
                                {
                                    issues.Add(atdtes);
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
                            String.Format(CultureInfo.CurrentCulture, ruleDescriptor.DisplayDescription, elementName)
                            , modelElement
                            , sqlFragment);

                    problems.Add(problem);
                }

            }
            return problems;
        }

    }
}
