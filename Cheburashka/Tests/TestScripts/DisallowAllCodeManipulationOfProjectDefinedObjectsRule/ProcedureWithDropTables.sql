create table  dbo.ProcedureWithDropTables_Table1
(       a int not null
,       b int 
)
GO
create table  dbo.ProcedureWithDropTables_Table2
(       a int not null
,       b int 
)
go

CREATE proc [ProcedureWithDropTables]
    AS
    BEGIN
        DROP TABLE  dbo.ProcedureWithDropTables_Table1, dbo.ProcedureWithDropTables_Table2
    END
go
