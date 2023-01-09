CREATE PROCEDURE dbo.ProcWithBeginWithReturnInBeginTryStatementBlock
AS begin
begin try
        declare @RC int
        exec @RC = dbo.ProcWithNestedBeginWithReturn; 
        return; 
end try
begin catch
    print 'error'
end catch;
END;
