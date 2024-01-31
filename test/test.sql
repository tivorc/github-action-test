use school

select case when count(id) = 56 then 'hay 56 registros' else 'el conteo no es correcto' end as is_correct_count
from teacher
