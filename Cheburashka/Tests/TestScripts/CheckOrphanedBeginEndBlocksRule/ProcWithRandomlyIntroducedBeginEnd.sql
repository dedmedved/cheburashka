
CREATE PROCEDURE dbo.ProcWithRandomlyIntroducedBeginEnd
AS 
BEGIN
    declare @RC INT

    BEGIN
    while 1=1 BEGIN TRY 
        EXEC @RC = dbo.ProcWithReturn; 
    END try
    BEGIN CATCH
        return;
    END CATCH ;
    END;

    return;
END