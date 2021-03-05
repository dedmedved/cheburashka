
CREATE PROCEDURE dbo.ProcWithNestedBeginWithReturnInWrongPlace
AS begin
BEGIN
    declare @RC int
    exec @RC = dbo.ProcWithNestedBeginWithReturn; -- Uses Return. This is OK.
    return; 
    declare @RC2 int;
END;
END;
