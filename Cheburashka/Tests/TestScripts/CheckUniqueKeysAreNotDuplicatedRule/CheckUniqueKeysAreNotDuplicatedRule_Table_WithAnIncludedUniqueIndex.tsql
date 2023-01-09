CREATE TABLE dbo.CheckUniqueKeysAreNotDuplicatedRule_Table_WithAnIncludedUniqueIndex 
(       a int not null
,       b int     null
,       c int     null
,       d int     null
) ;
go

create unique index ix_CheckUniqueKeysAreNotDuplicatedRule_Table_WithAnIncludedUniqueIndex_a on dbo.CheckUniqueKeysAreNotDuplicatedRule_Table_WithAnIncludedUniqueIndex  (a)
go
create unique index ix_CheckUniqueKeysAreNotDuplicatedRule_Table_WithAnIncludedUniqueIndex_b_a ON dbo.CheckUniqueKeysAreNotDuplicatedRule_Table_WithAnIncludedUniqueIndex  (b,a)
go
