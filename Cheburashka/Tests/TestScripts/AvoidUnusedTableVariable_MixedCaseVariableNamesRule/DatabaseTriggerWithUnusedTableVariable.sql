CREATE TRIGGER [DatabaseTriggerWithUnusedTableVariable]
    ON database
FOR DROP_SYNONYM    
    AS
    begin
    declare @A table (a int)      -- @A is unused. This should be flagged as a problem
    END
go
