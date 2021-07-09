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

namespace Cheburashka
{
    internal static class RuleConstants
    {
        /// <summary>
        /// The name of the resources file to use when looking up rule resources
        /// </summary>
        public const string ResourceBaseName = "Cheburashka.RuleResources";

        public const string AvoidUninitialisedVariables_RuleId                  = "Cheburashka.DM0001";
        public const string AvoidUnusedVariables_RuleId                         = "Cheburashka.DM0002";
        public const string AvoidWriteOnlyVariables_RuleId                      = "Cheburashka.DM0003";
        public const string AvoidUnusedTableVariable_RuleId                     = "Cheburashka.DM0004";
        public const string AvoidUnusedParameter_RuleId                         = "Cheburashka.DM0005";

        public const string EnforcePrimaryKey_RuleId                            = "Cheburashka.DM0011";
        public const string EnforceClusteredIndex_RuleId                        = "Cheburashka.DM0012";
        public const string EnforceClusteredIndexIsPrimaryOrForeignKeyRuleId    = "Cheburashka.DM0013";
        public const string EnforceForeignKeyIsIndexedRuleId                    = "Cheburashka.DM0014";
        //        public const string CheckForDuplicatedColumnsInIndexOrConstraintRuleId  = "Cheburashka.DM0015";
        public const string EnforceIndexKeyColumnSeparationRuleId               = "Cheburashka.DM0016";

        public const string CheckUniqueIndexHasNoNullColumnsRuleId              = "Cheburashka.DM0017";
        public const string CheckUniqueConstraintHasNoNullColumnsRuleId         = "Cheburashka.DM0018";
        public const string CheckUniqueKeysAreNotDuplicatedRuleId               = "Cheburashka.DM0019";
        public const string CheckClusteredKeyColumnsNotIncludedInIndexRuleId    = "Cheburashka.DM0020";

        public const string EnforceNamedConstraintRuleId                        = "Cheburashka.DM0022";

        public const string AvoidBareReturn_RuleId                              = "Cheburashka.DM0023";
        public const string AvoidDirectUseOfRowcount_RuleId                     = "Cheburashka.DM0024";
        public const string AvoidGoto_RuleId                                    = "Cheburashka.DM0025";
        public const string EnforceCaptureSPReturnStatus_RuleId                 = "Cheburashka.DM0026";
        public const string EnforceReturn_RuleId                                = "Cheburashka.DM0027";
        public const string EnforceTryCatch_RuleId                              = "Cheburashka.DM0028";

        public const string AvoidOnePartNames_RuleId                            = "Cheburashka.DM0029";

        public const string AvoidNullLiteral_RuleId                                     = "Cheburashka.DM0030";
        public const string DisallowAllCodeManipulationOfProjectDefinedObjects_RuleId   = "Cheburashka.DM0031";
        public const string DisallowUseOfSp_ReName_RuleId                               = "Cheburashka.DM0032";
        public const string EnforceForeignKey_RuleId                                    = "Cheburashka.DM0033";
        public const string EnforceForeignKeyIsUniquelyIndexed_RuleId                   = "Cheburashka.DM0034";
        public const string CheckMultipleForeignKeysBetweenTheSameTable_RuleId          = "Cheburashka.DM0035";
        public const string CheckMultipleForeignKeysFromOneTable_RuleId                 = "Cheburashka.DM0036";
        public const string CheckOrphanedBeginEndBlocks_RuleId                          = "Cheburashka.DM0037";
        public const string CheckUnnecessaryBrackets_RuleId                             = "Cheburashka.DM0038";
        public const string EnforceVariableLengthDataSpecification_RuleId               = "Cheburashka.DM0039";
        public const string CheckDefaultsAreOnNotNullColumns_RuleId                     = "Cheburashka.DM0040";
        public const string AvoidErrorNumber_RuleId                                     = "Cheburashka.DM0041";
        public const string AvoidUnusedLabels_RuleId                                    = "Cheburashka.DM0042";
        public const string AvoidNonANSIJoins_RuleId                                    = "Cheburashka.DM0043";

        public const string CheckOpenTransactionCountCode_RuleId                        = "Cheburashka.DM0045";
        
        public const string EnforceTableAlias_RuleId                                    = "Cheburashka.DM0047";
        public const string PreferThrowToRaiserror_RuleId                               = "Cheburashka.DM0048";
        public const string PreferConstantInitialisation_RuleId                         = "Cheburashka.DM0049";
        public const string AvoidRaiseErrorOutsideTryCatch_RuleId                       = "Cheburashka.DM0050";

        public const string EnforceExplicitInsertColumnList_RuleId                      = "Cheburashka.DM0051";
        public const string CheckForInsteadOfTriggersOnTables_RuleId                    = "Cheburashka.DM0052";


