
create procedure onelevelinlinequerieswithsubqueriesinApply
as
begin


-- pass
select  a.a
from    Table2 b
cross   apply
        (
        select  a
        from    Table1
        where   a=b.b
        ) a
-- pass
select  a.a
from    Table2 b
cross   apply
        (
        select  a
        from    Table1
        where   a in ( select t2.b from Table2 t2)
        and     a=b.b
        ) a
        
-- fail 
select  a.a
from    Table2 b
cross   apply
        (
        select  a
        ,       (select b from Table2) b
        from    Table1
        where   a=b.b
        ) a
-- fail 
select  a.a
from    Table2 b
cross   apply
        (
        select  t2.a
        ,       (select t2.b) b
        from    Table1 t1
        ,       Table2 t2
        where   t2.a=b.b
        )  a
-- fail 
select  a.a
from    Table2 b
cross   apply
        (
        select  t1.a
        ,       (select t2.b) b
        from    Table1 t1
        join    Table2 t2
        on      t1.a = t2.b
        where   t1.a=b.b
        )   a
-- fail 
select  a.a
from    Table2 b
cross   apply
        (
        select  t1.a
        ,       (select b from Table2) b
        from    Table1 t1
        join    Table2 t2
        on      t1.a = t2.b
        where   t1.a=b.b
        )   a
-- fail 
select  a.a
from    Table2 b
cross   apply
        (
        select  t2.a
        ,       (select t2.b) b
        from    Table1 t1
        join    Table2 t2
        on      t1.a = t2.b
        where   t1.a=b.b
        )   a
        
-- fail
select  a.a
from    Table2 b
cross   apply
        (
        select  a
        from    Table1
        where   a in ( select b from Table2)
        and     a=b.b
        )   a
-- fail
select  a.a
from    Table2 b
cross   apply
        (
        select  a
        from    Table1
        where   a > any ( select b from Table2)
        and     a=b.b
        ) a


-------------- union variants

-- pass
select  a.a
from    Table2 b
cross   apply
        (
        select  a
        from    Table1
        where   a=b.b
        union 
        select  a
        from    Table1
        where   a=b.b
        ) a
-- pass
select  a.a
from    Table2 b
cross   apply
        (
        select  a
        from    Table1
        where   a in ( select t2.b from Table2 t2)
        and     a=b.b
        union 
        select  a
        from    Table1
        where   a in ( select t2.b from Table2 t2)
        and     a=b.b
        ) a
        
-- fail 
select  a.a
from    Table2 b
cross   apply
        (
        select  a
        ,       (select b from Table2) b
        from    Table1
        where   a=b.b
        union 
        select  a
        ,       (select b from Table2) b
        from    Table1
        where   a=b.b
        ) a
-- fail 
select  a.a
from    Table2 b
cross   apply
        (
        select  t1.a
        ,       (select t2.b) b
        from    Table1 t1
        ,       Table2 t2
        where   t2.a=b.b
        union 
        select  t1.a
        ,       (select t2.b) b
        from    Table1 t1
        ,       Table2 t2
        where   t1.a=b.b
        )   a
-- fail 
select  a.a
from    Table2 b
cross   apply
        (
        select  t1.a
        ,       (select t2.b) b
        from    Table1 t1
        join    Table2 t2
        on      t1.a = t2.b
        where   t2.a=b.b
        union 
        select  t1.a
        ,       (select t1.b) b
        from    Table1 t1
        join    Table2 t2
        on      t1.a = t2.b
        where   t1.a=b.b
        )   a
-- fail 
select  a.a
from    Table2 b
cross   apply
        (
        select  t1.a
        ,       (select b from Table2) b
        from    Table1 t1
        join    Table2 t2
        on      t1.a = t2.b
        where   t1.a=b.b
        union 
        select  t1.a
        ,       (select b from Table2) b
        from    Table1 t1
        join    Table2 t2
        on      t1.a = t2.b
        where   t2.a=b.b
        )   a
-- fail 
select  a.a
from    Table2 b
cross   apply
        (
        select  t1.a
        ,       (select t2.b) b
        from    Table1 t1
        join    Table2 t2
        on      t1.a = t2.b
        where   t1.a=b.b
        union 
        select  t2.a
        ,       (select t2.b) b
        from    Table1 t1
        join    Table2 t2
        on      t1.a = t2.b
        where   t2.a=b.b
        )   a
        
-- fail
select  a.a
from    Table2 b
cross   apply
        (
        select  a
        from    Table1
        where   a in ( select b from Table2)
        and     a=b.b
        union 
        select  a
        from    Table1
        where   a in ( select b from Table2)
        and     a=b.b
        ) a
-- fail
select  a.a
from    Table2 b
cross   apply
        (
        select  a
        from    Table1
        where   a > any ( select b from Table2)
        and     a=b.b
        union 
        select  a
        from    Table1
        where   a > any ( select b from Table2)
        and     a=b.b
        ) a
        

return 0

end