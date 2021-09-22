CREATE PROCEDURE dbo.ProcWithSingleVariableAssignmentSetToIntButHasGotoAndIsIgnored 
AS 
BEGIN
    declare @VAR INT;
    GOTO label;
    SET @var=1;
label:
END
GO