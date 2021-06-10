
CREATE PROCEDURE dbo.ProcWithRaiserrorWithLevelEmbeddedInAVar
AS 
BEGIN
    begin try
    declare @RC INT = 10;
        RAISERROR('error',@RC,1); -- Uses RAISERROR at level 10, but its hidden in var - its an error as it might be a problem. W/o simple dataflow analysis we can't tell
    end try
    begin catch
      print error_message()
    end catch
END