using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheburashka.IndexAndKeyRules.EnforceForeignKeyIsIndexedRule
{
    class EnforceForeignKeyIsIndexedRule
    {
    }
}

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

using System.Linq;

namespace Neznayka
{
    /// <summary>
    /// This is a SQL rule which returns a warning message 
    /// whenever there is a ........................................
    /// This rule only applies to .................................
    /// </summary>

    [DatabaseSchemaProviderCompatibility(typeof(SqlDatabaseSchemaProvider))]
    [DataRuleAttribute(
        NeznaykaConstants.NameSpace,
        NeznaykaConstants.EnforceForeignKeyIsIndexedRuleId,
        NeznaykaConstants.ResourceBaseName,
        NeznaykaConstants.EnforceForeignKeyIsIndexed_RuleName,
        NeznaykaConstants.CategoryDatabaseStructures,
        DescriptionResourceId = NeznaykaConstants.EnforceForeignKeyIsIndexed_ProblemDescription)]
    [SupportedElementType(typeof(ISqlForeignKeyConstraint))]
    public class EnforceForeignKeyIsIndexedRule : StaticCodeAnalysisRule
    {
        #region Overrides
        /// <summary>
        /// Analyze the model element
        /// </summary>
        public override IList<DataRuleProblem> Analyze(DataRuleSetting ruleSetting, DataRuleExecutionContext context) {
            // (Re)-Load Environment settings

            List<DataRuleProblem> problems;
            SqlSchemaModel sqlSchemaModel;
            ISqlModelElement sqlElement;
            TSqlFragment sqlFragment;
            DMVRuleSetup.RuleSetup(context, out problems, out sqlSchemaModel, out sqlElement, out sqlFragment);

            // Refresh cached index/constraints/tables lists from Model
            DMVRuleSetup.RefreshDDLCache(sqlSchemaModel);

            ISqlForeignKeyConstraint self = sqlElement as ISqlForeignKeyConstraint;

            if (self != null) {
                //string selfSchema = self.Name.Parts[0];
                //string selfTable  = self.Name.Parts[1];

                // Get Database Schema and name of this model element.
                string owningObjectSchema = self.DefiningTable.Name.Parts[0];
                string owningObjectTable = self.DefiningTable.Name.Parts[1];

                List<ISqlPrimaryKeyConstraint> pks = ModelIndexAndKeysUtils.getPrimaryKeys(owningObjectSchema, owningObjectTable);
                List<ISqlIndex> indexes = ModelIndexAndKeysUtils.getIndexes(owningObjectSchema, owningObjectTable);
                List<ISqlUniqueConstraint> uniqueConstraints = ModelIndexAndKeysUtils.getUniqueConstraints(owningObjectSchema, owningObjectTable);

                bool indexExists = (indexes.Count > 0);
                bool uniqueConstraintExists = (uniqueConstraints.Count > 0);
                bool primaryKeyExists = (pks.Count > 0);

                List<String> ClusterColumns = ModelIndexAndKeysUtils.getClusteredKeyColumns(owningObjectSchema, owningObjectTable);

                List<TSqlFragment> issues = new List<TSqlFragment>();

                bool foundIndexThatMatchesAKey = false;
                if (indexExists || uniqueConstraintExists || primaryKeyExists) {
                    List<String> ForeignKeyColumns = self.Columns.Select(n => n.Name.Parts[2]).ToList();

                    if (indexExists) {
                        foreach (var index in indexes) {
                            List<String> LeadingEdgeIndexColumns = new List<String>();
                            foreach (var c in index.ColumnSpecifications) {
                                String lastElement = "";
                                foreach (var n in c.Column.Name.Parts) {
                                    lastElement = n;
                                }
                                LeadingEdgeIndexColumns.Add(lastElement);
                            }
                            foundIndexThatMatchesAKey = checkThatForeignKeysAreCoveredByIndex(ClusterColumns, ForeignKeyColumns, index.IsClustered, LeadingEdgeIndexColumns);
                            if (foundIndexThatMatchesAKey) {
                                break;
                            }
                        }
                    }
                    if (uniqueConstraintExists && !foundIndexThatMatchesAKey) {
                        foreach (var constraint in uniqueConstraints) {
                            List<String> LeadingEdgeIndexColumns = new List<String>();
                            foreach (var c in constraint.ColumnSpecifications) {
                                String lastElement = "";
                                foreach (var n in c.Column.Name.Parts) {
                                    lastElement = n;
                                }
                                LeadingEdgeIndexColumns.Add(lastElement);
                            }
                            foundIndexThatMatchesAKey = checkThatForeignKeysAreCoveredByIndex(ClusterColumns, ForeignKeyColumns, constraint.IsClustered, LeadingEdgeIndexColumns);
                            if (foundIndexThatMatchesAKey) {
                                break;
                            }
                        }
                    }
                    if (primaryKeyExists && !foundIndexThatMatchesAKey) {
                        foreach (var pk in pks) {
                            List<String> LeadingEdgeIndexColumns = new List<String>();
                            foreach (var c in pk.ColumnSpecifications) {
                                String lastElement = "";
                                foreach (var n in c.Column.Name.Parts) {
                                    lastElement = n;
                                }
                                LeadingEdgeIndexColumns.Add(lastElement);
                            }
                            foundIndexThatMatchesAKey = checkThatForeignKeysAreCoveredByIndex(ClusterColumns, ForeignKeyColumns, pk.IsClustered, LeadingEdgeIndexColumns);
                            if (foundIndexThatMatchesAKey) {
                                break;
                            }
                        }
                    }
                }

                if (!foundIndexThatMatchesAKey) {
                    issues.Add(sqlFragment);
                }


                // Create problems for each object
                foreach (TSqlFragment issue in issues) {
                    DataRuleProblem problem = new DataRuleProblem(this,
                                                String.Format(CultureInfo.CurrentCulture, this.RuleProperties.Description, SqlRuleUtils.GetElementName(sqlSchemaModel, sqlElement)),
                                                sqlElement);

                    SqlRuleUtils.UpdateProblemPosition(problem, issue.StartOffset, issue.FragmentLength);
                    problems.Add(problem);
                }

            }

            return problems;
        }

