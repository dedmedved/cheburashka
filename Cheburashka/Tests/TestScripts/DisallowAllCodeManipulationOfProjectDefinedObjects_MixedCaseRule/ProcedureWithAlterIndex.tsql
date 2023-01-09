create table  dbo.ProcedureWithAlterIndex_Table
(       a int not null
,       b int 
)
go
create index ix_Table_01 on dbo.ProcedureWithAlterIndex_Table (b)
go
CREATE proc ProcedureWithAlterIndex
    AS
    BEGIN
        alter index IX_TABLE_01 on dbo.ProcedureWithAlterIndex_Table set (IGNORE_DUP_KEY = ON);
        alter index IX_TABLE_01 on dbo.ProcedureWithAlterIndex_Table DISABLE;
        alter index IX_TABLE_01 on dbo.ProcedureWithAlterIndex_Table REBUILD WITH (DATA_COMPRESSION = PAGE);
    END
go
