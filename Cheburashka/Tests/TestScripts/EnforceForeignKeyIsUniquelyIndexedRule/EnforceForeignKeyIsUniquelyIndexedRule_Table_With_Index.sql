CREATE TABLE dbo.EnforceForeignKeyIsIndexedRule_Table_With_Index (a INT
, CONSTRAINT PK_EnforceForeignKeyIsIndexedRule_Table_With_Index primary KEY (a)
) ;
GO
create table EnforceForeignKeyIsIndexedRule_Table_With_Index_Child (a int
, constraint FK_EnforceForeignKeyIsIndexedRule_Table_With_Index foreign key (a) references EnforceForeignKeyIsIndexedRule_Table_With_Index (a)
)
GO
CREATE UNIQUE INDEX ix_EnforceForeignKeyIsIndexedRule_Table_With_Index on EnforceForeignKeyIsIndexedRule_Table_With_Index_Child(a)
GO 