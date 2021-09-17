CREATE FUNCTION [dbo].[TableValuedFunctionWithErrorNumber]
(
    @param1 int,
    @param2 char(5)
)
RETURNS @returntable TABLE
(
    c1 int,
    c2 char(5)
)
AS
BEGIN
    print @@ERROR;  -- This should be flagged as a problem
    INSERT @returntable
    SELECT @param1, @param2
EXIT_PROC:    
    RETURN
END
