
create procedure ProcWithUnInitialsiedTempTableCreatedBySelectInto
as
begin
    select * into #A from Table1    -- #A is is not uninitialised - not a problem
end