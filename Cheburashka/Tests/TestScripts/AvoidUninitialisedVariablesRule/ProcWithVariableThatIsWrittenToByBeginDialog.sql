
create procedure ProcWithVariableThatIsWrittenToByBeginDialog
as
begin
    declare @A UNIQUEIDENTIFIER  -- @A is set. This should NOT be flagged as a problem
    BEGIN DIALOG CONVERSATION @A
    from SERVICE [//Adventure-Works.com/ExpenseClient]
    to SERVICE '//Adventure-Works.com/Expenses'
    on CONTRACT [//Adventure-Works.com/Expenses/ExpenseSubmission] ;

    print isnull(@A, -1)
end