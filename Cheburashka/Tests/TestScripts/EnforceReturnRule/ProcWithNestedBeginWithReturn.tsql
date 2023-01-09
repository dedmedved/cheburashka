
CREATE PROCEDURE dbo.ProcWithNestedBeginWithReturn
AS begin
BEGIN
    declare @RC int
    exec @RC = dbo.ProcWithNestedBeginWithReturn; 
    return; -- Uses Return. This is OK.
END;
END;
