﻿create view dbo.ViewWithCTEInSelect 
as 
with x as (select * from dbo.Table1 )
select a.a from [x] a -- [x] is a cte name this should NOT be flagged as a problem
        ,     "x" b -- nor should the other quoted variety
        ,      x  c -- nor should the unquoted variety
GO
