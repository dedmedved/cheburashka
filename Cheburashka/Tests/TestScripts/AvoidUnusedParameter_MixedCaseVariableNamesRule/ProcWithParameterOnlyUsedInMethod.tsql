
create procedure ProcWithParameterOnlyUsedInMethod @A int
as
begin
declare @X xml = N'';
select @x.query('<P>DiscountPrice="{ sql:variable("@a") }" </P>');
-- !! The argument 1 of the XML data type method "query" must be a string literal.
end