CREATE TABLE dbo.CheckUniqueKeysAreNotDuplicatedRule_Table_WithAnIncludedUniqueConstraintAndIndex_ConstraintAdded 
(       A int not null
,       B int     null
,       C int     null
,       D int     NULL
) ;
go

create unique index ix_CheckUniqueKeysAreNotDuplicatedRule_Table_WithAnIncludedUniqueConstraintAndIndex_ConstraintAdded_a on dbo.CheckUniqueKeysAreNotDuplicatedRule_Table_WithAnIncludedUniqueConstraintAndIndex_ConstraintAdded (a)
go

ALTER TABLE  dbo.CheckUniqueKeysAreNotDuplicatedRule_Table_WithAnIncludedUniqueConstraintAndIndex_ConstraintAdded ADD CONSTRAINT  UN_CheckUniqueKeysAreNotDuplicatedRule_Table_WithAnIncludedUniqueConstraintAndIndex_ConstraintAdded_b_a UNIQUE (b,a) 
GO
