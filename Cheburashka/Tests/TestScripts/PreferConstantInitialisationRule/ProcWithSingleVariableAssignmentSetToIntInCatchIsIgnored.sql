CREATE PROCEDURE dbo.ProcWithSingleVariableAssignmentSetToIntInCatchIsIgnored 
AS 
BEGIN
    declare @VAR INT;
    BEGIN TRY
        SELECT 1
    END TRY
    BEGIN CATCH
        SET @var=1;
    END CATCH
END
GO