CREATE PROCEDURE dbo.ProcWithBeginWithReturnInNestedBeginTryStatementBlock
AS begin
begin try
        declare @RC int
        exec @RC = dbo.ProcWithNestedBeginWithReturn; 

            begin try
                    declare @RC2 int
                    exec @RC2 = dbo.ProcWithNestedBeginWithReturn; 
                    return; 
            end try
            begin catch
                print 'error'
            end catch;

        return; 
end try
begin catch
    print 'error'
end catch;
END;
