CREATE TRIGGER [ServerTriggerWithNonLocalTableVariable]
    ON ALL SERVER
    FOR LOGON
    AS
    begin 
    select * from  #A
    select * from  ##A
    END
