
create procedure ProcWithNonLocalTempTable
as
begin
    select * from  #A
    select * from  ##A
end