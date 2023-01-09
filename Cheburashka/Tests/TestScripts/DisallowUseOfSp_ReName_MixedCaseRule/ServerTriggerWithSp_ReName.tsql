create trigger [ServerTriggerWithSp_ReName] 
on ALL SERVER 
for logon
AS 
BEGIN
  exec SP_RENAME 'ProcWithSp_ReName','ProcWithSp_ReName_NewName'
END