
create procedure ProcWithParameterOnlyUsedInMethod @A int
as
begin
declare @x xml = N'';
select @x.query('<P>DiscountPrice="{ sql:variable("@A") }" </P>');
-- !! The argument 1 of the XML data type method "query" must be a string literal.
end