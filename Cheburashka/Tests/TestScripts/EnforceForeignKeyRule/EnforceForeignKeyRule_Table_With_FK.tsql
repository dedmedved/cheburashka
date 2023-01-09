CREATE TABLE dbo.EnforceForeignKeyRule_Table_With_FK (a INT
, CONSTRAINT PK_EnforceForeignKeyRule_Table_With_FK primary KEY (a)
) ;
GO
create table EnforceForeignKeyRule_Table_With_FK_Child (a int
, constraint FK_EnforceForeignKeyRule_Table_With_FK foreign key (a) references EnforceForeignKeyRule_Table_With_FK (a)
)
go