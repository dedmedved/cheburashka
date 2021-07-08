CREATE PROCEDURE dbo.ProcWithSingleVariableSetToIntParameter @par int
AS 
BEGIN
    declare @VAR INT;
    SET @VAR = @par;
END
GO