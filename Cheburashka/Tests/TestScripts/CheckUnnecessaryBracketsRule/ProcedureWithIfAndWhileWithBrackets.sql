CREATE proc dbo.ProcedureWithIfAndWhileWithBrackets
AS
    BEGIN
       IF 1=1      PRINT'a' 
       IF (1=1)    PRINT'a' 
       IF ((1=1))  PRINT'a' 
       IF 1=1     IF 1=1     PRINT'a' 
       IF (1=1)   IF (1=1)   PRINT'a' 
       IF ((1=1)) IF ((1=1)) PRINT'a' 
       IF 1=1      PRINT'a'  ELSE   IF 1=1     PRINT'a' 
       IF (1=1)    PRINT'a'  ELSE   IF (1=1)   PRINT'a' 
       IF ((1=1))  PRINT'a'  ELSE   IF ((1=1)) PRINT'a' 

       WHILE 1=1      PRINT'a'   IF 1=1     PRINT'a' 
       WHILE (1=1)    PRINT'a'   IF (1=1)   PRINT'a' 
       WHILE ((1=1))  PRINT'a'   IF ((1=1)) PRINT'a' 

       IF 1=1      PRINT'a'  WHILE 1=1     PRINT'a' IF 1=1     PRINT'a' 
       IF (1=1)    PRINT'a'  WHILE (1=1)   PRINT'a' IF (1=1)   PRINT'a' 
       IF ((1=1))  PRINT'a'  WHILE ((1=1)) PRINT'a' IF ((1=1)) PRINT'a' 


    END
go
