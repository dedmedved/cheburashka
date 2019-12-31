create table  dbo.[Table1]
(       a int not null
,       b int 
)
go
create index ix_Table_01 on dbo.[Table1] (b)
go
CREATE proc [ProcedureWithDropIndex]
    AS
    BEGIN
        drop index ix_Table_01 on dbo.Table1
    END
go
