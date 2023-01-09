create proc ProcWithaVarietyOfTableHints 
as
begin
    select * 
    from Table1 a with (nolock)
    join Table1 z (nolock)
    on a.a = z.a
    inner join Table1 b (READPAST)
    on a.a = b.a
    inner join Table1 c
    on a.a = c.a
end
go
