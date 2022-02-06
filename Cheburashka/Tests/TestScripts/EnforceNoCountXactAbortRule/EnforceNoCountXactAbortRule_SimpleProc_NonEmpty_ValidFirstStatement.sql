CREATE proc dbo.EnforceNoCountXactAbortRule_SimpleProc_NonEmpty_ValidFirstStatement as
set nocount,xact_abort on;
select 1 as a
