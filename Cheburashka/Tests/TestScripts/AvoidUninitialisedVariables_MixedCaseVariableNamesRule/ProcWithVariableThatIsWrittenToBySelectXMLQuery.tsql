
create procedure ProcWithVariableThatIsWrittenToBySelectXMLQuery
as
begin
    DECLARE @A xml  -- @A is set. This should NOT be flagged as a problem
    select  @A = input_xml.query('/input/vehicleXML/OptionRequestApi')
    print cast( isnull(@a,'') as nvarchar(100))
end