
create procedure onelevelinlinequerieswithsubqueries
as
begin

-- pass
select  a.a
from    (
        select  a
        from    Table1
        ) a
-- pass
select  a.a
from    (
        select  a
        from    Table1
        where   a in ( select t2.b from Table2 t2)
        ) a
        
-- fail 
select  a.a
from    (
        select  a
        ,       (select b from Table2) b
        from    Table1
        ) a
-- pass 
select  a.a
from    (
        select  t1.a
        ,       (select t2.b) b
        from    Table1 t1
        ,       Table2 t2
        )  a
-- pass 
select  a.a
from    (
        select  t1.a
        ,       (select t2.b) b
        from    Table1 t1
        join    Table2 t2
        on      t1.a = t2.b
        )   a
-- fail 
select  a.a
from    (
        select  t1.a
        ,       (select b from Table2) b
        from    Table1 t1
        join    Table2 t2
        on      t1.a = t2.b
        )   a
-- pass 
select  a.a
from    (
        select  t2.a
        ,       (select t2.b) b
        from    Table1 t1
        join    Table2 t2
        on      t1.a = t2.b
        )   a
        
-- fail
select  a.a
from    (
        select  a
        from    Table1
        where   a in ( select b from Table2)
        )   a
-- fail
select  a.a
from    (
        select  a
        from    Table1
        where   a > any ( select b from Table2)
        ) a


-------------- union variants

-- pass
select  a.a
from    (
        select  a
        from    Table1
        union 
        select  a
        from    Table1
        ) a
-- pass
select  a.a
from    (
        select  a
        from    Table1
        where   a in ( select t2.b from Table2 t2)
        union 
        select  a
        from    Table1
        where   a in ( select t2.b from Table2 t2)
        ) a
        
-- fail 
select  a.a
from    (
        select  a
        ,       (select b from Table2) b
        from    Table1
        union 
        select  a
        ,       (select b from Table2) b
        from    Table1
        ) a
-- pass 
select  a.a
from    (
        select  t1.a
        ,       (select t2.b) b
        from    Table1 t1
        ,       Table2 t2
        union 
        select  t2.a
        ,       (select t2.b) b
        from    Table1 t1
        ,       Table2 t2
        )   a
-- pass 
select  a.a
from    (
        select  t1.a
        ,       (select t2.b) b
        from    Table1 t1
        join    Table2 t2
        on      t1.a = t2.b
        union 
        select  t1.a
        ,       (select t1.b) b
        from    Table1 t1
        join    Table2 t2
        on      t1.a = t2.b
        )   a
-- fail 
select  a.a
from    (
        select  t1.a
        ,       (select b from Table2) b
        from    Table1 t1
        join    Table2 t2
        on      t1.a = t2.b
        union 
        select  t1.a
        ,       (select b from Table2) b
        from    Table1 t1
        join    Table2 t2
        on      t1.a = t2.b
        )   a
-- pass 
select  a.a
from    (
        select  t1.a
        ,       (select t2.b) b
        from    Table1 t1
        join    Table2 t2
        on      t1.a = t2.b
        union 
        select  t2.a
        ,       (select t2.b) b
        from    Table1 t1
        join    Table2 t2
        on      t1.a = t2.b
        )   a
        
-- fail
select  a.a
from    (
        select  a
        from    Table1
        where   a in ( select b from Table2) 
        union 
        select  a
        from    Table1
        where   a in ( select b from Table2)
        ) a
-- fail
select  a.a
from    (
        select  a
        from    Table1
        where   a > any ( select b from Table2)
        union 
        select  a
        from    Table1
        where   a > any ( select b from Table2)
        ) a
        

return 0

end