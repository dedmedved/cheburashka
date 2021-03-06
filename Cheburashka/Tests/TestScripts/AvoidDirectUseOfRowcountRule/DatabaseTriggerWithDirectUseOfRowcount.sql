CREATE TRIGGER [DatabaseTriggerWithDirectUseOfRowcount]
    ON database
FOR DROP_SYNONYM    
    AS
    BEGIN
  select @@rowcount; -- Uses @@rowcount directly . This should be flagged as a problem
  select @@error; -- Uses @@error directly . This should be flagged as a problem
    END
go
