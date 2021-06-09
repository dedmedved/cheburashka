CREATE PROC InsertFromDMLDeleteProc
AS
BEGIN
    INSERT INTO TableC
    SELECT	B1
    ,		B2
    FROM
    (
        DELETE TableB
        OUTPUT	inserted.B1 AS B1
        ,		inserted.B2 AS B2
    )   z;


    INSERT INTO TableC
    SELECT	B1
    ,		B2
    FROM
    (
        DELETE TableB
        OUTPUT	inserted.B1 AS B1
        ,		inserted.B2 AS B2
        FROM    TableB
        ,       TableC
    )   z;

    DELETE TableB
    OUTPUT	inserted.B1 AS B1
    ,		inserted.B2 AS B2
    FROM    TableB
    ,       TableC

END;

