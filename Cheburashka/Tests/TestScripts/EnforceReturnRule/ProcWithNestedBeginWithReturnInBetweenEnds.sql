
CREATE PROCEDURE dbo.ProcWithNestedBeginWithReturnInBetweenEnds
AS begin
BEGIN
    declare @RC int
    exec @RC = dbo.ProcWithNestedBeginWithReturn; -- Uses Return. This is OK.
END;
    return; 
END;
