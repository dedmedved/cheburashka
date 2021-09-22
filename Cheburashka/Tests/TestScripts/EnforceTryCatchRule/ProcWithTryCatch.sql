
CREATE PROCEDURE dbo.ProcWithTryCatch
AS 
BEGIN
    begin try
    declare @RC int
      exec @RC = dbo.ProcWithTryCatch; -- Uses TRY/CATCH. This is OK.
    end try
    begin catch
      print error_message()
    end catch
END