
CREATE PROCEDURE dbo.ProcWithNestedBeginWithReturn
AS BEGIN ATOMIC   
    WITH (TRANSACTION ISOLATION LEVEL = SNAPSHOT,
        LANGUAGE = N'us_english');
BEGIN
    declare @RC int
    exec @RC = dbo.ProcWithNestedBeginWithReturn; 
    return; -- Uses Return. This is OK.
END;
END;
