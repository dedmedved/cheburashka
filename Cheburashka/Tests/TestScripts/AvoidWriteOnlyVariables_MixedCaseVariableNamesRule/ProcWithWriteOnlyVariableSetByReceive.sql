
create procedure ProcWithWriteOnlyVariableSetByReceive
as
begin
    declare @A int  -- @A is only written to. This should be flagged as a problem
    ;receive TOP (1) 
            @a      = 1
    FROM    dbo.JobQueue;
end

