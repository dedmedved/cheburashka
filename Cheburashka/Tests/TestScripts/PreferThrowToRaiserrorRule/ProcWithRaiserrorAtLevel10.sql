
CREATE PROCEDURE dbo.ProcWithRaiserrorAtLevel10
AS 
BEGIN
    begin try
    declare @RC INT;
        RAISERROR('error',10,1); -- Uses RAISERROR at level 10. This is OK - its equivalent to PRINT.
    end try
    begin catch
      print error_message()
    end catch
END