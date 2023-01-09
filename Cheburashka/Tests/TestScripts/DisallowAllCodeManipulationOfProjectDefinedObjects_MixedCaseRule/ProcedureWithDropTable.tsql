create table  dbo.ProcedureWithDropTable_Table
(       a int not null
,       b int 
)
go
create index ix_Table_01 on dbo.ProcedureWithDropTable_Table (b)
go
create index ix_Table_02 on dbo.ProcedureWithDropTable_Table (b)
go
CREATE proc [ProcedureWithDropTable]
    AS
    BEGIN
        DROP TABLE  dbo.PROCEDUREWITHDROPTABLE_TABLE
    END
go
