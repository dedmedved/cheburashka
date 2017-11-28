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
    /// <summary>
    /// This is a SQL rule which returns a warning message 
    /// whenever there is a ........................................
    /// This rule only applies to .................................
    /// </summary>

    [DatabaseSchemaProviderCompatibility(typeof(SqlDatabaseSchemaProvider))]
    [DataRuleAttribute(
        NeznaykaConstants.NameSpace,
        NeznaykaConstants.CheckForDuplicatedColumnsInIndexOrConstraintRuleId,
        NeznaykaConstants.ResourceBaseName,
        NeznaykaConstants.CheckForDuplicatedColumnsInIndexOrConstraint_RuleName,
        NeznaykaConstants.CategoryDatabaseStructures,
        DescriptionResourceId = NeznaykaConstants.CheckForDuplicatedColumnsInIndexOrConstraint_ProblemDescription)]
    [SupportedElementType(typeof(ISqlIndex))]
    [SupportedElementType(typeof(ISqlPrimaryKeyConstraint))]
    [SupportedElementType(typeof(ISqlUniqueConstraint))]
    public class CheckForDuplicatedColumnsInIndexOrConstraintRule : StaticCodeAnalysisRule
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

            List<TSqlFragment> issues = new List<TSqlFragment>();

            ISqlIndex idx = sqlElement as ISqlIndex;
            ISqlPrimaryKeyConstraint pk = sqlElement as ISqlPrimaryKeyConstraint;
            ISqlUniqueConstraint uk = sqlElement as ISqlUniqueConstraint;

            List<ISqlIndexedColumnSpecification> colSpec = null;
            if (idx != null) {
                colSpec = idx.ColumnSpecifications.ToList();
            }
            else if (pk != null) {
                colSpec = pk.ColumnSpecifications.ToList();
            }
            else if (uk != null) {
                colSpec = uk.ColumnSpecifications.ToList();
            }

            if (colSpec != null) {
                List<String> cols = new List<String>();

                String lastElement = "";
                foreach (var c in colSpec) {
                    foreach (var n in c.Column.Name.Parts) {
                        lastElement = n;
                    }
                    cols.Add(lastElement);
                }
                List<String> uniqCols = cols.Distinct().Select(n => n).ToList();

                if (uniqCols.Count != cols.Count) {
                    issues.Add(sqlFragment);
                }
            }

            // Create problems for each object
            foreach (TSqlFragment issue in issues) {
                DataRuleProblem problem = new DataRuleProblem(this,
                                            String.Format(CultureInfo.CurrentCulture, this.RuleProperties.Description, SqlRuleUtils.GetElementName(sqlSchemaModel, sqlElement)),
                                            sqlElement);

                SqlRuleUtils.UpdateProblemPosition(problem, issue.StartOffset, issue.FragmentLength);
                problems.Add(problem);
            }


            return problems;
        }

        #endregion

    }
}
