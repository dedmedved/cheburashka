CREATE PROCEDURE ProcWithTableDefinitions
AS 
BEGIN
CREATE table TableB
(       a int 
,       b char collate Latin1_General_CI_AI      -- problem
)
;

declare @TableC table
(       a int 
,       b char collate Latin1_General_CI_AI      -- problem
)
;

CREATE table #TableA
(       a int 
,       b char collate Latin1_General_CI_AI      -- problem
)
;
END
