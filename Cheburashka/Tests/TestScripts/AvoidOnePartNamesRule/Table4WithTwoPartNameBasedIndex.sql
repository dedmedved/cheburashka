﻿
create nonclustered index t4_ix2
on dbo.Table4 (a)       -- Table4 has a schema. This should NOT be flagged as a problem
go



