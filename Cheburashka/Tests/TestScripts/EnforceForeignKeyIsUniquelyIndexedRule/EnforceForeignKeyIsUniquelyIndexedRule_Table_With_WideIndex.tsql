CREATE TABLE dbo.EnforceForeignKeyIsIndexedRule_Table_With_WideIndex (a INT
, CONSTRAINT PK_EnforceForeignKeyIsIndexedRule_Table_With_WideIndex primary KEY (a)
) ;
GO
create table EnforceForeignKeyIsIndexedRule_Table_With_WideIndex_Child (a INT
, b INT 
, constraint FK_EnforceForeignKeyIsIndexedRule_Table_With_WideIndex foreign key (a) references EnforceForeignKeyIsIndexedRule_Table_With_WideIndex (a)
)
GO
CREATE UNIQUE INDEX ix_EnforceForeignKeyIsIndexedRule_Table_With_WideIndex on EnforceForeignKeyIsIndexedRule_Table_With_WideIndex_Child(a,b)
GO 