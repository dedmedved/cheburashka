CREATE TRIGGER [ServerTriggerWithUnusedTableVariable]
    ON ALL SERVER
    FOR LOGON
    AS
    begin 
    declare @A table (a int)      -- @A is unused. This should be flagged as a problem
    END
