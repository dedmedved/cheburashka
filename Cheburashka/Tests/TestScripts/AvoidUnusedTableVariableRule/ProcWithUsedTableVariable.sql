
create procedure ProcWithUsedTableVariable
as
begin
    declare @A table (a int)  -- @A is unused. This should be flagged as a problem
    insert into @A values(1)
end