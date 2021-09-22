
create procedure ProcWithUnusedVariable
as
begin
    declare @A int  -- @A is unused. This should be flagged as a problem
end