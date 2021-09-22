CREATE function dbo.FunctionWithSingleVariableInitialisedFromIntParameter(@par int)
RETURNS INTEGER
AS 
BEGIN
    declare @VAR INT = @par;
    RETURN @var;
END
GO