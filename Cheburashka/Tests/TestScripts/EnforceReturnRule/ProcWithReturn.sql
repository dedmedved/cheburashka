
CREATE PROCEDURE dbo.ProcWithReturn
AS 
BEGIN
    declare @RC int
      exec @RC = dbo.ProcWithReturn; -- Uses Return. This is OK.
    return;
END