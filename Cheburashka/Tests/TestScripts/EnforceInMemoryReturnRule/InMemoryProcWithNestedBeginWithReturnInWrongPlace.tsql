
CREATE PROCEDURE dbo.ProcWithNestedBeginWithReturnInWrongPlace
AS BEGIN ATOMIC   
    WITH (TRANSACTION ISOLATION LEVEL = SNAPSHOT,
        LANGUAGE = N'us_english');
BEGIN
    declare @RC int
    exec @RC = dbo.ProcWithNestedBeginWithReturn; -- Uses Return in wrong place. This is NOT OK.
    return; 
    declare @RC2 int;
END;
END;
