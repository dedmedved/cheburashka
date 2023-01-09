CREATE TABLE dbo.CheckMultipleForeignKeysFromOneTablesRule_Table_With_FK (a INT
, CONSTRAINT PK_CheckMultipleForeignKeysFromOneTablesRule_Table_With_FK primary KEY (a)
) ;
GO
create table CheckMultipleForeignKeysFromOneTablesRule_Table_With_FK_Child (a int
, constraint FK_CheckMultipleForeignKeysFromOneTablesRule_Table_With_FK foreign key (a) references CheckMultipleForeignKeysFromOneTablesRule_Table_With_FK (a)
)
go