        public const string AvoidUnusedVariables_RuleName                               = "AvoidUnusedVariables_RuleName";
        public const string AvoidUnusedVariables_ProblemDescription                     = "AvoidUnusedVariables_ProblemDescription";

        public const string AvoidWriteOnlyVariables_RuleName                            = "AvoidWriteOnlyVariables_RuleName";
        public const string AvoidWriteOnlyVariables_ProblemDescription                  = "AvoidWriteOnlyVariables_ProblemDescription";

        public const string AvoidUnusedTableVariable_RuleName                           = "AvoidUnusedTableVariable_RuleName";
        public const string AvoidUnusedTableVariable_ProblemDescription                 = "AvoidUnusedTableVariable_ProblemDescription";

        public const string AvoidUninitialisedVariables_RuleName                        = "AvoidUninitialisedVariables_RuleName";
        public const string AvoidUninitialisedVariables_ProblemDescription              = "AvoidUninitialisedVariables_ProblemDescription";

        public const string AvoidUnusedParameter_RuleName                               = "AvoidUnusedParameter_RuleName";
        public const string AvoidUnusedParameter_ProblemDescription                     = "AvoidUnusedParameter_ProblemDescription";

        public const string EnforcePrimaryKey_RuleName                                      = "EnforcePrimaryKey_RuleName";
        public const string EnforcePrimaryKey_ProblemDescription                            = "EnforcePrimaryKey_ProblemDescription";

        public const string EnforceClusteredIndex_RuleName                                  = "EnforceClusteredIndex_RuleName";
        public const string EnforceClusteredIndex_ProblemDescription                        = "EnforceClusteredIndex_ProblemDescription";

        public const string EnforceForeignKeyIsIndexed_RuleName                             = "EnforceForeignKeyIsIndexed_RuleName";
        public const string EnforceForeignKeyIsIndexed_ProblemDescription                   = "EnforceForeignKeyIsIndexed_ProblemDescription";

        public const string EnforceClusteredIndexIsPrimaryOrForeignKey_RuleName             = "EnforceClusteredIndexIsPrimaryOrForeignKey_RuleName";
        public const string EnforceClusteredIndexIsPrimaryOrForeignKey_ProblemDescription   = "EnforceClusteredIndexIsPrimaryOrForeignKey_ProblemDescription";

        //public const string CheckForDuplicatedColumnsInIndexOrConstraint_RuleName           = "CheckForDuplicatedColumnsInIndexOrConstraint_RuleName";
        //public const string CheckForDuplicatedColumnsInIndexOrConstraint_ProblemDescription = "CheckForDuplicatedColumnsInIndexOrConstraint_ProblemDescription";

        public const string CheckUniqueKeysAreNotDuplicated_RuleName                        = "CheckUniqueKeysAreNotDuplicated_RuleName";
        public const string CheckUniqueKeysAreNotDuplicated_ProblemDescription              = "CheckUniqueKeysAreNotDuplicated_ProblemDescription";

        public const string CheckClusteredKeyColumnsNotIncludedInIndex_RuleName             = "CheckClusteredKeyColumnsNotIncludedInIndex_RuleName";
        public const string CheckClusteredKeyColumnsNotIncludedInIndex_ProblemDescription   = "CheckClusteredKeyColumnsNotIncludedInIndex_ProblemDescription";

        public const string EnforceNamedConstraint_RuleName                                 = "EnforceNamedConstraint_RuleName";
        public const string EnforceNamedConstraint_ProblemDescription                       = "EnforceNamedConstraint_ProblemDescription";

        public const string EnforceIndexKeyColumnSeparation_RuleName                        = "EnforceIndexKeyColumnSeparation_RuleName";
        public const string EnforceIndexKeyColumnSeparation_ProblemDescription              = "EnforceIndexKeyColumnSeparation_ProblemDescription";

        public const string CheckUniqueIndexHasNoNullColumns_RuleName                       = "CheckUniqueIndexHasNoNullColumns_RuleName";
        public const string CheckUniqueIndexHasNoNullColumns_ProblemDescription             = "CheckUniqueIndexHasNoNullColumns_ProblemDescription";

        public const string CheckUniqueConstraintHasNoNullColumns_RuleName                  = "CheckUniqueConstraintHasNoNullColumns_RuleName";
        public const string CheckUniqueConstraintHasNoNullColumns_ProblemDescription        = "CheckUniqueConstraintHasNoNullColumns_ProblemDescription";

        public const string AvoidBareReturn_RuleName                                        = "AvoidBareReturn_RuleName";
        public const string AvoidBareReturn_ProblemDescription                              = "AvoidBareReturn_ProblemDescription";
                                                                                            
