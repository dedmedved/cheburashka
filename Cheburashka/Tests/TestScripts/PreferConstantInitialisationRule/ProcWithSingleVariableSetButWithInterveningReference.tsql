CREATE PROCEDURE dbo.ProcWithSingleVariableSetButWithInterveningReference @par int
AS 
BEGIN
    declare @VAR INT ;
    declare @var2 INT ;
    SET @var2 = @var
    SET @var= 1;
END
GO