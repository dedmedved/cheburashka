﻿create table dbo.Table3 (a int
, constraint t3_chk_a check  (fn_chk(a) = 1) -- Table3 has no schema. This should be flagged as a problem
)

