create table  dbo.Table2
(       a int not null
,       b int 
)
go
create index ix_Table2_01 on dbo.Table2 (b)
go

CREATE TRIGGER [TableTriggerWithDropIndex]
    ON dbo.Table2
    after insert   
    AS
    BEGIN
        drop index ix_Table2_01 on dbo.Table2
    END
go
