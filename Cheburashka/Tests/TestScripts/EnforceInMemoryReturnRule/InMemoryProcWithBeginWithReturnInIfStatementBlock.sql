
CREATE PROCEDURE dbo.ProcWithBeginWithReturnInIfStatementBlock
    WITH NATIVE_COMPILATION, SCHEMABINDING   
AS
BEGIN ATOMIC   
    WITH (TRANSACTION ISOLATION LEVEL = SNAPSHOT,
        LANGUAGE = N'us_english');
    declare @x int = 0;
    if @x = 1 
    begin
        print 'one';
    end 
    else begin
        declare @RC int
        exec @RC = dbo.ProcWithNestedBeginWithReturn; 
        return; -- Uses Return in wrong place. This is NOT OK.
    end;
END;
