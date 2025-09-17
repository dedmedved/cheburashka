# Microsoft SQL Server Data-Tier Application Framework (DacFx) Nuget Package

## Overview

The Microsoft SQL Server Data-Tier Application Framework (DacFx) is a component which provides application lifecycle services for database development and management for Microsoft SQL Server and Microsoft Azure SQL Databases.
      DacFx supports various database deployment and management scenarios for SQL Server and Microsoft Azure SQL Databases including extracting / exporting a live database to a DAC package, deploying a DAC package to a new or existing database, 
      and migrating from on-premises to Microsoft Azure. 
	  
      This functionality is exposed via the DacFx API. DacFx can target SQL Server 2008 and newer, as well as Microsoft Azure SQL.
      
      This nuget package is a lightweight version of DacFx. If you would like to use the command-line utility SqlPackage.exe for creating and deploying .dacpac and .bacpac packages, please download SqlPackage.exe for Windows, macOS, or Linux from http://aka.ms/sqlpackage.

## Dependencies

The package Microsoft.SqlServer.DacFx depends on the new ADO.Net Sql client driver in the Microsoft.Data.SqlClient nuget package.

## Support

Open issues at [DacFx github](<https://github.com/microsoft/DacFx>)