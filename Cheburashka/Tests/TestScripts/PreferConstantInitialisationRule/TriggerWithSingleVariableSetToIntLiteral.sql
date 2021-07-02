CREATE trigger dbo.TriggerWithSingleVariableSetToIntLiteral
on Table1
after UPDATE  
AS 
BEGIN
    declare @VAR INT;
    SET @VAR = 1;
END
GO