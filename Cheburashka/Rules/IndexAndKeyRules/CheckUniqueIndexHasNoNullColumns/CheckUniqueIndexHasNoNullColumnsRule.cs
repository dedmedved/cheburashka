using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using Microsoft.Data.Schema.Extensibility;
using Microsoft.Data.Schema.SchemaModel;
using Microsoft.Data.Schema.ScriptDom.Sql;
using Microsoft.Data.Schema.Sql.SchemaModel;
using Microsoft.Data.Schema.Sql;
using Microsoft.Data.Schema.StaticCodeAnalysis;
using System.Text.RegularExpressions;
using Microsoft.Data.Schema.SchemaModel.Abstract;

using System.Linq;

namespace Cheburashka
{
    /// <summary>
    /// This is a SQL rule which returns a warning message 
    /// whenever there is a ........................................
    /// This rule only applies to .................................
    /// </summary>

    [DatabaseSchemaProviderCompatibility(typeof(SqlDatabaseSchemaProvider))]
    [DataRuleAttribute(
        NeznaykaConstants.NameSpace,
        NeznaykaConstants.CheckUniqueIndexHasNoNullColumnsRuleId,
        NeznaykaConstants.ResourceBaseName,
        NeznaykaConstants.CheckUniqueIndexHasNoNullColumns_RuleName,
        NeznaykaConstants.CategoryDatabaseStructures,
        DescriptionResourceId = NeznaykaConstants.CheckUniqueIndexHasNoNullColumns_ProblemDescription)]
    [SupportedElementType(typeof(ISqlIndex))]
    public class CheckUniqueIndexHasNoNullColumnsRule : StaticCodeAnalysisRule
    {
        #region Overrides
        /// <summary>
        /// Analyze the model element
        /// </summary>
        public override IList<DataRuleProblem> Analyze(DataRuleSetting ruleSetting, DataRuleExecutionContext context)
        {
            // (Re)-Load Environment settings

            List<DataRuleProblem> problems;
return problems;
            SqlSchemaModel sqlSchemaModel;
            ISqlModelElement sqlElement;
            TSqlFragment sqlFragment;
            DMVRuleSetup.RuleSetup(context, out problems, out sqlSchemaModel, out sqlElement, out sqlFragment);

// we probably need to alter all this if we decide to cover indexes created by code.

            // Refresh cached index/constraints/tables lists from Model
            DMVRuleSetup.RefreshDDLCache(sqlSchemaModel);

            // Get Database Schema and name of this model element.
            string owningObjectSchema;
            string owningObjectTable;
            DMVRuleSetup.getOwningObject(sqlElement, out owningObjectSchema, out owningObjectTable);


            // visitor to get the columns
            CheckUniqueIndexHasNoNullColumnsVisitor checkUniqueIndexHasNoNullColumnsVisitor = new CheckUniqueIndexHasNoNullColumnsVisitor();
            sqlFragment.Accept(checkUniqueIndexHasNoNullColumnsVisitor);
            List<ColumnWithSortOrder> indexColumns = checkUniqueIndexHasNoNullColumnsVisitor.Objects;
            // cannot be null
            List<ISqlSimpleColumn> tableColumns = new List<ISqlSimpleColumn>();
            tableColumns = DMVSettings.tableColumns( owningObjectSchema + @"." + owningObjectTable).ToList();
            if (tableColumns.Count != 0)
            {
                
                IEnumerable<ColumnWithSortOrder> nullableIndexColumns = from iCOl in indexColumns
                                                                        from tCol in tableColumns
                                                                        where SqlComparer.CompareEqual(iCOl.ColumnIdentifier.Value, tCol.Name.Parts[2])
                                                                        where tCol.IsNullable
                                                                        select iCOl;

                List<TSqlFragment> issues = new List<TSqlFragment>();
                foreach (var col in nullableIndexColumns) 
                {
                    issues.Add(col);
                }
                // Create problems for each object
                foreach (TSqlFragment issue in issues)
                {
                    DataRuleProblem problem = new DataRuleProblem(this,
                                                String.Format(CultureInfo.CurrentCulture, this.RuleProperties.Description, SqlRuleUtils.GetElementName(sqlSchemaModel, sqlElement)),
                                                sqlElement);

                    SqlRuleUtils.UpdateProblemPosition(problem, issue.StartOffset, issue.FragmentLength);
                    problems.Add(problem);
                }
            }


            return problems;
        }

        #endregion    
 
    }
}
