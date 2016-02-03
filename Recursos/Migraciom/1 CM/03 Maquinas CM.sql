INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('C1', 'CONVERTIDORA GRANDE NACAM', 1, 9, 5, 4, 2, 0.62, NULL, NULL, NULL, NULL, DEFAULT, DEFAULT, NULL, NULL);
	
    SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (371520, 13, 12, @idMaquina, 1, DEFAULT, 'x371520');
	
    INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (1, 43000000, 95505236.1894359, 128, @idMaquina, 1, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (2, 43000000, 95505236.1894359, 128, @idMaquina, 1, DEFAULT);
    
INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('C2', 'CONVERTIDORA NEGRA LITOGRAF', 1, 9, 5, 4, 1, 0.62, NULL, NULL, NULL, NULL, DEFAULT, DEFAULT, NULL, NULL);

	SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (234960, 13, 12, @idMaquina, 1, DEFAULT, 'x234960');

    INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (1, 36000000, 65389625.7533333, 128, @idMaquina, 1, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (2, 36000000, 65389625.7533333, 128, @idMaquina, 1, DEFAULT);
    
INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('C3', 'CONVERTIDORA VERDE', 1, 9, 5, 4, 1, 0.51000000000000001, NULL, NULL, NULL, NULL, DEFAULT, DEFAULT, NULL, NULL);
	
    SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (396000, 13, 12, @idMaquina, 1, DEFAULT, 'x396000');

    INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (1, 33000000, 61844643.8769231, 128, @idMaquina, 1, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (2, 33000000, 61844643.8769231, 128, @idMaquina, 1, DEFAULT);
    
INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('G1', 'GUILLOTINADO', 1, 8, 2, 3, 1, 4, NULL, NULL, NULL, NULL, DEFAULT, DEFAULT, NULL, NULL);
	
    SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (25, 16, 10, @idMaquina, 1, DEFAULT, 'x25');

    INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (1, 33400000, 50920989.8769231, 128, @idMaquina, 1, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (2, 33400000, 50920989.8769231, 128, @idMaquina, 1, DEFAULT);
    
INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('P1', 'PLASTIFICADORA 1', 1, 10, 5, 3, 1.2, 6.3499999999999996, NULL, NULL, NULL, NULL, DEFAULT, DEFAULT, NULL, NULL);
	
    SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (600000, 13, 10, @idMaquina, 1, DEFAULT, 'x600000');
	
    INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (1, 30202000, 61008478.6564912, 128, @idMaquina, 1, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (2, 30202000, 61008478.6564912, 128, @idMaquina, 1, DEFAULT);
    
INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('P2', 'PLASTIFICADORA 2', 1, 10, 5, 3, 1.2, 6.3499999999999996, NULL, NULL, NULL, NULL, DEFAULT, DEFAULT, NULL, NULL);

	SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (53244, 13, 10, @idMaquina, 1, DEFAULT, 'x53244');
	
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (65772, 13, 10, @idMaquina, 1, DEFAULT, 'x65772');
	
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (44370, 13, 10, @idMaquina, 1, DEFAULT, 'x44370');
	
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (65772, 13, 10, @idMaquina, 1, DEFAULT, 'x65772');
	
    INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (1, 30202000, 61008478.6564912, 128, @idMaquina, 1, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (2, 30202000, 61008478.6564912, 128, @idMaquina, 1, DEFAULT);
    
INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('L1', 'LITOGRAFICA MILLER BICOLOR', 1, 6, 5.5999999999999996, 3.5, 1, 4.8300000000000001, NULL, NULL, NULL, NULL, DEFAULT, DEFAULT, 2, 48000);

	SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (53244, 13, 10, @idMaquina, 1, DEFAULT, 'x53244');
	
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (65772, 13, 10, @idMaquina, 1, DEFAULT, 'x65772');
	
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (44370, 13, 10, @idMaquina, 1, DEFAULT, 'x44370');
	
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (65772, 13, 10, @idMaquina, 1, DEFAULT, 'x65772');

    INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (1, 97440000, 86688648.2835459, 128, @idMaquina, 1, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (2, 97440000, 86688648.2835459, 128, @idMaquina, 1, DEFAULT);

INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('L2', 'LITOGRAFICA ZONLAND BICOLOR', 1, 6, 3.5, 5.5, 2, 6.3499999999999996, NULL, NULL, NULL, NULL, DEFAULT, DEFAULT, 2, 26000);

	SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (3300, 13, 25, @idMaquina, 1, DEFAULT, 'x3300');

    INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (1, 131950000, 123137835.363792, 128, @idMaquina, 1, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (2, 131950000, 123137835.363792, 128, @idMaquina, 1, DEFAULT);

INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('L3', 'LITOGRAFICA ROLAND UN COLOR', 1, 6, 3, 5, 1, 6.3499999999999996, NULL, NULL, NULL, NULL, DEFAULT, DEFAULT, 1, 48000);

	SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (3300, 13, 25, @idMaquina, 1, DEFAULT, 'x3300');

    INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (1, 131950000, 123137835.363792, 128, @idMaquina, 1, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (2, 131950000, 123137835.363792, 128, @idMaquina, 1, DEFAULT);
    
INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('L4', 'LITOGRAFICA ROLAND 4 COLORES', 1, 6, 4.0999999999999996, 13.1, 1.5, 38, NULL, NULL, NULL, NULL, DEFAULT, DEFAULT, 4, 48000);

	SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (3500, 13, 30, @idMaquina, 1, DEFAULT, 'x3500');

    INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (1, 205194000, 141586385.477774, 128, @idMaquina, 1, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (2, 205194000, 141586385.477774, 128, @idMaquina, 1, DEFAULT);
    
INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('L5', 'LITOGRAFICA ROLAND BICOLOR', 1, 6, 3.1000000000000001, 5.0999999999999996, 1, 2.0800000000000001, NULL, NULL, NULL, NULL, DEFAULT, DEFAULT, 2, 26000);

	SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (2000, 13, 10, @idMaquina, 1, DEFAULT, 'x2000');

    INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (1, 47370000, 41130640.5939103, 128, @idMaquina, 1, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (2, 47370000, 41130640.5939103, 128, @idMaquina, 1, DEFAULT);
    
INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('T1', 'TROQUELADO SIMPLACUTTER', 1, 7, 2.2000000000000002, 4, 2, 0.73999999999999999, NULL, NULL, NULL, NULL, DEFAULT, DEFAULT, NULL, NULL);
	
	SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (1200, 17, 35, @idMaquina, 1, DEFAULT, 'x1200');

    INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (1, 15320000, 92830859.0491431, 128, @idMaquina, 1, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (2, 15320000, 92830859.0491431, 128, @idMaquina, 1, DEFAULT);
    
INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('T2', 'TROQULADDO TROQUIMAX', 1, 7, 2, 4, 1, 1.27, NULL, NULL, NULL, NULL, DEFAULT, DEFAULT, NULL, NULL);
	
    SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (1500, 17, 35, @idMaquina, 1, DEFAULT, 'x1500');

    INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (1, 0, 62022870.6045257, 128, @idMaquina, 1, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (2, 0, 62022870.6045257, 128, @idMaquina, 1, DEFAULT);
    
INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('T3', 'TROQUELADO ECONOCUT', 1, 7, 2.7000000000000002, 4, 2, 0.73999999999999999, NULL, NULL, NULL, NULL, DEFAULT, DEFAULT, NULL, NULL);
	
    SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (1500, 17, 35, @idMaquina, 1, DEFAULT, 'x1500');

    INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (1, 55120000, 105777732.309143, 128, @idMaquina, 1, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (2, 55120000, 105777732.309143, 128, @idMaquina, 1, DEFAULT);
    
INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('T4', 'TROQUELADO CROSSLAND', 1, 7, 2.8999999999999999, 4, 2, 0.88, NULL, NULL, NULL, NULL, DEFAULT, DEFAULT, NULL, NULL);
	
    SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (1200, 17, 35, @idMaquina, 1, DEFAULT, 'x1200');

    INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (1, 66240000, 114846378.880572, 128, @idMaquina, 1, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (2, 66240000, 114846378.880572, 128, @idMaquina, 1, DEFAULT);
    
INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('T5', 'TROQULADDO POLYGRAPH', 1, 7, 2, 4, 1, 1.27, NULL, NULL, NULL, NULL, DEFAULT, 0, NULL, NULL);
	
    SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (1200, 17, 35, @idMaquina, 1, DEFAULT, 'x1200');

    INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (1, 26200000, 0, 128, @idMaquina, 1, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (2, 26200000, 0, 128, @idMaquina, 1, DEFAULT);
    
INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('T6', 'TROQULEADO AUT1', 1, 7, 5.5, 4.5, 1, 6.6900000000000004, NULL, NULL, NULL, NULL, DEFAULT, DEFAULT, NULL, NULL);

	SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (3000, 17, 40, @idMaquina, 1, DEFAULT, 'x3000');

    INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (1, 164650000, 69742757.1127419, 128, @idMaquina, 1, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (2, 164650000, 69742757.1127419, 128, @idMaquina, 1, DEFAULT);
    
INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('T7', 'TROQUELADO AUT2 ', 1, 7, 2.7000000000000002, 5, 1, 4, NULL, NULL, NULL, NULL, DEFAULT, DEFAULT, NULL, NULL);
	
    SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (2500, 17, 40, @idMaquina, 1, DEFAULT, 'x2500');

    INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (1, 48900000, 58418562.0260459, 128, @idMaquina, 1, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (2, 48900000, 58418562.0260459, 128, @idMaquina, 1, DEFAULT);
    
INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('PE', 'PEGUE MAQUINA', 1, 11, 5, 10, 1.5, 0.80000000000000004, NULL, NULL, NULL, NULL, DEFAULT, DEFAULT, NULL, NULL);

	SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (8000, 13, 20, @idMaquina, 1, DEFAULT, 'x8000x20');
    
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (7000, 13, 90, @idMaquina, 1, DEFAULT, 'x7000x90');
    
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (5000, 13, 90, @idMaquina, 1, DEFAULT, 'x5000x90');
                
    INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (1, 146260000, 106782191.554491, 128, @idMaquina, 1, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (2,  146260000,106782191.554491, 128, @idMaquina, 1, DEFAULT);
    
INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('PM', 'PEGUE MANUAL', 1, 11, 5, 4, 1, 0, NULL, NULL, NULL, NULL, DEFAULT, DEFAULT, NULL, NULL);

	SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (1000, 13, 30, @idMaquina, 1, DEFAULT, 'x1000x30');

	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (833.33, 13, 20, @idMaquina, 1, DEFAULT, 'Lx833.33x20');

	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (375, 13, 20, @idMaquina, 1, DEFAULT, 'x375x20');

	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (625, 13, 20, @idMaquina, 1, DEFAULT, 'x625x20');

	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (312.5, 13, 20, @idMaquina, 1, DEFAULT, 'x312.5x20');

	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (333.33, 13, 20, @idMaquina, 1, DEFAULT, 'x333.33x20');

	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (541.66, 13, 20, @idMaquina, 1, DEFAULT, 'x541.66x20');

    INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (1, 11900000, 92036159.8653117, 128, @idMaquina, 1, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (2, 11900000, 92036159.8653117, 128, @idMaquina, 1, DEFAULT);
    
INSERT INTO produccion.maquina (codigo, nombre, empresa_idempresa, itemlista_iditemlistas_tipo, areaancho, arealargo, turnos, consumonominal, largomaxmp, largominmp, anchomaxmp, anchominmp, fechacreacion, activo, numerotintas, valorplancha)
VALUES ('CO', 'COLAMINADO', 1, 12, 3, 4, 1, 1.1200000000000001, NULL, NULL, NULL, NULL, DEFAULT, DEFAULT, NULL, NULL);
	
    SET @idMaquina = (LAST_INSERT_ID());
	INSERT INTO produccion.maquinavariprod (produccioncant, itemlista_iditemlista_produnimed, tiempoalistamiento, maquina_idmaquina, maquina_empresa_idempresa, activo, nombre_variacion_produccion)
	VALUES (1500, 13, 25, @idMaquina, 1, DEFAULT, 'x1500');

    INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (1, 18380000, 32273845.0679217, 128, @idMaquina, 1, DEFAULT);

	INSERT INTO produccion.maquinadatosperiodos (periodo_idPeriodo, avaluocomercial, presupuesto, tiempomtto, maquina_idmaquina, maquina_empresa_idempresa, activo)
	VALUES (2, 18380000, 32273845.0679217, 128, @idMaquina, 1, DEFAULT);
