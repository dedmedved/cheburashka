CREATE PROCEDURE dbo.ProcWithBeginWithReturnInBeginTryStatementBlockInWrongPlace
AS begin
begin try
        declare @RC int
        return; 
        exec @RC = dbo.ProcWithNestedBeginWithReturn; 
end try
begin catch
    print 'error'
end catch;
END;
