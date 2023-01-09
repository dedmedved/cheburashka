CREATE TABLE dbo.CheckUniqueKeysAreNotDuplicatedRule_Table_WithAnIncludedPrimaryKeyAndIndex 
(       A int not null
,       B int NOT NULL
,       C int     null
,       D int     NULL
,       CONSTRAINT  PK_CheckUniqueKeysAreNotDuplicatedRule_Table_WithAnIncludedPrimaryKeyAndIndex_b_a PRIMARY KEY  (b,a) 
) ;
go

create unique index ix_CheckUniqueKeysAreNotDuplicatedRule_Table_WithAnIncludedPrimaryKeyAndIndex_a on dbo.CheckUniqueKeysAreNotDuplicatedRule_Table_WithAnIncludedPrimaryKeyAndIndex (a)
go
