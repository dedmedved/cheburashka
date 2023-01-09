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
        DROP TABLE  DBO.PROCEDUREWITHDROPTABLES_TABLE1, DBO.PROCEDUREWITHDROPTABLES_TABLE2
    END
go
