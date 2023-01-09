create trigger CheckOpenTransactionCountCodeRule_DatabaseTrigger on database
    for drop_synonym
as
begin
IF @@TRANCOUNT = 1 ROLLBACK
IF XACT_STATE() = 1 ROLLBACK
IF @@TRANCOUNT = 1 OR XACT_STATE() = 1 ROLLBACK

WHILE @@TRANCOUNT = 1 ROLLBACK
WHILE XACT_STATE() = 1 ROLLBACK
WHILE @@TRANCOUNT = 1 OR XACT_STATE() = 1 ROLLBACK;
end
go
