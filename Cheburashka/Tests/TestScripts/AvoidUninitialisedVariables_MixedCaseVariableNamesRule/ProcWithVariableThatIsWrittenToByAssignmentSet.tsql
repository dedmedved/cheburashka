
create procedure ProcWithVariableThatIsWrittenToByAssignmentSet
as
begin
    declare @a int  -- @A is set. This should NOT be flagged as a problem
    update a
    set     @A = 1
    from    Table1 a
    print isnull(@A, -1)
end