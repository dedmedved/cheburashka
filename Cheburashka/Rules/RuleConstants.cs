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

using Microsoft.SqlServer.Dac.Extensibility;

namespace Cheburashka
{
    internal static class RuleConstants
    {
        /// <summary>
        /// The name of the resources file to use when looking up rule resources
        /// </summary>
        public const string ResourceBaseName = "Cheburashka.RuleResources";


        public const string AvoidUninitialisedVariables_RuleId = "Cheburashka.DM0001";
        public const string AvoidUnusedVariables_RuleId = "Cheburashka.DM0002";
        public const string AvoidWriteOnlyVariables_RuleId = "Cheburashka.DM0003";
        public const string AvoidUnusedTableVariable_RuleId = "Cheburashka.DM0004";
        public const string AvoidUnusedParameter_RuleId = "Cheburashka.DM0005";

        public const string EnforcePrimaryKey_RuleId                    = "Cheburashka.DM0011";
        public const string EnforceClusteredIndex_RuleId                = "Cheburashka.DM0012";

        public const string CheckForDuplicatedColumnsInIndexOrConstraintRuleId  = "DM0015";

        public const string CheckUniqueIndexHasNoNullColumnsRuleId      = "Cheburashka.DM0017";
        public const string CheckUniqueConstraintHasNoNullColumnsRuleId = "Cheburashka.DM0018";

        public const string CheckClusteredKeyColumnsNotIncludedInIndexRuleId = "DM0020";

        public const string EnforceNamedConstraintRuleId                = "Cheburashka.DM0022";

        
        public const string AvoidBareReturn_RuleId = "Cheburashka.DM0023";
        public const string AvoidDirectUseOfRowcount_RuleId = "Cheburashka.DM0024";
        public const string AvoidGoto_RuleId = "Cheburashka.DM0025";
        public const string EnforceCaptureSPReturnStatus_RuleId = "Cheburashka.DM0026";
        public const string EnforceReturn_RuleId = "Cheburashka.DM0027";
        public const string EnforceTryCatch_RuleId = "Cheburashka.DM0028";

        public const string AvoidOnePartNames_RuleId = "Cheburashka.DM0029";


        public const string AvoidUnusedVariables_RuleName = "AvoidUnusedVariables_RuleName";
        public const string AvoidUnusedVariables_ProblemDescription = "AvoidUnusedVariables_ProblemDescription";

        public const string AvoidWriteOnlyVariables_RuleName = "AvoidWriteOnlyVariables_RuleName";
        public const string AvoidWriteOnlyVariables_ProblemDescription = "AvoidWriteOnlyVariables_ProblemDescription";

        public const string AvoidUnusedTableVariable_RuleName = "AvoidUnusedTableVariable_RuleName";
        public const string AvoidUnusedTableVariable_ProblemDescription = "AvoidUnusedTableVariable_ProblemDescription";

        public const string AvoidUninitialisedVariables_RuleName = "AvoidUninitialisedVariables_RuleName";
        public const string AvoidUninitialisedVariables_ProblemDescription = "AvoidUninitialisedVariables_ProblemDescription";

        public const string AvoidUnusedParameter_RuleName = "AvoidUnusedParameter_RuleName";
        public const string AvoidUnusedParameter_ProblemDescription = "AvoidUnusedParameter_ProblemDescription";




        public const string EnforcePrimaryKey_RuleName                                  = "EnforcePrimaryKey_RuleName";
        public const string EnforcePrimaryKey_ProblemDescription                        = "EnforcePrimaryKey_ProblemDescription";

        public const string EnforceClusteredIndex_RuleName                              = "EnforceClusteredIndex_RuleName";
        public const string EnforceClusteredIndex_ProblemDescription                    = "EnforceClusteredIndex_ProblemDescription";


        public const string CheckClusteredKeyColumnsNotIncludedInIndex_RuleName = "CheckClusteredKeyColumnsNotIncludedInIndex_RuleName";
        public const string CheckClusteredKeyColumnsNotIncludedInIndex_ProblemDescription = "CheckClusteredKeyColumnsNotIncludedInIndex_ProblemDescription";

