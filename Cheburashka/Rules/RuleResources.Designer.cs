﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cheburashka {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class RuleResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal RuleResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Cheburashka.RuleResources", typeof(RuleResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to RETURN statement without return value was found in {0}..
        /// </summary>
        internal static string AvoidBareReturn_ProblemDescription {
            get {
                return ResourceManager.GetString("AvoidBareReturn_ProblemDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Avoid using Return statements with no explicit return value in Stored Procedures..
        /// </summary>
        internal static string AvoidBareReturn_RuleName {
            get {
                return ResourceManager.GetString("AvoidBareReturn_RuleName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to @@rowcount and/or @@error was used directly in {0}.  @@rowcount/@@error should always be captured by a SET @variable statement, or safe selection assignment statement before use..
        /// </summary>
        internal static string AvoidDirectUseOfRowcount_ProblemDescription {
            get {
                return ResourceManager.GetString("AvoidDirectUseOfRowcount_ProblemDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to @@rowcount and/or @@error should never be used directly..
        /// </summary>
        internal static string AvoidDirectUseOfRowcount_RuleName {
            get {
                return ResourceManager.GetString("AvoidDirectUseOfRowcount_RuleName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to @@error global variable usage found in {0}..
        /// </summary>
        internal static string AvoidErrorNumber_ProblemDescription {
            get {
                return ResourceManager.GetString("AvoidErrorNumber_ProblemDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Avoid using @error.  Use Try/Catch..
        /// </summary>
        internal static string AvoidErrorNumber_RuleName {
            get {
                return ResourceManager.GetString("AvoidErrorNumber_RuleName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to GOTO statement was found in {0}..
        /// </summary>
        internal static string AvoidGoto_ProblemDescription {
            get {
                return ResourceManager.GetString("AvoidGoto_ProblemDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Avoid using Goto statements..
        /// </summary>
        internal static string AvoidGoto_RuleName {
            get {
                return ResourceManager.GetString("AvoidGoto_RuleName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Old style join found in {0}..
        /// </summary>
        internal static string AvoidNonANSIJoins_ProblemDescription {
            get {
                return ResourceManager.GetString("AvoidNonANSIJoins_ProblemDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Avoid non-ANSI joins.  Use ANSI syntax, or T-SQL Apply..
        /// </summary>
        internal static string AvoidNonANSIJoins_RuleName {
            get {
                return ResourceManager.GetString("AvoidNonANSIJoins_RuleName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Null Literal was found in a comparison in {0}..
        /// </summary>
        internal static string AvoidNullLiteral_ProblemDescription {
            get {
                return ResourceManager.GetString("AvoidNullLiteral_ProblemDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Null is not a valid value to compare to..
        /// </summary>
        internal static string AvoidNullLiteral_RuleName {
            get {
                return ResourceManager.GetString("AvoidNullLiteral_RuleName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Schema object with no schema name found in {0}..
        /// </summary>
        internal static string AvoidOnePartNames_ProblemDescription {
            get {
                return ResourceManager.GetString("AvoidOnePartNames_ProblemDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Always include the schema name when referencing an object..
        /// </summary>
        internal static string AvoidOnePartNames_RuleName {
            get {
                return ResourceManager.GetString("AvoidOnePartNames_RuleName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Uninitialised variable found in {0}..
        /// </summary>
        internal static string AvoidUninitialisedVariables_ProblemDescription {
            get {
                return ResourceManager.GetString("AvoidUninitialisedVariables_ProblemDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Variables whose value is never set will be null..
        /// </summary>
        internal static string AvoidUninitialisedVariables_RuleName {
            get {
                return ResourceManager.GetString("AvoidUninitialisedVariables_RuleName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unreferenced label found in {0}..
        /// </summary>
        internal static string AvoidUnusedLabels_ProblemDescription {
            get {
                return ResourceManager.GetString("AvoidUnusedLabels_ProblemDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Avoid unreferenced labels in code..
        /// </summary>
        internal static string AvoidUnusedLabels_RuleName {
            get {
                return ResourceManager.GetString("AvoidUnusedLabels_RuleName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unused Parameter found in {0}..
        /// </summary>
        internal static string AvoidUnusedParameter_ProblemDescription {
            get {
                return ResourceManager.GetString("AvoidUnusedParameter_ProblemDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unused Parameters point to potential coding errors..
        /// </summary>
        internal static string AvoidUnusedParameter_RuleName {
            get {
                return ResourceManager.GetString("AvoidUnusedParameter_RuleName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unused Table Variable found in {0}..
        /// </summary>
        internal static string AvoidUnusedTableVariable_ProblemDescription {
            get {
                return ResourceManager.GetString("AvoidUnusedTableVariable_ProblemDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unused Table Variables point to potential coding errors..
        /// </summary>
        internal static string AvoidUnusedTableVariable_RuleName {
            get {
                return ResourceManager.GetString("AvoidUnusedTableVariable_RuleName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unused Variable found in {0}..
        /// </summary>
        internal static string AvoidUnusedVariables_ProblemDescription {
            get {
                return ResourceManager.GetString("AvoidUnusedVariables_ProblemDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unused Variables point to potential coding errors..
        /// </summary>
        internal static string AvoidUnusedVariables_RuleName {
            get {
                return ResourceManager.GetString("AvoidUnusedVariables_RuleName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Write-only Variable found in {0}..
        /// </summary>
        internal static string AvoidWriteOnlyVariables_ProblemDescription {
            get {
                return ResourceManager.GetString("AvoidWriteOnlyVariables_ProblemDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Variables whose values are set, but never used point to potential coding errors..
        /// </summary>
        internal static string AvoidWriteOnlyVariables_RuleName {
            get {
                return ResourceManager.GetString("AvoidWriteOnlyVariables_RuleName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Can&apos;t create ResourceManager for {0} from {1}..
        /// </summary>
        internal static string CannotCreateResourceManager {
            get {
                return ResourceManager.GetString("CannotCreateResourceManager", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SamplesCategory.
        /// </summary>
        internal static string CategorySamples {
            get {
                return ResourceManager.GetString("CategorySamples", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Clustered Key Column found in non-unique Index on a Clustered Table in {0}..
        /// </summary>
        internal static string CheckClusteredKeyColumnsNotIncludedInIndex_ProblemDescription {
            get {
                return ResourceManager.GetString("CheckClusteredKeyColumnsNotIncludedInIndex_ProblemDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Clustered Key Columns need not be explicitly included in a non-unique Index on a Clustered Table.  The clustering columns are already added to the end of the index leaf entry..
        /// </summary>
        internal static string CheckClusteredKeyColumnsNotIncludedInIndex_RuleName {
            get {
                return ResourceManager.GetString("CheckClusteredKeyColumnsNotIncludedInIndex_RuleName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Default found on nullable column in {0}..
        /// </summary>
        internal static string CheckDefaultsAreOnNotNullColumns_ProblemDescription {
            get {
                return ResourceManager.GetString("CheckDefaultsAreOnNotNullColumns_ProblemDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Default values make more sense on non-nullable columns..
        /// </summary>
        internal static string CheckDefaultsAreOnNotNullColumns_RuleName {
            get {
                return ResourceManager.GetString("CheckDefaultsAreOnNotNullColumns_RuleName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Duplicated column found in index or constraint in {0}..
        /// </summary>
        internal static string CheckForDuplicatedColumnsInIndexOrConstraint_ProblemDescription {
            get {
                return ResourceManager.GetString("CheckForDuplicatedColumnsInIndexOrConstraint_ProblemDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Avoid duplicating columns in the key of any index or constraint..
        /// </summary>
        internal static string CheckForDuplicatedColumnsInIndexOrConstraint_RuleName {
            get {
                return ResourceManager.GetString("CheckForDuplicatedColumnsInIndexOrConstraint_RuleName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Table with multiple Foreign Key relationships to the same Parent Table was found in {0}..
        /// </summary>
        internal static string CheckMultipleForeignKeysBetweenTheSameTable_ProblemDescription {
            get {
                return ResourceManager.GetString("CheckMultipleForeignKeysBetweenTheSameTable_ProblemDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Apart from tables modeling graph structures, and role-playing tables, it&apos;s unusual to find multiple relationships between two tables.  It may indicate a non-normal database design..
        /// </summary>
        internal static string CheckMultipleForeignKeysBetweenTheSameTable_RuleName {
            get {
                return ResourceManager.GetString("CheckMultipleForeignKeysBetweenTheSameTable_RuleName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Table with more than 5 Child Foreign Key relationships was found in {0}..
        /// </summary>
        internal static string CheckMultipleForeignKeysFromOneTable_ProblemDescription {
            get {
                return ResourceManager.GetString("CheckMultipleForeignKeysFromOneTable_ProblemDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Multiple FK relationships from one table may indicate an overly general design and/or a lack of normalisation..
        /// </summary>
        internal static string CheckMultipleForeignKeysFromOneTable_RuleName {
            get {
                return ResourceManager.GetString("CheckMultipleForeignKeysFromOneTable_RuleName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Code found checking @@trancount but not xact_state() or vice-versa in {0}..
        /// </summary>
        internal static string CheckOpenTransactionCountCode_ProblemDescription {
            get {
                return ResourceManager.GetString("CheckOpenTransactionCountCode_ProblemDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Neither @@trancount not xact_state() by themselves give the full picture of the number of open transaction.  Check both..
        /// </summary>
        internal static string CheckOpenTransactionCountCode_RuleName {
            get {
                return ResourceManager.GetString("CheckOpenTransactionCountCode_RuleName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unattached BEGIN/END block found in {0}..
        /// </summary>
        internal static string CheckOrphanedBeginEndBlocks_ProblemDescription {
            get {
                return ResourceManager.GetString("CheckOrphanedBeginEndBlocks_ProblemDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to BEGIN/END blocks do not define a scope in T-SQL.  They have no use unless associated with a control construct e.g. IF or WHILE..
        /// </summary>
        internal static string CheckOrphanedBeginEndBlocks_RuleName {
            get {
                return ResourceManager.GetString("CheckOrphanedBeginEndBlocks_RuleName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unique constraint found with nullable columns in {0}.  You should probably make the columns non-nullable..
        /// </summary>
        internal static string CheckUniqueConstraintHasNoNullColumns_ProblemDescription {
            get {
                return ResourceManager.GetString("CheckUniqueConstraintHasNoNullColumns_ProblemDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unique constraints generally should not have nullable columns..
        /// </summary>
        internal static string CheckUniqueConstraintHasNoNullColumns_RuleName {
            get {
                return ResourceManager.GetString("CheckUniqueConstraintHasNoNullColumns_RuleName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unique, non-filtered index found with nullable columns in {0}.  You should probably make the columns non-nullable, or make the index filtered to exclude nulls..
        /// </summary>
        internal static string CheckUniqueIndexHasNoNullColumns_ProblemDescription {
            get {
                return ResourceManager.GetString("CheckUniqueIndexHasNoNullColumns_ProblemDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unique indexes generally should not have nullable columns unless the index is filtered to remove them..
        /// </summary>
        internal static string CheckUniqueIndexHasNoNullColumns_RuleName {
            get {
                return ResourceManager.GetString("CheckUniqueIndexHasNoNullColumns_RuleName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unique constraint or index found where another unique constraint has already been defined over a subset of the columns in {0}..
        /// </summary>
        internal static string CheckUniqueKeysAreNotDuplicated_ProblemDescription {
            get {
                return ResourceManager.GetString("CheckUniqueKeysAreNotDuplicated_ProblemDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unique constraints and indexes shouldn&apos;t be over-constrained..
        /// </summary>
        internal static string CheckUniqueKeysAreNotDuplicated_RuleName {
            get {
                return ResourceManager.GetString("CheckUniqueKeysAreNotDuplicated_RuleName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unnecessary brackets found in {0}..
        /// </summary>
        internal static string CheckUnnecessaryBrackets_ProblemDescription {
            get {
                return ResourceManager.GetString("CheckUnnecessaryBrackets_ProblemDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unnecessary bracketing..
        /// </summary>
        internal static string CheckUnnecessaryBrackets_RuleName {
            get {
                return ResourceManager.GetString("CheckUnnecessaryBrackets_RuleName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Permanent, statically defined table, constraint or index is altered by code in {0}.This may make the database inconsistent with the project..
        /// </summary>
        internal static string DisallowAllCodeManipulationOfProjectDefinedObjects_ProblemDescription {
            get {
                return ResourceManager.GetString("DisallowAllCodeManipulationOfProjectDefinedObjects_ProblemDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Permanent, statically defined objects should not be altered by code..
        /// </summary>
        internal static string DisallowAllCodeManipulationOfProjectDefinedObjects_RuleName {
            get {
                return ResourceManager.GetString("DisallowAllCodeManipulationOfProjectDefinedObjects_RuleName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An object is being renamed in {0}.  This may make the database inconsistent with the project..
        /// </summary>
        internal static string DisallowUseOfSp_ReName_ProblemDescription {
            get {
                return ResourceManager.GetString("DisallowUseOfSp_ReName_ProblemDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Database objects should not be renamed by code at runtime..
        /// </summary>
        internal static string DisallowUseOfSp_ReName_RuleName {
            get {
                return ResourceManager.GetString("DisallowUseOfSp_ReName_RuleName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Non-core SP is called without checking the return status in {0}..
        /// </summary>
        internal static string EnforceCaptureSPReturnStatus_ProblemDescription {
            get {
                return ResourceManager.GetString("EnforceCaptureSPReturnStatus_ProblemDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Return status should always be retrieved..
        /// </summary>
        internal static string EnforceCaptureSPReturnStatus_RuleName {
            get {
                return ResourceManager.GetString("EnforceCaptureSPReturnStatus_RuleName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Table with heap structure was found in {0}..
        /// </summary>
        internal static string EnforceClusteredIndex_ProblemDescription {
            get {
                return ResourceManager.GetString("EnforceClusteredIndex_ProblemDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Tables should normally be clustered and not heap..
        /// </summary>
        internal static string EnforceClusteredIndex_RuleName {
            get {
                return ResourceManager.GetString("EnforceClusteredIndex_RuleName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Table in {0} has a clustered index or Unique Constraint that is not the Primary Key or a Foreign Key..
        /// </summary>
        internal static string EnforceClusteredIndexIsPrimaryOrForeignKey_ProblemDescription {
            get {
                return ResourceManager.GetString("EnforceClusteredIndexIsPrimaryOrForeignKey_ProblemDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Tables should normally be clustered on the Primary Key, or a Foreign Key..
        /// </summary>
        internal static string EnforceClusteredIndexIsPrimaryOrForeignKey_RuleName {
            get {
                return ResourceManager.GetString("EnforceClusteredIndexIsPrimaryOrForeignKey_RuleName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Table with no Foreign Key relationships was found in {0}..
        /// </summary>
        internal static string EnforceForeignKey_ProblemDescription {
            get {
                return ResourceManager.GetString("EnforceForeignKey_ProblemDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Tables should normally have a Foreign Key relationship with at least one other table..
        /// </summary>
        internal static string EnforceForeignKey_RuleName {
            get {
                return ResourceManager.GetString("EnforceForeignKey_RuleName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Foreign Key with no supporting index found in {0}..
        /// </summary>
        internal static string EnforceForeignKeyIsIndexed_ProblemDescription {
            get {
                return ResourceManager.GetString("EnforceForeignKeyIsIndexed_ProblemDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Foreign Keys should be supported by an appropriate index.  Otherwise table scans/locks will be taken..
        /// </summary>
        internal static string EnforceForeignKeyIsIndexed_RuleName {
            get {
                return ResourceManager.GetString("EnforceForeignKeyIsIndexed_RuleName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Foreign Key with no supporting unique index found in {0}..
        /// </summary>
        internal static string EnforceForeignKeyIsUniquelyIndexed_ProblemDescription {
            get {
                return ResourceManager.GetString("EnforceForeignKeyIsUniquelyIndexed_ProblemDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Foreign Keys should be supported by an appropriate unique index.  Each combination of the Foreign Key columns defines a unique subset of the data in the table..
        /// </summary>
        internal static string EnforceForeignKeyIsUniquelyIndexed_RuleName {
            get {
                return ResourceManager.GetString("EnforceForeignKeyIsUniquelyIndexed_RuleName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Index with a key that is just a subset or permutation of another key  found in {0}..
        /// </summary>
        internal static string EnforceIndexKeyColumnSeparation_ProblemDescription {
            get {
                return ResourceManager.GetString("EnforceIndexKeyColumnSeparation_ProblemDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Avoid indexes with keys that are just a permutation of another key, or form the leading edge of another key..
        /// </summary>
        internal static string EnforceIndexKeyColumnSeparation_RuleName {
            get {
                return ResourceManager.GetString("EnforceIndexKeyColumnSeparation_RuleName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unnamed constraint found in {0}.  Unnamed constraints make it difficult to perform database comparisons, and force redundant operations during code deployments..
        /// </summary>
        internal static string EnforceNamedConstraint_ProblemDescription {
            get {
                return ResourceManager.GetString("EnforceNamedConstraint_ProblemDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Avoid unnamed constraints.  These are assigned meaningless system-generated names at time of deployment..
        /// </summary>
        internal static string EnforceNamedConstraint_RuleName {
            get {
                return ResourceManager.GetString("EnforceNamedConstraint_RuleName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Table with no Primary Key was found in {0}..
        /// </summary>
        internal static string EnforcePrimaryKey_ProblemDescription {
            get {
                return ResourceManager.GetString("EnforcePrimaryKey_ProblemDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Tables should normally have a Primary Key constraint defined..
        /// </summary>
        internal static string EnforcePrimaryKey_RuleName {
            get {
                return ResourceManager.GetString("EnforcePrimaryKey_RuleName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Stored Procedure found without Return as the final executable statement in {0}..
        /// </summary>
        internal static string EnforceReturn_ProblemDescription {
            get {
                return ResourceManager.GetString("EnforceReturn_ProblemDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Stored Procedures have Return as the final executable statement..
        /// </summary>
        internal static string EnforceReturn_RuleName {
            get {
                return ResourceManager.GetString("EnforceReturn_RuleName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Data Source found without an alias in {0}..
        /// </summary>
        internal static string EnforceTableAlias_ProblemDescription {
            get {
                return ResourceManager.GetString("EnforceTableAlias_ProblemDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Tables, views and other data sources in DML need aliases where disambiguation is necessary..
        /// </summary>
        internal static string EnforceTableAlias_RuleName {
            get {
                return ResourceManager.GetString("EnforceTableAlias_RuleName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Code found without Try/Catch in {0}..
        /// </summary>
        internal static string EnforceTryCatch_ProblemDescription {
            get {
                return ResourceManager.GetString("EnforceTryCatch_ProblemDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Triggers and non-simple Stored Procedures need at least one Try/Catch block..
        /// </summary>
        internal static string EnforceTryCatch_RuleName {
            get {
                return ResourceManager.GetString("EnforceTryCatch_RuleName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Variable length datatype found with no length specification in {0}..
        /// </summary>
        internal static string EnforceVariableLengthDataSpecification_ProblemDescription {
            get {
                return ResourceManager.GetString("EnforceVariableLengthDataSpecification_ProblemDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Don&apos;t rely on default values for variable length datatypes, other than DateTime2. .
        /// </summary>
        internal static string EnforceVariableLengthDataSpecification_RuleName {
            get {
                return ResourceManager.GetString("EnforceVariableLengthDataSpecification_RuleName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Constant set but not by an initialiser in {0}.
        /// </summary>
        internal static string PreferConstantInitialisation_ProblemDescription {
            get {
                return ResourceManager.GetString("PreferConstantInitialisation_ProblemDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Variables set to constant values and never reset, are best set on declaration..
        /// </summary>
        internal static string PreferConstantInitialisation_RuleName {
            get {
                return ResourceManager.GetString("PreferConstantInitialisation_RuleName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Raiserror found in {0}..
        /// </summary>
        internal static string PreferThrowToRaiserror_ProblemDescription {
            get {
                return ResourceManager.GetString("PreferThrowToRaiserror_ProblemDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Prefer using Throw to Raiserror when raising an error..
        /// </summary>
        internal static string PreferThrowToRaiserror_RuleName {
            get {
                return ResourceManager.GetString("PreferThrowToRaiserror_RuleName", resourceCulture);
            }
        }
    }
}
