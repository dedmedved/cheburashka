
CREATE PROCEDURE dbo.ProcRaiseErrorInsideTryCatchErrorLevel16
AS 
BEGIN
    BEGIN TRY 
        SELECT 1
        RAISERROR('error',16,1); -- Uses RAISERROR. This is not OK outside a TRY/CATCH.
    END TRY
    BEGIN CATCH 
    END CATCH

END