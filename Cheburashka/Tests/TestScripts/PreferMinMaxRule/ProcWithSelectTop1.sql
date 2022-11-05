CREATE PROCEDURE ProcWithSelectTop1
AS 
BEGIN
select top 1 b from TableA order by B;
select top 10 b from TableA order by B;
select top 1 percent b from TableA order by B;
select top 1 b from TableA order by C;
select (select top 1 b from TableA order by B);
select (select top 10 b from TableA order by B);
select (select top 1 percent b from TableA order by B);
select (select top 1 b from TableA order by C);

select top 1 b from TableA order by 1;

END
