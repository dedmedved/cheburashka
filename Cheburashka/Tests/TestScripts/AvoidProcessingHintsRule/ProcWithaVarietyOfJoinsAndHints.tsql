create proc ProcWithaVarietyOfJoinsAndHints 
as
begin
    select * 
    from Table1 a 
    join Table1 z
    on a.a = z.a
    inner loop join Table1 b
    on a.a = b.a
    inner hash join Table1 c
    on c.a = a.a
    inner merge join Table1 d
    on d.a = a.a
    left merge join Table1 e
    on e.a = a.a
    left loop join Table1 f
    on f.a = a.a
    full hash join Table1 g
    on g.a = a.a
    full join (
        select *
        from   Table1 h
    ) h
    on h.a = a.a
    full hash join (
        select *
        from   Table1 i
    ) i
    on i.a = a.a
    inner join Table1 j
    on j.a = a.a
    inner hash join ( Table1 k
                    inner hash join Table1 l
                    on k.a = l.a
                    )
    on l.a = a.a
    inner join ( Table1 m
                    inner join Table1 n
                    on m.a = n.a
                    )
    on m.a = a.a
end
go
