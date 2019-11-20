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

using Cheburashka.Utility_Classes;
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
using QuickGraph;
using QuickGraph.Graphviz;
using QuickGraph.Graphviz.Dot;

namespace Cheburashka
{

    public sealed class FileDotEngine : IDotEngine
    {
        public string Run(GraphvizImageType imageType, string dot, string outputFileName)
        {
            string output = outputFileName;
            File.WriteAllText(output, dot);

            // assumes dot.exe is on the path:
            var args = string.Format(@"{0} -Tjpg -O", output);
            System.Diagnostics.Process.Start(@"C:\Program Files (x86)\Graphviz2.38\bin\dot.exe", args);
            return output;
        }
    }
    /// <summary>
    /// This is a SQL rule which returns a warning message 
    /// whenever there is a variable in a routine that is only ever written to.
    /// 
    /// Note that this uses a Localized export attribute, and hence the rule name and description will be
    /// localized if resource files for different languages are used
    /// </summary>
    [LocalizedExportCodeAnalysisRule(AvoidWriteOnlyVariablesRule.RuleId,
        RuleConstants.ResourceBaseName,                                     // Name of the resource file to look up displayname and description in
        RuleConstants.AvoidWriteOnlyVariables_RuleName,                     // ID used to look up the display name inside the resources file
        RuleConstants.AvoidWriteOnlyVariables_ProblemDescription,           // ID used to look up the description inside the resources file
        Category = RuleConstants.CategoryVariableUsage,                     // Rule category (e.g. "Design", "Naming")
        RuleScope = SqlRuleScope.Element)]                                  // This rule targets specific elements rather than the whole model
    public sealed class AvoidWriteOnlyVariablesRule : SqlCodeAnalysisRule
    {
        /// <summary>
        /// The Rule ID should resemble a fully-qualified class name. In the Visual Studio UI
        /// rules are grouped by "Namespace + Category", and each rule is shown using "Short ID: DisplayName".
        /// For this rule, it will be 
        /// shown as "DM0023: Avoid using Return statements with no explicit return value in Stored Procedures."
        /// </summary>
        public const string RuleId = RuleConstants.AvoidWriteOnlyVariables_RuleId;

