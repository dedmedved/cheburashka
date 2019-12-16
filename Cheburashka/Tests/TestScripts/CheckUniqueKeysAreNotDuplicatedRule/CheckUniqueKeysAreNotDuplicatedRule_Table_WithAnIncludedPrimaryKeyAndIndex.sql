CREATE TABLE dbo.CheckUniqueKeysAreNotDuplicatedRule_Table_WithAnIncludedPrimaryKeyAndIndex 
(       a int not null
,       b int NOT NULL
,       c int     null
,       d int     NULL
,       CONSTRAINT  PK_CheckUniqueKeysAreNotDuplicatedRule_Table_WithAnIncludedPrimaryKeyAndIndex_b_a PRIMARY KEY  (b,a) 
) ;
go

create unique index ix_CheckUniqueKeysAreNotDuplicatedRule_Table_WithAnIncludedPrimaryKeyAndIndex_a on dbo.CheckUniqueKeysAreNotDuplicatedRule_Table_WithAnIncludedPrimaryKeyAndIndex (a)
go
