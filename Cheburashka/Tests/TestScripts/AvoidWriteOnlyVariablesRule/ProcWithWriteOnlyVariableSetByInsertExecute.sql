
create procedure ProcWithWriteOnlyVariableSetByInsertExecute
as
begin
    declare @A int  -- @A is only written to. This should be flagged as a problem
    insert into dbo.Table1
    exec @A = ProcWithWriteOnlyVariableSetByInsertExecute
end