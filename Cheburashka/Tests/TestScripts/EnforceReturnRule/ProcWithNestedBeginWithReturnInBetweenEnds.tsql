
CREATE PROCEDURE dbo.ProcWithNestedBeginWithReturnInBetweenEnds
AS begin
BEGIN
    declare @RC int
    exec @RC = dbo.ProcWithNestedBeginWithReturn; 
END;
    return; -- Uses Return. This is OK.
END;
