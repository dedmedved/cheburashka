CREATE PROCEDURE dbo.ProcWithSingleVariableSetToInitialisedVariable @par int
AS 
BEGIN
    declare @VAR INT = 1;
    declare @var2 INT  ;
    SET @var2 = @var
END
GO