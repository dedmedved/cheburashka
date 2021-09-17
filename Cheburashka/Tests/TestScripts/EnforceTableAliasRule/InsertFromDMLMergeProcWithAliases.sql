CREATE PROC InsertFromDMLMergeProcWithAliases
AS
BEGIN
    INSERT INTO TableC
    SELECT	B1
    ,		B2
    FROM
    (
        MERGE TableB   tgt
        USING TableB   src
        ON B1 = B1
        WHEN MATCHED THEN UPDATE 
        SET B1 = GETDATE()
        ,   B2 = GETUTCDATE()
        OUTPUT	inserted.B1 AS B1
        ,		inserted.B2 AS B2
    )   z;


    INSERT INTO TableC
    SELECT	B1
    ,		B2
    FROM
    (
        MERGE TableB  tgt
        USING TableC  src
        ON B1 = C1
        WHEN MATCHED THEN UPDATE 
        SET B1 = C1
        ,   B2 = C2
        OUTPUT	inserted.B1 AS B1
        ,		inserted.B2 AS B2
    )   z;

        MERGE TableB  tgt
        USING TableC  src
        ON B1 = C1
        WHEN MATCHED THEN UPDATE 
        SET B1 = C1
        ,   B2 = C2
        OUTPUT	inserted.B1 AS B1
        ,		inserted.B2 AS B2;


END;

