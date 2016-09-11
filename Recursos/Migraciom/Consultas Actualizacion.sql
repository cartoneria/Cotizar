update produccion.maquina set activo = 1 where idmaquina > 0;

update produccion.maquinadatosperiodos set activo = 1 where idmaquinadatosperiodos > 0;

update produccion.maquinavariprod set activo = 1 where idVariacion > 0;

update comercial.asesor set activo = 1 where idasesor > 0;

update produccion.proveedor set activo = 1 where idproveedor > 0;

update produccion.proveedor_linea set activo = 1 where idproveedor_linea > 0;

update produccion.insumo set activo = 1 where idinsumo > 0;

update produccion.accesorio set activo =1 where idaccesorio > 0;

update seguridad.periodo set vigente = 1 where idPeriodo = 1;