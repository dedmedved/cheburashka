
create procedure ProcWithVariableThatIsWrittenToByInsertExecute
as
begin
    declare @A int  -- @A is set. This should NOT be flagged as a problem
    insert into dbo.Table1
    exec @a = ProcWithVariableThatIsWrittenToByInsertExecute
    print isnull(@A, -1)
end