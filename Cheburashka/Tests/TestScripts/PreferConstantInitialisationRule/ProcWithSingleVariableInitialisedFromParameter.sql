CREATE PROCEDURE dbo.ProcWithSingleVariableInitialisedFromParameter @par int
AS 
BEGIN
    declare @VAR INT = @par;
END
GO