        public const string EnforceNamedConstraint_RuleName                             = "EnforceNamedConstraint_RuleName";
        public const string EnforceNamedConstraint_ProblemDescription                   = "EnforceNamedConstraint_ProblemDescription";



        public const string CheckUniqueIndexHasNoNullColumns_RuleName                   = "CheckUniqueIndexHasNoNullColumns_RuleName";
        public const string CheckUniqueIndexHasNoNullColumns_ProblemDescription         = "CheckUniqueIndexHasNoNullColumns_ProblemDescription";

        public const string CheckUniqueConstraintHasNoNullColumns_RuleName              = "CheckUniqueConstraintHasNoNullColumns_RuleName";
        public const string CheckUniqueConstraintHasNoNullColumns_ProblemDescription    = "CheckUniqueConstraintHasNoNullColumns_ProblemDescription";

        public const string CheckForDuplicatedColumnsInIndexOrConstraint_RuleName           = "CheckForDuplicatedColumnsInIndexOrConstraint_RuleName";
        public const string CheckForDuplicatedColumnsInIndexOrConstraint_ProblemDescription = "CheckForDuplicatedColumnsInIndexOrConstraint_ProblemDescription";

        public const string AvoidBareReturn_RuleName                        = "AvoidBareReturn_RuleName";
        public const string AvoidBareReturn_ProblemDescription              = "AvoidBareReturn_ProblemDescription";

        public const string AvoidGoto_RuleName                              = "AvoidGoto_RuleName";
        public const string AvoidGoto_ProblemDescription                    = "AvoidGoto_ProblemDescription";

        public const string EnforceTryCatch_RuleName                        = "EnforceTryCatch_RuleName";
        public const string EnforceTryCatch_ProblemDescription              = "EnforceTryCatch_ProblemDescription";

        public const string EnforceReturn_RuleName                          = "EnforceReturn_RuleName";
        public const string EnforceReturn_ProblemDescription                = "EnforceReturn_ProblemDescription";

        public const string AvoidDirectUseOfRowcount_RuleName               = "AvoidDirectUseOfRowcount_RuleName";
        public const string AvoidDirectUseOfRowcount_ProblemDescription     = "AvoidDirectUseOfRowcount_ProblemDescription";

        public const string EnforceCaptureSPReturnStatus_RuleName           = "EnforceCaptureSPReturnStatus_RuleName";
        public const string EnforceCaptureSPReturnStatus_ProblemDescription = "EnforceCaptureSPReturnStatus_ProblemDescription";

        public const string AvoidOnePartNames_RuleName                      = "AvoidOnePartNames_RuleName";
        public const string AvoidOnePartNames_ProblemDescription            = "AvoidOnePartNames_ProblemDescription";


        /// <summary>
        /// The design category (should not be localized)
        /// </summary>
        /// 
        public const string NameSpace                           = "Cheburashka";

        public const string CategoryVariableNaming              = "CategoryVariableNaming";
        public const string CategoryVariableUsage               = "VariableUsage";

        public const string CategoryDesign                      = "Design";
        public const string CategoryPerformance                 = "Performance";
        public const string CategoryNaming                      = "Naming";

        public const string CategoryBasics                      = "Basics";
        public const string CategoryModel                       = "CategoryModel";
        public const string CategoryBatch                       = "CategoryBatch";
        public const string CategoryOnline                      = "CategoryOnline";
        public const string CategoryDatabaseSettings            = "CategoryDatabaseSettings";
        public const string CategoryEfficiency                  = "CategoryEfficiency";
        public const string CategoryStyle                       = "CategoryStyle";
        public const string CategoryTemporaryTables             = "CategoryTemporaryTables";
        public const string CategoryControlAndErrorHandling     = "CategoryControlAndErrorHandling";

        public const string CategoryDatabaseStructures          = "CategoryDatabaseStructures";

    }
}
