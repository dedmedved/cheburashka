
CREATE PROCEDURE dbo.ProcWithBeginInsideTry
AS 
BEGIN
    declare @RC INT

    while 1=1 BEGIN TRY 
    BEGIN
      exec @RC = dbo.ProcWithReturn; 
    END;
    END try
    BEGIN CATCH
        return;
    END CATCH ;

    return;
END