create function EnforceColumnPrefix_InlineFunctionWithAggregateFunctions(    @asAtDate datetime2 = null)
RETURNS TABLE AS RETURN
(WITH 
  startDate         AS (SELECT year((ISNULL(@asAtDate,getutcdate())))*10000+month((ISNULL(@asAtDate,getutcdate())))*100 +1 AS startDateKey)
, endDate           AS (SELECT year((ISNULL(@asAtDate,getutcdate())))*10000+month((ISNULL(@asAtDate,getutcdate())))*100 +day(eomonth(ISNULL(@asAtDate,getutcdate()))) AS endDateKey)
, x as (select * from table1) 
select a.a, max(c) c 
from    x a 
left join 
        table2 b 
on a.a = b.a
group by a.a
)
;
go

