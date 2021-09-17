
CREATE PROCEDURE dbo.ProcWithNestedBeginWithReturnInWrongPlace
AS begin
BEGIN
    declare @RC int
    exec @RC = dbo.ProcWithNestedBeginWithReturn; -- Uses Return in wrong place. This is Not OK.
    return; 
    declare @RC2 int;
END;
END;
