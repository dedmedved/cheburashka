
create procedure ProcWithUnusedTableVariable
as
begin
    declare @A table (a int)  -- @A is unused. This should be flagged as a problem
end