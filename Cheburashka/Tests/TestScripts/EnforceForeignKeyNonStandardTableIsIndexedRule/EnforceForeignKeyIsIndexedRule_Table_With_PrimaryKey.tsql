CREATE TABLE dbo.EnforceForeignKeyIsIndexedRule_Table_With_PrimaryKey (a INT
, CONSTRAINT PKEnforceForeignKeyIsIndexedRule_Table_With_PrimaryKey primary KEY (a)
) ;
GO
CREATE TABLE dbo.EnforceForeignKeyIsIndexedRule_Table_With_PrimaryKey_2 (b INT
, CONSTRAINT PKEnforceForeignKeyIsIndexedRule_Table_With_PrimaryKey_2 primary KEY (b)
) ;
GO
create table EnforceForeignKeyIsIndexedRule_Table_With_PrimaryKey_Child (c INT NOT NULL, d int NOT null
,														   ValidFrom					 DATETIME2(7) GENERATED ALWAYS AS ROW START CONSTRAINT df_service_draftdata_derivative_discontinuation_ValidFrom DEFAULT SYSUTCDATETIME() NOT NULL 
,														   ValidTo						 DATETIME2(7) GENERATED ALWAYS AS ROW END CONSTRAINT df_service_draftdata_derivative_discontinuation_ValidTo DEFAULT CAST('9999-12-31 23:59:59.9999999' AS DATETIME2) NOT NULL 
,															PERIOD FOR SYSTEM_TIME (ValidFrom, ValidTo)
, constraint FKEnforceForeignKeyIsIndexedRule_Table_With_PrimaryKey1 foreign key (c) references EnforceForeignKeyIsIndexedRule_Table_With_PrimaryKey (a)
, constraint FKEnforceForeignKeyIsIndexedRule_Table_With_PrimaryKey2 foreign key (d) references EnforceForeignKeyIsIndexedRule_Table_With_PrimaryKey_2 (b)
)
GO
ALTER TABLE  EnforceForeignKeyIsIndexedRule_Table_With_PrimaryKey_Child
ADD CONSTRAINT pk_EnforceForeignKeyIsIndexedRule_Table_With_PrimaryKey_Child  PRIMARY KEY (c)
GO 