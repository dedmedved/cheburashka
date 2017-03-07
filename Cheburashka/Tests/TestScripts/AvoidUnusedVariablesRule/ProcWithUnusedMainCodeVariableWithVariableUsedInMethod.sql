
create procedure ProcWithUnusedVariable
as
begin
    declare @A int = 0 -- @A is unused. This should be flagged as a problem
declare @x xml = N'<Product ProductID="771" ProductModelID="19" ProductModelName="Mountain 100" ListPrice="3399.99" DiscountPrice="2500" />'
select @x.query('<P>DiscountPrice="{ sql:variable("@A") }" </P>')
end