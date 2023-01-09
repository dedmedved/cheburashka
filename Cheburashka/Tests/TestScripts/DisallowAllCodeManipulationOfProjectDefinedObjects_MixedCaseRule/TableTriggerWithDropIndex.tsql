create table  dbo.Table2
(       a int not null
,       b int 
)
go
create index ix_table2_01 on dbo.table2 (b)
go

CREATE TRIGGER [TableTriggerWithDropIndex]
    ON dbo.Table2
    after insert   
    AS
    BEGIN
        drop index IX_TABLE2_01 ON DBO.TABLE2
    END
go
