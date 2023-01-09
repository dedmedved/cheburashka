create proc EnforceColumnPrefix_Proc_SubqueryWithOutAggregateFunctionAndExists
as
begin
		select a
		from dbo.Table1 vf
		where a = 1
		and b = (select c from dbo.Table2 x) --not ok
		and exists 
			(
				select a from dbo.Table3 d
				where c >=1.00
				and vf.a= d.a
			)

end
