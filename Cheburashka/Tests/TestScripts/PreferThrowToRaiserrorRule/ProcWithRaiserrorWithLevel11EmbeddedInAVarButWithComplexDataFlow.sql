
CREATE PROCEDURE dbo.ProcWithRaiserrorWithLevel11EmbeddedInAVarButWithComplexDataFlow
AS 
BEGIN
    begin try
    declare @RC INT;
    SET @RC = 11;
        RAISERROR('error',@RC,1); -- Uses RAISERROR at level 11, but its hidden in var - its an error as it might be a problem. W/o simple dataflow analysis we can't tell
    end try
    begin catch
      print error_message()
    end catch
END