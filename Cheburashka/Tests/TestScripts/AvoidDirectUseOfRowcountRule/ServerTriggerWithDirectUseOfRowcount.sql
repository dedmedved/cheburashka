CREATE TRIGGER [ServerTriggerWithDirectUseOfRowcount]
    ON ALL SERVER
    FOR LOGON
    AS
    BEGIN
  select @@rowcount; -- Uses @@rowcount directly . This should be flagged as a problem
  select @@error; -- Uses @@error directly . This should be flagged as a problem
    END
