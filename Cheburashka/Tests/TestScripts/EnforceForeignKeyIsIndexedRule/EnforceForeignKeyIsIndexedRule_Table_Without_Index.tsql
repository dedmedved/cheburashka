CREATE TABLE dbo.EnforceForeignKeyIsIndexedRule_Table_Without_Index (a INT
, CONSTRAINT PK_EnforceForeignKeyRule_Table_With_FK primary KEY (a)
) ;
GO
create table EnforceForeignKeyIsIndexedRule_Table_Without_Index_Child (a int
, constraint FK_EnforceForeignKeyIsIndexedRule_Table_Without_Index foreign key (a) references EnforceForeignKeyIsIndexedRule_Table_Without_Index (a)
)
go