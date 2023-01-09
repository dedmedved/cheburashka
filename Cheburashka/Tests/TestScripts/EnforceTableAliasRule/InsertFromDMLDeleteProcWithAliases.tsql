CREATE PROC InsertFromDMLDeleteProcWithAliases
AS
BEGIN
    INSERT INTO TableC
    SELECT	B1
    ,		B2
    FROM
    (
        DELETE B
        OUTPUT	deleted.B1 AS B1
        ,		deleted.B2 AS B2
        FROM   TableB B
    )   z;


    INSERT INTO TableC
    SELECT	B1
    ,		B2
    FROM
    (
        DELETE B
        OUTPUT	deleted.B1 AS B1
        ,		deleted.B2 AS B2
        FROM    TableB B
        ,       TableC C
    )   z;

    DELETE B
    OUTPUT	deleted.B1 AS B1
    ,		deleted.B2 AS B2
    FROM    TableB B
    ,       TableC C

END;

