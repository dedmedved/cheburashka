CREATE PROCEDURE dbo.ProcWithSingleVariableAssignmentSetToIntFollowedBySelectSetShouldBeIgnored 
AS 
BEGIN
    declare @VAR INT;
    SET @var =0;
    select @var=1 FROM table1;
END
GO