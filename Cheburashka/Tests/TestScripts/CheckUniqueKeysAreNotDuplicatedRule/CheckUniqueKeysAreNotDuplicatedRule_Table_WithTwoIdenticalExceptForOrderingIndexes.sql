CREATE TABLE dbo.CheckUniqueKeysAreNotDuplicatedRule_Table_WithTwoIdenticalExceptForOrderingIndexes 
(       a int not null
,       b int     null
,       c int     null
,       d int     null
) ;
go

create unique index ix_CheckUniqueKeysAreNotDuplicatedRule_Table_WithTwoIdenticalExceptForOrderingIndexes_a_b on dbo.CheckUniqueKeysAreNotDuplicatedRule_Table_WithTwoIdenticalExceptForOrderingIndexes (a,b)
go
create unique index ix_CheckUniqueKeysAreNotDuplicatedRule_Table_WithTwoIdenticalExceptForOrderingIndexes_b_a ON dbo.CheckUniqueKeysAreNotDuplicatedRule_Table_WithTwoIdenticalExceptForOrderingIndexes (b,a)
go
