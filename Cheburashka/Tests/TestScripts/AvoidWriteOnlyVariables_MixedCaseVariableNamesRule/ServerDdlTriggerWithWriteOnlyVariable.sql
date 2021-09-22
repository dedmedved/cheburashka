CREATE TRIGGER [ServerTriggerWithWriteOnlyVariable]
    ON ALL SERVER
    FOR LOGON
    AS
    begin 
    declare @A int      -- @A is only written to. This should be flagged as a problem
    set @a = 1
    END
