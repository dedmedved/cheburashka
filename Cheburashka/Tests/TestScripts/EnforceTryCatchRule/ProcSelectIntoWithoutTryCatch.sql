
CREATE PROCEDURE dbo.ProcSelectIntoWithoutTryCatch
AS 
BEGIN
      SELECT * INTO #tmp FROM dbo.Table1; -- Doesn't use TRY/CATCH. This should be flagged as a problem.
END