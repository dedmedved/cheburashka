
CREATE PROCEDURE dbo.ProcWithNestedBeginEnd
AS 
BEGIN
BEGIN
    declare @RC INT;
    return;
END;
END;