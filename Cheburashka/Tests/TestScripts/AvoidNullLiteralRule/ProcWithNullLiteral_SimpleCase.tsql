create procedure ProcWithNullLiteral_SimpleCase
as
begin
    SELECT a
    FROM dbo.table1
    WHERE case a  when 1 then 'one'
	              when 2 then 'two'
				  when null then 'null'
		  end = 'one'
end