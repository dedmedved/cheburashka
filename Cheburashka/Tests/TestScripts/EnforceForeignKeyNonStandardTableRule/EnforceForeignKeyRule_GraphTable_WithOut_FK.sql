CREATE TABLE dbo.sample_nodetable
(a int 
    INDEX ix_graphid UNIQUE ($node_id)
)
AS NODE
GO

CREATE TABLE dbo.sample_edgetable
(a int
    INDEX ix_graphid UNIQUE ($edge_id),
    INDEX ix_fromid ($from_id, $to_id),
    INDEX ix_toid ($to_id, $from_id)
)
AS EDGE
GO
