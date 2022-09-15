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
    /// whenever there is a scalar subquery which should be supported by a unique constraint
    /// </para>
    /// <para>
    /// Note that this uses a Localized export attribute, and hence the rule name and description will be
    /// localized if resource files for different languages are used
    /// </para>
    /// </summary>

    [LocalizedExportCodeAnalysisRule( CheckUniqueConstraintImpliedBySubQueryRule.RuleId,
        RuleConstants.ResourceBaseName,                                             // Name of the resource file to look up display name and description in
        RuleConstants.CheckUniqueConstraintImpliedBySubQueryRuleName,               // ID used to look up the display name inside the resources file
        RuleConstants.CheckUniqueConstraintImpliedBySubQueryProblemDescription,     // ID used to look up the description inside the resources file
        Category = RuleConstants.CategoryMissingDerivedConstraints,                 // Rule category (e.g. "Design", "Naming")
        RuleScope = SqlRuleScope.Element)]                                          // This rule targets specific elements rather than the whole model
    public sealed class CheckUniqueConstraintImpliedBySubQueryRule : SqlCodeAnalysisRule
    {
        /// <summary>
        /// The Rule ID should resemble a fully-qualified class name. In the Visual Studio UI
        /// rules are grouped by "Namespace + Category", and each rule is shown using "Short ID: DisplayName".
        /// For this rule, it will be 
        /// shown as "DM0057: Single table sub-queries with and-ed equality filters imply a unique constraint on the source data."
        /// </summary>
        public const string RuleId = RuleConstants.CheckUniqueConstraintImpliedBySubQueryRuleId;

        public CheckUniqueConstraintImpliedBySubQueryRule()
        {
            SupportedElementTypes = SqlRuleUtils.GetCodeAndViewContainingClasses();
        }



        private static bool ProcessCondition(int NestedNotCount, SchemaObjectName tableName, Identifier tableAlias, BooleanExpression condition,List<ColumnDetails> allColumns, ref List<ColumnDetails> tableColumns)
        {
            //tableColumns and otherTableColumns are only fully populated if the function succeeds.

            //var cols = pk.GetReferencedRelationshipInstances(
            //    PrimaryKeyConstraint.Columns, DacQueryScopes.UserDefined);
            //var clustered = (bool)pk.GetProperty(PrimaryKeyConstraint.Clustered);
            //leadingEdgeIndexColumns.AddRange(cols.Select(v => v.ObjectName.Parts[2]));
            //foundIndexThatMatchesAKey = CheckThatForeignKeysAreCoveredByIndex(clusterColumns, foreignKeyColumns, clustered, leadingEdgeIndexColumns);
            //if (foundIndexThatMatchesAKey)
            //{
            //    break;
            //}

            switch (condition)
            {
                case BooleanComparisonExpression booleanCondition:
                    switch (NestedNotCount % 2)
                    {
                        case 0 when booleanCondition.ComparisonType != BooleanComparisonType.Equals:
                        case 1 when booleanCondition.ComparisonType != BooleanComparisonType.NotEqualToBrackets && booleanCondition.ComparisonType != BooleanComparisonType.NotEqualToExclamation:
                            return false;
                    }
                    var lhsReferences = DmTSqlFragmentVisitor.Visit(booleanCondition.FirstExpression, new ColumnReferenceExpressionVisitor()).Cast<ColumnReferenceExpression>().ToList();
                    var rhsReferences = DmTSqlFragmentVisitor.Visit(booleanCondition.SecondExpression, new ColumnReferenceExpressionVisitor()).Cast<ColumnReferenceExpression>().ToList();

                    switch (lhsReferences.Count)
                    {
                        // multiple column refs both side - must be false -- we're looking for conditions like a.somecol = b.someothercol here
                        case > 1 when rhsReferences.Count > 1:
                            return false;
                        // no column refs both side - must be true (really?) -- but doesn't add to our knowledge of what is being referenced
                        case 0 when rhsReferences.Count == 0:
                            return true;
                    }

                    // now get into the meat of looking for column references.
                    var lhSingleMatch = false;
                    var rhSingleMatch = false;

                    var lhMultiMatch = 0;
                    var rhMultiMatch = 0;

                    ColumnDetails lhMatchedColumnDetails = new();
                    ColumnDetails rhMatchedColumnDetails = new();

                    // TODO work out how to handle 3-part/4-part table names provided
                    /* a match occurs when
                        1) a table alias is provided and the reference provided contains that alias and matches a column in the input list
                        2) a table alias is provided and the reference provided contains *NO* alias and matches a column in the input list
                        3) a table alias is *NOT* provided and the reference provided contains *SOME* alias 
                            and that alias matches a fragment of the schema.tablename of the object
                                and matches a column in the input list
                        4) a table alias is *NOT* provided and the reference provided contains *NO* alias and matches a column in the input list
                    */
                    //TODO - make this as robust as possible given there may be references to our table from the containing parts of the query
                    //TODO - as well as element embedded in tlhe LHS/RHS
                    if (booleanCondition.FirstExpression is ColumnReferenceExpression lhReferenceExpression )
                    {
                        var lhColRef = lhReferenceExpression.MultiPartIdentifier.Identifiers.ToList();
                        lhSingleMatch = MatchToSingleTargetColumn(tableAlias, allColumns, lhColRef,ref lhMatchedColumnDetails);
                        // now check the rhs - reject if it contains any column reference to our table
                        // or if our table appears in there in a subquery
                        // the idea is to eliminate any subquery from consideration if it looks like
                        // the uniqueness of the results can be determined be some inter-row or inter-rows relationship
                        // rather than the pure combination of values in the selection criteria.
                        rhMultiMatch = MatchToMultiTargetColumn(tableAlias, allColumns, rhsReferences);

                    }
                    if (booleanCondition.SecondExpression is ColumnReferenceExpression rhReferenceExpression)
                    {
                        var rhColRef = rhReferenceExpression.MultiPartIdentifier.Identifiers.ToList();
                        rhSingleMatch = MatchToSingleTargetColumn(tableAlias, allColumns, rhColRef, ref rhMatchedColumnDetails);
                        // now check the lhs - reject if it contains any column reference to our table
                        // or if our table appears in there in a subquery
                        // the idea is to eliminate any subquery from consideration if it looks like
                        // the uniqueness of the results can be determined be some inter-row or inter-rows relationship
                        // rather than the pure combination of values in the selection criteria.
                        lhMultiMatch = MatchToMultiTargetColumn(tableAlias, allColumns, lhsReferences);
                    }

                    // if both sides contain references to our table - return false
                    // todo simplify amd unify - resharper makes suggestions
                    if ( (lhSingleMatch || rhSingleMatch) && ! (lhSingleMatch && rhSingleMatch) )
                    {
                        // if we have one matching ref on the lhs and none on the rhs - we're good -- todo we're not, but lets leave the complications of that for 
                        if (lhSingleMatch && rhMultiMatch == 0 )
                        {
                            tableColumns.Add(lhMatchedColumnDetails) ;
                        }
                        // if we have one matching ref on the rhs and none on the lhs - we're good -- todo we're not, but lets leave the complications of that for 
                        if (rhSingleMatch && lhMultiMatch == 0 )
                        {
                            tableColumns.Add(rhMatchedColumnDetails) ;
                        }
                        return true;
                    }
                    return false;

                case BooleanNotExpression booleanNotCondition:
                    {
                        if (booleanNotCondition.Expression is BooleanComparisonExpression or BooleanNotExpression or BooleanParenthesisExpression)
                        {
                            return ProcessCondition(NestedNotCount + 1, tableName,tableAlias, booleanNotCondition.Expression, allColumns, ref tableColumns);
                        }

                        if (booleanNotCondition.Expression is BooleanBinaryExpression bexpr)
                        {
                            if (NestedNotCount % 2 == 1 && bexpr.BinaryExpressionType is BooleanBinaryExpressionType.And)
                            {
                                return false;
                            }

                            return ProcessCondition(NestedNotCount + 1, tableName,tableAlias, booleanNotCondition.Expression, allColumns, ref tableColumns);
                        }
                        return false;
                    }

                case BooleanParenthesisExpression booleanParenthesisCondition:
                    return ProcessCondition(NestedNotCount, tableName,tableAlias, booleanParenthesisCondition.Expression, allColumns, ref tableColumns);
                case SubqueryComparisonPredicate subqueryComparisonCondition:
                    if (subqueryComparisonCondition.ComparisonType != BooleanComparisonType.Equals)
                    {
                        return false;
                    }
                    return true;
                case BooleanBinaryExpression booleanBinaryExpression:
                    {
                        if (booleanBinaryExpression.BinaryExpressionType != BooleanBinaryExpressionType.And)
                            return false;

                        if (NestedNotCount % 2 == 1)
                        {
                            return false;
                        }

                        var validExpr = ProcessCondition(NestedNotCount, tableName, tableAlias, booleanBinaryExpression.FirstExpression, allColumns, ref tableColumns);
                        if (validExpr)
                        {
                            return ProcessCondition(NestedNotCount, tableName, tableAlias, booleanBinaryExpression.SecondExpression, allColumns, ref tableColumns);
                        }

                        return false;

                    }
            }
            return false;
        }

        //todo unify and simplify some of this code
        private static bool MatchToSingleTargetColumn(Identifier tableAlias, List<ColumnDetails> allColumns, IReadOnlyList<Identifier> colRef, ref ColumnDetails match)
        {
            var singleMatch = false ;
            var schemaRef = colRef.Count == 3
                    ? colRef[0]
                    : null
                ;
            var tableRef = colRef.Count switch
            {
                3 => colRef[1],
                2 => colRef[0],
                _ => null
            };
            var colNameToMatch = colRef[colRef.Count - 1].Value;

            if (tableAlias is not null)
            {
                if ( // 1)
                    (colRef.Count == 2 && colRef[1].Value.SQLModel_StringCompareEqual(tableAlias.Value))
                    // 2)
                    || colRef.Count == 1
                )
                {
                    singleMatch = SingleMatch(allColumns, colNameToMatch, out match);
                }

            }
            else
            {
                if ( // 3)
                    colRef.Count == 3 && schemaRef is not null && tableRef is not null
                    && schemaRef.Value.SQLModel_StringCompareEqual(colRef[0].Value)
                    && tableRef.Value.SQLModel_StringCompareEqual(colRef[1].Value)
                )
                {
                    singleMatch = SingleMatch(allColumns, colNameToMatch, out match);
                }
                else if ( // 3)
                    colRef.Count == 2 && tableRef?.Value.SQLModel_StringCompareEqual(colRef[0].Value) == true
                )
                {
                    singleMatch = SingleMatch(allColumns, colNameToMatch, out match);
                }
                else if ( // 4)
                    colRef.Count == 1
                )
                {
                    singleMatch = SingleMatch(allColumns, colNameToMatch, out match);
                }
            }
            return singleMatch;
        }

        private static int MatchToMultiTargetColumn(Identifier tableAlias, List<ColumnDetails> allColumns, IReadOnlyList<ColumnReferenceExpression> ColRefs)
        {
            var matchingColumnCount = 0;
            foreach (var colRef in ColRefs)
            {
                var identifier = colRef.MultiPartIdentifier;
                {
                    var singleMatch = false;
                    var schemaRef = identifier.Count == 3
                            ? identifier[0]
                            : null
                        ;
                    var tableRef = identifier.Count switch
                    {
                        3 => identifier[1],
                        2 => identifier[0],
                        _ => null
                    };
                    var colNameToMatch = identifier[identifier.Count - 1].Value;

                    if (tableAlias is not null)
                    {
                        if ( // 1)
                            (identifier.Count == 2 && identifier[1].Value.SQLModel_StringCompareEqual(tableAlias.Value))
                            // 2)
                            || identifier.Count == 1
                        )
                        {
                            singleMatch = SingleMatch(allColumns, colNameToMatch, out _);
                        }

                    }
                    else
                    {
                        if ( // 3)
                            identifier.Count == 3 && schemaRef is not null && tableRef is not null
                            && schemaRef.Value.SQLModel_StringCompareEqual(identifier[0].Value)
                            && tableRef.Value.SQLModel_StringCompareEqual(identifier[1].Value)
                        )
                        {
                            singleMatch = SingleMatch(allColumns, colNameToMatch, out _);
                        }
                        else if ( // 3)
                            identifier.Count == 2 && tableRef?.Value.SQLModel_StringCompareEqual(identifier[0].Value) == true
                        )
                        {
                            singleMatch = SingleMatch(allColumns, colNameToMatch, out _);
                        }
                        else if ( // 4)
                            identifier.Count == 1
                        )
                        {
                            singleMatch = SingleMatch(allColumns, colNameToMatch, out _);
                        }
                    }

                    if (singleMatch)
                    {
                        matchingColumnCount++;
                    }
                }
            }

            return matchingColumnCount;
        }

        private static bool SingleMatch(IEnumerable<ColumnDetails> allColumns, string colNameToMatch, out ColumnDetails match)
        {
            match = allColumns.FirstOrDefault(n => n.Name.SQLModel_StringCompareEqual(colNameToMatch));
            var singleMatch = match.Name is not null;
            return singleMatch;
        }

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext ruleExecutionContext)
        {
            DmvRuleSetup.RuleSetup(ruleExecutionContext, out var problems, out TSqlModel model, out TSqlFragment sqlFragment, out TSqlObject modelElement);
            DmvSettings.RefreshModelBuiltInCache(model);
            DmvSettings.RefreshConstraintsAndIndexesCache(model);
            var allTables = DmvSettings.GetTables;

            // Get Model collation 
            SqlComparer.Comparer = ruleExecutionContext.SchemaModel.CollationComparer;

            string elementName = RuleUtils.GetElementName(ruleExecutionContext);
            // The rule execution context has all the objects we'll need, including the fragment representing the object,
            // and a descriptor that lets us access rule metadata
            DmvSettings.RefreshModelBuiltInCache(ruleExecutionContext.SchemaModel);

            //var sql = sqlFragment.SQLModel_AsText();

            //find occurrences of these and eliminate them from consideration
            var inAndExistsSubqueries = DmTSqlFragmentVisitor.Visit(sqlFragment, new InAndExistsQueryVisitor()).Cast<ScalarSubquery>().ToList();
            var singleSourceSubQueries = DmTSqlFragmentVisitor.Visit(sqlFragment, new SingleSourceSubQueryEqualityConjunctionVisitor()).Cast<ScalarSubquery>().ToList();
            var validSingleSourceSubQueries = singleSourceSubQueries.Where(n => !inAndExistsSubqueries.Any(ies => Equals(ies, n))).ToList();
            List<ScalarSubquery> checkedSingleSourceSubQueries = new();

            //todo the table name checking needs augmenting with cte detection etc in the parent query
            // eg like here
            //;WITH someTableinDefaultSchema AS ( SELECT 1 AS a)
            //SELECT * 
            //    , ( SELECT a FROM someTableinDefaultSchema)
            //    , (SELECT a FROM someTableinDefaultSchema WHERE a = xx.a)
            //FROM someTableinDefaultSchema a
            //    CROSS JOIN (SELECT * FROM someTableinDefaultSchema )xx

            foreach (var singleSourceSubQuery in validSingleSourceSubQueries)
            {   
                //do all this work again thats been done in the iterator - sigh .........
                List<QuerySpecification> querySpecifications = new();
                SqlGatherQuery.GetQuery(singleSourceSubQuery, ref querySpecifications);
                if (querySpecifications[0] is { ForClause: null } query
                && query.FromClause.TableReferences[0] is NamedTableReference namedTableReference
                && namedTableReference.IsLocalObject() //TODO remove this restriction 
                    )
                {
                    //var singleSourceSubQuerySQL = singleSourceSubQuery.SQLModel_AsText();

                    var objectSchema = namedTableReference.SchemaObject.SchemaIdentifier?.Value ?? "dbo" ;
                    var objectName   = namedTableReference.SchemaObject.BaseIdentifier.Value;

                    // Match table in query to a table in the model
                    // for now stick to tables in the current database ............
                    // TODO - allow tables across the board
                    List<TSqlObject> objs = allTables
                        .Where(n => n.Name?.HasName == true
                                    && n.Name.Parts[0].SQLModel_StringCompareEqual(objectSchema)
                                    && n.Name.Parts[1].SQLModel_StringCompareEqual(objectName)
                        )
                        .Select(n => n).ToList();

                    var alias = namedTableReference.Alias;
                    var tableName = namedTableReference.SchemaObject;
                    if (objs.Count > 0)
                    {
                        var tbl = objs[0] ;
                        //var columnSpecifications = tbl.GetReferencedRelationshipInstances(Table.Columns, DacQueryScopes.UserDefined).ToList();
                        var columns = tbl.GetReferenced().Where(x => x.ObjectType == ModelSchema.Column).ToList();
                        //var columnTypes = columns.Select( n => n.GetReferenced(Column.DataType).FirstOrDefault().Name).ToList();
                        //var columnNulls = columns.Select( n => n.GetProperty(Column.Nullable)).ToList();
                        var columnSpecifications = columns.Select( n => new ColumnDetails { Name = n.Name.Parts.Last(), DataType = n.GetReferenced(Column.DataType).FirstOrDefault()?.Name, Nullable = (bool)n.GetProperty(Column.Nullable)}).ToList();

                        var condition = query.WhereClause.SearchCondition;

                        //var condDQL = condition.SQLModel_AsText();

                        //iterate over conditions,
                        //pull out the pairs, ensure that one is column reference only and member of the table
                        //if there are no column refs its not a problem here - but another rule could pick this up.

                        List<ColumnDetails> tableColumns      = new();
                        List<ColumnReferenceExpression> otherTableColumns = new();

                        var validClause = ProcessCondition(0, tableName, alias, condition, columnSpecifications, ref tableColumns);
                        var distinctColumnNames = tableColumns.Select(n => n.Name).Distinct().ToList();

                        List<TSqlObject> pks = ModelIndexAndKeysUtils.GetPrimaryKeys(objectSchema, objectName);
                        List<TSqlObject> uniqueIndexes = ModelIndexAndKeysUtils.GetUniqueIndexes(objectSchema, objectName);
                        List<TSqlObject> uniqueConstraints = ModelIndexAndKeysUtils.GetUniqueConstraints(objectSchema, objectName);

                        if (tableColumns.Count> 0) {
                            var foundAUniqueConstraintForEqualityColumns = FindAUniqueConstraintForEqualityColumns(pks, distinctColumnNames, PrimaryKeyConstraint.Columns);
                            if (!foundAUniqueConstraintForEqualityColumns) 
                                foundAUniqueConstraintForEqualityColumns = FindAUniqueConstraintForEqualityColumns(uniqueIndexes, distinctColumnNames, Index.Columns);
                            if (!foundAUniqueConstraintForEqualityColumns) 
                                foundAUniqueConstraintForEqualityColumns = FindAUniqueConstraintForEqualityColumns(uniqueConstraints, distinctColumnNames, UniqueConstraint.Columns);

                            if (!foundAUniqueConstraintForEqualityColumns && validClause)
                            {
                                checkedSingleSourceSubQueries.Add(singleSourceSubQuery);
                            }
                        }
                    }
                    else
                    {
                        // do nothing it's a bust
                    }

                }
            }

            RuleDescriptor ruleDescriptor = ruleExecutionContext.RuleDescriptor;
            RuleUtils.UpdateProblems( problems, modelElement, elementName, checkedSingleSourceSubQueries.Cast<TSqlFragment>().ToList(), ruleDescriptor);

            return problems;
        }

        private static bool FindAUniqueConstraintForEqualityColumns(List<TSqlObject> pks, List<string> distinctColumnNames, ModelRelationshipClass Columns)
        {
            var foundAUniqueConstraintForEqualityColumns = false;
            foreach (var pk in pks)
            {
                var cols = pk.GetReferencedRelationshipInstances(Columns, DacQueryScopes.UserDefined);
                var icolumns = cols.Select(v => v.ObjectName.Parts[2]).ToList();
                foundAUniqueConstraintForEqualityColumns = CheckListAWhollyContainsListB(distinctColumnNames, icolumns);
                if (foundAUniqueConstraintForEqualityColumns) 
                    break;
            }

            return foundAUniqueConstraintForEqualityColumns;
        }

        private static bool CheckListAWhollyContainsListB(IEnumerable<string> A, IReadOnlyCollection<string> B)
        {
            var result = A.Where(a => B.Any(a.SQLModel_StringCompareEqual)).ToList();
            return result.Count == B.Count;
        }
    }
}
