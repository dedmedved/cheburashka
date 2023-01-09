create table  dbo.Table1 ( a int ) 
go
create trigger dbo.[TableTriggerWithSp_ReName] on dbo.Table1
    after insert
AS 
BEGIN
  exec sp_rename 'ProcWithSp_ReName','ProcWithSp_ReName_NewName'
end

