CREATE TRIGGER [ServerTriggerWithInDirectUseOfRowcount]
    ON ALL SERVER
    FOR LOGON
    AS
    BEGIN
  declare @r1 int, @r2 int
  set @r1 = @@rowcount; -- Uses @@rowcount indirectly. This is ok.
  select @r2= @@error; -- Uses @@error indirectly. This is ok.
    END
