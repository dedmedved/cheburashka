
create procedure onelevelinlinequerieswithsubqueries
as
begin

declare @a int = (select  a.a
from    (
        select  a
        from    Table1 a
        ) a
        )
, @b int

select  @a = a.a
,       @b = a.a
from    (
        select  a
        from    Table1 a
        ) a

set @a = (select a.a
from    (
        select  a
        from    Table1 a
        ) a )


select  a.a
from    (
        select  a
        from    Table1 a
        where   a in ( select a.b from Table2 a)
        ) a
        

select  a.a
from    (
        select  a
        ,       (select b from Table2 a ) b
        from    Table1 a
        ) a

select  a.a
from    (
        select  a.a
        ,       (select t2.b) b
        from    Table1 a
        ,       Table2 t2
        )  a

-------------- union variants


select  a.a
from    (
        select  a
        from    Table1 a
        union 
        select  a
        from    Table1 a
        ) a

select  a.a
from    (
        select  a
        from    Table1 a
        where   a in ( select a.b from Table2 a)
        union 
        select  a
        from    Table1 a
        where   a in ( select a.b from Table2 a)
        ) a
        
select  a.a
from    (
        select  a
        ,       (select b from Table2 a ) 
        from    Table1 a
        union 
        select  a
        ,       (select b from Table2 a) 
        from    Table1 a
        ) a

select  a.a
from    (
        select  a.a
        ,       (select a.b)  
        from    Table1 a
        ,       Table2 t2
        union 
        select  t2.a
        ,       (select t2.b)  
        from    Table1 a
        ,       Table2 t2
        )   a
return 0

end