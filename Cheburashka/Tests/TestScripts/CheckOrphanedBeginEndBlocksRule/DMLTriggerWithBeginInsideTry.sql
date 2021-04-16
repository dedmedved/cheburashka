CREATE TABLE dbo.Table1 (a INT, b INT);
GO 
CREATE TRIGGER  dbo.DMLTriggerWithBeginInsideTry
ON dbo.Table1
AFTER INSERT 
AS 
BEGIN
    declare @RC INT

    while 1=1 BEGIN TRY 
    BEGIN
      exec @RC = dbo.ProcWithReturn; 
    END;
    END try
    BEGIN CATCH
        RETURN 1;
    END CATCH ;

    RETURN 1;
END