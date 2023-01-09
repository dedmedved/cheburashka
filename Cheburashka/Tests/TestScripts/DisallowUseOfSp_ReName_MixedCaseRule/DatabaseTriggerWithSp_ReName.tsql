create trigger [DatabaseTriggerWithSp_ReName] on database
    for drop_synonym
AS 
BEGIN
  exec SP_RENAME 'ProcWithSp_ReName','ProcWithSp_ReName_NewName'
END