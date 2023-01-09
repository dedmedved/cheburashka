
CREATE PROCEDURE dbo.ProcRaiseErrorOutsideTryCatchErrorLevel16
AS 
BEGIN
    BEGIN TRY 
        SELECT 1
    END TRY
    BEGIN CATCH 
    END CATCH
    RAISERROR('error',16,1); -- Uses RAISERROR. This is not OK outside a TRY/CATCH.
END