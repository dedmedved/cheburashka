
CREATE PROCEDURE dbo.ProcWithNestedBeginWithReturn
AS begin
BEGIN
    declare @RC int
    exec @RC = dbo.ProcWithNestedBeginWithReturn; -- Uses Return. This is OK.
    return; 
END;
END;
