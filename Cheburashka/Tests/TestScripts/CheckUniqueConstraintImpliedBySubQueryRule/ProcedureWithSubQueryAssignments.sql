CREATE proc dbo.ProcedureWithSubQueryAssignments
AS
DECLARE @a int 

set @a = (select a from dbo.Table1 where b = 3)                                                 -- ok
set @a = (select count(*) from dbo.Table1 where b = 3)                                          -- nonono
set @a = (select max(a) from dbo.Table1 where b = 3)                                            -- nonono
select * from Table1 where exists (select a from dbo.Table1 where b = 3)                        -- nonono
set @a = (select a from dbo.Table1 where b = 3 or a=1)                                          -- nonono
set @a = (select a from dbo.Table1 where b = 3 and a=1)                                         -- ok
set @a = (select a from dbo.Table1 where b = 3 and a=(select a from dbo.Table1 where b = 3))    --ok
set @a = (select a from dbo.Table1 where b = 3                                                  -- nonono
          union                                                                                 -- nonono
          select a from dbo.Table1 where b = 3)                                                 -- nonono
set @a = (select a from dbo.Table1 a                                                            -- nonono
          join dbo.Table1 b on a.a=b.a where b = 3)                                             -- nonono
set @a = (select a from dbo.Table1 a                                                            -- nonono
          join dbo.Table1 b on a.a=b.a )                                                        -- nonono
set @a = (select a from dbo.Table1 )                                                            -- nonono
--set @a = (with x as (select a from dbo.Table1) select a from x)                               -- invalid syntax
select * from Table1 where a > any (select a from dbo.Table1 where b = 3)                       -- nonono
select * from Table1 where a > all (select a from dbo.Table1 where b = 3)                       -- nonono
select * from Table1                                                                            -- nonono
cross apply (select a from dbo.Table1 where b = 3) x                     

set @a = (select a from dbo.Table1 where ((b = 3) and (a=1)))                                   -- ok
set @a = (select a from dbo.Table1 where not b != 3 and not a <> 1)                             -- ok
set @a = (select a from dbo.Table1 where (not (b != 3) and ( not a <> 1)))                      -- ok
set @a = (select a from dbo.Table1 where (not not not (b != 3) and ( not a <> 1)))              -- ok
set @a = (select a from dbo.Table1 where (not not not (b != 3) and ( not a  > 1)))              -- nonono
set @a = (select a from dbo.Table1 where b >= 3 and a  < 1)                                     -- nonono
set @a = (select a from dbo.Table1 where b !> 3 and a  !< 1)                                    -- nonono

set @a = (select a from dbo.Table1 where (not (b = 3 and a = 1)))                               -- nonono
set @a = (select a from dbo.Table1 where (not (b = 3 and a >= 1)))                              -- nonono
set @a = (select a from dbo.Table1 where not b != 3 and a >= 1)                                 -- nonono

set @a = (select a from dbo.View1 where b = 3 and a = 1)                                        -- nonono - because its a view
set @a = (select a from dbo.Table1 where (not (b != 3 and a <> 1)))                             -- nonono - not over and isn't right and 
set @a = (select a from dbo.Table1 where b+a=a*b)                                               -- nonono - 2 column references each side of =
set @a = (select a from dbo.Table1 where 1=1)                                                   -- nonono - no column references either side of =
set @a = (select a from dbo.Table1 where a=a*b)                                                 -- nonono - 2 column references one side of =
set @a = (select a from dbo.Table1 where a=1)                                                   -- OK 
set @a = (select a from dbo.Table1 where 1=a*b)                                                 -- nonono - 2 column references one side of =
set @a = (select a from Table1     where a = (select b from dbo.Table1 where b = 3) )           -- OK just 2 ? - -- accidentally broken as b referenced 2ce on rhs -- needs fixing to be broken where full stack analysis is done
set @a = (select a from Table1     where a != (select b from dbo.Table1 where b = 3) )          -- OK just 2 ? - -- accidentally broken as b referenced 2ce on rhs --- needs fixing to be broken where full stack analysis is done
set @a = (select a from Table1     where a = (select b2 from dbo.Table2 where b2 = 3) )         -- OK both 
set @a = (select a from Table1     where a != (select b2 from dbo.Table2 where b2 = 3) )        -- OK just 2
set @a = (select a from Table1     where not a != (select b2 from dbo.Table2 where b2 = 3) )    -- OK both 2
set @a = (select a from Table1     where a = (select b2 from dbo.Table2 where b2 = a) )         -- OK just 2
go 