CREATE PROCEDURE dbo.ProcWithSingleVariableExecuteSetToInt
AS 
BEGIN
    declare @VAR INT;
    exec @Var = dbo.ProcWithSingleVariableExecuteSetToInt;
END
GO