
create procedure ProcWithWriteOnlyTempTable
as
begin
    create table #A (a int)  -- #A is unused. This should be flagged as a problem
    create table ##A (a int)  -- #A is unused but not flagged as maybe global temp tables require more slack to be cut
    insert into #A values (1)

    update taarg
    set a = 1
    from #A  taarg;

    update #A
    set a = 1

    update taarg
    set a = 1
    from (#A  taarg
    join #A t
    on t.a = taarg.a
    ) ;
    update taarg
    set a = 1
    from (#A  taarg
    join #A t
    on t.a != taarg.a
    )
	, #A x ;

    update taarg
    set a = 1
    from (#A  taarg
    join #A t
    on t.a != taarg.a
    )
	, #A ;

end