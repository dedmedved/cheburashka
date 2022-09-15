create proc ProcWithVariousPathologicalUpdateStatements
as

UPDATE t1
SET	t1.v = t2.v
FROM dbo.Table1 t1
JOIN dbo.Table2 t2
ON t2.Id = t1.Id

UPDATE t1
SET	t1.v = t2.v
FROM ( dbo.Table1 t1
JOIN dbo.Table2 t2
ON t2.Id = t1.Id
)

UPDATE t1
SET	t1.v = t2.v
FROM ( ( dbo.Table1 t1
JOIN dbo.Table2 t2
ON t2.Id = t1.Id
) )

UPDATE t1
SET	t1.v = t2.v
FROM ( ( dbo.Table1 t1
JOIN dbo.Table2 t2
ON t2.Id = t1.Id )
JOIN dbo.Table3 t3
ON t3.Id = t1.Id
) 

UPDATE t1
SET	t1.v = t3.v
FROM dbo.Table1 t1
JOIN dbo.Table2 t2
JOIN dbo.Table3 t3
ON t3.Id = t2.Id
ON t2.Id = t1.Id 

;WITH base AS (
SELECT t1.Id,t2.v,t1.dscr FROM dbo.Table1 t1
JOIN dbo.Table2 t2
ON t2.Id = t1.Id
)
UPDATE t1
SET	t1.v = t3.v
FROM base t1
JOIN dbo.Table2 t2
JOIN dbo.Table3 t3
ON t3.Id = t2.Id
ON t2.Id = t1.Id 

-- Msg 4405, Level 16, State 1, Line 38
-- View or function 't1' is not updatable because the modification affects multiple base tables.

;WITH base AS (
SELECT t1.Id,t2.v,t1.dscr FROM dbo.Table1 t1
JOIN dbo.Table2 t2
ON t2.Id = t1.Id
)
UPDATE t1
SET	t1.v = t3.v
,	t1.dscr = t3.dscr
FROM base t1
JOIN dbo.Table2 t2
JOIN dbo.Table3 t3
ON t3.Id = t2.Id
ON t2.Id = t1.Id 