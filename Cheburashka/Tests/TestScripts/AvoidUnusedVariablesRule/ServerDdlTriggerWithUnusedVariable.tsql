CREATE TRIGGER [ServerTriggerWithUnusedVariable]
    ON ALL SERVER
    FOR LOGON
    AS
    begin 
    declare @A int      -- @A is unused. This should be flagged as a problem
    END
