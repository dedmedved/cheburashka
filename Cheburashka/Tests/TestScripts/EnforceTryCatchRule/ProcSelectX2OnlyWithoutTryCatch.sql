
CREATE PROCEDURE dbo.ProcSelectX2OnlyWithoutTryCatch
AS 
BEGIN
      SELECT * FROM dbo.Table1; -- 2selects - no longer simple - should use try/catch
      SELECT * FROM dbo.Table1; -- 2selects - no longer simple - should use try/catch
END