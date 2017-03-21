
create procedure ProcWithUnusedMainCodeVariableWithVariableUsedInMethod
as
begin
    declare @A int = 0 -- @A is unused. This should be flagged as a problem
declare @x xml = N'';
select @x.query('<P>DiscountPrice="{ sql:variable("@A") }" </P>');
-- !! The argument 1 of the XML data type method "query" must be a string literal.
end