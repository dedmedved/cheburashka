
CREATE PROCEDURE dbo.ProcWithReturn
AS 
BEGIN ATOMIC   
    WITH (TRANSACTION ISOLATION LEVEL = SNAPSHOT,
        LANGUAGE = N'us_english');
    declare @RC int
      exec @RC = dbo.ProcWithReturn; 
    return; -- Uses Return. This is OK.
END