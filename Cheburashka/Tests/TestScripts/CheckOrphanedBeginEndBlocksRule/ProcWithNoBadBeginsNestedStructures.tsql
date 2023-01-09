CREATE PROCEDURE dbo.ProcWithNoBadBeginsNestedStructures
AS
BEGIN
    DECLARE @RC INT;
    WHILE 1 = 1
    BEGIN TRY
        EXEC @RC = dbo.ProcWithReturn;
        WHILE 1 = 1
        BEGIN
            EXEC @RC = dbo.ProcWithReturn;
            IF 1 = 1
            BEGIN
                EXEC @RC = dbo.ProcWithReturn;
                IF 1 = 1
                BEGIN
                    EXEC @RC = dbo.ProcWithReturn;
                END;
                ELSE
                BEGIN
                    RETURN;
                END;
            END;
        END;
    END TRY
    BEGIN CATCH
        RETURN;
    END CATCH;
    RETURN;
END;