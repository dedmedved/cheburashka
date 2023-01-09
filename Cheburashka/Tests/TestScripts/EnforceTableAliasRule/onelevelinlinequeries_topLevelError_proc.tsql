create procedure onelevelinlinequeries_topLevelError
as
begin

-- horrendous - lower level problems are ignored completely.

-- single source selects

select  a
from    (
        select  t1.a
        from    Table1 t1
        ,       Table2 t2
        ) a
                
                
select  a
from    (
        select  t1.a
        from    Table1 t1
        ,       Table2 t2
        where   t1.a=t2.b
        ) a

select  a
from    (
        select  t1.a
        from    Table1 t1
        join    Table2 t2
        on      t1.a=t2.b
        ) a

select  a
from    (
        select  t1.a
        from    Table1 t1
        join    Table2 t2
        on      t1.a=t2.b
        join    Table3 t3
        on      t2.b=t3.c
        ) a

select  a
from    (
        select  t1.a
        from    (
                Table1 t1
        join    Table2 t2
        on      t1.a=t2.b
                ) 
        join    Table3 t3
        on      t2.b=t3.c
        ) a

select  a
from    (
        select  t1.a
        from    Table1 t1
        join    Table2 t2
        join    Table3 t3
        on      t2.b=t3.c
        on      t1.a=t2.b
        ) a

select  a
from    (
        select  1 as a
        from    Table1 t1
        ,       Table2 t2
        join    Table3 t3
        on      t2.b=t3.c
        where   t1.a=t2.b
        ) a

------------- now with a join

select  a.a
from    (
        select  t1.a
        from    Table1 t1
        ,       Table2 t2
        ) a
,       (
        select  t1.a
        from    Table1 t1
        ,       Table2 t2
        ) b
                
                
select a. a
from    (
        select  t1.a
        from    Table1 t1
        ,       Table2 t2
        where   t1.a=t2.b
        ) a
join    (
        select  t1.a
        from    Table1 t1
        ,       Table2 t2
        where   t1.a=t2.b
        ) b
on      a.a=b.a        

select  a.a
from    (
        select  t1.a
        from    Table1 t1
        join    Table2 t2
        on      t1.a=t2.b
        ) a
join    (
        select  t1.a
        from    Table1 t1
        join    Table2 t2
        on      t1.a=t2.b
        ) b
on      a.a=b.a        

select  a.a
from    (
        select  t1.a
        from    Table1 t1
        join    Table2 t2
        on      t1.a=t2.b
        join    Table3 t3
        on      t2.b=t3.c
        ) a
join    (
        select  t1.a
        from    Table1 t1
        join    Table2 t2
        on      t1.a=t2.b
        join    Table3 t3
        on      t2.b=t3.c
        ) b
on      a.a=b.a        

select  a.a
from    (
        select  t1.a
        from    (
                Table1 t1
        join    Table2 t2
        on      t1.a=t2.b
                ) 
        join    Table3 t3
        on      t2.b=t3.c
        ) a
join    (
        select  t1.a
        from    (
                Table1 t1
        join    Table2 t2
        on      t1.a=t2.b
                ) 
        join    Table3 t3
        on      t2.b=t3.c
        ) b
on      a.a=b.a        

select  a.a
from    (
        select  t1.a
        from    Table1 t1
        join    Table2 t2
        join    Table3 t3
        on      t2.b=t3.c
        on      t1.a=t2.b
        ) a
join    (
        select  t1.a
        from    Table1 t1
        join    Table2 t2
        join    Table3 t3
        on      t2.b=t3.c
        on      t1.a=t2.b
        ) b
on      a.a=b.a        

select  a.a
from    (
        select  t1.a
        from    Table1 t1
        ,       Table2 t2
        join    Table3 t3
        on      t2.b=c
        where   t1.a=t2.b
        ) a
join    (
        select  t1.a
        from    Table1 t1
        ,       Table2 t2
        join    Table3 t3
        on      t2.b=c
        where   t1.a=t2.b
        ) b
on      a.a=b.a        


end

