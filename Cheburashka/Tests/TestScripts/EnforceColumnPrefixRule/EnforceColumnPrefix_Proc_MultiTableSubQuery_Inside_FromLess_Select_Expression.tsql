create proc EnforceColumnPrefix_Proc_MultiTableSubQuery_Inside_FromLess_Select_Expression
as
begin
declare @product varchar(10) = (select(((SELECT a FROM (SELECT 1 as a)p1 cross join (select 2 as b)p2))));
end
