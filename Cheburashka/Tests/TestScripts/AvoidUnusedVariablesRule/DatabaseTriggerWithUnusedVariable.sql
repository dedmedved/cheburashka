CREATE TRIGGER [DatabaseTriggerWithUnusedVariable]
    ON database
FOR DROP_SYNONYM    
    AS
    begin
    declare @A int      -- @A is unused. This should be flagged as a problem
    END
go
