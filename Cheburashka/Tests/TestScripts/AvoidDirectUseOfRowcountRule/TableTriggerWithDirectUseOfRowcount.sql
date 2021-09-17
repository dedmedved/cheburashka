create TRIGGER dbo.[TableTriggerWithDirectUseOfRowcount]
    ON dbo.Table1
    after insert
as
  select @@rowcount; -- Uses @@rowcount directly . This should be flagged as a problem
  select @@error; -- Uses @@error directly . This should be flagged as a problem

