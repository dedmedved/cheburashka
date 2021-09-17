CREATE FUNCTION [dbo].[TableValuedFunctionWithDirectUseOfRowcount]
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
    INSERT @returntable
    SELECT   @@rowcount, cast(@@error as varchar); -- Uses @@rowcount and @@error directly . This should be flagged as a problem
    RETURN
END
