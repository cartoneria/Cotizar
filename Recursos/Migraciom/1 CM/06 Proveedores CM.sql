INSERT INTO produccion.proveedor (nombre, fechacreacion, activo, empresa_idempresa)
VALUES ('Smurfit Kappa', DEFAULT, DEFAULT, 1);

	SET @idProveerdor = (last_insert_id());
	INSERT INTO produccion.proveedor_linea (nombre, fechacreacion, activo, proveedor_idproveedor)
	VALUES ('Genérica', DEFAULT, DEFAULT, @idProveerdor);
	
INSERT INTO produccion.proveedor (nombre, fechacreacion, activo, empresa_idempresa)
VALUES ('Cartones de Colombia', DEFAULT, DEFAULT, 1);

	SET @idProveerdor = (last_insert_id());
	INSERT INTO produccion.proveedor_linea (nombre, fechacreacion, activo, proveedor_idproveedor)
	VALUES ('Genérica', DEFAULT, DEFAULT, @idProveerdor);
	
INSERT INTO produccion.proveedor (nombre, fechacreacion, activo, empresa_idempresa)
VALUES ('Cartones América S.A.', DEFAULT, DEFAULT, 1);

	SET @idProveerdor = (last_insert_id());
	INSERT INTO produccion.proveedor_linea (nombre, fechacreacion, activo, proveedor_idproveedor)
	VALUES ('Genérica', DEFAULT, DEFAULT, @idProveerdor);

INSERT INTO produccion.proveedor (nombre, fechacreacion, activo, empresa_idempresa)
VALUES ('Generico', DEFAULT, DEFAULT, 1);

	SET @idProveerdor = (last_insert_id());
	INSERT INTO produccion.proveedor_linea (nombre, fechacreacion, activo, proveedor_idproveedor)
	VALUES ('Genérica', DEFAULT, DEFAULT, @idProveerdor);