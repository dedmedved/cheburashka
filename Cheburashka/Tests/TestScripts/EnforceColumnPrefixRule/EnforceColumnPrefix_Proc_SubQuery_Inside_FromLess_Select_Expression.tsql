create proc EnforceColumnPrefix_Proc_SubQuery_Inside_FromLess_Select_Expression
as
begin
declare @product varchar(10) = (select(((SELECT a FROM (SELECT 1 as a)p))));
end
