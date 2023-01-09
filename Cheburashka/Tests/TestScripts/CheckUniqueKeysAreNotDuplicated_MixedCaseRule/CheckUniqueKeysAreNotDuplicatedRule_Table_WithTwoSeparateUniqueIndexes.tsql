CREATE TABLE dbo.CheckUniqueKeysAreNotDuplicatedRule_Table_WithTwoSeparateUniqueIndexes
(       A int not null
,       B int     null
,       C int     null
,       D int     null
) ;
go

create unique index ix_CheckUniqueKeysAreNotDuplicatedRule_Table_WithTwoSeparateUniqueIndexes_a_b  ON dbo.CheckUniqueKeysAreNotDuplicatedRule_Table_WithTwoSeparateUniqueIndexes (a,b)
go
create unique index ix_CheckUniqueKeysAreNotDuplicatedRule_Table_WithTwoSeparateUniqueIndexes_a    ON dbo.CheckUniqueKeysAreNotDuplicatedRule_Table_WithTwoSeparateUniqueIndexes (c,d)
go
