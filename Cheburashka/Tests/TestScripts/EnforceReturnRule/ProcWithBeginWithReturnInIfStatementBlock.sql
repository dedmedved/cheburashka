
CREATE PROCEDURE dbo.ProcWithBeginWithReturnInIfStatementBlock
AS begin
    declare @x int = 0;
    if @x = 1 
    begin
        print 'one';
    end 
    else begin
        declare @RC int
        exec @RC = dbo.ProcWithNestedBeginWithReturn; -- Uses Return. This is OK.
        return; 
    end;
END;
