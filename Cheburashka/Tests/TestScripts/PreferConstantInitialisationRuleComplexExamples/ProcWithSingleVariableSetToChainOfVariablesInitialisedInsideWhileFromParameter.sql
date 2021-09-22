CREATE PROCEDURE dbo.ProcWithSingleVariableSetToChainOfVariablesInitialisedInsideWhileFromParameter @par INT
AS
BEGIN
    DECLARE @VAR INT = @par;
    while 1=1 begin 
        DECLARE @VAR1 INT = @VAR * 2;
    end
    DECLARE @var2 INT;
    SET @var2 = @VAR1;
END;
GO