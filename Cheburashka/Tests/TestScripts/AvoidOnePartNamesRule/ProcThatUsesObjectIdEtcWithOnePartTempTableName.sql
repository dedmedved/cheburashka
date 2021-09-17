
create procedure dbo.ProcThatUsesObjectIdEtcWithOnePartTempTableName  
as
select object_id('msdb..#Table1')              -- has no schema name in literal.  This is OK as its a temp object.
select index_col('msdb..#Table1',1,1)          -- has no schema name in literal.  This is OK as its a temp object.
select type_id  ('msdb..#Table1')              -- has no schema name in literal.  This is OK as its a temp object.
