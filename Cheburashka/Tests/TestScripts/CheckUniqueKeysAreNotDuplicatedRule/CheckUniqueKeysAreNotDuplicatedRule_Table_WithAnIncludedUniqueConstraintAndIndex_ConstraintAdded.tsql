CREATE TABLE dbo.CheckUniqueKeysAreNotDuplicatedRule_Table_WithAnIncludedUniqueConstraintAndIndex_ConstraintAdded 
(       a int not null
,       b int     null
,       c int     null
,       d int     NULL
) ;
go

create unique index ix_CheckUniqueKeysAreNotDuplicatedRule_Table_WithAnIncludedUniqueConstraintAndIndex_ConstraintAdded_a on dbo.CheckUniqueKeysAreNotDuplicatedRule_Table_WithAnIncludedUniqueConstraintAndIndex_ConstraintAdded (a)
go

ALTER TABLE  dbo.CheckUniqueKeysAreNotDuplicatedRule_Table_WithAnIncludedUniqueConstraintAndIndex_ConstraintAdded ADD CONSTRAINT  UN_CheckUniqueKeysAreNotDuplicatedRule_Table_WithAnIncludedUniqueConstraintAndIndex_ConstraintAdded_b_a UNIQUE (b,a) 
GO
