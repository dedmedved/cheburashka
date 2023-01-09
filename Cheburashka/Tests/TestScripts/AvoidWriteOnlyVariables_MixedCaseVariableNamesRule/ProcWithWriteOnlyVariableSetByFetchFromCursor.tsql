
create procedure ProcWithWriteOnlyVariableSetByFetchFromCursor
as 
begin
    declare @A int  -- @A is only written to. This should be flagged as a problem
    declare l cursor for select a from Table1
    open l
    fetch next from l into @a
end