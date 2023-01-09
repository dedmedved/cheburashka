CREATE proc dbo.ProcedureWithSubQueryAssignmentsWithIndexes
AS
DECLARE @a int 

set @a = (select a from dbo.indexedTable1 where b = 3)                                                 -- ok
set @a = (select a from dbo.indexedTable1 where b = 3 and a=1)                                         -- ok
set @a = (select a from dbo.indexedTable1 where b = 3 and a=(select a from dbo.indexedTable1 where b = 3))    --ok
set @a = (select a from dbo.indexedTable1 where ((b = 3) and (a=1)))                                   -- ok
set @a = (select a from dbo.indexedTable1 where not b != 3 and not a <> 1)                             -- ok
set @a = (select a from dbo.indexedTable1 where (not (b != 3) and ( not a <> 1)))                      -- ok
set @a = (select a from dbo.indexedTable1 where (not not not (b != 3) and ( not a <> 1)))              -- ok
set @a = (select a from dbo.indexedTable1 where a=1)                                                   -- a isn't indexed
set @a = (select a from indexedTable1     where a = (select b from dbo.indexedTable1 where b = 3) )    -- OK just 2 ? - - -- accidentally broken as b referenced 2ce on rhs --needs fixing to be broken where full stack analysis is done
set @a = (select a from indexedTable1     where a != (select b from dbo.indexedTable1 where b = 3) )   -- OK just 2 ? - - -- accidentally broken as b referenced 2ce on rhs --needs fixing to be broken where full stack analysis is done
set @a = (select a from indexedTable1     where a = (select b2 from dbo.Table2 where b2 = 3) )         -- OK both - a isn't indexed
set @a = (select a from indexedTable1     where a != (select b2 from dbo.Table2 where b2 = 3) )        -- OK just 2
set @a = (select a from indexedTable1     where not a != (select b2 from dbo.Table2 where b2 = 3) )    -- OK both 2 
set @a = (select a from indexedTable1     where a = (select b2 from dbo.Table2 where b2 = a) )         -- OK just 2 -- accidentally broken as a referenced 2ce on rhs
go 