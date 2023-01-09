create table  dbo.Table7
(       a int not null
,       b int 
)
go
create index IX_Table7_01 on dbo.Table7 (b)
go

CREATE view dbo.ViewWithBracketedJoinExpressions
AS
          SELECT 1 as a 
          FROM (dbo.Table7 a
                join dbo.Table7 b
                on a.a=b.a
                join dbo.Table7 c
                on a.a=c.a
                )
union
          SELECT 1 as a 
          FROM ( dbo.Table7 a
                join ( dbo.Table7 b
                     join   dbo.Table7 c
                     on b.a=c.a
                     )
                on a.a=b.a)
union
          SELECT 1 as a 
          FROM ( dbo.Table7 a
                join ( dbo.Table7 b
                        join   dbo.Table7 c
                        join   dbo.Table7 d
                        on d.a=c.a
                        on b.a=c.a
                     )
                on a.a=b.a)
union
          SELECT 1 as a 
          FROM  dbo.Table7 a
          join (dbo.Table7 b
                join  dbo.Table7 c
                on b.a=c.a
                )
          on a.a=b.a
union
          SELECT 1 as a 
          FROM  dbo.Table7 a
          left join (dbo.Table7 b
                join  dbo.Table7 c
                on b.a=c.a
                )
          on a.a=b.a
          left join (dbo.Table7 x
                join  dbo.Table7 y
                on y.a=x.a
                )
          on a.a=x.a
union
          SELECT 1 as a 
          FROM (dbo.Table7 a
                join dbo.Table7 b
                on a.a=b.a
                )
          join dbo.Table7 c
          on a.a=c.a
go
