create TABLE dbo.EnforceForeignKeyRule_MemoryOptimisedTable_With_FK (a int not NULL
, CONSTRAINT PK_EnforceForeignKeyRule_MemoryOptimisedTable_With_FK primary KEY (a)
)
WITH (MEMORY_OPTIMIZED = ON, DURABILITY = SCHEMA_AND_DATA)
GO
create table dbo.EnforceForeignKeyRule_MemoryOptimisedTable_With_FK_Child (a int not NULL
, CONSTRAINT PK_EnforceForeignKeyRule_MemoryOptimisedTable_With_FK_Child primary KEY (a)
, constraint FK_EnforceForeignKeyRule_MemoryOptimisedTable_With_FK foreign key (a) references EnforceForeignKeyRule_MemoryOptimisedTable_With_FK (a)
)
WITH (MEMORY_OPTIMIZED = ON, DURABILITY = SCHEMA_AND_DATA)
go
