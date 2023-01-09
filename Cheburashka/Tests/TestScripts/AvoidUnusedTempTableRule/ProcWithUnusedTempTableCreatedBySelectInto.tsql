
create procedure ProcWithUnusedTempTableCreatedBySelectInto
as
begin
    select * into #A from Table1  -- #A is unused. This should be flagged as a problem
    select * into ##A from Table1  -- ##A is unused but not flagged as maybe global temp tables require more slack to be cut
end