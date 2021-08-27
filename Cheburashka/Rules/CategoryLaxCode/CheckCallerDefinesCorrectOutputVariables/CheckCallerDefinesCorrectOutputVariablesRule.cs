﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

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
    /// whenever there is au unused variable in a routine.
    /// </para>
    /// <para>
    /// Note that this uses a Localized export attribute, and hence the rule name and description will be
    /// localized if resource files for different languages are used
    /// </para>
    /// </summary>

    [LocalizedExportCodeAnalysisRule(CheckCallerDefinesCorrectOutputVariablesRule.RuleId,
        RuleConstants.ResourceBaseName,                                             // Name of the resource file to look up display name and description in
        RuleConstants.CheckCallerDefinesCorrectOutputVariablesRuleName,            // ID used to look up the display name inside the resources file
        RuleConstants.CheckCallerDefinesCorrectOutputVariablesProblemDescription,  // ID used to look up the description inside the resources file
        Category = RuleConstants.CategoryNonStrictCodingStyle,                      // Rule category (e.g. "Design", "Naming")
        RuleScope = SqlRuleScope.Element)]                                          // This rule targets specific elements rather than the whole model
    public sealed class CheckCallerDefinesCorrectOutputVariablesRule : SqlCodeAnalysisRule
    {
        /// <summary>
        /// <para>
        /// The Rule ID should resemble a fully-qualified class name. In the Visual Studio UI
        /// rules are grouped by "Namespace + Category", and each rule is shown using "Short ID: DisplayName".
        /// </para>
        /// <para>
        /// For this rule, it will be 
        /// shown as "DM0054: If an output parameter is defined, then ensure the parameter is passed as an output parameter."
        /// </para>
        /// </summary>
        public const string RuleId = RuleConstants.CheckCallerDefinesCorrectOutputVariablesRuleId;

        public CheckCallerDefinesCorrectOutputVariablesRule()
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
            SqlComparer.Comparer = ruleExecutionContext.SchemaModel.CollationComparer;

            List<SqlRuleProblem> problems = new();

            try
            {
                DmvRuleSetup.RuleSetup(ruleExecutionContext, out problems, out TSqlModel model, out TSqlFragment sqlFragment, out TSqlObject modelElement);
                string elementName = RuleUtils.GetElementName(ruleExecutionContext);
                // The rule execution context has all the objects we'll need, including the fragment representing the object,
                // and a descriptor that lets us access rule metadata
                RuleDescriptor ruleDescriptor = ruleExecutionContext.RuleDescriptor;

                DmvSettings.RefreshModelBuiltInCache(ruleExecutionContext.SchemaModel);
                DmvSettings.RefreshConstraintsAndIndexesCache(ruleExecutionContext.SchemaModel);

                
                var allProcedures = DmvSettings.GetProcedures;
                var executeSpecifications = DmTSqlFragmentVisitor.Visit(sqlFragment, new ExecuteSpecificationVisitor()).Cast<ExecuteSpecification>().ToList();
                foreach (var executeSpecification in executeSpecifications.Where( e => e.ExecutableEntity is ExecutableProcedureReference executableProcedureReference && executableProcedureReference.ProcedureReference is not null ))
                {
                    var executableProcedureReference = executeSpecification.ExecutableEntity as ExecutableProcedureReference ;
                    var name = executableProcedureReference?.ProcedureReference?.ProcedureReference?.Name;
                    var number = executableProcedureReference?.ProcedureReference?.ProcedureReference?.Number;
                    var callingParameters = executeSpecification.ExecutableEntity.Parameters;
                    var procedures = allProcedures.Where(p => SqlRuleUtils.ObjectNameMatches(p, name.BaseIdentifier.Value, name.SchemaIdentifier?.Value??"dbo")).ToList();
                    if (procedures.Count > 0)
                    {
                        var procedure = procedures[0];
                        var parameters = procedure.GetReferenced(Procedure.Parameters).ToList();
                        foreach (var parameter in parameters)
                        {
                            var paramName = parameter.Name.Parts[2];
                            var isOutput = (bool)parameter.GetProperty(Parameter.IsOutput);
                            if (isOutput)
                            {
                                var matchingVariable = callingParameters.Where(n=>n.Variable.Name.SQLModel_StringCompareEqual(paramName)).ToList();
                                //if 
                            }
                            var xy = 1;
                        }
                        var x = 1;

                    }
                }

                //bTriggerIsDefinedOnTable = allTables.Contains(table);

                // visitor to get the occurrences of data declarations names
                // DataTypes names are also Microsoft.Data.Schema.ScriptDom.Sql.SchemaObjectName's
                //var executeSpecifications = DmTSqlFragmentVisitor.Visit(sqlFragment, new ExecuteSpecificationVisitor()).Cast<ExecuteSpecification>().ToList();
                

//                RuleUtils.UpdateProblems(problems, modelElement, elementName, issues, ruleDescriptor);
            }
            catch
            {
            } // DMVRuleSetup.RuleSetup barfs on 'hidden' temporal history tables 'defined' in sub-projects

            return problems;
            }
    }
}
