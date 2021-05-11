CREATE TRIGGER [ServerTrigger]
    ON ALL SERVER
    FOR LOGON
    AS
    BEGIN
        GOTO EXIT_PROC;  
        SET NOCOUNT ON
EXIT_PROC:        
EXIT_PROC2:        -- This should be flagged as a problem
    END
