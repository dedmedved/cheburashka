CREATE TABLE dbo.EnforcePrimaryKeyRule_Table_With_PK_Added (a int not NULL
) ;
go
ALTER TABLE dbo.EnforcePrimaryKeyRule_Table_With_PK_Added
ADD CONSTRAINT PK_EnforcePrimaryKeyRule_Table_With_PK_Added PRIMARY KEY (a)
go
