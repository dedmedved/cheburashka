
CREATE PROCEDURE dbo.ProcWithNoBadBegins
AS 
BEGIN
    declare @RC INT

    while 1=1 BEGIN TRY 
      exec @RC = dbo.ProcWithReturn; 
    END try
    BEGIN CATCH
        return;
    END CATCH ;

    while 1=1 BEGIN

      exec @RC = dbo.ProcWithReturn; 
      END;


    IF 1=1 BEGIN

      exec @RC = dbo.ProcWithReturn; 
      END;

    IF 1=1 BEGIN
    
      exec @RC = dbo.ProcWithReturn; 
      END;
    ELSE BEGIN
    return
    END 
    return;
END