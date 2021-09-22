
CREATE PROCEDURE dbo.ProcRaiseErrorOutsideTryCatchErrorLevel10
AS 
BEGIN
    BEGIN TRY 
        SELECT 1
    END TRY
    BEGIN CATCH 
    END CATCH
    RAISERROR('error',10,1); -- Uses RAISERROR. This is not OK outside a TRY/CATCH.
END