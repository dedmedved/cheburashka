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
    using System.Collections.Generic;
    using System.Globalization;
    using Microsoft.SqlServer.Server;
    using Microsoft.SqlServer.Dac.Model;

    public partial class TSqlModelElement
    {
        ///<summary>
        ///  Returns a strongly-typed wrapper for the TSqlObject instance.
        ///</summary>
        public static ISqlModelElementReference AdaptInstance(ModelRelationshipInstance obj,
            Func<ModelRelationshipInstance, ISqlModelElementReference> createUnresolvedElement)
        {
            ModelTypeClass objectType = null;

            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }

            if (obj.Object != null)
            {
                objectType = obj.Object.ObjectType;
            }
            else
            {
                return createUnresolvedElement(obj);
            }

            switch (objectType.Name)
            {
                case "Column":
                    return new TSqlColumnReference(obj, objectType);
                case "TableValuedFunction":
                    return new TSqlTableValuedFunctionReference(obj, objectType);
                case "ScalarFunction":
                    return new TSqlScalarFunctionReference(obj, objectType);
                case "ClrTableOption":
                    return new TSqlClrTableOptionReference(obj, objectType);
                case "Aggregate":
                    return new TSqlAggregateReference(obj, objectType);
                case "ApplicationRole":
                    return new TSqlApplicationRoleReference(obj, objectType);
                case "Index":
                    return new TSqlIndexReference(obj, objectType);
                case "Assembly":
                    return new TSqlAssemblyReference(obj, objectType);
                case "AssemblySource":
                    return new TSqlAssemblySourceReference(obj, objectType);
                case "AsymmetricKey":
                    return new TSqlAsymmetricKeyReference(obj, objectType);
                case "AuditAction":
                    return new TSqlAuditActionReference(obj, objectType);
                case "AuditActionGroup":
                    return new TSqlAuditActionGroupReference(obj, objectType);
                case "AuditActionSpecification":
                    return new TSqlAuditActionSpecificationReference(obj, objectType);
                case "BrokerPriority":
                    return new TSqlBrokerPriorityReference(obj, objectType);
                case "BuiltInServerRole":
                    return new TSqlBuiltInServerRoleReference(obj, objectType);
                case "DataType":
                    return new TSqlDataTypeReference(obj, objectType);
                case "Certificate":
                    return new TSqlCertificateReference(obj, objectType);
                case "CheckConstraint":
                    return new TSqlCheckConstraintReference(obj, objectType);
                case "ClrTypeMethod":
                    return new TSqlClrTypeMethodReference(obj, objectType);
                case "ClrTypeMethodParameter":
                    return new TSqlClrTypeMethodParameterReference(obj, objectType);
                case "ClrTypeProperty":
                    return new TSqlClrTypePropertyReference(obj, objectType);
                case "ColumnStoreIndex":
                    return new TSqlColumnStoreIndexReference(obj, objectType);
                case "Contract":
                    return new TSqlContractReference(obj, objectType);
                case "Credential":
                    return new TSqlCredentialReference(obj, objectType);
                case "DatabaseCredential":
                    return new TSqlDatabaseCredentialReference(obj, objectType);
                case "CryptographicProvider":
                    return new TSqlCryptographicProviderReference(obj, objectType);
                case "DatabaseAuditSpecification":
                    return new TSqlDatabaseAuditSpecificationReference(obj, objectType);
                case "DatabaseDdlTrigger":
                    return new TSqlDatabaseDdlTriggerReference(obj, objectType);
                case "DatabaseEncryptionKey":
                    return new TSqlDatabaseEncryptionKeyReference(obj, objectType);
                case "DatabaseEventNotification":
                    return new TSqlDatabaseEventNotificationReference(obj, objectType);
                case "DatabaseMirroringLanguageSpecifier":
                    return new TSqlDatabaseMirroringLanguageSpecifierReference(obj, objectType);
                case "DatabaseOptions":
                    return new TSqlDatabaseOptionsReference(obj, objectType);
                case "DataCompressionOption":
                    return new TSqlDataCompressionOptionReference(obj, objectType);
                case "Default":
                    return new TSqlDefaultReference(obj, objectType);
                case "DefaultConstraint":
                    return new TSqlDefaultConstraintReference(obj, objectType);
                case "DmlTrigger":
                    return new TSqlDmlTriggerReference(obj, objectType);
                case "Endpoint":
                    return new TSqlEndpointReference(obj, objectType);
                case "ErrorMessage":
                    return new TSqlErrorMessageReference(obj, objectType);
                case "EventGroup":
                    return new TSqlEventGroupReference(obj, objectType);
                case "EventSession":
                    return new TSqlEventSessionReference(obj, objectType);
                case "DatabaseEventSession":
                    return new TSqlDatabaseEventSessionReference(obj, objectType);
                case "EventSessionAction":
                    return new TSqlEventSessionActionReference(obj, objectType);
                case "EventSessionDefinitions":
                    return new TSqlEventSessionDefinitionsReference(obj, objectType);
                case "EventSessionSetting":
                    return new TSqlEventSessionSettingReference(obj, objectType);
                case "EventSessionTarget":
                    return new TSqlEventSessionTargetReference(obj, objectType);
                case "EventTypeSpecifier":
                    return new TSqlEventTypeSpecifierReference(obj, objectType);
                case "ExtendedProcedure":
                    return new TSqlExtendedProcedureReference(obj, objectType);
                case "ExtendedProperty":
                    return new TSqlExtendedPropertyReference(obj, objectType);
                case "ExternalDataSource":
                    return new TSqlExternalDataSourceReference(obj, objectType);
                case "ExternalFileFormat":
                    return new TSqlExternalFileFormatReference(obj, objectType);
                case "ExternalTable":
                    return new TSqlExternalTableReference(obj, objectType);
                case "SqlFile":
                    return new TSqlSqlFileReference(obj, objectType);
                case "Filegroup":
                    return new TSqlFilegroupReference(obj, objectType);
                case "ForeignKeyConstraint":
                    return new TSqlForeignKeyConstraintReference(obj, objectType);
                case "FullTextCatalog":
                    return new TSqlFullTextCatalogReference(obj, objectType);
                case "FullTextIndex":
                    return new TSqlFullTextIndexReference(obj, objectType);
                case "FullTextIndexColumnSpecifier":
                    return new TSqlFullTextIndexColumnSpecifierReference(obj, objectType);
                case "FullTextStopList":
                    return new TSqlFullTextStopListReference(obj, objectType);
                case "HttpProtocolSpecifier":
                    return new TSqlHttpProtocolSpecifierReference(obj, objectType);
                case "LinkedServer":
                    return new TSqlLinkedServerReference(obj, objectType);
                case "LinkedServerLogin":
                    return new TSqlLinkedServerLoginReference(obj, objectType);
                case "Login":
                    return new TSqlLoginReference(obj, objectType);
                case "MasterKey":
                    return new TSqlMasterKeyReference(obj, objectType);
                case "MessageType":
                    return new TSqlMessageTypeReference(obj, objectType);
                case "PartitionFunction":
                    return new TSqlPartitionFunctionReference(obj, objectType);
                case "PartitionScheme":
                    return new TSqlPartitionSchemeReference(obj, objectType);
                case "PartitionValue":
                    return new TSqlPartitionValueReference(obj, objectType);
                case "Permission":
                    return new TSqlPermissionReference(obj, objectType);
                case "PrimaryKeyConstraint":
                    return new TSqlPrimaryKeyConstraintReference(obj, objectType);
                case "Procedure":
                    return new TSqlProcedureReference(obj, objectType);
                case "Queue":
                    return new TSqlQueueReference(obj, objectType);
                case "QueueEventNotification":
                    return new TSqlQueueEventNotificationReference(obj, objectType);
                case "RemoteServiceBinding":
                    return new TSqlRemoteServiceBindingReference(obj, objectType);
                case "ResourceGovernor":
                    return new TSqlResourceGovernorReference(obj, objectType);
                case "ResourcePool":
                    return new TSqlResourcePoolReference(obj, objectType);
                case "Role":
                    return new TSqlRoleReference(obj, objectType);
                case "RoleMembership":
                    return new TSqlRoleMembershipReference(obj, objectType);
                case "Route":
                    return new TSqlRouteReference(obj, objectType);
                case "Rule":
                    return new TSqlRuleReference(obj, objectType);
                case "Schema":
                    return new TSqlSchemaReference(obj, objectType);
                case "SearchProperty":
                    return new TSqlSearchPropertyReference(obj, objectType);
                case "SearchPropertyList":
                    return new TSqlSearchPropertyListReference(obj, objectType);
                case "SecurityPolicy":
                    return new TSqlSecurityPolicyReference(obj, objectType);
                case "SecurityPredicate":
                    return new TSqlSecurityPredicateReference(obj, objectType);
                case "Sequence":
                    return new TSqlSequenceReference(obj, objectType);
                case "ServerAudit":
                    return new TSqlServerAuditReference(obj, objectType);
                case "ServerAuditSpecification":
                    return new TSqlServerAuditSpecificationReference(obj, objectType);
                case "ServerDdlTrigger":
                    return new TSqlServerDdlTriggerReference(obj, objectType);
                case "ServerEventNotification":
                    return new TSqlServerEventNotificationReference(obj, objectType);
                case "ServerOptions":
                    return new TSqlServerOptionsReference(obj, objectType);
                case "ServerRoleMembership":
                    return new TSqlServerRoleMembershipReference(obj, objectType);
                case "Service":
                    return new TSqlServiceReference(obj, objectType);
                case "ServiceBrokerLanguageSpecifier":
                    return new TSqlServiceBrokerLanguageSpecifierReference(obj, objectType);
                case "Signature":
                    return new TSqlSignatureReference(obj, objectType);
                case "SignatureEncryptionMechanism":
                    return new TSqlSignatureEncryptionMechanismReference(obj, objectType);
                case "SoapLanguageSpecifier":
                    return new TSqlSoapLanguageSpecifierReference(obj, objectType);
                case "SoapMethodSpecification":
                    return new TSqlSoapMethodSpecificationReference(obj, objectType);
                case "SpatialIndex":
                    return new TSqlSpatialIndexReference(obj, objectType);
                case "Statistics":
                    return new TSqlStatisticsReference(obj, objectType);
                case "Parameter":
                    return new TSqlParameterReference(obj, objectType);
                case "SymmetricKey":
                    return new TSqlSymmetricKeyReference(obj, objectType);
                case "SymmetricKeyPassword":
                    return new TSqlSymmetricKeyPasswordReference(obj, objectType);
                case "Synonym":
                    return new TSqlSynonymReference(obj, objectType);
                case "Table":
                    return new TSqlTableReference(obj, objectType);
                case "FileTable":
                    return new TSqlFileTableReference(obj, objectType);
                case "TableType":
                    return new TSqlTableTypeReference(obj, objectType);
                case "TableTypeCheckConstraint":
                    return new TSqlTableTypeCheckConstraintReference(obj, objectType);
                case "TableTypeColumn":
                    return new TSqlTableTypeColumnReference(obj, objectType);
                case "TableTypeDefaultConstraint":
                    return new TSqlTableTypeDefaultConstraintReference(obj, objectType);
                case "TableTypeIndex":
                    return new TSqlTableTypeIndexReference(obj, objectType);
                case "TableTypePrimaryKeyConstraint":
                    return new TSqlTableTypePrimaryKeyConstraintReference(obj, objectType);
                case "TableTypeUniqueConstraint":
                    return new TSqlTableTypeUniqueConstraintReference(obj, objectType);
                case "TcpProtocolSpecifier":
                    return new TSqlTcpProtocolSpecifierReference(obj, objectType);
                case "UniqueConstraint":
                    return new TSqlUniqueConstraintReference(obj, objectType);
                case "User":
                    return new TSqlUserReference(obj, objectType);
                case "UserDefinedServerRole":
                    return new TSqlUserDefinedServerRoleReference(obj, objectType);
                case "UserDefinedType":
                    return new TSqlUserDefinedTypeReference(obj, objectType);
                case "View":
                    return new TSqlViewReference(obj, objectType);
                case "WorkloadGroup":
                    return new TSqlWorkloadGroupReference(obj, objectType);
                case "XmlIndex":
                    return new TSqlXmlIndexReference(obj, objectType);
                case "SelectiveXmlIndex":
                    return new TSqlSelectiveXmlIndexReference(obj, objectType);
                case "XmlNamespace":
                    return new TSqlXmlNamespaceReference(obj, objectType);
                case "PromotedNodePathForXQueryType":
                    return new TSqlPromotedNodePathForXQueryTypeReference(obj, objectType);
                case "PromotedNodePathForSqlType":
                    return new TSqlPromotedNodePathForSqlTypeReference(obj, objectType);
                case "XmlSchemaCollection":
                    return new TSqlXmlSchemaCollectionReference(obj, objectType);
                default:
                    throw new ArgumentException("No type mapping exists for " + objectType.Name);
            }
        }


        ///<summary>
        ///  Returns a strongly-typed wrapper for the TSqlObject instance.
        ///</summary>
        public static ISqlModelElement AdaptInstance(TSqlObject obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }

            switch (obj.ObjectType.Name)
            {
                case "Column":
                    return new TSqlColumn(obj);
                case "TableValuedFunction":
                    return new TSqlTableValuedFunction(obj);
                case "ScalarFunction":
                    return new TSqlScalarFunction(obj);
                case "ClrTableOption":
                    return new TSqlClrTableOption(obj);
                case "Aggregate":
                    return new TSqlAggregate(obj);
                case "ApplicationRole":
                    return new TSqlApplicationRole(obj);
                case "Index":
                    return new TSqlIndex(obj);
                case "Assembly":
                    return new TSqlAssembly(obj);
                case "AssemblySource":
                    return new TSqlAssemblySource(obj);
                case "AsymmetricKey":
                    return new TSqlAsymmetricKey(obj);
                case "AuditAction":
                    return new TSqlAuditAction(obj);
                case "AuditActionGroup":
                    return new TSqlAuditActionGroup(obj);
                case "AuditActionSpecification":
                    return new TSqlAuditActionSpecification(obj);
                case "BrokerPriority":
                    return new TSqlBrokerPriority(obj);
                case "BuiltInServerRole":
                    return new TSqlBuiltInServerRole(obj);
                case "DataType":
                    return new TSqlDataType(obj);
                case "Certificate":
                    return new TSqlCertificate(obj);
                case "CheckConstraint":
                    return new TSqlCheckConstraint(obj);
                case "ClrTypeMethod":
                    return new TSqlClrTypeMethod(obj);
                case "ClrTypeMethodParameter":
                    return new TSqlClrTypeMethodParameter(obj);
                case "ClrTypeProperty":
                    return new TSqlClrTypeProperty(obj);
                case "ColumnStoreIndex":
                    return new TSqlColumnStoreIndex(obj);
                case "Contract":
                    return new TSqlContract(obj);
                case "Credential":
                    return new TSqlCredential(obj);
                case "DatabaseCredential":
                    return new TSqlDatabaseCredential(obj);
                case "CryptographicProvider":
                    return new TSqlCryptographicProvider(obj);
                case "DatabaseAuditSpecification":
                    return new TSqlDatabaseAuditSpecification(obj);
                case "DatabaseDdlTrigger":
                    return new TSqlDatabaseDdlTrigger(obj);
                case "DatabaseEncryptionKey":
                    return new TSqlDatabaseEncryptionKey(obj);
                case "DatabaseEventNotification":
                    return new TSqlDatabaseEventNotification(obj);
                case "DatabaseMirroringLanguageSpecifier":
                    return new TSqlDatabaseMirroringLanguageSpecifier(obj);
                case "DatabaseOptions":
                    return new TSqlDatabaseOptions(obj);
                case "DataCompressionOption":
                    return new TSqlDataCompressionOption(obj);
                case "Default":
                    return new TSqlDefault(obj);
                case "DefaultConstraint":
                    return new TSqlDefaultConstraint(obj);
                case "DmlTrigger":
                    return new TSqlDmlTrigger(obj);
                case "Endpoint":
                    return new TSqlEndpoint(obj);
                case "ErrorMessage":
                    return new TSqlErrorMessage(obj);
                case "EventGroup":
                    return new TSqlEventGroup(obj);
                case "EventSession":
                    return new TSqlEventSession(obj);
                case "DatabaseEventSession":
                    return new TSqlDatabaseEventSession(obj);
                case "EventSessionAction":
                    return new TSqlEventSessionAction(obj);
                case "EventSessionDefinitions":
                    return new TSqlEventSessionDefinitions(obj);
                case "EventSessionSetting":
                    return new TSqlEventSessionSetting(obj);
                case "EventSessionTarget":
                    return new TSqlEventSessionTarget(obj);
                case "EventTypeSpecifier":
                    return new TSqlEventTypeSpecifier(obj);
                case "ExtendedProcedure":
                    return new TSqlExtendedProcedure(obj);
                case "ExtendedProperty":
                    return new TSqlExtendedProperty(obj);
                case "ExternalDataSource":
                    return new TSqlExternalDataSource(obj);
                case "ExternalFileFormat":
                    return new TSqlExternalFileFormat(obj);
                case "ExternalTable":
                    return new TSqlExternalTable(obj);
                case "SqlFile":
                    return new TSqlSqlFile(obj);
                case "Filegroup":
                    return new TSqlFilegroup(obj);
                case "ForeignKeyConstraint":
                    return new TSqlForeignKeyConstraint(obj);
                case "FullTextCatalog":
                    return new TSqlFullTextCatalog(obj);
                case "FullTextIndex":
                    return new TSqlFullTextIndex(obj);
                case "FullTextIndexColumnSpecifier":
                    return new TSqlFullTextIndexColumnSpecifier(obj);
                case "FullTextStopList":
                    return new TSqlFullTextStopList(obj);
                case "HttpProtocolSpecifier":
                    return new TSqlHttpProtocolSpecifier(obj);
                case "LinkedServer":
                    return new TSqlLinkedServer(obj);
                case "LinkedServerLogin":
                    return new TSqlLinkedServerLogin(obj);
                case "Login":
                    return new TSqlLogin(obj);
                case "MasterKey":
                    return new TSqlMasterKey(obj);
                case "MessageType":
                    return new TSqlMessageType(obj);
                case "PartitionFunction":
                    return new TSqlPartitionFunction(obj);
                case "PartitionScheme":
                    return new TSqlPartitionScheme(obj);
                case "PartitionValue":
                    return new TSqlPartitionValue(obj);
                case "Permission":
                    return new TSqlPermission(obj);
                case "PrimaryKeyConstraint":
                    return new TSqlPrimaryKeyConstraint(obj);
                case "Procedure":
                    return new TSqlProcedure(obj);
                case "Queue":
                    return new TSqlQueue(obj);
                case "QueueEventNotification":
                    return new TSqlQueueEventNotification(obj);
                case "RemoteServiceBinding":
                    return new TSqlRemoteServiceBinding(obj);
                case "ResourceGovernor":
                    return new TSqlResourceGovernor(obj);
                case "ResourcePool":
                    return new TSqlResourcePool(obj);
                case "Role":
                    return new TSqlRole(obj);
                case "RoleMembership":
                    return new TSqlRoleMembership(obj);
                case "Route":
                    return new TSqlRoute(obj);
                case "Rule":
                    return new TSqlRule(obj);
                case "Schema":
                    return new TSqlSchema(obj);
                case "SearchProperty":
                    return new TSqlSearchProperty(obj);
                case "SearchPropertyList":
                    return new TSqlSearchPropertyList(obj);
                case "SecurityPolicy":
                    return new TSqlSecurityPolicy(obj);
                case "SecurityPredicate":
                    return new TSqlSecurityPredicate(obj);
                case "Sequence":
                    return new TSqlSequence(obj);
                case "ServerAudit":
                    return new TSqlServerAudit(obj);
                case "ServerAuditSpecification":
                    return new TSqlServerAuditSpecification(obj);
                case "ServerDdlTrigger":
                    return new TSqlServerDdlTrigger(obj);
                case "ServerEventNotification":
                    return new TSqlServerEventNotification(obj);
                case "ServerOptions":
                    return new TSqlServerOptions(obj);
                case "ServerRoleMembership":
                    return new TSqlServerRoleMembership(obj);
                case "Service":
                    return new TSqlService(obj);
                case "ServiceBrokerLanguageSpecifier":
                    return new TSqlServiceBrokerLanguageSpecifier(obj);
                case "Signature":
                    return new TSqlSignature(obj);
                case "SignatureEncryptionMechanism":
                    return new TSqlSignatureEncryptionMechanism(obj);
                case "SoapLanguageSpecifier":
                    return new TSqlSoapLanguageSpecifier(obj);
                case "SoapMethodSpecification":
                    return new TSqlSoapMethodSpecification(obj);
                case "SpatialIndex":
                    return new TSqlSpatialIndex(obj);
                case "Statistics":
                    return new TSqlStatistics(obj);
                case "Parameter":
                    return new TSqlParameter(obj);
                case "SymmetricKey":
                    return new TSqlSymmetricKey(obj);
                case "SymmetricKeyPassword":
                    return new TSqlSymmetricKeyPassword(obj);
                case "Synonym":
                    return new TSqlSynonym(obj);
                case "Table":
                    return new TSqlTable(obj);
                case "FileTable":
                    return new TSqlFileTable(obj);
                case "TableType":
                    return new TSqlTableType(obj);
                case "TableTypeCheckConstraint":
                    return new TSqlTableTypeCheckConstraint(obj);
                case "TableTypeColumn":
                    return new TSqlTableTypeColumn(obj);
                case "TableTypeDefaultConstraint":
                    return new TSqlTableTypeDefaultConstraint(obj);
                case "TableTypeIndex":
                    return new TSqlTableTypeIndex(obj);
                case "TableTypePrimaryKeyConstraint":
                    return new TSqlTableTypePrimaryKeyConstraint(obj);
                case "TableTypeUniqueConstraint":
                    return new TSqlTableTypeUniqueConstraint(obj);
                case "TcpProtocolSpecifier":
                    return new TSqlTcpProtocolSpecifier(obj);
                case "UniqueConstraint":
                    return new TSqlUniqueConstraint(obj);
                case "User":
                    return new TSqlUser(obj);
                case "UserDefinedServerRole":
                    return new TSqlUserDefinedServerRole(obj);
                case "UserDefinedType":
                    return new TSqlUserDefinedType(obj);
                case "View":
                    return new TSqlView(obj);
                case "WorkloadGroup":
                    return new TSqlWorkloadGroup(obj);
                case "XmlIndex":
                    return new TSqlXmlIndex(obj);
                case "SelectiveXmlIndex":
                    return new TSqlSelectiveXmlIndex(obj);
                case "XmlNamespace":
                    return new TSqlXmlNamespace(obj);
                case "PromotedNodePathForXQueryType":
                    return new TSqlPromotedNodePathForXQueryType(obj);
                case "PromotedNodePathForSqlType":
                    return new TSqlPromotedNodePathForSqlType(obj);
                case "XmlSchemaCollection":
                    return new TSqlXmlSchemaCollection(obj);
                default:
                    throw new ArgumentException("No type mapping exists for " + obj.ObjectType.Name);
            }
        }
    }

    ///
    /// Adapter class for instances of <see cref="T:TSqlObject"/> with an <see cref="T:TSqlObject M:ObjectType"> equal to <see cref="T:Column"/>
    ///
    /// <see href="http://msdn.microsoft.com/en-us/library/microsoft.sqlserver.dac.model.column.aspx">Column</see>
    ///
    public partial class TSqlColumnReference : TSqlColumn, ISqlModelElementReference
    {
        private ModelRelationshipInstance relationshipInstance;
        private ModelTypeClass predefinedTypeClass;

        public TSqlColumnReference(ModelRelationshipInstance relationshipReference, ModelTypeClass typeClass)
        {
            relationshipInstance = relationshipReference;
            if (relationshipInstance.Object != null && relationshipInstance.Object.ObjectType != typeClass)
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture,
                        ModelMessages.InvalidObjectType, relationshipInstance.Object.ObjectType.Name, typeClass.Name),
                    "typeClass");
            }

            predefinedTypeClass = typeClass;
        }

        public override ObjectIdentifier Name
        {
            get { return relationshipInstance.ObjectName; }
        }

        public override ModelTypeClass ObjectType
        {
            get
            {
                if (IsResolved())
                {
                    return base.ObjectType;
                }
                else
                {
                    // when object is unresolved default to the predefined ModelTypClass
                    return predefinedTypeClass;
                }
            }
        }

        public bool IsResolved()
        {
            return relationshipInstance.Object != null;
        }

        public override TSqlObject Element
        {
            get
            {
                // Verify the Element is resolved.
                if (!IsResolved())
                {
                    throw new UnresolvedElementException(
                        string.Format(CultureInfo.CurrentUICulture,
                            ModelMessages.UnresolvedObject,
                            relationshipInstance.ObjectName));
                }

                return relationshipInstance.Object;
            }
        }

        public T GetMetadataProperty<T>(ModelPropertyClass property)
        {
            return relationshipInstance.GetProperty<T>(property);
        }
    }

    ///
    /// Adapter class for instances of <see cref="T:TSqlObject"/> with an <see cref="T:TSqlObject M:ObjectType"> equal to <see cref="T:Column"/>
    ///
    /// <see href="http://msdn.microsoft.com/en-us/library/microsoft.sqlserver.dac.model.column.aspx">Column</see>
    ///
    public partial class TSqlColumn : TSqlModelElement, ISqlSecurable
    {
        private static ModelTypeClass typeClass = Column.TypeClass;

        /// <summary>
        ///	Create a strongly-typed class TSqlColumn to adapt instances of <see cref="T:Column"/>
        /// </summary>
        public TSqlColumn(TSqlObject obj) : base(obj, Column.TypeClass)
        {
        }


        /// <summary>
        ///	Create a strongly-typed class TSqlColumn to adapt instances of <see cref="T:Column"/>
        /// </summary>
        protected TSqlColumn()
        {
        }

        public static ModelTypeClass TypeClass
        {
            get { return typeClass; }
        }

        ///
        /// Property wrapper for <see cref="M:Column.Collation"/>
        /// <see href="http://msdn.microsoft.com/en-us/library/microsoft.sqlserver.dac.model.column.collation.aspx">Column.Collation</see>
        ///
        public String Collation
        {
            get { return Element.GetProperty<String>(Column.Collation); }
        }


        ///
        /// Property wrapper for <see cref="M:Column.EncryptionAlgorithmName"/>
        /// <see href="http://msdn.microsoft.com/en-us/library/microsoft.sqlserver.dac.model.column.encryptionalgorithmname.aspx">Column.EncryptionAlgorithmName</see>
        ///
        public String EncryptionAlgorithmName
        {
            get { return Element.GetProperty<String>(Column.EncryptionAlgorithmName); }
        }


        ///
        /// Property wrapper for <see cref="M:Column.EncryptionType"/>
        /// <see href="http://msdn.microsoft.com/en-us/library/microsoft.sqlserver.dac.model.column.encryptiontype.aspx">Column.EncryptionType</see>
        ///
        public Int32 EncryptionType
        {
            get { return Element.GetProperty<Int32>(Column.EncryptionType); }
        }


        ///
        /// Property wrapper for <see cref="M:Column.Expression"/>
        /// <see href="http://msdn.microsoft.com/en-us/library/microsoft.sqlserver.dac.model.column.expression.aspx">Column.Expression</see>
        ///
        public String Expression
        {
            get { return (String) Element.GetProperty(Column.Expression); }
        }


        ///
        /// Property wrapper for <see cref="M:Column.GeneratedAlwaysType"/>
        /// <see href="http://msdn.microsoft.com/en-us/library/microsoft.sqlserver.dac.model.column.generatedalwaystype.aspx">Column.GeneratedAlwaysType</see>
        ///
        public ColumnGeneratedAlwaysType GeneratedAlwaysType
        {
            get { return Element.GetProperty<ColumnGeneratedAlwaysType>(Column.GeneratedAlwaysType); }
        }


        ///
        /// Property wrapper for <see cref="M:Column.GraphType"/>
        /// <see href="http://msdn.microsoft.com/en-us/library/microsoft.sqlserver.dac.model.column.graphtype.aspx">Column.GraphType</see>
        ///
        public Int32 GraphType
        {
            get { return Element.GetProperty<Int32>(Column.GraphType); }
        }


        ///
        /// Property wrapper for <see cref="M:Column.IdentityIncrement"/>
        /// <see href="http://msdn.microsoft.com/en-us/library/microsoft.sqlserver.dac.model.column.identityincrement.aspx">Column.IdentityIncrement</see>
        ///
        public String IdentityIncrement
        {
            get { return Element.GetProperty<String>(Column.IdentityIncrement); }
        }


        ///
        /// Property wrapper for <see cref="M:Column.IdentitySeed"/>
        /// <see href="http://msdn.microsoft.com/en-us/library/microsoft.sqlserver.dac.model.column.identityseed.aspx">Column.IdentitySeed</see>
        ///
        public String IdentitySeed
        {
            get { return Element.GetProperty<String>(Column.IdentitySeed); }
        }


        ///
        /// Property wrapper for <see cref="M:Column.IsFileStream"/>
        /// <see href="http://msdn.microsoft.com/en-us/library/microsoft.sqlserver.dac.model.column.isfilestream.aspx">Column.IsFileStream</see>
        ///
        public Boolean IsFileStream
        {
            get { return Element.GetProperty<Boolean>(Column.IsFileStream); }
        }


        ///
        /// Property wrapper for <see cref="M:Column.IsHidden"/>
        /// <see href="http://msdn.microsoft.com/en-us/library/microsoft.sqlserver.dac.model.column.ishidden.aspx">Column.IsHidden</see>
        ///
        public Boolean IsHidden
        {
            get { return Element.GetProperty<Boolean>(Column.IsHidden); }
        }


        ///
        /// Property wrapper for <see cref="M:Column.IsIdentity"/>
        /// <see href="http://msdn.microsoft.com/en-us/library/microsoft.sqlserver.dac.model.column.isidentity.aspx">Column.IsIdentity</see>
        ///
        public Boolean IsIdentity
        {
            get { return Element.GetProperty<Boolean>(Column.IsIdentity); }
        }


        ///
        /// Property wrapper for <see cref="M:Column.IsIdentityNotForReplication"/>
        /// <see href="http://msdn.microsoft.com/en-us/library/microsoft.sqlserver.dac.model.column.isidentitynotforreplication.aspx">Column.IsIdentityNotForReplication</see>
        ///
        public Boolean IsIdentityNotForReplication
        {
            get { return Element.GetProperty<Boolean>(Column.IsIdentityNotForReplication); }
        }


        ///
        /// Property wrapper for <see cref="M:Column.IsMax"/>
        /// <see href="http://msdn.microsoft.com/en-us/library/microsoft.sqlserver.dac.model.column.ismax.aspx">Column.IsMax</see>
        ///
        public Boolean IsMax
        {
            get { return Element.GetProperty<Boolean>(Column.IsMax); }
        }


        ///
        /// Property wrapper for <see cref="M:Column.IsPseudoColumn"/>
        /// <see href="http://msdn.microsoft.com/en-us/library/microsoft.sqlserver.dac.model.column.ispseudocolumn.aspx">Column.IsPseudoColumn</see>
        ///
        public Boolean IsPseudoColumn
        {
            get { return Element.GetProperty<Boolean>(Column.IsPseudoColumn); }
        }


        ///
        /// Property wrapper for <see cref="M:Column.IsRowGuidCol"/>
        /// <see href="http://msdn.microsoft.com/en-us/library/microsoft.sqlserver.dac.model.column.isrowguidcol.aspx">Column.IsRowGuidCol</see>
        ///
        public Boolean IsRowGuidCol
        {
            get { return Element.GetProperty<Boolean>(Column.IsRowGuidCol); }
        }


        ///
        /// Property wrapper for <see cref="M:Column.Length"/>
        /// <see href="http://msdn.microsoft.com/en-us/library/microsoft.sqlserver.dac.model.column.length.aspx">Column.Length</see>
        ///
        public Int32 Length
        {
            get { return Element.GetProperty<Int32>(Column.Length); }
        }


        ///
        /// Property wrapper for <see cref="M:Column.MaskingFunction"/>
        /// <see href="http://msdn.microsoft.com/en-us/library/microsoft.sqlserver.dac.model.column.maskingfunction.aspx">Column.MaskingFunction</see>
        ///
        public String MaskingFunction
        {
            get { return Element.GetProperty<String>(Column.MaskingFunction); }
        }


        ///
        /// Property wrapper for <see cref="M:Column.Nullable"/>
        /// <see href="http://msdn.microsoft.com/en-us/library/microsoft.sqlserver.dac.model.column.nullable.aspx">Column.Nullable</see>
        ///
        public Boolean Nullable
        {
            get { return Element.GetProperty<Boolean>(Column.Nullable); }
        }


        ///
        /// Property wrapper for <see cref="M:Column.Persisted"/>
        /// <see href="http://msdn.microsoft.com/en-us/library/microsoft.sqlserver.dac.model.column.persisted.aspx">Column.Persisted</see>
        ///
        public Boolean Persisted
        {
            get { return Element.GetProperty<Boolean>(Column.Persisted); }
        }


        ///
        /// Property wrapper for <see cref="M:Column.PersistedNullable"/>
        /// <see href="http://msdn.microsoft.com/en-us/library/microsoft.sqlserver.dac.model.column.persistednullable.aspx">Column.PersistedNullable</see>
        ///
        public Boolean? PersistedNullable
        {
            get { return Element.GetProperty<Boolean?>(Column.PersistedNullable); }
        }


        ///
        /// Property wrapper for <see cref="M:Column.Precision"/>
        /// <see href="http://msdn.microsoft.com/en-us/library/microsoft.sqlserver.dac.model.column.precision.aspx">Column.Precision</see>
        ///
        public Int32 Precision
        {
            get { return Element.GetProperty<Int32>(Column.Precision); }
        }


        ///
        /// Property wrapper for <see cref="M:Column.Scale"/>
        /// <see href="http://msdn.microsoft.com/en-us/library/microsoft.sqlserver.dac.model.column.scale.aspx">Column.Scale</see>
        ///
        public Int32 Scale
        {
            get { return Element.GetProperty<Int32>(Column.Scale); }
        }


        ///
        /// Property wrapper for <see cref="M:Column.Sparse"/>
        /// <see href="http://msdn.microsoft.com/en-us/library/microsoft.sqlserver.dac.model.column.sparse.aspx">Column.Sparse</see>
        ///
        public Boolean Sparse
        {
            get { return Element.GetProperty<Boolean>(Column.Sparse); }
        }


        ///
        /// Property wrapper for <see cref="M:Column.XmlStyle"/>
        /// <see href="http://msdn.microsoft.com/en-us/library/microsoft.sqlserver.dac.model.column.xmlstyle.aspx">Column.XmlStyle</see>
        ///
        public XmlStyle XmlStyle
        {
            get { return Element.GetProperty<XmlStyle>(Column.XmlStyle); }
        }


        ///
        /// Metadata property wrapper for <see cref="M:Column.ColumnType"/>
        ///
        public ColumnType ColumnType
        {
            get { return Element.GetMetadata<ColumnType>(Column.ColumnType); }
        }
    }
}

