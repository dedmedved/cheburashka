
CREATE PROCEDURE dbo.ProcSelectAndSetOnlyWithoutTryCatch
AS 
BEGIN
        SET NOCOUNT ON;
        SET LANGUAGE us_english;
        SET ANSI_DEFAULTS OFF
        SET TEXTSIZE 1000;

      SELECT * FROM dbo.Table1; -- Doesn't use TRY/CATCH. This shouldn't be flagged as a problem.
END