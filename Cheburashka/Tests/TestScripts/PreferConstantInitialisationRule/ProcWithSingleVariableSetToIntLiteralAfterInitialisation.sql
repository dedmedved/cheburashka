CREATE PROCEDURE dbo.ProcWithSingleVariableSetToIntLiteralAfterInitialisation
AS 
BEGIN
    declare @VAR INT = 1;
    SET @VAR = 1;
END
GO