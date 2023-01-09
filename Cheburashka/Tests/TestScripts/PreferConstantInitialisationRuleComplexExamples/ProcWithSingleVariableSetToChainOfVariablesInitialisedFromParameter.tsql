CREATE PROCEDURE dbo.ProcWithSingleVariableSetToChainOfVariablesInitialisedFromParameter @par INT
AS
BEGIN
    DECLARE @VAR INT = @par;
    DECLARE @VAR1 INT = @VAR * 2;
    DECLARE @var2 INT;
    SET @var2 = @VAR1;
END;
GO