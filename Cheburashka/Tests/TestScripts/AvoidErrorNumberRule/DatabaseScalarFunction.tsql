CREATE FUNCTION [dbo].[DatabaseScalarFunction]
(
    @param1 int,
    @param2 int
)
RETURNS INT
AS
BEGIN
    RETURN @param1 + @param2 + @@ERROR -- This should be flagged as a problem
  
END
