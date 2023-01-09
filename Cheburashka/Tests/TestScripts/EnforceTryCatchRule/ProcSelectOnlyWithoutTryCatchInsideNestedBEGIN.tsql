
CREATE PROCEDURE dbo.ProcSelectOnlyWithoutTryCatchInsideNestedBEGIN
AS 
BEGIN
BEGIN
BEGIN
      SELECT * FROM dbo.Table1; -- Doesn't use TRY/CATCH. This shouldn't be flagged as a problem.
END;END;
END