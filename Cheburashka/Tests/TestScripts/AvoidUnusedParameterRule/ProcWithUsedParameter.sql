
create procedure ProcWithUsedParameter @UsedParameter  int -- @UnedParameter is used. This should is NOT a problem
as
    select @UsedParameter