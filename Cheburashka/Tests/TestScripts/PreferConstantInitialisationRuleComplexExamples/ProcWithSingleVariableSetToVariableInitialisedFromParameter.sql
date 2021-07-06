CREATE PROCEDURE dbo.ProcWithSingleVariableSetToVariableInitialisedFromParameter @par int
AS 
BEGIN
    declare @VAR INT = @par;
    declare @var2 INT  ;
    SET @var2 = @var
END
GO