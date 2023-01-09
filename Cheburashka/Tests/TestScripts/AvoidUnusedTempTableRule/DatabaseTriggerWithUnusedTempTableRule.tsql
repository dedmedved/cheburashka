CREATE TRIGGER [DatabaseTriggerWithUnusedTempTable]
    ON database
FOR DROP_SYNONYM    
    AS
    begin
    create table #A (a int)      -- #A is unused. This should be flagged as a problem
    create index ix on #A(a)
    alter table #A add b int
    drop table #A
    END
go