        public AvoidWriteOnlyVariablesRule()
        {
            // This rule supports Procedures. Only those objects will be passed to the Analyze method
            SupportedElementTypes = new[]
            {
                // Note: can use the ModelSchema definitions, or access the TypeClass for any of these types
                //ModelSchema.ExtendedProcedure,
                ModelSchema.Procedure,
                ModelSchema.TableValuedFunction,
                ModelSchema.ScalarFunction,

                ModelSchema.DatabaseDdlTrigger,
                ModelSchema.DmlTrigger,
                ModelSchema.ServerDdlTrigger
            };
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

            List<SqlRuleProblem> problems = new List<SqlRuleProblem>();
            TSqlModel           model;
            TSqlObject          modelElement;
            TSqlFragment        sqlFragment;

            DMVRuleSetup.RuleSetup(ruleExecutionContext, out problems, out model, out sqlFragment, out modelElement);

            string elementName = RuleUtils.GetElementName(ruleExecutionContext, modelElement);

            // The rule execution context has all the objects we'll need, including the fragment representing the object,
            // and a descriptor that lets us access rule metadata

            RuleDescriptor ruleDescriptor = ruleExecutionContext.RuleDescriptor;

            DMVSettings.RefreshModelBuiltInCache(ruleExecutionContext.SchemaModel);


            // visitor to get the declarations of variables
            var declarationVisitor = new VariableDeclarationVisitor();
            sqlFragment.Accept(declarationVisitor);
            IList<Identifier> variableDeclarations = declarationVisitor.VariableDeclarations;

            // visitor to get parameter names - these look like variables and need removing
            // from variable references before we use them
            // !!! THIS DOESNT SEEM TO WORK - did it ever - even in the old codebase ?!!!! 
            var namedParameterUsageVisitor = new NamedParameterUsageVisitor();
            sqlFragment.Accept(namedParameterUsageVisitor);
            IEnumerable<VariableReference> namedParameters = namedParameterUsageVisitor.NamedParameters;

            // visitor to get the occurrences of variables
            var usageVisitor = new VariableUsageVisitor();
            sqlFragment.Accept(usageVisitor);
            IEnumerable<VariableReference> allVariableLikeReferences = usageVisitor.VariableReferences;

            // get all assignments to variables
            var updatedVariableVisitor = new UpdatedVariableVisitor();
            sqlFragment.Accept(updatedVariableVisitor);
            //List<SQLExpressionDependency> setVariables = updatedVariableVisitor.SetVariables;
            IEnumerable<SQLExpressionDependency> allSetVariables = updatedVariableVisitor.SetVariables;

            //// remove all named parameters from the list of referenced variables
            //// broken see replacement below
            //IEnumerable<VariableReference> tmpVr = allVariableLikeReferences.Except(namedParameters, new SqlVariableReferenceComparer());
            //List<VariableReference> variableReferences = tmpVr.ToList();

            // remove all named parameters from the list of referenced variables
            // broken see replacement below
            // also equality doesn't honour sql server  collation
            IEnumerable<VariableReference> tmpVr =
                        from varReference in allVariableLikeReferences
                        join varDeclaration in variableDeclarations
                            on 1 equals 1 // fake out the on clause
                        where SqlComparer.SQLModel_StringCompareEqual(varReference.Name, varDeclaration.Value) // real condition
                        select varReference;


            //// rewritten as method chain to allow use of collations
            //IEnumerable<VariableReference> tmpVr = 
            //    allVariableLikeReferences.Join( variableDeclarations
            //                                  , varReference => varReference.Name
            //                                  , varDeclaration => varDeclaration.Value
            //                                  , (varReference, varDeclaration) => varReference
            //                                  , SqlComparer.Comparer
            //                                  );

            List<VariableReference> variableReferences = tmpVr.ToList();

            //var query = allVariableLikeReferences.Join
            //(variableDeclarations
            //, varReference => varReference.Name
            //, varDeclaration => varDeclaration.Value
            //, (varReference) => new { x = varReference  } 
            //, SqlComparer.Comparer.Compare
            //);


            // remove all named parameters from the list of set variables
            IEnumerable<SQLExpressionDependency> tmpSetVr =
                        from varSetVar in allSetVariables
                        join varDeclaration in variableDeclarations
                        on 1 equals 1  // fake out the on clause
                        where SqlComparer.SQLModel_StringCompareEqual(varSetVar.Variable.Name, varDeclaration.Value) // real condition
                        select varSetVar;

            //// rewritten as method chain to allow use of collations
            //IEnumerable<SQLExpressionDependency> tmpSetVr = 
            //    allSetVariables.Join( variableDeclarations
            //                        , varSetVar => varSetVar.Variable.Name
            //                        , varDeclaration => varDeclaration.Value
            //                        , (varSetVar, varDeclaration) => varSetVar
            //                        , SqlComparer.Comparer
            //                        );

            List<SQLExpressionDependency> setVariables = tmpSetVr.ToList();

            // find all non-assignment contexts of variable usage.  These OUGHT to be ALL the evidence we need to 
            // show that a variable isn't being needlessly computed.

            var nonAssignmentContextVariableReferences = new Dictionary<string, List<VariableReference>>(SqlComparer.Comparer);
            foreach (var varRef in variableReferences)
            {
                bool assignmentRefFound = false;
                foreach ( var codeFragment in setVariables.Select(n => n.Context) )
                {
                    if ( codeFragment.SQLModel_Contains(varRef))
                    {
                        assignmentRefFound = true;
                    }
                }
                if ( ! assignmentRefFound )
                {
                    if (!nonAssignmentContextVariableReferences.ContainsKey(varRef.Name))
                    {
                        nonAssignmentContextVariableReferences.Add(varRef.Name, new List<VariableReference>());
                    }
                    nonAssignmentContextVariableReferences[varRef.Name].Add(varRef);
                }
            }


            var graphComparer = ruleExecutionContext.SchemaModel.CollationComparer;

            var writeDependencies = new BidirectionalGraph<string,Edge<string>>(false,-1,-1, SqlComparer.Comparer);

            writeDependencies.AddVertex("TERMINATE");
            writeDependencies.AddVertexRange(variableDeclarations.Select(n => n.Value));
            writeDependencies.AddEdgeRange(
                nonAssignmentContextVariableReferences.Select((n => new Edge<string>(n.Key, "TERMINATE"))));


            foreach (var setVariable in setVariables)
            {
                foreach (var dependency in setVariable.Dependencies)
                {
                    // only add the dependency if it is an actual variable -- looks like our code picks up *everything* syntactically like a variable.
                    if (variableReferences.Contains(dependency))
                    {
                        var freeVariable = setVariable.Variable.Name;
                        var dependentVariable = dependency.Name;
                        writeDependencies.AddEdge(new Edge<string>(dependentVariable, freeVariable));
                    }
                }
            }
            // compute transitive dependencies

            writeDependencies = writeDependencies.ComputeTransitiveClosure();

            // mark the variables that are assigned by assigning a path from a dummy node.
            writeDependencies.AddVertex("WRITTENTO");
            writeDependencies.AddEdgeRange(
                setVariables.Select((n => new Edge<string>("WRITTENTO",n.Variable.Name))));

            //IVertexAndEdgeListGraph<string, Edge<string>> g = writeDendencies;
            //var gviz = new GraphvizAlgorithm<string, Edge<string>>(g);
            //string s = gviz.Generate(new FileDotEngine(), @"C:\temp\" + elementName);

            // now need to find all variable references that aren't directly in a variable assignment of any kind.


            var consumedVariables = (from edge in writeDependencies.Edges where edge.Target == "TERMINATE" select edge.Source).ToList().Distinct();
            
            var unConsumedVariables = setVariables.Where(n => ! consumedVariables.Contains(n.Variable.Name))
                                                  .Select(n => n.Variable.Name)
                                                  .Distinct()
                                                  .ToList();

//            var usedVariables = (from edge in writeDependencies.Edges where edge.Source == "WRITTENTO" select edge.Target).ToList().Distinct();
//            var unUsedVariables = setVariables.Where(n => ! usedVariables.Contains(n.Variable.Name));
//            var unConsumedButSetVariables = unConsumedVariables.Where( n => ! );

            var objects = new Dictionary<string, object>(SqlComparer.Comparer);
            foreach (Identifier variableDeclaration in variableDeclarations)
            {
                objects.Add(variableDeclaration.Value, variableDeclaration);
            }

            foreach (var v in unConsumedVariables)
            {
                SqlRuleProblem problem =
                    new SqlRuleProblem(
                        String.Format(CultureInfo.CurrentCulture, ruleDescriptor.DisplayDescription, elementName)
                        , modelElement
                        , sqlFragment);


                RuleUtils.UpdateProblemPosition(modelElement, problem, ((Identifier)objects[v]));
                problems.Add(problem);
            }

            return problems;

        }

    }
}
