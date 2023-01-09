CREATE PROCEDURE dbo.ProcWithSingleVariableAssignmentReceiveMessageIsIgnored 
AS 
BEGIN
DECLARE @var UNIQUEIDENTIFIER;
RECEIVE @var=conversation_handle
FROM ExpenseQueue ;
END
GO