﻿create proc ProcWithAllVariablesOK @var1 int output, @var2 int output
as
begin
declare @rc int 
declare @a int = 1
declare @b int = 2
exec @rc = ProcWithAllVariablesOK @var1 = @a output, @var2 = @B output
end
go