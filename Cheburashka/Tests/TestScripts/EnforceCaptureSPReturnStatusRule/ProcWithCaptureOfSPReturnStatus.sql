
CREATE PROCEDURE dbo.ProcWithCaptureOfSPReturnStatus
AS 
BEGIN
    declare @RC int
      exec @RC = dbo.ProcWithCaptureOfSPReturnStatus; -- Captures return status. This is OK.
END