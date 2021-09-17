CREATE TABLE dbo.CheckUniqueKeysAreNotDuplicatedRule_Table_WithAnIncludedPrimaryKeyAndIndex_ConstraintAdded 
(       a int not null
,       b int NOT NULL
,       c int     null
,       d int     NULL
) ;
go

create unique index ix_CheckUniqueKeysAreNotDuplicatedRule_Table_WithAnIncludedPrimaryKeyAndIndex_a on dbo.CheckUniqueKeysAreNotDuplicatedRule_Table_WithAnIncludedPrimaryKeyAndIndex_ConstraintAdded (a)
go

ALTER TABLE dbo.CheckUniqueKeysAreNotDuplicatedRule_Table_WithAnIncludedPrimaryKeyAndIndex_ConstraintAdded  ADD CONSTRAINT  PK_CheckUniqueKeysAreNotDuplicatedRule_Table_WithAnIncludedPrimaryKeyAndIndex_ConstraintAdded_b_a PRIMARY KEY  (b,a) 
GO
