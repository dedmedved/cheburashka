CREATE TRIGGER [ServerTrigger1]
    ON ALL SERVER
    FOR LOGON
    AS
    BEGIN
        GOTO EXIT_PROC;  -- This should be flagged as a problem
        SET NOCOUNT ON
EXIT_PROC:        
    END
