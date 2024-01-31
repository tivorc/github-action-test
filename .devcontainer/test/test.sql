use school

select 'hay ' + cast(count(*) as varchar(10)) + ' registros' as conteo
from teacher
