﻿create table dbo.Table2 (a int
, constraint t2_chk_a check  (dbo.fn_chk(a) = 1) -- Table2 has a schema. This should NOT be flagged as a problem
)

