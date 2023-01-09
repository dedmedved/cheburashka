create table  dbo.[ProcedureWithCreateIndex_Table1]
(       a int not null
,       b int 
)
go

CREATE proc ProcedureWithCreateIndex
    AS
    BEGIN
        create index IX_TABLE_01 on dbo.[ProcedureWithCreateIndex_Table1] (b)
        create index IX_TABLE_02 on [ProcedureWithCreateIndex_Table1] (b)
    END
go
