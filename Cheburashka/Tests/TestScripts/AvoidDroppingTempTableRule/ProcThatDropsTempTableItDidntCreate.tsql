
create procedure ProcThatDropsTempTableItDidntCreate
as
begin
    drop table #A ;     -- not flagged - table was created in some other scope
    drop table ##A ;    -- not flagged - table was created in some other scope adn its global
end