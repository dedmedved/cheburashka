create table  dbo.Table3
(       a int not null
,       b int 
)
go
create index IX_TABLE3_01 on dbo.Table3 (b)
go

CREATE TRIGGER [DatabaseTriggerWithDropIndex]
    ON database
FOR DROP_SYNONYM    
    AS
    BEGIN
        drop index ix_Table3_01 on dbo.Table3
    END
go
