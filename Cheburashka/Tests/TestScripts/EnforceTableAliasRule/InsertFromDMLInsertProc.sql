CREATE PROC InsertFromDMLInsertProc
AS
BEGIN
    --INSERT INTO TableC
    --SELECT	B1
    --,		B2
    --FROM
    --(
    --    INSERT	INTO TableC
    --    OUTPUT	inserted.C1 AS B1
    --    ,		inserted.C2 AS B2
    --    SELECT	*
    --    FROM	TABLEB
    --)   z;


    INSERT INTO TableC
    SELECT	B1
    ,		B2
    FROM
    (
        INSERT	INTO TableC
        OUTPUT	inserted.C1 AS B1
        ,		inserted.C2 AS B2
        SELECT	C1
        ,       C2
        FROM	TABLEB
        ,   	TABLEC
    )   z;

        --INSERT	INTO TableC
        --OUTPUT	inserted.C1 AS B1
        --,		inserted.C2 AS B2
        --SELECT	C1
        --,       C2
        --FROM	TABLEB
        --,   	TABLEC

END;

