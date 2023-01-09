CREATE TABLE dbo.CheckUniqueKeysAreNotDuplicatedRule_Table_WithAnIncludedUniqueConstraintAndIndex 
(       a int not null
,       b int     null
,       c int     null
,       d int     NULL
,       CONSTRAINT  UN_CheckUniqueKeysAreNotDuplicatedRule_Table_WithAnIncludedUniqueConstraintAndIndex_b_a UNIQUE (b,a) 
) ;
go

create unique index ix_CheckUniqueKeysAreNotDuplicatedRule_Table_WithAnIncludedUniqueConstraintAndIndex_a on dbo.CheckUniqueKeysAreNotDuplicatedRule_Table_WithAnIncludedUniqueConstraintAndIndex (a)
go
