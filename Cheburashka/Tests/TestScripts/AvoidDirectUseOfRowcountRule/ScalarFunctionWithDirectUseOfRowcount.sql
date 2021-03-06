CREATE FUNCTION [dbo].[ScalarFunctionWithDirectUseOfRowcount] 
(
    @param1 int,
    @param2 char(5)
)
RETURNS int
as 
begin

  if @@rowcount = 1 return 1; -- Uses @@rowcount directly . This should be flagged as a problem
  if @@error = 1 return 1; -- Uses @@error directly . This should be flagged as a problem

end
