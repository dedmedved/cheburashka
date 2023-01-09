CREATE TABLE dbo.CheckUniqueKeysAreNotDuplicatedRule_Table_WithTwoSeparateUniqueIndexes
(       a int not null
,       b int     null
,       c int     null
,       d int     null
) ;
go

create unique index ix_CheckUniqueKeysAreNotDuplicatedRule_Table_WithTwoSeparateUniqueIndexes_a_b  ON dbo.CheckUniqueKeysAreNotDuplicatedRule_Table_WithTwoSeparateUniqueIndexes (a,b)
go
create unique index ix_CheckUniqueKeysAreNotDuplicatedRule_Table_WithTwoSeparateUniqueIndexes_a    ON dbo.CheckUniqueKeysAreNotDuplicatedRule_Table_WithTwoSeparateUniqueIndexes (c,d)
go
