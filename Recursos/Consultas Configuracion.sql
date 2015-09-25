-- Insert para los permisos al rol super administrador
insert into seguridad.permiso
select seguridad.rol.idrol, seguridad.funcionalidad.idfuncionalidad, seguridad.accion.idaccion
from seguridad.rol
	inner join seguridad.funcionalidad
    inner join seguridad.accion 
where seguridad.accion.idaccion < 6 and seguridad.funcionalidad.idfuncionalidad > 3;

insert into seguridad.funcionalidad_accion(funcionalidad_idfuncionalidad, accion_idaccion)
select seguridad.funcionalidad.idfuncionalidad, seguridad.accion.idaccion 
from seguridad.funcionalidad
	inner join seguridad.accion
where seguridad.accion.idaccion < 6 and seguridad.funcionalidad.idfuncionalidad > 3;