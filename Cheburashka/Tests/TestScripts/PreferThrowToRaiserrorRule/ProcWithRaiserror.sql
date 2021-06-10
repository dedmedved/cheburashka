
CREATE PROCEDURE dbo.ProcWithRaiserror
AS 
BEGIN
    begin try
    declare @RC INT;
        RAISERROR('error',16,1); -- Uses RAISERROR. This is not OK.
    end try
    begin catch
      print error_message()
    end catch
END