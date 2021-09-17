CREATE TABLE dbo.EnforceForeignKeyIsIndexedRule_Table_With_PrimaryKey (a INT
, CONSTRAINT PKEnforceForeignKeyIsIndexedRule_Table_With_PrimaryKey primary KEY (a)
) ;
GO
create table EnforceForeignKeyIsIndexedRule_Table_With_PrimaryKey_Child (a INT NOT null
, constraint FKEnforceForeignKeyIsIndexedRule_Table_With_PrimaryKey foreign key (a) references EnforceForeignKeyIsIndexedRule_Table_With_PrimaryKey (a)
)
GO
ALTER TABLE  EnforceForeignKeyIsIndexedRule_Table_With_PrimaryKey_Child
ADD CONSTRAINT pk_EnforceForeignKeyIsIndexedRule_Table_With_PrimaryKey  PRIMARY KEY (a)
GO 