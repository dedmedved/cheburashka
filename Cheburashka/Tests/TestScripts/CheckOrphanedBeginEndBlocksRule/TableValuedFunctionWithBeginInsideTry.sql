CREATE FUNCTION dbo.TableValuedFunctionWithBeginInsideTry()
RETURNS @res TABLE (a INT, b int)
AS 
BEGIN
    declare @RC INT

    while 1=1 BEGIN TRY 
    BEGIN
      INSERT @res values(1,1);
    END;
    END try
    BEGIN CATCH
        RETURN ;
    END CATCH ;

    RETURN ;
END