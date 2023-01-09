CREATE FUNCTION [dbo].[TableValuedFunctionWithUnUSedLabel]
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
    GOTO EXIT_PROC;  
    INSERT @returntable
    SELECT @param1, @param2
EXIT_PROC:    
EXIT_PROC2:    -- This should be flagged as a problem
    RETURN
END
