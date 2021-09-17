
create function CheckOpenTransactionCountCodeRule_TableValuedFunction ()
returns @X table (a int)
as
BEGIN

    IF @@TRANCOUNT = 1 ROLLBACK
    IF XACT_STATE() = 1 ROLLBACK
    IF @@TRANCOUNT = 1 OR XACT_STATE() = 1 ROLLBACK
    
    WHILE @@TRANCOUNT = 1 ROLLBACK
    WHILE XACT_STATE() = 1 ROLLBACK
    WHILE @@TRANCOUNT = 1 OR XACT_STATE() = 1 ROLLBACK;

    insert  into @X
    SELECT a
    FROM dbo.table1
    WHERE a = null
    return 
end