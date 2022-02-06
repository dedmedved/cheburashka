CREATE proc dbo.ProcedureWithInsertFromMergeWithMissingColumns_NULL
AS
insert  into 
        Table1 (a) 
select a
from    (
        merge   into
        Table1  trg
        using   (select 1 as a, 1 as b, 1 as c) src
        on      src.a = trg.a
        when not matched by target
        then insert (a) values (src.a)
        output inserted.a
) src
;

go