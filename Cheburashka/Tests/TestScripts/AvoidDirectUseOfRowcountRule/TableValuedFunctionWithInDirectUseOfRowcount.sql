CREATE FUNCTION [dbo].[TableValuedFunctionWithInDirectUseOfRowcount]
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
  declare @r1 int, @r2 int
  set @r1 = @@rowcount; -- Uses @@rowcount indirectly. This is ok.
  select @r2= @@error; -- Uses @@error indirectly. This is ok.

    INSERT @returntable
    SELECT   @r1, cast(@r2 as varchar); 
    RETURN
END
