
CREATE PROCEDURE dbo.ProcWithOutTryCatch
AS 
BEGIN
      exec dbo.ProcWithoutTryCatch; -- Doesn't use TRY/CATCH. This should be flagged as a problem.
END