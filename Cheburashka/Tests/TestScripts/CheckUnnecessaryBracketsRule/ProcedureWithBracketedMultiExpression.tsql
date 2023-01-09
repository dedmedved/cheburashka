CREATE proc dbo.ProcedureWithBracketedMultiExpression
AS
if ( 1=1 and 2=2 ) begin
    select * 
    from    Table5 a
    INNER JOIN    Table5 b ON (a.a = b.a and b.a=a.a) 
end

if ( 1=1 or 2=2 ) begin
    select * 
    from    Table5 a
    INNER JOIN    Table5 b ON ((a.a = b.a and b.a=a.a) )
end

if ((1=1) or (2=2)) begin
    select * 
    from    Table5 a
    INNER JOIN    Table5 b ON ((a.a = b.a) and (b.a=a.a)) 
end
if ((1=1) or (2=2) and (3=3)) begin
    select * 
    from    Table5 a
    INNER JOIN    Table5 b ON (a.a = b.a and (b.a=a.a or a.a=a.a)) 
end

go
