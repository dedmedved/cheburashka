CREATE TABLE dbo.CheckUniqueKeysAreNotDuplicatedRule_Table_WithAnIncludedPrimaryKeyAndIndex_ConstraintAdded 
(       A int not null
,       B int NOT NULL
,       C int     null
,       D int     NULL
) ;
go

create unique index ix_CheckUniqueKeysAreNotDuplicatedRule_Table_WithAnIncludedPrimaryKeyAndIndex_a on dbo.CheckUniqueKeysAreNotDuplicatedRule_Table_WithAnIncludedPrimaryKeyAndIndex_ConstraintAdded (a)
go

ALTER TABLE dbo.CheckUniqueKeysAreNotDuplicatedRule_Table_WithAnIncludedPrimaryKeyAndIndex_ConstraintAdded  ADD CONSTRAINT  PK_CheckUniqueKeysAreNotDuplicatedRule_Table_WithAnIncludedPrimaryKeyAndIndex_ConstraintAdded_b_a PRIMARY KEY  (b,a) 
GO
