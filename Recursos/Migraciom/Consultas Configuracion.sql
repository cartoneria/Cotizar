-- Insert para los permisos al rol super administrador
insert into seguridad_permiso
select seguridad_rol.idrol, seguridad_funcionalidad.idfuncionalidad, seguridad_accion.idaccion
from seguridad_rol
	inner join seguridad_funcionalidad
    inner join seguridad_accion 
where seguridad_accion.idaccion < 6 and seguridad_funcionalidad.idfuncionalidad > 3;

insert into seguridad_funcionalidad_accion(funcionalidad_idfuncionalidad, accion_idaccion)
select seguridad_funcionalidad.idfuncionalidad, seguridad_accion.idaccion 
from seguridad_funcionalidad
	inner join seguridad_accion
where seguridad_accion.idaccion < 6 and seguridad_funcionalidad.idfuncionalidad > 3;