
create procedure ProcWithUnusedTempTable
as
begin
    create table #A (a int)  -- #A is unused. This should be flagged as a problem
    create table ##A (a int)  -- #A is unused but not flagged as maybe global temp tables require more slack to be cut
end