CREATE FUNCTION [dbo].[DatabaseScalarFunction]
(
    @param1 int,
    @param2 int
)
RETURNS INT
AS
BEGIN
    GOTO EXIT_PROC;  

EXIT_PROC:    
EXIT_PROC2:    -- This should be flagged as a problem
    RETURN @param1 + @param2
END
