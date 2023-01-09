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

using System.Collections.Generic;
using System.Linq;
using Microsoft.SqlServer.Dac.CodeAnalysis;
using Microsoft.SqlServer.Dac.Model;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Cheburashka
{
    /// <summary>
    /// <para>
    /// This is a SQL rule which returns a warning message 
    /// whenever there is an insert that omits mandatory columns
    /// </para>
    /// <para>
    /// Note that this uses a Localized export attribute, and hence the rule name and description will be
    /// localized if resource files for different languages are used
    /// </para>
    /// </summary>

    [LocalizedExportCodeAnalysisRule(CheckMissingInsertColumnsRule.RuleId,
        RuleConstants.ResourceBaseName,                                     // Name of the resource file to look up display name and description in
        RuleConstants.CheckMissingInsertColumnsRuleName,                    // ID used to look up the display name inside the resources file
        RuleConstants.CheckMissingInsertColumnsProblemDescription,          // ID used to look up the description inside the resources file
        Category = RuleConstants.CategoryNonStrictCodingStyle,              // Rule category (e.g. "Design", "Naming")
        RuleScope = SqlRuleScope.Element)]                                  // This rule targets specific elements rather than the whole model
    public sealed class CheckMissingInsertColumnsRule : SqlCodeAnalysisRule
    {
        /// <summary>
        /// <para>
        /// The Rule ID should resemble a fully-qualified class name. In the Visual Studio UI
        /// rules are grouped by "Namespace + Category", and each rule is shown using "Short ID: DisplayName".
        /// </para>
        /// <para>
        /// For this rule, it will be 
        /// shown as "DM0061: Columns without a default or other system supplied value need a value specifying in Insert operations."
        /// </para>
        /// </summary>
        public const string RuleId = RuleConstants.CheckMissingInsertColumnsRuleId;

        public CheckMissingInsertColumnsRule()
        {
            SupportedElementTypes = SqlRuleUtils.GetStateAlteringContainingClasses();
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
            //SqlComparer.Comparer = ruleExecutionContext.SchemaModel.CollationComparer;
            DmvRuleSetup.RuleSetup(ruleExecutionContext, out var problems, out TSqlModel model, out TSqlFragment sqlFragment, out TSqlObject modelElement);
            DmvSettings.RefreshModelBuiltInCache(model);
            DmvSettings.RefreshConstraintsAndIndexesCache(model);
            string elementName = RuleUtils.GetElementName(ruleExecutionContext);
            // The rule execution context has all the objects we'll need, including the fragment representing the object,
            // and a descriptor that lets us access rule metadata
            RuleDescriptor ruleDescriptor = ruleExecutionContext.RuleDescriptor;

            try
            {
                var allTables = DmvSettings.GetTables;
                var allViews = DmvSettings.GetViews;
                // todo handle external,3-part name tables, views
                var allTempTables =  DmTableDetailsVisitor.Visit(sqlFragment, new TempTableDefinitionVisitor());
                var allVariableTables =  DmTableDetailsVisitor.Visit(sqlFragment, new TableVariableDefinitionVisitor());
                var InsertMergeFragments = DmTSqlFragmentVisitor.Visit(sqlFragment, new MergeSpecificationVisitor()).Cast<MergeSpecification>().ToList();
                var InsertFragments = DmTSqlFragmentVisitor.Visit(sqlFragment, new InsertSpecificationVisitor()).Cast<InsertSpecification>().ToList();
                var OutputIntoFragments = DmTSqlFragmentVisitor.Visit(sqlFragment, new OutputIntoClauseVisitor()).Cast<OutputIntoClause >().ToList();

                var problemInserts = new List<(TSqlFragment,string)>();

                foreach (var fragment in InsertFragments)
                {
                    var insertcolumns = fragment.Columns.ToList();
                    if (fragment.Target is VariableTableReference variableTableReference )
                    {
                        FindMissingMandatoryColumns(variableTableReference, allVariableTables, insertcolumns, problemInserts, fragment);
                    }
                    else if (fragment.Target is NamedTableReference table) {
                        if (table.IsAnyTempTableName() )
                            FindMissingMandatoryColumns(table, allTempTables, insertcolumns, problemInserts, fragment);
                        else if ( table.IsLocalObject() )
                            FindMissingMandatoryColumns(table, allTables, insertcolumns, problemInserts, fragment);
                        //FindMissingMandatoryColumns(table, allViews, insertcolumns, problemInserts, fragment); // works but doesn't work
                    }
                }
                foreach (var fragment in InsertMergeFragments)
                {
                    var insertFragment = fragment.ActionClauses.Where(n => n.Action is InsertMergeAction).Select(n => n.Action).FirstOrDefault() as InsertMergeAction;
                    var insertcolumns = insertFragment?.Columns.ToList();
                    // todo need to handle other types somehow
                    if (insertFragment is not null && fragment.Target is VariableTableReference variableTableReference )
                    {
                        FindMissingMandatoryColumns(variableTableReference, allVariableTables, insertcolumns, problemInserts, fragment);
                    }
                    else if (insertFragment is not null && fragment.Target is NamedTableReference table) {
                        if (table.IsAnyTempTableName() )
                            FindMissingMandatoryColumns(table, allTempTables, insertcolumns, problemInserts, fragment);
                        else if ( table.IsLocalObject() )
                            FindMissingMandatoryColumns(table, allTables, insertcolumns, problemInserts, fragment);
                        //FindMissingMandatoryColumns(table, allViews, insertcolumns, problemInserts, fragment); // works but doesn't work
                    }
                }
                foreach (var fragment in OutputIntoFragments)
                {
                    var insertcolumns = fragment.IntoTableColumns.ToList();
                    if (fragment.IntoTable is VariableTableReference variableTableReference )
                    {
                        FindMissingMandatoryColumns(variableTableReference, allVariableTables, insertcolumns, problemInserts, fragment);
                    }
                    else if (fragment.IntoTable is NamedTableReference table) {
                        if (table.IsAnyTempTableName() )
                            FindMissingMandatoryColumns(table, allTempTables, insertcolumns, problemInserts, fragment);
                        else if ( table.IsLocalObject() )
                            FindMissingMandatoryColumns(table, allTables, insertcolumns, problemInserts, fragment);
                        //FindMissingMandatoryColumns(table, allViews, insertcolumns, problemInserts, fragment); // works but doesn't work
                    }
                }

                RuleUtils.UpdateProblems(problems, modelElement, elementName, problemInserts, ruleDescriptor);
            }
            catch
            {
            } // DMVRuleSetup.RuleSetup barfs on 'hidden' temporal history tables 'defined' in sub-projects

            return problems;
            }

        private static void FindMissingMandatoryColumns(VariableTableReference table, IEnumerable<TableDetails> allTables, IReadOnlyCollection<ColumnReferenceExpression> insertcolumns, ICollection<(TSqlFragment,string)> problemInserts, TSqlFragment fragment)
        {
            var objectName = table.Variable.Name ;

            // Match table in query to a table in the model
            // for now stick to tables in the current database ............
            // TODO - allow tables across the board
            var objs = allTables.Where(n => n.TableName.SQLModel_StringCompareEqual(objectName)).Select(n => n).ToList();
            if (objs.Count == 0) return;

            var tbl = objs[0];
            var columns = tbl.TableDefinition.ColumnDefinitions;
            var mandatoryColumns = columns.Where(c => !(c.ComputedColumnExpression      is not null                                     ||   
                                                        c.IdentityOptions               is not null                                     ||
                                                        c.Constraints.Any( n => n is NullableConstraintDefinition x && x.Nullable)      ||
                                                        c.GeneratedAlways               is not null                                     ||
                                                        c.Constraints.Any( n => n is DefaultConstraintDefinition)                       
                )
            ).Select(n => new ColumnDetails
            {   Name = n.ColumnIdentifier.Value,
                DataType = new ObjectIdentifier(n.DataType.Name.BaseIdentifier.Value),
                Nullable = n.Constraints.Any( n => n is NullableConstraintDefinition x && x.Nullable)
            }).ToList();

            var problems = mandatoryColumns.Where(c => !insertcolumns.Any(ic =>
                c.Name.SQLModel_StringCompareEqual(ic.MultiPartIdentifier.Identifiers.Last()
                    .Value))).ToList().ConvertAll(n => (fragment, n.Name));

            if (problems.Count > 0)
            {
                foreach ( var p in problems)
                {
                    problemInserts.Add(p);
                }
            }
        }
        private static void FindMissingMandatoryColumns(NamedTableReference table, IEnumerable<TableDetails> allTables, IReadOnlyCollection<ColumnReferenceExpression> insertcolumns, ICollection<(TSqlFragment,string)> problemInserts, TSqlFragment fragment)
        {
            var objectName = table.SchemaObject.BaseIdentifier.Value;

            // Match table in query to a table in the model
            // for now stick to tables in the current database ............
            // TODO - allow tables across the board
            var objs = allTables.Where(n => n.TableName.SQLModel_StringCompareEqual(objectName)).Select(n => n).ToList();
            if (objs.Count == 0) return;

            var tbl = objs[0];
            var columns = tbl.TableDefinition.ColumnDefinitions;
            var mandatoryColumns = columns.Where(c => !(c.ComputedColumnExpression      is not null                                     ||   
                                                        c.IdentityOptions               is not null                                     ||
                                                        c.Constraints.Any( n => n is NullableConstraintDefinition x && x.Nullable)      ||
                                                        c.GeneratedAlways               is not null                                     ||
                                                        c.Constraints.Any( n => n is DefaultConstraintDefinition)                       
                )
            ).Select(n => new ColumnDetails
            {   Name = n.ColumnIdentifier.Value,
                DataType = new ObjectIdentifier(n.DataType.Name.BaseIdentifier.Value),
                Nullable = n.Constraints.Any( n => n is NullableConstraintDefinition x && x.Nullable)
            }).ToList();

            var problems = mandatoryColumns.Where(c => !insertcolumns.Any(ic =>
                c.Name.SQLModel_StringCompareEqual(ic.MultiPartIdentifier.Identifiers.Last()
                    .Value))).ToList().ConvertAll(n => (fragment, n.Name));

            if (problems.Count > 0)
            {
                foreach ( var p in problems)
                {
                    problemInserts.Add(p);
                }
            }
        }
        private static void FindMissingMandatoryColumns(NamedTableReference table, IEnumerable<TSqlObject> allTables, IReadOnlyCollection<ColumnReferenceExpression> insertcolumns, ICollection<(TSqlFragment,string)> problemInserts, TSqlFragment fragment)
        {
            var objectSchema = table.SchemaObject.SchemaIdentifier?.Value ?? "dbo";
            var objectName = table.SchemaObject.BaseIdentifier.Value;

            // Match table in query to a table in the model
            // for now stick to tables in the current database ............
            // TODO - allow tables across the board
            var objs = allTables
                .Where(n => n.Name?.HasName == true
                            && n.Name.Parts[0].SQLModel_StringCompareEqual(objectSchema)
                            && n.Name.Parts[1].SQLModel_StringCompareEqual(objectName)
                )
                .Select(n => n).ToList();
            if (objs.Count == 0) return;


            var tbl = objs[0];
            var columns = tbl.GetReferenced().Where(x => x.ObjectType == ModelSchema.Column).ToList();
            var mandatoryColumns = columns.Where(c => !(c.GetProperty(Column.Expression) is not null                                                                ||
                                                        (bool)c.GetProperty(Column.IsIdentity) /* unless identity insert is on */                                   ||
                                                        (bool)c.GetProperty(Column.IsIdentityNotForReplication)                                                     ||
                                                        (bool)c.GetProperty(Column.IsPseudoColumn)                                                                  ||
                                                        (bool)c.GetProperty(Column.Nullable)                                                                        ||
                                                        (ColumnGeneratedAlwaysType)c.GetProperty(Column.GeneratedAlwaysType) != ColumnGeneratedAlwaysType.None      ||
                                                        c.GetReferencingRelationshipInstances(DefaultConstraint.TargetColumn).Any()
                )
            ).Select(n => new ColumnDetails
            {   Name = n.Name.Parts.Last(),
                DataType = n.GetReferenced(Column.DataType).FirstOrDefault()?.Name,
                Nullable = (bool)n.GetProperty(Column.Nullable)
            }).ToList();

            var problems = mandatoryColumns.Where(c => !insertcolumns.Any(ic =>
                c.Name.SQLModel_StringCompareEqual(ic.MultiPartIdentifier.Identifiers.Last()
                    .Value))).ToList().ConvertAll(n => (fragment,n.Name));

            if (problems.Count > 0)
            {
                foreach ( var p in problems)
                {
                    problemInserts.Add(p);
                }
            }
        }
    }
}
