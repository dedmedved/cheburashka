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
    using System.Collections.Generic;
    using System.Globalization;
    using Microsoft.SqlServer.Dac.Model;

    public static class UtilityMethods
    {

        /// <summary>
        /// Returns the set of possible <see cref="ModelTypeClass"/> for the <see cref="System.Type"/>.
        /// </summary>
        /// <param name="type">Class or Interface to find mapped <see cref="ModelTypeClass"/></param>
        /// <returns>The <see cref="ModelTypeClass"/> that map to the <paramref name="type"/> <see cref="ModelTypeClass"/></returns>
        /// <remarks>
        /// if <paramref name="type"/> is an interface the the returned <see cref="ModelTypeClass"/> all implement the type. If the <paramref name="type"/> is class type on a single <see cref="ModelTypeClass"/> will be returned.
        /// </remarks>
        public static IEnumerable<ModelTypeClass> GetModelElementTypes(Type type)
        {
            if (type.Namespace != typeof(TSqlTable).Namespace)
            {
                throw new ArgumentException(
                    string.Format(CultureInfo.CurrentCulture, "The type {0}.{1} must be in the namespace {2}",
                        type.Namespace, type.Name, typeof(TSqlTable).Namespace), "type");
            }

            switch (type.Name)
            {
                case "ISql90TSqlAggregate":
                case "ISql100TSqlAggregate":
                case "ISql110TSqlAggregate":
                case "ISql120TSqlAggregate":
                case "ISqlAzureV12TSqlAggregate":
                case "TSqlAggregate":
                    yield return TSqlAggregate.TypeClass;
                    break;
                case "ISql90TSqlApplicationRole":
                case "ISql100TSqlApplicationRole":
                case "ISql110TSqlApplicationRole":
                case "ISql120TSqlApplicationRole":
                case "ISqlAzureV12TSqlApplicationRole":
                case "TSqlApplicationRole":
                    yield return TSqlApplicationRole.TypeClass;
                    break;
                case "ISql90TSqlAssembly":
                case "ISql100TSqlAssembly":
                case "ISqlAzureTSqlAssembly":
                case "ISql110TSqlAssembly":
                case "ISql120TSqlAssembly":
                case "ISqlAzureV12TSqlAssembly":
                case "TSqlAssembly":
                    yield return TSqlAssembly.TypeClass;
                    break;
                case "ISql90TSqlAssemblySource":
                case "ISql100TSqlAssemblySource":
                case "ISqlAzureTSqlAssemblySource":
                case "ISql110TSqlAssemblySource":
                case "ISql120TSqlAssemblySource":
                case "ISqlAzureV12TSqlAssemblySource":
                case "TSqlAssemblySource":
                    yield return TSqlAssemblySource.TypeClass;
                    break;
                case "ISql90TSqlAsymmetricKey":
                case "ISql100TSqlAsymmetricKey":
                case "ISql110TSqlAsymmetricKey":
                case "ISql120TSqlAsymmetricKey":
                case "TSqlAsymmetricKey":
                    yield return TSqlAsymmetricKey.TypeClass;
                    break;
                case "ISql100TSqlAuditAction":
                case "ISql110TSqlAuditAction":
                case "ISql120TSqlAuditAction":
                case "TSqlAuditAction":
                    yield return TSqlAuditAction.TypeClass;
                    break;
                case "ISql100TSqlAuditActionGroup":
                case "ISql110TSqlAuditActionGroup":
                case "ISql120TSqlAuditActionGroup":
                case "TSqlAuditActionGroup":
                    yield return TSqlAuditActionGroup.TypeClass;
                    break;
                case "ISql100TSqlAuditActionSpecification":
                case "ISql110TSqlAuditActionSpecification":
                case "ISql120TSqlAuditActionSpecification":
                case "TSqlAuditActionSpecification":
                    yield return TSqlAuditActionSpecification.TypeClass;
                    break;
                case "ISql100TSqlBrokerPriority":
                case "ISql110TSqlBrokerPriority":
                case "ISql120TSqlBrokerPriority":
                case "TSqlBrokerPriority":
                    yield return TSqlBrokerPriority.TypeClass;
                    break;
                case "ISql90TSqlBuiltInServerRole":
                case "ISql100TSqlBuiltInServerRole":
                case "ISqlAzureTSqlBuiltInServerRole":
                case "ISql110TSqlBuiltInServerRole":
                case "ISql120TSqlBuiltInServerRole":
                case "ISqlAzureV12TSqlBuiltInServerRole":
                case "TSqlBuiltInServerRole":
                    yield return TSqlBuiltInServerRole.TypeClass;
                    break;
                case "ISql90TSqlCertificate":
                case "ISql100TSqlCertificate":
                case "ISql110TSqlCertificate":
                case "ISql120TSqlCertificate":
                case "ISqlAzureV12TSqlCertificate":
                case "TSqlCertificate":
                    yield return TSqlCertificate.TypeClass;
                    break;
                case "ISql90TSqlCheckConstraint":
                case "ISql100TSqlCheckConstraint":
                case "ISqlAzureTSqlCheckConstraint":
                case "ISql110TSqlCheckConstraint":
                case "ISql120TSqlCheckConstraint":
                case "ISqlAzureV12TSqlCheckConstraint":
                case "TSqlCheckConstraint":
                    yield return TSqlCheckConstraint.TypeClass;
                    break;
                case "ISql90TSqlClrTableOption":
                case "ISql100TSqlClrTableOption":
                case "ISql110TSqlClrTableOption":
                case "ISql120TSqlClrTableOption":
                case "ISqlAzureV12TSqlClrTableOption":
                case "TSqlClrTableOption":
                    yield return TSqlClrTableOption.TypeClass;
                    break;
                case "ISql90TSqlClrTypeMethod":
                case "ISql100TSqlClrTypeMethod":
                case "ISqlAzureTSqlClrTypeMethod":
                case "ISql110TSqlClrTypeMethod":
                case "ISql120TSqlClrTypeMethod":
                case "ISqlAzureV12TSqlClrTypeMethod":
                case "TSqlClrTypeMethod":
                    yield return TSqlClrTypeMethod.TypeClass;
                    break;
                case "ISql90TSqlClrTypeMethodParameter":
                case "ISql100TSqlClrTypeMethodParameter":
                case "ISqlAzureTSqlClrTypeMethodParameter":
                case "ISql110TSqlClrTypeMethodParameter":
                case "ISql120TSqlClrTypeMethodParameter":
                case "ISqlAzureV12TSqlClrTypeMethodParameter":
                case "TSqlClrTypeMethodParameter":
                    yield return TSqlClrTypeMethodParameter.TypeClass;
                    break;
                case "ISql90TSqlClrTypeProperty":
                case "ISql100TSqlClrTypeProperty":
                case "ISqlAzureTSqlClrTypeProperty":
                case "ISql110TSqlClrTypeProperty":
                case "ISql120TSqlClrTypeProperty":
                case "ISqlAzureV12TSqlClrTypeProperty":
                case "TSqlClrTypeProperty":
                    yield return TSqlClrTypeProperty.TypeClass;
                    break;
                case "ISql90TSqlColumn":
                case "ISql100TSqlColumn":
                case "ISqlAzureTSqlColumn":
                case "ISql110TSqlColumn":
                case "ISql120TSqlColumn":
                case "ISqlAzureV12TSqlColumn":
                case "TSqlColumn":
                    yield return TSqlColumn.TypeClass;
                    break;
                case "ISql110TSqlColumnStoreIndex":
                case "ISql120TSqlColumnStoreIndex":
                case "ISqlAzureV12TSqlColumnStoreIndex":
                case "TSqlColumnStoreIndex":
                    yield return TSqlColumnStoreIndex.TypeClass;
                    break;
                case "ISql90TSqlContract":
                case "ISql100TSqlContract":
                case "ISql110TSqlContract":
                case "ISql120TSqlContract":
                case "TSqlContract":
                    yield return TSqlContract.TypeClass;
                    break;
                case "ISql90TSqlCredential":
                case "ISql100TSqlCredential":
                case "ISql110TSqlCredential":
                case "ISql120TSqlCredential":
                case "ISqlAzureV12TSqlCredential":
                case "TSqlCredential":
                    yield return TSqlCredential.TypeClass;
                    break;
                case "ISql100TSqlCryptographicProvider":
                case "ISql110TSqlCryptographicProvider":
                case "ISql120TSqlCryptographicProvider":
                case "TSqlCryptographicProvider":
                    yield return TSqlCryptographicProvider.TypeClass;
                    break;
                case "ISql100TSqlDatabaseAuditSpecification":
                case "ISql110TSqlDatabaseAuditSpecification":
                case "ISql120TSqlDatabaseAuditSpecification":
                case "TSqlDatabaseAuditSpecification":
                    yield return TSqlDatabaseAuditSpecification.TypeClass;
                    break;
            }
        }
    }
}