
create procedure ProcWithVariableThatIsWrittenToByFetchFromCursor
as
begin
    declare @A int  -- @A is set. This should NOT be flagged as a problem
    declare l cursor for select a from Table1
    open l
    fetch next from l into @A
    print isnull(@A, -1)
end