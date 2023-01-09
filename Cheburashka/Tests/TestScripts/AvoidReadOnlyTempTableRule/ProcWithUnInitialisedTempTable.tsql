
create procedure ProcWithUnInitialisedTempTable
as
begin
    create table #A (a int)   -- #A is uninitialised. This should be flagged as a problem
    create table ##A (a int)  -- #A is uninitialised but not flagged as maybe global temp tables require more slack to be cut
    select * from #A;
    select * from ##A;
end