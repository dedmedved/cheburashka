CREATE TRIGGER [SERVERTRIGGERWITHSP_RENAME] 
ON ALL SERVER 
FOR LOGON
AS 
BEGIN
  EXEC sp_rename 'ProcWithSp_ReName','ProcWithSp_ReName_NewName'
END