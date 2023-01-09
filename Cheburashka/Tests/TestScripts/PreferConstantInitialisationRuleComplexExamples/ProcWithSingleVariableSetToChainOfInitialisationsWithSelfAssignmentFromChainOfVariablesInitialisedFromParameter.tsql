CREATE PROCEDURE dbo.ProcWithSingleVariableSetToChainOfInitialisationsWithSelfAssignmentFromChainOfVariablesInitialisedFromParameter @par INT
AS
BEGIN
    DECLARE @VAR INT = @par;
    DECLARE @VAR1 INT = @VAR * 2;
    DECLARE @var2 INT;
    SET @var2 = @VAR2;
    DECLARE @var3 INT;
    SET @var3 = @VAR2;
END;
GO