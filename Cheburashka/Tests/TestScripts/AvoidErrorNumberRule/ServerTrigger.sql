CREATE TRIGGER [ServerTrigger]
    ON ALL SERVER
    FOR LOGON
    AS
    BEGIN
        RETURN @@ERROR;  -- This should be flagged as a problem
        SET NOCOUNT ON
EXIT_PROC:        
    END
