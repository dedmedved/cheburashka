
create procedure dbo.ProcThatUsesObjectIdEtcWithOnePartObjectName  
as
select object_id('Table1')                  -- no schema name in literal. this is an error
select index_col('Table1',1,1)              -- no schema name in literal. this is an error
select type_id('Table1')                    -- no schema name in literal. this is an error


select type_id('datetime')                  -- no schema name in literal. this is NOT an error as datetime is a builtin
