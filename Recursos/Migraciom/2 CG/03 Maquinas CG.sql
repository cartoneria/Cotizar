INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('C1', 'CONVERSION', 2, 9, 2.3999999999999999, 4.9000000000000004, 1, 0.62, NULL, NULL, NULL, NULL, DEFAULT, DEFAULT, NULL, NULL);

	SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (360000, 13, 12, @idMaquina, 2, DEFAULT, 'x360000');
	
	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (3, 45962300, 25000000, 112, @idMaquina, 2, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (4, 45962300, 25000000, 112, @idMaquina, 2, DEFAULT);

INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('G1', 'GUILLOTINADO', 2, 8, 2.3999999999999999, 2.3999999999999999, 1, 0.62, NULL, NULL, NULL, NULL, DEFAULT, DEFAULT, NULL, NULL);
	
	SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (20, 16, 10, @idMaquina, 2, DEFAULT, 'x20');

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (3, 50717442.7202876, 20000000, 112, @idMaquina, 2, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (4, 50717442.7202876, 20000000, 112, @idMaquina, 2, DEFAULT);

INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('L1', 'LITOGRAFIA 5 COLORES', 2, 6, 3, 8.0999999999999996, 1, 0.62, NULL, NULL, NULL, NULL, DEFAULT, DEFAULT, 5, 48000);
	
	SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (3300, 17, 30, @idMaquina, 2, DEFAULT, 'x3300');

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (3, 111722470, 134230000, 112, @idMaquina, 2, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (4, 111722470, 134230000, 112, @idMaquina, 2, DEFAULT);

INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('L2', 'LITOGRAFICA SOLNA 230', 2, 6, 2.6000000000000001, 4.2000000000000002, 1, 0.62, NULL, NULL, NULL, NULL, DEFAULT, DEFAULT, 5, 48000);
	
	SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (3000, 17, 30, @idMaquina, 2, DEFAULT, 'x3000');

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (3, 103340556.040107, 65360800, 112, @idMaquina, 2, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (4, 103340556.040107, 65360800, 112, @idMaquina, 2, DEFAULT);

INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('L3', 'LITOGRAFIA MILLER 2 COLORES', 2, 6, 2.7999999999999998, 4.9000000000000004, 1, 0.62, NULL, NULL, NULL, NULL, DEFAULT, DEFAULT, 2, 48000);
		
	SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (3000, 17, 30, @idMaquina, 2, DEFAULT, 'x3000');

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (3, 71338445.4033234, 65360800, 112, @idMaquina, 2, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (4, 71338445.4033234, 65360800, 112, @idMaquina, 2, DEFAULT);

INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('L4', 'LITOGRAFICA SOLNA 225', 2, 6, 2.5, 2.5, 1, 0.62, NULL, NULL, NULL, NULL, DEFAULT, DEFAULT, 5, 48000);

	SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (3000, 17, 30, @idMaquina, 2, DEFAULT, 'x3000');

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (3, 62642920.2316587, 38855000, 112, @idMaquina, 2, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (4, 62642920.2316587, 38855000, 112, @idMaquina, 2, DEFAULT);

INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('T1', 'TROQUELADORA VERDE', 2, 7, 2.3999999999999999, 4, 1, 0.62, NULL, NULL, NULL, NULL, DEFAULT, DEFAULT, NULL, NULL);

	SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (1200, 17, 50, @idMaquina, 2, DEFAULT, 'x1200');

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (3, 68302762.1517801, 28540800, 112, @idMaquina, 2, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (4, 68302762.1517801, 28540800, 112, @idMaquina, 2, DEFAULT);

INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('T2', 'TROQUELADORA NEGRA', 2, 7, 2.2999999999999998, 4, 1, 0.62, NULL, NULL, NULL, NULL, DEFAULT, DEFAULT, NULL, NULL);

	SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (1400, 17, 50, @idMaquina, 2, DEFAULT, 'x1400');

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (3, 72275153.3678907, 37976600, 112, @idMaquina, 2, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (4, 72275153.3678907, 37976600, 112, @idMaquina, 2, DEFAULT);

INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('T3', 'TROQUELADORA AZUL', 2, 7, 2.1000000000000001, 4, 1, 0.62, NULL, NULL, NULL, NULL, DEFAULT, DEFAULT, NULL, NULL);

	SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (1500, 17, 50, @idMaquina, 2, DEFAULT, 'x1500');

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (3, 70985957.1517801, 26848200, 112, @idMaquina, 2, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (4, 70985957.1517801, 26848200, 112, @idMaquina, 2, DEFAULT);

INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('P1', 'PLASTIFICADORA 1', 2, 10, 2.3999999999999999, 4, 1, 0.62, NULL, NULL, NULL, NULL, DEFAULT, DEFAULT, NULL, NULL);

	SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (56000, 13, 20, @idMaquina, 2, DEFAULT, 'x56000');

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (3, 63197748.9646999, 28540800, 112, @idMaquina, 2, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (4, 63197748.9646999, 28540800, 112, @idMaquina, 2, DEFAULT);

INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('P2', 'PLASTIFICADORA 2', 2, 10, 2.3999999999999999, 4, 1, 0.62, NULL, NULL, NULL, NULL, DEFAULT, DEFAULT, NULL, NULL);

	SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (56000, 13, 20, @idMaquina, 2, DEFAULT, 'x56000');

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (3, 67224948.9646999, 28540800, 112, @idMaquina, 2, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (4, 67224948.9646999, 28540800, 112, @idMaquina, 2, DEFAULT);

INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('PE', 'PEGADORA', 2, 11, 2.7000000000000002, 1.3999999999999999, 1, 0.62, NULL, NULL, NULL, NULL, DEFAULT, DEFAULT, NULL, NULL);

	SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (450000, 13, 30, @idMaquina, 2, DEFAULT, 'x450000');

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (3, 127485382.594983, 145544000, 112, @idMaquina, 2, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (4, 127485382.594983, 145544000, 112, @idMaquina, 2, DEFAULT);

INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('PM', 'PEGUE MANUAL', 2, 11, 5, 4, 1, 0.62, NULL, NULL, NULL, NULL, DEFAULT, DEFAULT, NULL, NULL);

	SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (1000, 13, 30, @idMaquina, 2, DEFAULT, 'x1000');

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (3, 114261260.893374, 12320000, 0, @idMaquina, 2, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (4, 114261260.893374, 12320000, 0, @idMaquina, 2, DEFAULT);

INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('CO', 'COLAMINADO', 2, 12, 2.3999999999999999, 4, 1, 0.62, NULL, NULL, NULL, NULL, DEFAULT, DEFAULT, NULL, NULL);

	SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (25000, 13, 30, @idMaquina, 2, DEFAULT, 'x25000');

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (3, 40000000, 18540800, 112, @idMaquina, 2, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (4, 40000000, 18540800, 112, @idMaquina, 2, DEFAULT);

