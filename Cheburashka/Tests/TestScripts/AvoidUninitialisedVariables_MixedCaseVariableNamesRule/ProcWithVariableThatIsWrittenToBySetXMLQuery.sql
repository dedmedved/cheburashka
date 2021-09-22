
create procedure ProcWithVariableThatIsWrittenToBySetXMLQuery
as
begin
    DECLARE @a xml  -- @A is set. This should NOT be flagged as a problem
    set  @A = input_xml.query('/input/vehicleXML/OptionRequestApi')
    print cast( isnull(@A,'') as nvarchar(100))
end