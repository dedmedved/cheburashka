
create procedure ProcWithWriteOnlyVariableSetByBeginDialog
as
begin
    declare @A UNIQUEIDENTIFIER  -- @A is only written to. This should be flagged as a problem
    BEGIN DIALOG CONVERSATION @a
    from SERVICE [//Adventure-Works.com/ExpenseClient]
    to SERVICE '//Adventure-Works.com/Expenses'
    on CONTRACT [//Adventure-Works.com/Expenses/ExpenseSubmission] ;
end