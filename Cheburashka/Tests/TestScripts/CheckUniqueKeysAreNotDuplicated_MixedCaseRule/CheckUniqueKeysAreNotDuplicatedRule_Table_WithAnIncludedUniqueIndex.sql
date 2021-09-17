CREATE TABLE dbo.CheckUniqueKeysAreNotDuplicatedRule_Table_WithAnIncludedUniqueIndex 
(       A int not null
,       B int     null
,       C int     null
,       D int     null
) ;
go

create unique index ix_CheckUniqueKeysAreNotDuplicatedRule_Table_WithAnIncludedUniqueIndex_a on dbo.CheckUniqueKeysAreNotDuplicatedRule_Table_WithAnIncludedUniqueIndex  (a)
go
create unique index ix_CheckUniqueKeysAreNotDuplicatedRule_Table_WithAnIncludedUniqueIndex_b_a ON dbo.CheckUniqueKeysAreNotDuplicatedRule_Table_WithAnIncludedUniqueIndex  (b,a)
go
