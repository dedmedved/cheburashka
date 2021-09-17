CREATE PROCEDURE dbo.ProcWithSingleVariableSetToError_lineFunction
AS 
BEGIN
    declare @VAR int;
    SET @VAR = ERROR_LINE();
END
GO