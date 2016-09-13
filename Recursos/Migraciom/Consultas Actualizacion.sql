update seguridad.accion set activo = 1 where idaccion > 0;

update seguridad.empresa set activo = 1 where idempresa > 0;

update seguridad.funcionalidad set activo = 1 where idfuncionalidad > 0;

update seguridad.funcionalidad set visible = 1 where idfuncionalidad > 0;

update seguridad.rol set activo = 1 where idrol > 0;

update seguridad.usuario set activo = 1 where idusuario > 0;

update seguridad.periodo set vigente = 1 where idPeriodo = 1;


update produccion.accesorio set activo =1 where idaccesorio > 0;

update produccion.insumo set activo = 1 where idinsumo > 0;

update produccion.maquina set activo = 1 where idmaquina > 0;

update produccion.maquinadatosperiodos set activo = 1 where idmaquinadatosperiodos > 0;

update produccion.maquinavariprod set activo = 1 where idVariacion > 0;

update produccion.proveedor set activo = 1 where idproveedor > 0;

update produccion.proveedor_linea set activo = 1 where idproveedor_linea > 0;


update `general`.`departamento` set activo = 1 where iddepartamento > 0;

update `general`.`itemlista` set activo = 1 where iditemlista > 0;

update `general`.municipio set activo =1 where idmunicipio > 0;


update comercial.asesor set activo = 1 where idasesor > 0;

update comercial.cliente set activo = 1 where idcliente > 0;

