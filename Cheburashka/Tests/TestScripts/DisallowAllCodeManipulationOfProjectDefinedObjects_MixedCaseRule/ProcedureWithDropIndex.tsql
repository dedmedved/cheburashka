create table  dbo.[Table1]
(       a int not null
,       b int 
)
go
create index ix_Table_01 on dbo.[Table1] (b)
go
create index ix_Table_02 on dbo.[Table1] (b)
go
CREATE proc [ProcedureWithDropIndex]
    AS
    BEGIN
        drop index IX_TABLE_01 on DBO.TABLE1
        drop index IX_TABLE_02 on TABLE1
    END
go
