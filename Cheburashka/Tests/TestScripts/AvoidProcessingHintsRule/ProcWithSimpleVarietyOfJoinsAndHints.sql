create proc ProcWithSimpleVarietyOfJoinsAndHints 
as
begin
    select * 
    from dbo.Table1 a 
    full hash join dbo.Table1 g
    on g.a = a.a
    full join (
        select *
        from   dbo.Table1 h
    ) h
    on h.a = a.a
    inner hash join ( dbo.Table1 j 
            inner hash join dbo.Table1 k
            on k.a = j.a )
    on j.a = a.a
end
go
