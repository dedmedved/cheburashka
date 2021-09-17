CREATE FUNCTION [dbo].[DatabaseScalarFunction1]
(
    @param1 int,
    @param2 int
)
RETURNS INT
AS
BEGIN
    GOTO EXIT_PROC;  -- This should be flagged as a problem
    RETURN @param1 + @param2
EXIT_PROC:    
END
