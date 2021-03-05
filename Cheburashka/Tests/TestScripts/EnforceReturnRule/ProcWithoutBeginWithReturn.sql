
CREATE PROCEDURE dbo.ProcWithoutBeginWithReturn
AS 
    declare @RC int
      exec @RC = dbo.ProcWithoutBeginWithReturn; -- Uses Return. This is OK.
    return;
