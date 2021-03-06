﻿CREATE PROC InsertFromDMLUpdateProc
AS
BEGIN
    INSERT INTO TableC
    SELECT	B1
    ,		B2
    FROM
    (
        UPDATE TableB
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
        UPDATE TableB
        SET B1 = C1
        ,   B2 = C2
        OUTPUT	inserted.B1 AS B1
        ,		inserted.B2 AS B2
        FROM    TableB
        ,       TableC
    )   z;

    UPDATE TableB
    SET B1 = C1
    ,   B2 = C2
    OUTPUT	inserted.B1 AS B1
    ,		inserted.B2 AS B2
    FROM    TableB
    ,       TableC

END;

