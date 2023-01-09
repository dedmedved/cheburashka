create trigger [ServerTriggerWithUninitialisedVariable] on all server
    for LOGON
as
begin 
    declare @a int      -- @A is uninitialised. This should be flagged as a problem
    print isnull(@A, -1)
end
