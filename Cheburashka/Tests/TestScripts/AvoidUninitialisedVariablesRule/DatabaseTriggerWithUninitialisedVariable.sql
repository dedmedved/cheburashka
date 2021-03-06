create trigger [DatabaseTriggerWithUninitialisedVariable] on database
    for drop_synonym
as
begin
    declare @A int      -- @A is uninitialised. This should be flagged as a problem
    print isnull(@A, -1)
end
go
