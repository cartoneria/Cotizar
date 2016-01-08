INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('C1', 'CONVERTIDORA GRANDE NACAM', 1, 9, 5, 4, 2, 0.62, NULL, NULL, NULL, NULL, DEFAULT, DEFAULT, NULL, NULL);
	
    SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (371520, 13, 12, @idMaquina, 1, DEFAULT, 'x371520');
	
    INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (1, 95505236.1894359, 43000000, 32, @idMaquina, 1, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (2, 95505236.1894359, 43000000, 32, @idMaquina, 1, DEFAULT);
    
INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('C2', 'CONVERTIDORA NEGRA LITOGRAF', 1, 9, 5, 4, 1, 0.62, NULL, NULL, NULL, NULL, DEFAULT, DEFAULT, NULL, NULL);

	SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (234960, 13, 12, @idMaquina, 1, DEFAULT, 'x234960');

    INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (1, 65389625.7533333, 36000000, 32, @idMaquina, 1, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (2, 65389625.7533333, 36000000, 32, @idMaquina, 1, DEFAULT);
    
INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('C3', 'CONVERTIDORA VERDE', 1, 9, 5, 4, 1, 0.51000000000000001, NULL, NULL, NULL, NULL, DEFAULT, DEFAULT, NULL, NULL);
	
    SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (396000, 13, 12, @idMaquina, 1, DEFAULT, 'x396000');

    INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (1, 61844643.8769231, 33000000, 32, @idMaquina, 1, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (2, 61844643.8769231, 33000000, 32, @idMaquina, 1, DEFAULT);
    
INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('G1', 'GUILLOTINADO', 1, 8, 2, 3, 1, 4, NULL, NULL, NULL, NULL, DEFAULT, DEFAULT, NULL, NULL);
	
    SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (25, 16, 10, @idMaquina, 1, DEFAULT, 'x25');

    INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (1, 50920989.8769231, 33400000, 32, @idMaquina, 1, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (2, 50920989.8769231, 33400000, 32, @idMaquina, 1, DEFAULT);
    
INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('P1', 'PLASTIFICADORA 1', 1, 10, 5, 3, 1.2, 6.3499999999999996, NULL, NULL, NULL, NULL, DEFAULT, DEFAULT, NULL, NULL);
	
    SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (758700, 13, 10, @idMaquina, 1, DEFAULT, 'x758.700');
	
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (569610, 13, 10, @idMaquina, 1, DEFAULT, 'x569610 ');

    INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (1, 61008478.6564912, 30202000, 32, @idMaquina, 1, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (2, 61008478.6564912, 30202000, 32, @idMaquina, 1, DEFAULT);
    
INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('P2', 'PLASTIFICADORA 2', 1, 10, 5, 3, 1.2, 6.3499999999999996, NULL, NULL, NULL, NULL, DEFAULT, DEFAULT, NULL, NULL);

	SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (758700, 13, 10, @idMaquina, 1, DEFAULT, 'x758.700 ');
	
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (569610, 13, 10, @idMaquina, 1, DEFAULT, 'x569.610 ');

    INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (1, 61008478.6564912, 30202000, 32, @idMaquina, 1, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (2, 61008478.6564912, 30202000, 32, @idMaquina, 1, DEFAULT);
    
INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('L1', 'LITOGRAFICA MILLER', 1, 6, 5.5999999999999996, 3.5, 1, 4.8300000000000001, NULL, NULL, NULL, NULL, DEFAULT, DEFAULT, 2, 48000);

	SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (3000, 13, 25, @idMaquina, 1, DEFAULT, 'x3000');

    INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (1, 86688648.2835459, 97440000, 32, @idMaquina, 1, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (2, 86688648.2835459, 97440000, 32, @idMaquina, 1, DEFAULT);
    
INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('L2', 'LITOGRAFICA BICOLOR', 1, 6, 3.5, 5.5, 2, 6.3499999999999996, NULL, NULL, NULL, NULL, DEFAULT, DEFAULT, 2, 48000);

	SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (3300, 13, 25, @idMaquina, 1, DEFAULT, 'x3300');

    INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (1, 123137835.363792, 131950000, 32, @idMaquina, 1, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (2, 123137835.363792, 131950000, 32, @idMaquina, 1, DEFAULT);
    
INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('L4', 'LITOGRAFICA 4 COLORES ', 1, 6, 4.0999999999999996, 13.1, 1.5, 38, NULL, NULL, NULL, NULL, DEFAULT, DEFAULT, 4, 48000);

	SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (3500, 13, 30, @idMaquina, 1, DEFAULT, 'x3500');

    INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (1, 141586385.477774, 205194000, 32, @idMaquina, 1, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (2, 141586385.477774, 205194000, 32, @idMaquina, 1, DEFAULT);
    
INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('L5', 'LITOGRAFICA ZONLAND', 1, 6, 3.1000000000000001, 5.0999999999999996, 1, 2.0800000000000001, NULL, NULL, NULL, NULL, DEFAULT, DEFAULT, 4, 48000);

	SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (2000, 13, 10, @idMaquina, 1, DEFAULT, 'x2000');

    INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (1, 41130640.5939103, 47370000, 32, @idMaquina, 1, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (2, 41130640.5939103, 47370000, 32, @idMaquina, 1, DEFAULT);
    
INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('T1', 'TROQUELADO SIMPLACUTTER', 1, 7, 2.2000000000000002, 4, 2, 0.73999999999999999, NULL, NULL, NULL, NULL, DEFAULT, DEFAULT, NULL, NULL);
	
	SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (1200, 17, 35, @idMaquina, 1, DEFAULT, 'x1200');

    INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (1, 92830859.0491431, 15320000, 32, @idMaquina, 1, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (2, 92830859.0491431, 15320000, 32, @idMaquina, 1, DEFAULT);
    
INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('T2', 'TROQULADDO TROQUIMAX', 1, 7, 2, 4, 1, 1.27, NULL, NULL, NULL, NULL, DEFAULT, DEFAULT, NULL, NULL);
	
    SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (1500, 17, 35, @idMaquina, 1, DEFAULT, 'x1500');

    INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (1, 62022870.6045257, 0, 32, @idMaquina, 1, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (2, 62022870.6045257, 0, 32, @idMaquina, 1, DEFAULT);
    
INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('T3', 'TROQUELADO ECONOCUT', 1, 7, 2.7000000000000002, 4, 2, 0.73999999999999999, NULL, NULL, NULL, NULL, DEFAULT, DEFAULT, NULL, NULL);
	
    SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (1500, 17, 35, @idMaquina, 1, DEFAULT, 'x1500');

    INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (1, 105777732.309143, 55120000, 32, @idMaquina, 1, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (2, 105777732.309143, 55120000, 32, @idMaquina, 1, DEFAULT);
    
INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('T4', 'TROQUELADO CROSSLAND', 1, 7, 2.8999999999999999, 4, 2, 0.88, NULL, NULL, NULL, NULL, DEFAULT, DEFAULT, NULL, NULL);
	
    SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (1200, 17, 35, @idMaquina, 1, DEFAULT, 'x1200');

    INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (1, 114846378.880572, 66240000, 32, @idMaquina, 1, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (2, 114846378.880572, 66240000, 32, @idMaquina, 1, DEFAULT);
    
INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('T5', 'TROQULADDO POLYGRAPH', 1, 7, 2, 4, 1, 1.27, NULL, NULL, NULL, NULL, DEFAULT, 0, NULL, NULL);
	
    SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (1200, 17, 35, @idMaquina, 1, DEFAULT, 'x1200');

    INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (1, 0, 26200000, 32, @idMaquina, 1, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (2, 0, 26200000, 32, @idMaquina, 1, DEFAULT);
    
INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('T6', 'TROQULEADO AUT1', 1, 7, 5.5, 4.5, 1, 6.6900000000000004, NULL, NULL, NULL, NULL, DEFAULT, DEFAULT, NULL, NULL);

	SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (3000, 17, 40, @idMaquina, 1, DEFAULT, 'x3000');

    INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (1, 69742757.1127419, 164650000, 32, @idMaquina, 1, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (2, 69742757.1127419, 164650000, 32, @idMaquina, 1, DEFAULT);
    
INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('T7', 'TROQUELADO AUT2 ', 1, 7, 2.7000000000000002, 5, 1, 4, NULL, NULL, NULL, NULL, DEFAULT, DEFAULT, NULL, NULL);
	
    SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (2500, 17, 40, @idMaquina, 1, DEFAULT, 'x2500');

    INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (1, 58418562.0260459, 48900000, 32, @idMaquina, 1, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (2, 58418562.0260459, 48900000, 32, @idMaquina, 1, DEFAULT);
    
INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('PE', 'PEGUE MAQUINA', 1, 11, 5, 10, 1.5, 0.80000000000000004, NULL, NULL, NULL, NULL, DEFAULT, DEFAULT, NULL, NULL);

	SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (350000, 13, 20, @idMaquina, 1, DEFAULT, 'x350000');

    INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (1, 106782191.554491, 146260000, 32, @idMaquina, 1, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (2, 106782191.554491, 146260000, 32, @idMaquina, 1, DEFAULT);
    
INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('PM', 'PEGUE MANUAL', 1, 11, 5, 4, 1, 0, NULL, NULL, NULL, NULL, DEFAULT, DEFAULT, NULL, NULL);

	SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (800, 13, 30, @idMaquina, 1, DEFAULT, 'x800');

    INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (1, 92036159.8653117, 11900000, 32, @idMaquina, 1, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (2, 92036159.8653117, 11900000, 32, @idMaquina, 1, DEFAULT);
    
INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('CO', 'COLAMINADO', 1, 12, 3, 4, 1, 1.1200000000000001, NULL, NULL, NULL, NULL, DEFAULT, DEFAULT, NULL, NULL);
	
    SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (30000, 13, 25, @idMaquina, 1, DEFAULT, 'x30000');

    INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (1, 32273845.0679217, 18380000, 32, @idMaquina, 1, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (2, 32273845.0679217, 18380000, 32, @idMaquina, 1, DEFAULT);
