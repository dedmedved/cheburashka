CREATE PROCEDURE dbo.ProcWithSingleVariableSetToChainOfVariablesInitialisedFromParameterInsideWhile @par INT
AS
BEGIN
    DECLARE @VAR INT = @par;
    DECLARE @VAR1 INT = @VAR * 2;
    DECLARE @var2 INT;
    while 1=1 begin 
        SET @var2 = @VAR1;
    end
END;
GO