        private static bool checkThatForeignKeysAreCoveredByIndex(List<String> ClusterColumns, List<String> ForeignKeyColumns, bool ClusteredIndex, List<String> LeadingEdgeIndexColumns) {
            bool foundIndexThatMatchesAKey = false;

            List<Int32> allPos = ModelIndexAndKeysUtils.getCorrespondingKeyPositions(ForeignKeyColumns, LeadingEdgeIndexColumns);
            List<Int32> matchedPos = allPos.Where(n => n != -1).Select(n => n).ToList();

            // if every fk column was found in the index
            // and found within the leading n columns, we're ok.
            // we assume no duplicate columns in the fk or index.
            // adjusted for 0-based arrays
            if (matchedPos.Count == allPos.Count
                && matchedPos.Count > 0
                && matchedPos.Count - 1 == matchedPos.Max()
                ) {
                foundIndexThatMatchesAKey = true;
            }
            // else if *this* particular index is not clustered and there *are* clustered columns 
            // check that any remaining unmatched keys can be found in the included columns.
            // whilst ensuring all columns we have found live in the first n columns in the index.
            else if (!ClusteredIndex && ClusterColumns.Count > 0) {
                // the leading edge columns must still have been found in the first n columns of the index
                // and there must be no other trailing elements in the actual key of the index.
                // and I'm still making these rules up on the fly.
                // adjusted for 0-based arrays
                if (matchedPos.Count == LeadingEdgeIndexColumns.Count()
                    && matchedPos.Count > 0
                    && matchedPos.Count - 1 == matchedPos.Max()
                    ) {
                    String[] arForeignKeyColumns = ForeignKeyColumns.ToArray();
                    List<String> unMatchedForeignKeyColumns = new List<String>();
                    for (int i = 0; i < allPos.Count; i++) {
                        if (allPos[i] == -1) {
                            unMatchedForeignKeyColumns.Add(arForeignKeyColumns[i]);
                        }
                    }

                    List<Int32> remainingPos = ModelIndexAndKeysUtils.getCorrespondingKeyPositions(unMatchedForeignKeyColumns, ClusterColumns);
                    List<Int32> remainingAndMatchedToClusteringKeyPos = remainingPos.Where(n => n != -1).Select(n => n).ToList();

                    // if we found all the unmatched columns in the cluster key we're home and dry !
                    if (remainingAndMatchedToClusteringKeyPos.Count == remainingPos.Count) {
                        foundIndexThatMatchesAKey = true;
                    }
                }
            }

            return foundIndexThatMatchesAKey;
        }

        #endregion

    }
}
