CREATE FUNCTION [dbo].[ScalarFunctionWithInDirectUseOfRowcount] 
(
    @param1 int,
    @param2 char(5)
)
RETURNS int
as 
begin

  declare @r1 int, @r2 int
  set @r1 = @@rowcount; -- Uses @@rowcount indirectly. This is ok.
  select @r2= @@error; -- Uses @@error indirectly. This is ok.


  if @r1 = 1 return 1; 
  if @r2 = 1 return 1; 

end
