
create procedure ProcWithVariableThatIsWrittenToByReceive
as
begin
    declare @A int  -- @A is set. This should NOT be flagged as a problem
    ;receive TOP (1) 
            @A      = 1
    FROM    dbo.JobQueue;
    print isnull(@A, -1)
end