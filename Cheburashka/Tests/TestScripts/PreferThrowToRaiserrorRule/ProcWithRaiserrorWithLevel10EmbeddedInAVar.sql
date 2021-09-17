
CREATE PROCEDURE dbo.ProcWithRaiserrorWithLevel10EmbeddedInAVar
AS 
BEGIN
    begin try
    declare @RC INT = 10;
        RAISERROR('error',@RC,1); -- Uses RAISERROR at level 10, in a var
    END try
    begin catch
      print error_message()
    end catch
END