        public const string AvoidGoto_RuleName                                              = "AvoidGoto_RuleName";
        public const string AvoidGoto_ProblemDescription                                    = "AvoidGoto_ProblemDescription";
                                                                                            
        public const string AvoidNullLiteral_RuleName                                       = "AvoidNullLiteral_RuleName";
        public const string AvoidNullLiteral_ProblemDescription                             = "AvoidNullLiteral_ProblemDescription";
                                                                                            
        public const string EnforceTryCatch_RuleName                                        = "EnforceTryCatch_RuleName";
        public const string EnforceTryCatch_ProblemDescription                              = "EnforceTryCatch_ProblemDescription";
                                                                                            
        public const string EnforceReturn_RuleName                                          = "EnforceReturn_RuleName";
        public const string EnforceReturn_ProblemDescription                                = "EnforceReturn_ProblemDescription";
                                                                                            
        public const string AvoidDirectUseOfRowcount_RuleName                               = "AvoidDirectUseOfRowcount_RuleName";
        public const string AvoidDirectUseOfRowcount_ProblemDescription                     = "AvoidDirectUseOfRowcount_ProblemDescription";
                                                                                            
        public const string EnforceCaptureSPReturnStatus_RuleName                           = "EnforceCaptureSPReturnStatus_RuleName";
        public const string EnforceCaptureSPReturnStatus_ProblemDescription                 = "EnforceCaptureSPReturnStatus_ProblemDescription";
                                                                                            
        public const string AvoidOnePartNames_RuleName                                      = "AvoidOnePartNames_RuleName";
        public const string AvoidOnePartNames_ProblemDescription                            = "AvoidOnePartNames_ProblemDescription";

        public const string DisallowAllCodeManipulationOfProjectDefinedObjects_RuleName             = "DisallowAllCodeManipulationOfProjectDefinedObjects_RuleName";
        public const string DisallowAllCodeManipulationOfProjectDefinedObjects_ProblemDescription   = "DisallowAllCodeManipulationOfProjectDefinedObjects_ProblemDescription";

        public const string DisallowUseOfSp_ReName_RuleName                                         = "DisallowUseOfSp_ReName_RuleName";
        public const string DisallowUseOfSp_ReName_ProblemDescription                               = "DisallowUseOfSp_ReName_ProblemDescription";

        public const string EnforceForeignKey_RuleName                                              = "EnforceForeignKey_RuleName";
        public const string EnforceForeignKey_ProblemDescription                                    = "EnforceForeignKey_ProblemDescription";

        public const string EnforceForeignKeyIsUniquelyIndexed_RuleName                             = "EnforceForeignKeyIsUniquelyIndexed_RuleName";
        public const string EnforceForeignKeyIsUniquelyIndexed_ProblemDescription                   = "EnforceForeignKeyIsUniquelyIndexed_ProblemDescription";

        public const string CheckMultipleForeignKeysBetweenTheSameTable_RuleName                    = "CheckMultipleForeignKeysBetweenTheSameTable_RuleName";
        public const string CheckMultipleForeignKeysBetweenTheSameTable_ProblemDescription          = "CheckMultipleForeignKeysBetweenTheSameTable_ProblemDescription";

        public const string CheckMultipleForeignKeysFromOneTable_RuleName                           = "CheckMultipleForeignKeysFromOneTable_RuleName";
        public const string CheckMultipleForeignKeysFromOneTable_ProblemDescription                 = "CheckMultipleForeignKeysFromOneTable_ProblemDescription";

        public const string CheckOrphanedBeginEndBlocks_RuleName                                    = "CheckOrphanedBeginEndBlocks_RuleName";
        public const string CheckOrphanedBeginEndBlocks_ProblemDescription                          = "CheckOrphanedBeginEndBlocks_ProblemDescription";

        public const string CheckUnnecessaryBrackets_RuleName                                       = "CheckUnnecessaryBrackets_RuleName";
        public const string CheckUnnecessaryBrackets_ProblemDescription                             = "CheckUnnecessaryBrackets_ProblemDescription";

        public const string EnforceVariableLengthDataSpecification_RuleName                         = "EnforceVariableLengthDataSpecification_RuleName";
        public const string EnforceVariableLengthDataSpecification_ProblemDescription               = "EnforceVariableLengthDataSpecification_ProblemDescription";

        public const string CheckDefaultsAreOnNotNullColumns_RuleName                               = "CheckDefaultsAreOnNotNullColumns_RuleName";
        public const string CheckDefaultsAreOnNotNullColumns_ProblemDescription                     = "CheckDefaultsAreOnNotNullColumns_ProblemDescription";

