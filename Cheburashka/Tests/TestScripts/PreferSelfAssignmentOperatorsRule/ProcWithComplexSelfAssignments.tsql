CREATE PROCEDURE ProcWithComplexSelfAssignments
AS 
BEGIN
declare @a int = 0;
update TableA
set a = a+1+1             
, @a = 1+@a +1           
set @a=@a+@a+1;         
set @a=@a+1+@a;         -- picked up
set @a=1-@a +@a;        -- picked up
update TableA
set a = a-1-a
, @a = -@a+@a-1
, a = a-1-a 
END
