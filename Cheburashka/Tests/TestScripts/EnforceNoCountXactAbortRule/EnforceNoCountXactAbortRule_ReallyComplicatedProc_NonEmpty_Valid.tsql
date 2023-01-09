CREATE proc dbo.EnforceNoCountXactAbortRule_ReallyComplicatedProc_NonEmpty_Valid as
begin
    set nocount on
    begin
        set xact_abort on;
    end 
    begin
        set xact_abort, nocount off;
        begin try
            set xact_abort, nocount on;
        end try
        begin catch
            raiserror('',16,1) 
        end catch
    end
    
    select 1 as a

        set xact_abort, nocount off;
        set xact_abort, nocount on;
        set xact_abort, nocount off;


end
