
create table dbo.indexedTable1 ( a int, b int)
go
create unique index ix_indexedTable1 on dbo.indexedTable1(b);
--alter table dbo.indexedTable1 add constraint ix_indexedTable1 unique (b);
go