        public const string AvoidErrorNumber_RuleName                                               = "AvoidErrorNumber_RuleName";
        public const string AvoidErrorNumber_ProblemDescription                                     = "AvoidErrorNumber_ProblemDescription";

        public const string AvoidUnusedLabels_RuleName                                              = "AvoidUnusedLabels_RuleName";
        public const string AvoidUnusedLabels_ProblemDescription                                    = "AvoidUnusedLabels_ProblemDescription";

        public const string AvoidNonANSIJoins_RuleName                                              = "AvoidNonANSIJoins_RuleName";
        public const string AvoidNonANSIJoins_ProblemDescription                                    = "AvoidNonANSIJoins_ProblemDescription";

        public const string CheckOpenTransactionCountCode_RuleName                                  = "CheckOpenTransactionCountCode_RuleName";
        public const string CheckOpenTransactionCountCode_ProblemDescription                        = "CheckOpenTransactionCountCode_ProblemDescription";

        public const string EnforceTableAlias_RuleName                                              = "EnforceTableAlias_RuleName";
        public const string EnforceTableAlias_ProblemDescription                                    = "EnforceTableAlias_ProblemDescription";

        public const string PreferThrowToRaiserror_RuleName                                         = "PreferThrowToRaiserror_RuleName";
        public const string PreferThrowToRaiserror_ProblemDescription                               = "PreferThrowToRaiserror_ProblemDescription";

        public const string PreferConstantInitialisation_RuleName                                   = "PreferConstantInitialisation_RuleName";
        public const string PreferConstantInitialisation_ProblemDescription                         = "PreferConstantInitialisation_ProblemDescription";

        public const string AvoidRaiseErrorOutsideTryCatch_RuleName                                 = "AvoidRaiseErrorOutsideTryCatch_RuleName";
        public const string AvoidRaiseErrorOutsideTryCatch_ProblemDescription                       = "AvoidRaiseErrorOutsideTryCatch_ProblemDescription";

        public const string EnforceExplicitInsertColumnList_RuleName                                = "EnforceExplicitInsertColumnList_RuleName";
        public const string EnforceExplicitInsertColumnList_ProblemDescription                      = "EnforceExplicitInsertColumnList_ProblemDescription";

        public const string CheckForInsteadOfTriggersOnTables_RuleName                              = "CheckForInsteadOfTriggersOnTables_RuleName";
        public const string CheckForInsteadOfTriggersOnTables_ProblemDescription                    = "CheckForInsteadOfTriggersOnTables_ProblemDescription";


        /// <summary>
        /// The design category (should not be localized)
        /// </summary>
        /// 
        public const string NameSpace                           = "Cheburashka";

        public const string CategoryVariableNaming              = "CategoryVariableNaming";
        public const string CategoryVariableUsage               = "CategoryVariableUsage";

        public const string CategoryDesign                      = "CategoryDesign";
        public const string CategoryPerformance                 = "CategoryPerformance";
        public const string CategoryNaming                      = "CategoryNaming";

        public const string CategoryBasics                      = "CategoryBasics";
        public const string CategoryModel                       = "CategoryModel";
        public const string CategoryBatch                       = "CategoryBatch";
        public const string CategoryOnline                      = "CategoryOnline";
        public const string CategoryDatabaseSettings            = "CategoryDatabaseSettings";
        public const string CategoryEfficiency                  = "CategoryEfficiency";
        public const string CategoryStyle                       = "CategoryStyle";
        public const string CategoryTemporaryTables             = "CategoryTemporaryTables";
        public const string CategoryControlAndErrorHandling     = "CategoryControlAndErrorHandling";

        public const string CategoryDatabaseStructures          = "Data.Database.PhysicalStructure";
        public const string CategoryRelationalDesignKeys        = "Data.Database.Keys";
        public const string CategoryRelationalDesignNull        = "Data.Database.Nulls";

        public const string CategorySSDTModel                   = "Data.SSDT.Model";
        public const string CategoryObsoleteCodingStyle         = "Code.ObsoleteStyle.Code";
        public const string CategoryModernCodingStyle           = "Code.ModernStyle.Code";

        public const string CategoryNonStrictCodingStyle        = "Code.LaxCode.StoredProcedures";
        public const string CategoryNonStrictCodingStyleNames   = "Code.LaxCode.Naming";
        public const string CategoryNonStrictCodingStyleData    = "Code.LaxCode.Data";
        public const string CategoryUnnecessaryCode             = "Code.Redundant.UnnecessaryCode";
        public const string CategoryUnnecessaryVariables        = "Code.Redundant.UnusedObjects";


        public const string CategoryDataTypes                   = "CategoryDataTypes";
        public const string CategoryDates                       = "CategoryDates";
        public const string CategoryRegionalisation             = "CategoryRegionalisation";

    }
}
