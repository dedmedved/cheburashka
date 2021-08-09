//------------------------------------------------------------------------------
//<copyright company="Microsoft">
//
//    The MIT License (MIT)
//    
//    Copyright (c) 2015 Microsoft
//    
//    Permission is hereby granted, free of charge, to any person obtaining a copy
//    of this software and associated documentation files (the "Software"), to deal
//    in the Software without restriction, including without limitation the rights
//    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//    copies of the Software, and to permit persons to whom the Software is
//    furnished to do so, subject to the following conditions:
//    
//    The above copyright notice and this permission notice shall be included in all
//    copies or substantial portions of the Software.
//    
//    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//    SOFTWARE.
//</copyright>
//------------------------------------------------------------------------------

namespace Microsoft.SqlServer.Dac.Extensions.Prototype
{
	using System;
	using System.Linq; 
	using Microsoft.SqlServer.Server;
	using Microsoft.SqlServer.Dac.Model;
	using System.Collections.Generic;
    public interface ISql90TSqlColumnReference : ISql90TSqlColumn
	{
    }
	public interface ISql90TSqlColumn : ISqlModelElement
	{		
		String Collation 
		{
			get;
		}
		String Expression 
		{
			get;
		}
		String IdentityIncrement 
		{
			get;
		}
		String IdentitySeed 
		{
			get;
		}
		Boolean IsIdentity 
		{
			get;
		}
		Boolean IsIdentityNotForReplication 
		{
			get;
		}
		Boolean IsMax 
		{
			get;
		}
		Boolean IsRowGuidCol 
		{
			get;
		}
		Int32 Length 
		{
			get;
		}
		Boolean Nullable 
		{
			get;
		}
		Boolean Persisted 
		{
			get;
		}
		Boolean? PersistedNullable 
		{
			get;
		}
		Int32 Precision 
		{
			get;
		}
		Int32 Scale 
		{
			get;
		}
		XmlStyle XmlStyle 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlDataType> DataType 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ExpressionDependencies 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlXmlSchemaCollectionReference> XmlSchemaCollection 
		{
			get;
		}
	}
    public interface ISql90TSqlTableValuedFunctionReference : ISql90TSqlTableValuedFunction
	{
    }
	public interface ISql90TSqlTableValuedFunction : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		Boolean CalledOnNullInput 
		{
			get;
		}
		String ClassName 
		{
			get;
		}
		DataAccessKind? DataAccess 
		{
			get;
		}
		Boolean? Deterministic 
		{
			get;
		}
		Boolean ExecuteAsCaller 
		{
			get;
		}
		Boolean ExecuteAsOwner 
		{
			get;
		}
		Boolean ExecuteAsSelf 
		{
			get;
		}
		String FillRowMethodName 
		{
			get;
		}
		Boolean IsNativeCompiled 
		{
			get;
		}
		Boolean IsReplicated 
		{
			get;
		}
		String MethodName 
		{
			get;
		}
		Boolean? Precise 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		Boolean ReturnsNullOnNullInput 
		{
			get;
		}
		String ReturnTableVariableName 
		{
			get;
		}
		SystemDataAccessKind? SystemDataAccess 
		{
			get;
		}
		Boolean WithEncryption 
		{
			get;
		}
		Boolean WithSchemaBinding 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlAssembly> Assembly 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BodyDependencies 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlColumn> Columns 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlLoginReference> Login 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlParameter> Parameters 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlDataTypeReference> ReturnType 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlSchemaReference> Schema 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlClrTableOption> TableOption 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlUserReference> User 
		{
			get;
		}
	}
    public interface ISql90TSqlScalarFunctionReference : ISql90TSqlScalarFunction
	{
    }
	public interface ISql90TSqlScalarFunction : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		Boolean CalledOnNullInput 
		{
			get;
		}
		String ClassName 
		{
			get;
		}
		DataAccessKind? DataAccess 
		{
			get;
		}
		Boolean? Deterministic 
		{
			get;
		}
		Boolean ExecuteAsCaller 
		{
			get;
		}
		Boolean ExecuteAsOwner 
		{
			get;
		}
		Boolean ExecuteAsSelf 
		{
			get;
		}
		String FillRowMethodName 
		{
			get;
		}
		Boolean IsNativeCompiled 
		{
			get;
		}
		Boolean IsReplicated 
		{
			get;
		}
		String MethodName 
		{
			get;
		}
		Boolean? Precise 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		Boolean ReturnsNullOnNullInput 
		{
			get;
		}
		SystemDataAccessKind? SystemDataAccess 
		{
			get;
		}
		Boolean WithEncryption 
		{
			get;
		}
		Boolean WithSchemaBinding 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlAssembly> Assembly 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BodyDependencies 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlLoginReference> Login 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlParameter> Parameters 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlDataTypeReference> ReturnType 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlSchemaReference> Schema 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlUserReference> User 
		{
			get;
		}
	}
    public interface ISql90TSqlClrTableOptionReference : ISql90TSqlClrTableOption
	{
    }
	public interface ISql90TSqlClrTableOption : ISqlModelElement
	{		
		String ClassName 
		{
			get;
		}
	}
    public interface ISql90TSqlAggregateReference : ISql90TSqlAggregate
	{
    }
	public interface ISql90TSqlAggregate : ISqlModelElement
	{		
		String ClassName 
		{
			get;
		}
		Format Format 
		{
			get;
		}
		Boolean? InvariantToDuplicates 
		{
			get;
		}
		Boolean? InvariantToNulls 
		{
			get;
		}
		Int32? MaxByteSize 
		{
			get;
		}
		Boolean? NullIfEmpty 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlAssemblyReference> Assembly 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlParameter> Parameters 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlDataTypeReference> ReturnType 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISql90TSqlApplicationRoleReference : ISql90TSqlApplicationRole
	{
    }
	public interface ISql90TSqlApplicationRole : ISqlModelElement
	{		
		String Password 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlSchemaReference> DefaultSchema 
		{
			get;
		}
	}
    public interface ISql90TSqlIndexReference : ISql90TSqlIndex
	{
    }
	public interface ISql90TSqlIndex : ISqlModelElement
	{		
		Boolean AllowPageLocks 
		{
			get;
		}
		Boolean AllowRowLocks 
		{
			get;
		}
		Int32? BucketCount 
		{
			get;
		}
		Boolean Clustered 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Int32? FillFactor 
		{
			get;
		}
		Boolean Hash 
		{
			get;
		}
		Boolean IgnoreDuplicateKey 
		{
			get;
		}
		Boolean RecomputeStatistics 
		{
			get;
		}
		Boolean Unique 
		{
			get;
		}
		Boolean WithPadIndex 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlColumnReference> Columns 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlFilegroupReference> Filegroup 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlColumnReference> IncludedColumns 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISpecifiesIndex> IndexedObject 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlColumnReference> PartitionColumn 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlPartitionSchemeReference> PartitionScheme 
		{
			get;
		}
	}
    public interface ISql90TSqlAssemblyReference : ISql90TSqlAssembly
	{
    }
	public interface ISql90TSqlAssembly : ISqlModelElement
	{		
		AssemblyPermissionSet PermissionSet 
		{
			get;
		}
		Boolean Visible 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlAssemblySource> AssemblySources 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlAssemblyReference> ReferencedAssemblies 
		{
			get;
		}
	}
    public interface ISql90TSqlAssemblySourceReference : ISql90TSqlAssemblySource
	{
    }
	public interface ISql90TSqlAssemblySource : ISqlModelElement
	{		
		String Source 
		{
			get;
		}
	}
    public interface ISql90TSqlAsymmetricKeyReference : ISql90TSqlAsymmetricKey
	{
    }
	public interface ISql90TSqlAsymmetricKey : ISqlModelElement
	{		
		AsymmetricKeyAlgorithm Algorithm 
		{
			get;
		}
		Boolean EncryptedWithPassword 
		{
			get;
		}
		String ExecutableFile 
		{
			get;
		}
		String File 
		{
			get;
		}
		String Password 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlAssemblyReference> Assembly 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
	}
    public interface ISql90TSqlAuditActionReference : ISql90TSqlAuditAction
	{
    }
	public interface ISql90TSqlAuditAction : ISqlModelElement
	{		
	}
    public interface ISql90TSqlAuditActionGroupReference : ISql90TSqlAuditActionGroup
	{
    }
	public interface ISql90TSqlAuditActionGroup : ISqlModelElement
	{		
	}
    public interface ISql90TSqlAuditActionSpecificationReference : ISql90TSqlAuditActionSpecification
	{
    }
	public interface ISql90TSqlAuditActionSpecification : ISqlModelElement
	{		
	}
    public interface ISql90TSqlBrokerPriorityReference : ISql90TSqlBrokerPriority
	{
    }
	public interface ISql90TSqlBrokerPriority : ISqlModelElement
	{		
	}
    public interface ISql90TSqlBuiltInServerRoleReference : ISql90TSqlBuiltInServerRole
	{
    }
	public interface ISql90TSqlBuiltInServerRole : ISqlModelElement
	{		
	}
    public interface ISql90TSqlDataTypeReference : ISql90TSqlDataType
	{
    }
	public interface ISql90TSqlDataType : ISqlModelElement
	{		
		SqlDataType SqlDataType 
		{
			get;
		}
		Boolean UddtIsMax 
		{
			get;
		}
		Int32 UddtLength 
		{
			get;
		}
		Boolean UddtNullable 
		{
			get;
		}
		Int32 UddtPrecision 
		{
			get;
		}
		Int32 UddtScale 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlSchemaReference> Schema 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlDataTypeReference> Type 
		{
			get;
		}
	}
    public interface ISql90TSqlCertificateReference : ISql90TSqlCertificate
	{
    }
	public interface ISql90TSqlCertificate : ISqlModelElement
	{		
		Boolean ActiveForBeginDialog 
		{
			get;
		}
		Boolean EncryptedWithPassword 
		{
			get;
		}
		String EncryptionPassword 
		{
			get;
		}
		String ExistingKeysFilePath 
		{
			get;
		}
		String ExpiryDate 
		{
			get;
		}
		Boolean IsExistingKeyFileExecutable 
		{
			get;
		}
		String PrivateKeyDecryptionPassword 
		{
			get;
		}
		String PrivateKeyEncryptionPassword 
		{
			get;
		}
		String PrivateKeyFilePath 
		{
			get;
		}
		String StartDate 
		{
			get;
		}
		String Subject 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlAssemblyReference> ExistingKeysAssembly 
		{
			get;
		}
	}
    public interface ISql90TSqlCheckConstraintReference : ISql90TSqlCheckConstraint
	{
    }
	public interface ISql90TSqlCheckConstraint : ISqlModelElement
	{		
		Boolean Disabled 
		{
			get;
		}
		String Expression 
		{
			get;
		}
		Boolean NotForReplication 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ExpressionDependencies 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlTableReference> Host 
		{
			get;
		}
	}
    public interface ISql90TSqlClrTypeMethodReference : ISql90TSqlClrTypeMethod
	{
    }
	public interface ISql90TSqlClrTypeMethod : ISqlModelElement
	{		
		String MethodName 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlParameter> Parameters 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlDataType> ReturnType 
		{
			get;
		}
	}
    public interface ISql90TSqlClrTypeMethodParameterReference : ISql90TSqlClrTypeMethodParameter
	{
    }
	public interface ISql90TSqlClrTypeMethodParameter : ISqlModelElement
	{		
		Boolean IsOutput 
		{
			get;
		}
		String ParameterName 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlDataType> DataType 
		{
			get;
		}
	}
    public interface ISql90TSqlClrTypePropertyReference : ISql90TSqlClrTypeProperty
	{
    }
	public interface ISql90TSqlClrTypeProperty : ISqlModelElement
	{		
		String PropertyName 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlDataTypeReference> ClrType 
		{
			get;
		}
	}
    public interface ISql90TSqlColumnStoreIndexReference : ISql90TSqlColumnStoreIndex
	{
    }
	public interface ISql90TSqlColumnStoreIndex : ISqlModelElement
	{		
		Boolean Clustered 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlFilegroupReference> Filegroup 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISpecifiesIndex> IndexedObject 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlColumnReference> PartitionColumn 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlPartitionSchemeReference> PartitionScheme 
		{
			get;
		}
	}
    public interface ISql90TSqlContractReference : ISql90TSqlContract
	{
    }
	public interface ISql90TSqlContract : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlMessageTypeReference> Messages 
		{
			get;
		}
	}
    public interface ISql90TSqlCredentialReference : ISql90TSqlCredential
	{
    }
	public interface ISql90TSqlCredential : ISqlModelElement
	{		
		String Identity 
		{
			get;
		}
		String Secret 
		{
			get;
		}
	}
    public interface ISql90TSqlDatabaseCredentialReference : ISql90TSqlDatabaseCredential
	{
    }
	public interface ISql90TSqlDatabaseCredential : ISqlModelElement
	{		
	}
    public interface ISql90TSqlCryptographicProviderReference : ISql90TSqlCryptographicProvider
	{
    }
	public interface ISql90TSqlCryptographicProvider : ISqlModelElement
	{		
	}
    public interface ISql90TSqlDatabaseAuditSpecificationReference : ISql90TSqlDatabaseAuditSpecification
	{
    }
	public interface ISql90TSqlDatabaseAuditSpecification : ISqlModelElement
	{		
	}
    public interface ISql90TSqlDatabaseDdlTriggerReference : ISql90TSqlDatabaseDdlTrigger
	{
    }
	public interface ISql90TSqlDatabaseDdlTrigger : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		String ClassName 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Boolean ExecuteAsCaller 
		{
			get;
		}
		Boolean ExecuteAsOwner 
		{
			get;
		}
		Boolean ExecuteAsSelf 
		{
			get;
		}
		String MethodName 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		TriggerType TriggerType 
		{
			get;
		}
		Boolean WithEncryption 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlAssemblyReference> Assembly 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BodyDependencies 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlEventGroup> EventGroup 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Model.EventType> EventType 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlLoginReference> Login 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlUserReference> User 
		{
			get;
		}
	}
    public interface ISql90TSqlDatabaseEncryptionKeyReference : ISql90TSqlDatabaseEncryptionKey
	{
    }
	public interface ISql90TSqlDatabaseEncryptionKey : ISqlModelElement
	{		
	}
    public interface ISql90TSqlDatabaseEventNotificationReference : ISql90TSqlDatabaseEventNotification
	{
    }
	public interface ISql90TSqlDatabaseEventNotification : ISqlModelElement
	{		
		String BrokerInstanceSpecifier 
		{
			get;
		}
		String BrokerService 
		{
			get;
		}
		Boolean WithFanIn 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlEventGroup> EventGroup 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Model.EventType> EventType 
		{
			get;
		}
	}
    public interface ISql90TSqlDatabaseMirroringLanguageSpecifierReference : ISql90TSqlDatabaseMirroringLanguageSpecifier
	{
    }
	public interface ISql90TSqlDatabaseMirroringLanguageSpecifier : ISqlModelElement
	{		
		ServiceBrokerEncryptionAlgorithm EncryptionAlgorithmPart1 
		{
			get;
		}
		ServiceBrokerEncryptionAlgorithm EncryptionAlgorithmPart2 
		{
			get;
		}
		EncryptionMode EncryptionMode 
		{
			get;
		}
		DatabaseMirroringRole RoleType 
		{
			get;
		}
		Boolean UseCertificateFirst 
		{
			get;
		}
		AuthenticationModes WindowsAuthenticationMode 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlCertificateReference> AuthenticationCertificate 
		{
			get;
		}
	}
    public interface ISql90TSqlDatabaseOptionsReference : ISql90TSqlDatabaseOptions
	{
    }
	public interface ISql90TSqlDatabaseOptions : ISqlModelElement
	{		
		Boolean AllowSnapshotIsolation 
		{
			get;
		}
		Boolean AnsiNullDefaultOn 
		{
			get;
		}
		Boolean AnsiNullsOn 
		{
			get;
		}
		Boolean AnsiPaddingOn 
		{
			get;
		}
		Boolean AnsiWarningsOn 
		{
			get;
		}
		Boolean ArithAbortOn 
		{
			get;
		}
		Boolean AutoClose 
		{
			get;
		}
		Boolean AutoCreateStatistics 
		{
			get;
		}
		Boolean AutoShrink 
		{
			get;
		}
		Boolean AutoUpdateStatistics 
		{
			get;
		}
		Boolean AutoUpdateStatisticsAsync 
		{
			get;
		}
		String Collation 
		{
			get;
		}
		Int32 CompatibilityLevel 
		{
			get;
		}
		Boolean ConcatNullYieldsNull 
		{
			get;
		}
		Boolean CursorCloseOnCommit 
		{
			get;
		}
		Boolean CursorDefaultGlobalScope 
		{
			get;
		}
		Boolean DatabaseStateOffline 
		{
			get;
		}
		Boolean DateCorrelationOptimizationOn 
		{
			get;
		}
		Boolean DBChainingOn 
		{
			get;
		}
		Boolean FullTextEnabled 
		{
			get;
		}
		Boolean MemoryOptimizedElevateToSnapshot 
		{
			get;
		}
		Boolean NumericRoundAbortOn 
		{
			get;
		}
		PageVerifyMode PageVerifyMode 
		{
			get;
		}
		ParameterizationOption ParameterizationOption 
		{
			get;
		}
		Boolean QuotedIdentifierOn 
		{
			get;
		}
		Boolean ReadOnly 
		{
			get;
		}
		RecoveryMode RecoveryMode 
		{
			get;
		}
		Boolean RecursiveTriggersOn 
		{
			get;
		}
		ServiceBrokerOption ServiceBrokerOption 
		{
			get;
		}
		Boolean SupplementalLoggingOn 
		{
			get;
		}
		Boolean TornPageProtectionOn 
		{
			get;
		}
		Boolean TransactionIsolationReadCommittedSnapshot 
		{
			get;
		}
		Boolean Trustworthy 
		{
			get;
		}
		UserAccessOption UserAccessOption 
		{
			get;
		}
		Boolean VardecimalStorageFormatOn 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlFilegroupReference> DefaultFilegroup 
		{
			get;
		}
	}
    public interface ISql90TSqlDataCompressionOptionReference : ISql90TSqlDataCompressionOption
	{
    }
	public interface ISql90TSqlDataCompressionOption : ISqlModelElement
	{		
	}
    public interface ISql90TSqlDefaultReference : ISql90TSqlDefault
	{
    }
	public interface ISql90TSqlDefault : ISqlModelElement
	{		
		String Expression 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BoundObjects 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISql90TSqlDefaultConstraintReference : ISql90TSqlDefaultConstraint
	{
    }
	public interface ISql90TSqlDefaultConstraint : ISqlModelElement
	{		
		Boolean Disabled 
		{
			get;
		}
		String Expression 
		{
			get;
		}
		Boolean WithValues 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ExpressionDependencies 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlTableReference> Host 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlColumnReference> TargetColumn 
		{
			get;
		}
	}
    public interface ISql90TSqlDmlTriggerReference : ISql90TSqlDmlTrigger
	{
    }
	public interface ISql90TSqlDmlTrigger : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		String ClassName 
		{
			get;
		}
		OrderRestriction DeleteOrderRestriction 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Boolean ExecuteAsCaller 
		{
			get;
		}
		Boolean ExecuteAsOwner 
		{
			get;
		}
		Boolean ExecuteAsSelf 
		{
			get;
		}
		OrderRestriction InsertOrderRestriction 
		{
			get;
		}
		Boolean IsDeleteTrigger 
		{
			get;
		}
		Boolean IsInsertTrigger 
		{
			get;
		}
		Boolean IsUpdateTrigger 
		{
			get;
		}
		String MethodName 
		{
			get;
		}
		Boolean NotForReplication 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		TriggerType TriggerType 
		{
			get;
		}
		OrderRestriction UpdateOrderRestriction 
		{
			get;
		}
		Boolean WithAppend 
		{
			get;
		}
		Boolean WithEncryption 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlAssemblyReference> Assembly 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BodyDependencies 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlLoginReference> Login 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> TriggerObject 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlUserReference> User 
		{
			get;
		}
	}
    public interface ISql90TSqlEndpointReference : ISql90TSqlEndpoint
	{
    }
	public interface ISql90TSqlEndpoint : ISqlModelElement
	{		
		Payload Payload 
		{
			get;
		}
		Protocol Protocol 
		{
			get;
		}
		State State 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.IEndpointLanguageSpecifier> PayloadSpecifier 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.IProtocolSpecifier > ProtocolSpecifier 
		{
			get;
		}
	}
    public interface ISql90TSqlErrorMessageReference : ISql90TSqlErrorMessage
	{
    }
	public interface ISql90TSqlErrorMessage : ISqlModelElement
	{		
		String Language 
		{
			get;
		}
		Int32 MessageNumber 
		{
			get;
		}
		String MessageText 
		{
			get;
		}
		Int32 Severity 
		{
			get;
		}
		Boolean WithLog 
		{
			get;
		}
	}
    public interface ISql90TSqlEventGroupReference : ISql90TSqlEventGroup
	{
    }
	public interface ISql90TSqlEventGroup : ISqlModelElement
	{		
		EventGroupType Group 
		{
			get;
		}
	}
    public interface ISql90TSqlEventSessionReference : ISql90TSqlEventSession
	{
    }
	public interface ISql90TSqlEventSession : ISqlModelElement
	{		
	}
    public interface ISql90TSqlDatabaseEventSessionReference : ISql90TSqlDatabaseEventSession
	{
    }
	public interface ISql90TSqlDatabaseEventSession : ISqlModelElement
	{		
	}
    public interface ISql90TSqlEventSessionActionReference : ISql90TSqlEventSessionAction
	{
    }
	public interface ISql90TSqlEventSessionAction : ISqlModelElement
	{		
	}
    public interface ISql90TSqlEventSessionDefinitionsReference : ISql90TSqlEventSessionDefinitions
	{
    }
	public interface ISql90TSqlEventSessionDefinitions : ISqlModelElement
	{		
	}
    public interface ISql90TSqlEventSessionSettingReference : ISql90TSqlEventSessionSetting
	{
    }
	public interface ISql90TSqlEventSessionSetting : ISqlModelElement
	{		
	}
    public interface ISql90TSqlEventSessionTargetReference : ISql90TSqlEventSessionTarget
	{
    }
	public interface ISql90TSqlEventSessionTarget : ISqlModelElement
	{		
	}
    public interface ISql90TSqlEventTypeSpecifierReference : ISql90TSqlEventTypeSpecifier
	{
    }
	public interface ISql90TSqlEventTypeSpecifier : ISqlModelElement
	{		
		EventType EventType 
		{
			get;
		}
		OrderRestriction Order 
		{
			get;
		}
	}
    public interface ISql90TSqlExtendedProcedureReference : ISql90TSqlExtendedProcedure
	{
    }
	public interface ISql90TSqlExtendedProcedure : ISqlModelElement
	{		
		Boolean ExeccuteAsCaller 
		{
			get;
		}
		Boolean ExecuteAsOwner 
		{
			get;
		}
		Boolean ExecuteAsSelf 
		{
			get;
		}
		Boolean WithEncryption 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlLoginReference> Login 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlParameter> Parameters 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlSchemaReference> Schema 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlUserReference> User 
		{
			get;
		}
	}
    public interface ISql90TSqlExtendedPropertyReference : ISql90TSqlExtendedProperty
	{
    }
	public interface ISql90TSqlExtendedProperty : ISqlModelElement
	{		
		String Value 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.IExtendedPropertyHost> Host 
		{
			get;
		}
	}
    public interface ISql90TSqlExternalDataSourceReference : ISql90TSqlExternalDataSource
	{
    }
	public interface ISql90TSqlExternalDataSource : ISqlModelElement
	{		
	}
    public interface ISql90TSqlExternalFileFormatReference : ISql90TSqlExternalFileFormat
	{
    }
	public interface ISql90TSqlExternalFileFormat : ISqlModelElement
	{		
	}
    public interface ISql90TSqlExternalTableReference : ISql90TSqlExternalTable
	{
    }
	public interface ISql90TSqlExternalTable : ISqlModelElement
	{		
		Boolean? IsAnsiNullsOn 
		{
			get;
		}
		Boolean? IsQuotedIdentifierOn 
		{
			get;
		}
		Boolean IsTableLockOnBulkLoad 
		{
			get;
		}
		//Composing
		IEnumerable<TSqlModelElementReference> Columns 
		{
			get;
		}
		//Peer
		IEnumerable<TSqlModelElementReference> Filegroup 
		{
			get;
		}
		//Peer
		IEnumerable<TSqlModelElementReference> PartitionColumn 
		{
			get;
		}
		//Peer
		IEnumerable<TSqlModelElementReference> PartitionScheme 
		{
			get;
		}
		//Hierarchical
		IEnumerable<TSqlModelElementReference> Schema 
		{
			get;
		}
	}
    public interface ISql90TSqlSqlFileReference : ISql90TSqlSqlFile
	{
    }
	public interface ISql90TSqlSqlFile : ISqlModelElement
	{		
		Int32? FileGrowth 
		{
			get;
		}
		MemoryUnit FileGrowthUnit 
		{
			get;
		}
		String FileName 
		{
			get;
		}
		Boolean IsLogFile 
		{
			get;
		}
		Int32? MaxSize 
		{
			get;
		}
		MemoryUnit MaxSizeUnit 
		{
			get;
		}
		Boolean Offline 
		{
			get;
		}
		Int32? Size 
		{
			get;
		}
		MemoryUnit SizeUnit 
		{
			get;
		}
		Boolean Unlimited 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlFilegroupReference> Filegroup 
		{
			get;
		}
	}
    public interface ISql90TSqlFilegroupReference : ISql90TSqlFilegroup
	{
    }
	public interface ISql90TSqlFilegroup : ISqlModelElement
	{		
		Boolean ReadOnly 
		{
			get;
		}
	}
    public interface ISql90TSqlForeignKeyConstraintReference : ISql90TSqlForeignKeyConstraint
	{
    }
	public interface ISql90TSqlForeignKeyConstraint : ISqlModelElement
	{		
		ForeignKeyAction DeleteAction 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Boolean NotForReplication 
		{
			get;
		}
		ForeignKeyAction UpdateAction 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlColumnReference> Columns 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlColumnReference> ForeignColumns 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlTableReference> ForeignTable 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlTableReference> Host 
		{
			get;
		}
	}
    public interface ISql90TSqlFullTextCatalogReference : ISql90TSqlFullTextCatalog
	{
    }
	public interface ISql90TSqlFullTextCatalog : ISqlModelElement
	{		
		Boolean? AccentSensitivity 
		{
			get;
		}
		Boolean IsDefault 
		{
			get;
		}
		String Path 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlFilegroupReference> Filegroup 
		{
			get;
		}
	}
    public interface ISql90TSqlFullTextIndexReference : ISql90TSqlFullTextIndex
	{
    }
	public interface ISql90TSqlFullTextIndex : ISqlModelElement
	{		
		ChangeTrackingOption ChangeTracking 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Boolean Replicated 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.TSqlModelElementReference> Catalog 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlFullTextIndexColumnSpecifier> Columns 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISpecifiesIndex> IndexedObject 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> UniqueIndexName 
		{
			get;
		}
	}
    public interface ISql90TSqlFullTextIndexColumnSpecifierReference : ISql90TSqlFullTextIndexColumnSpecifier
	{
    }
	public interface ISql90TSqlFullTextIndexColumnSpecifier : ISqlModelElement
	{		
		Int32? LanguageId 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlColumnReference> Column 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlColumnReference> TypeColumn 
		{
			get;
		}
	}
    public interface ISql90TSqlFullTextStopListReference : ISql90TSqlFullTextStopList
	{
    }
	public interface ISql90TSqlFullTextStopList : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
	}
    public interface ISql90TSqlHttpProtocolSpecifierReference : ISql90TSqlHttpProtocolSpecifier
	{
    }
	public interface ISql90TSqlHttpProtocolSpecifier : ISqlModelElement
	{		
		AuthenticationModes AuthenticationMode 
		{
			get;
		}
		String AuthenticationRealm 
		{
			get;
		}
		Int32? ClearPort 
		{
			get;
		}
		Boolean CompressionEnabled 
		{
			get;
		}
		String DefaultLogonDomain 
		{
			get;
		}
		Boolean ListeningOnAllNoneReservedSites 
		{
			get;
		}
		Boolean ListeningOnAllSites 
		{
			get;
		}
		String Path 
		{
			get;
		}
		HttpPorts Ports 
		{
			get;
		}
		Int32? SslPort 
		{
			get;
		}
		String Website 
		{
			get;
		}
	}
    public interface ISql90TSqlLinkedServerReference : ISql90TSqlLinkedServer
	{
    }
	public interface ISql90TSqlLinkedServer : ISqlModelElement
	{		
		String Catalog 
		{
			get;
		}
		Boolean CollationCompatible 
		{
			get;
		}
		String CollationName 
		{
			get;
		}
		Int32 ConnectTimeout 
		{
			get;
		}
		Boolean DataAccess 
		{
			get;
		}
		String DataSource 
		{
			get;
		}
		Boolean IsDistributor 
		{
			get;
		}
		Boolean IsPublisher 
		{
			get;
		}
		Boolean IsSubscriber 
		{
			get;
		}
		Boolean LazySchemaValidationEnabled 
		{
			get;
		}
		String Location 
		{
			get;
		}
		String ProductName 
		{
			get;
		}
		String ProviderName 
		{
			get;
		}
		String ProviderString 
		{
			get;
		}
		Int32 QueryTimeout 
		{
			get;
		}
		Boolean RpcEnabled 
		{
			get;
		}
		Boolean RpcOutEnabled 
		{
			get;
		}
		Boolean UseRemoteCollation 
		{
			get;
		}
	}
    public interface ISql90TSqlLinkedServerLoginReference : ISql90TSqlLinkedServerLogin
	{
    }
	public interface ISql90TSqlLinkedServerLogin : ISqlModelElement
	{		
		String LinkedServerLoginName 
		{
			get;
		}
		String LinkedServerPassword 
		{
			get;
		}
		Boolean UseSelf 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlLinkedServerReference> LinkedServer 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlLoginReference> LocalLogin 
		{
			get;
		}
	}
    public interface ISql90TSqlLoginReference : ISql90TSqlLogin
	{
    }
	public interface ISql90TSqlLogin : ISqlModelElement
	{		
		Boolean CheckExpiration 
		{
			get;
		}
		Boolean CheckPolicy 
		{
			get;
		}
		String DefaultDatabase 
		{
			get;
		}
		String DefaultLanguage 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		LoginEncryptionOption EncryptionOption 
		{
			get;
		}
		Boolean MappedToWindowsLogin 
		{
			get;
		}
		String Password 
		{
			get;
		}
		Boolean PasswordHashed 
		{
			get;
		}
		Boolean PasswordMustChange 
		{
			get;
		}
		String Sid 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlAsymmetricKeyReference> AsymmetricKey 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlCertificateReference> Certificate 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlCredentialReference> Credential 
		{
			get;
		}
	}
    public interface ISql90TSqlMasterKeyReference : ISql90TSqlMasterKey
	{
    }
	public interface ISql90TSqlMasterKey : ISqlModelElement
	{		
		String Password 
		{
			get;
		}
	}
    public interface ISql90TSqlMessageTypeReference : ISql90TSqlMessageType
	{
    }
	public interface ISql90TSqlMessageType : ISqlModelElement
	{		
		ValidationMethod ValidationMethod 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlXmlSchemaCollectionReference> XmlSchemaCollection 
		{
			get;
		}
	}
    public interface ISql90TSqlPartitionFunctionReference : ISql90TSqlPartitionFunction
	{
    }
	public interface ISql90TSqlPartitionFunction : ISqlModelElement
	{		
		PartitionRange Range 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlPartitionValue> BoundaryValues 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlDataTypeReference> ParameterType 
		{
			get;
		}
	}
    public interface ISql90TSqlPartitionSchemeReference : ISql90TSqlPartitionScheme
	{
    }
	public interface ISql90TSqlPartitionScheme : ISqlModelElement
	{		
		Boolean AllToOneFilegroup 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlFilegroupReference> Filegroups 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlPartitionFunctionReference> PartitionFunction 
		{
			get;
		}
	}
    public interface ISql90TSqlPartitionValueReference : ISql90TSqlPartitionValue
	{
    }
	public interface ISql90TSqlPartitionValue : ISqlModelElement
	{		
		String Expression 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ExpressionDependencies 
		{
			get;
		}
	}
    public interface ISql90TSqlPermissionReference : ISql90TSqlPermission
	{
    }
	public interface ISql90TSqlPermission : ISqlModelElement
	{		
		PermissionAction PermissionAction 
		{
			get;
		}
		PermissionType PermissionType 
		{
			get;
		}
		Boolean WithAllPrivileges 
		{
			get;
		}
		Boolean WithGrantOption 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlColumnReference> ExcludedColumns 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlSecurityPrincipal> Grantee 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlSecurityPrincipal> Grantor 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlColumnReference> RevokedGrantOptionColumns 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlSecurable> SecuredObject 
		{
			get;
		}
	}
    public interface ISql90TSqlPrimaryKeyConstraintReference : ISql90TSqlPrimaryKeyConstraint
	{
    }
	public interface ISql90TSqlPrimaryKeyConstraint : ISqlModelElement
	{		
		Boolean AllowPageLocks 
		{
			get;
		}
		Boolean AllowRowLocks 
		{
			get;
		}
		Int32? BucketCount 
		{
			get;
		}
		Boolean Clustered 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Int32? FillFactor 
		{
			get;
		}
		Boolean Hash 
		{
			get;
		}
		Boolean IgnoreDuplicateKey 
		{
			get;
		}
		Boolean RecomputeStatistics 
		{
			get;
		}
		Boolean WithPadIndex 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlColumnReference> Columns 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlFilegroupReference> Filegroup 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlTableReference> Host 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlColumnReference> PartitionColumn 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlPartitionSchemeReference> PartitionScheme 
		{
			get;
		}
	}
    public interface ISql90TSqlProcedureReference : ISql90TSqlProcedure
	{
    }
	public interface ISql90TSqlProcedure : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		String ClassName 
		{
			get;
		}
		Boolean ExecuteAsCaller 
		{
			get;
		}
		Boolean ExecuteAsOwner 
		{
			get;
		}
		Boolean ExecuteAsSelf 
		{
			get;
		}
		Boolean ForReplication 
		{
			get;
		}
		Boolean IsReplicated 
		{
			get;
		}
		String MethodName 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		Boolean WithEncryption 
		{
			get;
		}
		Boolean WithRecompile 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlAssemblyReference> Assembly 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BodyDependencies 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlLoginReference> Login 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlParameter> Parameters 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlProcedureReference> ParentProcedure 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlSchemaReference> Schema 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlUserReference> User 
		{
			get;
		}
	}
    public interface ISql90TSqlQueueReference : ISql90TSqlQueue
	{
    }
	public interface ISql90TSqlQueue : ISqlModelElement
	{		
		Boolean ActivationExecuteAsCaller 
		{
			get;
		}
		Boolean ActivationExecuteAsOwner 
		{
			get;
		}
		Boolean ActivationExecuteAsSelf 
		{
			get;
		}
		Int32? ActivationMaxQueueReaders 
		{
			get;
		}
		Boolean? ActivationStatusOn 
		{
			get;
		}
		Boolean RetentionOn 
		{
			get;
		}
		Boolean StatusOn 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlProcedureReference> ActivationProcedure 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlColumn> Columns 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlFilegroupReference> Filegroup 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlLoginReference> Login 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlColumnReference> PartitionColumn 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlPartitionSchemeReference> PartitionScheme 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlSchemaReference> Schema 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlUserReference> User 
		{
			get;
		}
	}
    public interface ISql90TSqlQueueEventNotificationReference : ISql90TSqlQueueEventNotification
	{
    }
	public interface ISql90TSqlQueueEventNotification : ISqlModelElement
	{		
		String BrokerInstanceSpecifier 
		{
			get;
		}
		String BrokerService 
		{
			get;
		}
		Boolean WithFanIn 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlEventGroup> EventGroup 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Model.EventType> EventType 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlQueueReference> Queue 
		{
			get;
		}
	}
    public interface ISql90TSqlRemoteServiceBindingReference : ISql90TSqlRemoteServiceBinding
	{
    }
	public interface ISql90TSqlRemoteServiceBinding : ISqlModelElement
	{		
		Boolean Anonymous 
		{
			get;
		}
		String Service 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlUserReference> User 
		{
			get;
		}
	}
    public interface ISql90TSqlResourceGovernorReference : ISql90TSqlResourceGovernor
	{
    }
	public interface ISql90TSqlResourceGovernor : ISqlModelElement
	{		
	}
    public interface ISql90TSqlResourcePoolReference : ISql90TSqlResourcePool
	{
    }
	public interface ISql90TSqlResourcePool : ISqlModelElement
	{		
	}
    public interface ISql90TSqlRoleReference : ISql90TSqlRole
	{
    }
	public interface ISql90TSqlRole : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
	}
    public interface ISql90TSqlRoleMembershipReference : ISql90TSqlRoleMembership
	{
    }
	public interface ISql90TSqlRoleMembership : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlDatabaseSecurityPrincipal> Member 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlRoleReference> Role 
		{
			get;
		}
	}
    public interface ISql90TSqlRouteReference : ISql90TSqlRoute
	{
    }
	public interface ISql90TSqlRoute : ISqlModelElement
	{		
		String Address 
		{
			get;
		}
		String BrokerInstance 
		{
			get;
		}
		Int32? Lifetime 
		{
			get;
		}
		String MirrorAddress 
		{
			get;
		}
		String ServiceName 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
	}
    public interface ISql90TSqlRuleReference : ISql90TSqlRule
	{
    }
	public interface ISql90TSqlRule : ISqlModelElement
	{		
		String Expression 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BoundObjects 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISql90TSqlSchemaReference : ISql90TSqlSchema
	{
    }
	public interface ISql90TSqlSchema : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
	}
    public interface ISql90TSqlSearchPropertyReference : ISql90TSqlSearchProperty
	{
    }
	public interface ISql90TSqlSearchProperty : ISqlModelElement
	{		
	}
    public interface ISql90TSqlSearchPropertyListReference : ISql90TSqlSearchPropertyList
	{
    }
	public interface ISql90TSqlSearchPropertyList : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
	}
    public interface ISql90TSqlSecurityPolicyReference : ISql90TSqlSecurityPolicy
	{
    }
	public interface ISql90TSqlSecurityPolicy : ISqlModelElement
	{		
		Boolean Enabled 
		{
			get;
		}
		Boolean IsSchemaBound 
		{
			get;
		}
		Boolean NotForReplication 
		{
			get;
		}
		//Composing
		IEnumerable<TSqlModelElementReference> Predicates 
		{
			get;
		}
		//Hierarchical
		IEnumerable<TSqlModelElementReference> Schema 
		{
			get;
		}
	}
    public interface ISql90TSqlSecurityPredicateReference : ISql90TSqlSecurityPredicate
	{
    }
	public interface ISql90TSqlSecurityPredicate : ISqlModelElement
	{		
		String BodyScript 
		{
			get;
		}
		SecurityPredicateOperation Operation 
		{
			get;
		}
		SecurityPredicateType PredicateType 
		{
			get;
		}
		//Peer
		IEnumerable<TSqlModelElementReference> BodyDependencies 
		{
			get;
		}
		//Peer
		IEnumerable<TSqlModelElementReference> TargetObject 
		{
			get;
		}
	}
    public interface ISql90TSqlSequenceReference : ISql90TSqlSequence
	{
    }
	public interface ISql90TSqlSequence : ISqlModelElement
	{		
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISql90TSqlServerAuditReference : ISql90TSqlServerAudit
	{
    }
	public interface ISql90TSqlServerAudit : ISqlModelElement
	{		
	}
    public interface ISql90TSqlServerAuditSpecificationReference : ISql90TSqlServerAuditSpecification
	{
    }
	public interface ISql90TSqlServerAuditSpecification : ISqlModelElement
	{		
	}
    public interface ISql90TSqlServerDdlTriggerReference : ISql90TSqlServerDdlTrigger
	{
    }
	public interface ISql90TSqlServerDdlTrigger : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		String ClassName 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Boolean ExecuteAsCaller 
		{
			get;
		}
		Boolean ExecuteAsOwner 
		{
			get;
		}
		Boolean ExecuteAsSelf 
		{
			get;
		}
		Boolean IsLogon 
		{
			get;
		}
		String MethodName 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		TriggerType TriggerType 
		{
			get;
		}
		Boolean WithEncryption 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlAssemblyReference> Assembly 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BodyDependencies 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlEventGroup> EventGroup 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Model.EventType> EventType 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlLoginReference> Login 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlUserReference> User 
		{
			get;
		}
	}
    public interface ISql90TSqlServerEventNotificationReference : ISql90TSqlServerEventNotification
	{
    }
	public interface ISql90TSqlServerEventNotification : ISqlModelElement
	{		
		String BrokerInstanceSpecifier 
		{
			get;
		}
		String BrokerService 
		{
			get;
		}
		Boolean WithFanIn 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlEventGroup> EventGroup 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Model.EventType> EventType 
		{
			get;
		}
	}
    public interface ISql90TSqlServerOptionsReference : ISql90TSqlServerOptions
	{
    }
	public interface ISql90TSqlServerOptions : ISqlModelElement
	{		
	}
    public interface ISql90TSqlServerRoleMembershipReference : ISql90TSqlServerRoleMembership
	{
    }
	public interface ISql90TSqlServerRoleMembership : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.IServerSecurityPrincipal> Member 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlRoleReference> Role 
		{
			get;
		}
	}
    public interface ISql90TSqlServiceReference : ISql90TSqlService
	{
    }
	public interface ISql90TSqlService : ISqlModelElement
	{		
		Boolean UseDefaultContract 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlContractReference> Contracts 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlQueueReference> Queue 
		{
			get;
		}
	}
    public interface ISql90TSqlServiceBrokerLanguageSpecifierReference : ISql90TSqlServiceBrokerLanguageSpecifier
	{
    }
	public interface ISql90TSqlServiceBrokerLanguageSpecifier : ISqlModelElement
	{		
		ServiceBrokerEncryptionAlgorithm EncryptionAlgorithmPart1 
		{
			get;
		}
		ServiceBrokerEncryptionAlgorithm EncryptionAlgorithmPart2 
		{
			get;
		}
		EncryptionMode EncryptionMode 
		{
			get;
		}
		Boolean MessageForwardingEnabled 
		{
			get;
		}
		Int32 MessageForwardSize 
		{
			get;
		}
		Boolean UseCertificateFirst 
		{
			get;
		}
		AuthenticationModes WindowsAuthenticationMode 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlCertificateReference> AuthenticationCertificate 
		{
			get;
		}
	}
    public interface ISql90TSqlSignatureReference : ISql90TSqlSignature
	{
    }
	public interface ISql90TSqlSignature : ISqlModelElement
	{		
		Boolean IsCounterSignature 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.TSqlModelElement> EncryptionMechanism 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> SignedObject 
		{
			get;
		}
	}
    public interface ISql90TSqlSignatureEncryptionMechanismReference : ISql90TSqlSignatureEncryptionMechanism
	{
    }
	public interface ISql90TSqlSignatureEncryptionMechanism : ISqlModelElement
	{		
		String Password 
		{
			get;
		}
		String SignedBlob 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlAsymmetricKeyReference> AsymmetricKey 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlCertificateReference> Certificate 
		{
			get;
		}
	}
    public interface ISql90TSqlSoapLanguageSpecifierReference : ISql90TSqlSoapLanguageSpecifier
	{
    }
	public interface ISql90TSqlSoapLanguageSpecifier : ISqlModelElement
	{		
		Boolean BatchesEnabled 
		{
			get;
		}
		CharacterSet CharacterSet 
		{
			get;
		}
		String DatabaseName 
		{
			get;
		}
		Int32 HeaderLimit 
		{
			get;
		}
		Boolean IsDefaultDatabase 
		{
			get;
		}
		Boolean IsDefaultNamespace 
		{
			get;
		}
		Boolean IsDefaultWsdlSpName 
		{
			get;
		}
		SoapLoginType LoginType 
		{
			get;
		}
		String Namespace 
		{
			get;
		}
		SoapSchema SchemaType 
		{
			get;
		}
		Boolean SessionsEnabled 
		{
			get;
		}
		Int32 SessionTimeout 
		{
			get;
		}
		Boolean SessionTimeoutNever 
		{
			get;
		}
		String WsdlSpName 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlSoapMethodSpecification> WebMethods 
		{
			get;
		}
	}
    public interface ISql90TSqlSoapMethodSpecificationReference : ISql90TSqlSoapMethodSpecification
	{
    }
	public interface ISql90TSqlSoapMethodSpecification : ISqlModelElement
	{		
		SoapFormat Format 
		{
			get;
		}
		SoapSchema SchemaType 
		{
			get;
		}
		String WebMethodAlias 
		{
			get;
		}
		String WebMethodNamespace 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> RelatedMethod 
		{
			get;
		}
	}
    public interface ISql90TSqlSpatialIndexReference : ISql90TSqlSpatialIndex
	{
    }
	public interface ISql90TSqlSpatialIndex : ISqlModelElement
	{		
		Boolean Disabled 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlFilegroupReference> Filegroup 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlColumnReference> PartitionColumn 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlPartitionSchemeReference> PartitionScheme 
		{
			get;
		}
	}
    public interface ISql90TSqlStatisticsReference : ISql90TSqlStatistics
	{
    }
	public interface ISql90TSqlStatistics : ISqlModelElement
	{		
		Boolean NoRecompute 
		{
			get;
		}
		Int32 SampleSize 
		{
			get;
		}
		SamplingStyle SamplingStyle 
		{
			get;
		}
		String StatsStream 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlColumnReference> Columns 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> OnObject 
		{
			get;
		}
	}
    public interface ISql90TSqlParameterReference : ISql90TSqlParameter
	{
    }
	public interface ISql90TSqlParameter : ISqlModelElement
	{		
		String DefaultExpression 
		{
			get;
		}
		Boolean IsMax 
		{
			get;
		}
		Boolean IsOutput 
		{
			get;
		}
		Int32 Length 
		{
			get;
		}
		Int32 Precision 
		{
			get;
		}
		Int32 Scale 
		{
			get;
		}
		Boolean Varying 
		{
			get;
		}
		XmlStyle XmlStyle 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlDataType> DataType 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlXmlSchemaCollectionReference> XmlSchemaCollection 
		{
			get;
		}
	}
    public interface ISql90TSqlSymmetricKeyReference : ISql90TSqlSymmetricKey
	{
    }
	public interface ISql90TSqlSymmetricKey : ISqlModelElement
	{		
		SymmetricKeyAlgorithm Algorithm 
		{
			get;
		}
		String IdentityValue 
		{
			get;
		}
		String KeySource 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlAsymmetricKeyReference> AsymmetricKeys 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlCertificateReference> Certificates 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.TSqlModelElement> Passwords 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlSymmetricKeyReference> SymmetricKeys 
		{
			get;
		}
	}
    public interface ISql90TSqlSymmetricKeyPasswordReference : ISql90TSqlSymmetricKeyPassword
	{
    }
	public interface ISql90TSqlSymmetricKeyPassword : ISqlModelElement
	{		
		String Password 
		{
			get;
		}
	}
    public interface ISql90TSqlSynonymReference : ISql90TSqlSynonym
	{
    }
	public interface ISql90TSqlSynonym : ISqlModelElement
	{		
		String ForObjectName 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ForObject 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISql90TSqlTableReference : ISql90TSqlTable
	{
    }
	public interface ISql90TSqlTable : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		Int64? DataPages 
		{
			get;
		}
		Double? DataSize 
		{
			get;
		}
		Double? IndexSize 
		{
			get;
		}
		Boolean IsAutoGeneratedHistoryTable 
		{
			get;
		}
		Boolean IsReplicated 
		{
			get;
		}
		Boolean LargeValueTypesOutOfRow 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		Int64? RowCount 
		{
			get;
		}
		Boolean TableLockOnBulkLoad 
		{
			get;
		}
		Int32 TextInRowSize 
		{
			get;
		}
		Int64? UsedPages 
		{
			get;
		}
		Boolean VardecimalStorageFormatEnabled 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlColumn> Columns 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlFilegroupReference> Filegroup 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlFilegroupReference> FilegroupForTextImage 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlColumnReference> PartitionColumn 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlPartitionSchemeReference> PartitionScheme 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISql90TSqlFileTableReference : ISql90TSqlFileTable
	{
    }
	public interface ISql90TSqlFileTable : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		Boolean TableLockOnBulkLoad 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlColumn> Columns 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlFilegroupReference> Filegroup 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlColumnReference> PartitionColumn 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlPartitionSchemeReference> PartitionScheme 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISql90TSqlTableTypeReference : ISql90TSqlTableType
	{
    }
	public interface ISql90TSqlTableType : ISqlModelElement
	{		
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISql90TSqlTableTypeCheckConstraintReference : ISql90TSqlTableTypeCheckConstraint
	{
    }
	public interface ISql90TSqlTableTypeCheckConstraint : ISqlModelElement
	{		
	}
    public interface ISql90TSqlTableTypeColumnReference : ISql90TSqlTableTypeColumn
	{
    }
	public interface ISql90TSqlTableTypeColumn : ISqlModelElement
	{		
		Boolean IsMax 
		{
			get;
		}
		Int32 Length 
		{
			get;
		}
		Int32 Precision 
		{
			get;
		}
		Int32 Scale 
		{
			get;
		}
		XmlStyle XmlStyle 
		{
			get;
		}
	}
    public interface ISql90TSqlTableTypeDefaultConstraintReference : ISql90TSqlTableTypeDefaultConstraint
	{
    }
	public interface ISql90TSqlTableTypeDefaultConstraint : ISqlModelElement
	{		
	}
    public interface ISql90TSqlTableTypeIndexReference : ISql90TSqlTableTypeIndex
	{
    }
	public interface ISql90TSqlTableTypeIndex : ISqlModelElement
	{		
		Int32? BucketCount 
		{
			get;
		}
		Boolean Hash 
		{
			get;
		}
		Boolean IsDisabled 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlColumnReference> Columns 
		{
			get;
		}
	}
    public interface ISql90TSqlTableTypePrimaryKeyConstraintReference : ISql90TSqlTableTypePrimaryKeyConstraint
	{
    }
	public interface ISql90TSqlTableTypePrimaryKeyConstraint : ISqlModelElement
	{		
		Int32? BucketCount 
		{
			get;
		}
		Boolean Hash 
		{
			get;
		}
	}
    public interface ISql90TSqlTableTypeUniqueConstraintReference : ISql90TSqlTableTypeUniqueConstraint
	{
    }
	public interface ISql90TSqlTableTypeUniqueConstraint : ISqlModelElement
	{		
		Int32? BucketCount 
		{
			get;
		}
		Boolean Hash 
		{
			get;
		}
	}
    public interface ISql90TSqlTcpProtocolSpecifierReference : ISql90TSqlTcpProtocolSpecifier
	{
    }
	public interface ISql90TSqlTcpProtocolSpecifier : ISqlModelElement
	{		
		String ListenerIPv4 
		{
			get;
		}
		String ListenerIPv6 
		{
			get;
		}
		Int32 ListenerPort 
		{
			get;
		}
		Boolean ListeningOnAllIPs 
		{
			get;
		}
	}
    public interface ISql90TSqlUniqueConstraintReference : ISql90TSqlUniqueConstraint
	{
    }
	public interface ISql90TSqlUniqueConstraint : ISqlModelElement
	{		
		Boolean AllowPageLocks 
		{
			get;
		}
		Boolean AllowRowLocks 
		{
			get;
		}
		Int32? BucketCount 
		{
			get;
		}
		Boolean Clustered 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Int32? FillFactor 
		{
			get;
		}
		Boolean Hash 
		{
			get;
		}
		Boolean IgnoreDuplicateKey 
		{
			get;
		}
		Boolean RecomputeStatistics 
		{
			get;
		}
		Boolean WithPadIndex 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlColumnReference> Columns 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlFilegroupReference> Filegroup 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlTableReference> Host 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlColumnReference> PartitionColumn 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlPartitionSchemeReference> PartitionScheme 
		{
			get;
		}
	}
    public interface ISql90TSqlUserReference : ISql90TSqlUser
	{
    }
	public interface ISql90TSqlUser : ISqlModelElement
	{		
		Boolean WithoutLogin 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlAsymmetricKeyReference> AsymmetricKey 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlCertificateReference> Certificate 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlSchemaReference> DefaultSchema 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlLoginReference> Login 
		{
			get;
		}
	}
    public interface ISql90TSqlUserDefinedServerRoleReference : ISql90TSqlUserDefinedServerRole
	{
    }
	public interface ISql90TSqlUserDefinedServerRole : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
	}
    public interface ISql90TSqlUserDefinedTypeReference : ISql90TSqlUserDefinedType
	{
    }
	public interface ISql90TSqlUserDefinedType : ISqlModelElement
	{		
		Boolean? ByteOrdered 
		{
			get;
		}
		String ClassName 
		{
			get;
		}
		Boolean? FixedLength 
		{
			get;
		}
		Format Format 
		{
			get;
		}
		Int32? MaxByteSize 
		{
			get;
		}
		String ValidationMethodName 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlAssemblyReference> Assembly 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.TSqlModelElement> Methods 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.TSqlModelElement> Properties 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISql90TSqlViewReference : ISql90TSqlView
	{
    }
	public interface ISql90TSqlView : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		Boolean Replicated 
		{
			get;
		}
		String SelectStatement 
		{
			get;
		}
		Boolean WithCheckOption 
		{
			get;
		}
		Boolean WithEncryption 
		{
			get;
		}
		Boolean WithSchemaBinding 
		{
			get;
		}
		Boolean WithViewMetadata 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BodyDependencies 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlColumn> Columns 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISql90TSqlWorkloadGroupReference : ISql90TSqlWorkloadGroup
	{
    }
	public interface ISql90TSqlWorkloadGroup : ISqlModelElement
	{		
	}
    public interface ISql90TSqlXmlIndexReference : ISql90TSqlXmlIndex
	{
    }
	public interface ISql90TSqlXmlIndex : ISqlModelElement
	{		
		Boolean AllowPageLocks 
		{
			get;
		}
		Boolean AllowRowLocks 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Int32? FillFactor 
		{
			get;
		}
		Boolean IsPrimary 
		{
			get;
		}
		Boolean RecomputeStatistics 
		{
			get;
		}
		SecondaryXmlIndexType SecondaryXmlIndexType 
		{
			get;
		}
		Boolean WithPadIndex 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlColumnReference> Column 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISpecifiesIndex> IndexedObject 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlXmlIndexReference> PrimaryXmlIndex 
		{
			get;
		}
	}
    public interface ISql90TSqlSelectiveXmlIndexReference : ISql90TSqlSelectiveXmlIndex
	{
    }
	public interface ISql90TSqlSelectiveXmlIndex : ISqlModelElement
	{		
		Boolean Disabled 
		{
			get;
		}
	}
    public interface ISql90TSqlXmlNamespaceReference : ISql90TSqlXmlNamespace
	{
    }
	public interface ISql90TSqlXmlNamespace : ISqlModelElement
	{		
	}
    public interface ISql90TSqlPromotedNodePathForXQueryTypeReference : ISql90TSqlPromotedNodePathForXQueryType
	{
    }
	public interface ISql90TSqlPromotedNodePathForXQueryType : ISqlModelElement
	{		
	}
    public interface ISql90TSqlPromotedNodePathForSqlTypeReference : ISql90TSqlPromotedNodePathForSqlType
	{
    }
	public interface ISql90TSqlPromotedNodePathForSqlType : ISqlModelElement
	{		
		Boolean IsMax 
		{
			get;
		}
		Int32 Length 
		{
			get;
		}
		Int32 Precision 
		{
			get;
		}
		Int32 Scale 
		{
			get;
		}
	}
    public interface ISql90TSqlXmlSchemaCollectionReference : ISql90TSqlXmlSchemaCollection
	{
    }
	public interface ISql90TSqlXmlSchemaCollection : ISqlModelElement
	{		
		String Expression 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql90TSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISql100TSqlColumnReference : ISql100TSqlColumn
	{
    }
	public interface ISql100TSqlColumn : ISqlModelElement
	{		
		String Collation 
		{
			get;
		}
		String Expression 
		{
			get;
		}
		String IdentityIncrement 
		{
			get;
		}
		String IdentitySeed 
		{
			get;
		}
		Boolean IsFileStream 
		{
			get;
		}
		Boolean IsIdentity 
		{
			get;
		}
		Boolean IsIdentityNotForReplication 
		{
			get;
		}
		Boolean IsMax 
		{
			get;
		}
		Boolean IsRowGuidCol 
		{
			get;
		}
		Int32 Length 
		{
			get;
		}
		Boolean Nullable 
		{
			get;
		}
		Boolean Persisted 
		{
			get;
		}
		Boolean? PersistedNullable 
		{
			get;
		}
		Int32 Precision 
		{
			get;
		}
		Int32 Scale 
		{
			get;
		}
		Boolean Sparse 
		{
			get;
		}
		XmlStyle XmlStyle 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlDataType> DataType 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ExpressionDependencies 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlXmlSchemaCollectionReference> XmlSchemaCollection 
		{
			get;
		}
	}
    public interface ISql100TSqlTableValuedFunctionReference : ISql100TSqlTableValuedFunction
	{
    }
	public interface ISql100TSqlTableValuedFunction : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		Boolean CalledOnNullInput 
		{
			get;
		}
		String ClassName 
		{
			get;
		}
		DataAccessKind? DataAccess 
		{
			get;
		}
		Boolean? Deterministic 
		{
			get;
		}
		Boolean ExecuteAsCaller 
		{
			get;
		}
		Boolean ExecuteAsOwner 
		{
			get;
		}
		Boolean ExecuteAsSelf 
		{
			get;
		}
		String FillRowMethodName 
		{
			get;
		}
		Boolean IsNativeCompiled 
		{
			get;
		}
		Boolean IsReplicated 
		{
			get;
		}
		String MethodName 
		{
			get;
		}
		Boolean? Precise 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		Boolean ReturnsNullOnNullInput 
		{
			get;
		}
		String ReturnTableVariableName 
		{
			get;
		}
		SystemDataAccessKind? SystemDataAccess 
		{
			get;
		}
		Boolean WithEncryption 
		{
			get;
		}
		Boolean WithSchemaBinding 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlAssembly> Assembly 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BodyDependencies 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlColumn> Columns 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlLoginReference> Login 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlParameter> Parameters 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlDataTypeReference> ReturnType 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlSchemaReference> Schema 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlClrTableOption> TableOption 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlUserReference> User 
		{
			get;
		}
	}
    public interface ISql100TSqlScalarFunctionReference : ISql100TSqlScalarFunction
	{
    }
	public interface ISql100TSqlScalarFunction : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		Boolean CalledOnNullInput 
		{
			get;
		}
		String ClassName 
		{
			get;
		}
		DataAccessKind? DataAccess 
		{
			get;
		}
		Boolean? Deterministic 
		{
			get;
		}
		Boolean ExecuteAsCaller 
		{
			get;
		}
		Boolean ExecuteAsOwner 
		{
			get;
		}
		Boolean ExecuteAsSelf 
		{
			get;
		}
		String FillRowMethodName 
		{
			get;
		}
		Boolean IsNativeCompiled 
		{
			get;
		}
		Boolean IsReplicated 
		{
			get;
		}
		String MethodName 
		{
			get;
		}
		Boolean? Precise 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		Boolean ReturnsNullOnNullInput 
		{
			get;
		}
		SystemDataAccessKind? SystemDataAccess 
		{
			get;
		}
		Boolean WithEncryption 
		{
			get;
		}
		Boolean WithSchemaBinding 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlAssembly> Assembly 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BodyDependencies 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlLoginReference> Login 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlParameter> Parameters 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlDataTypeReference> ReturnType 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlSchemaReference> Schema 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlUserReference> User 
		{
			get;
		}
	}
    public interface ISql100TSqlClrTableOptionReference : ISql100TSqlClrTableOption
	{
    }
	public interface ISql100TSqlClrTableOption : ISqlModelElement
	{		
		String ClassName 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlColumnReference> OrderColumns 
		{
			get;
		}
	}
    public interface ISql100TSqlAggregateReference : ISql100TSqlAggregate
	{
    }
	public interface ISql100TSqlAggregate : ISqlModelElement
	{		
		String ClassName 
		{
			get;
		}
		Format Format 
		{
			get;
		}
		Boolean? InvariantToDuplicates 
		{
			get;
		}
		Boolean? InvariantToNulls 
		{
			get;
		}
		Int32? MaxByteSize 
		{
			get;
		}
		Boolean? NullIfEmpty 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlAssemblyReference> Assembly 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlParameter> Parameters 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlDataTypeReference> ReturnType 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISql100TSqlApplicationRoleReference : ISql100TSqlApplicationRole
	{
    }
	public interface ISql100TSqlApplicationRole : ISqlModelElement
	{		
		String Password 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlSchemaReference> DefaultSchema 
		{
			get;
		}
	}
    public interface ISql100TSqlIndexReference : ISql100TSqlIndex
	{
    }
	public interface ISql100TSqlIndex : ISqlModelElement
	{		
		Boolean AllowPageLocks 
		{
			get;
		}
		Boolean AllowRowLocks 
		{
			get;
		}
		Int32? BucketCount 
		{
			get;
		}
		Boolean Clustered 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Boolean? FileStreamNull 
		{
			get;
		}
		Int32? FillFactor 
		{
			get;
		}
		String FilterPredicate 
		{
			get;
		}
		Boolean Hash 
		{
			get;
		}
		Boolean IgnoreDuplicateKey 
		{
			get;
		}
		Boolean RecomputeStatistics 
		{
			get;
		}
		Boolean Unique 
		{
			get;
		}
		Boolean WithPadIndex 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BodyDependencies 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlColumnReference> Columns 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlDataCompressionOption> DataCompressionOptions 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlFilegroupReference> Filegroup 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlFilegroupReference> FileStreamFilegroup 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlPartitionSchemeReference> FileStreamPartitionScheme 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlColumnReference> IncludedColumns 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISpecifiesIndex> IndexedObject 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlColumnReference> PartitionColumn 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlPartitionSchemeReference> PartitionScheme 
		{
			get;
		}
	}
    public interface ISql100TSqlAssemblyReference : ISql100TSqlAssembly
	{
    }
	public interface ISql100TSqlAssembly : ISqlModelElement
	{		
		AssemblyPermissionSet PermissionSet 
		{
			get;
		}
		Boolean Visible 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlAssemblySource> AssemblySources 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlAssemblyReference> ReferencedAssemblies 
		{
			get;
		}
	}
    public interface ISql100TSqlAssemblySourceReference : ISql100TSqlAssemblySource
	{
    }
	public interface ISql100TSqlAssemblySource : ISqlModelElement
	{		
		String Source 
		{
			get;
		}
	}
    public interface ISql100TSqlAsymmetricKeyReference : ISql100TSqlAsymmetricKey
	{
    }
	public interface ISql100TSqlAsymmetricKey : ISqlModelElement
	{		
		AsymmetricKeyAlgorithm Algorithm 
		{
			get;
		}
		SymmetricKeyCreationDisposition CreationDisposition 
		{
			get;
		}
		Boolean EncryptedWithPassword 
		{
			get;
		}
		String ExecutableFile 
		{
			get;
		}
		String File 
		{
			get;
		}
		String Password 
		{
			get;
		}
		String ProviderKeyName 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlAssemblyReference> Assembly 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> Provider 
		{
			get;
		}
	}
    public interface ISql100TSqlAuditActionReference : ISql100TSqlAuditAction
	{
    }
	public interface ISql100TSqlAuditAction : ISqlModelElement
	{		
		DatabaseAuditAction Action 
		{
			get;
		}
	}
    public interface ISql100TSqlAuditActionGroupReference : ISql100TSqlAuditActionGroup
	{
    }
	public interface ISql100TSqlAuditActionGroup : ISqlModelElement
	{		
		AuditActionGroupType ActionGroup 
		{
			get;
		}
	}
    public interface ISql100TSqlAuditActionSpecificationReference : ISql100TSqlAuditActionSpecification
	{
    }
	public interface ISql100TSqlAuditActionSpecification : ISqlModelElement
	{		
		Boolean AuditsDatabase 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlAuditAction> AuditActions 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlDatabaseSecurityPrincipal> Principals 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlSecurable> SecuredObject 
		{
			get;
		}
	}
    public interface ISql100TSqlBrokerPriorityReference : ISql100TSqlBrokerPriority
	{
    }
	public interface ISql100TSqlBrokerPriority : ISqlModelElement
	{		
		Int32 PriorityLevel 
		{
			get;
		}
		String RemoteServiceName 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ContractName 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> LocalServiceName 
		{
			get;
		}
	}
    public interface ISql100TSqlBuiltInServerRoleReference : ISql100TSqlBuiltInServerRole
	{
    }
	public interface ISql100TSqlBuiltInServerRole : ISqlModelElement
	{		
	}
    public interface ISql100TSqlDataTypeReference : ISql100TSqlDataType
	{
    }
	public interface ISql100TSqlDataType : ISqlModelElement
	{		
		SqlDataType SqlDataType 
		{
			get;
		}
		Boolean UddtIsMax 
		{
			get;
		}
		Int32 UddtLength 
		{
			get;
		}
		Boolean UddtNullable 
		{
			get;
		}
		Int32 UddtPrecision 
		{
			get;
		}
		Int32 UddtScale 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlSchemaReference> Schema 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlDataTypeReference> Type 
		{
			get;
		}
	}
    public interface ISql100TSqlCertificateReference : ISql100TSqlCertificate
	{
    }
	public interface ISql100TSqlCertificate : ISqlModelElement
	{		
		Boolean ActiveForBeginDialog 
		{
			get;
		}
		Boolean EncryptedWithPassword 
		{
			get;
		}
		String EncryptionPassword 
		{
			get;
		}
		String ExistingKeysFilePath 
		{
			get;
		}
		String ExpiryDate 
		{
			get;
		}
		Boolean IsExistingKeyFileExecutable 
		{
			get;
		}
		String PrivateKeyDecryptionPassword 
		{
			get;
		}
		String PrivateKeyEncryptionPassword 
		{
			get;
		}
		String PrivateKeyFilePath 
		{
			get;
		}
		String StartDate 
		{
			get;
		}
		String Subject 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlAssemblyReference> ExistingKeysAssembly 
		{
			get;
		}
	}
    public interface ISql100TSqlCheckConstraintReference : ISql100TSqlCheckConstraint
	{
    }
	public interface ISql100TSqlCheckConstraint : ISqlModelElement
	{		
		Boolean Disabled 
		{
			get;
		}
		String Expression 
		{
			get;
		}
		Boolean NotForReplication 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ExpressionDependencies 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlTableReference> Host 
		{
			get;
		}
	}
    public interface ISql100TSqlClrTypeMethodReference : ISql100TSqlClrTypeMethod
	{
    }
	public interface ISql100TSqlClrTypeMethod : ISqlModelElement
	{		
		String MethodName 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlParameter> Parameters 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlDataType> ReturnType 
		{
			get;
		}
	}
    public interface ISql100TSqlClrTypeMethodParameterReference : ISql100TSqlClrTypeMethodParameter
	{
    }
	public interface ISql100TSqlClrTypeMethodParameter : ISqlModelElement
	{		
		Boolean IsOutput 
		{
			get;
		}
		String ParameterName 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlDataType> DataType 
		{
			get;
		}
	}
    public interface ISql100TSqlClrTypePropertyReference : ISql100TSqlClrTypeProperty
	{
    }
	public interface ISql100TSqlClrTypeProperty : ISqlModelElement
	{		
		String PropertyName 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlDataTypeReference> ClrType 
		{
			get;
		}
	}
    public interface ISql100TSqlColumnStoreIndexReference : ISql100TSqlColumnStoreIndex
	{
    }
	public interface ISql100TSqlColumnStoreIndex : ISqlModelElement
	{		
		Boolean Clustered 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlDataCompressionOption> DataCompressionOptions 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlFilegroupReference> Filegroup 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISpecifiesIndex> IndexedObject 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlColumnReference> PartitionColumn 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlPartitionSchemeReference> PartitionScheme 
		{
			get;
		}
	}
    public interface ISql100TSqlContractReference : ISql100TSqlContract
	{
    }
	public interface ISql100TSqlContract : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlMessageTypeReference> Messages 
		{
			get;
		}
	}
    public interface ISql100TSqlCredentialReference : ISql100TSqlCredential
	{
    }
	public interface ISql100TSqlCredential : ISqlModelElement
	{		
		String Identity 
		{
			get;
		}
		String Secret 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlCryptographicProviderReference> CryptographicProvider 
		{
			get;
		}
	}
    public interface ISql100TSqlDatabaseCredentialReference : ISql100TSqlDatabaseCredential
	{
    }
	public interface ISql100TSqlDatabaseCredential : ISqlModelElement
	{		
	}
    public interface ISql100TSqlCryptographicProviderReference : ISql100TSqlCryptographicProvider
	{
    }
	public interface ISql100TSqlCryptographicProvider : ISqlModelElement
	{		
		String DllPath 
		{
			get;
		}
		Boolean Enabled 
		{
			get;
		}
	}
    public interface ISql100TSqlDatabaseAuditSpecificationReference : ISql100TSqlDatabaseAuditSpecification
	{
    }
	public interface ISql100TSqlDatabaseAuditSpecification : ISqlModelElement
	{		
		Boolean WithState 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlAuditActionGroup> AuditActionGroups 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlAuditAction> AuditActions 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlServerAuditReference> ServerAudit 
		{
			get;
		}
	}
    public interface ISql100TSqlDatabaseDdlTriggerReference : ISql100TSqlDatabaseDdlTrigger
	{
    }
	public interface ISql100TSqlDatabaseDdlTrigger : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		String ClassName 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Boolean ExecuteAsCaller 
		{
			get;
		}
		Boolean ExecuteAsOwner 
		{
			get;
		}
		Boolean ExecuteAsSelf 
		{
			get;
		}
		String MethodName 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		TriggerType TriggerType 
		{
			get;
		}
		Boolean WithEncryption 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlAssemblyReference> Assembly 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BodyDependencies 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlEventGroup> EventGroup 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Model.EventType> EventType 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlLoginReference> Login 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlUserReference> User 
		{
			get;
		}
	}
    public interface ISql100TSqlDatabaseEncryptionKeyReference : ISql100TSqlDatabaseEncryptionKey
	{
    }
	public interface ISql100TSqlDatabaseEncryptionKey : ISqlModelElement
	{		
		SymmetricKeyAlgorithm Algorithm 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlAsymmetricKeyReference> AsymmetricKey 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlCertificateReference> Certificate 
		{
			get;
		}
	}
    public interface ISql100TSqlDatabaseEventNotificationReference : ISql100TSqlDatabaseEventNotification
	{
    }
	public interface ISql100TSqlDatabaseEventNotification : ISqlModelElement
	{		
		String BrokerInstanceSpecifier 
		{
			get;
		}
		String BrokerService 
		{
			get;
		}
		Boolean WithFanIn 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlEventGroup> EventGroup 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Model.EventType> EventType 
		{
			get;
		}
	}
    public interface ISql100TSqlDatabaseMirroringLanguageSpecifierReference : ISql100TSqlDatabaseMirroringLanguageSpecifier
	{
    }
	public interface ISql100TSqlDatabaseMirroringLanguageSpecifier : ISqlModelElement
	{		
		ServiceBrokerEncryptionAlgorithm EncryptionAlgorithmPart1 
		{
			get;
		}
		ServiceBrokerEncryptionAlgorithm EncryptionAlgorithmPart2 
		{
			get;
		}
		EncryptionMode EncryptionMode 
		{
			get;
		}
		DatabaseMirroringRole RoleType 
		{
			get;
		}
		Boolean UseCertificateFirst 
		{
			get;
		}
		AuthenticationModes WindowsAuthenticationMode 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlCertificateReference> AuthenticationCertificate 
		{
			get;
		}
	}
    public interface ISql100TSqlDatabaseOptionsReference : ISql100TSqlDatabaseOptions
	{
    }
	public interface ISql100TSqlDatabaseOptions : ISqlModelElement
	{		
		Boolean AllowSnapshotIsolation 
		{
			get;
		}
		Boolean AnsiNullDefaultOn 
		{
			get;
		}
		Boolean AnsiNullsOn 
		{
			get;
		}
		Boolean AnsiPaddingOn 
		{
			get;
		}
		Boolean AnsiWarningsOn 
		{
			get;
		}
		Boolean ArithAbortOn 
		{
			get;
		}
		Boolean AutoClose 
		{
			get;
		}
		Boolean AutoCreateStatistics 
		{
			get;
		}
		Boolean AutoShrink 
		{
			get;
		}
		Boolean AutoUpdateStatistics 
		{
			get;
		}
		Boolean AutoUpdateStatisticsAsync 
		{
			get;
		}
		Boolean ChangeTrackingAutoCleanup 
		{
			get;
		}
		Boolean ChangeTrackingEnabled 
		{
			get;
		}
		Int32 ChangeTrackingRetentionPeriod 
		{
			get;
		}
		TimeUnit ChangeTrackingRetentionUnit 
		{
			get;
		}
		String Collation 
		{
			get;
		}
		Int32 CompatibilityLevel 
		{
			get;
		}
		Boolean ConcatNullYieldsNull 
		{
			get;
		}
		Boolean CursorCloseOnCommit 
		{
			get;
		}
		Boolean CursorDefaultGlobalScope 
		{
			get;
		}
		Boolean DatabaseStateOffline 
		{
			get;
		}
		Boolean DateCorrelationOptimizationOn 
		{
			get;
		}
		Boolean DBChainingOn 
		{
			get;
		}
		Boolean FullTextEnabled 
		{
			get;
		}
		Boolean HonorBrokerPriority 
		{
			get;
		}
		Boolean MemoryOptimizedElevateToSnapshot 
		{
			get;
		}
		Boolean NumericRoundAbortOn 
		{
			get;
		}
		PageVerifyMode PageVerifyMode 
		{
			get;
		}
		ParameterizationOption ParameterizationOption 
		{
			get;
		}
		Boolean QuotedIdentifierOn 
		{
			get;
		}
		Boolean ReadOnly 
		{
			get;
		}
		RecoveryMode RecoveryMode 
		{
			get;
		}
		Boolean RecursiveTriggersOn 
		{
			get;
		}
		ServiceBrokerOption ServiceBrokerOption 
		{
			get;
		}
		Boolean SupplementalLoggingOn 
		{
			get;
		}
		Boolean TornPageProtectionOn 
		{
			get;
		}
		Boolean TransactionIsolationReadCommittedSnapshot 
		{
			get;
		}
		Boolean Trustworthy 
		{
			get;
		}
		UserAccessOption UserAccessOption 
		{
			get;
		}
		Boolean VardecimalStorageFormatOn 
		{
			get;
		}
		Boolean WithEncryption 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlFilegroupReference> DefaultFilegroup 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlFilegroupReference> DefaultFileStreamFilegroup 
		{
			get;
		}
	}
    public interface ISql100TSqlDataCompressionOptionReference : ISql100TSqlDataCompressionOption
	{
    }
	public interface ISql100TSqlDataCompressionOption : ISqlModelElement
	{		
		CompressionLevel CompressionLevel 
		{
			get;
		}
		Int32 PartitionNumber 
		{
			get;
		}
	}
    public interface ISql100TSqlDefaultReference : ISql100TSqlDefault
	{
    }
	public interface ISql100TSqlDefault : ISqlModelElement
	{		
		String Expression 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BoundObjects 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISql100TSqlDefaultConstraintReference : ISql100TSqlDefaultConstraint
	{
    }
	public interface ISql100TSqlDefaultConstraint : ISqlModelElement
	{		
		Boolean Disabled 
		{
			get;
		}
		String Expression 
		{
			get;
		}
		Boolean WithValues 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ExpressionDependencies 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlTableReference> Host 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlColumnReference> TargetColumn 
		{
			get;
		}
	}
    public interface ISql100TSqlDmlTriggerReference : ISql100TSqlDmlTrigger
	{
    }
	public interface ISql100TSqlDmlTrigger : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		String ClassName 
		{
			get;
		}
		OrderRestriction DeleteOrderRestriction 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Boolean ExecuteAsCaller 
		{
			get;
		}
		Boolean ExecuteAsOwner 
		{
			get;
		}
		Boolean ExecuteAsSelf 
		{
			get;
		}
		OrderRestriction InsertOrderRestriction 
		{
			get;
		}
		Boolean IsDeleteTrigger 
		{
			get;
		}
		Boolean IsInsertTrigger 
		{
			get;
		}
		Boolean IsUpdateTrigger 
		{
			get;
		}
		String MethodName 
		{
			get;
		}
		Boolean NotForReplication 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		TriggerType TriggerType 
		{
			get;
		}
		OrderRestriction UpdateOrderRestriction 
		{
			get;
		}
		Boolean WithAppend 
		{
			get;
		}
		Boolean WithEncryption 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlAssemblyReference> Assembly 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BodyDependencies 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlLoginReference> Login 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> TriggerObject 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlUserReference> User 
		{
			get;
		}
	}
    public interface ISql100TSqlEndpointReference : ISql100TSqlEndpoint
	{
    }
	public interface ISql100TSqlEndpoint : ISqlModelElement
	{		
		Payload Payload 
		{
			get;
		}
		Protocol Protocol 
		{
			get;
		}
		State State 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.IEndpointLanguageSpecifier> PayloadSpecifier 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.IProtocolSpecifier > ProtocolSpecifier 
		{
			get;
		}
	}
    public interface ISql100TSqlErrorMessageReference : ISql100TSqlErrorMessage
	{
    }
	public interface ISql100TSqlErrorMessage : ISqlModelElement
	{		
		String Language 
		{
			get;
		}
		Int32 MessageNumber 
		{
			get;
		}
		String MessageText 
		{
			get;
		}
		Int32 Severity 
		{
			get;
		}
		Boolean WithLog 
		{
			get;
		}
	}
    public interface ISql100TSqlEventGroupReference : ISql100TSqlEventGroup
	{
    }
	public interface ISql100TSqlEventGroup : ISqlModelElement
	{		
		EventGroupType Group 
		{
			get;
		}
	}
    public interface ISql100TSqlEventSessionReference : ISql100TSqlEventSession
	{
    }
	public interface ISql100TSqlEventSession : ISqlModelElement
	{		
		EventRetentionMode EventRetentionMode 
		{
			get;
		}
		Int32 MaxDispatchLatency 
		{
			get;
		}
		Int32 MaxEventSize 
		{
			get;
		}
		MemoryUnit MaxEventSizeUnit 
		{
			get;
		}
		Int32 MaxMemory 
		{
			get;
		}
		MemoryUnit MaxMemoryUnit 
		{
			get;
		}
		MemoryPartitionMode MemoryPartitionMode 
		{
			get;
		}
		EventSessionScope SessionScope 
		{
			get;
		}
		Boolean StartupState 
		{
			get;
		}
		Boolean TrackCausality 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.TSqlModelElement> EventDefinitions 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.TSqlModelElement> EventTargets 
		{
			get;
		}
	}
    public interface ISql100TSqlDatabaseEventSessionReference : ISql100TSqlDatabaseEventSession
	{
    }
	public interface ISql100TSqlDatabaseEventSession : ISqlModelElement
	{		
		EventRetentionMode EventRetentionMode 
		{
			get;
		}
		Int32 MaxDispatchLatency 
		{
			get;
		}
		Int32 MaxEventSize 
		{
			get;
		}
		MemoryUnit MaxEventSizeUnit 
		{
			get;
		}
		Int32 MaxMemory 
		{
			get;
		}
		MemoryUnit MaxMemoryUnit 
		{
			get;
		}
		MemoryPartitionMode MemoryPartitionMode 
		{
			get;
		}
		EventSessionScope SessionScope 
		{
			get;
		}
		Boolean StartupState 
		{
			get;
		}
		Boolean TrackCausality 
		{
			get;
		}
		//Composing
		IEnumerable<TSqlModelElementReference> EventDefinitions 
		{
			get;
		}
		//Composing
		IEnumerable<TSqlModelElementReference> EventTargets 
		{
			get;
		}
	}
    public interface ISql100TSqlEventSessionActionReference : ISql100TSqlEventSessionAction
	{
    }
	public interface ISql100TSqlEventSessionAction : ISqlModelElement
	{		
		String ActionName 
		{
			get;
		}
		String EventModuleGuid 
		{
			get;
		}
		String EventPackageName 
		{
			get;
		}
	}
    public interface ISql100TSqlEventSessionDefinitionsReference : ISql100TSqlEventSessionDefinitions
	{
    }
	public interface ISql100TSqlEventSessionDefinitions : ISqlModelElement
	{		
		String EventModuleGuid 
		{
			get;
		}
		String EventName 
		{
			get;
		}
		String EventPackageName 
		{
			get;
		}
		String WhereExpression 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlEventSessionAction> Actions 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.TSqlModelElement> AttributeSettings 
		{
			get;
		}
	}
    public interface ISql100TSqlEventSessionSettingReference : ISql100TSqlEventSessionSetting
	{
    }
	public interface ISql100TSqlEventSessionSetting : ISqlModelElement
	{		
		String SettingName 
		{
			get;
		}
		String SettingValue 
		{
			get;
		}
	}
    public interface ISql100TSqlEventSessionTargetReference : ISql100TSqlEventSessionTarget
	{
    }
	public interface ISql100TSqlEventSessionTarget : ISqlModelElement
	{		
		String EventModuleGuid 
		{
			get;
		}
		String EventPackageName 
		{
			get;
		}
		String TargetName 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.TSqlModelElement> ParameterSettings 
		{
			get;
		}
	}
    public interface ISql100TSqlEventTypeSpecifierReference : ISql100TSqlEventTypeSpecifier
	{
    }
	public interface ISql100TSqlEventTypeSpecifier : ISqlModelElement
	{		
		EventType EventType 
		{
			get;
		}
		OrderRestriction Order 
		{
			get;
		}
	}
    public interface ISql100TSqlExtendedProcedureReference : ISql100TSqlExtendedProcedure
	{
    }
	public interface ISql100TSqlExtendedProcedure : ISqlModelElement
	{		
		Boolean ExeccuteAsCaller 
		{
			get;
		}
		Boolean ExecuteAsOwner 
		{
			get;
		}
		Boolean ExecuteAsSelf 
		{
			get;
		}
		Boolean WithEncryption 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlLoginReference> Login 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlParameter> Parameters 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlSchemaReference> Schema 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlUserReference> User 
		{
			get;
		}
	}
    public interface ISql100TSqlExtendedPropertyReference : ISql100TSqlExtendedProperty
	{
    }
	public interface ISql100TSqlExtendedProperty : ISqlModelElement
	{		
		String Value 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.IExtendedPropertyHost> Host 
		{
			get;
		}
	}
    public interface ISql100TSqlExternalDataSourceReference : ISql100TSqlExternalDataSource
	{
    }
	public interface ISql100TSqlExternalDataSource : ISqlModelElement
	{		
	}
    public interface ISql100TSqlExternalFileFormatReference : ISql100TSqlExternalFileFormat
	{
    }
	public interface ISql100TSqlExternalFileFormat : ISqlModelElement
	{		
	}
    public interface ISql100TSqlExternalTableReference : ISql100TSqlExternalTable
	{
    }
	public interface ISql100TSqlExternalTable : ISqlModelElement
	{		
		Boolean? IsAnsiNullsOn 
		{
			get;
		}
		Boolean? IsFileStreamNull 
		{
			get;
		}
		Boolean? IsQuotedIdentifierOn 
		{
			get;
		}
		Boolean IsTableLockOnBulkLoad 
		{
			get;
		}
		LockEscalationMethod LockEscalation 
		{
			get;
		}
		//Composing
		IEnumerable<TSqlModelElementReference> Columns 
		{
			get;
		}
		//Composing
		IEnumerable<TSqlModelElementReference> DataCompressionOptions 
		{
			get;
		}
		//Peer
		IEnumerable<TSqlModelElementReference> Filegroup 
		{
			get;
		}
		//Peer
		IEnumerable<TSqlModelElementReference> FileStreamFilegroup 
		{
			get;
		}
		//Peer
		IEnumerable<TSqlModelElementReference> FileStreamPartitionScheme 
		{
			get;
		}
		//Peer
		IEnumerable<TSqlModelElementReference> PartitionColumn 
		{
			get;
		}
		//Peer
		IEnumerable<TSqlModelElementReference> PartitionScheme 
		{
			get;
		}
		//Hierarchical
		IEnumerable<TSqlModelElementReference> Schema 
		{
			get;
		}
	}
    public interface ISql100TSqlSqlFileReference : ISql100TSqlSqlFile
	{
    }
	public interface ISql100TSqlSqlFile : ISqlModelElement
	{		
		Int32? FileGrowth 
		{
			get;
		}
		MemoryUnit FileGrowthUnit 
		{
			get;
		}
		String FileName 
		{
			get;
		}
		Boolean IsLogFile 
		{
			get;
		}
		Int32? MaxSize 
		{
			get;
		}
		MemoryUnit MaxSizeUnit 
		{
			get;
		}
		Boolean Offline 
		{
			get;
		}
		Int32? Size 
		{
			get;
		}
		MemoryUnit SizeUnit 
		{
			get;
		}
		Boolean Unlimited 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlFilegroupReference> Filegroup 
		{
			get;
		}
	}
    public interface ISql100TSqlFilegroupReference : ISql100TSqlFilegroup
	{
    }
	public interface ISql100TSqlFilegroup : ISqlModelElement
	{		
		Boolean ContainsFileStream 
		{
			get;
		}
		Boolean ReadOnly 
		{
			get;
		}
	}
    public interface ISql100TSqlForeignKeyConstraintReference : ISql100TSqlForeignKeyConstraint
	{
    }
	public interface ISql100TSqlForeignKeyConstraint : ISqlModelElement
	{		
		ForeignKeyAction DeleteAction 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Boolean NotForReplication 
		{
			get;
		}
		ForeignKeyAction UpdateAction 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlColumnReference> Columns 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlColumnReference> ForeignColumns 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlTableReference> ForeignTable 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlTableReference> Host 
		{
			get;
		}
	}
    public interface ISql100TSqlFullTextCatalogReference : ISql100TSqlFullTextCatalog
	{
    }
	public interface ISql100TSqlFullTextCatalog : ISqlModelElement
	{		
		Boolean? AccentSensitivity 
		{
			get;
		}
		Boolean IsDefault 
		{
			get;
		}
		String Path 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlFilegroupReference> Filegroup 
		{
			get;
		}
	}
    public interface ISql100TSqlFullTextIndexReference : ISql100TSqlFullTextIndex
	{
    }
	public interface ISql100TSqlFullTextIndex : ISqlModelElement
	{		
		ChangeTrackingOption ChangeTracking 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Boolean Replicated 
		{
			get;
		}
		Boolean StopListOff 
		{
			get;
		}
		Boolean UseSystemStopList 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.TSqlModelElementReference> Catalog 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlFullTextIndexColumnSpecifier> Columns 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlFilegroupReference> Filegroup 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISpecifiesIndex> IndexedObject 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> StopList 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> UniqueIndexName 
		{
			get;
		}
	}
    public interface ISql100TSqlFullTextIndexColumnSpecifierReference : ISql100TSqlFullTextIndexColumnSpecifier
	{
    }
	public interface ISql100TSqlFullTextIndexColumnSpecifier : ISqlModelElement
	{		
		Int32? LanguageId 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlColumnReference> Column 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlColumnReference> TypeColumn 
		{
			get;
		}
	}
    public interface ISql100TSqlFullTextStopListReference : ISql100TSqlFullTextStopList
	{
    }
	public interface ISql100TSqlFullTextStopList : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
	}
    public interface ISql100TSqlHttpProtocolSpecifierReference : ISql100TSqlHttpProtocolSpecifier
	{
    }
	public interface ISql100TSqlHttpProtocolSpecifier : ISqlModelElement
	{		
		AuthenticationModes AuthenticationMode 
		{
			get;
		}
		String AuthenticationRealm 
		{
			get;
		}
		Int32? ClearPort 
		{
			get;
		}
		Boolean CompressionEnabled 
		{
			get;
		}
		String DefaultLogonDomain 
		{
			get;
		}
		Boolean ListeningOnAllNoneReservedSites 
		{
			get;
		}
		Boolean ListeningOnAllSites 
		{
			get;
		}
		String Path 
		{
			get;
		}
		HttpPorts Ports 
		{
			get;
		}
		Int32? SslPort 
		{
			get;
		}
		String Website 
		{
			get;
		}
	}
    public interface ISql100TSqlLinkedServerReference : ISql100TSqlLinkedServer
	{
    }
	public interface ISql100TSqlLinkedServer : ISqlModelElement
	{		
		String Catalog 
		{
			get;
		}
		Boolean CollationCompatible 
		{
			get;
		}
		String CollationName 
		{
			get;
		}
		Int32 ConnectTimeout 
		{
			get;
		}
		Boolean DataAccess 
		{
			get;
		}
		String DataSource 
		{
			get;
		}
		Boolean IsDistributor 
		{
			get;
		}
		Boolean IsPublisher 
		{
			get;
		}
		Boolean IsSubscriber 
		{
			get;
		}
		Boolean LazySchemaValidationEnabled 
		{
			get;
		}
		String Location 
		{
			get;
		}
		String ProductName 
		{
			get;
		}
		String ProviderName 
		{
			get;
		}
		String ProviderString 
		{
			get;
		}
		Int32 QueryTimeout 
		{
			get;
		}
		Boolean RemoteProcTransactionPromotionEnabled 
		{
			get;
		}
		Boolean RpcEnabled 
		{
			get;
		}
		Boolean RpcOutEnabled 
		{
			get;
		}
		Boolean UseRemoteCollation 
		{
			get;
		}
	}
    public interface ISql100TSqlLinkedServerLoginReference : ISql100TSqlLinkedServerLogin
	{
    }
	public interface ISql100TSqlLinkedServerLogin : ISqlModelElement
	{		
		String LinkedServerLoginName 
		{
			get;
		}
		String LinkedServerPassword 
		{
			get;
		}
		Boolean UseSelf 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlLinkedServerReference> LinkedServer 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlLoginReference> LocalLogin 
		{
			get;
		}
	}
    public interface ISql100TSqlLoginReference : ISql100TSqlLogin
	{
    }
	public interface ISql100TSqlLogin : ISqlModelElement
	{		
		Boolean CheckExpiration 
		{
			get;
		}
		Boolean CheckPolicy 
		{
			get;
		}
		String DefaultDatabase 
		{
			get;
		}
		String DefaultLanguage 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		LoginEncryptionOption EncryptionOption 
		{
			get;
		}
		Boolean MappedToWindowsLogin 
		{
			get;
		}
		String Password 
		{
			get;
		}
		Boolean PasswordHashed 
		{
			get;
		}
		Boolean PasswordMustChange 
		{
			get;
		}
		String Sid 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlAsymmetricKeyReference> AsymmetricKey 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlCertificateReference> Certificate 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlCredentialReference> Credential 
		{
			get;
		}
	}
    public interface ISql100TSqlMasterKeyReference : ISql100TSqlMasterKey
	{
    }
	public interface ISql100TSqlMasterKey : ISqlModelElement
	{		
		String Password 
		{
			get;
		}
	}
    public interface ISql100TSqlMessageTypeReference : ISql100TSqlMessageType
	{
    }
	public interface ISql100TSqlMessageType : ISqlModelElement
	{		
		ValidationMethod ValidationMethod 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlXmlSchemaCollectionReference> XmlSchemaCollection 
		{
			get;
		}
	}
    public interface ISql100TSqlPartitionFunctionReference : ISql100TSqlPartitionFunction
	{
    }
	public interface ISql100TSqlPartitionFunction : ISqlModelElement
	{		
		PartitionRange Range 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlPartitionValue> BoundaryValues 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlDataTypeReference> ParameterType 
		{
			get;
		}
	}
    public interface ISql100TSqlPartitionSchemeReference : ISql100TSqlPartitionScheme
	{
    }
	public interface ISql100TSqlPartitionScheme : ISqlModelElement
	{		
		Boolean AllToOneFilegroup 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlFilegroupReference> Filegroups 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlPartitionFunctionReference> PartitionFunction 
		{
			get;
		}
	}
    public interface ISql100TSqlPartitionValueReference : ISql100TSqlPartitionValue
	{
    }
	public interface ISql100TSqlPartitionValue : ISqlModelElement
	{		
		String Expression 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ExpressionDependencies 
		{
			get;
		}
	}
    public interface ISql100TSqlPermissionReference : ISql100TSqlPermission
	{
    }
	public interface ISql100TSqlPermission : ISqlModelElement
	{		
		PermissionAction PermissionAction 
		{
			get;
		}
		PermissionType PermissionType 
		{
			get;
		}
		Boolean WithAllPrivileges 
		{
			get;
		}
		Boolean WithGrantOption 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlColumnReference> ExcludedColumns 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlSecurityPrincipal> Grantee 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlSecurityPrincipal> Grantor 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlColumnReference> RevokedGrantOptionColumns 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlSecurable> SecuredObject 
		{
			get;
		}
	}
    public interface ISql100TSqlPrimaryKeyConstraintReference : ISql100TSqlPrimaryKeyConstraint
	{
    }
	public interface ISql100TSqlPrimaryKeyConstraint : ISqlModelElement
	{		
		Boolean AllowPageLocks 
		{
			get;
		}
		Boolean AllowRowLocks 
		{
			get;
		}
		Int32? BucketCount 
		{
			get;
		}
		Boolean Clustered 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Boolean? FileStreamNull 
		{
			get;
		}
		Int32? FillFactor 
		{
			get;
		}
		Boolean Hash 
		{
			get;
		}
		Boolean IgnoreDuplicateKey 
		{
			get;
		}
		Boolean RecomputeStatistics 
		{
			get;
		}
		Boolean WithPadIndex 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlColumnReference> Columns 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlDataCompressionOption> DataCompressionOptions 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlFilegroupReference> Filegroup 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlFilegroupReference> FileStreamFilegroup 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlPartitionSchemeReference> FileStreamPartitionScheme 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlTableReference> Host 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlColumnReference> PartitionColumn 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlPartitionSchemeReference> PartitionScheme 
		{
			get;
		}
	}
    public interface ISql100TSqlProcedureReference : ISql100TSqlProcedure
	{
    }
	public interface ISql100TSqlProcedure : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		String ClassName 
		{
			get;
		}
		Boolean ExecuteAsCaller 
		{
			get;
		}
		Boolean ExecuteAsOwner 
		{
			get;
		}
		Boolean ExecuteAsSelf 
		{
			get;
		}
		Boolean ForReplication 
		{
			get;
		}
		Boolean IsReplicated 
		{
			get;
		}
		String MethodName 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		Boolean WithEncryption 
		{
			get;
		}
		Boolean WithRecompile 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlAssemblyReference> Assembly 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BodyDependencies 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlLoginReference> Login 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlParameter> Parameters 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlProcedureReference> ParentProcedure 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlSchemaReference> Schema 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlUserReference> User 
		{
			get;
		}
	}
    public interface ISql100TSqlQueueReference : ISql100TSqlQueue
	{
    }
	public interface ISql100TSqlQueue : ISqlModelElement
	{		
		Boolean ActivationExecuteAsCaller 
		{
			get;
		}
		Boolean ActivationExecuteAsOwner 
		{
			get;
		}
		Boolean ActivationExecuteAsSelf 
		{
			get;
		}
		Int32? ActivationMaxQueueReaders 
		{
			get;
		}
		Boolean? ActivationStatusOn 
		{
			get;
		}
		Boolean PoisonMessageHandlingStatusOn 
		{
			get;
		}
		Boolean RetentionOn 
		{
			get;
		}
		Boolean StatusOn 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlProcedureReference> ActivationProcedure 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlColumn> Columns 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlFilegroupReference> Filegroup 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlLoginReference> Login 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlColumnReference> PartitionColumn 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlPartitionSchemeReference> PartitionScheme 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlSchemaReference> Schema 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlUserReference> User 
		{
			get;
		}
	}
    public interface ISql100TSqlQueueEventNotificationReference : ISql100TSqlQueueEventNotification
	{
    }
	public interface ISql100TSqlQueueEventNotification : ISqlModelElement
	{		
		String BrokerInstanceSpecifier 
		{
			get;
		}
		String BrokerService 
		{
			get;
		}
		Boolean WithFanIn 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlEventGroup> EventGroup 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Model.EventType> EventType 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlQueueReference> Queue 
		{
			get;
		}
	}
    public interface ISql100TSqlRemoteServiceBindingReference : ISql100TSqlRemoteServiceBinding
	{
    }
	public interface ISql100TSqlRemoteServiceBinding : ISqlModelElement
	{		
		Boolean Anonymous 
		{
			get;
		}
		String Service 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlUserReference> User 
		{
			get;
		}
	}
    public interface ISql100TSqlResourceGovernorReference : ISql100TSqlResourceGovernor
	{
    }
	public interface ISql100TSqlResourceGovernor : ISqlModelElement
	{		
		Boolean? Enabled 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ClassifierFunction 
		{
			get;
		}
	}
    public interface ISql100TSqlResourcePoolReference : ISql100TSqlResourcePool
	{
    }
	public interface ISql100TSqlResourcePool : ISqlModelElement
	{		
		Int32 MaxCpuPercent 
		{
			get;
		}
		Int32 MaxMemoryPercent 
		{
			get;
		}
		Int32 MinCpuPercent 
		{
			get;
		}
		Int32 MinMemoryPercent 
		{
			get;
		}
	}
    public interface ISql100TSqlRoleReference : ISql100TSqlRole
	{
    }
	public interface ISql100TSqlRole : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
	}
    public interface ISql100TSqlRoleMembershipReference : ISql100TSqlRoleMembership
	{
    }
	public interface ISql100TSqlRoleMembership : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlDatabaseSecurityPrincipal> Member 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlRoleReference> Role 
		{
			get;
		}
	}
    public interface ISql100TSqlRouteReference : ISql100TSqlRoute
	{
    }
	public interface ISql100TSqlRoute : ISqlModelElement
	{		
		String Address 
		{
			get;
		}
		String BrokerInstance 
		{
			get;
		}
		Int32? Lifetime 
		{
			get;
		}
		String MirrorAddress 
		{
			get;
		}
		String ServiceName 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
	}
    public interface ISql100TSqlRuleReference : ISql100TSqlRule
	{
    }
	public interface ISql100TSqlRule : ISqlModelElement
	{		
		String Expression 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BoundObjects 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISql100TSqlSchemaReference : ISql100TSqlSchema
	{
    }
	public interface ISql100TSqlSchema : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
	}
    public interface ISql100TSqlSearchPropertyReference : ISql100TSqlSearchProperty
	{
    }
	public interface ISql100TSqlSearchProperty : ISqlModelElement
	{		
	}
    public interface ISql100TSqlSearchPropertyListReference : ISql100TSqlSearchPropertyList
	{
    }
	public interface ISql100TSqlSearchPropertyList : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
	}
    public interface ISql100TSqlSecurityPolicyReference : ISql100TSqlSecurityPolicy
	{
    }
	public interface ISql100TSqlSecurityPolicy : ISqlModelElement
	{		
		Boolean Enabled 
		{
			get;
		}
		Boolean IsSchemaBound 
		{
			get;
		}
		Boolean NotForReplication 
		{
			get;
		}
		//Composing
		IEnumerable<TSqlModelElementReference> Predicates 
		{
			get;
		}
		//Hierarchical
		IEnumerable<TSqlModelElementReference> Schema 
		{
			get;
		}
	}
    public interface ISql100TSqlSecurityPredicateReference : ISql100TSqlSecurityPredicate
	{
    }
	public interface ISql100TSqlSecurityPredicate : ISqlModelElement
	{		
		String BodyScript 
		{
			get;
		}
		SecurityPredicateOperation Operation 
		{
			get;
		}
		SecurityPredicateType PredicateType 
		{
			get;
		}
		//Peer
		IEnumerable<TSqlModelElementReference> BodyDependencies 
		{
			get;
		}
		//Peer
		IEnumerable<TSqlModelElementReference> TargetObject 
		{
			get;
		}
	}
    public interface ISql100TSqlSequenceReference : ISql100TSqlSequence
	{
    }
	public interface ISql100TSqlSequence : ISqlModelElement
	{		
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISql100TSqlServerAuditReference : ISql100TSqlServerAudit
	{
    }
	public interface ISql100TSqlServerAudit : ISqlModelElement
	{		
		String AuditGuid 
		{
			get;
		}
		AuditTarget AuditTarget 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		String FilePath 
		{
			get;
		}
		Int32? MaxRolloverFiles 
		{
			get;
		}
		Int32? MaxSize 
		{
			get;
		}
		MemoryUnit MaxSizeUnit 
		{
			get;
		}
		FailureAction OnFailure 
		{
			get;
		}
		Int32 QueueDelay 
		{
			get;
		}
		Boolean ReserveDiskSpace 
		{
			get;
		}
		Boolean UnlimitedFileSize 
		{
			get;
		}
		Boolean UnlimitedMaxRolloverFiles 
		{
			get;
		}
	}
    public interface ISql100TSqlServerAuditSpecificationReference : ISql100TSqlServerAuditSpecification
	{
    }
	public interface ISql100TSqlServerAuditSpecification : ISqlModelElement
	{		
		Boolean StateOn 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlAuditActionGroup> AuditActionGroups 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlServerAuditReference> ServerAudit 
		{
			get;
		}
	}
    public interface ISql100TSqlServerDdlTriggerReference : ISql100TSqlServerDdlTrigger
	{
    }
	public interface ISql100TSqlServerDdlTrigger : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		String ClassName 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Boolean ExecuteAsCaller 
		{
			get;
		}
		Boolean ExecuteAsOwner 
		{
			get;
		}
		Boolean ExecuteAsSelf 
		{
			get;
		}
		Boolean IsLogon 
		{
			get;
		}
		String MethodName 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		TriggerType TriggerType 
		{
			get;
		}
		Boolean WithEncryption 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlAssemblyReference> Assembly 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BodyDependencies 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlEventGroup> EventGroup 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Model.EventType> EventType 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlLoginReference> Login 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlUserReference> User 
		{
			get;
		}
	}
    public interface ISql100TSqlServerEventNotificationReference : ISql100TSqlServerEventNotification
	{
    }
	public interface ISql100TSqlServerEventNotification : ISqlModelElement
	{		
		String BrokerInstanceSpecifier 
		{
			get;
		}
		String BrokerService 
		{
			get;
		}
		Boolean WithFanIn 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlEventGroup> EventGroup 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Model.EventType> EventType 
		{
			get;
		}
	}
    public interface ISql100TSqlServerOptionsReference : ISql100TSqlServerOptions
	{
    }
	public interface ISql100TSqlServerOptions : ISqlModelElement
	{		
	}
    public interface ISql100TSqlServerRoleMembershipReference : ISql100TSqlServerRoleMembership
	{
    }
	public interface ISql100TSqlServerRoleMembership : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.IServerSecurityPrincipal> Member 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlRoleReference> Role 
		{
			get;
		}
	}
    public interface ISql100TSqlServiceReference : ISql100TSqlService
	{
    }
	public interface ISql100TSqlService : ISqlModelElement
	{		
		Boolean UseDefaultContract 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlContractReference> Contracts 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlQueueReference> Queue 
		{
			get;
		}
	}
    public interface ISql100TSqlServiceBrokerLanguageSpecifierReference : ISql100TSqlServiceBrokerLanguageSpecifier
	{
    }
	public interface ISql100TSqlServiceBrokerLanguageSpecifier : ISqlModelElement
	{		
		ServiceBrokerEncryptionAlgorithm EncryptionAlgorithmPart1 
		{
			get;
		}
		ServiceBrokerEncryptionAlgorithm EncryptionAlgorithmPart2 
		{
			get;
		}
		EncryptionMode EncryptionMode 
		{
			get;
		}
		Boolean MessageForwardingEnabled 
		{
			get;
		}
		Int32 MessageForwardSize 
		{
			get;
		}
		Boolean UseCertificateFirst 
		{
			get;
		}
		AuthenticationModes WindowsAuthenticationMode 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlCertificateReference> AuthenticationCertificate 
		{
			get;
		}
	}
    public interface ISql100TSqlSignatureReference : ISql100TSqlSignature
	{
    }
	public interface ISql100TSqlSignature : ISqlModelElement
	{		
		Boolean IsCounterSignature 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.TSqlModelElement> EncryptionMechanism 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> SignedObject 
		{
			get;
		}
	}
    public interface ISql100TSqlSignatureEncryptionMechanismReference : ISql100TSqlSignatureEncryptionMechanism
	{
    }
	public interface ISql100TSqlSignatureEncryptionMechanism : ISqlModelElement
	{		
		String Password 
		{
			get;
		}
		String SignedBlob 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlAsymmetricKeyReference> AsymmetricKey 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlCertificateReference> Certificate 
		{
			get;
		}
	}
    public interface ISql100TSqlSoapLanguageSpecifierReference : ISql100TSqlSoapLanguageSpecifier
	{
    }
	public interface ISql100TSqlSoapLanguageSpecifier : ISqlModelElement
	{		
		Boolean BatchesEnabled 
		{
			get;
		}
		CharacterSet CharacterSet 
		{
			get;
		}
		String DatabaseName 
		{
			get;
		}
		Int32 HeaderLimit 
		{
			get;
		}
		Boolean IsDefaultDatabase 
		{
			get;
		}
		Boolean IsDefaultNamespace 
		{
			get;
		}
		Boolean IsDefaultWsdlSpName 
		{
			get;
		}
		SoapLoginType LoginType 
		{
			get;
		}
		String Namespace 
		{
			get;
		}
		SoapSchema SchemaType 
		{
			get;
		}
		Boolean SessionsEnabled 
		{
			get;
		}
		Int32 SessionTimeout 
		{
			get;
		}
		Boolean SessionTimeoutNever 
		{
			get;
		}
		String WsdlSpName 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlSoapMethodSpecification> WebMethods 
		{
			get;
		}
	}
    public interface ISql100TSqlSoapMethodSpecificationReference : ISql100TSqlSoapMethodSpecification
	{
    }
	public interface ISql100TSqlSoapMethodSpecification : ISqlModelElement
	{		
		SoapFormat Format 
		{
			get;
		}
		SoapSchema SchemaType 
		{
			get;
		}
		String WebMethodAlias 
		{
			get;
		}
		String WebMethodNamespace 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> RelatedMethod 
		{
			get;
		}
	}
    public interface ISql100TSqlSpatialIndexReference : ISql100TSqlSpatialIndex
	{
    }
	public interface ISql100TSqlSpatialIndex : ISqlModelElement
	{		
		Boolean AllowPageLocks 
		{
			get;
		}
		Boolean AllowRowLocks 
		{
			get;
		}
		Int32? CellsPerObject 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Int32 FillFactor 
		{
			get;
		}
		Degree GridLevel1Density 
		{
			get;
		}
		Degree GridLevel2Density 
		{
			get;
		}
		Degree GridLevel3Density 
		{
			get;
		}
		Degree GridLevel4Density 
		{
			get;
		}
		Boolean IgnoreDuplicateKey 
		{
			get;
		}
		Boolean RecomputeStatistics 
		{
			get;
		}
		Tessellation Tessellation 
		{
			get;
		}
		Boolean WithPadIndex 
		{
			get;
		}
		Double? XMax 
		{
			get;
		}
		Double? XMin 
		{
			get;
		}
		Double? YMax 
		{
			get;
		}
		Double? YMin 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlColumnReference> Column 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlFilegroupReference> Filegroup 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISpecifiesIndex> IndexedObject 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlColumnReference> PartitionColumn 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlPartitionSchemeReference> PartitionScheme 
		{
			get;
		}
	}
    public interface ISql100TSqlStatisticsReference : ISql100TSqlStatistics
	{
    }
	public interface ISql100TSqlStatistics : ISqlModelElement
	{		
		String FilterPredicate 
		{
			get;
		}
		Boolean NoRecompute 
		{
			get;
		}
		Int32 SampleSize 
		{
			get;
		}
		SamplingStyle SamplingStyle 
		{
			get;
		}
		String StatsStream 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlColumnReference> Columns 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ExpressionDependencies 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> OnObject 
		{
			get;
		}
	}
    public interface ISql100TSqlParameterReference : ISql100TSqlParameter
	{
    }
	public interface ISql100TSqlParameter : ISqlModelElement
	{		
		String DefaultExpression 
		{
			get;
		}
		Boolean IsMax 
		{
			get;
		}
		Boolean IsOutput 
		{
			get;
		}
		Int32 Length 
		{
			get;
		}
		Int32 Precision 
		{
			get;
		}
		Boolean ReadOnly 
		{
			get;
		}
		Int32 Scale 
		{
			get;
		}
		Boolean Varying 
		{
			get;
		}
		XmlStyle XmlStyle 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlDataType> DataType 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlXmlSchemaCollectionReference> XmlSchemaCollection 
		{
			get;
		}
	}
    public interface ISql100TSqlSymmetricKeyReference : ISql100TSqlSymmetricKey
	{
    }
	public interface ISql100TSqlSymmetricKey : ISqlModelElement
	{		
		SymmetricKeyAlgorithm Algorithm 
		{
			get;
		}
		SymmetricKeyCreationDisposition CreationDisposition 
		{
			get;
		}
		String IdentityValue 
		{
			get;
		}
		String KeySource 
		{
			get;
		}
		String ProviderKeyName 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlAsymmetricKeyReference> AsymmetricKeys 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlCertificateReference> Certificates 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.TSqlModelElement> Passwords 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> Provider 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlSymmetricKeyReference> SymmetricKeys 
		{
			get;
		}
	}
    public interface ISql100TSqlSymmetricKeyPasswordReference : ISql100TSqlSymmetricKeyPassword
	{
    }
	public interface ISql100TSqlSymmetricKeyPassword : ISqlModelElement
	{		
		String Password 
		{
			get;
		}
	}
    public interface ISql100TSqlSynonymReference : ISql100TSqlSynonym
	{
    }
	public interface ISql100TSqlSynonym : ISqlModelElement
	{		
		String ForObjectName 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ForObject 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISql100TSqlTableReference : ISql100TSqlTable
	{
    }
	public interface ISql100TSqlTable : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		Boolean ChangeDataCaptureEnabled 
		{
			get;
		}
		Boolean ChangeTrackingEnabled 
		{
			get;
		}
		Int64? DataPages 
		{
			get;
		}
		Double? DataSize 
		{
			get;
		}
		Boolean? FileStreamNull 
		{
			get;
		}
		Double? IndexSize 
		{
			get;
		}
		Boolean IsAutoGeneratedHistoryTable 
		{
			get;
		}
		Boolean IsReplicated 
		{
			get;
		}
		Boolean LargeValueTypesOutOfRow 
		{
			get;
		}
		LockEscalationMethod LockEscalation 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		Int64? RowCount 
		{
			get;
		}
		Boolean TableLockOnBulkLoad 
		{
			get;
		}
		Int32 TextInRowSize 
		{
			get;
		}
		Boolean TrackColumnsUpdated 
		{
			get;
		}
		Int64? UsedPages 
		{
			get;
		}
		Boolean VardecimalStorageFormatEnabled 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlColumn> Columns 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlDataCompressionOption> DataCompressionOptions 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlFilegroupReference> Filegroup 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlFilegroupReference> FilegroupForTextImage 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlFilegroupReference> FileStreamFilegroup 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlPartitionSchemeReference> FileStreamPartitionScheme 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlColumnReference> PartitionColumn 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlPartitionSchemeReference> PartitionScheme 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISql100TSqlFileTableReference : ISql100TSqlFileTable
	{
    }
	public interface ISql100TSqlFileTable : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		Boolean? FileStreamNull 
		{
			get;
		}
		LockEscalationMethod LockEscalation 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		Boolean TableLockOnBulkLoad 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlColumn> Columns 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlDataCompressionOption> DataCompressionOptions 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlFilegroupReference> Filegroup 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlFilegroupReference> FileStreamFilegroup 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlPartitionSchemeReference> FileStreamPartitionScheme 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlColumnReference> PartitionColumn 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlPartitionSchemeReference> PartitionScheme 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISql100TSqlTableTypeReference : ISql100TSqlTableType
	{
    }
	public interface ISql100TSqlTableType : ISqlModelElement
	{		
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlTableTypeColumn> Columns 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ITableTypeConstraint> Constraints 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISql100TSqlTableTypeCheckConstraintReference : ISql100TSqlTableTypeCheckConstraint
	{
    }
	public interface ISql100TSqlTableTypeCheckConstraint : ISqlModelElement
	{		
		String Expression 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ExpressionDependencies 
		{
			get;
		}
	}
    public interface ISql100TSqlTableTypeColumnReference : ISql100TSqlTableTypeColumn
	{
    }
	public interface ISql100TSqlTableTypeColumn : ISqlModelElement
	{		
		String Collation 
		{
			get;
		}
		String Expression 
		{
			get;
		}
		String IdentityIncrement 
		{
			get;
		}
		String IdentitySeed 
		{
			get;
		}
		Boolean IsIdentity 
		{
			get;
		}
		Boolean IsMax 
		{
			get;
		}
		Boolean IsRowGuidCol 
		{
			get;
		}
		Int32 Length 
		{
			get;
		}
		Boolean Nullable 
		{
			get;
		}
		Boolean Persisted 
		{
			get;
		}
		Boolean? PersistedNullable 
		{
			get;
		}
		Int32 Precision 
		{
			get;
		}
		Int32 Scale 
		{
			get;
		}
		XmlStyle XmlStyle 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlDataType> DataType 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ExpressionDependencies 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlXmlSchemaCollectionReference> XmlSchemaCollection 
		{
			get;
		}
	}
    public interface ISql100TSqlTableTypeDefaultConstraintReference : ISql100TSqlTableTypeDefaultConstraint
	{
    }
	public interface ISql100TSqlTableTypeDefaultConstraint : ISqlModelElement
	{		
		String Expression 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ExpressionDependencies 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlColumnReference> TargetColumn 
		{
			get;
		}
	}
    public interface ISql100TSqlTableTypeIndexReference : ISql100TSqlTableTypeIndex
	{
    }
	public interface ISql100TSqlTableTypeIndex : ISqlModelElement
	{		
		Int32? BucketCount 
		{
			get;
		}
		Boolean Hash 
		{
			get;
		}
		Boolean IsDisabled 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlColumnReference> Columns 
		{
			get;
		}
	}
    public interface ISql100TSqlTableTypePrimaryKeyConstraintReference : ISql100TSqlTableTypePrimaryKeyConstraint
	{
    }
	public interface ISql100TSqlTableTypePrimaryKeyConstraint : ISqlModelElement
	{		
		Int32? BucketCount 
		{
			get;
		}
		Boolean Clustered 
		{
			get;
		}
		Boolean Hash 
		{
			get;
		}
		Boolean IgnoreDuplicateKey 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlColumnReference> Columns 
		{
			get;
		}
	}
    public interface ISql100TSqlTableTypeUniqueConstraintReference : ISql100TSqlTableTypeUniqueConstraint
	{
    }
	public interface ISql100TSqlTableTypeUniqueConstraint : ISqlModelElement
	{		
		Int32? BucketCount 
		{
			get;
		}
		Boolean Clustered 
		{
			get;
		}
		Boolean Hash 
		{
			get;
		}
		Boolean IgnoreDuplicateKey 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlColumnReference> Columns 
		{
			get;
		}
	}
    public interface ISql100TSqlTcpProtocolSpecifierReference : ISql100TSqlTcpProtocolSpecifier
	{
    }
	public interface ISql100TSqlTcpProtocolSpecifier : ISqlModelElement
	{		
		String ListenerIPv4 
		{
			get;
		}
		String ListenerIPv6 
		{
			get;
		}
		Int32 ListenerPort 
		{
			get;
		}
		Boolean ListeningOnAllIPs 
		{
			get;
		}
	}
    public interface ISql100TSqlUniqueConstraintReference : ISql100TSqlUniqueConstraint
	{
    }
	public interface ISql100TSqlUniqueConstraint : ISqlModelElement
	{		
		Boolean AllowPageLocks 
		{
			get;
		}
		Boolean AllowRowLocks 
		{
			get;
		}
		Int32? BucketCount 
		{
			get;
		}
		Boolean Clustered 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Boolean? FileStreamNull 
		{
			get;
		}
		Int32? FillFactor 
		{
			get;
		}
		Boolean Hash 
		{
			get;
		}
		Boolean IgnoreDuplicateKey 
		{
			get;
		}
		Boolean RecomputeStatistics 
		{
			get;
		}
		Boolean WithPadIndex 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlColumnReference> Columns 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlDataCompressionOption> DataCompressionOptions 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlFilegroupReference> Filegroup 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlFilegroupReference> FileStreamFilegroup 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlPartitionSchemeReference> FileStreamPartitionScheme 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlTableReference> Host 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlColumnReference> PartitionColumn 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlPartitionSchemeReference> PartitionScheme 
		{
			get;
		}
	}
    public interface ISql100TSqlUserReference : ISql100TSqlUser
	{
    }
	public interface ISql100TSqlUser : ISqlModelElement
	{		
		Boolean WithoutLogin 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlAsymmetricKeyReference> AsymmetricKey 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlCertificateReference> Certificate 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlSchemaReference> DefaultSchema 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlLoginReference> Login 
		{
			get;
		}
	}
    public interface ISql100TSqlUserDefinedServerRoleReference : ISql100TSqlUserDefinedServerRole
	{
    }
	public interface ISql100TSqlUserDefinedServerRole : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
	}
    public interface ISql100TSqlUserDefinedTypeReference : ISql100TSqlUserDefinedType
	{
    }
	public interface ISql100TSqlUserDefinedType : ISqlModelElement
	{		
		Boolean? ByteOrdered 
		{
			get;
		}
		String ClassName 
		{
			get;
		}
		Boolean? FixedLength 
		{
			get;
		}
		Format Format 
		{
			get;
		}
		Int32? MaxByteSize 
		{
			get;
		}
		String ValidationMethodName 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlAssemblyReference> Assembly 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.TSqlModelElement> Methods 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.TSqlModelElement> Properties 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISql100TSqlViewReference : ISql100TSqlView
	{
    }
	public interface ISql100TSqlView : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		Boolean Replicated 
		{
			get;
		}
		String SelectStatement 
		{
			get;
		}
		Boolean WithCheckOption 
		{
			get;
		}
		Boolean WithEncryption 
		{
			get;
		}
		Boolean WithSchemaBinding 
		{
			get;
		}
		Boolean WithViewMetadata 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BodyDependencies 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlColumn> Columns 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISql100TSqlWorkloadGroupReference : ISql100TSqlWorkloadGroup
	{
    }
	public interface ISql100TSqlWorkloadGroup : ISqlModelElement
	{		
		Int32 GroupMaxRequests 
		{
			get;
		}
		Degree Importance 
		{
			get;
		}
		Int32 MaxDop 
		{
			get;
		}
		Int32 RequestMaxCpuTimeSec 
		{
			get;
		}
		Int32 RequestMaxMemoryGrantPercent 
		{
			get;
		}
		Int32 RequestMemoryGrantTimeoutSec 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlResourcePoolReference> ResourcePool 
		{
			get;
		}
	}
    public interface ISql100TSqlXmlIndexReference : ISql100TSqlXmlIndex
	{
    }
	public interface ISql100TSqlXmlIndex : ISqlModelElement
	{		
		Boolean AllowPageLocks 
		{
			get;
		}
		Boolean AllowRowLocks 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Int32? FillFactor 
		{
			get;
		}
		Boolean IgnoreDuplicateKey 
		{
			get;
		}
		Boolean IsPrimary 
		{
			get;
		}
		Boolean RecomputeStatistics 
		{
			get;
		}
		SecondaryXmlIndexType SecondaryXmlIndexType 
		{
			get;
		}
		Boolean WithPadIndex 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlColumnReference> Column 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISpecifiesIndex> IndexedObject 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlXmlIndexReference> PrimaryXmlIndex 
		{
			get;
		}
	}
    public interface ISql100TSqlSelectiveXmlIndexReference : ISql100TSqlSelectiveXmlIndex
	{
    }
	public interface ISql100TSqlSelectiveXmlIndex : ISqlModelElement
	{		
		Boolean Disabled 
		{
			get;
		}
	}
    public interface ISql100TSqlXmlNamespaceReference : ISql100TSqlXmlNamespace
	{
    }
	public interface ISql100TSqlXmlNamespace : ISqlModelElement
	{		
	}
    public interface ISql100TSqlPromotedNodePathForXQueryTypeReference : ISql100TSqlPromotedNodePathForXQueryType
	{
    }
	public interface ISql100TSqlPromotedNodePathForXQueryType : ISqlModelElement
	{		
	}
    public interface ISql100TSqlPromotedNodePathForSqlTypeReference : ISql100TSqlPromotedNodePathForSqlType
	{
    }
	public interface ISql100TSqlPromotedNodePathForSqlType : ISqlModelElement
	{		
		Boolean IsMax 
		{
			get;
		}
		Int32 Length 
		{
			get;
		}
		Int32 Precision 
		{
			get;
		}
		Int32 Scale 
		{
			get;
		}
	}
    public interface ISql100TSqlXmlSchemaCollectionReference : ISql100TSqlXmlSchemaCollection
	{
    }
	public interface ISql100TSqlXmlSchemaCollection : ISqlModelElement
	{		
		String Expression 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql100TSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlColumnReference : ISqlAzureTSqlColumn
	{
    }
	public interface ISqlAzureTSqlColumn : ISqlModelElement
	{		
		String Collation 
		{
			get;
		}
		String Expression 
		{
			get;
		}
		String IdentityIncrement 
		{
			get;
		}
		String IdentitySeed 
		{
			get;
		}
		Boolean IsIdentity 
		{
			get;
		}
		Boolean IsMax 
		{
			get;
		}
		Int32 Length 
		{
			get;
		}
		Boolean Nullable 
		{
			get;
		}
		Boolean Persisted 
		{
			get;
		}
		Boolean? PersistedNullable 
		{
			get;
		}
		Int32 Precision 
		{
			get;
		}
		Int32 Scale 
		{
			get;
		}
		Boolean Sparse 
		{
			get;
		}
		XmlStyle XmlStyle 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlDataType> DataType 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ExpressionDependencies 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlXmlSchemaCollectionReference> XmlSchemaCollection 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlTableValuedFunctionReference : ISqlAzureTSqlTableValuedFunction
	{
    }
	public interface ISqlAzureTSqlTableValuedFunction : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		Boolean CalledOnNullInput 
		{
			get;
		}
		String ClassName 
		{
			get;
		}
		Boolean ExecuteAsCaller 
		{
			get;
		}
		Boolean ExecuteAsOwner 
		{
			get;
		}
		Boolean ExecuteAsSelf 
		{
			get;
		}
		Boolean IsNativeCompiled 
		{
			get;
		}
		String MethodName 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		Boolean ReturnsNullOnNullInput 
		{
			get;
		}
		String ReturnTableVariableName 
		{
			get;
		}
		Boolean WithSchemaBinding 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlAssembly> Assembly 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BodyDependencies 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlColumn> Columns 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlLoginReference> Login 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlParameter> Parameters 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlDataTypeReference> ReturnType 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlSchemaReference> Schema 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlClrTableOption> TableOption 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlUserReference> User 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlScalarFunctionReference : ISqlAzureTSqlScalarFunction
	{
    }
	public interface ISqlAzureTSqlScalarFunction : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		Boolean CalledOnNullInput 
		{
			get;
		}
		String ClassName 
		{
			get;
		}
		Boolean ExecuteAsCaller 
		{
			get;
		}
		Boolean ExecuteAsOwner 
		{
			get;
		}
		Boolean ExecuteAsSelf 
		{
			get;
		}
		Boolean IsNativeCompiled 
		{
			get;
		}
		String MethodName 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		Boolean ReturnsNullOnNullInput 
		{
			get;
		}
		Boolean WithSchemaBinding 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlAssembly> Assembly 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BodyDependencies 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlLoginReference> Login 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlParameter> Parameters 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlDataTypeReference> ReturnType 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlSchemaReference> Schema 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlUserReference> User 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlClrTableOptionReference : ISqlAzureTSqlClrTableOption
	{
    }
	public interface ISqlAzureTSqlClrTableOption : ISqlModelElement
	{		
		String ClassName 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlAggregateReference : ISqlAzureTSqlAggregate
	{
    }
	public interface ISqlAzureTSqlAggregate : ISqlModelElement
	{		
		String ClassName 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlAssemblyReference> Assembly 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlParameter> Parameters 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlApplicationRoleReference : ISqlAzureTSqlApplicationRole
	{
    }
	public interface ISqlAzureTSqlApplicationRole : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlSchemaReference> DefaultSchema 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlIndexReference : ISqlAzureTSqlIndex
	{
    }
	public interface ISqlAzureTSqlIndex : ISqlModelElement
	{		
		Int32? BucketCount 
		{
			get;
		}
		Boolean Clustered 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		String FilterPredicate 
		{
			get;
		}
		Boolean Hash 
		{
			get;
		}
		Boolean IgnoreDuplicateKey 
		{
			get;
		}
		Boolean RecomputeStatistics 
		{
			get;
		}
		Boolean Unique 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlColumnReference> Columns 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlColumnReference> IncludedColumns 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISpecifiesIndex> IndexedObject 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlAssemblyReference : ISqlAzureTSqlAssembly
	{
    }
	public interface ISqlAzureTSqlAssembly : ISqlModelElement
	{		
		AssemblyPermissionSet PermissionSet 
		{
			get;
		}
		Boolean Visible 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlAssemblySource> AssemblySources 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlAssemblyReference> ReferencedAssemblies 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlAssemblySourceReference : ISqlAzureTSqlAssemblySource
	{
    }
	public interface ISqlAzureTSqlAssemblySource : ISqlModelElement
	{		
		String Source 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlAsymmetricKeyReference : ISqlAzureTSqlAsymmetricKey
	{
    }
	public interface ISqlAzureTSqlAsymmetricKey : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlAuditActionReference : ISqlAzureTSqlAuditAction
	{
    }
	public interface ISqlAzureTSqlAuditAction : ISqlModelElement
	{		
	}
    public interface ISqlAzureTSqlAuditActionGroupReference : ISqlAzureTSqlAuditActionGroup
	{
    }
	public interface ISqlAzureTSqlAuditActionGroup : ISqlModelElement
	{		
	}
    public interface ISqlAzureTSqlAuditActionSpecificationReference : ISqlAzureTSqlAuditActionSpecification
	{
    }
	public interface ISqlAzureTSqlAuditActionSpecification : ISqlModelElement
	{		
	}
    public interface ISqlAzureTSqlBrokerPriorityReference : ISqlAzureTSqlBrokerPriority
	{
    }
	public interface ISqlAzureTSqlBrokerPriority : ISqlModelElement
	{		
	}
    public interface ISqlAzureTSqlBuiltInServerRoleReference : ISqlAzureTSqlBuiltInServerRole
	{
    }
	public interface ISqlAzureTSqlBuiltInServerRole : ISqlModelElement
	{		
	}
    public interface ISqlAzureTSqlDataTypeReference : ISqlAzureTSqlDataType
	{
    }
	public interface ISqlAzureTSqlDataType : ISqlModelElement
	{		
		SqlDataType SqlDataType 
		{
			get;
		}
		Boolean UddtIsMax 
		{
			get;
		}
		Int32 UddtLength 
		{
			get;
		}
		Boolean UddtNullable 
		{
			get;
		}
		Int32 UddtPrecision 
		{
			get;
		}
		Int32 UddtScale 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlSchemaReference> Schema 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlDataTypeReference> Type 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlCertificateReference : ISqlAzureTSqlCertificate
	{
    }
	public interface ISqlAzureTSqlCertificate : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlCheckConstraintReference : ISqlAzureTSqlCheckConstraint
	{
    }
	public interface ISqlAzureTSqlCheckConstraint : ISqlModelElement
	{		
		Boolean Disabled 
		{
			get;
		}
		String Expression 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ExpressionDependencies 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlTableReference> Host 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlClrTypeMethodReference : ISqlAzureTSqlClrTypeMethod
	{
    }
	public interface ISqlAzureTSqlClrTypeMethod : ISqlModelElement
	{		
		String MethodName 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlParameter> Parameters 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlDataType> ReturnType 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlClrTypeMethodParameterReference : ISqlAzureTSqlClrTypeMethodParameter
	{
    }
	public interface ISqlAzureTSqlClrTypeMethodParameter : ISqlModelElement
	{		
		Boolean IsOutput 
		{
			get;
		}
		String ParameterName 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlDataType> DataType 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlClrTypePropertyReference : ISqlAzureTSqlClrTypeProperty
	{
    }
	public interface ISqlAzureTSqlClrTypeProperty : ISqlModelElement
	{		
		String PropertyName 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlDataTypeReference> ClrType 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlColumnStoreIndexReference : ISqlAzureTSqlColumnStoreIndex
	{
    }
	public interface ISqlAzureTSqlColumnStoreIndex : ISqlModelElement
	{		
		Boolean Clustered 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISpecifiesIndex> IndexedObject 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlContractReference : ISqlAzureTSqlContract
	{
    }
	public interface ISqlAzureTSqlContract : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlCredentialReference : ISqlAzureTSqlCredential
	{
    }
	public interface ISqlAzureTSqlCredential : ISqlModelElement
	{		
	}
    public interface ISqlAzureTSqlDatabaseCredentialReference : ISqlAzureTSqlDatabaseCredential
	{
    }
	public interface ISqlAzureTSqlDatabaseCredential : ISqlModelElement
	{		
	}
    public interface ISqlAzureTSqlCryptographicProviderReference : ISqlAzureTSqlCryptographicProvider
	{
    }
	public interface ISqlAzureTSqlCryptographicProvider : ISqlModelElement
	{		
	}
    public interface ISqlAzureTSqlDatabaseAuditSpecificationReference : ISqlAzureTSqlDatabaseAuditSpecification
	{
    }
	public interface ISqlAzureTSqlDatabaseAuditSpecification : ISqlModelElement
	{		
	}
    public interface ISqlAzureTSqlDatabaseDdlTriggerReference : ISqlAzureTSqlDatabaseDdlTrigger
	{
    }
	public interface ISqlAzureTSqlDatabaseDdlTrigger : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		String ClassName 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Boolean ExecuteAsCaller 
		{
			get;
		}
		Boolean ExecuteAsOwner 
		{
			get;
		}
		Boolean ExecuteAsSelf 
		{
			get;
		}
		String MethodName 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		TriggerType TriggerType 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlAssemblyReference> Assembly 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BodyDependencies 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlEventGroup> EventGroup 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Model.EventType> EventType 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlLoginReference> Login 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlUserReference> User 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlDatabaseEncryptionKeyReference : ISqlAzureTSqlDatabaseEncryptionKey
	{
    }
	public interface ISqlAzureTSqlDatabaseEncryptionKey : ISqlModelElement
	{		
	}
    public interface ISqlAzureTSqlDatabaseEventNotificationReference : ISqlAzureTSqlDatabaseEventNotification
	{
    }
	public interface ISqlAzureTSqlDatabaseEventNotification : ISqlModelElement
	{		
	}
    public interface ISqlAzureTSqlDatabaseMirroringLanguageSpecifierReference : ISqlAzureTSqlDatabaseMirroringLanguageSpecifier
	{
    }
	public interface ISqlAzureTSqlDatabaseMirroringLanguageSpecifier : ISqlModelElement
	{		
	}
    public interface ISqlAzureTSqlDatabaseOptionsReference : ISqlAzureTSqlDatabaseOptions
	{
    }
	public interface ISqlAzureTSqlDatabaseOptions : ISqlModelElement
	{		
		String Collation 
		{
			get;
		}
		Boolean ReadOnly 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlDataCompressionOptionReference : ISqlAzureTSqlDataCompressionOption
	{
    }
	public interface ISqlAzureTSqlDataCompressionOption : ISqlModelElement
	{		
	}
    public interface ISqlAzureTSqlDefaultReference : ISqlAzureTSqlDefault
	{
    }
	public interface ISqlAzureTSqlDefault : ISqlModelElement
	{		
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlDefaultConstraintReference : ISqlAzureTSqlDefaultConstraint
	{
    }
	public interface ISqlAzureTSqlDefaultConstraint : ISqlModelElement
	{		
		Boolean Disabled 
		{
			get;
		}
		String Expression 
		{
			get;
		}
		Boolean WithValues 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ExpressionDependencies 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlTableReference> Host 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlColumnReference> TargetColumn 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlDmlTriggerReference : ISqlAzureTSqlDmlTrigger
	{
    }
	public interface ISqlAzureTSqlDmlTrigger : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		String ClassName 
		{
			get;
		}
		OrderRestriction DeleteOrderRestriction 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Boolean ExecuteAsCaller 
		{
			get;
		}
		Boolean ExecuteAsOwner 
		{
			get;
		}
		Boolean ExecuteAsSelf 
		{
			get;
		}
		OrderRestriction InsertOrderRestriction 
		{
			get;
		}
		Boolean IsDeleteTrigger 
		{
			get;
		}
		Boolean IsInsertTrigger 
		{
			get;
		}
		Boolean IsUpdateTrigger 
		{
			get;
		}
		String MethodName 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		TriggerType TriggerType 
		{
			get;
		}
		OrderRestriction UpdateOrderRestriction 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlAssemblyReference> Assembly 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BodyDependencies 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlLoginReference> Login 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> TriggerObject 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlUserReference> User 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlEndpointReference : ISqlAzureTSqlEndpoint
	{
    }
	public interface ISqlAzureTSqlEndpoint : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlErrorMessageReference : ISqlAzureTSqlErrorMessage
	{
    }
	public interface ISqlAzureTSqlErrorMessage : ISqlModelElement
	{		
	}
    public interface ISqlAzureTSqlEventGroupReference : ISqlAzureTSqlEventGroup
	{
    }
	public interface ISqlAzureTSqlEventGroup : ISqlModelElement
	{		
		EventGroupType Group 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlEventSessionReference : ISqlAzureTSqlEventSession
	{
    }
	public interface ISqlAzureTSqlEventSession : ISqlModelElement
	{		
	}
    public interface ISqlAzureTSqlDatabaseEventSessionReference : ISqlAzureTSqlDatabaseEventSession
	{
    }
	public interface ISqlAzureTSqlDatabaseEventSession : ISqlModelElement
	{		
	}
    public interface ISqlAzureTSqlEventSessionActionReference : ISqlAzureTSqlEventSessionAction
	{
    }
	public interface ISqlAzureTSqlEventSessionAction : ISqlModelElement
	{		
	}
    public interface ISqlAzureTSqlEventSessionDefinitionsReference : ISqlAzureTSqlEventSessionDefinitions
	{
    }
	public interface ISqlAzureTSqlEventSessionDefinitions : ISqlModelElement
	{		
	}
    public interface ISqlAzureTSqlEventSessionSettingReference : ISqlAzureTSqlEventSessionSetting
	{
    }
	public interface ISqlAzureTSqlEventSessionSetting : ISqlModelElement
	{		
	}
    public interface ISqlAzureTSqlEventSessionTargetReference : ISqlAzureTSqlEventSessionTarget
	{
    }
	public interface ISqlAzureTSqlEventSessionTarget : ISqlModelElement
	{		
	}
    public interface ISqlAzureTSqlEventTypeSpecifierReference : ISqlAzureTSqlEventTypeSpecifier
	{
    }
	public interface ISqlAzureTSqlEventTypeSpecifier : ISqlModelElement
	{		
		EventType EventType 
		{
			get;
		}
		OrderRestriction Order 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlExtendedProcedureReference : ISqlAzureTSqlExtendedProcedure
	{
    }
	public interface ISqlAzureTSqlExtendedProcedure : ISqlModelElement
	{		
		Boolean ExeccuteAsCaller 
		{
			get;
		}
		Boolean ExecuteAsOwner 
		{
			get;
		}
		Boolean ExecuteAsSelf 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlLoginReference> Login 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlParameter> Parameters 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlSchemaReference> Schema 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlUserReference> User 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlExtendedPropertyReference : ISqlAzureTSqlExtendedProperty
	{
    }
	public interface ISqlAzureTSqlExtendedProperty : ISqlModelElement
	{		
	}
    public interface ISqlAzureTSqlExternalDataSourceReference : ISqlAzureTSqlExternalDataSource
	{
    }
	public interface ISqlAzureTSqlExternalDataSource : ISqlModelElement
	{		
	}
    public interface ISqlAzureTSqlExternalFileFormatReference : ISqlAzureTSqlExternalFileFormat
	{
    }
	public interface ISqlAzureTSqlExternalFileFormat : ISqlModelElement
	{		
	}
    public interface ISqlAzureTSqlExternalTableReference : ISqlAzureTSqlExternalTable
	{
    }
	public interface ISqlAzureTSqlExternalTable : ISqlModelElement
	{		
		Boolean? IsAnsiNullsOn 
		{
			get;
		}
		Boolean? IsQuotedIdentifierOn 
		{
			get;
		}
		Boolean IsTableLockOnBulkLoad 
		{
			get;
		}
		LockEscalationMethod LockEscalation 
		{
			get;
		}
		//Composing
		IEnumerable<TSqlModelElementReference> Columns 
		{
			get;
		}
		//Hierarchical
		IEnumerable<TSqlModelElementReference> Schema 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlSqlFileReference : ISqlAzureTSqlSqlFile
	{
    }
	public interface ISqlAzureTSqlSqlFile : ISqlModelElement
	{		
	}
    public interface ISqlAzureTSqlFilegroupReference : ISqlAzureTSqlFilegroup
	{
    }
	public interface ISqlAzureTSqlFilegroup : ISqlModelElement
	{		
	}
    public interface ISqlAzureTSqlForeignKeyConstraintReference : ISqlAzureTSqlForeignKeyConstraint
	{
    }
	public interface ISqlAzureTSqlForeignKeyConstraint : ISqlModelElement
	{		
		ForeignKeyAction DeleteAction 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		ForeignKeyAction UpdateAction 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlColumnReference> Columns 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlColumnReference> ForeignColumns 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlTableReference> ForeignTable 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlTableReference> Host 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlFullTextCatalogReference : ISqlAzureTSqlFullTextCatalog
	{
    }
	public interface ISqlAzureTSqlFullTextCatalog : ISqlModelElement
	{		
		Boolean? AccentSensitivity 
		{
			get;
		}
		Boolean IsDefault 
		{
			get;
		}
		String Path 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlFilegroupReference> Filegroup 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlFullTextIndexReference : ISqlAzureTSqlFullTextIndex
	{
    }
	public interface ISqlAzureTSqlFullTextIndex : ISqlModelElement
	{		
	}
    public interface ISqlAzureTSqlFullTextIndexColumnSpecifierReference : ISqlAzureTSqlFullTextIndexColumnSpecifier
	{
    }
	public interface ISqlAzureTSqlFullTextIndexColumnSpecifier : ISqlModelElement
	{		
	}
    public interface ISqlAzureTSqlFullTextStopListReference : ISqlAzureTSqlFullTextStopList
	{
    }
	public interface ISqlAzureTSqlFullTextStopList : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlHttpProtocolSpecifierReference : ISqlAzureTSqlHttpProtocolSpecifier
	{
    }
	public interface ISqlAzureTSqlHttpProtocolSpecifier : ISqlModelElement
	{		
	}
    public interface ISqlAzureTSqlLinkedServerReference : ISqlAzureTSqlLinkedServer
	{
    }
	public interface ISqlAzureTSqlLinkedServer : ISqlModelElement
	{		
	}
    public interface ISqlAzureTSqlLinkedServerLoginReference : ISqlAzureTSqlLinkedServerLogin
	{
    }
	public interface ISqlAzureTSqlLinkedServerLogin : ISqlModelElement
	{		
	}
    public interface ISqlAzureTSqlLoginReference : ISqlAzureTSqlLogin
	{
    }
	public interface ISqlAzureTSqlLogin : ISqlModelElement
	{		
		Boolean Disabled 
		{
			get;
		}
		String Password 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlMasterKeyReference : ISqlAzureTSqlMasterKey
	{
    }
	public interface ISqlAzureTSqlMasterKey : ISqlModelElement
	{		
	}
    public interface ISqlAzureTSqlMessageTypeReference : ISqlAzureTSqlMessageType
	{
    }
	public interface ISqlAzureTSqlMessageType : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlPartitionFunctionReference : ISqlAzureTSqlPartitionFunction
	{
    }
	public interface ISqlAzureTSqlPartitionFunction : ISqlModelElement
	{		
	}
    public interface ISqlAzureTSqlPartitionSchemeReference : ISqlAzureTSqlPartitionScheme
	{
    }
	public interface ISqlAzureTSqlPartitionScheme : ISqlModelElement
	{		
	}
    public interface ISqlAzureTSqlPartitionValueReference : ISqlAzureTSqlPartitionValue
	{
    }
	public interface ISqlAzureTSqlPartitionValue : ISqlModelElement
	{		
	}
    public interface ISqlAzureTSqlPermissionReference : ISqlAzureTSqlPermission
	{
    }
	public interface ISqlAzureTSqlPermission : ISqlModelElement
	{		
		PermissionAction PermissionAction 
		{
			get;
		}
		PermissionType PermissionType 
		{
			get;
		}
		Boolean WithAllPrivileges 
		{
			get;
		}
		Boolean WithGrantOption 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlColumnReference> ExcludedColumns 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlSecurityPrincipal> Grantee 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlSecurityPrincipal> Grantor 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlColumnReference> RevokedGrantOptionColumns 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlSecurable> SecuredObject 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlPrimaryKeyConstraintReference : ISqlAzureTSqlPrimaryKeyConstraint
	{
    }
	public interface ISqlAzureTSqlPrimaryKeyConstraint : ISqlModelElement
	{		
		Int32? BucketCount 
		{
			get;
		}
		Boolean Clustered 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Boolean Hash 
		{
			get;
		}
		Boolean IgnoreDuplicateKey 
		{
			get;
		}
		Boolean RecomputeStatistics 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlColumnReference> Columns 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlTableReference> Host 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlProcedureReference : ISqlAzureTSqlProcedure
	{
    }
	public interface ISqlAzureTSqlProcedure : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		String ClassName 
		{
			get;
		}
		Boolean ExecuteAsCaller 
		{
			get;
		}
		Boolean ExecuteAsOwner 
		{
			get;
		}
		Boolean ExecuteAsSelf 
		{
			get;
		}
		String MethodName 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		Boolean WithRecompile 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlAssemblyReference> Assembly 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BodyDependencies 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlLoginReference> Login 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlParameter> Parameters 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlSchemaReference> Schema 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlUserReference> User 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlQueueReference : ISqlAzureTSqlQueue
	{
    }
	public interface ISqlAzureTSqlQueue : ISqlModelElement
	{		
		Boolean ActivationExecuteAsCaller 
		{
			get;
		}
		Boolean ActivationExecuteAsOwner 
		{
			get;
		}
		Boolean ActivationExecuteAsSelf 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlColumn> Columns 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlLoginReference> Login 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlSchemaReference> Schema 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlUserReference> User 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlQueueEventNotificationReference : ISqlAzureTSqlQueueEventNotification
	{
    }
	public interface ISqlAzureTSqlQueueEventNotification : ISqlModelElement
	{		
	}
    public interface ISqlAzureTSqlRemoteServiceBindingReference : ISqlAzureTSqlRemoteServiceBinding
	{
    }
	public interface ISqlAzureTSqlRemoteServiceBinding : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlResourceGovernorReference : ISqlAzureTSqlResourceGovernor
	{
    }
	public interface ISqlAzureTSqlResourceGovernor : ISqlModelElement
	{		
	}
    public interface ISqlAzureTSqlResourcePoolReference : ISqlAzureTSqlResourcePool
	{
    }
	public interface ISqlAzureTSqlResourcePool : ISqlModelElement
	{		
	}
    public interface ISqlAzureTSqlRoleReference : ISqlAzureTSqlRole
	{
    }
	public interface ISqlAzureTSqlRole : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlRoleMembershipReference : ISqlAzureTSqlRoleMembership
	{
    }
	public interface ISqlAzureTSqlRoleMembership : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlDatabaseSecurityPrincipal> Member 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlRoleReference> Role 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlRouteReference : ISqlAzureTSqlRoute
	{
    }
	public interface ISqlAzureTSqlRoute : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlRuleReference : ISqlAzureTSqlRule
	{
    }
	public interface ISqlAzureTSqlRule : ISqlModelElement
	{		
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlSchemaReference : ISqlAzureTSqlSchema
	{
    }
	public interface ISqlAzureTSqlSchema : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlSearchPropertyReference : ISqlAzureTSqlSearchProperty
	{
    }
	public interface ISqlAzureTSqlSearchProperty : ISqlModelElement
	{		
	}
    public interface ISqlAzureTSqlSearchPropertyListReference : ISqlAzureTSqlSearchPropertyList
	{
    }
	public interface ISqlAzureTSqlSearchPropertyList : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlSecurityPolicyReference : ISqlAzureTSqlSecurityPolicy
	{
    }
	public interface ISqlAzureTSqlSecurityPolicy : ISqlModelElement
	{		
		Boolean Enabled 
		{
			get;
		}
		Boolean IsSchemaBound 
		{
			get;
		}
		Boolean NotForReplication 
		{
			get;
		}
		//Composing
		IEnumerable<TSqlModelElementReference> Predicates 
		{
			get;
		}
		//Hierarchical
		IEnumerable<TSqlModelElementReference> Schema 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlSecurityPredicateReference : ISqlAzureTSqlSecurityPredicate
	{
    }
	public interface ISqlAzureTSqlSecurityPredicate : ISqlModelElement
	{		
		String BodyScript 
		{
			get;
		}
		SecurityPredicateOperation Operation 
		{
			get;
		}
		SecurityPredicateType PredicateType 
		{
			get;
		}
		//Peer
		IEnumerable<TSqlModelElementReference> BodyDependencies 
		{
			get;
		}
		//Peer
		IEnumerable<TSqlModelElementReference> TargetObject 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlSequenceReference : ISqlAzureTSqlSequence
	{
    }
	public interface ISqlAzureTSqlSequence : ISqlModelElement
	{		
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlServerAuditReference : ISqlAzureTSqlServerAudit
	{
    }
	public interface ISqlAzureTSqlServerAudit : ISqlModelElement
	{		
	}
    public interface ISqlAzureTSqlServerAuditSpecificationReference : ISqlAzureTSqlServerAuditSpecification
	{
    }
	public interface ISqlAzureTSqlServerAuditSpecification : ISqlModelElement
	{		
	}
    public interface ISqlAzureTSqlServerDdlTriggerReference : ISqlAzureTSqlServerDdlTrigger
	{
    }
	public interface ISqlAzureTSqlServerDdlTrigger : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		String ClassName 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Boolean ExecuteAsCaller 
		{
			get;
		}
		Boolean ExecuteAsOwner 
		{
			get;
		}
		Boolean ExecuteAsSelf 
		{
			get;
		}
		String MethodName 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		TriggerType TriggerType 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlAssemblyReference> Assembly 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BodyDependencies 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlEventGroup> EventGroup 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Model.EventType> EventType 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlLoginReference> Login 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlUserReference> User 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlServerEventNotificationReference : ISqlAzureTSqlServerEventNotification
	{
    }
	public interface ISqlAzureTSqlServerEventNotification : ISqlModelElement
	{		
	}
    public interface ISqlAzureTSqlServerOptionsReference : ISqlAzureTSqlServerOptions
	{
    }
	public interface ISqlAzureTSqlServerOptions : ISqlModelElement
	{		
	}
    public interface ISqlAzureTSqlServerRoleMembershipReference : ISqlAzureTSqlServerRoleMembership
	{
    }
	public interface ISqlAzureTSqlServerRoleMembership : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.IServerSecurityPrincipal> Member 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlRoleReference> Role 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlServiceReference : ISqlAzureTSqlService
	{
    }
	public interface ISqlAzureTSqlService : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlServiceBrokerLanguageSpecifierReference : ISqlAzureTSqlServiceBrokerLanguageSpecifier
	{
    }
	public interface ISqlAzureTSqlServiceBrokerLanguageSpecifier : ISqlModelElement
	{		
	}
    public interface ISqlAzureTSqlSignatureReference : ISqlAzureTSqlSignature
	{
    }
	public interface ISqlAzureTSqlSignature : ISqlModelElement
	{		
	}
    public interface ISqlAzureTSqlSignatureEncryptionMechanismReference : ISqlAzureTSqlSignatureEncryptionMechanism
	{
    }
	public interface ISqlAzureTSqlSignatureEncryptionMechanism : ISqlModelElement
	{		
	}
    public interface ISqlAzureTSqlSoapLanguageSpecifierReference : ISqlAzureTSqlSoapLanguageSpecifier
	{
    }
	public interface ISqlAzureTSqlSoapLanguageSpecifier : ISqlModelElement
	{		
	}
    public interface ISqlAzureTSqlSoapMethodSpecificationReference : ISqlAzureTSqlSoapMethodSpecification
	{
    }
	public interface ISqlAzureTSqlSoapMethodSpecification : ISqlModelElement
	{		
	}
    public interface ISqlAzureTSqlSpatialIndexReference : ISqlAzureTSqlSpatialIndex
	{
    }
	public interface ISqlAzureTSqlSpatialIndex : ISqlModelElement
	{		
		Int32? CellsPerObject 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Degree GridLevel1Density 
		{
			get;
		}
		Degree GridLevel2Density 
		{
			get;
		}
		Degree GridLevel3Density 
		{
			get;
		}
		Degree GridLevel4Density 
		{
			get;
		}
		Boolean IgnoreDuplicateKey 
		{
			get;
		}
		Boolean RecomputeStatistics 
		{
			get;
		}
		Tessellation Tessellation 
		{
			get;
		}
		Double? XMax 
		{
			get;
		}
		Double? XMin 
		{
			get;
		}
		Double? YMax 
		{
			get;
		}
		Double? YMin 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlColumnReference> Column 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISpecifiesIndex> IndexedObject 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlStatisticsReference : ISqlAzureTSqlStatistics
	{
    }
	public interface ISqlAzureTSqlStatistics : ISqlModelElement
	{		
		String FilterPredicate 
		{
			get;
		}
		Boolean NoRecompute 
		{
			get;
		}
		Int32 SampleSize 
		{
			get;
		}
		SamplingStyle SamplingStyle 
		{
			get;
		}
		String StatsStream 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlColumnReference> Columns 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ExpressionDependencies 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> OnObject 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlParameterReference : ISqlAzureTSqlParameter
	{
    }
	public interface ISqlAzureTSqlParameter : ISqlModelElement
	{		
		String DefaultExpression 
		{
			get;
		}
		Boolean IsMax 
		{
			get;
		}
		Boolean IsOutput 
		{
			get;
		}
		Int32 Length 
		{
			get;
		}
		Int32 Precision 
		{
			get;
		}
		Boolean ReadOnly 
		{
			get;
		}
		Int32 Scale 
		{
			get;
		}
		Boolean Varying 
		{
			get;
		}
		XmlStyle XmlStyle 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlDataType> DataType 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlXmlSchemaCollectionReference> XmlSchemaCollection 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlSymmetricKeyReference : ISqlAzureTSqlSymmetricKey
	{
    }
	public interface ISqlAzureTSqlSymmetricKey : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlSymmetricKeyPasswordReference : ISqlAzureTSqlSymmetricKeyPassword
	{
    }
	public interface ISqlAzureTSqlSymmetricKeyPassword : ISqlModelElement
	{		
	}
    public interface ISqlAzureTSqlSynonymReference : ISqlAzureTSqlSynonym
	{
    }
	public interface ISqlAzureTSqlSynonym : ISqlModelElement
	{		
		String ForObjectName 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ForObject 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlTableReference : ISqlAzureTSqlTable
	{
    }
	public interface ISqlAzureTSqlTable : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		Int64? DataPages 
		{
			get;
		}
		Double? DataSize 
		{
			get;
		}
		Double? IndexSize 
		{
			get;
		}
		Boolean IsAutoGeneratedHistoryTable 
		{
			get;
		}
		Boolean LargeValueTypesOutOfRow 
		{
			get;
		}
		LockEscalationMethod LockEscalation 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		Int64? RowCount 
		{
			get;
		}
		Boolean TableLockOnBulkLoad 
		{
			get;
		}
		Int32 TextInRowSize 
		{
			get;
		}
		Int64? UsedPages 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlColumn> Columns 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlFileTableReference : ISqlAzureTSqlFileTable
	{
    }
	public interface ISqlAzureTSqlFileTable : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		LockEscalationMethod LockEscalation 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		Boolean TableLockOnBulkLoad 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlColumn> Columns 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlTableTypeReference : ISqlAzureTSqlTableType
	{
    }
	public interface ISqlAzureTSqlTableType : ISqlModelElement
	{		
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlTableTypeColumn> Columns 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ITableTypeConstraint> Constraints 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlTableTypeCheckConstraintReference : ISqlAzureTSqlTableTypeCheckConstraint
	{
    }
	public interface ISqlAzureTSqlTableTypeCheckConstraint : ISqlModelElement
	{		
		String Expression 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ExpressionDependencies 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlTableTypeColumnReference : ISqlAzureTSqlTableTypeColumn
	{
    }
	public interface ISqlAzureTSqlTableTypeColumn : ISqlModelElement
	{		
		String Collation 
		{
			get;
		}
		String Expression 
		{
			get;
		}
		String IdentityIncrement 
		{
			get;
		}
		String IdentitySeed 
		{
			get;
		}
		Boolean IsIdentity 
		{
			get;
		}
		Boolean IsMax 
		{
			get;
		}
		Int32 Length 
		{
			get;
		}
		Boolean Nullable 
		{
			get;
		}
		Boolean Persisted 
		{
			get;
		}
		Boolean? PersistedNullable 
		{
			get;
		}
		Int32 Precision 
		{
			get;
		}
		Int32 Scale 
		{
			get;
		}
		XmlStyle XmlStyle 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlDataType> DataType 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ExpressionDependencies 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlXmlSchemaCollectionReference> XmlSchemaCollection 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlTableTypeDefaultConstraintReference : ISqlAzureTSqlTableTypeDefaultConstraint
	{
    }
	public interface ISqlAzureTSqlTableTypeDefaultConstraint : ISqlModelElement
	{		
		String Expression 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ExpressionDependencies 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlColumnReference> TargetColumn 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlTableTypeIndexReference : ISqlAzureTSqlTableTypeIndex
	{
    }
	public interface ISqlAzureTSqlTableTypeIndex : ISqlModelElement
	{		
		Int32? BucketCount 
		{
			get;
		}
		Boolean Hash 
		{
			get;
		}
		Boolean IsDisabled 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlColumnReference> Columns 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlTableTypePrimaryKeyConstraintReference : ISqlAzureTSqlTableTypePrimaryKeyConstraint
	{
    }
	public interface ISqlAzureTSqlTableTypePrimaryKeyConstraint : ISqlModelElement
	{		
		Int32? BucketCount 
		{
			get;
		}
		Boolean Clustered 
		{
			get;
		}
		Boolean Hash 
		{
			get;
		}
		Boolean IgnoreDuplicateKey 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlColumnReference> Columns 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlTableTypeUniqueConstraintReference : ISqlAzureTSqlTableTypeUniqueConstraint
	{
    }
	public interface ISqlAzureTSqlTableTypeUniqueConstraint : ISqlModelElement
	{		
		Int32? BucketCount 
		{
			get;
		}
		Boolean Clustered 
		{
			get;
		}
		Boolean Hash 
		{
			get;
		}
		Boolean IgnoreDuplicateKey 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlColumnReference> Columns 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlTcpProtocolSpecifierReference : ISqlAzureTSqlTcpProtocolSpecifier
	{
    }
	public interface ISqlAzureTSqlTcpProtocolSpecifier : ISqlModelElement
	{		
	}
    public interface ISqlAzureTSqlUniqueConstraintReference : ISqlAzureTSqlUniqueConstraint
	{
    }
	public interface ISqlAzureTSqlUniqueConstraint : ISqlModelElement
	{		
		Int32? BucketCount 
		{
			get;
		}
		Boolean Clustered 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Boolean Hash 
		{
			get;
		}
		Boolean IgnoreDuplicateKey 
		{
			get;
		}
		Boolean RecomputeStatistics 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlColumnReference> Columns 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlTableReference> Host 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlUserReference : ISqlAzureTSqlUser
	{
    }
	public interface ISqlAzureTSqlUser : ISqlModelElement
	{		
		Boolean WithoutLogin 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlSchemaReference> DefaultSchema 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlLoginReference> Login 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlUserDefinedServerRoleReference : ISqlAzureTSqlUserDefinedServerRole
	{
    }
	public interface ISqlAzureTSqlUserDefinedServerRole : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlUserDefinedTypeReference : ISqlAzureTSqlUserDefinedType
	{
    }
	public interface ISqlAzureTSqlUserDefinedType : ISqlModelElement
	{		
		Boolean? ByteOrdered 
		{
			get;
		}
		String ClassName 
		{
			get;
		}
		Boolean? FixedLength 
		{
			get;
		}
		Format Format 
		{
			get;
		}
		Int32? MaxByteSize 
		{
			get;
		}
		String ValidationMethodName 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlAssemblyReference> Assembly 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.TSqlModelElement> Methods 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.TSqlModelElement> Properties 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlViewReference : ISqlAzureTSqlView
	{
    }
	public interface ISqlAzureTSqlView : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		String SelectStatement 
		{
			get;
		}
		Boolean WithCheckOption 
		{
			get;
		}
		Boolean WithSchemaBinding 
		{
			get;
		}
		Boolean WithViewMetadata 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BodyDependencies 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlColumn> Columns 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlWorkloadGroupReference : ISqlAzureTSqlWorkloadGroup
	{
    }
	public interface ISqlAzureTSqlWorkloadGroup : ISqlModelElement
	{		
	}
    public interface ISqlAzureTSqlXmlIndexReference : ISqlAzureTSqlXmlIndex
	{
    }
	public interface ISqlAzureTSqlXmlIndex : ISqlModelElement
	{		
		Boolean Disabled 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlSelectiveXmlIndexReference : ISqlAzureTSqlSelectiveXmlIndex
	{
    }
	public interface ISqlAzureTSqlSelectiveXmlIndex : ISqlModelElement
	{		
		Boolean Disabled 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlXmlNamespaceReference : ISqlAzureTSqlXmlNamespace
	{
    }
	public interface ISqlAzureTSqlXmlNamespace : ISqlModelElement
	{		
	}
    public interface ISqlAzureTSqlPromotedNodePathForXQueryTypeReference : ISqlAzureTSqlPromotedNodePathForXQueryType
	{
    }
	public interface ISqlAzureTSqlPromotedNodePathForXQueryType : ISqlModelElement
	{		
	}
    public interface ISqlAzureTSqlPromotedNodePathForSqlTypeReference : ISqlAzureTSqlPromotedNodePathForSqlType
	{
    }
	public interface ISqlAzureTSqlPromotedNodePathForSqlType : ISqlModelElement
	{		
		Boolean IsMax 
		{
			get;
		}
		Int32 Length 
		{
			get;
		}
		Int32 Precision 
		{
			get;
		}
		Int32 Scale 
		{
			get;
		}
	}
    public interface ISqlAzureTSqlXmlSchemaCollectionReference : ISqlAzureTSqlXmlSchemaCollection
	{
    }
	public interface ISqlAzureTSqlXmlSchemaCollection : ISqlModelElement
	{		
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureTSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISql110TSqlColumnReference : ISql110TSqlColumn
	{
    }
	public interface ISql110TSqlColumn : ISqlModelElement
	{		
		String Collation 
		{
			get;
		}
		String Expression 
		{
			get;
		}
		String IdentityIncrement 
		{
			get;
		}
		String IdentitySeed 
		{
			get;
		}
		Boolean IsFileStream 
		{
			get;
		}
		Boolean IsIdentity 
		{
			get;
		}
		Boolean IsIdentityNotForReplication 
		{
			get;
		}
		Boolean IsMax 
		{
			get;
		}
		Boolean IsRowGuidCol 
		{
			get;
		}
		Int32 Length 
		{
			get;
		}
		Boolean Nullable 
		{
			get;
		}
		Boolean Persisted 
		{
			get;
		}
		Boolean? PersistedNullable 
		{
			get;
		}
		Int32 Precision 
		{
			get;
		}
		Int32 Scale 
		{
			get;
		}
		Boolean Sparse 
		{
			get;
		}
		XmlStyle XmlStyle 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlDataType> DataType 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ExpressionDependencies 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlXmlSchemaCollectionReference> XmlSchemaCollection 
		{
			get;
		}
	}
    public interface ISql110TSqlTableValuedFunctionReference : ISql110TSqlTableValuedFunction
	{
    }
	public interface ISql110TSqlTableValuedFunction : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		Boolean CalledOnNullInput 
		{
			get;
		}
		String ClassName 
		{
			get;
		}
		DataAccessKind? DataAccess 
		{
			get;
		}
		Boolean? Deterministic 
		{
			get;
		}
		Boolean ExecuteAsCaller 
		{
			get;
		}
		Boolean ExecuteAsOwner 
		{
			get;
		}
		Boolean ExecuteAsSelf 
		{
			get;
		}
		String FillRowMethodName 
		{
			get;
		}
		Boolean IsNativeCompiled 
		{
			get;
		}
		Boolean IsReplicated 
		{
			get;
		}
		String MethodName 
		{
			get;
		}
		Boolean? Precise 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		Boolean ReturnsNullOnNullInput 
		{
			get;
		}
		String ReturnTableVariableName 
		{
			get;
		}
		SystemDataAccessKind? SystemDataAccess 
		{
			get;
		}
		Boolean WithEncryption 
		{
			get;
		}
		Boolean WithSchemaBinding 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlAssembly> Assembly 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BodyDependencies 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlColumn> Columns 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlLoginReference> Login 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlParameter> Parameters 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlDataTypeReference> ReturnType 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlSchemaReference> Schema 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlClrTableOption> TableOption 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlUserReference> User 
		{
			get;
		}
	}
    public interface ISql110TSqlScalarFunctionReference : ISql110TSqlScalarFunction
	{
    }
	public interface ISql110TSqlScalarFunction : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		Boolean CalledOnNullInput 
		{
			get;
		}
		String ClassName 
		{
			get;
		}
		DataAccessKind? DataAccess 
		{
			get;
		}
		Boolean? Deterministic 
		{
			get;
		}
		Boolean ExecuteAsCaller 
		{
			get;
		}
		Boolean ExecuteAsOwner 
		{
			get;
		}
		Boolean ExecuteAsSelf 
		{
			get;
		}
		String FillRowMethodName 
		{
			get;
		}
		Boolean IsNativeCompiled 
		{
			get;
		}
		Boolean IsReplicated 
		{
			get;
		}
		String MethodName 
		{
			get;
		}
		Boolean? Precise 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		Boolean ReturnsNullOnNullInput 
		{
			get;
		}
		SystemDataAccessKind? SystemDataAccess 
		{
			get;
		}
		Boolean WithEncryption 
		{
			get;
		}
		Boolean WithSchemaBinding 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlAssembly> Assembly 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BodyDependencies 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlLoginReference> Login 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlParameter> Parameters 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlDataTypeReference> ReturnType 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlSchemaReference> Schema 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlUserReference> User 
		{
			get;
		}
	}
    public interface ISql110TSqlClrTableOptionReference : ISql110TSqlClrTableOption
	{
    }
	public interface ISql110TSqlClrTableOption : ISqlModelElement
	{		
		String ClassName 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlColumnReference> OrderColumns 
		{
			get;
		}
	}
    public interface ISql110TSqlAggregateReference : ISql110TSqlAggregate
	{
    }
	public interface ISql110TSqlAggregate : ISqlModelElement
	{		
		String ClassName 
		{
			get;
		}
		Format Format 
		{
			get;
		}
		Boolean? InvariantToDuplicates 
		{
			get;
		}
		Boolean? InvariantToNulls 
		{
			get;
		}
		Int32? MaxByteSize 
		{
			get;
		}
		Boolean? NullIfEmpty 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlAssemblyReference> Assembly 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlParameter> Parameters 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlDataTypeReference> ReturnType 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISql110TSqlApplicationRoleReference : ISql110TSqlApplicationRole
	{
    }
	public interface ISql110TSqlApplicationRole : ISqlModelElement
	{		
		String Password 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlSchemaReference> DefaultSchema 
		{
			get;
		}
	}
    public interface ISql110TSqlIndexReference : ISql110TSqlIndex
	{
    }
	public interface ISql110TSqlIndex : ISqlModelElement
	{		
		Boolean AllowPageLocks 
		{
			get;
		}
		Boolean AllowRowLocks 
		{
			get;
		}
		Int32? BucketCount 
		{
			get;
		}
		Boolean Clustered 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Boolean? FileStreamNull 
		{
			get;
		}
		Int32? FillFactor 
		{
			get;
		}
		String FilterPredicate 
		{
			get;
		}
		Boolean Hash 
		{
			get;
		}
		Boolean IgnoreDuplicateKey 
		{
			get;
		}
		Boolean RecomputeStatistics 
		{
			get;
		}
		Boolean Unique 
		{
			get;
		}
		Boolean WithPadIndex 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BodyDependencies 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlColumnReference> Columns 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlDataCompressionOption> DataCompressionOptions 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlFilegroupReference> Filegroup 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlFilegroupReference> FileStreamFilegroup 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlPartitionSchemeReference> FileStreamPartitionScheme 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlColumnReference> IncludedColumns 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISpecifiesIndex> IndexedObject 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlColumnReference> PartitionColumn 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlPartitionSchemeReference> PartitionScheme 
		{
			get;
		}
	}
    public interface ISql110TSqlAssemblyReference : ISql110TSqlAssembly
	{
    }
	public interface ISql110TSqlAssembly : ISqlModelElement
	{		
		AssemblyPermissionSet PermissionSet 
		{
			get;
		}
		Boolean Visible 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlAssemblySource> AssemblySources 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlAssemblyReference> ReferencedAssemblies 
		{
			get;
		}
	}
    public interface ISql110TSqlAssemblySourceReference : ISql110TSqlAssemblySource
	{
    }
	public interface ISql110TSqlAssemblySource : ISqlModelElement
	{		
		String Source 
		{
			get;
		}
	}
    public interface ISql110TSqlAsymmetricKeyReference : ISql110TSqlAsymmetricKey
	{
    }
	public interface ISql110TSqlAsymmetricKey : ISqlModelElement
	{		
		AsymmetricKeyAlgorithm Algorithm 
		{
			get;
		}
		SymmetricKeyCreationDisposition CreationDisposition 
		{
			get;
		}
		Boolean EncryptedWithPassword 
		{
			get;
		}
		String ExecutableFile 
		{
			get;
		}
		String File 
		{
			get;
		}
		String Password 
		{
			get;
		}
		String ProviderKeyName 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlAssemblyReference> Assembly 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> Provider 
		{
			get;
		}
	}
    public interface ISql110TSqlAuditActionReference : ISql110TSqlAuditAction
	{
    }
	public interface ISql110TSqlAuditAction : ISqlModelElement
	{		
		DatabaseAuditAction Action 
		{
			get;
		}
	}
    public interface ISql110TSqlAuditActionGroupReference : ISql110TSqlAuditActionGroup
	{
    }
	public interface ISql110TSqlAuditActionGroup : ISqlModelElement
	{		
		AuditActionGroupType ActionGroup 
		{
			get;
		}
	}
    public interface ISql110TSqlAuditActionSpecificationReference : ISql110TSqlAuditActionSpecification
	{
    }
	public interface ISql110TSqlAuditActionSpecification : ISqlModelElement
	{		
		Boolean AuditsDatabase 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlAuditAction> AuditActions 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlDatabaseSecurityPrincipal> Principals 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlSecurable> SecuredObject 
		{
			get;
		}
	}
    public interface ISql110TSqlBrokerPriorityReference : ISql110TSqlBrokerPriority
	{
    }
	public interface ISql110TSqlBrokerPriority : ISqlModelElement
	{		
		Int32 PriorityLevel 
		{
			get;
		}
		String RemoteServiceName 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ContractName 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> LocalServiceName 
		{
			get;
		}
	}
    public interface ISql110TSqlBuiltInServerRoleReference : ISql110TSqlBuiltInServerRole
	{
    }
	public interface ISql110TSqlBuiltInServerRole : ISqlModelElement
	{		
	}
    public interface ISql110TSqlDataTypeReference : ISql110TSqlDataType
	{
    }
	public interface ISql110TSqlDataType : ISqlModelElement
	{		
		SqlDataType SqlDataType 
		{
			get;
		}
		Boolean UddtIsMax 
		{
			get;
		}
		Int32 UddtLength 
		{
			get;
		}
		Boolean UddtNullable 
		{
			get;
		}
		Int32 UddtPrecision 
		{
			get;
		}
		Int32 UddtScale 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlSchemaReference> Schema 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlDataTypeReference> Type 
		{
			get;
		}
	}
    public interface ISql110TSqlCertificateReference : ISql110TSqlCertificate
	{
    }
	public interface ISql110TSqlCertificate : ISqlModelElement
	{		
		Boolean ActiveForBeginDialog 
		{
			get;
		}
		Boolean EncryptedWithPassword 
		{
			get;
		}
		String EncryptionPassword 
		{
			get;
		}
		String ExistingKeysFilePath 
		{
			get;
		}
		String ExpiryDate 
		{
			get;
		}
		Boolean IsExistingKeyFileExecutable 
		{
			get;
		}
		String PrivateKeyDecryptionPassword 
		{
			get;
		}
		String PrivateKeyEncryptionPassword 
		{
			get;
		}
		String PrivateKeyFilePath 
		{
			get;
		}
		String StartDate 
		{
			get;
		}
		String Subject 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlAssemblyReference> ExistingKeysAssembly 
		{
			get;
		}
	}
    public interface ISql110TSqlCheckConstraintReference : ISql110TSqlCheckConstraint
	{
    }
	public interface ISql110TSqlCheckConstraint : ISqlModelElement
	{		
		Boolean Disabled 
		{
			get;
		}
		String Expression 
		{
			get;
		}
		Boolean NotForReplication 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ExpressionDependencies 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlTableReference> Host 
		{
			get;
		}
	}
    public interface ISql110TSqlClrTypeMethodReference : ISql110TSqlClrTypeMethod
	{
    }
	public interface ISql110TSqlClrTypeMethod : ISqlModelElement
	{		
		String MethodName 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlParameter> Parameters 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlDataType> ReturnType 
		{
			get;
		}
	}
    public interface ISql110TSqlClrTypeMethodParameterReference : ISql110TSqlClrTypeMethodParameter
	{
    }
	public interface ISql110TSqlClrTypeMethodParameter : ISqlModelElement
	{		
		Boolean IsOutput 
		{
			get;
		}
		String ParameterName 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlDataType> DataType 
		{
			get;
		}
	}
    public interface ISql110TSqlClrTypePropertyReference : ISql110TSqlClrTypeProperty
	{
    }
	public interface ISql110TSqlClrTypeProperty : ISqlModelElement
	{		
		String PropertyName 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlDataTypeReference> ClrType 
		{
			get;
		}
	}
    public interface ISql110TSqlColumnStoreIndexReference : ISql110TSqlColumnStoreIndex
	{
    }
	public interface ISql110TSqlColumnStoreIndex : ISqlModelElement
	{		
		Boolean Clustered 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlColumnReference> Columns 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlDataCompressionOption> DataCompressionOptions 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlFilegroupReference> Filegroup 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISpecifiesIndex> IndexedObject 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlColumnReference> PartitionColumn 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlPartitionSchemeReference> PartitionScheme 
		{
			get;
		}
	}
    public interface ISql110TSqlContractReference : ISql110TSqlContract
	{
    }
	public interface ISql110TSqlContract : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlMessageTypeReference> Messages 
		{
			get;
		}
	}
    public interface ISql110TSqlCredentialReference : ISql110TSqlCredential
	{
    }
	public interface ISql110TSqlCredential : ISqlModelElement
	{		
		String Identity 
		{
			get;
		}
		String Secret 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlCryptographicProviderReference> CryptographicProvider 
		{
			get;
		}
	}
    public interface ISql110TSqlDatabaseCredentialReference : ISql110TSqlDatabaseCredential
	{
    }
	public interface ISql110TSqlDatabaseCredential : ISqlModelElement
	{		
	}
    public interface ISql110TSqlCryptographicProviderReference : ISql110TSqlCryptographicProvider
	{
    }
	public interface ISql110TSqlCryptographicProvider : ISqlModelElement
	{		
		String DllPath 
		{
			get;
		}
		Boolean Enabled 
		{
			get;
		}
	}
    public interface ISql110TSqlDatabaseAuditSpecificationReference : ISql110TSqlDatabaseAuditSpecification
	{
    }
	public interface ISql110TSqlDatabaseAuditSpecification : ISqlModelElement
	{		
		Boolean WithState 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlAuditActionGroup> AuditActionGroups 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlAuditAction> AuditActions 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlServerAuditReference> ServerAudit 
		{
			get;
		}
	}
    public interface ISql110TSqlDatabaseDdlTriggerReference : ISql110TSqlDatabaseDdlTrigger
	{
    }
	public interface ISql110TSqlDatabaseDdlTrigger : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		String ClassName 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Boolean ExecuteAsCaller 
		{
			get;
		}
		Boolean ExecuteAsOwner 
		{
			get;
		}
		Boolean ExecuteAsSelf 
		{
			get;
		}
		String MethodName 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		TriggerType TriggerType 
		{
			get;
		}
		Boolean WithEncryption 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlAssemblyReference> Assembly 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BodyDependencies 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlEventGroup> EventGroup 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Model.EventType> EventType 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlLoginReference> Login 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlUserReference> User 
		{
			get;
		}
	}
    public interface ISql110TSqlDatabaseEncryptionKeyReference : ISql110TSqlDatabaseEncryptionKey
	{
    }
	public interface ISql110TSqlDatabaseEncryptionKey : ISqlModelElement
	{		
		SymmetricKeyAlgorithm Algorithm 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlAsymmetricKeyReference> AsymmetricKey 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlCertificateReference> Certificate 
		{
			get;
		}
	}
    public interface ISql110TSqlDatabaseEventNotificationReference : ISql110TSqlDatabaseEventNotification
	{
    }
	public interface ISql110TSqlDatabaseEventNotification : ISqlModelElement
	{		
		String BrokerInstanceSpecifier 
		{
			get;
		}
		String BrokerService 
		{
			get;
		}
		Boolean WithFanIn 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlEventGroup> EventGroup 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Model.EventType> EventType 
		{
			get;
		}
	}
    public interface ISql110TSqlDatabaseMirroringLanguageSpecifierReference : ISql110TSqlDatabaseMirroringLanguageSpecifier
	{
    }
	public interface ISql110TSqlDatabaseMirroringLanguageSpecifier : ISqlModelElement
	{		
		ServiceBrokerEncryptionAlgorithm EncryptionAlgorithmPart1 
		{
			get;
		}
		ServiceBrokerEncryptionAlgorithm EncryptionAlgorithmPart2 
		{
			get;
		}
		EncryptionMode EncryptionMode 
		{
			get;
		}
		DatabaseMirroringRole RoleType 
		{
			get;
		}
		Boolean UseCertificateFirst 
		{
			get;
		}
		AuthenticationModes WindowsAuthenticationMode 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlCertificateReference> AuthenticationCertificate 
		{
			get;
		}
	}
    public interface ISql110TSqlDatabaseOptionsReference : ISql110TSqlDatabaseOptions
	{
    }
	public interface ISql110TSqlDatabaseOptions : ISqlModelElement
	{		
		Boolean AllowSnapshotIsolation 
		{
			get;
		}
		Boolean AnsiNullDefaultOn 
		{
			get;
		}
		Boolean AnsiNullsOn 
		{
			get;
		}
		Boolean AnsiPaddingOn 
		{
			get;
		}
		Boolean AnsiWarningsOn 
		{
			get;
		}
		Boolean ArithAbortOn 
		{
			get;
		}
		Boolean AutoClose 
		{
			get;
		}
		Boolean AutoCreateStatistics 
		{
			get;
		}
		Boolean AutoShrink 
		{
			get;
		}
		Boolean AutoUpdateStatistics 
		{
			get;
		}
		Boolean AutoUpdateStatisticsAsync 
		{
			get;
		}
		Boolean ChangeTrackingAutoCleanup 
		{
			get;
		}
		Boolean ChangeTrackingEnabled 
		{
			get;
		}
		Int32 ChangeTrackingRetentionPeriod 
		{
			get;
		}
		TimeUnit ChangeTrackingRetentionUnit 
		{
			get;
		}
		String Collation 
		{
			get;
		}
		Int32 CompatibilityLevel 
		{
			get;
		}
		Boolean ConcatNullYieldsNull 
		{
			get;
		}
		Containment Containment 
		{
			get;
		}
		Boolean CursorCloseOnCommit 
		{
			get;
		}
		Boolean CursorDefaultGlobalScope 
		{
			get;
		}
		Boolean DatabaseStateOffline 
		{
			get;
		}
		Boolean DateCorrelationOptimizationOn 
		{
			get;
		}
		Boolean DBChainingOn 
		{
			get;
		}
		String DefaultFullTextLanguage 
		{
			get;
		}
		String DefaultLanguage 
		{
			get;
		}
		String FileStreamDirectoryName 
		{
			get;
		}
		Boolean FullTextEnabled 
		{
			get;
		}
		Boolean HonorBrokerPriority 
		{
			get;
		}
		Boolean MemoryOptimizedElevateToSnapshot 
		{
			get;
		}
		Boolean NestedTriggersOn 
		{
			get;
		}
		NonTransactedFileStreamAccess NonTransactedFileStreamAccess 
		{
			get;
		}
		Boolean NumericRoundAbortOn 
		{
			get;
		}
		PageVerifyMode PageVerifyMode 
		{
			get;
		}
		ParameterizationOption ParameterizationOption 
		{
			get;
		}
		Boolean QuotedIdentifierOn 
		{
			get;
		}
		Boolean ReadOnly 
		{
			get;
		}
		RecoveryMode RecoveryMode 
		{
			get;
		}
		Boolean RecursiveTriggersOn 
		{
			get;
		}
		ServiceBrokerOption ServiceBrokerOption 
		{
			get;
		}
		Boolean SupplementalLoggingOn 
		{
			get;
		}
		Int32 TargetRecoveryTimePeriod 
		{
			get;
		}
		TimeUnit TargetRecoveryTimeUnit 
		{
			get;
		}
		Boolean TornPageProtectionOn 
		{
			get;
		}
		Boolean TransactionIsolationReadCommittedSnapshot 
		{
			get;
		}
		Boolean TransformNoiseWords 
		{
			get;
		}
		Boolean Trustworthy 
		{
			get;
		}
		Int16 TwoDigitYearCutoff 
		{
			get;
		}
		UserAccessOption UserAccessOption 
		{
			get;
		}
		Boolean VardecimalStorageFormatOn 
		{
			get;
		}
		Boolean WithEncryption 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlFilegroupReference> DefaultFilegroup 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlFilegroupReference> DefaultFileStreamFilegroup 
		{
			get;
		}
	}
    public interface ISql110TSqlDataCompressionOptionReference : ISql110TSqlDataCompressionOption
	{
    }
	public interface ISql110TSqlDataCompressionOption : ISqlModelElement
	{		
		CompressionLevel CompressionLevel 
		{
			get;
		}
		Int32 PartitionNumber 
		{
			get;
		}
	}
    public interface ISql110TSqlDefaultReference : ISql110TSqlDefault
	{
    }
	public interface ISql110TSqlDefault : ISqlModelElement
	{		
		String Expression 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BoundObjects 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISql110TSqlDefaultConstraintReference : ISql110TSqlDefaultConstraint
	{
    }
	public interface ISql110TSqlDefaultConstraint : ISqlModelElement
	{		
		Boolean Disabled 
		{
			get;
		}
		String Expression 
		{
			get;
		}
		Boolean WithValues 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ExpressionDependencies 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlTableReference> Host 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlColumnReference> TargetColumn 
		{
			get;
		}
	}
    public interface ISql110TSqlDmlTriggerReference : ISql110TSqlDmlTrigger
	{
    }
	public interface ISql110TSqlDmlTrigger : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		String ClassName 
		{
			get;
		}
		OrderRestriction DeleteOrderRestriction 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Boolean ExecuteAsCaller 
		{
			get;
		}
		Boolean ExecuteAsOwner 
		{
			get;
		}
		Boolean ExecuteAsSelf 
		{
			get;
		}
		OrderRestriction InsertOrderRestriction 
		{
			get;
		}
		Boolean IsDeleteTrigger 
		{
			get;
		}
		Boolean IsInsertTrigger 
		{
			get;
		}
		Boolean IsUpdateTrigger 
		{
			get;
		}
		String MethodName 
		{
			get;
		}
		Boolean NotForReplication 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		TriggerType TriggerType 
		{
			get;
		}
		OrderRestriction UpdateOrderRestriction 
		{
			get;
		}
		Boolean WithAppend 
		{
			get;
		}
		Boolean WithEncryption 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlAssemblyReference> Assembly 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BodyDependencies 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlLoginReference> Login 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> TriggerObject 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlUserReference> User 
		{
			get;
		}
	}
    public interface ISql110TSqlEndpointReference : ISql110TSqlEndpoint
	{
    }
	public interface ISql110TSqlEndpoint : ISqlModelElement
	{		
		Payload Payload 
		{
			get;
		}
		Protocol Protocol 
		{
			get;
		}
		State State 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.IEndpointLanguageSpecifier> PayloadSpecifier 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.IProtocolSpecifier > ProtocolSpecifier 
		{
			get;
		}
	}
    public interface ISql110TSqlErrorMessageReference : ISql110TSqlErrorMessage
	{
    }
	public interface ISql110TSqlErrorMessage : ISqlModelElement
	{		
		String Language 
		{
			get;
		}
		Int32 MessageNumber 
		{
			get;
		}
		String MessageText 
		{
			get;
		}
		Int32 Severity 
		{
			get;
		}
		Boolean WithLog 
		{
			get;
		}
	}
    public interface ISql110TSqlEventGroupReference : ISql110TSqlEventGroup
	{
    }
	public interface ISql110TSqlEventGroup : ISqlModelElement
	{		
		EventGroupType Group 
		{
			get;
		}
	}
    public interface ISql110TSqlEventSessionReference : ISql110TSqlEventSession
	{
    }
	public interface ISql110TSqlEventSession : ISqlModelElement
	{		
		EventRetentionMode EventRetentionMode 
		{
			get;
		}
		Int32 MaxDispatchLatency 
		{
			get;
		}
		Int32 MaxEventSize 
		{
			get;
		}
		MemoryUnit MaxEventSizeUnit 
		{
			get;
		}
		Int32 MaxMemory 
		{
			get;
		}
		MemoryUnit MaxMemoryUnit 
		{
			get;
		}
		MemoryPartitionMode MemoryPartitionMode 
		{
			get;
		}
		EventSessionScope SessionScope 
		{
			get;
		}
		Boolean StartupState 
		{
			get;
		}
		Boolean TrackCausality 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.TSqlModelElement> EventDefinitions 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.TSqlModelElement> EventTargets 
		{
			get;
		}
	}
    public interface ISql110TSqlDatabaseEventSessionReference : ISql110TSqlDatabaseEventSession
	{
    }
	public interface ISql110TSqlDatabaseEventSession : ISqlModelElement
	{		
		EventRetentionMode EventRetentionMode 
		{
			get;
		}
		Int32 MaxDispatchLatency 
		{
			get;
		}
		Int32 MaxEventSize 
		{
			get;
		}
		MemoryUnit MaxEventSizeUnit 
		{
			get;
		}
		Int32 MaxMemory 
		{
			get;
		}
		MemoryUnit MaxMemoryUnit 
		{
			get;
		}
		MemoryPartitionMode MemoryPartitionMode 
		{
			get;
		}
		EventSessionScope SessionScope 
		{
			get;
		}
		Boolean StartupState 
		{
			get;
		}
		Boolean TrackCausality 
		{
			get;
		}
		//Composing
		IEnumerable<TSqlModelElementReference> EventDefinitions 
		{
			get;
		}
		//Composing
		IEnumerable<TSqlModelElementReference> EventTargets 
		{
			get;
		}
	}
    public interface ISql110TSqlEventSessionActionReference : ISql110TSqlEventSessionAction
	{
    }
	public interface ISql110TSqlEventSessionAction : ISqlModelElement
	{		
		String ActionName 
		{
			get;
		}
		String EventModuleGuid 
		{
			get;
		}
		String EventPackageName 
		{
			get;
		}
	}
    public interface ISql110TSqlEventSessionDefinitionsReference : ISql110TSqlEventSessionDefinitions
	{
    }
	public interface ISql110TSqlEventSessionDefinitions : ISqlModelElement
	{		
		String EventModuleGuid 
		{
			get;
		}
		String EventName 
		{
			get;
		}
		String EventPackageName 
		{
			get;
		}
		String WhereExpression 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlEventSessionAction> Actions 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.TSqlModelElement> AttributeSettings 
		{
			get;
		}
	}
    public interface ISql110TSqlEventSessionSettingReference : ISql110TSqlEventSessionSetting
	{
    }
	public interface ISql110TSqlEventSessionSetting : ISqlModelElement
	{		
		String SettingName 
		{
			get;
		}
		String SettingValue 
		{
			get;
		}
	}
    public interface ISql110TSqlEventSessionTargetReference : ISql110TSqlEventSessionTarget
	{
    }
	public interface ISql110TSqlEventSessionTarget : ISqlModelElement
	{		
		String EventModuleGuid 
		{
			get;
		}
		String EventPackageName 
		{
			get;
		}
		String TargetName 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.TSqlModelElement> ParameterSettings 
		{
			get;
		}
	}
    public interface ISql110TSqlEventTypeSpecifierReference : ISql110TSqlEventTypeSpecifier
	{
    }
	public interface ISql110TSqlEventTypeSpecifier : ISqlModelElement
	{		
		EventType EventType 
		{
			get;
		}
		OrderRestriction Order 
		{
			get;
		}
	}
    public interface ISql110TSqlExtendedProcedureReference : ISql110TSqlExtendedProcedure
	{
    }
	public interface ISql110TSqlExtendedProcedure : ISqlModelElement
	{		
		Boolean ExeccuteAsCaller 
		{
			get;
		}
		Boolean ExecuteAsOwner 
		{
			get;
		}
		Boolean ExecuteAsSelf 
		{
			get;
		}
		Boolean WithEncryption 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlLoginReference> Login 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlParameter> Parameters 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlSchemaReference> Schema 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlUserReference> User 
		{
			get;
		}
	}
    public interface ISql110TSqlExtendedPropertyReference : ISql110TSqlExtendedProperty
	{
    }
	public interface ISql110TSqlExtendedProperty : ISqlModelElement
	{		
		String Value 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.IExtendedPropertyHost> Host 
		{
			get;
		}
	}
    public interface ISql110TSqlExternalDataSourceReference : ISql110TSqlExternalDataSource
	{
    }
	public interface ISql110TSqlExternalDataSource : ISqlModelElement
	{		
	}
    public interface ISql110TSqlExternalFileFormatReference : ISql110TSqlExternalFileFormat
	{
    }
	public interface ISql110TSqlExternalFileFormat : ISqlModelElement
	{		
	}
    public interface ISql110TSqlExternalTableReference : ISql110TSqlExternalTable
	{
    }
	public interface ISql110TSqlExternalTable : ISqlModelElement
	{		
		Boolean? IsAnsiNullsOn 
		{
			get;
		}
		Boolean? IsFileStreamNull 
		{
			get;
		}
		Boolean? IsQuotedIdentifierOn 
		{
			get;
		}
		Boolean IsTableLockOnBulkLoad 
		{
			get;
		}
		LockEscalationMethod LockEscalation 
		{
			get;
		}
		//Composing
		IEnumerable<TSqlModelElementReference> Columns 
		{
			get;
		}
		//Composing
		IEnumerable<TSqlModelElementReference> DataCompressionOptions 
		{
			get;
		}
		//Peer
		IEnumerable<TSqlModelElementReference> Filegroup 
		{
			get;
		}
		//Peer
		IEnumerable<TSqlModelElementReference> FileStreamFilegroup 
		{
			get;
		}
		//Peer
		IEnumerable<TSqlModelElementReference> FileStreamPartitionScheme 
		{
			get;
		}
		//Peer
		IEnumerable<TSqlModelElementReference> PartitionColumn 
		{
			get;
		}
		//Peer
		IEnumerable<TSqlModelElementReference> PartitionScheme 
		{
			get;
		}
		//Hierarchical
		IEnumerable<TSqlModelElementReference> Schema 
		{
			get;
		}
	}
    public interface ISql110TSqlSqlFileReference : ISql110TSqlSqlFile
	{
    }
	public interface ISql110TSqlSqlFile : ISqlModelElement
	{		
		Int32? FileGrowth 
		{
			get;
		}
		MemoryUnit FileGrowthUnit 
		{
			get;
		}
		String FileName 
		{
			get;
		}
		Boolean IsLogFile 
		{
			get;
		}
		Int32? MaxSize 
		{
			get;
		}
		MemoryUnit MaxSizeUnit 
		{
			get;
		}
		Boolean Offline 
		{
			get;
		}
		Int32? Size 
		{
			get;
		}
		MemoryUnit SizeUnit 
		{
			get;
		}
		Boolean Unlimited 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlFilegroupReference> Filegroup 
		{
			get;
		}
	}
    public interface ISql110TSqlFilegroupReference : ISql110TSqlFilegroup
	{
    }
	public interface ISql110TSqlFilegroup : ISqlModelElement
	{		
		Boolean ContainsFileStream 
		{
			get;
		}
		Boolean ReadOnly 
		{
			get;
		}
	}
    public interface ISql110TSqlForeignKeyConstraintReference : ISql110TSqlForeignKeyConstraint
	{
    }
	public interface ISql110TSqlForeignKeyConstraint : ISqlModelElement
	{		
		ForeignKeyAction DeleteAction 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Boolean NotForReplication 
		{
			get;
		}
		ForeignKeyAction UpdateAction 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlColumnReference> Columns 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlColumnReference> ForeignColumns 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlTableReference> ForeignTable 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlTableReference> Host 
		{
			get;
		}
	}
    public interface ISql110TSqlFullTextCatalogReference : ISql110TSqlFullTextCatalog
	{
    }
	public interface ISql110TSqlFullTextCatalog : ISqlModelElement
	{		
		Boolean? AccentSensitivity 
		{
			get;
		}
		Boolean IsDefault 
		{
			get;
		}
		String Path 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlFilegroupReference> Filegroup 
		{
			get;
		}
	}
    public interface ISql110TSqlFullTextIndexReference : ISql110TSqlFullTextIndex
	{
    }
	public interface ISql110TSqlFullTextIndex : ISqlModelElement
	{		
		ChangeTrackingOption ChangeTracking 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Boolean Replicated 
		{
			get;
		}
		Boolean StopListOff 
		{
			get;
		}
		Boolean UseSystemStopList 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.TSqlModelElementReference> Catalog 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlFullTextIndexColumnSpecifier> Columns 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlFilegroupReference> Filegroup 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISpecifiesIndex> IndexedObject 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlSearchPropertyListReference> SearchPropertyList 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> StopList 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> UniqueIndexName 
		{
			get;
		}
	}
    public interface ISql110TSqlFullTextIndexColumnSpecifierReference : ISql110TSqlFullTextIndexColumnSpecifier
	{
    }
	public interface ISql110TSqlFullTextIndexColumnSpecifier : ISqlModelElement
	{		
		Int32? LanguageId 
		{
			get;
		}
		Boolean PartOfStatisticalSemantics 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlColumnReference> Column 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlColumnReference> TypeColumn 
		{
			get;
		}
	}
    public interface ISql110TSqlFullTextStopListReference : ISql110TSqlFullTextStopList
	{
    }
	public interface ISql110TSqlFullTextStopList : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
	}
    public interface ISql110TSqlHttpProtocolSpecifierReference : ISql110TSqlHttpProtocolSpecifier
	{
    }
	public interface ISql110TSqlHttpProtocolSpecifier : ISqlModelElement
	{		
	}
    public interface ISql110TSqlLinkedServerReference : ISql110TSqlLinkedServer
	{
    }
	public interface ISql110TSqlLinkedServer : ISqlModelElement
	{		
		String Catalog 
		{
			get;
		}
		Boolean CollationCompatible 
		{
			get;
		}
		String CollationName 
		{
			get;
		}
		Int32 ConnectTimeout 
		{
			get;
		}
		Boolean DataAccess 
		{
			get;
		}
		String DataSource 
		{
			get;
		}
		Boolean IsDistributor 
		{
			get;
		}
		Boolean IsPublisher 
		{
			get;
		}
		Boolean IsSubscriber 
		{
			get;
		}
		Boolean LazySchemaValidationEnabled 
		{
			get;
		}
		String Location 
		{
			get;
		}
		String ProductName 
		{
			get;
		}
		String ProviderName 
		{
			get;
		}
		String ProviderString 
		{
			get;
		}
		Int32 QueryTimeout 
		{
			get;
		}
		Boolean RemoteProcTransactionPromotionEnabled 
		{
			get;
		}
		Boolean RpcEnabled 
		{
			get;
		}
		Boolean RpcOutEnabled 
		{
			get;
		}
		Boolean UseRemoteCollation 
		{
			get;
		}
	}
    public interface ISql110TSqlLinkedServerLoginReference : ISql110TSqlLinkedServerLogin
	{
    }
	public interface ISql110TSqlLinkedServerLogin : ISqlModelElement
	{		
		String LinkedServerLoginName 
		{
			get;
		}
		String LinkedServerPassword 
		{
			get;
		}
		Boolean UseSelf 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlLinkedServerReference> LinkedServer 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlLoginReference> LocalLogin 
		{
			get;
		}
	}
    public interface ISql110TSqlLoginReference : ISql110TSqlLogin
	{
    }
	public interface ISql110TSqlLogin : ISqlModelElement
	{		
		Boolean CheckExpiration 
		{
			get;
		}
		Boolean CheckPolicy 
		{
			get;
		}
		String DefaultDatabase 
		{
			get;
		}
		String DefaultLanguage 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		LoginEncryptionOption EncryptionOption 
		{
			get;
		}
		Boolean MappedToWindowsLogin 
		{
			get;
		}
		String Password 
		{
			get;
		}
		Boolean PasswordHashed 
		{
			get;
		}
		Boolean PasswordMustChange 
		{
			get;
		}
		String Sid 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlAsymmetricKeyReference> AsymmetricKey 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlCertificateReference> Certificate 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlCredentialReference> Credential 
		{
			get;
		}
	}
    public interface ISql110TSqlMasterKeyReference : ISql110TSqlMasterKey
	{
    }
	public interface ISql110TSqlMasterKey : ISqlModelElement
	{		
		String Password 
		{
			get;
		}
	}
    public interface ISql110TSqlMessageTypeReference : ISql110TSqlMessageType
	{
    }
	public interface ISql110TSqlMessageType : ISqlModelElement
	{		
		ValidationMethod ValidationMethod 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlXmlSchemaCollectionReference> XmlSchemaCollection 
		{
			get;
		}
	}
    public interface ISql110TSqlPartitionFunctionReference : ISql110TSqlPartitionFunction
	{
    }
	public interface ISql110TSqlPartitionFunction : ISqlModelElement
	{		
		PartitionRange Range 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlPartitionValue> BoundaryValues 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlDataTypeReference> ParameterType 
		{
			get;
		}
	}
    public interface ISql110TSqlPartitionSchemeReference : ISql110TSqlPartitionScheme
	{
    }
	public interface ISql110TSqlPartitionScheme : ISqlModelElement
	{		
		Boolean AllToOneFilegroup 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlFilegroupReference> Filegroups 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlPartitionFunctionReference> PartitionFunction 
		{
			get;
		}
	}
    public interface ISql110TSqlPartitionValueReference : ISql110TSqlPartitionValue
	{
    }
	public interface ISql110TSqlPartitionValue : ISqlModelElement
	{		
		String Expression 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ExpressionDependencies 
		{
			get;
		}
	}
    public interface ISql110TSqlPermissionReference : ISql110TSqlPermission
	{
    }
	public interface ISql110TSqlPermission : ISqlModelElement
	{		
		PermissionAction PermissionAction 
		{
			get;
		}
		PermissionType PermissionType 
		{
			get;
		}
		Boolean WithAllPrivileges 
		{
			get;
		}
		Boolean WithGrantOption 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlColumnReference> ExcludedColumns 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlSecurityPrincipal> Grantee 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlSecurityPrincipal> Grantor 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlColumnReference> RevokedGrantOptionColumns 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlSecurable> SecuredObject 
		{
			get;
		}
	}
    public interface ISql110TSqlPrimaryKeyConstraintReference : ISql110TSqlPrimaryKeyConstraint
	{
    }
	public interface ISql110TSqlPrimaryKeyConstraint : ISqlModelElement
	{		
		Boolean AllowPageLocks 
		{
			get;
		}
		Boolean AllowRowLocks 
		{
			get;
		}
		Int32? BucketCount 
		{
			get;
		}
		Boolean Clustered 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Boolean? FileStreamNull 
		{
			get;
		}
		Int32? FillFactor 
		{
			get;
		}
		Boolean Hash 
		{
			get;
		}
		Boolean IgnoreDuplicateKey 
		{
			get;
		}
		Boolean RecomputeStatistics 
		{
			get;
		}
		Boolean WithPadIndex 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlColumnReference> Columns 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlDataCompressionOption> DataCompressionOptions 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlFilegroupReference> Filegroup 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlFilegroupReference> FileStreamFilegroup 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlPartitionSchemeReference> FileStreamPartitionScheme 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlTableReference> Host 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlColumnReference> PartitionColumn 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlPartitionSchemeReference> PartitionScheme 
		{
			get;
		}
	}
    public interface ISql110TSqlProcedureReference : ISql110TSqlProcedure
	{
    }
	public interface ISql110TSqlProcedure : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		String ClassName 
		{
			get;
		}
		Boolean ExecuteAsCaller 
		{
			get;
		}
		Boolean ExecuteAsOwner 
		{
			get;
		}
		Boolean ExecuteAsSelf 
		{
			get;
		}
		Boolean ForReplication 
		{
			get;
		}
		Boolean IsReplicated 
		{
			get;
		}
		String MethodName 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		Boolean WithEncryption 
		{
			get;
		}
		Boolean WithRecompile 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlAssemblyReference> Assembly 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BodyDependencies 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlLoginReference> Login 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlParameter> Parameters 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlProcedureReference> ParentProcedure 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlSchemaReference> Schema 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlUserReference> User 
		{
			get;
		}
	}
    public interface ISql110TSqlQueueReference : ISql110TSqlQueue
	{
    }
	public interface ISql110TSqlQueue : ISqlModelElement
	{		
		Boolean ActivationExecuteAsCaller 
		{
			get;
		}
		Boolean ActivationExecuteAsOwner 
		{
			get;
		}
		Boolean ActivationExecuteAsSelf 
		{
			get;
		}
		Int32? ActivationMaxQueueReaders 
		{
			get;
		}
		Boolean? ActivationStatusOn 
		{
			get;
		}
		Boolean PoisonMessageHandlingStatusOn 
		{
			get;
		}
		Boolean RetentionOn 
		{
			get;
		}
		Boolean StatusOn 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlProcedureReference> ActivationProcedure 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlColumn> Columns 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlFilegroupReference> Filegroup 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlLoginReference> Login 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlColumnReference> PartitionColumn 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlPartitionSchemeReference> PartitionScheme 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlSchemaReference> Schema 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlUserReference> User 
		{
			get;
		}
	}
    public interface ISql110TSqlQueueEventNotificationReference : ISql110TSqlQueueEventNotification
	{
    }
	public interface ISql110TSqlQueueEventNotification : ISqlModelElement
	{		
		String BrokerInstanceSpecifier 
		{
			get;
		}
		String BrokerService 
		{
			get;
		}
		Boolean WithFanIn 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlEventGroup> EventGroup 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Model.EventType> EventType 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlQueueReference> Queue 
		{
			get;
		}
	}
    public interface ISql110TSqlRemoteServiceBindingReference : ISql110TSqlRemoteServiceBinding
	{
    }
	public interface ISql110TSqlRemoteServiceBinding : ISqlModelElement
	{		
		Boolean Anonymous 
		{
			get;
		}
		String Service 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlUserReference> User 
		{
			get;
		}
	}
    public interface ISql110TSqlResourceGovernorReference : ISql110TSqlResourceGovernor
	{
    }
	public interface ISql110TSqlResourceGovernor : ISqlModelElement
	{		
		Boolean? Enabled 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ClassifierFunction 
		{
			get;
		}
	}
    public interface ISql110TSqlResourcePoolReference : ISql110TSqlResourcePool
	{
    }
	public interface ISql110TSqlResourcePool : ISqlModelElement
	{		
		Int32 CapCpuPercent 
		{
			get;
		}
		Int32 MaxCpuPercent 
		{
			get;
		}
		Int32 MaxMemoryPercent 
		{
			get;
		}
		Int32 MinCpuPercent 
		{
			get;
		}
		Int32 MinMemoryPercent 
		{
			get;
		}
	}
    public interface ISql110TSqlRoleReference : ISql110TSqlRole
	{
    }
	public interface ISql110TSqlRole : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
	}
    public interface ISql110TSqlRoleMembershipReference : ISql110TSqlRoleMembership
	{
    }
	public interface ISql110TSqlRoleMembership : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlDatabaseSecurityPrincipal> Member 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlRoleReference> Role 
		{
			get;
		}
	}
    public interface ISql110TSqlRouteReference : ISql110TSqlRoute
	{
    }
	public interface ISql110TSqlRoute : ISqlModelElement
	{		
		String Address 
		{
			get;
		}
		String BrokerInstance 
		{
			get;
		}
		Int32? Lifetime 
		{
			get;
		}
		String MirrorAddress 
		{
			get;
		}
		String ServiceName 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
	}
    public interface ISql110TSqlRuleReference : ISql110TSqlRule
	{
    }
	public interface ISql110TSqlRule : ISqlModelElement
	{		
		String Expression 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BoundObjects 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISql110TSqlSchemaReference : ISql110TSqlSchema
	{
    }
	public interface ISql110TSqlSchema : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
	}
    public interface ISql110TSqlSearchPropertyReference : ISql110TSqlSearchProperty
	{
    }
	public interface ISql110TSqlSearchProperty : ISqlModelElement
	{		
		String Description 
		{
			get;
		}
		Int32 Identifier 
		{
			get;
		}
		String PropertySetGuid 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlSearchPropertyListReference> SearchPropertyList 
		{
			get;
		}
	}
    public interface ISql110TSqlSearchPropertyListReference : ISql110TSqlSearchPropertyList
	{
    }
	public interface ISql110TSqlSearchPropertyList : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
	}
    public interface ISql110TSqlSecurityPolicyReference : ISql110TSqlSecurityPolicy
	{
    }
	public interface ISql110TSqlSecurityPolicy : ISqlModelElement
	{		
		Boolean Enabled 
		{
			get;
		}
		Boolean IsSchemaBound 
		{
			get;
		}
		Boolean NotForReplication 
		{
			get;
		}
		//Composing
		IEnumerable<TSqlModelElementReference> Predicates 
		{
			get;
		}
		//Hierarchical
		IEnumerable<TSqlModelElementReference> Schema 
		{
			get;
		}
	}
    public interface ISql110TSqlSecurityPredicateReference : ISql110TSqlSecurityPredicate
	{
    }
	public interface ISql110TSqlSecurityPredicate : ISqlModelElement
	{		
		String BodyScript 
		{
			get;
		}
		SecurityPredicateOperation Operation 
		{
			get;
		}
		SecurityPredicateType PredicateType 
		{
			get;
		}
		//Peer
		IEnumerable<TSqlModelElementReference> BodyDependencies 
		{
			get;
		}
		//Peer
		IEnumerable<TSqlModelElementReference> TargetObject 
		{
			get;
		}
	}
    public interface ISql110TSqlSequenceReference : ISql110TSqlSequence
	{
    }
	public interface ISql110TSqlSequence : ISqlModelElement
	{		
		Int32? CacheSize 
		{
			get;
		}
		String IncrementValue 
		{
			get;
		}
		Boolean IsCached 
		{
			get;
		}
		Boolean IsCycling 
		{
			get;
		}
		String MaxValue 
		{
			get;
		}
		String MinValue 
		{
			get;
		}
		Boolean NoMaxValue 
		{
			get;
		}
		Boolean NoMinValue 
		{
			get;
		}
		String StartValue 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlDataTypeReference> DataType 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISql110TSqlServerAuditReference : ISql110TSqlServerAudit
	{
    }
	public interface ISql110TSqlServerAudit : ISqlModelElement
	{		
		String AuditGuid 
		{
			get;
		}
		AuditTarget AuditTarget 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		String FilePath 
		{
			get;
		}
		Int32? MaxFiles 
		{
			get;
		}
		Int32? MaxRolloverFiles 
		{
			get;
		}
		Int32? MaxSize 
		{
			get;
		}
		MemoryUnit MaxSizeUnit 
		{
			get;
		}
		FailureAction OnFailure 
		{
			get;
		}
		String PredicateExpression 
		{
			get;
		}
		Int32 QueueDelay 
		{
			get;
		}
		Boolean ReserveDiskSpace 
		{
			get;
		}
		Boolean UnlimitedFileSize 
		{
			get;
		}
		Boolean UnlimitedMaxRolloverFiles 
		{
			get;
		}
	}
    public interface ISql110TSqlServerAuditSpecificationReference : ISql110TSqlServerAuditSpecification
	{
    }
	public interface ISql110TSqlServerAuditSpecification : ISqlModelElement
	{		
		Boolean StateOn 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlAuditActionGroup> AuditActionGroups 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlServerAuditReference> ServerAudit 
		{
			get;
		}
	}
    public interface ISql110TSqlServerDdlTriggerReference : ISql110TSqlServerDdlTrigger
	{
    }
	public interface ISql110TSqlServerDdlTrigger : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		String ClassName 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Boolean ExecuteAsCaller 
		{
			get;
		}
		Boolean ExecuteAsOwner 
		{
			get;
		}
		Boolean ExecuteAsSelf 
		{
			get;
		}
		Boolean IsLogon 
		{
			get;
		}
		String MethodName 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		TriggerType TriggerType 
		{
			get;
		}
		Boolean WithEncryption 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlAssemblyReference> Assembly 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BodyDependencies 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlEventGroup> EventGroup 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Model.EventType> EventType 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlLoginReference> Login 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlUserReference> User 
		{
			get;
		}
	}
    public interface ISql110TSqlServerEventNotificationReference : ISql110TSqlServerEventNotification
	{
    }
	public interface ISql110TSqlServerEventNotification : ISqlModelElement
	{		
		String BrokerInstanceSpecifier 
		{
			get;
		}
		String BrokerService 
		{
			get;
		}
		Boolean WithFanIn 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlEventGroup> EventGroup 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Model.EventType> EventType 
		{
			get;
		}
	}
    public interface ISql110TSqlServerOptionsReference : ISql110TSqlServerOptions
	{
    }
	public interface ISql110TSqlServerOptions : ISqlModelElement
	{		
	}
    public interface ISql110TSqlServerRoleMembershipReference : ISql110TSqlServerRoleMembership
	{
    }
	public interface ISql110TSqlServerRoleMembership : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.IServerSecurityPrincipal> Member 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlRoleReference> Role 
		{
			get;
		}
	}
    public interface ISql110TSqlServiceReference : ISql110TSqlService
	{
    }
	public interface ISql110TSqlService : ISqlModelElement
	{		
		Boolean UseDefaultContract 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlContractReference> Contracts 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlQueueReference> Queue 
		{
			get;
		}
	}
    public interface ISql110TSqlServiceBrokerLanguageSpecifierReference : ISql110TSqlServiceBrokerLanguageSpecifier
	{
    }
	public interface ISql110TSqlServiceBrokerLanguageSpecifier : ISqlModelElement
	{		
		ServiceBrokerEncryptionAlgorithm EncryptionAlgorithmPart1 
		{
			get;
		}
		ServiceBrokerEncryptionAlgorithm EncryptionAlgorithmPart2 
		{
			get;
		}
		EncryptionMode EncryptionMode 
		{
			get;
		}
		Boolean MessageForwardingEnabled 
		{
			get;
		}
		Int32 MessageForwardSize 
		{
			get;
		}
		Boolean UseCertificateFirst 
		{
			get;
		}
		AuthenticationModes WindowsAuthenticationMode 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlCertificateReference> AuthenticationCertificate 
		{
			get;
		}
	}
    public interface ISql110TSqlSignatureReference : ISql110TSqlSignature
	{
    }
	public interface ISql110TSqlSignature : ISqlModelElement
	{		
		Boolean IsCounterSignature 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.TSqlModelElement> EncryptionMechanism 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> SignedObject 
		{
			get;
		}
	}
    public interface ISql110TSqlSignatureEncryptionMechanismReference : ISql110TSqlSignatureEncryptionMechanism
	{
    }
	public interface ISql110TSqlSignatureEncryptionMechanism : ISqlModelElement
	{		
		String Password 
		{
			get;
		}
		String SignedBlob 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlAsymmetricKeyReference> AsymmetricKey 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlCertificateReference> Certificate 
		{
			get;
		}
	}
    public interface ISql110TSqlSoapLanguageSpecifierReference : ISql110TSqlSoapLanguageSpecifier
	{
    }
	public interface ISql110TSqlSoapLanguageSpecifier : ISqlModelElement
	{		
	}
    public interface ISql110TSqlSoapMethodSpecificationReference : ISql110TSqlSoapMethodSpecification
	{
    }
	public interface ISql110TSqlSoapMethodSpecification : ISqlModelElement
	{		
	}
    public interface ISql110TSqlSpatialIndexReference : ISql110TSqlSpatialIndex
	{
    }
	public interface ISql110TSqlSpatialIndex : ISqlModelElement
	{		
		Boolean AllowPageLocks 
		{
			get;
		}
		Boolean AllowRowLocks 
		{
			get;
		}
		Int32? CellsPerObject 
		{
			get;
		}
		CompressionLevel DataCompression 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Int32 FillFactor 
		{
			get;
		}
		Degree GridLevel1Density 
		{
			get;
		}
		Degree GridLevel2Density 
		{
			get;
		}
		Degree GridLevel3Density 
		{
			get;
		}
		Degree GridLevel4Density 
		{
			get;
		}
		Boolean IgnoreDuplicateKey 
		{
			get;
		}
		Boolean RecomputeStatistics 
		{
			get;
		}
		Tessellation Tessellation 
		{
			get;
		}
		Boolean WithPadIndex 
		{
			get;
		}
		Double? XMax 
		{
			get;
		}
		Double? XMin 
		{
			get;
		}
		Double? YMax 
		{
			get;
		}
		Double? YMin 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlColumnReference> Column 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlFilegroupReference> Filegroup 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISpecifiesIndex> IndexedObject 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlColumnReference> PartitionColumn 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlPartitionSchemeReference> PartitionScheme 
		{
			get;
		}
	}
    public interface ISql110TSqlStatisticsReference : ISql110TSqlStatistics
	{
    }
	public interface ISql110TSqlStatistics : ISqlModelElement
	{		
		String FilterPredicate 
		{
			get;
		}
		Boolean NoRecompute 
		{
			get;
		}
		Int32 SampleSize 
		{
			get;
		}
		SamplingStyle SamplingStyle 
		{
			get;
		}
		String StatsStream 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlColumnReference> Columns 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ExpressionDependencies 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> OnObject 
		{
			get;
		}
	}
    public interface ISql110TSqlParameterReference : ISql110TSqlParameter
	{
    }
	public interface ISql110TSqlParameter : ISqlModelElement
	{		
		String DefaultExpression 
		{
			get;
		}
		Boolean IsMax 
		{
			get;
		}
		Boolean IsOutput 
		{
			get;
		}
		Int32 Length 
		{
			get;
		}
		Int32 Precision 
		{
			get;
		}
		Boolean ReadOnly 
		{
			get;
		}
		Int32 Scale 
		{
			get;
		}
		Boolean Varying 
		{
			get;
		}
		XmlStyle XmlStyle 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlDataType> DataType 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlXmlSchemaCollectionReference> XmlSchemaCollection 
		{
			get;
		}
	}
    public interface ISql110TSqlSymmetricKeyReference : ISql110TSqlSymmetricKey
	{
    }
	public interface ISql110TSqlSymmetricKey : ISqlModelElement
	{		
		SymmetricKeyAlgorithm Algorithm 
		{
			get;
		}
		SymmetricKeyCreationDisposition CreationDisposition 
		{
			get;
		}
		String IdentityValue 
		{
			get;
		}
		String KeySource 
		{
			get;
		}
		String ProviderKeyName 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlAsymmetricKeyReference> AsymmetricKeys 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlCertificateReference> Certificates 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.TSqlModelElement> Passwords 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> Provider 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlSymmetricKeyReference> SymmetricKeys 
		{
			get;
		}
	}
    public interface ISql110TSqlSymmetricKeyPasswordReference : ISql110TSqlSymmetricKeyPassword
	{
    }
	public interface ISql110TSqlSymmetricKeyPassword : ISqlModelElement
	{		
		String Password 
		{
			get;
		}
	}
    public interface ISql110TSqlSynonymReference : ISql110TSqlSynonym
	{
    }
	public interface ISql110TSqlSynonym : ISqlModelElement
	{		
		String ForObjectName 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ForObject 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISql110TSqlTableReference : ISql110TSqlTable
	{
    }
	public interface ISql110TSqlTable : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		Boolean ChangeDataCaptureEnabled 
		{
			get;
		}
		Boolean ChangeTrackingEnabled 
		{
			get;
		}
		Int64? DataPages 
		{
			get;
		}
		Double? DataSize 
		{
			get;
		}
		Boolean? FileStreamNull 
		{
			get;
		}
		Double? IndexSize 
		{
			get;
		}
		Boolean IsAutoGeneratedHistoryTable 
		{
			get;
		}
		Boolean IsReplicated 
		{
			get;
		}
		Boolean LargeValueTypesOutOfRow 
		{
			get;
		}
		LockEscalationMethod LockEscalation 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		Int64? RowCount 
		{
			get;
		}
		Boolean TableLockOnBulkLoad 
		{
			get;
		}
		Int32 TextInRowSize 
		{
			get;
		}
		Boolean TrackColumnsUpdated 
		{
			get;
		}
		Int64? UsedPages 
		{
			get;
		}
		Boolean VardecimalStorageFormatEnabled 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlColumn> Columns 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlDataCompressionOption> DataCompressionOptions 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlFilegroupReference> Filegroup 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlFilegroupReference> FilegroupForTextImage 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlFilegroupReference> FileStreamFilegroup 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlPartitionSchemeReference> FileStreamPartitionScheme 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlColumnReference> PartitionColumn 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlPartitionSchemeReference> PartitionScheme 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISql110TSqlFileTableReference : ISql110TSqlFileTable
	{
    }
	public interface ISql110TSqlFileTable : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		Boolean? FileStreamNull 
		{
			get;
		}
		String FileTableCollateFilename 
		{
			get;
		}
		String FileTableDirectory 
		{
			get;
		}
		Boolean FileTableNamespaceEnabled 
		{
			get;
		}
		LockEscalationMethod LockEscalation 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		Boolean TableLockOnBulkLoad 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlColumn> Columns 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlDataCompressionOption> DataCompressionOptions 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlFilegroupReference> Filegroup 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlFilegroupReference> FileStreamFilegroup 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlPartitionSchemeReference> FileStreamPartitionScheme 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlColumnReference> PartitionColumn 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlPartitionSchemeReference> PartitionScheme 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISql110TSqlTableTypeReference : ISql110TSqlTableType
	{
    }
	public interface ISql110TSqlTableType : ISqlModelElement
	{		
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlTableTypeColumn> Columns 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ITableTypeConstraint> Constraints 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISql110TSqlTableTypeCheckConstraintReference : ISql110TSqlTableTypeCheckConstraint
	{
    }
	public interface ISql110TSqlTableTypeCheckConstraint : ISqlModelElement
	{		
		String Expression 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ExpressionDependencies 
		{
			get;
		}
	}
    public interface ISql110TSqlTableTypeColumnReference : ISql110TSqlTableTypeColumn
	{
    }
	public interface ISql110TSqlTableTypeColumn : ISqlModelElement
	{		
		String Collation 
		{
			get;
		}
		String Expression 
		{
			get;
		}
		String IdentityIncrement 
		{
			get;
		}
		String IdentitySeed 
		{
			get;
		}
		Boolean IsIdentity 
		{
			get;
		}
		Boolean IsMax 
		{
			get;
		}
		Boolean IsRowGuidCol 
		{
			get;
		}
		Int32 Length 
		{
			get;
		}
		Boolean Nullable 
		{
			get;
		}
		Boolean Persisted 
		{
			get;
		}
		Boolean? PersistedNullable 
		{
			get;
		}
		Int32 Precision 
		{
			get;
		}
		Int32 Scale 
		{
			get;
		}
		XmlStyle XmlStyle 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlDataType> DataType 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ExpressionDependencies 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlXmlSchemaCollectionReference> XmlSchemaCollection 
		{
			get;
		}
	}
    public interface ISql110TSqlTableTypeDefaultConstraintReference : ISql110TSqlTableTypeDefaultConstraint
	{
    }
	public interface ISql110TSqlTableTypeDefaultConstraint : ISqlModelElement
	{		
		String Expression 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ExpressionDependencies 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlColumnReference> TargetColumn 
		{
			get;
		}
	}
    public interface ISql110TSqlTableTypeIndexReference : ISql110TSqlTableTypeIndex
	{
    }
	public interface ISql110TSqlTableTypeIndex : ISqlModelElement
	{		
		Int32? BucketCount 
		{
			get;
		}
		Boolean Hash 
		{
			get;
		}
		Boolean IsDisabled 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlColumnReference> Columns 
		{
			get;
		}
	}
    public interface ISql110TSqlTableTypePrimaryKeyConstraintReference : ISql110TSqlTableTypePrimaryKeyConstraint
	{
    }
	public interface ISql110TSqlTableTypePrimaryKeyConstraint : ISqlModelElement
	{		
		Int32? BucketCount 
		{
			get;
		}
		Boolean Clustered 
		{
			get;
		}
		Boolean Hash 
		{
			get;
		}
		Boolean IgnoreDuplicateKey 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlColumnReference> Columns 
		{
			get;
		}
	}
    public interface ISql110TSqlTableTypeUniqueConstraintReference : ISql110TSqlTableTypeUniqueConstraint
	{
    }
	public interface ISql110TSqlTableTypeUniqueConstraint : ISqlModelElement
	{		
		Int32? BucketCount 
		{
			get;
		}
		Boolean Clustered 
		{
			get;
		}
		Boolean Hash 
		{
			get;
		}
		Boolean IgnoreDuplicateKey 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlColumnReference> Columns 
		{
			get;
		}
	}
    public interface ISql110TSqlTcpProtocolSpecifierReference : ISql110TSqlTcpProtocolSpecifier
	{
    }
	public interface ISql110TSqlTcpProtocolSpecifier : ISqlModelElement
	{		
		String ListenerIPv4 
		{
			get;
		}
		String ListenerIPv6 
		{
			get;
		}
		Int32 ListenerPort 
		{
			get;
		}
		Boolean ListeningOnAllIPs 
		{
			get;
		}
	}
    public interface ISql110TSqlUniqueConstraintReference : ISql110TSqlUniqueConstraint
	{
    }
	public interface ISql110TSqlUniqueConstraint : ISqlModelElement
	{		
		Boolean AllowPageLocks 
		{
			get;
		}
		Boolean AllowRowLocks 
		{
			get;
		}
		Int32? BucketCount 
		{
			get;
		}
		Boolean Clustered 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Boolean? FileStreamNull 
		{
			get;
		}
		Int32? FillFactor 
		{
			get;
		}
		Boolean Hash 
		{
			get;
		}
		Boolean IgnoreDuplicateKey 
		{
			get;
		}
		Boolean RecomputeStatistics 
		{
			get;
		}
		Boolean WithPadIndex 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlColumnReference> Columns 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlDataCompressionOption> DataCompressionOptions 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlFilegroupReference> Filegroup 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlFilegroupReference> FileStreamFilegroup 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlPartitionSchemeReference> FileStreamPartitionScheme 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlTableReference> Host 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlColumnReference> PartitionColumn 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlPartitionSchemeReference> PartitionScheme 
		{
			get;
		}
	}
    public interface ISql110TSqlUserReference : ISql110TSqlUser
	{
    }
	public interface ISql110TSqlUser : ISqlModelElement
	{		
		AuthenticationType AuthenticationType 
		{
			get;
		}
		String DefaultLanguage 
		{
			get;
		}
		String Password 
		{
			get;
		}
		String Sid 
		{
			get;
		}
		Boolean WithoutLogin 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlAsymmetricKeyReference> AsymmetricKey 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlCertificateReference> Certificate 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlSchemaReference> DefaultSchema 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlLoginReference> Login 
		{
			get;
		}
	}
    public interface ISql110TSqlUserDefinedServerRoleReference : ISql110TSqlUserDefinedServerRole
	{
    }
	public interface ISql110TSqlUserDefinedServerRole : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
	}
    public interface ISql110TSqlUserDefinedTypeReference : ISql110TSqlUserDefinedType
	{
    }
	public interface ISql110TSqlUserDefinedType : ISqlModelElement
	{		
		Boolean? ByteOrdered 
		{
			get;
		}
		String ClassName 
		{
			get;
		}
		Boolean? FixedLength 
		{
			get;
		}
		Format Format 
		{
			get;
		}
		Int32? MaxByteSize 
		{
			get;
		}
		String ValidationMethodName 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlAssemblyReference> Assembly 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.TSqlModelElement> Methods 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.TSqlModelElement> Properties 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISql110TSqlViewReference : ISql110TSqlView
	{
    }
	public interface ISql110TSqlView : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		Boolean Replicated 
		{
			get;
		}
		String SelectStatement 
		{
			get;
		}
		Boolean WithCheckOption 
		{
			get;
		}
		Boolean WithEncryption 
		{
			get;
		}
		Boolean WithSchemaBinding 
		{
			get;
		}
		Boolean WithViewMetadata 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BodyDependencies 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlColumn> Columns 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISql110TSqlWorkloadGroupReference : ISql110TSqlWorkloadGroup
	{
    }
	public interface ISql110TSqlWorkloadGroup : ISqlModelElement
	{		
		Int32 GroupMaxRequests 
		{
			get;
		}
		Degree Importance 
		{
			get;
		}
		Int32 MaxDop 
		{
			get;
		}
		Int32 RequestMaxCpuTimeSec 
		{
			get;
		}
		Int32 RequestMaxMemoryGrantPercent 
		{
			get;
		}
		Int32 RequestMemoryGrantTimeoutSec 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlResourcePoolReference> ResourcePool 
		{
			get;
		}
	}
    public interface ISql110TSqlXmlIndexReference : ISql110TSqlXmlIndex
	{
    }
	public interface ISql110TSqlXmlIndex : ISqlModelElement
	{		
		Boolean AllowPageLocks 
		{
			get;
		}
		Boolean AllowRowLocks 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Int32? FillFactor 
		{
			get;
		}
		Boolean IgnoreDuplicateKey 
		{
			get;
		}
		Boolean IsPrimary 
		{
			get;
		}
		Boolean RecomputeStatistics 
		{
			get;
		}
		SecondaryXmlIndexType SecondaryXmlIndexType 
		{
			get;
		}
		Boolean WithPadIndex 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlColumnReference> Column 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISpecifiesIndex> IndexedObject 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlXmlIndexReference> PrimaryXmlIndex 
		{
			get;
		}
	}
    public interface ISql110TSqlSelectiveXmlIndexReference : ISql110TSqlSelectiveXmlIndex
	{
    }
	public interface ISql110TSqlSelectiveXmlIndex : ISqlModelElement
	{		
		Boolean AllowPageLocks 
		{
			get;
		}
		Boolean AllowRowLocks 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Int32? FillFactor 
		{
			get;
		}
		Boolean IgnoreDuplicateKey 
		{
			get;
		}
		Boolean IsPrimary 
		{
			get;
		}
		Boolean RecomputeStatistics 
		{
			get;
		}
		Boolean WithPadIndex 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlColumnReference> Column 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISpecifiesIndex> IndexedObject 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlPromotedNodePath> PrimaryPromotedPath 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlSelectiveXmlIndexReference> PrimarySelectiveXmlIndex 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlPromotedNodePath> PromotedPaths 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlXmlNamespace> XmlNamespaces 
		{
			get;
		}
	}
    public interface ISql110TSqlXmlNamespaceReference : ISql110TSqlXmlNamespace
	{
    }
	public interface ISql110TSqlXmlNamespace : ISqlModelElement
	{		
		String NamespaceUri 
		{
			get;
		}
		String Prefix 
		{
			get;
		}
	}
    public interface ISql110TSqlPromotedNodePathForXQueryTypeReference : ISql110TSqlPromotedNodePathForXQueryType
	{
    }
	public interface ISql110TSqlPromotedNodePathForXQueryType : ISqlModelElement
	{		
		Boolean IsSingleton 
		{
			get;
		}
		Int32? MaxLength 
		{
			get;
		}
		String NodePath 
		{
			get;
		}
		String Type 
		{
			get;
		}
	}
    public interface ISql110TSqlPromotedNodePathForSqlTypeReference : ISql110TSqlPromotedNodePathForSqlType
	{
    }
	public interface ISql110TSqlPromotedNodePathForSqlType : ISqlModelElement
	{		
		Boolean IsMax 
		{
			get;
		}
		Boolean IsSingleton 
		{
			get;
		}
		Int32 Length 
		{
			get;
		}
		String NodePath 
		{
			get;
		}
		Int32 Precision 
		{
			get;
		}
		Int32 Scale 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlDataTypeReference> DataType 
		{
			get;
		}
	}
    public interface ISql110TSqlXmlSchemaCollectionReference : ISql110TSqlXmlSchemaCollection
	{
    }
	public interface ISql110TSqlXmlSchemaCollection : ISqlModelElement
	{		
		String Expression 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql110TSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISql120TSqlColumnReference : ISql120TSqlColumn
	{
    }
	public interface ISql120TSqlColumn : ISqlModelElement
	{		
		String Collation 
		{
			get;
		}
		String Expression 
		{
			get;
		}
		String IdentityIncrement 
		{
			get;
		}
		String IdentitySeed 
		{
			get;
		}
		Boolean IsFileStream 
		{
			get;
		}
		Boolean IsIdentity 
		{
			get;
		}
		Boolean IsIdentityNotForReplication 
		{
			get;
		}
		Boolean IsMax 
		{
			get;
		}
		Boolean IsRowGuidCol 
		{
			get;
		}
		Int32 Length 
		{
			get;
		}
		Boolean Nullable 
		{
			get;
		}
		Boolean Persisted 
		{
			get;
		}
		Boolean? PersistedNullable 
		{
			get;
		}
		Int32 Precision 
		{
			get;
		}
		Int32 Scale 
		{
			get;
		}
		Boolean Sparse 
		{
			get;
		}
		XmlStyle XmlStyle 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlDataType> DataType 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ExpressionDependencies 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlXmlSchemaCollectionReference> XmlSchemaCollection 
		{
			get;
		}
	}
    public interface ISql120TSqlTableValuedFunctionReference : ISql120TSqlTableValuedFunction
	{
    }
	public interface ISql120TSqlTableValuedFunction : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		Boolean CalledOnNullInput 
		{
			get;
		}
		String ClassName 
		{
			get;
		}
		DataAccessKind? DataAccess 
		{
			get;
		}
		Boolean? Deterministic 
		{
			get;
		}
		Boolean ExecuteAsCaller 
		{
			get;
		}
		Boolean ExecuteAsOwner 
		{
			get;
		}
		Boolean ExecuteAsSelf 
		{
			get;
		}
		String FillRowMethodName 
		{
			get;
		}
		Boolean IsNativeCompiled 
		{
			get;
		}
		Boolean IsReplicated 
		{
			get;
		}
		String MethodName 
		{
			get;
		}
		Boolean? Precise 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		Boolean ReturnsNullOnNullInput 
		{
			get;
		}
		String ReturnTableVariableName 
		{
			get;
		}
		SystemDataAccessKind? SystemDataAccess 
		{
			get;
		}
		Boolean WithEncryption 
		{
			get;
		}
		Boolean WithSchemaBinding 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlAssembly> Assembly 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BodyDependencies 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlColumn> Columns 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlLoginReference> Login 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlParameter> Parameters 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlDataTypeReference> ReturnType 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlSchemaReference> Schema 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlClrTableOption> TableOption 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlUserReference> User 
		{
			get;
		}
	}
    public interface ISql120TSqlScalarFunctionReference : ISql120TSqlScalarFunction
	{
    }
	public interface ISql120TSqlScalarFunction : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		Boolean CalledOnNullInput 
		{
			get;
		}
		String ClassName 
		{
			get;
		}
		DataAccessKind? DataAccess 
		{
			get;
		}
		Boolean? Deterministic 
		{
			get;
		}
		Boolean ExecuteAsCaller 
		{
			get;
		}
		Boolean ExecuteAsOwner 
		{
			get;
		}
		Boolean ExecuteAsSelf 
		{
			get;
		}
		String FillRowMethodName 
		{
			get;
		}
		Boolean IsNativeCompiled 
		{
			get;
		}
		Boolean IsReplicated 
		{
			get;
		}
		String MethodName 
		{
			get;
		}
		Boolean? Precise 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		Boolean ReturnsNullOnNullInput 
		{
			get;
		}
		SystemDataAccessKind? SystemDataAccess 
		{
			get;
		}
		Boolean WithEncryption 
		{
			get;
		}
		Boolean WithSchemaBinding 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlAssembly> Assembly 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BodyDependencies 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlLoginReference> Login 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlParameter> Parameters 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlDataTypeReference> ReturnType 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlSchemaReference> Schema 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlUserReference> User 
		{
			get;
		}
	}
    public interface ISql120TSqlClrTableOptionReference : ISql120TSqlClrTableOption
	{
    }
	public interface ISql120TSqlClrTableOption : ISqlModelElement
	{		
		String ClassName 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlColumnReference> OrderColumns 
		{
			get;
		}
	}
    public interface ISql120TSqlAggregateReference : ISql120TSqlAggregate
	{
    }
	public interface ISql120TSqlAggregate : ISqlModelElement
	{		
		String ClassName 
		{
			get;
		}
		Format Format 
		{
			get;
		}
		Boolean? InvariantToDuplicates 
		{
			get;
		}
		Boolean? InvariantToNulls 
		{
			get;
		}
		Int32? MaxByteSize 
		{
			get;
		}
		Boolean? NullIfEmpty 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlAssemblyReference> Assembly 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlParameter> Parameters 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlDataTypeReference> ReturnType 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISql120TSqlApplicationRoleReference : ISql120TSqlApplicationRole
	{
    }
	public interface ISql120TSqlApplicationRole : ISqlModelElement
	{		
		String Password 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlSchemaReference> DefaultSchema 
		{
			get;
		}
	}
    public interface ISql120TSqlIndexReference : ISql120TSqlIndex
	{
    }
	public interface ISql120TSqlIndex : ISqlModelElement
	{		
		Boolean AllowPageLocks 
		{
			get;
		}
		Boolean AllowRowLocks 
		{
			get;
		}
		Int32? BucketCount 
		{
			get;
		}
		Boolean Clustered 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Boolean? FileStreamNull 
		{
			get;
		}
		Int32? FillFactor 
		{
			get;
		}
		String FilterPredicate 
		{
			get;
		}
		Boolean Hash 
		{
			get;
		}
		Boolean IgnoreDuplicateKey 
		{
			get;
		}
		Boolean IncrementalStatistics 
		{
			get;
		}
		Boolean RecomputeStatistics 
		{
			get;
		}
		Boolean Unique 
		{
			get;
		}
		Boolean WithPadIndex 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BodyDependencies 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlColumnReference> Columns 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlDataCompressionOption> DataCompressionOptions 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlFilegroupReference> Filegroup 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlFilegroupReference> FileStreamFilegroup 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlPartitionSchemeReference> FileStreamPartitionScheme 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlColumnReference> IncludedColumns 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISpecifiesIndex> IndexedObject 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlColumnReference> PartitionColumn 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlPartitionSchemeReference> PartitionScheme 
		{
			get;
		}
	}
    public interface ISql120TSqlAssemblyReference : ISql120TSqlAssembly
	{
    }
	public interface ISql120TSqlAssembly : ISqlModelElement
	{		
		AssemblyPermissionSet PermissionSet 
		{
			get;
		}
		Boolean Visible 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlAssemblySource> AssemblySources 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlAssemblyReference> ReferencedAssemblies 
		{
			get;
		}
	}
    public interface ISql120TSqlAssemblySourceReference : ISql120TSqlAssemblySource
	{
    }
	public interface ISql120TSqlAssemblySource : ISqlModelElement
	{		
		String Source 
		{
			get;
		}
	}
    public interface ISql120TSqlAsymmetricKeyReference : ISql120TSqlAsymmetricKey
	{
    }
	public interface ISql120TSqlAsymmetricKey : ISqlModelElement
	{		
		AsymmetricKeyAlgorithm Algorithm 
		{
			get;
		}
		SymmetricKeyCreationDisposition CreationDisposition 
		{
			get;
		}
		Boolean EncryptedWithPassword 
		{
			get;
		}
		String ExecutableFile 
		{
			get;
		}
		String File 
		{
			get;
		}
		String Password 
		{
			get;
		}
		String ProviderKeyName 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlAssemblyReference> Assembly 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> Provider 
		{
			get;
		}
	}
    public interface ISql120TSqlAuditActionReference : ISql120TSqlAuditAction
	{
    }
	public interface ISql120TSqlAuditAction : ISqlModelElement
	{		
		DatabaseAuditAction Action 
		{
			get;
		}
	}
    public interface ISql120TSqlAuditActionGroupReference : ISql120TSqlAuditActionGroup
	{
    }
	public interface ISql120TSqlAuditActionGroup : ISqlModelElement
	{		
		AuditActionGroupType ActionGroup 
		{
			get;
		}
	}
    public interface ISql120TSqlAuditActionSpecificationReference : ISql120TSqlAuditActionSpecification
	{
    }
	public interface ISql120TSqlAuditActionSpecification : ISqlModelElement
	{		
		Boolean AuditsDatabase 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlAuditAction> AuditActions 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlDatabaseSecurityPrincipal> Principals 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlSecurable> SecuredObject 
		{
			get;
		}
	}
    public interface ISql120TSqlBrokerPriorityReference : ISql120TSqlBrokerPriority
	{
    }
	public interface ISql120TSqlBrokerPriority : ISqlModelElement
	{		
		Int32 PriorityLevel 
		{
			get;
		}
		String RemoteServiceName 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ContractName 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> LocalServiceName 
		{
			get;
		}
	}
    public interface ISql120TSqlBuiltInServerRoleReference : ISql120TSqlBuiltInServerRole
	{
    }
	public interface ISql120TSqlBuiltInServerRole : ISqlModelElement
	{		
	}
    public interface ISql120TSqlDataTypeReference : ISql120TSqlDataType
	{
    }
	public interface ISql120TSqlDataType : ISqlModelElement
	{		
		SqlDataType SqlDataType 
		{
			get;
		}
		Boolean UddtIsMax 
		{
			get;
		}
		Int32 UddtLength 
		{
			get;
		}
		Boolean UddtNullable 
		{
			get;
		}
		Int32 UddtPrecision 
		{
			get;
		}
		Int32 UddtScale 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlSchemaReference> Schema 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlDataTypeReference> Type 
		{
			get;
		}
	}
    public interface ISql120TSqlCertificateReference : ISql120TSqlCertificate
	{
    }
	public interface ISql120TSqlCertificate : ISqlModelElement
	{		
		Boolean ActiveForBeginDialog 
		{
			get;
		}
		Boolean EncryptedWithPassword 
		{
			get;
		}
		String EncryptionPassword 
		{
			get;
		}
		String ExistingKeysFilePath 
		{
			get;
		}
		String ExpiryDate 
		{
			get;
		}
		Boolean IsExistingKeyFileExecutable 
		{
			get;
		}
		String PrivateKeyDecryptionPassword 
		{
			get;
		}
		String PrivateKeyEncryptionPassword 
		{
			get;
		}
		String PrivateKeyFilePath 
		{
			get;
		}
		String StartDate 
		{
			get;
		}
		String Subject 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlAssemblyReference> ExistingKeysAssembly 
		{
			get;
		}
	}
    public interface ISql120TSqlCheckConstraintReference : ISql120TSqlCheckConstraint
	{
    }
	public interface ISql120TSqlCheckConstraint : ISqlModelElement
	{		
		Boolean Disabled 
		{
			get;
		}
		String Expression 
		{
			get;
		}
		Boolean NotForReplication 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ExpressionDependencies 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlTableReference> Host 
		{
			get;
		}
	}
    public interface ISql120TSqlClrTypeMethodReference : ISql120TSqlClrTypeMethod
	{
    }
	public interface ISql120TSqlClrTypeMethod : ISqlModelElement
	{		
		String MethodName 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlParameter> Parameters 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlDataType> ReturnType 
		{
			get;
		}
	}
    public interface ISql120TSqlClrTypeMethodParameterReference : ISql120TSqlClrTypeMethodParameter
	{
    }
	public interface ISql120TSqlClrTypeMethodParameter : ISqlModelElement
	{		
		Boolean IsOutput 
		{
			get;
		}
		String ParameterName 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlDataType> DataType 
		{
			get;
		}
	}
    public interface ISql120TSqlClrTypePropertyReference : ISql120TSqlClrTypeProperty
	{
    }
	public interface ISql120TSqlClrTypeProperty : ISqlModelElement
	{		
		String PropertyName 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlDataTypeReference> ClrType 
		{
			get;
		}
	}
    public interface ISql120TSqlColumnStoreIndexReference : ISql120TSqlColumnStoreIndex
	{
    }
	public interface ISql120TSqlColumnStoreIndex : ISqlModelElement
	{		
		Boolean Clustered 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlColumnReference> Columns 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlDataCompressionOption> DataCompressionOptions 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlFilegroupReference> Filegroup 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISpecifiesIndex> IndexedObject 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlColumnReference> PartitionColumn 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlPartitionSchemeReference> PartitionScheme 
		{
			get;
		}
	}
    public interface ISql120TSqlContractReference : ISql120TSqlContract
	{
    }
	public interface ISql120TSqlContract : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlMessageTypeReference> Messages 
		{
			get;
		}
	}
    public interface ISql120TSqlCredentialReference : ISql120TSqlCredential
	{
    }
	public interface ISql120TSqlCredential : ISqlModelElement
	{		
		String Identity 
		{
			get;
		}
		String Secret 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlCryptographicProviderReference> CryptographicProvider 
		{
			get;
		}
	}
    public interface ISql120TSqlDatabaseCredentialReference : ISql120TSqlDatabaseCredential
	{
    }
	public interface ISql120TSqlDatabaseCredential : ISqlModelElement
	{		
	}
    public interface ISql120TSqlCryptographicProviderReference : ISql120TSqlCryptographicProvider
	{
    }
	public interface ISql120TSqlCryptographicProvider : ISqlModelElement
	{		
		String DllPath 
		{
			get;
		}
		Boolean Enabled 
		{
			get;
		}
	}
    public interface ISql120TSqlDatabaseAuditSpecificationReference : ISql120TSqlDatabaseAuditSpecification
	{
    }
	public interface ISql120TSqlDatabaseAuditSpecification : ISqlModelElement
	{		
		Boolean WithState 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlAuditActionGroup> AuditActionGroups 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlAuditAction> AuditActions 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlServerAuditReference> ServerAudit 
		{
			get;
		}
	}
    public interface ISql120TSqlDatabaseDdlTriggerReference : ISql120TSqlDatabaseDdlTrigger
	{
    }
	public interface ISql120TSqlDatabaseDdlTrigger : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		String ClassName 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Boolean ExecuteAsCaller 
		{
			get;
		}
		Boolean ExecuteAsOwner 
		{
			get;
		}
		Boolean ExecuteAsSelf 
		{
			get;
		}
		String MethodName 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		TriggerType TriggerType 
		{
			get;
		}
		Boolean WithEncryption 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlAssemblyReference> Assembly 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BodyDependencies 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlEventGroup> EventGroup 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Model.EventType> EventType 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlLoginReference> Login 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlUserReference> User 
		{
			get;
		}
	}
    public interface ISql120TSqlDatabaseEncryptionKeyReference : ISql120TSqlDatabaseEncryptionKey
	{
    }
	public interface ISql120TSqlDatabaseEncryptionKey : ISqlModelElement
	{		
		SymmetricKeyAlgorithm Algorithm 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlAsymmetricKeyReference> AsymmetricKey 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlCertificateReference> Certificate 
		{
			get;
		}
	}
    public interface ISql120TSqlDatabaseEventNotificationReference : ISql120TSqlDatabaseEventNotification
	{
    }
	public interface ISql120TSqlDatabaseEventNotification : ISqlModelElement
	{		
		String BrokerInstanceSpecifier 
		{
			get;
		}
		String BrokerService 
		{
			get;
		}
		Boolean WithFanIn 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlEventGroup> EventGroup 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Model.EventType> EventType 
		{
			get;
		}
	}
    public interface ISql120TSqlDatabaseMirroringLanguageSpecifierReference : ISql120TSqlDatabaseMirroringLanguageSpecifier
	{
    }
	public interface ISql120TSqlDatabaseMirroringLanguageSpecifier : ISqlModelElement
	{		
		ServiceBrokerEncryptionAlgorithm EncryptionAlgorithmPart1 
		{
			get;
		}
		ServiceBrokerEncryptionAlgorithm EncryptionAlgorithmPart2 
		{
			get;
		}
		EncryptionMode EncryptionMode 
		{
			get;
		}
		DatabaseMirroringRole RoleType 
		{
			get;
		}
		Boolean UseCertificateFirst 
		{
			get;
		}
		AuthenticationModes WindowsAuthenticationMode 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlCertificateReference> AuthenticationCertificate 
		{
			get;
		}
	}
    public interface ISql120TSqlDatabaseOptionsReference : ISql120TSqlDatabaseOptions
	{
    }
	public interface ISql120TSqlDatabaseOptions : ISqlModelElement
	{		
		Boolean AllowSnapshotIsolation 
		{
			get;
		}
		Boolean AnsiNullDefaultOn 
		{
			get;
		}
		Boolean AnsiNullsOn 
		{
			get;
		}
		Boolean AnsiPaddingOn 
		{
			get;
		}
		Boolean AnsiWarningsOn 
		{
			get;
		}
		Boolean ArithAbortOn 
		{
			get;
		}
		Boolean AutoClose 
		{
			get;
		}
		Boolean AutoCreateStatistics 
		{
			get;
		}
		Boolean AutoCreateStatisticsIncremental 
		{
			get;
		}
		Boolean AutoShrink 
		{
			get;
		}
		Boolean AutoUpdateStatistics 
		{
			get;
		}
		Boolean AutoUpdateStatisticsAsync 
		{
			get;
		}
		Boolean ChangeTrackingAutoCleanup 
		{
			get;
		}
		Boolean ChangeTrackingEnabled 
		{
			get;
		}
		Int32 ChangeTrackingRetentionPeriod 
		{
			get;
		}
		TimeUnit ChangeTrackingRetentionUnit 
		{
			get;
		}
		String Collation 
		{
			get;
		}
		Int32 CompatibilityLevel 
		{
			get;
		}
		Boolean ConcatNullYieldsNull 
		{
			get;
		}
		Containment Containment 
		{
			get;
		}
		Boolean CursorCloseOnCommit 
		{
			get;
		}
		Boolean CursorDefaultGlobalScope 
		{
			get;
		}
		Boolean DatabaseStateOffline 
		{
			get;
		}
		Boolean DateCorrelationOptimizationOn 
		{
			get;
		}
		Boolean DBChainingOn 
		{
			get;
		}
		String DefaultFullTextLanguage 
		{
			get;
		}
		String DefaultLanguage 
		{
			get;
		}
		DelayedDurabilityMode DelayedDurabilityMode 
		{
			get;
		}
		String FileStreamDirectoryName 
		{
			get;
		}
		Boolean FullTextEnabled 
		{
			get;
		}
		Boolean HonorBrokerPriority 
		{
			get;
		}
		Boolean MemoryOptimizedElevateToSnapshot 
		{
			get;
		}
		Boolean NestedTriggersOn 
		{
			get;
		}
		NonTransactedFileStreamAccess NonTransactedFileStreamAccess 
		{
			get;
		}
		Boolean NumericRoundAbortOn 
		{
			get;
		}
		PageVerifyMode PageVerifyMode 
		{
			get;
		}
		ParameterizationOption ParameterizationOption 
		{
			get;
		}
		Boolean QuotedIdentifierOn 
		{
			get;
		}
		Boolean ReadOnly 
		{
			get;
		}
		RecoveryMode RecoveryMode 
		{
			get;
		}
		Boolean RecursiveTriggersOn 
		{
			get;
		}
		ServiceBrokerOption ServiceBrokerOption 
		{
			get;
		}
		Boolean SupplementalLoggingOn 
		{
			get;
		}
		Int32 TargetRecoveryTimePeriod 
		{
			get;
		}
		TimeUnit TargetRecoveryTimeUnit 
		{
			get;
		}
		Boolean TornPageProtectionOn 
		{
			get;
		}
		Boolean TransactionIsolationReadCommittedSnapshot 
		{
			get;
		}
		Boolean TransformNoiseWords 
		{
			get;
		}
		Boolean Trustworthy 
		{
			get;
		}
		Int16 TwoDigitYearCutoff 
		{
			get;
		}
		UserAccessOption UserAccessOption 
		{
			get;
		}
		Boolean VardecimalStorageFormatOn 
		{
			get;
		}
		Boolean WithEncryption 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlFilegroupReference> DefaultFilegroup 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlFilegroupReference> DefaultFileStreamFilegroup 
		{
			get;
		}
	}
    public interface ISql120TSqlDataCompressionOptionReference : ISql120TSqlDataCompressionOption
	{
    }
	public interface ISql120TSqlDataCompressionOption : ISqlModelElement
	{		
		CompressionLevel CompressionLevel 
		{
			get;
		}
		Int32 PartitionNumber 
		{
			get;
		}
	}
    public interface ISql120TSqlDefaultReference : ISql120TSqlDefault
	{
    }
	public interface ISql120TSqlDefault : ISqlModelElement
	{		
		String Expression 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BoundObjects 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISql120TSqlDefaultConstraintReference : ISql120TSqlDefaultConstraint
	{
    }
	public interface ISql120TSqlDefaultConstraint : ISqlModelElement
	{		
		Boolean Disabled 
		{
			get;
		}
		String Expression 
		{
			get;
		}
		Boolean WithValues 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ExpressionDependencies 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlTableReference> Host 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlColumnReference> TargetColumn 
		{
			get;
		}
	}
    public interface ISql120TSqlDmlTriggerReference : ISql120TSqlDmlTrigger
	{
    }
	public interface ISql120TSqlDmlTrigger : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		String ClassName 
		{
			get;
		}
		OrderRestriction DeleteOrderRestriction 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Boolean ExecuteAsCaller 
		{
			get;
		}
		Boolean ExecuteAsOwner 
		{
			get;
		}
		Boolean ExecuteAsSelf 
		{
			get;
		}
		OrderRestriction InsertOrderRestriction 
		{
			get;
		}
		Boolean IsDeleteTrigger 
		{
			get;
		}
		Boolean IsInsertTrigger 
		{
			get;
		}
		Boolean IsUpdateTrigger 
		{
			get;
		}
		String MethodName 
		{
			get;
		}
		Boolean NotForReplication 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		TriggerType TriggerType 
		{
			get;
		}
		OrderRestriction UpdateOrderRestriction 
		{
			get;
		}
		Boolean WithAppend 
		{
			get;
		}
		Boolean WithEncryption 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlAssemblyReference> Assembly 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BodyDependencies 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlLoginReference> Login 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> TriggerObject 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlUserReference> User 
		{
			get;
		}
	}
    public interface ISql120TSqlEndpointReference : ISql120TSqlEndpoint
	{
    }
	public interface ISql120TSqlEndpoint : ISqlModelElement
	{		
		Payload Payload 
		{
			get;
		}
		Protocol Protocol 
		{
			get;
		}
		State State 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.IEndpointLanguageSpecifier> PayloadSpecifier 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.IProtocolSpecifier > ProtocolSpecifier 
		{
			get;
		}
	}
    public interface ISql120TSqlErrorMessageReference : ISql120TSqlErrorMessage
	{
    }
	public interface ISql120TSqlErrorMessage : ISqlModelElement
	{		
		String Language 
		{
			get;
		}
		Int32 MessageNumber 
		{
			get;
		}
		String MessageText 
		{
			get;
		}
		Int32 Severity 
		{
			get;
		}
		Boolean WithLog 
		{
			get;
		}
	}
    public interface ISql120TSqlEventGroupReference : ISql120TSqlEventGroup
	{
    }
	public interface ISql120TSqlEventGroup : ISqlModelElement
	{		
		EventGroupType Group 
		{
			get;
		}
	}
    public interface ISql120TSqlEventSessionReference : ISql120TSqlEventSession
	{
    }
	public interface ISql120TSqlEventSession : ISqlModelElement
	{		
		EventRetentionMode EventRetentionMode 
		{
			get;
		}
		Int32 MaxDispatchLatency 
		{
			get;
		}
		Int32 MaxEventSize 
		{
			get;
		}
		MemoryUnit MaxEventSizeUnit 
		{
			get;
		}
		Int32 MaxMemory 
		{
			get;
		}
		MemoryUnit MaxMemoryUnit 
		{
			get;
		}
		MemoryPartitionMode MemoryPartitionMode 
		{
			get;
		}
		EventSessionScope SessionScope 
		{
			get;
		}
		Boolean StartupState 
		{
			get;
		}
		Boolean TrackCausality 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.TSqlModelElement> EventDefinitions 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.TSqlModelElement> EventTargets 
		{
			get;
		}
	}
    public interface ISql120TSqlDatabaseEventSessionReference : ISql120TSqlDatabaseEventSession
	{
    }
	public interface ISql120TSqlDatabaseEventSession : ISqlModelElement
	{		
		EventRetentionMode EventRetentionMode 
		{
			get;
		}
		Int32 MaxDispatchLatency 
		{
			get;
		}
		Int32 MaxEventSize 
		{
			get;
		}
		MemoryUnit MaxEventSizeUnit 
		{
			get;
		}
		Int32 MaxMemory 
		{
			get;
		}
		MemoryUnit MaxMemoryUnit 
		{
			get;
		}
		MemoryPartitionMode MemoryPartitionMode 
		{
			get;
		}
		EventSessionScope SessionScope 
		{
			get;
		}
		Boolean StartupState 
		{
			get;
		}
		Boolean TrackCausality 
		{
			get;
		}
		//Composing
		IEnumerable<TSqlModelElementReference> EventDefinitions 
		{
			get;
		}
		//Composing
		IEnumerable<TSqlModelElementReference> EventTargets 
		{
			get;
		}
	}
    public interface ISql120TSqlEventSessionActionReference : ISql120TSqlEventSessionAction
	{
    }
	public interface ISql120TSqlEventSessionAction : ISqlModelElement
	{		
		String ActionName 
		{
			get;
		}
		String EventModuleGuid 
		{
			get;
		}
		String EventPackageName 
		{
			get;
		}
	}
    public interface ISql120TSqlEventSessionDefinitionsReference : ISql120TSqlEventSessionDefinitions
	{
    }
	public interface ISql120TSqlEventSessionDefinitions : ISqlModelElement
	{		
		String EventModuleGuid 
		{
			get;
		}
		String EventName 
		{
			get;
		}
		String EventPackageName 
		{
			get;
		}
		String WhereExpression 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlEventSessionAction> Actions 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.TSqlModelElement> AttributeSettings 
		{
			get;
		}
	}
    public interface ISql120TSqlEventSessionSettingReference : ISql120TSqlEventSessionSetting
	{
    }
	public interface ISql120TSqlEventSessionSetting : ISqlModelElement
	{		
		String SettingName 
		{
			get;
		}
		String SettingValue 
		{
			get;
		}
	}
    public interface ISql120TSqlEventSessionTargetReference : ISql120TSqlEventSessionTarget
	{
    }
	public interface ISql120TSqlEventSessionTarget : ISqlModelElement
	{		
		String EventModuleGuid 
		{
			get;
		}
		String EventPackageName 
		{
			get;
		}
		String TargetName 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.TSqlModelElement> ParameterSettings 
		{
			get;
		}
	}
    public interface ISql120TSqlEventTypeSpecifierReference : ISql120TSqlEventTypeSpecifier
	{
    }
	public interface ISql120TSqlEventTypeSpecifier : ISqlModelElement
	{		
		EventType EventType 
		{
			get;
		}
		OrderRestriction Order 
		{
			get;
		}
	}
    public interface ISql120TSqlExtendedProcedureReference : ISql120TSqlExtendedProcedure
	{
    }
	public interface ISql120TSqlExtendedProcedure : ISqlModelElement
	{		
		Boolean ExeccuteAsCaller 
		{
			get;
		}
		Boolean ExecuteAsOwner 
		{
			get;
		}
		Boolean ExecuteAsSelf 
		{
			get;
		}
		Boolean WithEncryption 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlLoginReference> Login 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlParameter> Parameters 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlSchemaReference> Schema 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlUserReference> User 
		{
			get;
		}
	}
    public interface ISql120TSqlExtendedPropertyReference : ISql120TSqlExtendedProperty
	{
    }
	public interface ISql120TSqlExtendedProperty : ISqlModelElement
	{		
		String Value 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.IExtendedPropertyHost> Host 
		{
			get;
		}
	}
    public interface ISql120TSqlExternalDataSourceReference : ISql120TSqlExternalDataSource
	{
    }
	public interface ISql120TSqlExternalDataSource : ISqlModelElement
	{		
	}
    public interface ISql120TSqlExternalFileFormatReference : ISql120TSqlExternalFileFormat
	{
    }
	public interface ISql120TSqlExternalFileFormat : ISqlModelElement
	{		
	}
    public interface ISql120TSqlExternalTableReference : ISql120TSqlExternalTable
	{
    }
	public interface ISql120TSqlExternalTable : ISqlModelElement
	{		
		Boolean? IsAnsiNullsOn 
		{
			get;
		}
		Boolean? IsFileStreamNull 
		{
			get;
		}
		Boolean? IsQuotedIdentifierOn 
		{
			get;
		}
		Boolean IsTableLockOnBulkLoad 
		{
			get;
		}
		LockEscalationMethod LockEscalation 
		{
			get;
		}
		//Composing
		IEnumerable<TSqlModelElementReference> Columns 
		{
			get;
		}
		//Composing
		IEnumerable<TSqlModelElementReference> DataCompressionOptions 
		{
			get;
		}
		//Peer
		IEnumerable<TSqlModelElementReference> Filegroup 
		{
			get;
		}
		//Peer
		IEnumerable<TSqlModelElementReference> FileStreamFilegroup 
		{
			get;
		}
		//Peer
		IEnumerable<TSqlModelElementReference> FileStreamPartitionScheme 
		{
			get;
		}
		//Peer
		IEnumerable<TSqlModelElementReference> PartitionColumn 
		{
			get;
		}
		//Peer
		IEnumerable<TSqlModelElementReference> PartitionScheme 
		{
			get;
		}
		//Hierarchical
		IEnumerable<TSqlModelElementReference> Schema 
		{
			get;
		}
	}
    public interface ISql120TSqlSqlFileReference : ISql120TSqlSqlFile
	{
    }
	public interface ISql120TSqlSqlFile : ISqlModelElement
	{		
		Int32? FileGrowth 
		{
			get;
		}
		MemoryUnit FileGrowthUnit 
		{
			get;
		}
		String FileName 
		{
			get;
		}
		Boolean IsLogFile 
		{
			get;
		}
		Int32? MaxSize 
		{
			get;
		}
		MemoryUnit MaxSizeUnit 
		{
			get;
		}
		Boolean Offline 
		{
			get;
		}
		Int32? Size 
		{
			get;
		}
		MemoryUnit SizeUnit 
		{
			get;
		}
		Boolean Unlimited 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlFilegroupReference> Filegroup 
		{
			get;
		}
	}
    public interface ISql120TSqlFilegroupReference : ISql120TSqlFilegroup
	{
    }
	public interface ISql120TSqlFilegroup : ISqlModelElement
	{		
		Boolean ContainsFileStream 
		{
			get;
		}
		Boolean ContainsMemoryOptimizedData 
		{
			get;
		}
		Boolean ReadOnly 
		{
			get;
		}
	}
    public interface ISql120TSqlForeignKeyConstraintReference : ISql120TSqlForeignKeyConstraint
	{
    }
	public interface ISql120TSqlForeignKeyConstraint : ISqlModelElement
	{		
		ForeignKeyAction DeleteAction 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Boolean NotForReplication 
		{
			get;
		}
		ForeignKeyAction UpdateAction 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlColumnReference> Columns 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlColumnReference> ForeignColumns 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlTableReference> ForeignTable 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlTableReference> Host 
		{
			get;
		}
	}
    public interface ISql120TSqlFullTextCatalogReference : ISql120TSqlFullTextCatalog
	{
    }
	public interface ISql120TSqlFullTextCatalog : ISqlModelElement
	{		
		Boolean? AccentSensitivity 
		{
			get;
		}
		Boolean IsDefault 
		{
			get;
		}
		String Path 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlFilegroupReference> Filegroup 
		{
			get;
		}
	}
    public interface ISql120TSqlFullTextIndexReference : ISql120TSqlFullTextIndex
	{
    }
	public interface ISql120TSqlFullTextIndex : ISqlModelElement
	{		
		ChangeTrackingOption ChangeTracking 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Boolean Replicated 
		{
			get;
		}
		Boolean StopListOff 
		{
			get;
		}
		Boolean UseSystemStopList 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.TSqlModelElementReference> Catalog 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlFullTextIndexColumnSpecifier> Columns 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlFilegroupReference> Filegroup 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISpecifiesIndex> IndexedObject 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlSearchPropertyListReference> SearchPropertyList 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> StopList 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> UniqueIndexName 
		{
			get;
		}
	}
    public interface ISql120TSqlFullTextIndexColumnSpecifierReference : ISql120TSqlFullTextIndexColumnSpecifier
	{
    }
	public interface ISql120TSqlFullTextIndexColumnSpecifier : ISqlModelElement
	{		
		Int32? LanguageId 
		{
			get;
		}
		Boolean PartOfStatisticalSemantics 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlColumnReference> Column 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlColumnReference> TypeColumn 
		{
			get;
		}
	}
    public interface ISql120TSqlFullTextStopListReference : ISql120TSqlFullTextStopList
	{
    }
	public interface ISql120TSqlFullTextStopList : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
	}
    public interface ISql120TSqlHttpProtocolSpecifierReference : ISql120TSqlHttpProtocolSpecifier
	{
    }
	public interface ISql120TSqlHttpProtocolSpecifier : ISqlModelElement
	{		
	}
    public interface ISql120TSqlLinkedServerReference : ISql120TSqlLinkedServer
	{
    }
	public interface ISql120TSqlLinkedServer : ISqlModelElement
	{		
		String Catalog 
		{
			get;
		}
		Boolean CollationCompatible 
		{
			get;
		}
		String CollationName 
		{
			get;
		}
		Int32 ConnectTimeout 
		{
			get;
		}
		Boolean DataAccess 
		{
			get;
		}
		String DataSource 
		{
			get;
		}
		Boolean IsDistributor 
		{
			get;
		}
		Boolean IsPublisher 
		{
			get;
		}
		Boolean IsSubscriber 
		{
			get;
		}
		Boolean LazySchemaValidationEnabled 
		{
			get;
		}
		String Location 
		{
			get;
		}
		String ProductName 
		{
			get;
		}
		String ProviderName 
		{
			get;
		}
		String ProviderString 
		{
			get;
		}
		Int32 QueryTimeout 
		{
			get;
		}
		Boolean RemoteProcTransactionPromotionEnabled 
		{
			get;
		}
		Boolean RpcEnabled 
		{
			get;
		}
		Boolean RpcOutEnabled 
		{
			get;
		}
		Boolean UseRemoteCollation 
		{
			get;
		}
	}
    public interface ISql120TSqlLinkedServerLoginReference : ISql120TSqlLinkedServerLogin
	{
    }
	public interface ISql120TSqlLinkedServerLogin : ISqlModelElement
	{		
		String LinkedServerLoginName 
		{
			get;
		}
		String LinkedServerPassword 
		{
			get;
		}
		Boolean UseSelf 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlLinkedServerReference> LinkedServer 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlLoginReference> LocalLogin 
		{
			get;
		}
	}
    public interface ISql120TSqlLoginReference : ISql120TSqlLogin
	{
    }
	public interface ISql120TSqlLogin : ISqlModelElement
	{		
		Boolean CheckExpiration 
		{
			get;
		}
		Boolean CheckPolicy 
		{
			get;
		}
		String DefaultDatabase 
		{
			get;
		}
		String DefaultLanguage 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		LoginEncryptionOption EncryptionOption 
		{
			get;
		}
		Boolean MappedToWindowsLogin 
		{
			get;
		}
		String Password 
		{
			get;
		}
		Boolean PasswordHashed 
		{
			get;
		}
		Boolean PasswordMustChange 
		{
			get;
		}
		String Sid 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlAsymmetricKeyReference> AsymmetricKey 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlCertificateReference> Certificate 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlCredentialReference> Credential 
		{
			get;
		}
	}
    public interface ISql120TSqlMasterKeyReference : ISql120TSqlMasterKey
	{
    }
	public interface ISql120TSqlMasterKey : ISqlModelElement
	{		
		String Password 
		{
			get;
		}
	}
    public interface ISql120TSqlMessageTypeReference : ISql120TSqlMessageType
	{
    }
	public interface ISql120TSqlMessageType : ISqlModelElement
	{		
		ValidationMethod ValidationMethod 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlXmlSchemaCollectionReference> XmlSchemaCollection 
		{
			get;
		}
	}
    public interface ISql120TSqlPartitionFunctionReference : ISql120TSqlPartitionFunction
	{
    }
	public interface ISql120TSqlPartitionFunction : ISqlModelElement
	{		
		PartitionRange Range 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlPartitionValue> BoundaryValues 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlDataTypeReference> ParameterType 
		{
			get;
		}
	}
    public interface ISql120TSqlPartitionSchemeReference : ISql120TSqlPartitionScheme
	{
    }
	public interface ISql120TSqlPartitionScheme : ISqlModelElement
	{		
		Boolean AllToOneFilegroup 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlFilegroupReference> Filegroups 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlPartitionFunctionReference> PartitionFunction 
		{
			get;
		}
	}
    public interface ISql120TSqlPartitionValueReference : ISql120TSqlPartitionValue
	{
    }
	public interface ISql120TSqlPartitionValue : ISqlModelElement
	{		
		String Expression 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ExpressionDependencies 
		{
			get;
		}
	}
    public interface ISql120TSqlPermissionReference : ISql120TSqlPermission
	{
    }
	public interface ISql120TSqlPermission : ISqlModelElement
	{		
		PermissionAction PermissionAction 
		{
			get;
		}
		PermissionType PermissionType 
		{
			get;
		}
		Boolean WithAllPrivileges 
		{
			get;
		}
		Boolean WithGrantOption 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlColumnReference> ExcludedColumns 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlSecurityPrincipal> Grantee 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlSecurityPrincipal> Grantor 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlColumnReference> RevokedGrantOptionColumns 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlSecurable> SecuredObject 
		{
			get;
		}
	}
    public interface ISql120TSqlPrimaryKeyConstraintReference : ISql120TSqlPrimaryKeyConstraint
	{
    }
	public interface ISql120TSqlPrimaryKeyConstraint : ISqlModelElement
	{		
		Boolean AllowPageLocks 
		{
			get;
		}
		Boolean AllowRowLocks 
		{
			get;
		}
		Int32? BucketCount 
		{
			get;
		}
		Boolean Clustered 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Boolean? FileStreamNull 
		{
			get;
		}
		Int32? FillFactor 
		{
			get;
		}
		Boolean Hash 
		{
			get;
		}
		Boolean IgnoreDuplicateKey 
		{
			get;
		}
		Boolean RecomputeStatistics 
		{
			get;
		}
		Boolean WithPadIndex 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlColumnReference> Columns 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlDataCompressionOption> DataCompressionOptions 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlFilegroupReference> Filegroup 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlFilegroupReference> FileStreamFilegroup 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlPartitionSchemeReference> FileStreamPartitionScheme 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlTableReference> Host 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlColumnReference> PartitionColumn 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlPartitionSchemeReference> PartitionScheme 
		{
			get;
		}
	}
    public interface ISql120TSqlProcedureReference : ISql120TSqlProcedure
	{
    }
	public interface ISql120TSqlProcedure : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		String ClassName 
		{
			get;
		}
		Boolean ExecuteAsCaller 
		{
			get;
		}
		Boolean ExecuteAsOwner 
		{
			get;
		}
		Boolean ExecuteAsSelf 
		{
			get;
		}
		Boolean ForReplication 
		{
			get;
		}
		Boolean IsReplicated 
		{
			get;
		}
		String MethodName 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		Boolean WithEncryption 
		{
			get;
		}
		Boolean WithNativeCompilation 
		{
			get;
		}
		Boolean WithRecompile 
		{
			get;
		}
		Boolean WithSchemaBinding 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlAssemblyReference> Assembly 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BodyDependencies 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlLoginReference> Login 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlParameter> Parameters 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlProcedureReference> ParentProcedure 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlSchemaReference> Schema 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlUserReference> User 
		{
			get;
		}
	}
    public interface ISql120TSqlQueueReference : ISql120TSqlQueue
	{
    }
	public interface ISql120TSqlQueue : ISqlModelElement
	{		
		Boolean ActivationExecuteAsCaller 
		{
			get;
		}
		Boolean ActivationExecuteAsOwner 
		{
			get;
		}
		Boolean ActivationExecuteAsSelf 
		{
			get;
		}
		Int32? ActivationMaxQueueReaders 
		{
			get;
		}
		Boolean? ActivationStatusOn 
		{
			get;
		}
		Boolean PoisonMessageHandlingStatusOn 
		{
			get;
		}
		Boolean RetentionOn 
		{
			get;
		}
		Boolean StatusOn 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlProcedureReference> ActivationProcedure 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlColumn> Columns 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlFilegroupReference> Filegroup 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlLoginReference> Login 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlColumnReference> PartitionColumn 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlPartitionSchemeReference> PartitionScheme 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlSchemaReference> Schema 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlUserReference> User 
		{
			get;
		}
	}
    public interface ISql120TSqlQueueEventNotificationReference : ISql120TSqlQueueEventNotification
	{
    }
	public interface ISql120TSqlQueueEventNotification : ISqlModelElement
	{		
		String BrokerInstanceSpecifier 
		{
			get;
		}
		String BrokerService 
		{
			get;
		}
		Boolean WithFanIn 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlEventGroup> EventGroup 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Model.EventType> EventType 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlQueueReference> Queue 
		{
			get;
		}
	}
    public interface ISql120TSqlRemoteServiceBindingReference : ISql120TSqlRemoteServiceBinding
	{
    }
	public interface ISql120TSqlRemoteServiceBinding : ISqlModelElement
	{		
		Boolean Anonymous 
		{
			get;
		}
		String Service 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlUserReference> User 
		{
			get;
		}
	}
    public interface ISql120TSqlResourceGovernorReference : ISql120TSqlResourceGovernor
	{
    }
	public interface ISql120TSqlResourceGovernor : ISqlModelElement
	{		
		Boolean? Enabled 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ClassifierFunction 
		{
			get;
		}
	}
    public interface ISql120TSqlResourcePoolReference : ISql120TSqlResourcePool
	{
    }
	public interface ISql120TSqlResourcePool : ISqlModelElement
	{		
		Int32 CapCpuPercent 
		{
			get;
		}
		Int32 MaxCpuPercent 
		{
			get;
		}
		Int32 MaxIopsPerVolume 
		{
			get;
		}
		Int32 MaxMemoryPercent 
		{
			get;
		}
		Int32 MinCpuPercent 
		{
			get;
		}
		Int32 MinIopsPerVolume 
		{
			get;
		}
		Int32 MinMemoryPercent 
		{
			get;
		}
	}
    public interface ISql120TSqlRoleReference : ISql120TSqlRole
	{
    }
	public interface ISql120TSqlRole : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
	}
    public interface ISql120TSqlRoleMembershipReference : ISql120TSqlRoleMembership
	{
    }
	public interface ISql120TSqlRoleMembership : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlDatabaseSecurityPrincipal> Member 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlRoleReference> Role 
		{
			get;
		}
	}
    public interface ISql120TSqlRouteReference : ISql120TSqlRoute
	{
    }
	public interface ISql120TSqlRoute : ISqlModelElement
	{		
		String Address 
		{
			get;
		}
		String BrokerInstance 
		{
			get;
		}
		Int32? Lifetime 
		{
			get;
		}
		String MirrorAddress 
		{
			get;
		}
		String ServiceName 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
	}
    public interface ISql120TSqlRuleReference : ISql120TSqlRule
	{
    }
	public interface ISql120TSqlRule : ISqlModelElement
	{		
		String Expression 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BoundObjects 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISql120TSqlSchemaReference : ISql120TSqlSchema
	{
    }
	public interface ISql120TSqlSchema : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
	}
    public interface ISql120TSqlSearchPropertyReference : ISql120TSqlSearchProperty
	{
    }
	public interface ISql120TSqlSearchProperty : ISqlModelElement
	{		
		String Description 
		{
			get;
		}
		Int32 Identifier 
		{
			get;
		}
		String PropertySetGuid 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlSearchPropertyListReference> SearchPropertyList 
		{
			get;
		}
	}
    public interface ISql120TSqlSearchPropertyListReference : ISql120TSqlSearchPropertyList
	{
    }
	public interface ISql120TSqlSearchPropertyList : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
	}
    public interface ISql120TSqlSecurityPolicyReference : ISql120TSqlSecurityPolicy
	{
    }
	public interface ISql120TSqlSecurityPolicy : ISqlModelElement
	{		
		Boolean Enabled 
		{
			get;
		}
		Boolean IsSchemaBound 
		{
			get;
		}
		Boolean NotForReplication 
		{
			get;
		}
		//Composing
		IEnumerable<TSqlModelElementReference> Predicates 
		{
			get;
		}
		//Hierarchical
		IEnumerable<TSqlModelElementReference> Schema 
		{
			get;
		}
	}
    public interface ISql120TSqlSecurityPredicateReference : ISql120TSqlSecurityPredicate
	{
    }
	public interface ISql120TSqlSecurityPredicate : ISqlModelElement
	{		
		String BodyScript 
		{
			get;
		}
		SecurityPredicateOperation Operation 
		{
			get;
		}
		SecurityPredicateType PredicateType 
		{
			get;
		}
		//Peer
		IEnumerable<TSqlModelElementReference> BodyDependencies 
		{
			get;
		}
		//Peer
		IEnumerable<TSqlModelElementReference> TargetObject 
		{
			get;
		}
	}
    public interface ISql120TSqlSequenceReference : ISql120TSqlSequence
	{
    }
	public interface ISql120TSqlSequence : ISqlModelElement
	{		
		Int32? CacheSize 
		{
			get;
		}
		String IncrementValue 
		{
			get;
		}
		Boolean IsCached 
		{
			get;
		}
		Boolean IsCycling 
		{
			get;
		}
		String MaxValue 
		{
			get;
		}
		String MinValue 
		{
			get;
		}
		Boolean NoMaxValue 
		{
			get;
		}
		Boolean NoMinValue 
		{
			get;
		}
		String StartValue 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlDataTypeReference> DataType 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISql120TSqlServerAuditReference : ISql120TSqlServerAudit
	{
    }
	public interface ISql120TSqlServerAudit : ISqlModelElement
	{		
		String AuditGuid 
		{
			get;
		}
		AuditTarget AuditTarget 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		String FilePath 
		{
			get;
		}
		Int32? MaxFiles 
		{
			get;
		}
		Int32? MaxRolloverFiles 
		{
			get;
		}
		Int32? MaxSize 
		{
			get;
		}
		MemoryUnit MaxSizeUnit 
		{
			get;
		}
		FailureAction OnFailure 
		{
			get;
		}
		String PredicateExpression 
		{
			get;
		}
		Int32 QueueDelay 
		{
			get;
		}
		Boolean ReserveDiskSpace 
		{
			get;
		}
		Boolean UnlimitedFileSize 
		{
			get;
		}
		Boolean UnlimitedMaxRolloverFiles 
		{
			get;
		}
	}
    public interface ISql120TSqlServerAuditSpecificationReference : ISql120TSqlServerAuditSpecification
	{
    }
	public interface ISql120TSqlServerAuditSpecification : ISqlModelElement
	{		
		Boolean StateOn 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlAuditActionGroup> AuditActionGroups 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlServerAuditReference> ServerAudit 
		{
			get;
		}
	}
    public interface ISql120TSqlServerDdlTriggerReference : ISql120TSqlServerDdlTrigger
	{
    }
	public interface ISql120TSqlServerDdlTrigger : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		String ClassName 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Boolean ExecuteAsCaller 
		{
			get;
		}
		Boolean ExecuteAsOwner 
		{
			get;
		}
		Boolean ExecuteAsSelf 
		{
			get;
		}
		Boolean IsLogon 
		{
			get;
		}
		String MethodName 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		TriggerType TriggerType 
		{
			get;
		}
		Boolean WithEncryption 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlAssemblyReference> Assembly 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BodyDependencies 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlEventGroup> EventGroup 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Model.EventType> EventType 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlLoginReference> Login 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlUserReference> User 
		{
			get;
		}
	}
    public interface ISql120TSqlServerEventNotificationReference : ISql120TSqlServerEventNotification
	{
    }
	public interface ISql120TSqlServerEventNotification : ISqlModelElement
	{		
		String BrokerInstanceSpecifier 
		{
			get;
		}
		String BrokerService 
		{
			get;
		}
		Boolean WithFanIn 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlEventGroup> EventGroup 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Model.EventType> EventType 
		{
			get;
		}
	}
    public interface ISql120TSqlServerOptionsReference : ISql120TSqlServerOptions
	{
    }
	public interface ISql120TSqlServerOptions : ISqlModelElement
	{		
	}
    public interface ISql120TSqlServerRoleMembershipReference : ISql120TSqlServerRoleMembership
	{
    }
	public interface ISql120TSqlServerRoleMembership : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.IServerSecurityPrincipal> Member 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlRoleReference> Role 
		{
			get;
		}
	}
    public interface ISql120TSqlServiceReference : ISql120TSqlService
	{
    }
	public interface ISql120TSqlService : ISqlModelElement
	{		
		Boolean UseDefaultContract 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlContractReference> Contracts 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlQueueReference> Queue 
		{
			get;
		}
	}
    public interface ISql120TSqlServiceBrokerLanguageSpecifierReference : ISql120TSqlServiceBrokerLanguageSpecifier
	{
    }
	public interface ISql120TSqlServiceBrokerLanguageSpecifier : ISqlModelElement
	{		
		ServiceBrokerEncryptionAlgorithm EncryptionAlgorithmPart1 
		{
			get;
		}
		ServiceBrokerEncryptionAlgorithm EncryptionAlgorithmPart2 
		{
			get;
		}
		EncryptionMode EncryptionMode 
		{
			get;
		}
		Boolean MessageForwardingEnabled 
		{
			get;
		}
		Int32 MessageForwardSize 
		{
			get;
		}
		Boolean UseCertificateFirst 
		{
			get;
		}
		AuthenticationModes WindowsAuthenticationMode 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlCertificateReference> AuthenticationCertificate 
		{
			get;
		}
	}
    public interface ISql120TSqlSignatureReference : ISql120TSqlSignature
	{
    }
	public interface ISql120TSqlSignature : ISqlModelElement
	{		
		Boolean IsCounterSignature 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.TSqlModelElement> EncryptionMechanism 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> SignedObject 
		{
			get;
		}
	}
    public interface ISql120TSqlSignatureEncryptionMechanismReference : ISql120TSqlSignatureEncryptionMechanism
	{
    }
	public interface ISql120TSqlSignatureEncryptionMechanism : ISqlModelElement
	{		
		String Password 
		{
			get;
		}
		String SignedBlob 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlAsymmetricKeyReference> AsymmetricKey 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlCertificateReference> Certificate 
		{
			get;
		}
	}
    public interface ISql120TSqlSoapLanguageSpecifierReference : ISql120TSqlSoapLanguageSpecifier
	{
    }
	public interface ISql120TSqlSoapLanguageSpecifier : ISqlModelElement
	{		
	}
    public interface ISql120TSqlSoapMethodSpecificationReference : ISql120TSqlSoapMethodSpecification
	{
    }
	public interface ISql120TSqlSoapMethodSpecification : ISqlModelElement
	{		
	}
    public interface ISql120TSqlSpatialIndexReference : ISql120TSqlSpatialIndex
	{
    }
	public interface ISql120TSqlSpatialIndex : ISqlModelElement
	{		
		Boolean AllowPageLocks 
		{
			get;
		}
		Boolean AllowRowLocks 
		{
			get;
		}
		Int32? CellsPerObject 
		{
			get;
		}
		CompressionLevel DataCompression 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Int32 FillFactor 
		{
			get;
		}
		Degree GridLevel1Density 
		{
			get;
		}
		Degree GridLevel2Density 
		{
			get;
		}
		Degree GridLevel3Density 
		{
			get;
		}
		Degree GridLevel4Density 
		{
			get;
		}
		Boolean IgnoreDuplicateKey 
		{
			get;
		}
		Boolean RecomputeStatistics 
		{
			get;
		}
		Tessellation Tessellation 
		{
			get;
		}
		Boolean WithPadIndex 
		{
			get;
		}
		Double? XMax 
		{
			get;
		}
		Double? XMin 
		{
			get;
		}
		Double? YMax 
		{
			get;
		}
		Double? YMin 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlColumnReference> Column 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlFilegroupReference> Filegroup 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISpecifiesIndex> IndexedObject 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlColumnReference> PartitionColumn 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlPartitionSchemeReference> PartitionScheme 
		{
			get;
		}
	}
    public interface ISql120TSqlStatisticsReference : ISql120TSqlStatistics
	{
    }
	public interface ISql120TSqlStatistics : ISqlModelElement
	{		
		String FilterPredicate 
		{
			get;
		}
		Boolean Incremental 
		{
			get;
		}
		Boolean NoRecompute 
		{
			get;
		}
		Int32 SampleSize 
		{
			get;
		}
		SamplingStyle SamplingStyle 
		{
			get;
		}
		String StatsStream 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlColumnReference> Columns 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ExpressionDependencies 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> OnObject 
		{
			get;
		}
	}
    public interface ISql120TSqlParameterReference : ISql120TSqlParameter
	{
    }
	public interface ISql120TSqlParameter : ISqlModelElement
	{		
		String DefaultExpression 
		{
			get;
		}
		Boolean IsMax 
		{
			get;
		}
		Boolean IsOutput 
		{
			get;
		}
		Int32 Length 
		{
			get;
		}
		Int32 Precision 
		{
			get;
		}
		Boolean ReadOnly 
		{
			get;
		}
		Int32 Scale 
		{
			get;
		}
		Boolean Varying 
		{
			get;
		}
		XmlStyle XmlStyle 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlDataType> DataType 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlXmlSchemaCollectionReference> XmlSchemaCollection 
		{
			get;
		}
	}
    public interface ISql120TSqlSymmetricKeyReference : ISql120TSqlSymmetricKey
	{
    }
	public interface ISql120TSqlSymmetricKey : ISqlModelElement
	{		
		SymmetricKeyAlgorithm Algorithm 
		{
			get;
		}
		SymmetricKeyCreationDisposition CreationDisposition 
		{
			get;
		}
		String IdentityValue 
		{
			get;
		}
		String KeySource 
		{
			get;
		}
		String ProviderKeyName 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlAsymmetricKeyReference> AsymmetricKeys 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlCertificateReference> Certificates 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.TSqlModelElement> Passwords 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> Provider 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlSymmetricKeyReference> SymmetricKeys 
		{
			get;
		}
	}
    public interface ISql120TSqlSymmetricKeyPasswordReference : ISql120TSqlSymmetricKeyPassword
	{
    }
	public interface ISql120TSqlSymmetricKeyPassword : ISqlModelElement
	{		
		String Password 
		{
			get;
		}
	}
    public interface ISql120TSqlSynonymReference : ISql120TSqlSynonym
	{
    }
	public interface ISql120TSqlSynonym : ISqlModelElement
	{		
		String ForObjectName 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ForObject 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISql120TSqlTableReference : ISql120TSqlTable
	{
    }
	public interface ISql120TSqlTable : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		Boolean ChangeDataCaptureEnabled 
		{
			get;
		}
		Boolean ChangeTrackingEnabled 
		{
			get;
		}
		Int64? DataPages 
		{
			get;
		}
		Double? DataSize 
		{
			get;
		}
		Durability Durability 
		{
			get;
		}
		Boolean? FileStreamNull 
		{
			get;
		}
		Double? IndexSize 
		{
			get;
		}
		Boolean IsAutoGeneratedHistoryTable 
		{
			get;
		}
		Boolean IsReplicated 
		{
			get;
		}
		Boolean LargeValueTypesOutOfRow 
		{
			get;
		}
		LockEscalationMethod LockEscalation 
		{
			get;
		}
		Boolean MemoryOptimized 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		Int64? RowCount 
		{
			get;
		}
		Boolean TableLockOnBulkLoad 
		{
			get;
		}
		Int32 TextInRowSize 
		{
			get;
		}
		Boolean TrackColumnsUpdated 
		{
			get;
		}
		Int64? UsedPages 
		{
			get;
		}
		Boolean VardecimalStorageFormatEnabled 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlColumn> Columns 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlDataCompressionOption> DataCompressionOptions 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlFilegroupReference> Filegroup 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlFilegroupReference> FilegroupForTextImage 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlFilegroupReference> FileStreamFilegroup 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlPartitionSchemeReference> FileStreamPartitionScheme 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlColumnReference> PartitionColumn 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlPartitionSchemeReference> PartitionScheme 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISql120TSqlFileTableReference : ISql120TSqlFileTable
	{
    }
	public interface ISql120TSqlFileTable : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		Boolean? FileStreamNull 
		{
			get;
		}
		String FileTableCollateFilename 
		{
			get;
		}
		String FileTableDirectory 
		{
			get;
		}
		Boolean FileTableNamespaceEnabled 
		{
			get;
		}
		LockEscalationMethod LockEscalation 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		Boolean TableLockOnBulkLoad 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlColumn> Columns 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlDataCompressionOption> DataCompressionOptions 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlFilegroupReference> Filegroup 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlFilegroupReference> FileStreamFilegroup 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlPartitionSchemeReference> FileStreamPartitionScheme 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlColumnReference> PartitionColumn 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlPartitionSchemeReference> PartitionScheme 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISql120TSqlTableTypeReference : ISql120TSqlTableType
	{
    }
	public interface ISql120TSqlTableType : ISqlModelElement
	{		
		Boolean MemoryOptimized 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlTableTypeColumn> Columns 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ITableTypeConstraint> Constraints 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.TSqlTableTypeIndex> Indexes 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISql120TSqlTableTypeCheckConstraintReference : ISql120TSqlTableTypeCheckConstraint
	{
    }
	public interface ISql120TSqlTableTypeCheckConstraint : ISqlModelElement
	{		
		String Expression 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ExpressionDependencies 
		{
			get;
		}
	}
    public interface ISql120TSqlTableTypeColumnReference : ISql120TSqlTableTypeColumn
	{
    }
	public interface ISql120TSqlTableTypeColumn : ISqlModelElement
	{		
		String Collation 
		{
			get;
		}
		String Expression 
		{
			get;
		}
		String IdentityIncrement 
		{
			get;
		}
		String IdentitySeed 
		{
			get;
		}
		Boolean IsIdentity 
		{
			get;
		}
		Boolean IsMax 
		{
			get;
		}
		Boolean IsRowGuidCol 
		{
			get;
		}
		Int32 Length 
		{
			get;
		}
		Boolean Nullable 
		{
			get;
		}
		Boolean Persisted 
		{
			get;
		}
		Boolean? PersistedNullable 
		{
			get;
		}
		Int32 Precision 
		{
			get;
		}
		Int32 Scale 
		{
			get;
		}
		XmlStyle XmlStyle 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlDataType> DataType 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ExpressionDependencies 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlXmlSchemaCollectionReference> XmlSchemaCollection 
		{
			get;
		}
	}
    public interface ISql120TSqlTableTypeDefaultConstraintReference : ISql120TSqlTableTypeDefaultConstraint
	{
    }
	public interface ISql120TSqlTableTypeDefaultConstraint : ISqlModelElement
	{		
		String Expression 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ExpressionDependencies 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlColumnReference> TargetColumn 
		{
			get;
		}
	}
    public interface ISql120TSqlTableTypeIndexReference : ISql120TSqlTableTypeIndex
	{
    }
	public interface ISql120TSqlTableTypeIndex : ISqlModelElement
	{		
		Int32? BucketCount 
		{
			get;
		}
		Boolean Hash 
		{
			get;
		}
		Boolean IsDisabled 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlColumnReference> Columns 
		{
			get;
		}
	}
    public interface ISql120TSqlTableTypePrimaryKeyConstraintReference : ISql120TSqlTableTypePrimaryKeyConstraint
	{
    }
	public interface ISql120TSqlTableTypePrimaryKeyConstraint : ISqlModelElement
	{		
		Int32? BucketCount 
		{
			get;
		}
		Boolean Clustered 
		{
			get;
		}
		Boolean Hash 
		{
			get;
		}
		Boolean IgnoreDuplicateKey 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlColumnReference> Columns 
		{
			get;
		}
	}
    public interface ISql120TSqlTableTypeUniqueConstraintReference : ISql120TSqlTableTypeUniqueConstraint
	{
    }
	public interface ISql120TSqlTableTypeUniqueConstraint : ISqlModelElement
	{		
		Int32? BucketCount 
		{
			get;
		}
		Boolean Clustered 
		{
			get;
		}
		Boolean Hash 
		{
			get;
		}
		Boolean IgnoreDuplicateKey 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlColumnReference> Columns 
		{
			get;
		}
	}
    public interface ISql120TSqlTcpProtocolSpecifierReference : ISql120TSqlTcpProtocolSpecifier
	{
    }
	public interface ISql120TSqlTcpProtocolSpecifier : ISqlModelElement
	{		
		String ListenerIPv4 
		{
			get;
		}
		String ListenerIPv6 
		{
			get;
		}
		Int32 ListenerPort 
		{
			get;
		}
		Boolean ListeningOnAllIPs 
		{
			get;
		}
	}
    public interface ISql120TSqlUniqueConstraintReference : ISql120TSqlUniqueConstraint
	{
    }
	public interface ISql120TSqlUniqueConstraint : ISqlModelElement
	{		
		Boolean AllowPageLocks 
		{
			get;
		}
		Boolean AllowRowLocks 
		{
			get;
		}
		Int32? BucketCount 
		{
			get;
		}
		Boolean Clustered 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Boolean? FileStreamNull 
		{
			get;
		}
		Int32? FillFactor 
		{
			get;
		}
		Boolean Hash 
		{
			get;
		}
		Boolean IgnoreDuplicateKey 
		{
			get;
		}
		Boolean RecomputeStatistics 
		{
			get;
		}
		Boolean WithPadIndex 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlColumnReference> Columns 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlDataCompressionOption> DataCompressionOptions 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlFilegroupReference> Filegroup 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlFilegroupReference> FileStreamFilegroup 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlPartitionSchemeReference> FileStreamPartitionScheme 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlTableReference> Host 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlColumnReference> PartitionColumn 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlPartitionSchemeReference> PartitionScheme 
		{
			get;
		}
	}
    public interface ISql120TSqlUserReference : ISql120TSqlUser
	{
    }
	public interface ISql120TSqlUser : ISqlModelElement
	{		
		AuthenticationType AuthenticationType 
		{
			get;
		}
		String DefaultLanguage 
		{
			get;
		}
		String Password 
		{
			get;
		}
		String Sid 
		{
			get;
		}
		Boolean WithoutLogin 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlAsymmetricKeyReference> AsymmetricKey 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlCertificateReference> Certificate 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlSchemaReference> DefaultSchema 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlLoginReference> Login 
		{
			get;
		}
	}
    public interface ISql120TSqlUserDefinedServerRoleReference : ISql120TSqlUserDefinedServerRole
	{
    }
	public interface ISql120TSqlUserDefinedServerRole : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
	}
    public interface ISql120TSqlUserDefinedTypeReference : ISql120TSqlUserDefinedType
	{
    }
	public interface ISql120TSqlUserDefinedType : ISqlModelElement
	{		
		Boolean? ByteOrdered 
		{
			get;
		}
		String ClassName 
		{
			get;
		}
		Boolean? FixedLength 
		{
			get;
		}
		Format Format 
		{
			get;
		}
		Int32? MaxByteSize 
		{
			get;
		}
		String ValidationMethodName 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlAssemblyReference> Assembly 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.TSqlModelElement> Methods 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.TSqlModelElement> Properties 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISql120TSqlViewReference : ISql120TSqlView
	{
    }
	public interface ISql120TSqlView : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		Boolean Replicated 
		{
			get;
		}
		String SelectStatement 
		{
			get;
		}
		Boolean WithCheckOption 
		{
			get;
		}
		Boolean WithEncryption 
		{
			get;
		}
		Boolean WithSchemaBinding 
		{
			get;
		}
		Boolean WithViewMetadata 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BodyDependencies 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlColumn> Columns 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISql120TSqlWorkloadGroupReference : ISql120TSqlWorkloadGroup
	{
    }
	public interface ISql120TSqlWorkloadGroup : ISqlModelElement
	{		
		Int32 GroupMaxRequests 
		{
			get;
		}
		Degree Importance 
		{
			get;
		}
		Int32 MaxDop 
		{
			get;
		}
		Int32 RequestMaxCpuTimeSec 
		{
			get;
		}
		Int32 RequestMaxMemoryGrantPercent 
		{
			get;
		}
		Int32 RequestMemoryGrantTimeoutSec 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlResourcePoolReference> ResourcePool 
		{
			get;
		}
	}
    public interface ISql120TSqlXmlIndexReference : ISql120TSqlXmlIndex
	{
    }
	public interface ISql120TSqlXmlIndex : ISqlModelElement
	{		
		Boolean AllowPageLocks 
		{
			get;
		}
		Boolean AllowRowLocks 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Int32? FillFactor 
		{
			get;
		}
		Boolean IgnoreDuplicateKey 
		{
			get;
		}
		Boolean IsPrimary 
		{
			get;
		}
		Boolean RecomputeStatistics 
		{
			get;
		}
		SecondaryXmlIndexType SecondaryXmlIndexType 
		{
			get;
		}
		Boolean WithPadIndex 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlColumnReference> Column 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISpecifiesIndex> IndexedObject 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlXmlIndexReference> PrimaryXmlIndex 
		{
			get;
		}
	}
    public interface ISql120TSqlSelectiveXmlIndexReference : ISql120TSqlSelectiveXmlIndex
	{
    }
	public interface ISql120TSqlSelectiveXmlIndex : ISqlModelElement
	{		
		Boolean AllowPageLocks 
		{
			get;
		}
		Boolean AllowRowLocks 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Int32? FillFactor 
		{
			get;
		}
		Boolean IgnoreDuplicateKey 
		{
			get;
		}
		Boolean IsPrimary 
		{
			get;
		}
		Boolean RecomputeStatistics 
		{
			get;
		}
		Boolean WithPadIndex 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlColumnReference> Column 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISpecifiesIndex> IndexedObject 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlPromotedNodePath> PrimaryPromotedPath 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlSelectiveXmlIndexReference> PrimarySelectiveXmlIndex 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlPromotedNodePath> PromotedPaths 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlXmlNamespace> XmlNamespaces 
		{
			get;
		}
	}
    public interface ISql120TSqlXmlNamespaceReference : ISql120TSqlXmlNamespace
	{
    }
	public interface ISql120TSqlXmlNamespace : ISqlModelElement
	{		
		String NamespaceUri 
		{
			get;
		}
		String Prefix 
		{
			get;
		}
	}
    public interface ISql120TSqlPromotedNodePathForXQueryTypeReference : ISql120TSqlPromotedNodePathForXQueryType
	{
    }
	public interface ISql120TSqlPromotedNodePathForXQueryType : ISqlModelElement
	{		
		Boolean IsSingleton 
		{
			get;
		}
		Int32? MaxLength 
		{
			get;
		}
		String NodePath 
		{
			get;
		}
		String Type 
		{
			get;
		}
	}
    public interface ISql120TSqlPromotedNodePathForSqlTypeReference : ISql120TSqlPromotedNodePathForSqlType
	{
    }
	public interface ISql120TSqlPromotedNodePathForSqlType : ISqlModelElement
	{		
		Boolean IsMax 
		{
			get;
		}
		Boolean IsSingleton 
		{
			get;
		}
		Int32 Length 
		{
			get;
		}
		String NodePath 
		{
			get;
		}
		Int32 Precision 
		{
			get;
		}
		Int32 Scale 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlDataTypeReference> DataType 
		{
			get;
		}
	}
    public interface ISql120TSqlXmlSchemaCollectionReference : ISql120TSqlXmlSchemaCollection
	{
    }
	public interface ISql120TSqlXmlSchemaCollection : ISqlModelElement
	{		
		String Expression 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISql120TSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISql130TSqlColumnReference : ISql130TSqlColumn
	{
    }
	public interface ISql130TSqlColumn : ISqlModelElement
	{		
	}
    public interface ISql130TSqlTableValuedFunctionReference : ISql130TSqlTableValuedFunction
	{
    }
	public interface ISql130TSqlTableValuedFunction : ISqlModelElement
	{		
	}
    public interface ISql130TSqlScalarFunctionReference : ISql130TSqlScalarFunction
	{
    }
	public interface ISql130TSqlScalarFunction : ISqlModelElement
	{		
	}
    public interface ISql130TSqlClrTableOptionReference : ISql130TSqlClrTableOption
	{
    }
	public interface ISql130TSqlClrTableOption : ISqlModelElement
	{		
	}
    public interface ISql130TSqlAggregateReference : ISql130TSqlAggregate
	{
    }
	public interface ISql130TSqlAggregate : ISqlModelElement
	{		
	}
    public interface ISql130TSqlApplicationRoleReference : ISql130TSqlApplicationRole
	{
    }
	public interface ISql130TSqlApplicationRole : ISqlModelElement
	{		
	}
    public interface ISql130TSqlIndexReference : ISql130TSqlIndex
	{
    }
	public interface ISql130TSqlIndex : ISqlModelElement
	{		
	}
    public interface ISql130TSqlAssemblyReference : ISql130TSqlAssembly
	{
    }
	public interface ISql130TSqlAssembly : ISqlModelElement
	{		
	}
    public interface ISql130TSqlAssemblySourceReference : ISql130TSqlAssemblySource
	{
    }
	public interface ISql130TSqlAssemblySource : ISqlModelElement
	{		
	}
    public interface ISql130TSqlAsymmetricKeyReference : ISql130TSqlAsymmetricKey
	{
    }
	public interface ISql130TSqlAsymmetricKey : ISqlModelElement
	{		
	}
    public interface ISql130TSqlAuditActionReference : ISql130TSqlAuditAction
	{
    }
	public interface ISql130TSqlAuditAction : ISqlModelElement
	{		
	}
    public interface ISql130TSqlAuditActionGroupReference : ISql130TSqlAuditActionGroup
	{
    }
	public interface ISql130TSqlAuditActionGroup : ISqlModelElement
	{		
	}
    public interface ISql130TSqlAuditActionSpecificationReference : ISql130TSqlAuditActionSpecification
	{
    }
	public interface ISql130TSqlAuditActionSpecification : ISqlModelElement
	{		
	}
    public interface ISql130TSqlBrokerPriorityReference : ISql130TSqlBrokerPriority
	{
    }
	public interface ISql130TSqlBrokerPriority : ISqlModelElement
	{		
	}
    public interface ISql130TSqlBuiltInServerRoleReference : ISql130TSqlBuiltInServerRole
	{
    }
	public interface ISql130TSqlBuiltInServerRole : ISqlModelElement
	{		
	}
    public interface ISql130TSqlDataTypeReference : ISql130TSqlDataType
	{
    }
	public interface ISql130TSqlDataType : ISqlModelElement
	{		
	}
    public interface ISql130TSqlCertificateReference : ISql130TSqlCertificate
	{
    }
	public interface ISql130TSqlCertificate : ISqlModelElement
	{		
	}
    public interface ISql130TSqlCheckConstraintReference : ISql130TSqlCheckConstraint
	{
    }
	public interface ISql130TSqlCheckConstraint : ISqlModelElement
	{		
	}
    public interface ISql130TSqlClrTypeMethodReference : ISql130TSqlClrTypeMethod
	{
    }
	public interface ISql130TSqlClrTypeMethod : ISqlModelElement
	{		
	}
    public interface ISql130TSqlClrTypeMethodParameterReference : ISql130TSqlClrTypeMethodParameter
	{
    }
	public interface ISql130TSqlClrTypeMethodParameter : ISqlModelElement
	{		
	}
    public interface ISql130TSqlClrTypePropertyReference : ISql130TSqlClrTypeProperty
	{
    }
	public interface ISql130TSqlClrTypeProperty : ISqlModelElement
	{		
	}
    public interface ISql130TSqlColumnStoreIndexReference : ISql130TSqlColumnStoreIndex
	{
    }
	public interface ISql130TSqlColumnStoreIndex : ISqlModelElement
	{		
	}
    public interface ISql130TSqlContractReference : ISql130TSqlContract
	{
    }
	public interface ISql130TSqlContract : ISqlModelElement
	{		
	}
    public interface ISql130TSqlCredentialReference : ISql130TSqlCredential
	{
    }
	public interface ISql130TSqlCredential : ISqlModelElement
	{		
	}
    public interface ISql130TSqlDatabaseCredentialReference : ISql130TSqlDatabaseCredential
	{
    }
	public interface ISql130TSqlDatabaseCredential : ISqlModelElement
	{		
	}
    public interface ISql130TSqlCryptographicProviderReference : ISql130TSqlCryptographicProvider
	{
    }
	public interface ISql130TSqlCryptographicProvider : ISqlModelElement
	{		
	}
    public interface ISql130TSqlDatabaseAuditSpecificationReference : ISql130TSqlDatabaseAuditSpecification
	{
    }
	public interface ISql130TSqlDatabaseAuditSpecification : ISqlModelElement
	{		
	}
    public interface ISql130TSqlDatabaseDdlTriggerReference : ISql130TSqlDatabaseDdlTrigger
	{
    }
	public interface ISql130TSqlDatabaseDdlTrigger : ISqlModelElement
	{		
	}
    public interface ISql130TSqlDatabaseEncryptionKeyReference : ISql130TSqlDatabaseEncryptionKey
	{
    }
	public interface ISql130TSqlDatabaseEncryptionKey : ISqlModelElement
	{		
	}
    public interface ISql130TSqlDatabaseEventNotificationReference : ISql130TSqlDatabaseEventNotification
	{
    }
	public interface ISql130TSqlDatabaseEventNotification : ISqlModelElement
	{		
	}
    public interface ISql130TSqlDatabaseMirroringLanguageSpecifierReference : ISql130TSqlDatabaseMirroringLanguageSpecifier
	{
    }
	public interface ISql130TSqlDatabaseMirroringLanguageSpecifier : ISqlModelElement
	{		
	}
    public interface ISql130TSqlDatabaseOptionsReference : ISql130TSqlDatabaseOptions
	{
    }
	public interface ISql130TSqlDatabaseOptions : ISqlModelElement
	{		
	}
    public interface ISql130TSqlDataCompressionOptionReference : ISql130TSqlDataCompressionOption
	{
    }
	public interface ISql130TSqlDataCompressionOption : ISqlModelElement
	{		
	}
    public interface ISql130TSqlDefaultReference : ISql130TSqlDefault
	{
    }
	public interface ISql130TSqlDefault : ISqlModelElement
	{		
	}
    public interface ISql130TSqlDefaultConstraintReference : ISql130TSqlDefaultConstraint
	{
    }
	public interface ISql130TSqlDefaultConstraint : ISqlModelElement
	{		
	}
    public interface ISql130TSqlDmlTriggerReference : ISql130TSqlDmlTrigger
	{
    }
	public interface ISql130TSqlDmlTrigger : ISqlModelElement
	{		
	}
    public interface ISql130TSqlEndpointReference : ISql130TSqlEndpoint
	{
    }
	public interface ISql130TSqlEndpoint : ISqlModelElement
	{		
	}
    public interface ISql130TSqlErrorMessageReference : ISql130TSqlErrorMessage
	{
    }
	public interface ISql130TSqlErrorMessage : ISqlModelElement
	{		
	}
    public interface ISql130TSqlEventGroupReference : ISql130TSqlEventGroup
	{
    }
	public interface ISql130TSqlEventGroup : ISqlModelElement
	{		
	}
    public interface ISql130TSqlEventSessionReference : ISql130TSqlEventSession
	{
    }
	public interface ISql130TSqlEventSession : ISqlModelElement
	{		
	}
    public interface ISql130TSqlDatabaseEventSessionReference : ISql130TSqlDatabaseEventSession
	{
    }
	public interface ISql130TSqlDatabaseEventSession : ISqlModelElement
	{		
	}
    public interface ISql130TSqlEventSessionActionReference : ISql130TSqlEventSessionAction
	{
    }
	public interface ISql130TSqlEventSessionAction : ISqlModelElement
	{		
	}
    public interface ISql130TSqlEventSessionDefinitionsReference : ISql130TSqlEventSessionDefinitions
	{
    }
	public interface ISql130TSqlEventSessionDefinitions : ISqlModelElement
	{		
	}
    public interface ISql130TSqlEventSessionSettingReference : ISql130TSqlEventSessionSetting
	{
    }
	public interface ISql130TSqlEventSessionSetting : ISqlModelElement
	{		
	}
    public interface ISql130TSqlEventSessionTargetReference : ISql130TSqlEventSessionTarget
	{
    }
	public interface ISql130TSqlEventSessionTarget : ISqlModelElement
	{		
	}
    public interface ISql130TSqlEventTypeSpecifierReference : ISql130TSqlEventTypeSpecifier
	{
    }
	public interface ISql130TSqlEventTypeSpecifier : ISqlModelElement
	{		
	}
    public interface ISql130TSqlExtendedProcedureReference : ISql130TSqlExtendedProcedure
	{
    }
	public interface ISql130TSqlExtendedProcedure : ISqlModelElement
	{		
	}
    public interface ISql130TSqlExtendedPropertyReference : ISql130TSqlExtendedProperty
	{
    }
	public interface ISql130TSqlExtendedProperty : ISqlModelElement
	{		
	}
    public interface ISql130TSqlExternalDataSourceReference : ISql130TSqlExternalDataSource
	{
    }
	public interface ISql130TSqlExternalDataSource : ISqlModelElement
	{		
	}
    public interface ISql130TSqlExternalFileFormatReference : ISql130TSqlExternalFileFormat
	{
    }
	public interface ISql130TSqlExternalFileFormat : ISqlModelElement
	{		
	}
    public interface ISql130TSqlExternalTableReference : ISql130TSqlExternalTable
	{
    }
	public interface ISql130TSqlExternalTable : ISqlModelElement
	{		
	}
    public interface ISql130TSqlSqlFileReference : ISql130TSqlSqlFile
	{
    }
	public interface ISql130TSqlSqlFile : ISqlModelElement
	{		
	}
    public interface ISql130TSqlFilegroupReference : ISql130TSqlFilegroup
	{
    }
	public interface ISql130TSqlFilegroup : ISqlModelElement
	{		
	}
    public interface ISql130TSqlForeignKeyConstraintReference : ISql130TSqlForeignKeyConstraint
	{
    }
	public interface ISql130TSqlForeignKeyConstraint : ISqlModelElement
	{		
	}
    public interface ISql130TSqlFullTextCatalogReference : ISql130TSqlFullTextCatalog
	{
    }
	public interface ISql130TSqlFullTextCatalog : ISqlModelElement
	{		
	}
    public interface ISql130TSqlFullTextIndexReference : ISql130TSqlFullTextIndex
	{
    }
	public interface ISql130TSqlFullTextIndex : ISqlModelElement
	{		
	}
    public interface ISql130TSqlFullTextIndexColumnSpecifierReference : ISql130TSqlFullTextIndexColumnSpecifier
	{
    }
	public interface ISql130TSqlFullTextIndexColumnSpecifier : ISqlModelElement
	{		
	}
    public interface ISql130TSqlFullTextStopListReference : ISql130TSqlFullTextStopList
	{
    }
	public interface ISql130TSqlFullTextStopList : ISqlModelElement
	{		
	}
    public interface ISql130TSqlHttpProtocolSpecifierReference : ISql130TSqlHttpProtocolSpecifier
	{
    }
	public interface ISql130TSqlHttpProtocolSpecifier : ISqlModelElement
	{		
	}
    public interface ISql130TSqlLinkedServerReference : ISql130TSqlLinkedServer
	{
    }
	public interface ISql130TSqlLinkedServer : ISqlModelElement
	{		
	}
    public interface ISql130TSqlLinkedServerLoginReference : ISql130TSqlLinkedServerLogin
	{
    }
	public interface ISql130TSqlLinkedServerLogin : ISqlModelElement
	{		
	}
    public interface ISql130TSqlLoginReference : ISql130TSqlLogin
	{
    }
	public interface ISql130TSqlLogin : ISqlModelElement
	{		
	}
    public interface ISql130TSqlMasterKeyReference : ISql130TSqlMasterKey
	{
    }
	public interface ISql130TSqlMasterKey : ISqlModelElement
	{		
	}
    public interface ISql130TSqlMessageTypeReference : ISql130TSqlMessageType
	{
    }
	public interface ISql130TSqlMessageType : ISqlModelElement
	{		
	}
    public interface ISql130TSqlPartitionFunctionReference : ISql130TSqlPartitionFunction
	{
    }
	public interface ISql130TSqlPartitionFunction : ISqlModelElement
	{		
	}
    public interface ISql130TSqlPartitionSchemeReference : ISql130TSqlPartitionScheme
	{
    }
	public interface ISql130TSqlPartitionScheme : ISqlModelElement
	{		
	}
    public interface ISql130TSqlPartitionValueReference : ISql130TSqlPartitionValue
	{
    }
	public interface ISql130TSqlPartitionValue : ISqlModelElement
	{		
	}
    public interface ISql130TSqlPermissionReference : ISql130TSqlPermission
	{
    }
	public interface ISql130TSqlPermission : ISqlModelElement
	{		
	}
    public interface ISql130TSqlPrimaryKeyConstraintReference : ISql130TSqlPrimaryKeyConstraint
	{
    }
	public interface ISql130TSqlPrimaryKeyConstraint : ISqlModelElement
	{		
	}
    public interface ISql130TSqlProcedureReference : ISql130TSqlProcedure
	{
    }
	public interface ISql130TSqlProcedure : ISqlModelElement
	{		
	}
    public interface ISql130TSqlQueueReference : ISql130TSqlQueue
	{
    }
	public interface ISql130TSqlQueue : ISqlModelElement
	{		
	}
    public interface ISql130TSqlQueueEventNotificationReference : ISql130TSqlQueueEventNotification
	{
    }
	public interface ISql130TSqlQueueEventNotification : ISqlModelElement
	{		
	}
    public interface ISql130TSqlRemoteServiceBindingReference : ISql130TSqlRemoteServiceBinding
	{
    }
	public interface ISql130TSqlRemoteServiceBinding : ISqlModelElement
	{		
	}
    public interface ISql130TSqlResourceGovernorReference : ISql130TSqlResourceGovernor
	{
    }
	public interface ISql130TSqlResourceGovernor : ISqlModelElement
	{		
	}
    public interface ISql130TSqlResourcePoolReference : ISql130TSqlResourcePool
	{
    }
	public interface ISql130TSqlResourcePool : ISqlModelElement
	{		
	}
    public interface ISql130TSqlRoleReference : ISql130TSqlRole
	{
    }
	public interface ISql130TSqlRole : ISqlModelElement
	{		
	}
    public interface ISql130TSqlRoleMembershipReference : ISql130TSqlRoleMembership
	{
    }
	public interface ISql130TSqlRoleMembership : ISqlModelElement
	{		
	}
    public interface ISql130TSqlRouteReference : ISql130TSqlRoute
	{
    }
	public interface ISql130TSqlRoute : ISqlModelElement
	{		
	}
    public interface ISql130TSqlRuleReference : ISql130TSqlRule
	{
    }
	public interface ISql130TSqlRule : ISqlModelElement
	{		
	}
    public interface ISql130TSqlSchemaReference : ISql130TSqlSchema
	{
    }
	public interface ISql130TSqlSchema : ISqlModelElement
	{		
	}
    public interface ISql130TSqlSearchPropertyReference : ISql130TSqlSearchProperty
	{
    }
	public interface ISql130TSqlSearchProperty : ISqlModelElement
	{		
	}
    public interface ISql130TSqlSearchPropertyListReference : ISql130TSqlSearchPropertyList
	{
    }
	public interface ISql130TSqlSearchPropertyList : ISqlModelElement
	{		
	}
    public interface ISql130TSqlSecurityPolicyReference : ISql130TSqlSecurityPolicy
	{
    }
	public interface ISql130TSqlSecurityPolicy : ISqlModelElement
	{		
	}
    public interface ISql130TSqlSecurityPredicateReference : ISql130TSqlSecurityPredicate
	{
    }
	public interface ISql130TSqlSecurityPredicate : ISqlModelElement
	{		
	}
    public interface ISql130TSqlSequenceReference : ISql130TSqlSequence
	{
    }
	public interface ISql130TSqlSequence : ISqlModelElement
	{		
	}
    public interface ISql130TSqlServerAuditReference : ISql130TSqlServerAudit
	{
    }
	public interface ISql130TSqlServerAudit : ISqlModelElement
	{		
	}
    public interface ISql130TSqlServerAuditSpecificationReference : ISql130TSqlServerAuditSpecification
	{
    }
	public interface ISql130TSqlServerAuditSpecification : ISqlModelElement
	{		
	}
    public interface ISql130TSqlServerDdlTriggerReference : ISql130TSqlServerDdlTrigger
	{
    }
	public interface ISql130TSqlServerDdlTrigger : ISqlModelElement
	{		
	}
    public interface ISql130TSqlServerEventNotificationReference : ISql130TSqlServerEventNotification
	{
    }
	public interface ISql130TSqlServerEventNotification : ISqlModelElement
	{		
	}
    public interface ISql130TSqlServerOptionsReference : ISql130TSqlServerOptions
	{
    }
	public interface ISql130TSqlServerOptions : ISqlModelElement
	{		
	}
    public interface ISql130TSqlServerRoleMembershipReference : ISql130TSqlServerRoleMembership
	{
    }
	public interface ISql130TSqlServerRoleMembership : ISqlModelElement
	{		
	}
    public interface ISql130TSqlServiceReference : ISql130TSqlService
	{
    }
	public interface ISql130TSqlService : ISqlModelElement
	{		
	}
    public interface ISql130TSqlServiceBrokerLanguageSpecifierReference : ISql130TSqlServiceBrokerLanguageSpecifier
	{
    }
	public interface ISql130TSqlServiceBrokerLanguageSpecifier : ISqlModelElement
	{		
	}
    public interface ISql130TSqlSignatureReference : ISql130TSqlSignature
	{
    }
	public interface ISql130TSqlSignature : ISqlModelElement
	{		
	}
    public interface ISql130TSqlSignatureEncryptionMechanismReference : ISql130TSqlSignatureEncryptionMechanism
	{
    }
	public interface ISql130TSqlSignatureEncryptionMechanism : ISqlModelElement
	{		
	}
    public interface ISql130TSqlSoapLanguageSpecifierReference : ISql130TSqlSoapLanguageSpecifier
	{
    }
	public interface ISql130TSqlSoapLanguageSpecifier : ISqlModelElement
	{		
	}
    public interface ISql130TSqlSoapMethodSpecificationReference : ISql130TSqlSoapMethodSpecification
	{
    }
	public interface ISql130TSqlSoapMethodSpecification : ISqlModelElement
	{		
	}
    public interface ISql130TSqlSpatialIndexReference : ISql130TSqlSpatialIndex
	{
    }
	public interface ISql130TSqlSpatialIndex : ISqlModelElement
	{		
	}
    public interface ISql130TSqlStatisticsReference : ISql130TSqlStatistics
	{
    }
	public interface ISql130TSqlStatistics : ISqlModelElement
	{		
	}
    public interface ISql130TSqlParameterReference : ISql130TSqlParameter
	{
    }
	public interface ISql130TSqlParameter : ISqlModelElement
	{		
	}
    public interface ISql130TSqlSymmetricKeyReference : ISql130TSqlSymmetricKey
	{
    }
	public interface ISql130TSqlSymmetricKey : ISqlModelElement
	{		
	}
    public interface ISql130TSqlSymmetricKeyPasswordReference : ISql130TSqlSymmetricKeyPassword
	{
    }
	public interface ISql130TSqlSymmetricKeyPassword : ISqlModelElement
	{		
	}
    public interface ISql130TSqlSynonymReference : ISql130TSqlSynonym
	{
    }
	public interface ISql130TSqlSynonym : ISqlModelElement
	{		
	}
    public interface ISql130TSqlTableReference : ISql130TSqlTable
	{
    }
	public interface ISql130TSqlTable : ISqlModelElement
	{		
	}
    public interface ISql130TSqlFileTableReference : ISql130TSqlFileTable
	{
    }
	public interface ISql130TSqlFileTable : ISqlModelElement
	{		
	}
    public interface ISql130TSqlTableTypeReference : ISql130TSqlTableType
	{
    }
	public interface ISql130TSqlTableType : ISqlModelElement
	{		
	}
    public interface ISql130TSqlTableTypeCheckConstraintReference : ISql130TSqlTableTypeCheckConstraint
	{
    }
	public interface ISql130TSqlTableTypeCheckConstraint : ISqlModelElement
	{		
	}
    public interface ISql130TSqlTableTypeColumnReference : ISql130TSqlTableTypeColumn
	{
    }
	public interface ISql130TSqlTableTypeColumn : ISqlModelElement
	{		
	}
    public interface ISql130TSqlTableTypeDefaultConstraintReference : ISql130TSqlTableTypeDefaultConstraint
	{
    }
	public interface ISql130TSqlTableTypeDefaultConstraint : ISqlModelElement
	{		
	}
    public interface ISql130TSqlTableTypeIndexReference : ISql130TSqlTableTypeIndex
	{
    }
	public interface ISql130TSqlTableTypeIndex : ISqlModelElement
	{		
	}
    public interface ISql130TSqlTableTypePrimaryKeyConstraintReference : ISql130TSqlTableTypePrimaryKeyConstraint
	{
    }
	public interface ISql130TSqlTableTypePrimaryKeyConstraint : ISqlModelElement
	{		
	}
    public interface ISql130TSqlTableTypeUniqueConstraintReference : ISql130TSqlTableTypeUniqueConstraint
	{
    }
	public interface ISql130TSqlTableTypeUniqueConstraint : ISqlModelElement
	{		
	}
    public interface ISql130TSqlTcpProtocolSpecifierReference : ISql130TSqlTcpProtocolSpecifier
	{
    }
	public interface ISql130TSqlTcpProtocolSpecifier : ISqlModelElement
	{		
	}
    public interface ISql130TSqlUniqueConstraintReference : ISql130TSqlUniqueConstraint
	{
    }
	public interface ISql130TSqlUniqueConstraint : ISqlModelElement
	{		
	}
    public interface ISql130TSqlUserReference : ISql130TSqlUser
	{
    }
	public interface ISql130TSqlUser : ISqlModelElement
	{		
	}
    public interface ISql130TSqlUserDefinedServerRoleReference : ISql130TSqlUserDefinedServerRole
	{
    }
	public interface ISql130TSqlUserDefinedServerRole : ISqlModelElement
	{		
	}
    public interface ISql130TSqlUserDefinedTypeReference : ISql130TSqlUserDefinedType
	{
    }
	public interface ISql130TSqlUserDefinedType : ISqlModelElement
	{		
	}
    public interface ISql130TSqlViewReference : ISql130TSqlView
	{
    }
	public interface ISql130TSqlView : ISqlModelElement
	{		
	}
    public interface ISql130TSqlWorkloadGroupReference : ISql130TSqlWorkloadGroup
	{
    }
	public interface ISql130TSqlWorkloadGroup : ISqlModelElement
	{		
	}
    public interface ISql130TSqlXmlIndexReference : ISql130TSqlXmlIndex
	{
    }
	public interface ISql130TSqlXmlIndex : ISqlModelElement
	{		
	}
    public interface ISql130TSqlSelectiveXmlIndexReference : ISql130TSqlSelectiveXmlIndex
	{
    }
	public interface ISql130TSqlSelectiveXmlIndex : ISqlModelElement
	{		
	}
    public interface ISql130TSqlXmlNamespaceReference : ISql130TSqlXmlNamespace
	{
    }
	public interface ISql130TSqlXmlNamespace : ISqlModelElement
	{		
	}
    public interface ISql130TSqlPromotedNodePathForXQueryTypeReference : ISql130TSqlPromotedNodePathForXQueryType
	{
    }
	public interface ISql130TSqlPromotedNodePathForXQueryType : ISqlModelElement
	{		
	}
    public interface ISql130TSqlPromotedNodePathForSqlTypeReference : ISql130TSqlPromotedNodePathForSqlType
	{
    }
	public interface ISql130TSqlPromotedNodePathForSqlType : ISqlModelElement
	{		
	}
    public interface ISql130TSqlXmlSchemaCollectionReference : ISql130TSqlXmlSchemaCollection
	{
    }
	public interface ISql130TSqlXmlSchemaCollection : ISqlModelElement
	{		
	}
    public interface ISql140TSqlColumnReference : ISql140TSqlColumn
	{
    }
	public interface ISql140TSqlColumn : ISqlModelElement
	{		
	}
    public interface ISql140TSqlTableValuedFunctionReference : ISql140TSqlTableValuedFunction
	{
    }
	public interface ISql140TSqlTableValuedFunction : ISqlModelElement
	{		
	}
    public interface ISql140TSqlScalarFunctionReference : ISql140TSqlScalarFunction
	{
    }
	public interface ISql140TSqlScalarFunction : ISqlModelElement
	{		
	}
    public interface ISql140TSqlClrTableOptionReference : ISql140TSqlClrTableOption
	{
    }
	public interface ISql140TSqlClrTableOption : ISqlModelElement
	{		
	}
    public interface ISql140TSqlAggregateReference : ISql140TSqlAggregate
	{
    }
	public interface ISql140TSqlAggregate : ISqlModelElement
	{		
	}
    public interface ISql140TSqlApplicationRoleReference : ISql140TSqlApplicationRole
	{
    }
	public interface ISql140TSqlApplicationRole : ISqlModelElement
	{		
	}
    public interface ISql140TSqlIndexReference : ISql140TSqlIndex
	{
    }
	public interface ISql140TSqlIndex : ISqlModelElement
	{		
	}
    public interface ISql140TSqlAssemblyReference : ISql140TSqlAssembly
	{
    }
	public interface ISql140TSqlAssembly : ISqlModelElement
	{		
	}
    public interface ISql140TSqlAssemblySourceReference : ISql140TSqlAssemblySource
	{
    }
	public interface ISql140TSqlAssemblySource : ISqlModelElement
	{		
	}
    public interface ISql140TSqlAsymmetricKeyReference : ISql140TSqlAsymmetricKey
	{
    }
	public interface ISql140TSqlAsymmetricKey : ISqlModelElement
	{		
	}
    public interface ISql140TSqlAuditActionReference : ISql140TSqlAuditAction
	{
    }
	public interface ISql140TSqlAuditAction : ISqlModelElement
	{		
	}
    public interface ISql140TSqlAuditActionGroupReference : ISql140TSqlAuditActionGroup
	{
    }
	public interface ISql140TSqlAuditActionGroup : ISqlModelElement
	{		
	}
    public interface ISql140TSqlAuditActionSpecificationReference : ISql140TSqlAuditActionSpecification
	{
    }
	public interface ISql140TSqlAuditActionSpecification : ISqlModelElement
	{		
	}
    public interface ISql140TSqlBrokerPriorityReference : ISql140TSqlBrokerPriority
	{
    }
	public interface ISql140TSqlBrokerPriority : ISqlModelElement
	{		
	}
    public interface ISql140TSqlBuiltInServerRoleReference : ISql140TSqlBuiltInServerRole
	{
    }
	public interface ISql140TSqlBuiltInServerRole : ISqlModelElement
	{		
	}
    public interface ISql140TSqlDataTypeReference : ISql140TSqlDataType
	{
    }
	public interface ISql140TSqlDataType : ISqlModelElement
	{		
	}
    public interface ISql140TSqlCertificateReference : ISql140TSqlCertificate
	{
    }
	public interface ISql140TSqlCertificate : ISqlModelElement
	{		
	}
    public interface ISql140TSqlCheckConstraintReference : ISql140TSqlCheckConstraint
	{
    }
	public interface ISql140TSqlCheckConstraint : ISqlModelElement
	{		
	}
    public interface ISql140TSqlClrTypeMethodReference : ISql140TSqlClrTypeMethod
	{
    }
	public interface ISql140TSqlClrTypeMethod : ISqlModelElement
	{		
	}
    public interface ISql140TSqlClrTypeMethodParameterReference : ISql140TSqlClrTypeMethodParameter
	{
    }
	public interface ISql140TSqlClrTypeMethodParameter : ISqlModelElement
	{		
	}
    public interface ISql140TSqlClrTypePropertyReference : ISql140TSqlClrTypeProperty
	{
    }
	public interface ISql140TSqlClrTypeProperty : ISqlModelElement
	{		
	}
    public interface ISql140TSqlColumnStoreIndexReference : ISql140TSqlColumnStoreIndex
	{
    }
	public interface ISql140TSqlColumnStoreIndex : ISqlModelElement
	{		
	}
    public interface ISql140TSqlContractReference : ISql140TSqlContract
	{
    }
	public interface ISql140TSqlContract : ISqlModelElement
	{		
	}
    public interface ISql140TSqlCredentialReference : ISql140TSqlCredential
	{
    }
	public interface ISql140TSqlCredential : ISqlModelElement
	{		
	}
    public interface ISql140TSqlDatabaseCredentialReference : ISql140TSqlDatabaseCredential
	{
    }
	public interface ISql140TSqlDatabaseCredential : ISqlModelElement
	{		
	}
    public interface ISql140TSqlCryptographicProviderReference : ISql140TSqlCryptographicProvider
	{
    }
	public interface ISql140TSqlCryptographicProvider : ISqlModelElement
	{		
	}
    public interface ISql140TSqlDatabaseAuditSpecificationReference : ISql140TSqlDatabaseAuditSpecification
	{
    }
	public interface ISql140TSqlDatabaseAuditSpecification : ISqlModelElement
	{		
	}
    public interface ISql140TSqlDatabaseDdlTriggerReference : ISql140TSqlDatabaseDdlTrigger
	{
    }
	public interface ISql140TSqlDatabaseDdlTrigger : ISqlModelElement
	{		
	}
    public interface ISql140TSqlDatabaseEncryptionKeyReference : ISql140TSqlDatabaseEncryptionKey
	{
    }
	public interface ISql140TSqlDatabaseEncryptionKey : ISqlModelElement
	{		
	}
    public interface ISql140TSqlDatabaseEventNotificationReference : ISql140TSqlDatabaseEventNotification
	{
    }
	public interface ISql140TSqlDatabaseEventNotification : ISqlModelElement
	{		
	}
    public interface ISql140TSqlDatabaseMirroringLanguageSpecifierReference : ISql140TSqlDatabaseMirroringLanguageSpecifier
	{
    }
	public interface ISql140TSqlDatabaseMirroringLanguageSpecifier : ISqlModelElement
	{		
	}
    public interface ISql140TSqlDatabaseOptionsReference : ISql140TSqlDatabaseOptions
	{
    }
	public interface ISql140TSqlDatabaseOptions : ISqlModelElement
	{		
	}
    public interface ISql140TSqlDataCompressionOptionReference : ISql140TSqlDataCompressionOption
	{
    }
	public interface ISql140TSqlDataCompressionOption : ISqlModelElement
	{		
	}
    public interface ISql140TSqlDefaultReference : ISql140TSqlDefault
	{
    }
	public interface ISql140TSqlDefault : ISqlModelElement
	{		
	}
    public interface ISql140TSqlDefaultConstraintReference : ISql140TSqlDefaultConstraint
	{
    }
	public interface ISql140TSqlDefaultConstraint : ISqlModelElement
	{		
	}
    public interface ISql140TSqlDmlTriggerReference : ISql140TSqlDmlTrigger
	{
    }
	public interface ISql140TSqlDmlTrigger : ISqlModelElement
	{		
	}
    public interface ISql140TSqlEndpointReference : ISql140TSqlEndpoint
	{
    }
	public interface ISql140TSqlEndpoint : ISqlModelElement
	{		
	}
    public interface ISql140TSqlErrorMessageReference : ISql140TSqlErrorMessage
	{
    }
	public interface ISql140TSqlErrorMessage : ISqlModelElement
	{		
	}
    public interface ISql140TSqlEventGroupReference : ISql140TSqlEventGroup
	{
    }
	public interface ISql140TSqlEventGroup : ISqlModelElement
	{		
	}
    public interface ISql140TSqlEventSessionReference : ISql140TSqlEventSession
	{
    }
	public interface ISql140TSqlEventSession : ISqlModelElement
	{		
	}
    public interface ISql140TSqlDatabaseEventSessionReference : ISql140TSqlDatabaseEventSession
	{
    }
	public interface ISql140TSqlDatabaseEventSession : ISqlModelElement
	{		
	}
    public interface ISql140TSqlEventSessionActionReference : ISql140TSqlEventSessionAction
	{
    }
	public interface ISql140TSqlEventSessionAction : ISqlModelElement
	{		
	}
    public interface ISql140TSqlEventSessionDefinitionsReference : ISql140TSqlEventSessionDefinitions
	{
    }
	public interface ISql140TSqlEventSessionDefinitions : ISqlModelElement
	{		
	}
    public interface ISql140TSqlEventSessionSettingReference : ISql140TSqlEventSessionSetting
	{
    }
	public interface ISql140TSqlEventSessionSetting : ISqlModelElement
	{		
	}
    public interface ISql140TSqlEventSessionTargetReference : ISql140TSqlEventSessionTarget
	{
    }
	public interface ISql140TSqlEventSessionTarget : ISqlModelElement
	{		
	}
    public interface ISql140TSqlEventTypeSpecifierReference : ISql140TSqlEventTypeSpecifier
	{
    }
	public interface ISql140TSqlEventTypeSpecifier : ISqlModelElement
	{		
	}
    public interface ISql140TSqlExtendedProcedureReference : ISql140TSqlExtendedProcedure
	{
    }
	public interface ISql140TSqlExtendedProcedure : ISqlModelElement
	{		
	}
    public interface ISql140TSqlExtendedPropertyReference : ISql140TSqlExtendedProperty
	{
    }
	public interface ISql140TSqlExtendedProperty : ISqlModelElement
	{		
	}
    public interface ISql140TSqlExternalDataSourceReference : ISql140TSqlExternalDataSource
	{
    }
	public interface ISql140TSqlExternalDataSource : ISqlModelElement
	{		
	}
    public interface ISql140TSqlExternalFileFormatReference : ISql140TSqlExternalFileFormat
	{
    }
	public interface ISql140TSqlExternalFileFormat : ISqlModelElement
	{		
	}
    public interface ISql140TSqlExternalTableReference : ISql140TSqlExternalTable
	{
    }
	public interface ISql140TSqlExternalTable : ISqlModelElement
	{		
	}
    public interface ISql140TSqlSqlFileReference : ISql140TSqlSqlFile
	{
    }
	public interface ISql140TSqlSqlFile : ISqlModelElement
	{		
	}
    public interface ISql140TSqlFilegroupReference : ISql140TSqlFilegroup
	{
    }
	public interface ISql140TSqlFilegroup : ISqlModelElement
	{		
	}
    public interface ISql140TSqlForeignKeyConstraintReference : ISql140TSqlForeignKeyConstraint
	{
    }
	public interface ISql140TSqlForeignKeyConstraint : ISqlModelElement
	{		
	}
    public interface ISql140TSqlFullTextCatalogReference : ISql140TSqlFullTextCatalog
	{
    }
	public interface ISql140TSqlFullTextCatalog : ISqlModelElement
	{		
	}
    public interface ISql140TSqlFullTextIndexReference : ISql140TSqlFullTextIndex
	{
    }
	public interface ISql140TSqlFullTextIndex : ISqlModelElement
	{		
	}
    public interface ISql140TSqlFullTextIndexColumnSpecifierReference : ISql140TSqlFullTextIndexColumnSpecifier
	{
    }
	public interface ISql140TSqlFullTextIndexColumnSpecifier : ISqlModelElement
	{		
	}
    public interface ISql140TSqlFullTextStopListReference : ISql140TSqlFullTextStopList
	{
    }
	public interface ISql140TSqlFullTextStopList : ISqlModelElement
	{		
	}
    public interface ISql140TSqlHttpProtocolSpecifierReference : ISql140TSqlHttpProtocolSpecifier
	{
    }
	public interface ISql140TSqlHttpProtocolSpecifier : ISqlModelElement
	{		
	}
    public interface ISql140TSqlLinkedServerReference : ISql140TSqlLinkedServer
	{
    }
	public interface ISql140TSqlLinkedServer : ISqlModelElement
	{		
	}
    public interface ISql140TSqlLinkedServerLoginReference : ISql140TSqlLinkedServerLogin
	{
    }
	public interface ISql140TSqlLinkedServerLogin : ISqlModelElement
	{		
	}
    public interface ISql140TSqlLoginReference : ISql140TSqlLogin
	{
    }
	public interface ISql140TSqlLogin : ISqlModelElement
	{		
	}
    public interface ISql140TSqlMasterKeyReference : ISql140TSqlMasterKey
	{
    }
	public interface ISql140TSqlMasterKey : ISqlModelElement
	{		
	}
    public interface ISql140TSqlMessageTypeReference : ISql140TSqlMessageType
	{
    }
	public interface ISql140TSqlMessageType : ISqlModelElement
	{		
	}
    public interface ISql140TSqlPartitionFunctionReference : ISql140TSqlPartitionFunction
	{
    }
	public interface ISql140TSqlPartitionFunction : ISqlModelElement
	{		
	}
    public interface ISql140TSqlPartitionSchemeReference : ISql140TSqlPartitionScheme
	{
    }
	public interface ISql140TSqlPartitionScheme : ISqlModelElement
	{		
	}
    public interface ISql140TSqlPartitionValueReference : ISql140TSqlPartitionValue
	{
    }
	public interface ISql140TSqlPartitionValue : ISqlModelElement
	{		
	}
    public interface ISql140TSqlPermissionReference : ISql140TSqlPermission
	{
    }
	public interface ISql140TSqlPermission : ISqlModelElement
	{		
	}
    public interface ISql140TSqlPrimaryKeyConstraintReference : ISql140TSqlPrimaryKeyConstraint
	{
    }
	public interface ISql140TSqlPrimaryKeyConstraint : ISqlModelElement
	{		
	}
    public interface ISql140TSqlProcedureReference : ISql140TSqlProcedure
	{
    }
	public interface ISql140TSqlProcedure : ISqlModelElement
	{		
	}
    public interface ISql140TSqlQueueReference : ISql140TSqlQueue
	{
    }
	public interface ISql140TSqlQueue : ISqlModelElement
	{		
	}
    public interface ISql140TSqlQueueEventNotificationReference : ISql140TSqlQueueEventNotification
	{
    }
	public interface ISql140TSqlQueueEventNotification : ISqlModelElement
	{		
	}
    public interface ISql140TSqlRemoteServiceBindingReference : ISql140TSqlRemoteServiceBinding
	{
    }
	public interface ISql140TSqlRemoteServiceBinding : ISqlModelElement
	{		
	}
    public interface ISql140TSqlResourceGovernorReference : ISql140TSqlResourceGovernor
	{
    }
	public interface ISql140TSqlResourceGovernor : ISqlModelElement
	{		
	}
    public interface ISql140TSqlResourcePoolReference : ISql140TSqlResourcePool
	{
    }
	public interface ISql140TSqlResourcePool : ISqlModelElement
	{		
	}
    public interface ISql140TSqlRoleReference : ISql140TSqlRole
	{
    }
	public interface ISql140TSqlRole : ISqlModelElement
	{		
	}
    public interface ISql140TSqlRoleMembershipReference : ISql140TSqlRoleMembership
	{
    }
	public interface ISql140TSqlRoleMembership : ISqlModelElement
	{		
	}
    public interface ISql140TSqlRouteReference : ISql140TSqlRoute
	{
    }
	public interface ISql140TSqlRoute : ISqlModelElement
	{		
	}
    public interface ISql140TSqlRuleReference : ISql140TSqlRule
	{
    }
	public interface ISql140TSqlRule : ISqlModelElement
	{		
	}
    public interface ISql140TSqlSchemaReference : ISql140TSqlSchema
	{
    }
	public interface ISql140TSqlSchema : ISqlModelElement
	{		
	}
    public interface ISql140TSqlSearchPropertyReference : ISql140TSqlSearchProperty
	{
    }
	public interface ISql140TSqlSearchProperty : ISqlModelElement
	{		
	}
    public interface ISql140TSqlSearchPropertyListReference : ISql140TSqlSearchPropertyList
	{
    }
	public interface ISql140TSqlSearchPropertyList : ISqlModelElement
	{		
	}
    public interface ISql140TSqlSecurityPolicyReference : ISql140TSqlSecurityPolicy
	{
    }
	public interface ISql140TSqlSecurityPolicy : ISqlModelElement
	{		
	}
    public interface ISql140TSqlSecurityPredicateReference : ISql140TSqlSecurityPredicate
	{
    }
	public interface ISql140TSqlSecurityPredicate : ISqlModelElement
	{		
	}
    public interface ISql140TSqlSequenceReference : ISql140TSqlSequence
	{
    }
	public interface ISql140TSqlSequence : ISqlModelElement
	{		
	}
    public interface ISql140TSqlServerAuditReference : ISql140TSqlServerAudit
	{
    }
	public interface ISql140TSqlServerAudit : ISqlModelElement
	{		
	}
    public interface ISql140TSqlServerAuditSpecificationReference : ISql140TSqlServerAuditSpecification
	{
    }
	public interface ISql140TSqlServerAuditSpecification : ISqlModelElement
	{		
	}
    public interface ISql140TSqlServerDdlTriggerReference : ISql140TSqlServerDdlTrigger
	{
    }
	public interface ISql140TSqlServerDdlTrigger : ISqlModelElement
	{		
	}
    public interface ISql140TSqlServerEventNotificationReference : ISql140TSqlServerEventNotification
	{
    }
	public interface ISql140TSqlServerEventNotification : ISqlModelElement
	{		
	}
    public interface ISql140TSqlServerOptionsReference : ISql140TSqlServerOptions
	{
    }
	public interface ISql140TSqlServerOptions : ISqlModelElement
	{		
	}
    public interface ISql140TSqlServerRoleMembershipReference : ISql140TSqlServerRoleMembership
	{
    }
	public interface ISql140TSqlServerRoleMembership : ISqlModelElement
	{		
	}
    public interface ISql140TSqlServiceReference : ISql140TSqlService
	{
    }
	public interface ISql140TSqlService : ISqlModelElement
	{		
	}
    public interface ISql140TSqlServiceBrokerLanguageSpecifierReference : ISql140TSqlServiceBrokerLanguageSpecifier
	{
    }
	public interface ISql140TSqlServiceBrokerLanguageSpecifier : ISqlModelElement
	{		
	}
    public interface ISql140TSqlSignatureReference : ISql140TSqlSignature
	{
    }
	public interface ISql140TSqlSignature : ISqlModelElement
	{		
	}
    public interface ISql140TSqlSignatureEncryptionMechanismReference : ISql140TSqlSignatureEncryptionMechanism
	{
    }
	public interface ISql140TSqlSignatureEncryptionMechanism : ISqlModelElement
	{		
	}
    public interface ISql140TSqlSoapLanguageSpecifierReference : ISql140TSqlSoapLanguageSpecifier
	{
    }
	public interface ISql140TSqlSoapLanguageSpecifier : ISqlModelElement
	{		
	}
    public interface ISql140TSqlSoapMethodSpecificationReference : ISql140TSqlSoapMethodSpecification
	{
    }
	public interface ISql140TSqlSoapMethodSpecification : ISqlModelElement
	{		
	}
    public interface ISql140TSqlSpatialIndexReference : ISql140TSqlSpatialIndex
	{
    }
	public interface ISql140TSqlSpatialIndex : ISqlModelElement
	{		
	}
    public interface ISql140TSqlStatisticsReference : ISql140TSqlStatistics
	{
    }
	public interface ISql140TSqlStatistics : ISqlModelElement
	{		
	}
    public interface ISql140TSqlParameterReference : ISql140TSqlParameter
	{
    }
	public interface ISql140TSqlParameter : ISqlModelElement
	{		
	}
    public interface ISql140TSqlSymmetricKeyReference : ISql140TSqlSymmetricKey
	{
    }
	public interface ISql140TSqlSymmetricKey : ISqlModelElement
	{		
	}
    public interface ISql140TSqlSymmetricKeyPasswordReference : ISql140TSqlSymmetricKeyPassword
	{
    }
	public interface ISql140TSqlSymmetricKeyPassword : ISqlModelElement
	{		
	}
    public interface ISql140TSqlSynonymReference : ISql140TSqlSynonym
	{
    }
	public interface ISql140TSqlSynonym : ISqlModelElement
	{		
	}
    public interface ISql140TSqlTableReference : ISql140TSqlTable
	{
    }
	public interface ISql140TSqlTable : ISqlModelElement
	{		
	}
    public interface ISql140TSqlFileTableReference : ISql140TSqlFileTable
	{
    }
	public interface ISql140TSqlFileTable : ISqlModelElement
	{		
	}
    public interface ISql140TSqlTableTypeReference : ISql140TSqlTableType
	{
    }
	public interface ISql140TSqlTableType : ISqlModelElement
	{		
	}
    public interface ISql140TSqlTableTypeCheckConstraintReference : ISql140TSqlTableTypeCheckConstraint
	{
    }
	public interface ISql140TSqlTableTypeCheckConstraint : ISqlModelElement
	{		
	}
    public interface ISql140TSqlTableTypeColumnReference : ISql140TSqlTableTypeColumn
	{
    }
	public interface ISql140TSqlTableTypeColumn : ISqlModelElement
	{		
	}
    public interface ISql140TSqlTableTypeDefaultConstraintReference : ISql140TSqlTableTypeDefaultConstraint
	{
    }
	public interface ISql140TSqlTableTypeDefaultConstraint : ISqlModelElement
	{		
	}
    public interface ISql140TSqlTableTypeIndexReference : ISql140TSqlTableTypeIndex
	{
    }
	public interface ISql140TSqlTableTypeIndex : ISqlModelElement
	{		
	}
    public interface ISql140TSqlTableTypePrimaryKeyConstraintReference : ISql140TSqlTableTypePrimaryKeyConstraint
	{
    }
	public interface ISql140TSqlTableTypePrimaryKeyConstraint : ISqlModelElement
	{		
	}
    public interface ISql140TSqlTableTypeUniqueConstraintReference : ISql140TSqlTableTypeUniqueConstraint
	{
    }
	public interface ISql140TSqlTableTypeUniqueConstraint : ISqlModelElement
	{		
	}
    public interface ISql140TSqlTcpProtocolSpecifierReference : ISql140TSqlTcpProtocolSpecifier
	{
    }
	public interface ISql140TSqlTcpProtocolSpecifier : ISqlModelElement
	{		
	}
    public interface ISql140TSqlUniqueConstraintReference : ISql140TSqlUniqueConstraint
	{
    }
	public interface ISql140TSqlUniqueConstraint : ISqlModelElement
	{		
	}
    public interface ISql140TSqlUserReference : ISql140TSqlUser
	{
    }
	public interface ISql140TSqlUser : ISqlModelElement
	{		
	}
    public interface ISql140TSqlUserDefinedServerRoleReference : ISql140TSqlUserDefinedServerRole
	{
    }
	public interface ISql140TSqlUserDefinedServerRole : ISqlModelElement
	{		
	}
    public interface ISql140TSqlUserDefinedTypeReference : ISql140TSqlUserDefinedType
	{
    }
	public interface ISql140TSqlUserDefinedType : ISqlModelElement
	{		
	}
    public interface ISql140TSqlViewReference : ISql140TSqlView
	{
    }
	public interface ISql140TSqlView : ISqlModelElement
	{		
	}
    public interface ISql140TSqlWorkloadGroupReference : ISql140TSqlWorkloadGroup
	{
    }
	public interface ISql140TSqlWorkloadGroup : ISqlModelElement
	{		
	}
    public interface ISql140TSqlXmlIndexReference : ISql140TSqlXmlIndex
	{
    }
	public interface ISql140TSqlXmlIndex : ISqlModelElement
	{		
	}
    public interface ISql140TSqlSelectiveXmlIndexReference : ISql140TSqlSelectiveXmlIndex
	{
    }
	public interface ISql140TSqlSelectiveXmlIndex : ISqlModelElement
	{		
	}
    public interface ISql140TSqlXmlNamespaceReference : ISql140TSqlXmlNamespace
	{
    }
	public interface ISql140TSqlXmlNamespace : ISqlModelElement
	{		
	}
    public interface ISql140TSqlPromotedNodePathForXQueryTypeReference : ISql140TSqlPromotedNodePathForXQueryType
	{
    }
	public interface ISql140TSqlPromotedNodePathForXQueryType : ISqlModelElement
	{		
	}
    public interface ISql140TSqlPromotedNodePathForSqlTypeReference : ISql140TSqlPromotedNodePathForSqlType
	{
    }
	public interface ISql140TSqlPromotedNodePathForSqlType : ISqlModelElement
	{		
	}
    public interface ISql140TSqlXmlSchemaCollectionReference : ISql140TSqlXmlSchemaCollection
	{
    }
	public interface ISql140TSqlXmlSchemaCollection : ISqlModelElement
	{		
	}
    public interface ISql150TSqlColumnReference : ISql150TSqlColumn
	{
    }
	public interface ISql150TSqlColumn : ISqlModelElement
	{		
	}
    public interface ISql150TSqlTableValuedFunctionReference : ISql150TSqlTableValuedFunction
	{
    }
	public interface ISql150TSqlTableValuedFunction : ISqlModelElement
	{		
	}
    public interface ISql150TSqlScalarFunctionReference : ISql150TSqlScalarFunction
	{
    }
	public interface ISql150TSqlScalarFunction : ISqlModelElement
	{		
	}
    public interface ISql150TSqlClrTableOptionReference : ISql150TSqlClrTableOption
	{
    }
	public interface ISql150TSqlClrTableOption : ISqlModelElement
	{		
	}
    public interface ISql150TSqlAggregateReference : ISql150TSqlAggregate
	{
    }
	public interface ISql150TSqlAggregate : ISqlModelElement
	{		
	}
    public interface ISql150TSqlApplicationRoleReference : ISql150TSqlApplicationRole
	{
    }
	public interface ISql150TSqlApplicationRole : ISqlModelElement
	{		
	}
    public interface ISql150TSqlIndexReference : ISql150TSqlIndex
	{
    }
	public interface ISql150TSqlIndex : ISqlModelElement
	{		
	}
    public interface ISql150TSqlAssemblyReference : ISql150TSqlAssembly
	{
    }
	public interface ISql150TSqlAssembly : ISqlModelElement
	{		
	}
    public interface ISql150TSqlAssemblySourceReference : ISql150TSqlAssemblySource
	{
    }
	public interface ISql150TSqlAssemblySource : ISqlModelElement
	{		
	}
    public interface ISql150TSqlAsymmetricKeyReference : ISql150TSqlAsymmetricKey
	{
    }
	public interface ISql150TSqlAsymmetricKey : ISqlModelElement
	{		
	}
    public interface ISql150TSqlAuditActionReference : ISql150TSqlAuditAction
	{
    }
	public interface ISql150TSqlAuditAction : ISqlModelElement
	{		
	}
    public interface ISql150TSqlAuditActionGroupReference : ISql150TSqlAuditActionGroup
	{
    }
	public interface ISql150TSqlAuditActionGroup : ISqlModelElement
	{		
	}
    public interface ISql150TSqlAuditActionSpecificationReference : ISql150TSqlAuditActionSpecification
	{
    }
	public interface ISql150TSqlAuditActionSpecification : ISqlModelElement
	{		
	}
    public interface ISql150TSqlBrokerPriorityReference : ISql150TSqlBrokerPriority
	{
    }
	public interface ISql150TSqlBrokerPriority : ISqlModelElement
	{		
	}
    public interface ISql150TSqlBuiltInServerRoleReference : ISql150TSqlBuiltInServerRole
	{
    }
	public interface ISql150TSqlBuiltInServerRole : ISqlModelElement
	{		
	}
    public interface ISql150TSqlDataTypeReference : ISql150TSqlDataType
	{
    }
	public interface ISql150TSqlDataType : ISqlModelElement
	{		
	}
    public interface ISql150TSqlCertificateReference : ISql150TSqlCertificate
	{
    }
	public interface ISql150TSqlCertificate : ISqlModelElement
	{		
	}
    public interface ISql150TSqlCheckConstraintReference : ISql150TSqlCheckConstraint
	{
    }
	public interface ISql150TSqlCheckConstraint : ISqlModelElement
	{		
	}
    public interface ISql150TSqlClrTypeMethodReference : ISql150TSqlClrTypeMethod
	{
    }
	public interface ISql150TSqlClrTypeMethod : ISqlModelElement
	{		
	}
    public interface ISql150TSqlClrTypeMethodParameterReference : ISql150TSqlClrTypeMethodParameter
	{
    }
	public interface ISql150TSqlClrTypeMethodParameter : ISqlModelElement
	{		
	}
    public interface ISql150TSqlClrTypePropertyReference : ISql150TSqlClrTypeProperty
	{
    }
	public interface ISql150TSqlClrTypeProperty : ISqlModelElement
	{		
	}
    public interface ISql150TSqlColumnStoreIndexReference : ISql150TSqlColumnStoreIndex
	{
    }
	public interface ISql150TSqlColumnStoreIndex : ISqlModelElement
	{		
	}
    public interface ISql150TSqlContractReference : ISql150TSqlContract
	{
    }
	public interface ISql150TSqlContract : ISqlModelElement
	{		
	}
    public interface ISql150TSqlCredentialReference : ISql150TSqlCredential
	{
    }
	public interface ISql150TSqlCredential : ISqlModelElement
	{		
	}
    public interface ISql150TSqlDatabaseCredentialReference : ISql150TSqlDatabaseCredential
	{
    }
	public interface ISql150TSqlDatabaseCredential : ISqlModelElement
	{		
	}
    public interface ISql150TSqlCryptographicProviderReference : ISql150TSqlCryptographicProvider
	{
    }
	public interface ISql150TSqlCryptographicProvider : ISqlModelElement
	{		
	}
    public interface ISql150TSqlDatabaseAuditSpecificationReference : ISql150TSqlDatabaseAuditSpecification
	{
    }
	public interface ISql150TSqlDatabaseAuditSpecification : ISqlModelElement
	{		
	}
    public interface ISql150TSqlDatabaseDdlTriggerReference : ISql150TSqlDatabaseDdlTrigger
	{
    }
	public interface ISql150TSqlDatabaseDdlTrigger : ISqlModelElement
	{		
	}
    public interface ISql150TSqlDatabaseEncryptionKeyReference : ISql150TSqlDatabaseEncryptionKey
	{
    }
	public interface ISql150TSqlDatabaseEncryptionKey : ISqlModelElement
	{		
	}
    public interface ISql150TSqlDatabaseEventNotificationReference : ISql150TSqlDatabaseEventNotification
	{
    }
	public interface ISql150TSqlDatabaseEventNotification : ISqlModelElement
	{		
	}
    public interface ISql150TSqlDatabaseMirroringLanguageSpecifierReference : ISql150TSqlDatabaseMirroringLanguageSpecifier
	{
    }
	public interface ISql150TSqlDatabaseMirroringLanguageSpecifier : ISqlModelElement
	{		
	}
    public interface ISql150TSqlDatabaseOptionsReference : ISql150TSqlDatabaseOptions
	{
    }
	public interface ISql150TSqlDatabaseOptions : ISqlModelElement
	{		
	}
    public interface ISql150TSqlDataCompressionOptionReference : ISql150TSqlDataCompressionOption
	{
    }
	public interface ISql150TSqlDataCompressionOption : ISqlModelElement
	{		
	}
    public interface ISql150TSqlDefaultReference : ISql150TSqlDefault
	{
    }
	public interface ISql150TSqlDefault : ISqlModelElement
	{		
	}
    public interface ISql150TSqlDefaultConstraintReference : ISql150TSqlDefaultConstraint
	{
    }
	public interface ISql150TSqlDefaultConstraint : ISqlModelElement
	{		
	}
    public interface ISql150TSqlDmlTriggerReference : ISql150TSqlDmlTrigger
	{
    }
	public interface ISql150TSqlDmlTrigger : ISqlModelElement
	{		
	}
    public interface ISql150TSqlEndpointReference : ISql150TSqlEndpoint
	{
    }
	public interface ISql150TSqlEndpoint : ISqlModelElement
	{		
	}
    public interface ISql150TSqlErrorMessageReference : ISql150TSqlErrorMessage
	{
    }
	public interface ISql150TSqlErrorMessage : ISqlModelElement
	{		
	}
    public interface ISql150TSqlEventGroupReference : ISql150TSqlEventGroup
	{
    }
	public interface ISql150TSqlEventGroup : ISqlModelElement
	{		
	}
    public interface ISql150TSqlEventSessionReference : ISql150TSqlEventSession
	{
    }
	public interface ISql150TSqlEventSession : ISqlModelElement
	{		
	}
    public interface ISql150TSqlDatabaseEventSessionReference : ISql150TSqlDatabaseEventSession
	{
    }
	public interface ISql150TSqlDatabaseEventSession : ISqlModelElement
	{		
	}
    public interface ISql150TSqlEventSessionActionReference : ISql150TSqlEventSessionAction
	{
    }
	public interface ISql150TSqlEventSessionAction : ISqlModelElement
	{		
	}
    public interface ISql150TSqlEventSessionDefinitionsReference : ISql150TSqlEventSessionDefinitions
	{
    }
	public interface ISql150TSqlEventSessionDefinitions : ISqlModelElement
	{		
	}
    public interface ISql150TSqlEventSessionSettingReference : ISql150TSqlEventSessionSetting
	{
    }
	public interface ISql150TSqlEventSessionSetting : ISqlModelElement
	{		
	}
    public interface ISql150TSqlEventSessionTargetReference : ISql150TSqlEventSessionTarget
	{
    }
	public interface ISql150TSqlEventSessionTarget : ISqlModelElement
	{		
	}
    public interface ISql150TSqlEventTypeSpecifierReference : ISql150TSqlEventTypeSpecifier
	{
    }
	public interface ISql150TSqlEventTypeSpecifier : ISqlModelElement
	{		
	}
    public interface ISql150TSqlExtendedProcedureReference : ISql150TSqlExtendedProcedure
	{
    }
	public interface ISql150TSqlExtendedProcedure : ISqlModelElement
	{		
	}
    public interface ISql150TSqlExtendedPropertyReference : ISql150TSqlExtendedProperty
	{
    }
	public interface ISql150TSqlExtendedProperty : ISqlModelElement
	{		
	}
    public interface ISql150TSqlExternalDataSourceReference : ISql150TSqlExternalDataSource
	{
    }
	public interface ISql150TSqlExternalDataSource : ISqlModelElement
	{		
	}
    public interface ISql150TSqlExternalFileFormatReference : ISql150TSqlExternalFileFormat
	{
    }
	public interface ISql150TSqlExternalFileFormat : ISqlModelElement
	{		
	}
    public interface ISql150TSqlExternalTableReference : ISql150TSqlExternalTable
	{
    }
	public interface ISql150TSqlExternalTable : ISqlModelElement
	{		
	}
    public interface ISql150TSqlSqlFileReference : ISql150TSqlSqlFile
	{
    }
	public interface ISql150TSqlSqlFile : ISqlModelElement
	{		
	}
    public interface ISql150TSqlFilegroupReference : ISql150TSqlFilegroup
	{
    }
	public interface ISql150TSqlFilegroup : ISqlModelElement
	{		
	}
    public interface ISql150TSqlForeignKeyConstraintReference : ISql150TSqlForeignKeyConstraint
	{
    }
	public interface ISql150TSqlForeignKeyConstraint : ISqlModelElement
	{		
	}
    public interface ISql150TSqlFullTextCatalogReference : ISql150TSqlFullTextCatalog
	{
    }
	public interface ISql150TSqlFullTextCatalog : ISqlModelElement
	{		
	}
    public interface ISql150TSqlFullTextIndexReference : ISql150TSqlFullTextIndex
	{
    }
	public interface ISql150TSqlFullTextIndex : ISqlModelElement
	{		
	}
    public interface ISql150TSqlFullTextIndexColumnSpecifierReference : ISql150TSqlFullTextIndexColumnSpecifier
	{
    }
	public interface ISql150TSqlFullTextIndexColumnSpecifier : ISqlModelElement
	{		
	}
    public interface ISql150TSqlFullTextStopListReference : ISql150TSqlFullTextStopList
	{
    }
	public interface ISql150TSqlFullTextStopList : ISqlModelElement
	{		
	}
    public interface ISql150TSqlHttpProtocolSpecifierReference : ISql150TSqlHttpProtocolSpecifier
	{
    }
	public interface ISql150TSqlHttpProtocolSpecifier : ISqlModelElement
	{		
	}
    public interface ISql150TSqlLinkedServerReference : ISql150TSqlLinkedServer
	{
    }
	public interface ISql150TSqlLinkedServer : ISqlModelElement
	{		
	}
    public interface ISql150TSqlLinkedServerLoginReference : ISql150TSqlLinkedServerLogin
	{
    }
	public interface ISql150TSqlLinkedServerLogin : ISqlModelElement
	{		
	}
    public interface ISql150TSqlLoginReference : ISql150TSqlLogin
	{
    }
	public interface ISql150TSqlLogin : ISqlModelElement
	{		
	}
    public interface ISql150TSqlMasterKeyReference : ISql150TSqlMasterKey
	{
    }
	public interface ISql150TSqlMasterKey : ISqlModelElement
	{		
	}
    public interface ISql150TSqlMessageTypeReference : ISql150TSqlMessageType
	{
    }
	public interface ISql150TSqlMessageType : ISqlModelElement
	{		
	}
    public interface ISql150TSqlPartitionFunctionReference : ISql150TSqlPartitionFunction
	{
    }
	public interface ISql150TSqlPartitionFunction : ISqlModelElement
	{		
	}
    public interface ISql150TSqlPartitionSchemeReference : ISql150TSqlPartitionScheme
	{
    }
	public interface ISql150TSqlPartitionScheme : ISqlModelElement
	{		
	}
    public interface ISql150TSqlPartitionValueReference : ISql150TSqlPartitionValue
	{
    }
	public interface ISql150TSqlPartitionValue : ISqlModelElement
	{		
	}
    public interface ISql150TSqlPermissionReference : ISql150TSqlPermission
	{
    }
	public interface ISql150TSqlPermission : ISqlModelElement
	{		
	}
    public interface ISql150TSqlPrimaryKeyConstraintReference : ISql150TSqlPrimaryKeyConstraint
	{
    }
	public interface ISql150TSqlPrimaryKeyConstraint : ISqlModelElement
	{		
	}
    public interface ISql150TSqlProcedureReference : ISql150TSqlProcedure
	{
    }
	public interface ISql150TSqlProcedure : ISqlModelElement
	{		
	}
    public interface ISql150TSqlQueueReference : ISql150TSqlQueue
	{
    }
	public interface ISql150TSqlQueue : ISqlModelElement
	{		
	}
    public interface ISql150TSqlQueueEventNotificationReference : ISql150TSqlQueueEventNotification
	{
    }
	public interface ISql150TSqlQueueEventNotification : ISqlModelElement
	{		
	}
    public interface ISql150TSqlRemoteServiceBindingReference : ISql150TSqlRemoteServiceBinding
	{
    }
	public interface ISql150TSqlRemoteServiceBinding : ISqlModelElement
	{		
	}
    public interface ISql150TSqlResourceGovernorReference : ISql150TSqlResourceGovernor
	{
    }
	public interface ISql150TSqlResourceGovernor : ISqlModelElement
	{		
	}
    public interface ISql150TSqlResourcePoolReference : ISql150TSqlResourcePool
	{
    }
	public interface ISql150TSqlResourcePool : ISqlModelElement
	{		
	}
    public interface ISql150TSqlRoleReference : ISql150TSqlRole
	{
    }
	public interface ISql150TSqlRole : ISqlModelElement
	{		
	}
    public interface ISql150TSqlRoleMembershipReference : ISql150TSqlRoleMembership
	{
    }
	public interface ISql150TSqlRoleMembership : ISqlModelElement
	{		
	}
    public interface ISql150TSqlRouteReference : ISql150TSqlRoute
	{
    }
	public interface ISql150TSqlRoute : ISqlModelElement
	{		
	}
    public interface ISql150TSqlRuleReference : ISql150TSqlRule
	{
    }
	public interface ISql150TSqlRule : ISqlModelElement
	{		
	}
    public interface ISql150TSqlSchemaReference : ISql150TSqlSchema
	{
    }
	public interface ISql150TSqlSchema : ISqlModelElement
	{		
	}
    public interface ISql150TSqlSearchPropertyReference : ISql150TSqlSearchProperty
	{
    }
	public interface ISql150TSqlSearchProperty : ISqlModelElement
	{		
	}
    public interface ISql150TSqlSearchPropertyListReference : ISql150TSqlSearchPropertyList
	{
    }
	public interface ISql150TSqlSearchPropertyList : ISqlModelElement
	{		
	}
    public interface ISql150TSqlSecurityPolicyReference : ISql150TSqlSecurityPolicy
	{
    }
	public interface ISql150TSqlSecurityPolicy : ISqlModelElement
	{		
	}
    public interface ISql150TSqlSecurityPredicateReference : ISql150TSqlSecurityPredicate
	{
    }
	public interface ISql150TSqlSecurityPredicate : ISqlModelElement
	{		
	}
    public interface ISql150TSqlSequenceReference : ISql150TSqlSequence
	{
    }
	public interface ISql150TSqlSequence : ISqlModelElement
	{		
	}
    public interface ISql150TSqlServerAuditReference : ISql150TSqlServerAudit
	{
    }
	public interface ISql150TSqlServerAudit : ISqlModelElement
	{		
	}
    public interface ISql150TSqlServerAuditSpecificationReference : ISql150TSqlServerAuditSpecification
	{
    }
	public interface ISql150TSqlServerAuditSpecification : ISqlModelElement
	{		
	}
    public interface ISql150TSqlServerDdlTriggerReference : ISql150TSqlServerDdlTrigger
	{
    }
	public interface ISql150TSqlServerDdlTrigger : ISqlModelElement
	{		
	}
    public interface ISql150TSqlServerEventNotificationReference : ISql150TSqlServerEventNotification
	{
    }
	public interface ISql150TSqlServerEventNotification : ISqlModelElement
	{		
	}
    public interface ISql150TSqlServerOptionsReference : ISql150TSqlServerOptions
	{
    }
	public interface ISql150TSqlServerOptions : ISqlModelElement
	{		
	}
    public interface ISql150TSqlServerRoleMembershipReference : ISql150TSqlServerRoleMembership
	{
    }
	public interface ISql150TSqlServerRoleMembership : ISqlModelElement
	{		
	}
    public interface ISql150TSqlServiceReference : ISql150TSqlService
	{
    }
	public interface ISql150TSqlService : ISqlModelElement
	{		
	}
    public interface ISql150TSqlServiceBrokerLanguageSpecifierReference : ISql150TSqlServiceBrokerLanguageSpecifier
	{
    }
	public interface ISql150TSqlServiceBrokerLanguageSpecifier : ISqlModelElement
	{		
	}
    public interface ISql150TSqlSignatureReference : ISql150TSqlSignature
	{
    }
	public interface ISql150TSqlSignature : ISqlModelElement
	{		
	}
    public interface ISql150TSqlSignatureEncryptionMechanismReference : ISql150TSqlSignatureEncryptionMechanism
	{
    }
	public interface ISql150TSqlSignatureEncryptionMechanism : ISqlModelElement
	{		
	}
    public interface ISql150TSqlSoapLanguageSpecifierReference : ISql150TSqlSoapLanguageSpecifier
	{
    }
	public interface ISql150TSqlSoapLanguageSpecifier : ISqlModelElement
	{		
	}
    public interface ISql150TSqlSoapMethodSpecificationReference : ISql150TSqlSoapMethodSpecification
	{
    }
	public interface ISql150TSqlSoapMethodSpecification : ISqlModelElement
	{		
	}
    public interface ISql150TSqlSpatialIndexReference : ISql150TSqlSpatialIndex
	{
    }
	public interface ISql150TSqlSpatialIndex : ISqlModelElement
	{		
	}
    public interface ISql150TSqlStatisticsReference : ISql150TSqlStatistics
	{
    }
	public interface ISql150TSqlStatistics : ISqlModelElement
	{		
	}
    public interface ISql150TSqlParameterReference : ISql150TSqlParameter
	{
    }
	public interface ISql150TSqlParameter : ISqlModelElement
	{		
	}
    public interface ISql150TSqlSymmetricKeyReference : ISql150TSqlSymmetricKey
	{
    }
	public interface ISql150TSqlSymmetricKey : ISqlModelElement
	{		
	}
    public interface ISql150TSqlSymmetricKeyPasswordReference : ISql150TSqlSymmetricKeyPassword
	{
    }
	public interface ISql150TSqlSymmetricKeyPassword : ISqlModelElement
	{		
	}
    public interface ISql150TSqlSynonymReference : ISql150TSqlSynonym
	{
    }
	public interface ISql150TSqlSynonym : ISqlModelElement
	{		
	}
    public interface ISql150TSqlTableReference : ISql150TSqlTable
	{
    }
	public interface ISql150TSqlTable : ISqlModelElement
	{		
	}
    public interface ISql150TSqlFileTableReference : ISql150TSqlFileTable
	{
    }
	public interface ISql150TSqlFileTable : ISqlModelElement
	{		
	}
    public interface ISql150TSqlTableTypeReference : ISql150TSqlTableType
	{
    }
	public interface ISql150TSqlTableType : ISqlModelElement
	{		
	}
    public interface ISql150TSqlTableTypeCheckConstraintReference : ISql150TSqlTableTypeCheckConstraint
	{
    }
	public interface ISql150TSqlTableTypeCheckConstraint : ISqlModelElement
	{		
	}
    public interface ISql150TSqlTableTypeColumnReference : ISql150TSqlTableTypeColumn
	{
    }
	public interface ISql150TSqlTableTypeColumn : ISqlModelElement
	{		
	}
    public interface ISql150TSqlTableTypeDefaultConstraintReference : ISql150TSqlTableTypeDefaultConstraint
	{
    }
	public interface ISql150TSqlTableTypeDefaultConstraint : ISqlModelElement
	{		
	}
    public interface ISql150TSqlTableTypeIndexReference : ISql150TSqlTableTypeIndex
	{
    }
	public interface ISql150TSqlTableTypeIndex : ISqlModelElement
	{		
	}
    public interface ISql150TSqlTableTypePrimaryKeyConstraintReference : ISql150TSqlTableTypePrimaryKeyConstraint
	{
    }
	public interface ISql150TSqlTableTypePrimaryKeyConstraint : ISqlModelElement
	{		
	}
    public interface ISql150TSqlTableTypeUniqueConstraintReference : ISql150TSqlTableTypeUniqueConstraint
	{
    }
	public interface ISql150TSqlTableTypeUniqueConstraint : ISqlModelElement
	{		
	}
    public interface ISql150TSqlTcpProtocolSpecifierReference : ISql150TSqlTcpProtocolSpecifier
	{
    }
	public interface ISql150TSqlTcpProtocolSpecifier : ISqlModelElement
	{		
	}
    public interface ISql150TSqlUniqueConstraintReference : ISql150TSqlUniqueConstraint
	{
    }
	public interface ISql150TSqlUniqueConstraint : ISqlModelElement
	{		
	}
    public interface ISql150TSqlUserReference : ISql150TSqlUser
	{
    }
	public interface ISql150TSqlUser : ISqlModelElement
	{		
	}
    public interface ISql150TSqlUserDefinedServerRoleReference : ISql150TSqlUserDefinedServerRole
	{
    }
	public interface ISql150TSqlUserDefinedServerRole : ISqlModelElement
	{		
	}
    public interface ISql150TSqlUserDefinedTypeReference : ISql150TSqlUserDefinedType
	{
    }
	public interface ISql150TSqlUserDefinedType : ISqlModelElement
	{		
	}
    public interface ISql150TSqlViewReference : ISql150TSqlView
	{
    }
	public interface ISql150TSqlView : ISqlModelElement
	{		
	}
    public interface ISql150TSqlWorkloadGroupReference : ISql150TSqlWorkloadGroup
	{
    }
	public interface ISql150TSqlWorkloadGroup : ISqlModelElement
	{		
	}
    public interface ISql150TSqlXmlIndexReference : ISql150TSqlXmlIndex
	{
    }
	public interface ISql150TSqlXmlIndex : ISqlModelElement
	{		
	}
    public interface ISql150TSqlSelectiveXmlIndexReference : ISql150TSqlSelectiveXmlIndex
	{
    }
	public interface ISql150TSqlSelectiveXmlIndex : ISqlModelElement
	{		
	}
    public interface ISql150TSqlXmlNamespaceReference : ISql150TSqlXmlNamespace
	{
    }
	public interface ISql150TSqlXmlNamespace : ISqlModelElement
	{		
	}
    public interface ISql150TSqlPromotedNodePathForXQueryTypeReference : ISql150TSqlPromotedNodePathForXQueryType
	{
    }
	public interface ISql150TSqlPromotedNodePathForXQueryType : ISqlModelElement
	{		
	}
    public interface ISql150TSqlPromotedNodePathForSqlTypeReference : ISql150TSqlPromotedNodePathForSqlType
	{
    }
	public interface ISql150TSqlPromotedNodePathForSqlType : ISqlModelElement
	{		
	}
    public interface ISql150TSqlXmlSchemaCollectionReference : ISql150TSqlXmlSchemaCollection
	{
    }
	public interface ISql150TSqlXmlSchemaCollection : ISqlModelElement
	{		
	}
    public interface ISqlAzureV12TSqlColumnReference : ISqlAzureV12TSqlColumn
	{
    }
	public interface ISqlAzureV12TSqlColumn : ISqlModelElement
	{		
		String Collation 
		{
			get;
		}
		String EncryptionAlgorithmName 
		{
			get;
		}
		Int32 EncryptionType 
		{
			get;
		}
		String Expression 
		{
			get;
		}
		ColumnGeneratedAlwaysType GeneratedAlwaysType 
		{
			get;
		}
		Int32 GraphType 
		{
			get;
		}
		String IdentityIncrement 
		{
			get;
		}
		String IdentitySeed 
		{
			get;
		}
		Boolean IsHidden 
		{
			get;
		}
		Boolean IsIdentity 
		{
			get;
		}
		Boolean IsIdentityNotForReplication 
		{
			get;
		}
		Boolean IsMax 
		{
			get;
		}
		Boolean IsPseudoColumn 
		{
			get;
		}
		Boolean IsRowGuidCol 
		{
			get;
		}
		Int32 Length 
		{
			get;
		}
		String MaskingFunction 
		{
			get;
		}
		Boolean Nullable 
		{
			get;
		}
		Boolean Persisted 
		{
			get;
		}
		Boolean? PersistedNullable 
		{
			get;
		}
		Int32 Precision 
		{
			get;
		}
		Int32 Scale 
		{
			get;
		}
		Boolean Sparse 
		{
			get;
		}
		XmlStyle XmlStyle 
		{
			get;
		}
		//Peer
		IEnumerable<TSqlModelElementReference> ColumnEncryptionKey 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlDataType> DataType 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ExpressionDependencies 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlXmlSchemaCollectionReference> XmlSchemaCollection 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlTableValuedFunctionReference : ISqlAzureV12TSqlTableValuedFunction
	{
    }
	public interface ISqlAzureV12TSqlTableValuedFunction : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		Boolean CalledOnNullInput 
		{
			get;
		}
		String ClassName 
		{
			get;
		}
		DataAccessKind? DataAccess 
		{
			get;
		}
		Boolean? Deterministic 
		{
			get;
		}
		Boolean ExecuteAsCaller 
		{
			get;
		}
		Boolean ExecuteAsOwner 
		{
			get;
		}
		Boolean ExecuteAsSelf 
		{
			get;
		}
		String FillRowMethodName 
		{
			get;
		}
		Boolean IsNativeCompiled 
		{
			get;
		}
		String MethodName 
		{
			get;
		}
		Boolean? Precise 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		Boolean ReturnsNullOnNullInput 
		{
			get;
		}
		String ReturnTableVariableName 
		{
			get;
		}
		SystemDataAccessKind? SystemDataAccess 
		{
			get;
		}
		Boolean WithEncryption 
		{
			get;
		}
		Boolean WithSchemaBinding 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlAssembly> Assembly 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BodyDependencies 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlColumn> Columns 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlLoginReference> Login 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlParameter> Parameters 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlDataTypeReference> ReturnType 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlSchemaReference> Schema 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlClrTableOption> TableOption 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlUserReference> User 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlScalarFunctionReference : ISqlAzureV12TSqlScalarFunction
	{
    }
	public interface ISqlAzureV12TSqlScalarFunction : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		Boolean CalledOnNullInput 
		{
			get;
		}
		String ClassName 
		{
			get;
		}
		DataAccessKind? DataAccess 
		{
			get;
		}
		Boolean? Deterministic 
		{
			get;
		}
		Boolean ExecuteAsCaller 
		{
			get;
		}
		Boolean ExecuteAsOwner 
		{
			get;
		}
		Boolean ExecuteAsSelf 
		{
			get;
		}
		String FillRowMethodName 
		{
			get;
		}
		Boolean IsInline 
		{
			get;
		}
		Boolean IsInlineable 
		{
			get;
		}
		Boolean IsNativeCompiled 
		{
			get;
		}
		String MethodName 
		{
			get;
		}
		Boolean? Precise 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		Boolean ReturnsNullOnNullInput 
		{
			get;
		}
		SystemDataAccessKind? SystemDataAccess 
		{
			get;
		}
		Boolean WithEncryption 
		{
			get;
		}
		Boolean WithSchemaBinding 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlAssembly> Assembly 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BodyDependencies 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlLoginReference> Login 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlParameter> Parameters 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlDataTypeReference> ReturnType 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlSchemaReference> Schema 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlUserReference> User 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlClrTableOptionReference : ISqlAzureV12TSqlClrTableOption
	{
    }
	public interface ISqlAzureV12TSqlClrTableOption : ISqlModelElement
	{		
		String ClassName 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlColumnReference> OrderColumns 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlAggregateReference : ISqlAzureV12TSqlAggregate
	{
    }
	public interface ISqlAzureV12TSqlAggregate : ISqlModelElement
	{		
		String ClassName 
		{
			get;
		}
		Format Format 
		{
			get;
		}
		Boolean? InvariantToDuplicates 
		{
			get;
		}
		Boolean? InvariantToNulls 
		{
			get;
		}
		Int32? MaxByteSize 
		{
			get;
		}
		Boolean? NullIfEmpty 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlAssemblyReference> Assembly 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlParameter> Parameters 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlDataTypeReference> ReturnType 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlApplicationRoleReference : ISqlAzureV12TSqlApplicationRole
	{
    }
	public interface ISqlAzureV12TSqlApplicationRole : ISqlModelElement
	{		
		String Password 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlSchemaReference> DefaultSchema 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlIndexReference : ISqlAzureV12TSqlIndex
	{
    }
	public interface ISqlAzureV12TSqlIndex : ISqlModelElement
	{		
		Boolean AllowPageLocks 
		{
			get;
		}
		Boolean AllowRowLocks 
		{
			get;
		}
		Int32? BucketCount 
		{
			get;
		}
		Boolean Clustered 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Int32? FillFactor 
		{
			get;
		}
		String FilterPredicate 
		{
			get;
		}
		Boolean Hash 
		{
			get;
		}
		Boolean IgnoreDuplicateKey 
		{
			get;
		}
		Boolean IncrementalStatistics 
		{
			get;
		}
		Boolean RecomputeStatistics 
		{
			get;
		}
		Boolean Unique 
		{
			get;
		}
		Boolean WithPadIndex 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BodyDependencies 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlColumnReference> Columns 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlDataCompressionOption> DataCompressionOptions 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlFilegroupReference> Filegroup 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlColumnReference> IncludedColumns 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISpecifiesIndex> IndexedObject 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlColumnReference> PartitionColumn 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlPartitionSchemeReference> PartitionScheme 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlAssemblyReference : ISqlAzureV12TSqlAssembly
	{
    }
	public interface ISqlAzureV12TSqlAssembly : ISqlModelElement
	{		
		AssemblyPermissionSet PermissionSet 
		{
			get;
		}
		Boolean Visible 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlAssemblySource> AssemblySources 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlAssemblyReference> ReferencedAssemblies 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlAssemblySourceReference : ISqlAzureV12TSqlAssemblySource
	{
    }
	public interface ISqlAzureV12TSqlAssemblySource : ISqlModelElement
	{		
		String Source 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlAsymmetricKeyReference : ISqlAzureV12TSqlAsymmetricKey
	{
    }
	public interface ISqlAzureV12TSqlAsymmetricKey : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlAuditActionReference : ISqlAzureV12TSqlAuditAction
	{
    }
	public interface ISqlAzureV12TSqlAuditAction : ISqlModelElement
	{		
	}
    public interface ISqlAzureV12TSqlAuditActionGroupReference : ISqlAzureV12TSqlAuditActionGroup
	{
    }
	public interface ISqlAzureV12TSqlAuditActionGroup : ISqlModelElement
	{		
	}
    public interface ISqlAzureV12TSqlAuditActionSpecificationReference : ISqlAzureV12TSqlAuditActionSpecification
	{
    }
	public interface ISqlAzureV12TSqlAuditActionSpecification : ISqlModelElement
	{		
	}
    public interface ISqlAzureV12TSqlBrokerPriorityReference : ISqlAzureV12TSqlBrokerPriority
	{
    }
	public interface ISqlAzureV12TSqlBrokerPriority : ISqlModelElement
	{		
	}
    public interface ISqlAzureV12TSqlBuiltInServerRoleReference : ISqlAzureV12TSqlBuiltInServerRole
	{
    }
	public interface ISqlAzureV12TSqlBuiltInServerRole : ISqlModelElement
	{		
	}
    public interface ISqlAzureV12TSqlDataTypeReference : ISqlAzureV12TSqlDataType
	{
    }
	public interface ISqlAzureV12TSqlDataType : ISqlModelElement
	{		
		SqlDataType SqlDataType 
		{
			get;
		}
		Boolean UddtIsMax 
		{
			get;
		}
		Int32 UddtLength 
		{
			get;
		}
		Boolean UddtNullable 
		{
			get;
		}
		Int32 UddtPrecision 
		{
			get;
		}
		Int32 UddtScale 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlSchemaReference> Schema 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlDataTypeReference> Type 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlCertificateReference : ISqlAzureV12TSqlCertificate
	{
    }
	public interface ISqlAzureV12TSqlCertificate : ISqlModelElement
	{		
		Boolean ActiveForBeginDialog 
		{
			get;
		}
		Boolean EncryptedWithPassword 
		{
			get;
		}
		String EncryptionPassword 
		{
			get;
		}
		String ExistingKeysFilePath 
		{
			get;
		}
		String ExpiryDate 
		{
			get;
		}
		Boolean IsExistingKeyFileExecutable 
		{
			get;
		}
		String PrivateKeyDecryptionPassword 
		{
			get;
		}
		String PrivateKeyEncryptionPassword 
		{
			get;
		}
		String PrivateKeyFilePath 
		{
			get;
		}
		String StartDate 
		{
			get;
		}
		String Subject 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlCheckConstraintReference : ISqlAzureV12TSqlCheckConstraint
	{
    }
	public interface ISqlAzureV12TSqlCheckConstraint : ISqlModelElement
	{		
		Boolean Disabled 
		{
			get;
		}
		String Expression 
		{
			get;
		}
		Boolean NotForReplication 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ExpressionDependencies 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlTableReference> Host 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlClrTypeMethodReference : ISqlAzureV12TSqlClrTypeMethod
	{
    }
	public interface ISqlAzureV12TSqlClrTypeMethod : ISqlModelElement
	{		
		String MethodName 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlParameter> Parameters 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlDataType> ReturnType 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlClrTypeMethodParameterReference : ISqlAzureV12TSqlClrTypeMethodParameter
	{
    }
	public interface ISqlAzureV12TSqlClrTypeMethodParameter : ISqlModelElement
	{		
		Boolean IsOutput 
		{
			get;
		}
		String ParameterName 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlDataType> DataType 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlClrTypePropertyReference : ISqlAzureV12TSqlClrTypeProperty
	{
    }
	public interface ISqlAzureV12TSqlClrTypeProperty : ISqlModelElement
	{		
		String PropertyName 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlDataTypeReference> ClrType 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlColumnStoreIndexReference : ISqlAzureV12TSqlColumnStoreIndex
	{
    }
	public interface ISqlAzureV12TSqlColumnStoreIndex : ISqlModelElement
	{		
		Boolean Clustered 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlColumnReference> Columns 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlDataCompressionOption> DataCompressionOptions 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlFilegroupReference> Filegroup 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISpecifiesIndex> IndexedObject 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlColumnReference> PartitionColumn 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlPartitionSchemeReference> PartitionScheme 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlContractReference : ISqlAzureV12TSqlContract
	{
    }
	public interface ISqlAzureV12TSqlContract : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlCredentialReference : ISqlAzureV12TSqlCredential
	{
    }
	public interface ISqlAzureV12TSqlCredential : ISqlModelElement
	{		
		String Identity 
		{
			get;
		}
		String Secret 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlDatabaseCredentialReference : ISqlAzureV12TSqlDatabaseCredential
	{
    }
	public interface ISqlAzureV12TSqlDatabaseCredential : ISqlModelElement
	{		
		String Identity 
		{
			get;
		}
		String Secret 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlCryptographicProviderReference : ISqlAzureV12TSqlCryptographicProvider
	{
    }
	public interface ISqlAzureV12TSqlCryptographicProvider : ISqlModelElement
	{		
	}
    public interface ISqlAzureV12TSqlDatabaseAuditSpecificationReference : ISqlAzureV12TSqlDatabaseAuditSpecification
	{
    }
	public interface ISqlAzureV12TSqlDatabaseAuditSpecification : ISqlModelElement
	{		
	}
    public interface ISqlAzureV12TSqlDatabaseDdlTriggerReference : ISqlAzureV12TSqlDatabaseDdlTrigger
	{
    }
	public interface ISqlAzureV12TSqlDatabaseDdlTrigger : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		String ClassName 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Boolean ExecuteAsCaller 
		{
			get;
		}
		Boolean ExecuteAsOwner 
		{
			get;
		}
		Boolean ExecuteAsSelf 
		{
			get;
		}
		String MethodName 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		TriggerType TriggerType 
		{
			get;
		}
		Boolean WithEncryption 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlAssemblyReference> Assembly 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BodyDependencies 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlEventGroup> EventGroup 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Model.EventType> EventType 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlLoginReference> Login 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlUserReference> User 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlDatabaseEncryptionKeyReference : ISqlAzureV12TSqlDatabaseEncryptionKey
	{
    }
	public interface ISqlAzureV12TSqlDatabaseEncryptionKey : ISqlModelElement
	{		
	}
    public interface ISqlAzureV12TSqlDatabaseEventNotificationReference : ISqlAzureV12TSqlDatabaseEventNotification
	{
    }
	public interface ISqlAzureV12TSqlDatabaseEventNotification : ISqlModelElement
	{		
	}
    public interface ISqlAzureV12TSqlDatabaseMirroringLanguageSpecifierReference : ISqlAzureV12TSqlDatabaseMirroringLanguageSpecifier
	{
    }
	public interface ISqlAzureV12TSqlDatabaseMirroringLanguageSpecifier : ISqlModelElement
	{		
	}
    public interface ISqlAzureV12TSqlDatabaseOptionsReference : ISqlAzureV12TSqlDatabaseOptions
	{
    }
	public interface ISqlAzureV12TSqlDatabaseOptions : ISqlModelElement
	{		
		Boolean AllowSnapshotIsolation 
		{
			get;
		}
		Boolean AnsiNullDefaultOn 
		{
			get;
		}
		Boolean AnsiNullsOn 
		{
			get;
		}
		Boolean AnsiPaddingOn 
		{
			get;
		}
		Boolean AnsiWarningsOn 
		{
			get;
		}
		Boolean ArithAbortOn 
		{
			get;
		}
		Boolean AutoCreateStatistics 
		{
			get;
		}
		Boolean AutoCreateStatisticsIncremental 
		{
			get;
		}
		Boolean AutoShrink 
		{
			get;
		}
		Boolean AutoUpdateStatistics 
		{
			get;
		}
		Boolean AutoUpdateStatisticsAsync 
		{
			get;
		}
		CatalogCollation? CatalogCollation 
		{
			get;
		}
		Boolean ChangeTrackingAutoCleanup 
		{
			get;
		}
		Boolean ChangeTrackingEnabled 
		{
			get;
		}
		Int32 ChangeTrackingRetentionPeriod 
		{
			get;
		}
		TimeUnit ChangeTrackingRetentionUnit 
		{
			get;
		}
		String Collation 
		{
			get;
		}
		Int32 CompatibilityLevel 
		{
			get;
		}
		Boolean ConcatNullYieldsNull 
		{
			get;
		}
		Boolean CursorCloseOnCommit 
		{
			get;
		}
		Boolean DateCorrelationOptimizationOn 
		{
			get;
		}
		Boolean FullTextEnabled 
		{
			get;
		}
		Boolean LegacyCardinalityEstimation 
		{
			get;
		}
		Boolean? LegacyCardinalityEstimationForSecondary 
		{
			get;
		}
		Int32 MaxDop 
		{
			get;
		}
		Int32? MaxDopForSecondary 
		{
			get;
		}
		Boolean NumericRoundAbortOn 
		{
			get;
		}
		Boolean ParameterSniffing 
		{
			get;
		}
		Boolean? ParameterSniffingForSecondary 
		{
			get;
		}
		Boolean QueryOptimizerHotfixes 
		{
			get;
		}
		Boolean? QueryOptimizerHotfixesForSecondary 
		{
			get;
		}
		QueryStoreCaptureMode QueryStoreCaptureMode 
		{
			get;
		}
		QueryStoreDesiredState QueryStoreDesiredState 
		{
			get;
		}
		Int32 QueryStoreFlushInterval 
		{
			get;
		}
		Int32 QueryStoreIntervalLength 
		{
			get;
		}
		Int32 QueryStoreMaxPlansPerQuery 
		{
			get;
		}
		Int32 QueryStoreMaxStorageSize 
		{
			get;
		}
		Int32 QueryStoreStaleQueryThreshold 
		{
			get;
		}
		Boolean QuotedIdentifierOn 
		{
			get;
		}
		Boolean ReadOnly 
		{
			get;
		}
		Boolean RecursiveTriggersOn 
		{
			get;
		}
		Boolean TemporalHistoryRetentionEnabled 
		{
			get;
		}
		Boolean VardecimalStorageFormatOn 
		{
			get;
		}
		Boolean WithEncryption 
		{
			get;
		}
		//Peer
		IEnumerable<TSqlModelElementReference> GenericDatabaseScopedConfigurationOptions 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlDataCompressionOptionReference : ISqlAzureV12TSqlDataCompressionOption
	{
    }
	public interface ISqlAzureV12TSqlDataCompressionOption : ISqlModelElement
	{		
		CompressionLevel CompressionLevel 
		{
			get;
		}
		Int32 PartitionNumber 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlDefaultReference : ISqlAzureV12TSqlDefault
	{
    }
	public interface ISqlAzureV12TSqlDefault : ISqlModelElement
	{		
		String Expression 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BoundObjects 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlDefaultConstraintReference : ISqlAzureV12TSqlDefaultConstraint
	{
    }
	public interface ISqlAzureV12TSqlDefaultConstraint : ISqlModelElement
	{		
		Boolean Disabled 
		{
			get;
		}
		String Expression 
		{
			get;
		}
		Boolean WithValues 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ExpressionDependencies 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlTableReference> Host 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlColumnReference> TargetColumn 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlDmlTriggerReference : ISqlAzureV12TSqlDmlTrigger
	{
    }
	public interface ISqlAzureV12TSqlDmlTrigger : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		String ClassName 
		{
			get;
		}
		OrderRestriction DeleteOrderRestriction 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Boolean ExecuteAsCaller 
		{
			get;
		}
		Boolean ExecuteAsOwner 
		{
			get;
		}
		Boolean ExecuteAsSelf 
		{
			get;
		}
		OrderRestriction InsertOrderRestriction 
		{
			get;
		}
		Boolean IsDeleteTrigger 
		{
			get;
		}
		Boolean IsInsertTrigger 
		{
			get;
		}
		Boolean IsNativeCompiled 
		{
			get;
		}
		Boolean IsSchemaBound 
		{
			get;
		}
		Boolean IsUpdateTrigger 
		{
			get;
		}
		String MethodName 
		{
			get;
		}
		Boolean NotForReplication 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		TriggerType TriggerType 
		{
			get;
		}
		OrderRestriction UpdateOrderRestriction 
		{
			get;
		}
		Boolean WithAppend 
		{
			get;
		}
		Boolean WithEncryption 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlAssemblyReference> Assembly 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BodyDependencies 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlLoginReference> Login 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> TriggerObject 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlUserReference> User 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlEndpointReference : ISqlAzureV12TSqlEndpoint
	{
    }
	public interface ISqlAzureV12TSqlEndpoint : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlErrorMessageReference : ISqlAzureV12TSqlErrorMessage
	{
    }
	public interface ISqlAzureV12TSqlErrorMessage : ISqlModelElement
	{		
	}
    public interface ISqlAzureV12TSqlEventGroupReference : ISqlAzureV12TSqlEventGroup
	{
    }
	public interface ISqlAzureV12TSqlEventGroup : ISqlModelElement
	{		
		EventGroupType Group 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlEventSessionReference : ISqlAzureV12TSqlEventSession
	{
    }
	public interface ISqlAzureV12TSqlEventSession : ISqlModelElement
	{		
		EventRetentionMode EventRetentionMode 
		{
			get;
		}
		Int32 MaxDispatchLatency 
		{
			get;
		}
		Int32 MaxEventSize 
		{
			get;
		}
		MemoryUnit MaxEventSizeUnit 
		{
			get;
		}
		Int32 MaxMemory 
		{
			get;
		}
		MemoryUnit MaxMemoryUnit 
		{
			get;
		}
		MemoryPartitionMode MemoryPartitionMode 
		{
			get;
		}
		EventSessionScope SessionScope 
		{
			get;
		}
		Boolean StartupState 
		{
			get;
		}
		Boolean TrackCausality 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.TSqlModelElement> EventDefinitions 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.TSqlModelElement> EventTargets 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlDatabaseEventSessionReference : ISqlAzureV12TSqlDatabaseEventSession
	{
    }
	public interface ISqlAzureV12TSqlDatabaseEventSession : ISqlModelElement
	{		
		EventRetentionMode EventRetentionMode 
		{
			get;
		}
		Int32 MaxDispatchLatency 
		{
			get;
		}
		Int32 MaxEventSize 
		{
			get;
		}
		MemoryUnit MaxEventSizeUnit 
		{
			get;
		}
		Int32 MaxMemory 
		{
			get;
		}
		MemoryUnit MaxMemoryUnit 
		{
			get;
		}
		MemoryPartitionMode MemoryPartitionMode 
		{
			get;
		}
		EventSessionScope SessionScope 
		{
			get;
		}
		Boolean StartupState 
		{
			get;
		}
		Boolean TrackCausality 
		{
			get;
		}
		//Composing
		IEnumerable<TSqlModelElementReference> EventDefinitions 
		{
			get;
		}
		//Composing
		IEnumerable<TSqlModelElementReference> EventTargets 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlEventSessionActionReference : ISqlAzureV12TSqlEventSessionAction
	{
    }
	public interface ISqlAzureV12TSqlEventSessionAction : ISqlModelElement
	{		
		String ActionName 
		{
			get;
		}
		String EventModuleGuid 
		{
			get;
		}
		String EventPackageName 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlEventSessionDefinitionsReference : ISqlAzureV12TSqlEventSessionDefinitions
	{
    }
	public interface ISqlAzureV12TSqlEventSessionDefinitions : ISqlModelElement
	{		
		String EventModuleGuid 
		{
			get;
		}
		String EventName 
		{
			get;
		}
		String EventPackageName 
		{
			get;
		}
		String WhereExpression 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlEventSessionAction> Actions 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.TSqlModelElement> AttributeSettings 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlEventSessionSettingReference : ISqlAzureV12TSqlEventSessionSetting
	{
    }
	public interface ISqlAzureV12TSqlEventSessionSetting : ISqlModelElement
	{		
		String SettingName 
		{
			get;
		}
		String SettingValue 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlEventSessionTargetReference : ISqlAzureV12TSqlEventSessionTarget
	{
    }
	public interface ISqlAzureV12TSqlEventSessionTarget : ISqlModelElement
	{		
		String EventModuleGuid 
		{
			get;
		}
		String EventPackageName 
		{
			get;
		}
		String TargetName 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.TSqlModelElement> ParameterSettings 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlEventTypeSpecifierReference : ISqlAzureV12TSqlEventTypeSpecifier
	{
    }
	public interface ISqlAzureV12TSqlEventTypeSpecifier : ISqlModelElement
	{		
		EventType EventType 
		{
			get;
		}
		OrderRestriction Order 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlExtendedProcedureReference : ISqlAzureV12TSqlExtendedProcedure
	{
    }
	public interface ISqlAzureV12TSqlExtendedProcedure : ISqlModelElement
	{		
		Boolean ExeccuteAsCaller 
		{
			get;
		}
		Boolean ExecuteAsOwner 
		{
			get;
		}
		Boolean ExecuteAsSelf 
		{
			get;
		}
		Boolean WithEncryption 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlLoginReference> Login 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlParameter> Parameters 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlSchemaReference> Schema 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlUserReference> User 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlExtendedPropertyReference : ISqlAzureV12TSqlExtendedProperty
	{
    }
	public interface ISqlAzureV12TSqlExtendedProperty : ISqlModelElement
	{		
		String Value 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.IExtendedPropertyHost> Host 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlExternalDataSourceReference : ISqlAzureV12TSqlExternalDataSource
	{
    }
	public interface ISqlAzureV12TSqlExternalDataSource : ISqlModelElement
	{		
		String DatabaseName 
		{
			get;
		}
		DataSourceType DataSourceType 
		{
			get;
		}
		String Location 
		{
			get;
		}
		String ShardMapName 
		{
			get;
		}
		//Peer
		IEnumerable<TSqlModelElementReference> Credential 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlExternalFileFormatReference : ISqlAzureV12TSqlExternalFileFormat
	{
    }
	public interface ISqlAzureV12TSqlExternalFileFormat : ISqlModelElement
	{		
	}
    public interface ISqlAzureV12TSqlExternalTableReference : ISqlAzureV12TSqlExternalTable
	{
    }
	public interface ISqlAzureV12TSqlExternalTable : ISqlModelElement
	{		
		Int32 DistributionPolicyType 
		{
			get;
		}
		String ExternalObjectName 
		{
			get;
		}
		String ExternalSchemaName 
		{
			get;
		}
		Boolean? IsAnsiNullsOn 
		{
			get;
		}
		Boolean? IsQuotedIdentifierOn 
		{
			get;
		}
		Boolean IsTableLockOnBulkLoad 
		{
			get;
		}
		LockEscalationMethod LockEscalation 
		{
			get;
		}
		//Composing
		IEnumerable<TSqlModelElementReference> Columns 
		{
			get;
		}
		//Composing
		IEnumerable<TSqlModelElementReference> DataCompressionOptions 
		{
			get;
		}
		//Peer
		IEnumerable<TSqlModelElementReference> DataSourceName 
		{
			get;
		}
		//Peer
		IEnumerable<TSqlModelElementReference> Filegroup 
		{
			get;
		}
		//Peer
		IEnumerable<TSqlModelElementReference> PartitionColumn 
		{
			get;
		}
		//Peer
		IEnumerable<TSqlModelElementReference> PartitionScheme 
		{
			get;
		}
		//Hierarchical
		IEnumerable<TSqlModelElementReference> Schema 
		{
			get;
		}
		//Peer
		IEnumerable<TSqlModelElementReference> ShardingColumn 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlSqlFileReference : ISqlAzureV12TSqlSqlFile
	{
    }
	public interface ISqlAzureV12TSqlSqlFile : ISqlModelElement
	{		
	}
    public interface ISqlAzureV12TSqlFilegroupReference : ISqlAzureV12TSqlFilegroup
	{
    }
	public interface ISqlAzureV12TSqlFilegroup : ISqlModelElement
	{		
	}
    public interface ISqlAzureV12TSqlForeignKeyConstraintReference : ISqlAzureV12TSqlForeignKeyConstraint
	{
    }
	public interface ISqlAzureV12TSqlForeignKeyConstraint : ISqlModelElement
	{		
		ForeignKeyAction DeleteAction 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Boolean NotForReplication 
		{
			get;
		}
		ForeignKeyAction UpdateAction 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlColumnReference> Columns 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlColumnReference> ForeignColumns 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlTableReference> ForeignTable 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlTableReference> Host 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlFullTextCatalogReference : ISqlAzureV12TSqlFullTextCatalog
	{
    }
	public interface ISqlAzureV12TSqlFullTextCatalog : ISqlModelElement
	{		
		Boolean? AccentSensitivity 
		{
			get;
		}
		Boolean IsDefault 
		{
			get;
		}
		String Path 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlFilegroupReference> Filegroup 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlFullTextIndexReference : ISqlAzureV12TSqlFullTextIndex
	{
    }
	public interface ISqlAzureV12TSqlFullTextIndex : ISqlModelElement
	{		
		ChangeTrackingOption ChangeTracking 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Boolean StopListOff 
		{
			get;
		}
		Boolean UseSystemStopList 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.TSqlModelElementReference> Catalog 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlFullTextIndexColumnSpecifier> Columns 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlFilegroupReference> Filegroup 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISpecifiesIndex> IndexedObject 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> StopList 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> UniqueIndexName 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlFullTextIndexColumnSpecifierReference : ISqlAzureV12TSqlFullTextIndexColumnSpecifier
	{
    }
	public interface ISqlAzureV12TSqlFullTextIndexColumnSpecifier : ISqlModelElement
	{		
		Int32? LanguageId 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlColumnReference> Column 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlColumnReference> TypeColumn 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlFullTextStopListReference : ISqlAzureV12TSqlFullTextStopList
	{
    }
	public interface ISqlAzureV12TSqlFullTextStopList : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlHttpProtocolSpecifierReference : ISqlAzureV12TSqlHttpProtocolSpecifier
	{
    }
	public interface ISqlAzureV12TSqlHttpProtocolSpecifier : ISqlModelElement
	{		
	}
    public interface ISqlAzureV12TSqlLinkedServerReference : ISqlAzureV12TSqlLinkedServer
	{
    }
	public interface ISqlAzureV12TSqlLinkedServer : ISqlModelElement
	{		
	}
    public interface ISqlAzureV12TSqlLinkedServerLoginReference : ISqlAzureV12TSqlLinkedServerLogin
	{
    }
	public interface ISqlAzureV12TSqlLinkedServerLogin : ISqlModelElement
	{		
	}
    public interface ISqlAzureV12TSqlLoginReference : ISqlAzureV12TSqlLogin
	{
    }
	public interface ISqlAzureV12TSqlLogin : ISqlModelElement
	{		
		Boolean Disabled 
		{
			get;
		}
		String Password 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlMasterKeyReference : ISqlAzureV12TSqlMasterKey
	{
    }
	public interface ISqlAzureV12TSqlMasterKey : ISqlModelElement
	{		
		String Password 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlMessageTypeReference : ISqlAzureV12TSqlMessageType
	{
    }
	public interface ISqlAzureV12TSqlMessageType : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlPartitionFunctionReference : ISqlAzureV12TSqlPartitionFunction
	{
    }
	public interface ISqlAzureV12TSqlPartitionFunction : ISqlModelElement
	{		
		PartitionRange Range 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlPartitionValue> BoundaryValues 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlDataTypeReference> ParameterType 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlPartitionSchemeReference : ISqlAzureV12TSqlPartitionScheme
	{
    }
	public interface ISqlAzureV12TSqlPartitionScheme : ISqlModelElement
	{		
		Boolean AllToOneFilegroup 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlFilegroupReference> Filegroups 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlPartitionFunctionReference> PartitionFunction 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlPartitionValueReference : ISqlAzureV12TSqlPartitionValue
	{
    }
	public interface ISqlAzureV12TSqlPartitionValue : ISqlModelElement
	{		
		String Expression 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ExpressionDependencies 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlPermissionReference : ISqlAzureV12TSqlPermission
	{
    }
	public interface ISqlAzureV12TSqlPermission : ISqlModelElement
	{		
		PermissionAction PermissionAction 
		{
			get;
		}
		PermissionType PermissionType 
		{
			get;
		}
		Boolean WithAllPrivileges 
		{
			get;
		}
		Boolean WithGrantOption 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlColumnReference> ExcludedColumns 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlSecurityPrincipal> Grantee 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlSecurityPrincipal> Grantor 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlColumnReference> RevokedGrantOptionColumns 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlSecurable> SecuredObject 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlPrimaryKeyConstraintReference : ISqlAzureV12TSqlPrimaryKeyConstraint
	{
    }
	public interface ISqlAzureV12TSqlPrimaryKeyConstraint : ISqlModelElement
	{		
		Boolean AllowPageLocks 
		{
			get;
		}
		Boolean AllowRowLocks 
		{
			get;
		}
		Int32? BucketCount 
		{
			get;
		}
		Boolean Clustered 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Int32? FillFactor 
		{
			get;
		}
		Boolean Hash 
		{
			get;
		}
		Boolean IgnoreDuplicateKey 
		{
			get;
		}
		Boolean RecomputeStatistics 
		{
			get;
		}
		Boolean WithPadIndex 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlColumnReference> Columns 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlDataCompressionOption> DataCompressionOptions 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlFilegroupReference> Filegroup 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlTableReference> Host 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlColumnReference> PartitionColumn 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlPartitionSchemeReference> PartitionScheme 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlProcedureReference : ISqlAzureV12TSqlProcedure
	{
    }
	public interface ISqlAzureV12TSqlProcedure : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		String ClassName 
		{
			get;
		}
		Boolean ExecuteAsCaller 
		{
			get;
		}
		Boolean ExecuteAsOwner 
		{
			get;
		}
		Boolean ExecuteAsSelf 
		{
			get;
		}
		String MethodName 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		Boolean WithEncryption 
		{
			get;
		}
		Boolean WithNativeCompilation 
		{
			get;
		}
		Boolean WithRecompile 
		{
			get;
		}
		Boolean WithSchemaBinding 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlAssemblyReference> Assembly 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BodyDependencies 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlLoginReference> Login 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlParameter> Parameters 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlProcedureReference> ParentProcedure 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlSchemaReference> Schema 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlUserReference> User 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlQueueReference : ISqlAzureV12TSqlQueue
	{
    }
	public interface ISqlAzureV12TSqlQueue : ISqlModelElement
	{		
		Boolean ActivationExecuteAsCaller 
		{
			get;
		}
		Boolean ActivationExecuteAsOwner 
		{
			get;
		}
		Boolean ActivationExecuteAsSelf 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlColumn> Columns 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlFilegroupReference> Filegroup 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlLoginReference> Login 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlColumnReference> PartitionColumn 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlPartitionSchemeReference> PartitionScheme 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlSchemaReference> Schema 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlUserReference> User 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlQueueEventNotificationReference : ISqlAzureV12TSqlQueueEventNotification
	{
    }
	public interface ISqlAzureV12TSqlQueueEventNotification : ISqlModelElement
	{		
	}
    public interface ISqlAzureV12TSqlRemoteServiceBindingReference : ISqlAzureV12TSqlRemoteServiceBinding
	{
    }
	public interface ISqlAzureV12TSqlRemoteServiceBinding : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlResourceGovernorReference : ISqlAzureV12TSqlResourceGovernor
	{
    }
	public interface ISqlAzureV12TSqlResourceGovernor : ISqlModelElement
	{		
	}
    public interface ISqlAzureV12TSqlResourcePoolReference : ISqlAzureV12TSqlResourcePool
	{
    }
	public interface ISqlAzureV12TSqlResourcePool : ISqlModelElement
	{		
	}
    public interface ISqlAzureV12TSqlRoleReference : ISqlAzureV12TSqlRole
	{
    }
	public interface ISqlAzureV12TSqlRole : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlRoleMembershipReference : ISqlAzureV12TSqlRoleMembership
	{
    }
	public interface ISqlAzureV12TSqlRoleMembership : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlDatabaseSecurityPrincipal> Member 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlRoleReference> Role 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlRouteReference : ISqlAzureV12TSqlRoute
	{
    }
	public interface ISqlAzureV12TSqlRoute : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlRuleReference : ISqlAzureV12TSqlRule
	{
    }
	public interface ISqlAzureV12TSqlRule : ISqlModelElement
	{		
		String Expression 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BoundObjects 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlSchemaReference : ISqlAzureV12TSqlSchema
	{
    }
	public interface ISqlAzureV12TSqlSchema : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlSearchPropertyReference : ISqlAzureV12TSqlSearchProperty
	{
    }
	public interface ISqlAzureV12TSqlSearchProperty : ISqlModelElement
	{		
	}
    public interface ISqlAzureV12TSqlSearchPropertyListReference : ISqlAzureV12TSqlSearchPropertyList
	{
    }
	public interface ISqlAzureV12TSqlSearchPropertyList : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlSecurityPolicyReference : ISqlAzureV12TSqlSecurityPolicy
	{
    }
	public interface ISqlAzureV12TSqlSecurityPolicy : ISqlModelElement
	{		
		Boolean Enabled 
		{
			get;
		}
		Boolean IsSchemaBound 
		{
			get;
		}
		Boolean NotForReplication 
		{
			get;
		}
		//Composing
		IEnumerable<TSqlModelElementReference> Predicates 
		{
			get;
		}
		//Hierarchical
		IEnumerable<TSqlModelElementReference> Schema 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlSecurityPredicateReference : ISqlAzureV12TSqlSecurityPredicate
	{
    }
	public interface ISqlAzureV12TSqlSecurityPredicate : ISqlModelElement
	{		
		String BodyScript 
		{
			get;
		}
		SecurityPredicateOperation Operation 
		{
			get;
		}
		SecurityPredicateType PredicateType 
		{
			get;
		}
		//Peer
		IEnumerable<TSqlModelElementReference> BodyDependencies 
		{
			get;
		}
		//Peer
		IEnumerable<TSqlModelElementReference> TargetObject 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlSequenceReference : ISqlAzureV12TSqlSequence
	{
    }
	public interface ISqlAzureV12TSqlSequence : ISqlModelElement
	{		
		Int32? CacheSize 
		{
			get;
		}
		String IncrementValue 
		{
			get;
		}
		Boolean IsCached 
		{
			get;
		}
		Boolean IsCycling 
		{
			get;
		}
		String MaxValue 
		{
			get;
		}
		String MinValue 
		{
			get;
		}
		Boolean NoMaxValue 
		{
			get;
		}
		Boolean NoMinValue 
		{
			get;
		}
		String StartValue 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlDataTypeReference> DataType 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlServerAuditReference : ISqlAzureV12TSqlServerAudit
	{
    }
	public interface ISqlAzureV12TSqlServerAudit : ISqlModelElement
	{		
	}
    public interface ISqlAzureV12TSqlServerAuditSpecificationReference : ISqlAzureV12TSqlServerAuditSpecification
	{
    }
	public interface ISqlAzureV12TSqlServerAuditSpecification : ISqlModelElement
	{		
	}
    public interface ISqlAzureV12TSqlServerDdlTriggerReference : ISqlAzureV12TSqlServerDdlTrigger
	{
    }
	public interface ISqlAzureV12TSqlServerDdlTrigger : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		String ClassName 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Boolean ExecuteAsCaller 
		{
			get;
		}
		Boolean ExecuteAsOwner 
		{
			get;
		}
		Boolean ExecuteAsSelf 
		{
			get;
		}
		String MethodName 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		TriggerType TriggerType 
		{
			get;
		}
		Boolean WithEncryption 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlAssemblyReference> Assembly 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BodyDependencies 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlEventGroup> EventGroup 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Model.EventType> EventType 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlLoginReference> Login 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlUserReference> User 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlServerEventNotificationReference : ISqlAzureV12TSqlServerEventNotification
	{
    }
	public interface ISqlAzureV12TSqlServerEventNotification : ISqlModelElement
	{		
	}
    public interface ISqlAzureV12TSqlServerOptionsReference : ISqlAzureV12TSqlServerOptions
	{
    }
	public interface ISqlAzureV12TSqlServerOptions : ISqlModelElement
	{		
	}
    public interface ISqlAzureV12TSqlServerRoleMembershipReference : ISqlAzureV12TSqlServerRoleMembership
	{
    }
	public interface ISqlAzureV12TSqlServerRoleMembership : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.IServerSecurityPrincipal> Member 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlRoleReference> Role 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlServiceReference : ISqlAzureV12TSqlService
	{
    }
	public interface ISqlAzureV12TSqlService : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlServiceBrokerLanguageSpecifierReference : ISqlAzureV12TSqlServiceBrokerLanguageSpecifier
	{
    }
	public interface ISqlAzureV12TSqlServiceBrokerLanguageSpecifier : ISqlModelElement
	{		
	}
    public interface ISqlAzureV12TSqlSignatureReference : ISqlAzureV12TSqlSignature
	{
    }
	public interface ISqlAzureV12TSqlSignature : ISqlModelElement
	{		
	}
    public interface ISqlAzureV12TSqlSignatureEncryptionMechanismReference : ISqlAzureV12TSqlSignatureEncryptionMechanism
	{
    }
	public interface ISqlAzureV12TSqlSignatureEncryptionMechanism : ISqlModelElement
	{		
	}
    public interface ISqlAzureV12TSqlSoapLanguageSpecifierReference : ISqlAzureV12TSqlSoapLanguageSpecifier
	{
    }
	public interface ISqlAzureV12TSqlSoapLanguageSpecifier : ISqlModelElement
	{		
	}
    public interface ISqlAzureV12TSqlSoapMethodSpecificationReference : ISqlAzureV12TSqlSoapMethodSpecification
	{
    }
	public interface ISqlAzureV12TSqlSoapMethodSpecification : ISqlModelElement
	{		
	}
    public interface ISqlAzureV12TSqlSpatialIndexReference : ISqlAzureV12TSqlSpatialIndex
	{
    }
	public interface ISqlAzureV12TSqlSpatialIndex : ISqlModelElement
	{		
		Boolean AllowPageLocks 
		{
			get;
		}
		Boolean AllowRowLocks 
		{
			get;
		}
		Int32? CellsPerObject 
		{
			get;
		}
		CompressionLevel DataCompression 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Int32 FillFactor 
		{
			get;
		}
		Degree GridLevel1Density 
		{
			get;
		}
		Degree GridLevel2Density 
		{
			get;
		}
		Degree GridLevel3Density 
		{
			get;
		}
		Degree GridLevel4Density 
		{
			get;
		}
		Boolean IgnoreDuplicateKey 
		{
			get;
		}
		Boolean RecomputeStatistics 
		{
			get;
		}
		Tessellation Tessellation 
		{
			get;
		}
		Boolean WithPadIndex 
		{
			get;
		}
		Double? XMax 
		{
			get;
		}
		Double? XMin 
		{
			get;
		}
		Double? YMax 
		{
			get;
		}
		Double? YMin 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlColumnReference> Column 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlFilegroupReference> Filegroup 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISpecifiesIndex> IndexedObject 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlColumnReference> PartitionColumn 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlPartitionSchemeReference> PartitionScheme 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlStatisticsReference : ISqlAzureV12TSqlStatistics
	{
    }
	public interface ISqlAzureV12TSqlStatistics : ISqlModelElement
	{		
		String FilterPredicate 
		{
			get;
		}
		Boolean Incremental 
		{
			get;
		}
		Boolean NoRecompute 
		{
			get;
		}
		Int32 SampleSize 
		{
			get;
		}
		SamplingStyle SamplingStyle 
		{
			get;
		}
		String StatsStream 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlColumnReference> Columns 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ExpressionDependencies 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> OnObject 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlParameterReference : ISqlAzureV12TSqlParameter
	{
    }
	public interface ISqlAzureV12TSqlParameter : ISqlModelElement
	{		
		String DefaultExpression 
		{
			get;
		}
		Boolean IsMax 
		{
			get;
		}
		Boolean IsNullable 
		{
			get;
		}
		Boolean IsOutput 
		{
			get;
		}
		Int32 Length 
		{
			get;
		}
		Int32 Precision 
		{
			get;
		}
		Boolean ReadOnly 
		{
			get;
		}
		Int32 Scale 
		{
			get;
		}
		Boolean Varying 
		{
			get;
		}
		XmlStyle XmlStyle 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlDataType> DataType 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlXmlSchemaCollectionReference> XmlSchemaCollection 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlSymmetricKeyReference : ISqlAzureV12TSqlSymmetricKey
	{
    }
	public interface ISqlAzureV12TSqlSymmetricKey : ISqlModelElement
	{		
		SymmetricKeyAlgorithm Algorithm 
		{
			get;
		}
		String IdentityValue 
		{
			get;
		}
		String KeySource 
		{
			get;
		}
		String ProviderKeyName 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlCertificateReference> Certificates 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.TSqlModelElement> Passwords 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlSymmetricKeyReference> SymmetricKeys 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlSymmetricKeyPasswordReference : ISqlAzureV12TSqlSymmetricKeyPassword
	{
    }
	public interface ISqlAzureV12TSqlSymmetricKeyPassword : ISqlModelElement
	{		
		String Password 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlSynonymReference : ISqlAzureV12TSqlSynonym
	{
    }
	public interface ISqlAzureV12TSqlSynonym : ISqlModelElement
	{		
		String ForObjectName 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ForObject 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlTableReference : ISqlAzureV12TSqlTable
	{
    }
	public interface ISqlAzureV12TSqlTable : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		Boolean ChangeTrackingEnabled 
		{
			get;
		}
		Int64? DataPages 
		{
			get;
		}
		Double? DataSize 
		{
			get;
		}
		Durability Durability 
		{
			get;
		}
		Double? IndexSize 
		{
			get;
		}
		Boolean IsAutoGeneratedHistoryTable 
		{
			get;
		}
		Boolean IsEdge 
		{
			get;
		}
		Boolean IsNode 
		{
			get;
		}
		Boolean LargeValueTypesOutOfRow 
		{
			get;
		}
		LockEscalationMethod LockEscalation 
		{
			get;
		}
		Boolean MemoryOptimized 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		Int32 RetentionUnit 
		{
			get;
		}
		Int32 RetentionValue 
		{
			get;
		}
		Int64? RowCount 
		{
			get;
		}
		Boolean TableLockOnBulkLoad 
		{
			get;
		}
		Int32 TextInRowSize 
		{
			get;
		}
		Boolean TrackColumnsUpdated 
		{
			get;
		}
		Int64? UsedPages 
		{
			get;
		}
		Boolean VardecimalStorageFormatEnabled 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlColumn> Columns 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlDataCompressionOption> DataCompressionOptions 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlFilegroupReference> Filegroup 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlColumnReference> PartitionColumn 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlPartitionSchemeReference> PartitionScheme 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlSchemaReference> Schema 
		{
			get;
		}
		//Peer
		IEnumerable<TSqlModelElementReference> TemporalSystemVersioningHistoryTable 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlFileTableReference : ISqlAzureV12TSqlFileTable
	{
    }
	public interface ISqlAzureV12TSqlFileTable : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		LockEscalationMethod LockEscalation 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		Boolean TableLockOnBulkLoad 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlColumn> Columns 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlDataCompressionOption> DataCompressionOptions 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlFilegroupReference> Filegroup 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlColumnReference> PartitionColumn 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlPartitionSchemeReference> PartitionScheme 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlTableTypeReference : ISqlAzureV12TSqlTableType
	{
    }
	public interface ISqlAzureV12TSqlTableType : ISqlModelElement
	{		
		Boolean MemoryOptimized 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlTableTypeColumn> Columns 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ITableTypeConstraint> Constraints 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.TSqlTableTypeIndex> Indexes 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlTableTypeCheckConstraintReference : ISqlAzureV12TSqlTableTypeCheckConstraint
	{
    }
	public interface ISqlAzureV12TSqlTableTypeCheckConstraint : ISqlModelElement
	{		
		String Expression 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ExpressionDependencies 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlTableTypeColumnReference : ISqlAzureV12TSqlTableTypeColumn
	{
    }
	public interface ISqlAzureV12TSqlTableTypeColumn : ISqlModelElement
	{		
		String Collation 
		{
			get;
		}
		String Expression 
		{
			get;
		}
		String IdentityIncrement 
		{
			get;
		}
		String IdentitySeed 
		{
			get;
		}
		Boolean IsIdentity 
		{
			get;
		}
		Boolean IsMax 
		{
			get;
		}
		Boolean IsRowGuidCol 
		{
			get;
		}
		Int32 Length 
		{
			get;
		}
		Boolean Nullable 
		{
			get;
		}
		Boolean Persisted 
		{
			get;
		}
		Boolean? PersistedNullable 
		{
			get;
		}
		Int32 Precision 
		{
			get;
		}
		Int32 Scale 
		{
			get;
		}
		XmlStyle XmlStyle 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlDataType> DataType 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ExpressionDependencies 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlXmlSchemaCollectionReference> XmlSchemaCollection 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlTableTypeDefaultConstraintReference : ISqlAzureV12TSqlTableTypeDefaultConstraint
	{
    }
	public interface ISqlAzureV12TSqlTableTypeDefaultConstraint : ISqlModelElement
	{		
		String Expression 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> ExpressionDependencies 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlColumnReference> TargetColumn 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlTableTypeIndexReference : ISqlAzureV12TSqlTableTypeIndex
	{
    }
	public interface ISqlAzureV12TSqlTableTypeIndex : ISqlModelElement
	{		
		Int32? BucketCount 
		{
			get;
		}
		Boolean Hash 
		{
			get;
		}
		Boolean IsDisabled 
		{
			get;
		}
		Boolean IsUnique 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlColumnReference> Columns 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlTableTypePrimaryKeyConstraintReference : ISqlAzureV12TSqlTableTypePrimaryKeyConstraint
	{
    }
	public interface ISqlAzureV12TSqlTableTypePrimaryKeyConstraint : ISqlModelElement
	{		
		Int32? BucketCount 
		{
			get;
		}
		Boolean Clustered 
		{
			get;
		}
		Boolean Hash 
		{
			get;
		}
		Boolean IgnoreDuplicateKey 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlColumnReference> Columns 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlTableTypeUniqueConstraintReference : ISqlAzureV12TSqlTableTypeUniqueConstraint
	{
    }
	public interface ISqlAzureV12TSqlTableTypeUniqueConstraint : ISqlModelElement
	{		
		Int32? BucketCount 
		{
			get;
		}
		Boolean Clustered 
		{
			get;
		}
		Boolean Hash 
		{
			get;
		}
		Boolean IgnoreDuplicateKey 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlColumnReference> Columns 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlTcpProtocolSpecifierReference : ISqlAzureV12TSqlTcpProtocolSpecifier
	{
    }
	public interface ISqlAzureV12TSqlTcpProtocolSpecifier : ISqlModelElement
	{		
	}
    public interface ISqlAzureV12TSqlUniqueConstraintReference : ISqlAzureV12TSqlUniqueConstraint
	{
    }
	public interface ISqlAzureV12TSqlUniqueConstraint : ISqlModelElement
	{		
		Boolean AllowPageLocks 
		{
			get;
		}
		Boolean AllowRowLocks 
		{
			get;
		}
		Int32? BucketCount 
		{
			get;
		}
		Boolean Clustered 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Int32? FillFactor 
		{
			get;
		}
		Boolean Hash 
		{
			get;
		}
		Boolean IgnoreDuplicateKey 
		{
			get;
		}
		Boolean RecomputeStatistics 
		{
			get;
		}
		Boolean WithPadIndex 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlColumnReference> Columns 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlDataCompressionOption> DataCompressionOptions 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlFilegroupReference> Filegroup 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlTableReference> Host 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlColumnReference> PartitionColumn 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlPartitionSchemeReference> PartitionScheme 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlUserReference : ISqlAzureV12TSqlUser
	{
    }
	public interface ISqlAzureV12TSqlUser : ISqlModelElement
	{		
		AuthenticationType AuthenticationType 
		{
			get;
		}
		String Password 
		{
			get;
		}
		String Sid 
		{
			get;
		}
		UserType UserType 
		{
			get;
		}
		Boolean WithoutLogin 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlSchemaReference> DefaultSchema 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlLoginReference> Login 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlUserDefinedServerRoleReference : ISqlAzureV12TSqlUserDefinedServerRole
	{
    }
	public interface ISqlAzureV12TSqlUserDefinedServerRole : ISqlModelElement
	{		
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlObjectAuthorizer> Authorizer 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlUserDefinedTypeReference : ISqlAzureV12TSqlUserDefinedType
	{
    }
	public interface ISqlAzureV12TSqlUserDefinedType : ISqlModelElement
	{		
		Boolean? ByteOrdered 
		{
			get;
		}
		String ClassName 
		{
			get;
		}
		Boolean? FixedLength 
		{
			get;
		}
		Format Format 
		{
			get;
		}
		Int32? MaxByteSize 
		{
			get;
		}
		String ValidationMethodName 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlAssemblyReference> Assembly 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.TSqlModelElement> Methods 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.TSqlModelElement> Properties 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlViewReference : ISqlAzureV12TSqlView
	{
    }
	public interface ISqlAzureV12TSqlView : ISqlModelElement
	{		
		Boolean? AnsiNullsOn 
		{
			get;
		}
		Boolean? QuotedIdentifierOn 
		{
			get;
		}
		String SelectStatement 
		{
			get;
		}
		Boolean WithCheckOption 
		{
			get;
		}
		Boolean WithEncryption 
		{
			get;
		}
		Boolean WithSchemaBinding 
		{
			get;
		}
		Boolean WithViewMetadata 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlModelElementReference> BodyDependencies 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlColumn> Columns 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlSchemaReference> Schema 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlWorkloadGroupReference : ISqlAzureV12TSqlWorkloadGroup
	{
    }
	public interface ISqlAzureV12TSqlWorkloadGroup : ISqlModelElement
	{		
	}
    public interface ISqlAzureV12TSqlXmlIndexReference : ISqlAzureV12TSqlXmlIndex
	{
    }
	public interface ISqlAzureV12TSqlXmlIndex : ISqlModelElement
	{		
		Boolean AllowPageLocks 
		{
			get;
		}
		Boolean AllowRowLocks 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Int32? FillFactor 
		{
			get;
		}
		Boolean IgnoreDuplicateKey 
		{
			get;
		}
		Boolean IsPrimary 
		{
			get;
		}
		Boolean RecomputeStatistics 
		{
			get;
		}
		SecondaryXmlIndexType SecondaryXmlIndexType 
		{
			get;
		}
		Boolean WithPadIndex 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlColumnReference> Column 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISpecifiesIndex> IndexedObject 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlXmlIndexReference> PrimaryXmlIndex 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlSelectiveXmlIndexReference : ISqlAzureV12TSqlSelectiveXmlIndex
	{
    }
	public interface ISqlAzureV12TSqlSelectiveXmlIndex : ISqlModelElement
	{		
		Boolean AllowPageLocks 
		{
			get;
		}
		Boolean AllowRowLocks 
		{
			get;
		}
		Boolean Disabled 
		{
			get;
		}
		Int32? FillFactor 
		{
			get;
		}
		Boolean IgnoreDuplicateKey 
		{
			get;
		}
		Boolean IsPrimary 
		{
			get;
		}
		Boolean RecomputeStatistics 
		{
			get;
		}
		Boolean WithPadIndex 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlColumnReference> Column 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISpecifiesIndex> IndexedObject 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlPromotedNodePath> PrimaryPromotedPath 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlSelectiveXmlIndexReference> PrimarySelectiveXmlIndex 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlPromotedNodePath> PromotedPaths 
		{
			get;
		}
		//Composing
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlXmlNamespace> XmlNamespaces 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlXmlNamespaceReference : ISqlAzureV12TSqlXmlNamespace
	{
    }
	public interface ISqlAzureV12TSqlXmlNamespace : ISqlModelElement
	{		
		String NamespaceUri 
		{
			get;
		}
		String Prefix 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlPromotedNodePathForXQueryTypeReference : ISqlAzureV12TSqlPromotedNodePathForXQueryType
	{
    }
	public interface ISqlAzureV12TSqlPromotedNodePathForXQueryType : ISqlModelElement
	{		
		Boolean IsSingleton 
		{
			get;
		}
		Int32? MaxLength 
		{
			get;
		}
		String NodePath 
		{
			get;
		}
		String Type 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlPromotedNodePathForSqlTypeReference : ISqlAzureV12TSqlPromotedNodePathForSqlType
	{
    }
	public interface ISqlAzureV12TSqlPromotedNodePathForSqlType : ISqlModelElement
	{		
		Boolean IsMax 
		{
			get;
		}
		Boolean IsSingleton 
		{
			get;
		}
		Int32 Length 
		{
			get;
		}
		String NodePath 
		{
			get;
		}
		Int32 Precision 
		{
			get;
		}
		Int32 Scale 
		{
			get;
		}
		//Peer
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlDataTypeReference> DataType 
		{
			get;
		}
	}
    public interface ISqlAzureV12TSqlXmlSchemaCollectionReference : ISqlAzureV12TSqlXmlSchemaCollection
	{
    }
	public interface ISqlAzureV12TSqlXmlSchemaCollection : ISqlModelElement
	{		
		String Expression 
		{
			get;
		}
		//Hierarchical
		IEnumerable<Microsoft.SqlServer.Dac.Extensions.Prototype.ISqlAzureV12TSqlSchemaReference> Schema 
		{
			get;
		}
	}
}