CREATE TABLE dbo.CheckUniqueKeysAreNotDuplicatedRule_Table_WithTwoOverLappingUniqueIndexes
(       a int not null
,       b int     null
,       c int     null
,       d int     null
) ;
go

create unique index ix_CheckUniqueKeysAreNotDuplicatedRule_Table_WithTwoOverLappingUniqueIndexes_a_b on dbo.CheckUniqueKeysAreNotDuplicatedRule_Table_WithTwoOverLappingUniqueIndexes (a,b)
go
create unique index ix_CheckUniqueKeysAreNotDuplicatedRule_Table_WithTwoOverLappingUniqueIndexes_b_c ON dbo.CheckUniqueKeysAreNotDuplicatedRule_Table_WithTwoOverLappingUniqueIndexes (b,c)
go
