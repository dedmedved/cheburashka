﻿create table dbo.Table4 (a int)
go
create nonclustered index t4_ix1
on Table4 (a)       -- Table4 has no schema. This should be flagged as a problem
go



