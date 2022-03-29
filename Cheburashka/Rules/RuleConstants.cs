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

        public const string AvoidUninitialisedVariablesRuleId                           = "Cheburashka.DM0001";
        public const string AvoidUnusedVariablesRuleId                                  = "Cheburashka.DM0002";
        public const string AvoidWriteOnlyVariablesRuleId                               = "Cheburashka.DM0003";
        public const string AvoidUnusedTableVariableRuleId                              = "Cheburashka.DM0004";
        public const string AvoidUnusedParameterRuleId                                  = "Cheburashka.DM0005";
        public const string EnforceSingleReturnRuleId                                   = "Cheburashka.DM0006";

        public const string EnforcePrimaryKeyRuleId                                     = "Cheburashka.DM0011";
        public const string EnforceClusteredIndexRuleId                                 = "Cheburashka.DM0012";
        public const string EnforceClusteredIndexIsPrimaryOrForeignKeyRuleId            = "Cheburashka.DM0013";
        public const string EnforceForeignKeyIsIndexedRuleId                            = "Cheburashka.DM0014";

        public const string EnforceIndexKeyColumnSeparationRuleId                       = "Cheburashka.DM0016";

        public const string CheckUniqueIndexHasNoNullColumnsRuleId                      = "Cheburashka.DM0017";
        public const string CheckUniqueConstraintHasNoNullColumnsRuleId                 = "Cheburashka.DM0018";
        public const string CheckUniqueKeysAreNotDuplicatedRuleId                       = "Cheburashka.DM0019";


        public const string PreferExplicitNullInColumnDefinitionRuleId                  = "Cheburashka.DM0020";
        public const string AvoidExplicitCollateInDefinitionRuleId                      = "Cheburashka.DM0021";


        public const string EnforceNamedConstraintRuleId                                = "Cheburashka.DM0022";

        public const string AvoidBareReturnRuleId                                       = "Cheburashka.DM0023";
        public const string AvoidDirectUseOfRowcountRuleId                              = "Cheburashka.DM0024";
        public const string AvoidGotoRuleId                                             = "Cheburashka.DM0025";
        public const string EnforceCaptureSpReturnStatusRuleId                          = "Cheburashka.DM0026";
        public const string EnforceReturnRuleId                                         = "Cheburashka.DM0027";
        public const string EnforceTryCatchRuleId                                       = "Cheburashka.DM0028";

        public const string AvoidOnePartNamesRuleId                                     = "Cheburashka.DM0029";

        public const string AvoidNullLiteralRuleId                                      = "Cheburashka.DM0030";
        public const string DisallowAllCodeManipulationOfProjectDefinedObjectsRuleId    = "Cheburashka.DM0031";
        public const string DisallowUseOfSpReNameRuleId                                 = "Cheburashka.DM0032";
        public const string EnforceForeignKeyRuleId                                     = "Cheburashka.DM0033";
        public const string EnforceForeignKeyIsUniquelyIndexedRuleId                    = "Cheburashka.DM0034";
        public const string CheckMultipleForeignKeysBetweenTheSameTableRuleId           = "Cheburashka.DM0035";
        public const string CheckMultipleForeignKeysFromOneTableRuleId                  = "Cheburashka.DM0036";
        public const string CheckOrphanedBeginEndBlocksRuleId                           = "Cheburashka.DM0037";
        public const string CheckUnnecessaryBracketsRuleId                              = "Cheburashka.DM0038";
        public const string EnforceVariableLengthDataSpecificationRuleId                = "Cheburashka.DM0039";
        public const string CheckDefaultsAreOnNotNullColumnsRuleId                      = "Cheburashka.DM0040";
        public const string AvoidErrorNumberRuleId                                      = "Cheburashka.DM0041";
        public const string AvoidUnusedLabelsRuleId                                     = "Cheburashka.DM0042";
        public const string AvoidNonAnsiJoinsRuleId                                     = "Cheburashka.DM0043";

        public const string CheckOpenTransactionCountCodeRuleId                         = "Cheburashka.DM0045";
        
        public const string EnforceColumnPrefixRuleId                                   = "Cheburashka.DM0046";
        public const string EnforceTableAliasRuleId                                     = "Cheburashka.DM0047";
        public const string PreferThrowToRaiserrorRuleId                                = "Cheburashka.DM0048";
        public const string PreferConstantInitialisationRuleId                          = "Cheburashka.DM0049";
        public const string AvoidRaiseErrorOutsideTryCatchRuleId                        = "Cheburashka.DM0050";

        public const string EnforceExplicitInsertColumnListRuleId                       = "Cheburashka.DM0051";
        public const string CheckForInsteadOfTriggersOnTablesRuleId                     = "Cheburashka.DM0052";
        public const string CheckForMultipleOutputVariablesRuleId                       = "Cheburashka.DM0053";
        public const string CheckCallerDefinesCorrectOutputVariablesRuleId              = "Cheburashka.DM0054";

        public const string EnforceSingleColumnPrefixRuleId                             = "Cheburashka.DM0055";
        public const string EnforceUniqueTableAliasRuleId                               = "Cheburashka.DM0056";

        public const string CheckUniqueConstraintImpliedBySubQueryRuleId                = "Cheburashka.DM0057";
        public const string PreferDropIfExistsRuleId                                    = "Cheburashka.DM0058";

        public const string AvoidSelectIntoRuleId                                       = "Cheburashka.DM0059";
        public const string EnforceNoCountXactAbortRuleId                               = "Cheburashka.DM0060";

        public const string CheckMissingInsertColumnsRuleId                             = "Cheburashka.DM0061";
        public const string AvoidUnusedTempTableRuleId                                  = "Cheburashka.DM0062";
        public const string AvoidUsingNonLocalTempTableRuleId                           = "Cheburashka.DM0063";
        public const string AvoidDroppingTempTableRuleId                                = "Cheburashka.DM0064";
        public const string AvoidReadOnlyTempTableRuleId                                = "Cheburashka.DM0065";
        

        public const string AvoidUnusedVariablesRuleName                                = "AvoidUnusedVariables_RuleName";
        public const string AvoidUnusedVariablesProblemDescription                      = "AvoidUnusedVariables_ProblemDescription";

        public const string AvoidWriteOnlyVariablesRuleName                             = "AvoidWriteOnlyVariables_RuleName";
        public const string AvoidWriteOnlyVariablesProblemDescription                   = "AvoidWriteOnlyVariables_ProblemDescription";

        public const string AvoidUnusedTableVariableRuleName                            = "AvoidUnusedTableVariable_RuleName";
        public const string AvoidUnusedTableVariableProblemDescription                  = "AvoidUnusedTableVariable_ProblemDescription";

        public const string AvoidUninitialisedVariablesRuleName                         = "AvoidUninitialisedVariables_RuleName";
        public const string AvoidUninitialisedVariablesProblemDescription               = "AvoidUninitialisedVariables_ProblemDescription";

        public const string AvoidUnusedParameterRuleName                                = "AvoidUnusedParameter_RuleName";
        public const string AvoidUnusedParameterProblemDescription                      = "AvoidUnusedParameter_ProblemDescription";

        public const string EnforceSingleReturnRuleName                                 = "EnforceSingleReturn_RuleName";
        public const string EnforceSingleReturnProblemDescription                       = "EnforceSingleReturn_ProblemDescription";

 
        public const string EnforcePrimaryKeyRuleName                                      = "EnforcePrimaryKey_RuleName";
        public const string EnforcePrimaryKeyProblemDescription                            = "EnforcePrimaryKey_ProblemDescription";

        public const string EnforceClusteredIndexRuleName                                  = "EnforceClusteredIndex_RuleName";
        public const string EnforceClusteredIndexProblemDescription                        = "EnforceClusteredIndex_ProblemDescription";

        public const string EnforceForeignKeyIsIndexedRuleName                             = "EnforceForeignKeyIsIndexed_RuleName";
        public const string EnforceForeignKeyIsIndexedProblemDescription                   = "EnforceForeignKeyIsIndexed_ProblemDescription";

        public const string EnforceClusteredIndexIsPrimaryOrForeignKeyRuleName             = "EnforceClusteredIndexIsPrimaryOrForeignKey_RuleName";
        public const string EnforceClusteredIndexIsPrimaryOrForeignKeyProblemDescription   = "EnforceClusteredIndexIsPrimaryOrForeignKey_ProblemDescription";


        public const string PreferExplicitNullInColumnDefinitionRuleName                   = "PreferExplicitNullInColumnDefinition_RuleName";
        public const string PreferExplicitNullInColumnDefinitionProblemDescription         = "PreferExplicitNullInColumnDefinition_ProblemDescription";
        public const string AvoidExplicitCollateInDefinitionRuleName                       = "AvoidExplicitCollateInDefinition_RuleName";
        public const string AvoidExplicitCollateInDefinitionProblemDescription             = "AvoidExplicitCollateInDefinition_ProblemDescription";



        public const string CheckUniqueKeysAreNotDuplicatedRuleName                        = "CheckUniqueKeysAreNotDuplicated_RuleName";
        public const string CheckUniqueKeysAreNotDuplicatedProblemDescription              = "CheckUniqueKeysAreNotDuplicated_ProblemDescription";

        public const string CheckClusteredKeyColumnsNotIncludedInIndexRuleName             = "CheckClusteredKeyColumnsNotIncludedInIndex_RuleName";
        public const string CheckClusteredKeyColumnsNotIncludedInIndexProblemDescription   = "CheckClusteredKeyColumnsNotIncludedInIndex_ProblemDescription";

        public const string EnforceNamedConstraintRuleName                                 = "EnforceNamedConstraint_RuleName";
        public const string EnforceNamedConstraintProblemDescription                       = "EnforceNamedConstraint_ProblemDescription";

        public const string EnforceIndexKeyColumnSeparationRuleName                        = "EnforceIndexKeyColumnSeparation_RuleName";
        public const string EnforceIndexKeyColumnSeparationProblemDescription              = "EnforceIndexKeyColumnSeparation_ProblemDescription";

        public const string CheckUniqueIndexHasNoNullColumnsRuleName                       = "CheckUniqueIndexHasNoNullColumns_RuleName";
        public const string CheckUniqueIndexHasNoNullColumnsProblemDescription             = "CheckUniqueIndexHasNoNullColumns_ProblemDescription";

        public const string CheckUniqueConstraintHasNoNullColumnsRuleName                  = "CheckUniqueConstraintHasNoNullColumns_RuleName";
        public const string CheckUniqueConstraintHasNoNullColumnsProblemDescription        = "CheckUniqueConstraintHasNoNullColumns_ProblemDescription";

        public const string AvoidBareReturnRuleName                                        = "AvoidBareReturn_RuleName";
        public const string AvoidBareReturnProblemDescription                              = "AvoidBareReturn_ProblemDescription";
                                                                                            
        public const string AvoidGotoRuleName                                              = "AvoidGoto_RuleName";
        public const string AvoidGotoProblemDescription                                    = "AvoidGoto_ProblemDescription";
                                                                                            
        public const string AvoidNullLiteralRuleName                                       = "AvoidNullLiteral_RuleName";
        public const string AvoidNullLiteralProblemDescription                             = "AvoidNullLiteral_ProblemDescription";
                                                                                            
        public const string EnforceTryCatchRuleName                                        = "EnforceTryCatch_RuleName";
        public const string EnforceTryCatchProblemDescription                              = "EnforceTryCatch_ProblemDescription";
                                                                                            
        public const string EnforceReturnRuleName                                          = "EnforceReturn_RuleName";
        public const string EnforceReturnProblemDescription                                = "EnforceReturn_ProblemDescription";
                                                                                            
        public const string AvoidDirectUseOfRowcountRuleName                               = "AvoidDirectUseOfRowcount_RuleName";
        public const string AvoidDirectUseOfRowcountProblemDescription                     = "AvoidDirectUseOfRowcount_ProblemDescription";
                                                                                            
        public const string EnforceCaptureSpReturnStatusRuleName                           = "EnforceCaptureSPReturnStatus_RuleName";
        public const string EnforceCaptureSpReturnStatusProblemDescription                 = "EnforceCaptureSPReturnStatus_ProblemDescription";
                                                                                            
        public const string AvoidOnePartNamesRuleName                                      = "AvoidOnePartNames_RuleName";
        public const string AvoidOnePartNamesProblemDescription                            = "AvoidOnePartNames_ProblemDescription";

        public const string DisallowAllCodeManipulationOfProjectDefinedObjectsRuleName              = "DisallowAllCodeManipulationOfProjectDefinedObjects_RuleName";
        public const string DisallowAllCodeManipulationOfProjectDefinedObjectsProblemDescription    = "DisallowAllCodeManipulationOfProjectDefinedObjects_ProblemDescription";

        public const string DisallowUseOfSpReNameRuleName                                           = "DisallowUseOfSp_ReName_RuleName";
        public const string DisallowUseOfSpReNameProblemDescription                                 = "DisallowUseOfSp_ReName_ProblemDescription";

        public const string EnforceForeignKeyRuleName                                               = "EnforceForeignKey_RuleName";
        public const string EnforceForeignKeyProblemDescription                                     = "EnforceForeignKey_ProblemDescription";

        public const string EnforceForeignKeyIsUniquelyIndexedRuleName                              = "EnforceForeignKeyIsUniquelyIndexed_RuleName";
        public const string EnforceForeignKeyIsUniquelyIndexedProblemDescription                    = "EnforceForeignKeyIsUniquelyIndexed_ProblemDescription";

        public const string CheckMultipleForeignKeysBetweenTheSameTableRuleName                     = "CheckMultipleForeignKeysBetweenTheSameTable_RuleName";
        public const string CheckMultipleForeignKeysBetweenTheSameTableProblemDescription           = "CheckMultipleForeignKeysBetweenTheSameTable_ProblemDescription";

        public const string CheckMultipleForeignKeysFromOneTableRuleName                            = "CheckMultipleForeignKeysFromOneTable_RuleName";
        public const string CheckMultipleForeignKeysFromOneTableProblemDescription                  = "CheckMultipleForeignKeysFromOneTable_ProblemDescription";

        public const string CheckOrphanedBeginEndBlocksRuleName                                     = "CheckOrphanedBeginEndBlocks_RuleName";
        public const string CheckOrphanedBeginEndBlocksProblemDescription                           = "CheckOrphanedBeginEndBlocks_ProblemDescription";

        public const string CheckUnnecessaryBracketsRuleName                                        = "CheckUnnecessaryBrackets_RuleName";
        public const string CheckUnnecessaryBracketsProblemDescription                              = "CheckUnnecessaryBrackets_ProblemDescription";

        public const string EnforceVariableLengthDataSpecificationRuleName                          = "EnforceVariableLengthDataSpecification_RuleName";
        public const string EnforceVariableLengthDataSpecificationProblemDescription                = "EnforceVariableLengthDataSpecification_ProblemDescription";

        public const string CheckDefaultsAreOnNotNullColumnsRuleName                                = "CheckDefaultsAreOnNotNullColumns_RuleName";
        public const string CheckDefaultsAreOnNotNullColumnsProblemDescription                      = "CheckDefaultsAreOnNotNullColumns_ProblemDescription";

        public const string AvoidErrorNumberRuleName                                                = "AvoidErrorNumber_RuleName";
        public const string AvoidErrorNumberProblemDescription                                      = "AvoidErrorNumber_ProblemDescription";

        public const string AvoidUnusedLabelsRuleName                                               = "AvoidUnusedLabels_RuleName";
        public const string AvoidUnusedLabelsProblemDescription                                     = "AvoidUnusedLabels_ProblemDescription";

        public const string AvoidNonAnsiJoinsRuleName                                               = "AvoidNonANSIJoins_RuleName";
        public const string AvoidNonAnsiJoinsProblemDescription                                     = "AvoidNonANSIJoins_ProblemDescription";

        public const string CheckOpenTransactionCountCodeRuleName                                   = "CheckOpenTransactionCountCode_RuleName";
        public const string CheckOpenTransactionCountCodeProblemDescription                         = "CheckOpenTransactionCountCode_ProblemDescription";

        public const string EnforceColumnPrefixRuleName                                             = "EnforceColumnPrefix_RuleName";
        public const string EnforceColumnPrefixProblemDescription                                   = "EnforceColumnPrefix_ProblemDescription";

        public const string EnforceTableAliasRuleName                                               = "EnforceTableAlias_RuleName";
        public const string EnforceTableAliasProblemDescription                                     = "EnforceTableAlias_ProblemDescription";

        public const string PreferThrowToRaiserrorRuleName                                          = "PreferThrowToRaiserror_RuleName";
        public const string PreferThrowToRaiserrorProblemDescription                                = "PreferThrowToRaiserror_ProblemDescription";

        public const string PreferConstantInitialisationRuleName                                    = "PreferConstantInitialisation_RuleName";
        public const string PreferConstantInitialisationProblemDescription                          = "PreferConstantInitialisation_ProblemDescription";

        public const string AvoidRaiseErrorOutsideTryCatchRuleName                                  = "AvoidRaiseErrorOutsideTryCatch_RuleName";
        public const string AvoidRaiseErrorOutsideTryCatchProblemDescription                        = "AvoidRaiseErrorOutsideTryCatch_ProblemDescription";

        public const string EnforceExplicitInsertColumnListRuleName                                 = "EnforceExplicitInsertColumnList_RuleName";
        public const string EnforceExplicitInsertColumnListProblemDescription                       = "EnforceExplicitInsertColumnList_ProblemDescription";

        public const string CheckForInsteadOfTriggersOnTablesRuleName                               = "CheckForInsteadOfTriggersOnTables_RuleName";
        public const string CheckForInsteadOfTriggersOnTablesProblemDescription                     = "CheckForInsteadOfTriggersOnTables_ProblemDescription";

        public const string CheckForMultipleOutputVariablesRuleName                                 = "CheckForMultipleOutputVariables_RuleName";
        public const string CheckForMultipleOutputVariablesProblemDescription                       = "CheckForMultipleOutputVariables_ProblemDescription";

        public const string CheckCallerDefinesCorrectOutputVariablesRuleName                        = "CheckCallerDefinesCorrectOutputVariables_RuleName";
        public const string CheckCallerDefinesCorrectOutputVariablesProblemDescription              = "CheckCallerDefinesCorrectOutputVariables_ProblemDescription";

        public const string EnforceSingleColumnPrefixRuleName                                       = "EnforceSingleColumnPrefix_RuleName";
        public const string EnforceSingleColumnPrefixProblemDescription                             = "EnforceSingleColumnPrefix_ProblemDescription";

        public const string EnforceUniqueTableAliasRuleName                                         = "EnforceUniqueTableAlias_RuleName";
        public const string EnforceUniqueTableAliasProblemDescription                               = "EnforceUniqueTableAlias_ProblemDescription";

        public const string CheckUniqueConstraintImpliedBySubQueryRuleName                          = "CheckUniqueConstraintImpliedBySubQuery_RuleName";
        public const string CheckUniqueConstraintImpliedBySubQueryProblemDescription                = "CheckUniqueConstraintImpliedBySubQuery_ProblemDescription";

        public const string PreferDropIfExistsRuleName                                              = "PreferDropIfExists_Rulename";
        public const string PreferDropIfExistsProblemDescription                                    = "PreferDropIfExists_ProblemDescription";

        public const string AvoidSelectIntoRuleName                                                 = "AvoidSelectInto_RuleName";
        public const string AvoidSelectIntoProblemDescription                                       = "AvoidSelectInto_ProblemDescription";

        public const string EnforceNoCountXactAbortRuleName                                         = "EnforceNoCountXactAbort_RuleName";
        public const string EnforceNoCountXactAbortProblemDescription                               = "EnforceNoCountXactAbort_ProblemDescription";

        public const string CheckMissingInsertColumnsRuleName                                       = "CheckMissingInsertColumns_RuleName";
        public const string CheckMissingInsertColumnsProblemDescription                             = "CheckMissingInsertColumns_ProblemDescription";

        public const string AvoidUnusedTempTableRuleName                                            = "AvoidUnusedTempTable_RuleName";
        public const string AvoidUnusedTempTableProblemDescription                                  = "AvoidUnusedTempTable_ProblemDescription";

        public const string AvoidUsingNonLocalTempTableRuleName                                     = "AvoidUsingNonLocalTempTable_RuleName";
        public const string AvoidUsingNonLocalTempTableProblemDescription                           = "AvoidUsingNonLocalTempTable_ProblemDescription";

        public const string AvoidDroppingTempTableRuleName                                          = "AvoidDroppingTempTable_RuleName";
        public const string AvoidDroppingTempTableProblemDescription                                = "AvoidDroppingTempTable_ProblemDescription";

        public const string AvoidReadOnlyTempTableRuleName                                          = "AvoidReadOnlyTempTable_RuleName";
        public const string AvoidReadOnlyTempTableProblemDescription                                = "AvoidReadOnlyTempTable_ProblemDescription";


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

        //public const string CategoryBasics                      = "CategoryBasics";
        //public const string CategoryModel                       = "CategoryModel";
        //public const string CategoryBatch                       = "CategoryBatch";
        //public const string CategoryOnline                      = "CategoryOnline";
        //public const string CategoryDatabaseSettings            = "CategoryDatabaseSettings";
        //public const string CategoryEfficiency                  = "CategoryEfficiency";
        //public const string CategoryStyle                       = "CategoryStyle";
        //public const string CategoryTemporaryTables             = "CategoryTemporaryTables";
        //public const string CategoryControlAndErrorHandling     = "CategoryControlAndErrorHandling";

        public const string CategoryDatabaseStructures          = "Data.Database.PhysicalStructure";
        public const string CategoryRelationalDesignKeys        = "Data.Database.Keys";
        public const string CategoryRelationalDesignNull        = "Data.Database.Nulls";
        public const string CategoryTempTables                  = "Data.Database.TempTables";

        public const string CategorySsdtModel                   = "Data.SSDT.Model";
        public const string CategoryObsoleteCodingStyle         = "Code.ObsoleteStyle.Code";
        public const string CategoryModernCodingStyle           = "Code.ModernStyle.Code";

        public const string CategoryNonStrictCodingStyle        = "Code.LaxCode.StoredProcedures";
        public const string CategoryNonStrictCodingStyleNames   = "Code.LaxCode.Naming";
        public const string CategoryNonStrictCodingStyleData    = "Code.LaxCode.Data";

        public const string CategoryUnnecessaryCode             = "Code.Redundant.UnnecessaryCode";
        public const string CategoryUnnecessaryVariables        = "Code.Redundant.UnusedObjects";

        public const string CategoryParameters                  = "Code.Parameter.Issues";
        public const string CategoryMissingDerivedConstraints   = "Data.Database.Constraints";


        //public const string CategoryDataTypes                   = "CategoryDataTypes";
        //public const string CategoryDates                       = "CategoryDates";
        //public const string CategoryRegionalisation             = "CategoryRegionalisation";

    }
}
