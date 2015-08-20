
-- Insert para los permisos al rol super administrador
insert into permiso
select rol.idrol, funcionalidad.idfuncionalidad, accion.idaccion
from rol
	inner join funcionalidad
    inner join accion 
    where accion.idaccion not in (4);