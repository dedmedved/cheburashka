CREATE PROCEDURE dbo.ProcWithSingleVariableSetToChainOfInitialisationsInWhileFromChainOfVariablesInitialisedFromParameter @par INT
AS
BEGIN
    DECLARE @VAR INT = @par;
    DECLARE @VAR1 INT = @VAR * 2;
    DECLARE @var2 INT;
    while 1=1 begin 
        SET @var2 = @VAR1;
    end
    DECLARE @var3 INT;
    SET @var3 = @VAR2;
END;
GO