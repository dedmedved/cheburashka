CREATE TABLE dbo.CheckUniqueKeysAreNotDuplicatedRule_Table_WithAnIncludedUniqueConstraintAndIndex 
(       A int not null
,       B int     null
,       C int     null
,       D int     NULL
,       CONSTRAINT  UN_CheckUniqueKeysAreNotDuplicatedRule_Table_WithAnIncludedUniqueConstraintAndIndex_b_a UNIQUE (b,a) 
) ;
go

create unique index ix_CheckUniqueKeysAreNotDuplicatedRule_Table_WithAnIncludedUniqueConstraintAndIndex_a on dbo.CheckUniqueKeysAreNotDuplicatedRule_Table_WithAnIncludedUniqueConstraintAndIndex (a)
go
