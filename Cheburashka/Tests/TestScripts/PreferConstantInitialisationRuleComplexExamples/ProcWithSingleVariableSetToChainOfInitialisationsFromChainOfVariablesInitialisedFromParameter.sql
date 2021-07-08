CREATE PROCEDURE dbo.ProcWithSingleVariableSetToChainOfInitialisationsFromChainOfVariablesInitialisedFromParameter @par INT
AS
BEGIN
    DECLARE @VAR INT = @par;
    DECLARE @VAR1 INT = @VAR * 2;
    DECLARE @var2 INT;
    SET @var2 = @VAR1;
    DECLARE @var3 INT;
    SET @var3 = @VAR2;
END;
GO