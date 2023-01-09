CREATE PROCEDURE ProcWithTableDefinitions
AS 
BEGIN
CREATE table TableB
(       a int not null
,       b int null
,       c int       -- problem
);

declare @TableC table
(       a int not null
,       b int null
,       c int       -- problem
);

CREATE table #TableA
(       a int not null
,       b int null
,       c int       -- problem
);
CREATE table TableC
(       a int not null
,       b int null
,       c as a*b persisted -- no problem
);
END
