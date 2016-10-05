create type dbo.userDefType as table
(   Id              int             not null 
,   StartDate       date            not null
,   EndDate         date            not null
,   check           (StartDate <= EndDate)
)

go

create procedure ProcWithUserDefinedDataTypeThatMayOrMayNotBeATableType
as
begin
    declare @A dbo.userDefType  -- User defined type - we can't be sure its not a table type. This should NOT be flagged as a problem - avoid FALSE positives
    print isnull(@A, -1)
end

