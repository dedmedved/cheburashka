create table  dbo.Table5
(       a int not null
,       b int 
)
go
create index IX_TABLE5_01 on dbo.Table5 (b)
go

CREATE view dbo.ViewWithDoubledBrackets
AS
          SELECT 1 as a FROM dbo.Table5 WHERE 1=1
union all SELECT 1 as a FROM dbo.Table5 WHERE (1=1)
union all SELECT 1 as a FROM dbo.Table5 WHERE ((1=1))                                          --bad
union all SELECT 1 as a FROM dbo.Table5 WHERE (1=1) AND a = ((b + a ) + a)
union all SELECT 1 as a FROM dbo.Table5 WHERE (1=1) AND a = (((b + a )) + a)                   --bad
union all SELECT 1 as a FROM dbo.Table5 WHERE EXISTS ((SELECT 1 FROM dbo.Table5))              --bad
union all SELECT 1 as a FROM dbo.Table5 WHERE ((EXISTS (SELECT 1 FROM dbo.Table5)))            --bad
union all SELECT 1 as a FROM dbo.Table5 WHERE (1=1 and EXISTS (SELECT 1 FROM dbo.Table5))
union all SELECT 1 as a FROM dbo.Table5 WHERE (EXISTS (SELECT 1 FROM dbo.Table5))
go
