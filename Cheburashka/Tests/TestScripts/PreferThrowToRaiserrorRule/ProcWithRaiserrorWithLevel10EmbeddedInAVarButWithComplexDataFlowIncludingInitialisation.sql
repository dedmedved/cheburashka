
CREATE PROCEDURE dbo.ProcWithRaiserrorWithLevel10EmbeddedInAVarButWithComplexDataFlowIncludingInitialisation
AS 
BEGIN
    begin try
    declare @RC INT =10 ;
    set @RC = 10;       -- cant deal with this scenario
        RAISERROR('error',@RC,1); -- Uses RAISERROR at level 10, in a var- should be an error - we cant tell
    END try
    begin catch
      print error_message()
    end catch
END