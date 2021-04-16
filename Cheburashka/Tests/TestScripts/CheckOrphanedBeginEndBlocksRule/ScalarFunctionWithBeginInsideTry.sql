CREATE FUNCTION dbo.ScalarFunctionWithBeginInsideTry()
RETURNS int
AS 
BEGIN
    declare @RC INT

    while 1=1 BEGIN TRY 
    BEGIN
      exec @RC = dbo.ProcWithReturn; 
    END;
    END try
    BEGIN CATCH
        RETURN 1;
    END CATCH ;

    RETURN 1;
END