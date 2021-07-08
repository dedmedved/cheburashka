CREATE PROCEDURE dbo.ProcWithSingleVariableSetToIntParameterWhereParameterIsSetAfterReference @par int
AS 
BEGIN
    declare @VAR INT;
    SET @VAR = @par;
    SET @par=1;
END
GO