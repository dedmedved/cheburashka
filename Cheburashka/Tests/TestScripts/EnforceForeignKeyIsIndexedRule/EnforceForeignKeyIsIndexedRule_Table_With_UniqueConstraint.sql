﻿CREATE TABLE dbo.EnforceForeignKeyIsIndexedRule_Table_With_UniqueConstraint (a INT
, CONSTRAINT PK_EnforceForeignKeyIsIndexedRule_Table_With_UniqueConstraint primary KEY (a)
) ;
GO
create table EnforceForeignKeyIsIndexedRule_Table_With_UniqueConstraint_Child (a int
, constraint FK_EnforceForeignKeyIsIndexedRule_Table_With_UniqueConstraint foreign key (a) references EnforceForeignKeyIsIndexedRule_Table_With_UniqueConstraint (a)
)
GO
ALTER TABLE  EnforceForeignKeyIsIndexedRule_Table_With_UniqueConstraint_Child
ADD CONSTRAINT un_EnforceForeignKeyIsIndexedRule_Table_With_UniqueConstraint  unique (a)
GO 