CREATE PROC EnforceColumnPrefix_Proc_SingleSourceSQL_With_Merge_Source
AS BEGIN

        INSERT INTO     Table1 (a)
        SELECT  a
        FROM
                (
                MERGE Table1 t
                USING Table2 s
                ON t.a = s.a
                WHEN MATCHED THEN
                        UPDATE SET b = s.b
                WHEN NOT MATCHED BY TARGET THEN
                        INSERT  (a, b)
                        VALUES
                        (a, b)
                WHEN NOT MATCHED BY SOURCE THEN
                        DELETE
                OUTPUT $action AS Action
              , s.*
                ) AS changes_made
        WHERE   action = 'UPDATE' ;

END ;
