INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('ZAPATO DAMA',36,'01','2',21,11,29.3,50,66,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('ZAPATO CABALLERO',36,'01','3',32.5,21,12,56,67.8,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA NORMAL PEQUEÑA',36,'01','4',16,9,26.4,44.7,52.4,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA PARDELY ',36,'01','5',17.5,11,28,49.8,59.3,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BOTÍN DAMA',36,'01','6',19,10,29,49,60,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PIE CHEF',36,'01','7',20,4.5,20,29,51,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (14, 10.4, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('ZAPATO DAMA CAPRINO',36,'01','8',16.7,10,29,49,55.4,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BOTA DAMA CAPRINO',36,'01','9',24.5,10,29,49,70.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('FRUGALLETA FRESA Y MARACUYA',36,'01','10',13,10.5,4,83.8,29.9,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('TENCNOAL   GELATINA 1',36,'01','11',8.5,8.5,2.5,25,23,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PIE CHEF 1 CM',36,'01','12',20,4.5,20,53.1,31,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('TENCNOAL   GELATINA X 12',36,'01','13',8.5,8.5,2.5,70.5,49.6,12,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA BALETA',36,'01','14',23,13,9,82,45.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA DAMA',36,'01','15',29,16.5,10,49,55.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA BOTA',36,'01','16',31.5,24,10.5,52.5,70.8,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA BOTIN',36,'01','17',31.7,20.9,10.3,52.3,64.3,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CJ HOMBRE LOMBHER',36,'01','18',31.5,18,10.5,52.5,58.8,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('ZAPATILLA DAMA MANFER',36,'01','19',28,16.5,10,49,54.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BONTIN DAMA MANFER',36,'01','20',29.6,19.5,11.3,52.2,63.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA DAMA_2',36,'01','21',16,8.3,27,87.2,50.1,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA VALETA',36,'01','22',27,13,8,86,43.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('MUESTRA TESTIGO 1',36,'02','1',25.3,14.6,5.5,25.7,42,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAMISA TAPA ARVAL',36,'03','1',32.8,21,6,59.6,48,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (26, 14, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAMISA BASE ARVAL',36,'03','2',32.4,20.4,6,59.3,47.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('TAPA CAJA PANTALON',36,'03','3',36.5,30.5,4,49,54.8,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PLATEADA BASE, paltalon clasico base',36,'03','4',36.3,30.2,4,48.2,54.4,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BACHELLITO TAPA, paltalon niño tapa',36,'03','5',29.4,26.8,4,48.7,46,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BACHELLITO BASE, paltalon niño base',36,'03','6',29.3,26.5,4,48.5,45.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('SEIS CAMISAS TAPA',36,'03','7',34.3,22.3,6,48.7,60.7,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BAYON´S BASE',36,'03','8',20,12.5,2.5,32.5,49.7,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA CAMISA  TAPA PK MODA',36,'03','9',33.3,22,3,48,37.8,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (24.2, 14.3, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAMISA BASE PK MODA',36,'03','10',33,22,6.5,49.8,50.3,61.4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('UNA CAMISA BACHELI',36,'03','11',34.7,21.3,3,49,35,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (26, 17.3, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('TAPA Y BASE CASHMERE',36,'03','12',0,0,0,49.5,85.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('TAPA BROWNIE AMERICAN',36,'03','13',0,0,0,45.5,33.4,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (16, 27, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BASE CAMISA BACHELLI',36,'03','14',21,34.5,6,60.7,47.1,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('TAPA PANTALON NIÑO',36,'03','15',26.5,38.6,4,44.8,58,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BASE PANTALON NIÑO',36,'03','16',26.2,38.3,4,44.6,57.4,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('TAPA CAMISA MONO NEGRO',36,'03','17',23.8,35,2.7,37.4,49,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (27, 19, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BASE CAMISA MONO NEGRO',36,'03','18',23.6,34.4,6.2,51.2,62.3,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (5, 2, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('TAPA CAJA CAMISA',36,'03','19',32.5,21,6,48,59.5,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (26.6, 15, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BASE YIBU',36,'03','20',31.5,21,4,39.2,49.7,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('TAPA YIBU',36,'03','21',31.8,21.4,4,39.6,50,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('TAPA PANTALON ARVAL',36,'03','22',28,37.8,3.5,44.4,54.2,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (7.8, 3.2, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BASE PANTALON ARVAL',36,'03','23',27.5,37.5,3.5,44.4,54.2,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('TAPA',36,'03','24',30.5,36.3,4,48.7,54.6,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BASE',36,'03','25',30.2,36,4,48.4,54.3,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('TAPA Y BASE CIRIOS',36,'03','26',29.9,10,5,75.3,40.8,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (26, 6.3, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('TAPA CAMISA',36,'03','27',23.8,34.8,2.7,48.2,37.2,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (18, 26, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BASE CAMISA',36,'03','28',23.5,34.4,6.3,51.5,62.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('TAPA DIANCAR',36,'03','29',22.2,33.3,3,37.7,48.2,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (17, 26.5, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BASE DIANCAR',36,'03','30',22,33,6.5,61,51.5,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (2.1, 4, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA RUBIALES PEQUEÑA',36,'03','31',17.5,10.5,3.5,34.8,56.2,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (14.5, 8, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA BROWNIE X 8',36,'03','32',32,17,4.4,52.4,76,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA RUBIALES GRANDE',36,'03','33',25.4,13.4,3.5,42.7,61,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (21.8, 10.4, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('TAPA ALBUN',36,'03','34',32.4,32.4,3.5,49.5,49.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BASE ALBUN',36,'03','35',32,32,4,51,51,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA CORREA',36,'03','36',11,11,5.7,36.7,73,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA 11x11x3.5',36,'03','37',11,11,3.5,28.3,56.2,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (8, 8, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('TAPA CAJA GRANDE RELOJ',36,'03','38',46.5,41.5,5,66.5,96.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BASE CAJA GRANDE RELOJ',36,'03','39',46,41,5,66,96,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('ROLLOS LA CAMPIÑA Y POPSY',36,'04','1',10,10,22,47.3,42.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('AROMATICAS X 12 FRUTALIA',36,'04','3',7.5,5,8.2,52.5,26.3,3,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA REGALO PEQUEÑA',36,'04','5',23,6.5,38,55.5,61,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA REGALO GRANDE',36,'04','6',30,9.8,40.2,64.5,81.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('MEDIO ROLLO NEW BRANDS GRATTO',36,'04','7',10,10,12.1,37.5,42.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('MAXIROLLO,campiña',36,'04','8',10,10,30.8,56,42.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA AROMAT.R-11',36,'04','9',10.8,5.5,8.5,37.8,68.1,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('TÉ HIMALAYA',36,'04','10',11,6.7,7.2,38.5,73.7,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('ALFA 1/2 YARDA',36,'04','11',7,1.8,8.4,18.5,38.1,3,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('ALFA 1 YARDA',36,'04','12',7,2.5,8.5,15.5,60,3,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('AROMATICAS HIMALAYA',36,'04','13',12.8,5.2,5.9,31.7,74.8,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('C.I.STEVIA',36,'04','14',13,5,6,19,37.2,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('TÉ HINDÚ X 50 AROMA',36,'04','15',14,10.3,5.9,79.1,50.2,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('LINCOCELIN 20 ML',36,'04','16',8,6.5,4.5,40,26.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('ALFA TRADING 1X5 YD',36,'04','17',7.5,6,16,30.8,84.6,3,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('ALFA TRADING 1/2X5 YD',36,'04','18',7.5,3,16,24.8,66.6,3,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('ANUICE',36,'04','19',14,10,4,29.5,86.5,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('HINDU X 25',36,'04','20',14,5.9,5.2,57.1,79.5,8,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA REGALO PEQUEÑA - 7 ML.',36,'04','21',38,23,6.4,55,61.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('INDIVIDUAL BROWIE',36,'04','22',4,7,8.5,23.5,18.6,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('HIPLANTRO MUESTRA',36,'04','23',6.5,13,5.5,18,40.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('DAVILA AROMATICA Y TE',36,'04','24',7.5,7.5,7.5,38,31.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('TE TRADICIONA X 25',36,'04','25',13.8,5.3,6,32.7,39,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('TE VERDE CLASICO',36,'04','26',12,6.4,7.2,39.5,38,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('TE X 50 SAMOA',36,'04','27',13.9,10.2,6,85,49.1,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('FRUTOS DEL BOSQUE Y FRUTOS ROJOS',36,'04','28',12,6.5,7.2,37.8,72.1,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BROWNIE AREQUIPE X 2 Y CHOCOLATE',36,'04','29',14,4,8,52.2,64.5,6,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BOQUILLAS D´CRISTAL',36,'04','30',5.3,5.3,4.8,29.2,22.2,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CELL',36,'04','31',8,4.5,6.5,39.8,25.9,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA PERA DE OIDO',36,'04','32',5.9,5.9,11.1,42.5,25,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('AROMÁTICA LIGHT X 12',36,'04','33',7.5,5,8.5,37.2,53.1,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA CAUCHOS ',36,'04','34',6.5,2,10,69.2,36.5,10,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('AROMÁTICAS TECNOFARMA',36,'04','35',8.6,6.6,8,56,31.5,3,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('DISPLAY AREQUIPE X 6',36,'04','36',5.5,5.2,16.5,27.2,23,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA ANUCURE',36,'04','37',9.5,4,15,68.8,57.5,6,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA FILTRO MEDIANA',36,'04','38',23.5,3,28,55.5,70.9,2,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (11.6, 7.5, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA LIMA X 12',36,'04','39',10,6.2,26.2,42.2,34.2,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA HERBAL X 16',36,'04','40',11,6.5,7.8,89,36.4,5,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA CHOCOFIESTA CHOCONIEVE',36,'04','41',9.5,6.5,17.5,59.4,67.4,4,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (6.8, 6.8, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA FILTRO 30 X 30',36,'04','42',30,3,30,39.2,67,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (12, 7.5, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA FILTRO LARGA',36,'04','43',19,3,45.5,55,45.5,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (12, 9, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA FILTRO PEQUEÑA',36,'04','44',23,2.5,23,57,52.5,2,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (14.5, 4.9, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA LUBRICANTE',36,'04','45',3.3,3.3,8.6,30,29.5,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA MIEL  X 20',36,'04','46',10.8,10,5.5,58.7,68.1,6,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA ANUCURE  ARABE',36,'04','47',9.5,4,15,48,28.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA HOMEOCOKSINUM X 9',36,'04','48',5.7,2.3,18.4,25.5,25.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA JUMBO NEVADA',36,'04','49',25,6,36,51.4,64,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (8.5, 12, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('DISPLAY AREQUIPE X 6 LATTI',36,'04','50',5.5,5.2,16.5,27.2,68.7,3,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA AGENDA PEQ-GRAN',36,'04','51',0,0,0,48.7,48.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA PRECOCIDA X 220gr',36,'04','52',17,2,19,39.5,54,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA COMBO JUEGO DE BAÑO',36,'04','53',23.5,73.5,52.5,69.9,63.7,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (17, 46, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('REF 41',36,'04','54',24.9,6,37.5,50.3,63.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('REF 42',36,'04','55',25.5,4.4,35.5,48,61.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('REF 43',36,'04','56',21,8,37.8,57.4,59.7,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('REF 44',36,'04','57',24.6,7,31.4,49,65,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('REF 47',36,'04','58',10.5,6.2,11.8,24.1,35,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CJ AFILADOR',36,'04','59',7,3,16,46,21.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA EXTRAGANDE HB',36,'04','60',25,6,39,54.6,63.5,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (11.7, 10, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA JARROSIL',36,'04','61',5.7,4.4,8.9,21,35.2,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA HOMEOCOKSINUM X 6',36,'04','62',5.7,2.5,14.7,21.6,51,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA CUCHILLO',36,'04','63',4.5,2,25,31.6,28.7,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA FILTRO MOTOS',36,'04','64',15,5,21,34.2,39.8,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (8, 9, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('REF 29',36,'04','65',20.4,4.1,41,52.8,52,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('REF 27',36,'04','66',10.4,4.2,31.4,41,32,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('REF AC - 4',36,'04','67',30,3,30,39,67.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('REF No. 4',36,'04','68',25.5,3.6,26.5,37,60,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('REF No. 5',36,'04','69',20.5,5.9,31.4,47,54.6,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('REF No. 16',36,'04','70',23,7.4,23.5,41.5,62.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('REF No. 15',36,'04','71',16.8,5.5,19.3,30.4,44.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('REF No. 19',36,'04','72',14.5,14.5,19,52,59.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('REF No. 22',36,'04','73',6.5,6.5,10,21.6,25.6,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA FRUTA Y TE VERDE LIGHT X 12',36,'04','74',6.5,8.5,7.8,40,32,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('DISPLAY AREQUIPE X 6 LATTI',36,'04','75',5.5,5.2,16.5,72.4,48,6,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('DISPOSITIVO ELECTRONICO',36,'04','76',5.5,12,5.5,36.4,32.1,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CJ AC5',36,'04','77',20.6,3.4,23.2,50,32.9,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CJ AC6',36,'04','78',20.6,2.8,28.2,48.9,36.9,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CJ AC7',36,'04','79',25,3.3,30,59,39.7,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CJ AC8',36,'04','80',26.8,5,35.5,66,49.4,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CJ GASA ESTERIL GENERICA ',36,'04','81',13.7,2,15.2,40.7,32.6,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BARRIL X 7 LTRS.',36,'05','1',65.9,0,35,70,36.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BARRIL X 4 LTRS.',36,'05','2',65.9,0,24.5,68.4,25.8,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BARRIL X 2 LITROS',36,'05','3',0,0,0,52,24.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BARRIL X 3 LTRS.',36,'05','4',0,0,0,70,26.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BARRIL 1 LT LAS DELICIAS',36,'05','5',0,0,12,35.8,20.9,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BARRIL GENERICO 2 LITROS',36,'05','6',0,0,10.5,52,24.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BARRIL X 7 LTRS.',36,'05','7',0,0,0,70,36.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BARRIL X 8 LTRS.',36,'05','8',0,0,0,68,38.6,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('AMERCAN POLLO/UN CUARTO DE POLLO',36,'06','1',16.7,10.3,6.7,38.6,55.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA COMBO broaster',36,'06','2',24.5,16,8,55.5,83,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('TÉ DESCAFEINADO, TE VERDE PIÑA',36,'06','3',10.5,7,6.7,33,71.4,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('FORTEX X 250 ML',36,'06','4',6,6,16.4,54.3,25.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('AROMATICAS X 16 REFS',36,'06','5',12.5,5.4,6,59.6,36.9,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA MARISELA NAVIDAD (LONCHERITA)',36,'06','6',16,8,11.3,49.9,49.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJITA OSITO',36,'06','7',5,5,5,42.5,22,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('MEZCLADOR promociones fantasticas',36,'06','8',11.5,9.8,10.8,47.5,44.4,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA MARISELA NAVIDAD X 1',36,'06','9',16,8,11.3,27.2,50,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('TRATAMIENTO ADELGAZANTE',36,'06','10',23.5,22,7,45.5,93,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('ENCEDEL 200 M.  CELL FAR.',36,'06','11',9,6,13.5,32,25.4,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('DISPLAY BROWNIE X 10 CHOCOLATE Y AREQUIPE',36,'06','12',17.7,17.7,10.8,57.1,90.9,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('SAMOA INSTITUCIONAL X 80',36,'06','13',19.8,12.8,7,48.7,67.2,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('LITRO  HIPLANTRO',36,'06','14',10.9,14.5,15,66.9,52.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PORCION INDIVIDUAL HINPLANTRO',36,'06','15',13,7,7.5,38.3,41.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('MEZCLADOR P. FANTASTICAS TIRA',36,'06','16',11.5,10,10.8,29.1,89.3,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('MANTECADA X 6  GUADALUPE',36,'06','17',17,11,11,54.5,57.4,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BIMBOLETE ADES',36,'06','18',11.5,8.6,14,31,83.7,2,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (13.5, 8.5, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('VALLEFRUT + PONQUE',36,'06','19',12,7,12.5,78.7,39.4,3,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('DISPLAY X 16 UNIDADES',36,'06','20',26,13,11,64.6,79.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('VALLEFRUT + PONQUESITO KIT ESCOLAR',36,'06','21',10.7,4,12.5,30.7,70.9,3,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (12, 8.3, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('TIGO PROMOCION CELULAR',36,'06','22',15.8,8.8,14,50.9,65.4,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('MANI CARREFOUR GAL ALIMENTOS',36,'06','23',19.6,13.6,9.6,42.2,90,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA PUNTILLA TREFILADOS',36,'06','24',4.9,9.2,4.5,58.8,58.7,8,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('DISPLAY X 12 SANTILLANA CON NIDO',36,'06','25',12,8.5,12,52,54.2,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA SIXPACK CERVEZA',36,'06','26',18.9,12.6,21.2,48.5,65,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('AVA PLUS ',36,'06','27',12,11.5,5,58.2,62,4,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (8, 7.5, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('AVA  ',36,'06','28',12,11.5,4,79,50.3,4,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (8, 7.5, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CJ MASA PARA BUÑUELOS LOS HORNITOS',36,'06','29',11.5,15.5,4.5,47,35,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA INES',36,'06','30',19.4,12.1,6,47.3,66.5,2,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (15.2, 7.2, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CJ AROMÁTICA X 20 FRUTALIA',36,'06','31',10.8,5.5,8.5,54.1,68.1,6,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA INES MINI',36,'06','32',16.2,14.5,6,33.5,80.8,2,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (12, 10.5, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA TIFFANY',36,'06','33',16,14.5,8,57.5,64.5,2,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (12, 10.5, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA INES PLUS',36,'06','34',16.4,11.8,8,50,59.5,2,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (12.4, 7.8, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('1/4 DE POLLO ',36,'06','35',10.3,16.7,6.7,42,57,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJAS KIT ACCESORIOS',36,'06','36',0,0,0,41.7,29.4,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA PUNTILLONES',36,'06','37',12,5.4,3.5,46.5,40.5,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA POLLO',36,'06','38',15.5,12,20,38.8,57,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA TE X 14',36,'06','39',13.9,5,6,28.4,38.9,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA DISPENSADOR',36,'06','40',21.5,11,18,36,66.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJAPUNTILLA CABEZA',36,'06','41',7.5,5.5,10,41.5,55,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA SOBRES DE PANELA X 20',36,'06','42',11.7,6.1,7.8,32.9,78.6,4,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (2.5, 3.5, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA GALLESTAS X 240gr',36,'06','43',14,6,20,59.2,43,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA MONALISA CON INSERTO',36,'06','44',24.3,8.2,8.3,58.1,68,2,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (20.6, 5.8, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJAS AROMATICAS X 20',36,'06','45',11.5,6,3.5,51.6,73.2,8,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('DISPLAY MR BROWN X 10 (2013)',36,'06','46',17,16.5,10.2,55.8,88.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA INES MINI',36,'06','47',16.1,8.9,5,28,70,2,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (12, 5.5, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA INES NUEVO DISEÑO',36,'06','48',14.6,9.7,6,31.5,67,2,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (11, 6.7, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA AR 185',36,'06','49',18.5,18.5,18.5,51.9,76,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (13, 13, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CJ BOTA MANFER',36,'06','50',23,11.5,32,58,70.9,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CJ MAGNA',36,'06','51',12,11.5,8.3,35.7,77.5,2,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (8.5, 9, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CJ KID ELASTICO',36,'06','52',16,10,4.5,45,53.4,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA DENTALSTAND 5',36,'06','53',17,9.5,17.5,64.8,56.6,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('DISPLAY PEQUEÑO 50g X 12',36,'06','54',14.7,11.5,9,43.5,70.6,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('DISPLAY PEQUEÑO125g X 12',36,'06','55',18.5,11.5,17.8,58.4,82.2,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA MIEL X 40',36,'06','56',15.2,8.8,10,51.9,49.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA PUNTILLAS 2 1/2" ',36,'06','57',9.1,4.9,4.5,59,58.7,8,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA PUNTILLAS 2" ',36,'06','58',9.1,4.9,6,64.5,58.7,8,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA PUNTILLAS 4" ',36,'06','59',8.2,4.9,12.6,46,82.6,6,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA DENTALSTAND 4',36,'06','60',9.5,9.5,20,69.4,40.8,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CJ CLAVOS PARA ZINC AMARILLA',36,'06','61',7.5,5.5,10,38.5,86.3,6,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('DENTALSTAND ROJA 2 PLUS',36,'06','62',10,9,19.5,67.5,41,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CJ DOSIFICADOR JABON',36,'06','63',11,9,17,60.7,43,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CJ DENTAL STAND 2 ',36,'06','64',10,7,12.5,48.7,36.7,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('DISPLAY PANELA',36,'06','65',16,12.6,17,55.6,71.6,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA SOLUBLE ÉXITO +  NIDO',36,'06','66',21.8,8.3,15.5,43.6,63.5,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (18, 10, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA AROMATICAS',36,'06','67',9,7,8,77,31.5,4,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (2.2, 8.6, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA FILTRO HUMBOLDT',36,'06','68',7,7,18.5,31.8,29.4,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA PUNTILLONES AZUL',36,'06','69',5.5,7.5,11,44,57,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA CLAVOS VARELA',36,'06','70',16.5,4.5,4.5,47,26.7,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA NATILLA',36,'06','71',11,4.2,16.7,64.1,51.8,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA POLLO BROASTER',36,'06','72',22,15,9.5,37,75.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA EXPRIMIDOR NARANJA',36,'06','73',23.5,12,13.5,34.5,72.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA NATILLA DOÑA LEO',36,'06','74',11,4.2,16.7,33,51.8,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BROWNIES CAFÉ',36,'07','1',20.1,10,7,68.1,37.1,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BROWNIES, CAJAS',36,'07','2',19.9,10,7,67,35.6,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('NIDO',36,'07','3',15,8.5,7,29.1,25.1,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA POLLO PROCOPA',36,'07','4',24.1,16,7,68.6,47.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA 1/2 POLLO DOMICILIO PROCOPA',36,'07','5',15.9,15.4,7,52.2,73,3,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA PONQUE X 500 GRAMOS',36,'07','6',18,18,7,62.6,63,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA PONQUE X 300 GRAMOS',36,'07','7',16,16,7,54.5,52.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA POLLO(2) 1/2 POLLO MESA (2)',36,'07','8',0,0,0,89.3,47.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA MEDIO POLLO DOMICILIO',36,'07','9',15.9,15.4,5.1,52,73,3,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA POLLO(2) 1/2 POLLO DOMICILIO (1)',36,'07','10',0,0,0,59.2,81.7,3,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA MANTECADA X 9',36,'07','11',18.5,11,3.5,51,32,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA MANTECADA X 24',36,'07','12',24.4,22,3.5,63,54,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJAS FOTOGRAFIA',36,'07','13',3.5,20.9,15.7,110,75,5,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('DIVISIONES LARGAS COMBO',36,'08','1',24.5,6,0,24.5,24,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('DIVISIONES CORTAS COMBO',36,'08','2',16,6,0,24.5,24,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('SEPARADORES     CIA SABOR',36,'08','3',14.9,4,0,23.6,29.7,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BONGO  MULTIDOMCILIOS',36,'08','4',0,0,0,39.6,17.4,3,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('DIVISIONES TIGO',36,'08','5',0,0,0,36.8,28,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('NIDO CAJA FELIZ',36,'08','6',17.5,9.5,9,44.4,19,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('NIDOS CJ BROCHETA - CJ DESAYUNO',36,'08','7',0,0,0,45,26,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('EXTRACTOR VIDRIO',36,'09','1',6.5,6,13.8,44.5,25.7,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('EXTRACTOR BIBERON',36,'09','2',11.5,6.1,14.2,46.5,36.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('JENNY GENERICA',36,'09','3',19.5,9,34.5,53.4,59.3,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (26, 14.5, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('',36,'09','4',26.7,12.6,42,65.5,81.5,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (32, 19.6, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('TISANAS X 8 ORQUIDEAS',36,'09','5',14.2,5.3,5.9,81.4,55.8,8,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PROTECTOR DE PEZÓN',36,'09','6',7.2,4.2,7.2,24.2,18,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('RECOLECTOR DE LECHE',36,'09','7',8.7,5.3,8.7,22.3,29.4,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('SORBIFLEX R-70',36,'09','8',9,2.5,23.5,48.7,30.7,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('ASPIRADOR NASAL',36,'09','9',3.8,3.8,9.2,29.7,16.2,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('alfa trading 3"x3"',36,'09','10',14.9,10.9,13.1,34.2,52.9,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('AROMATICAS ',36,'09','11',14.2,5.2,5.9,55.7,40.4,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('AROMATICAS COLSUBCIO',36,'09','12',14.2,5.2,5.9,55.6,40.5,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('TISANAS ORQUIDEA TIRA',36,'09','13',14.2,5.2,5.8,27.9,81.3,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('D`CRISTAL  LAVADO VAG.',36,'09','14',8.5,7,14.5,28.4,32.4,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('TISANAS COLSUBSIDIO X 2',36,'09','15',14.2,5.2,5.9,28,40.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('TISANAS COLSUBSIDIO TIRA X 4',36,'09','16',14.2,5.2,5.9,27.8,81,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('RECOLECTOR DE LECHE',36,'09','17',8.7,5.3,8.7,29.4,19.9,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA X 175 GRAMOS CELIO',36,'09','18',12,4.8,17,50,35,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('INSTALACIONES DE LA ARTURO SIERRA',36,'09','19',25,18,6,39,49.5,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (14, 9, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('SMARTCARD TIGO',36,'09','20',14,5,9,49.7,57.9,2,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (10, 6, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('DISPLAY BOQUILLAS',36,'09','21',6,6.3,10.5,43.5,37.5,2,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (6.5, 9.5, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('DISPLAY RECOLECTOR DE LECHE',36,'09','22',8.4,8.4,5.5,39.5,31,2,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (10.7, 4.5, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('DISPLAY EXTRACTOR',36,'09','23',6.6,6.6,12.8,49.8,29.5,2,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (8.5, 10, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('DISPLAY COMBO VARIOS + NIDO',36,'09','24',14,6,15,27.5,58.5,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (10, 16.8, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA PROTECTOR DE PEZÓN',36,'09','25',7.2,4.2,7.2,25.5,34.2,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA PLEG KRAF UEG-11',36,'09','26',19,15.5,11.3,63.4,70.7,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA PLEG KRAF UEP-7',36,'09','27',19,15.5,7.7,56.2,70.7,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('SORBIFLEX R-70 (2014)',36,'09','28',9,3,23.5,32,25.4,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('ASPIRADOR NASAL GERSA',36,'09','29',3.8,3.8,9.2,31.3,17.7,2,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (5.8, 5.4, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('AROMATICAS TE NEGRO X 25',36,'09','30',14.2,5.2,5.9,56.8,40.4,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CJ BIBERON MUNCHI 9 ONZ',36,'09','31',6.1,6.1,19.5,65.7,26.5,2,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (9.5, 12.5, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CJ BIBERON MUNCHI 5 ONZ',36,'09','32',6.4,6.4,14.3,56.2,26.7,2,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (7.8, 10, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('DISPLAY EXTRACTOR VIDRIO GERSA',36,'09','33',6.6,6.6,13.9,49.8,29.5,2,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (8.5, 10, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA PACK LIST',36,'09','34',12,10,8.2,44.7,46.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA PERA RECTAL No. 1',36,'09','35',6.4,6.4,7.5,27.5,33.8,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA TAPABOCAS 4 TIRAS AZUL',36,'09','36',18,11,10,59.4,49.9,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA FIXOSAFE',36,'09','37',5,15.5,5,42.4,15.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA CINTA QUIRURGICA MICROPOROSA',36,'09','38',17,6,11.5,57.5,26.2,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA DISPLAY X 12',36,'09','39',16.5,10.2,10.2,54.9,29.2,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CDAJA GALLETA RELLENA X 10',36,'09','40',18.5,6.4,6.8,52.7,33.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('GUANTES LATEX POR 24',36,'09','41',13.3,3,11.8,28,68,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA MOÑO',36,'09','42',8.5,8.5,13.8,36.5,57.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA # 4',36,'10','1',23.2,22.7,7,37.2,62,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (17, 15, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA # 5',36,'10','2',28,28,7.5,43.3,73,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (20.5, 18, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA # 6 AMERCA CHEESCAKE',36,'10','3',32.5,32.5,7.5,47.5,82,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (21.3, 18, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PONQUESITO',36,'10','4',15,15,9,33.2,50,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('MANTECADAS X 12',36,'10','5',24.3,16,3.5,31.2,42.5,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (13.8, 6.5, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('ÉXITO VINO NUEZ',36,'10','6',20,12,7,40.5,34,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('NICE',36,'10','7',13,12.5,5.6,38,24,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA PONQUÉ HAPPY',36,'10','8',31,31,10,51,84.7,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA # 5 HAPPY TORTAS',36,'10','9',22,22,14,50.2,75,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA # 6 HAPPY TORTAS',36,'10','10',27,27,14,55,85.2,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA # 7',36,'10','11',31,31,14,59,93,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA # 8',36,'10','12',22,22,10,42,67,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA # 9, zc113',36,'10','13',27,27,10,47,76.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA # 10',36,'10','14',16,16,8.8,33.8,52.2,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('ZC-114',36,'10','15',30,30,10,50,82.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BONGO HAMBURGUESA,ORALE GUEY',36,'10','16',21,19,6,66.3,52.8,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA CUARTA HORNITOS',36,'10','17',28,28,13,54,84.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('ROLLO PORCIONADO',36,'10','18',24,13,13,54,49.7,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA BROWNIES arequipe, azucar y chocolate mama',36,'10','19',14.5,14.5,3.5,43.8,79.9,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA # 1',36,'10','20',12,9,5,44.5,30,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA # 2',36,'10','21',17,12,5,54.5,36.2,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('ÉXITO CHIPS DE CHOCOLATE',36,'10','22',20,10,4.5,58.5,31,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA NAVIDAD.RECT X500 GRS',36,'10','23',20.5,10.5,7.8,36.2,78.7,2,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (14, 5, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA NAV.REDONDO X 1000 GRS.',36,'10','24',20,20,8,72.5,64,2,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (17.5, 11, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA ARROZ',36,'10','25',12,10,13.5,54,42.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PONQUÉ VINO Y NUEZ,coma',36,'10','26',20,12,7.5,34,40.5,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (8.5, 7.5, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PONQUÉ 16X16X10/ HAPPY TORTAS Nº 10',36,'10','27',16,16,10,33.8,53,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PONQUÉ REGALO',36,'10','28',9,9,5.5,20.6,37.3,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PONQUÉ 27X27X10/ HAPPY TORTAS Nº 9',36,'10','29',27,27,10,47,77,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PONQUÉ 45X45 TAPA/ HAPPY TORTAS Nº4',36,'10','30',45,45,12,69,60,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PONQUÉ 45X45 BASE/ HAPPY TORTAS Nº4',36,'10','31',45,45,12,69,59,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('MATEOS PIZZA',36,'10','32',22,22,3,28.3,53,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('MANTECADA NAV.GUA',36,'10','33',24.3,16,3.5,31.5,42.5,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (19, 9, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('TURRON DE MANI LUCERNA',36,'10','34',19.5,6.5,4,27.5,92.5,4,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (6.5, 3.5, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PONQUÉ 33X33X12',36,'10','35',33,33,12,57,93,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('DORI POLLO DOMICILIO #2',36,'10','36',21,13.2,5,31,38.4,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA # 1 NUEVO TAMAÑO',36,'10','37',15,9,5,25,60,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PONQUE GRANDE',36,'10','38',30.5,30.5,14,58.5,92,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (20.3, 14, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CHICK POLLO',36,'10','39',16.5,8,5,24.6,50.3,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('P.P.C PIZZA',36,'10','40',20,20,3,26,48.4,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA TORTA    ',36,'10','41',23.5,23,14,51.3,77.5,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (16.3, 14.8, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA NO. 2 2 PORCIONES',36,'10','42',10.5,7.9,18,68,38.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA  TERCERA HORNITOS',36,'10','43',33,33,13,59,94.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('MEDIO BRAZO',36,'10','44',12,20,9,76,44.1,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA QUINTA',36,'10','45',22,22,13,48,72.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA CERO LOS HORNITOS P1',36,'10','46',48,48,12,63,72,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA CERO LOS HORNITOS P2',36,'10','47',48,48,12,63,72,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA PRIMERA LOS HORNITOS P1',36,'10','48',45,45,12,68,60,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA PRIMERA LOS HORNITOS P2',36,'10','49',45,45,12,68,60,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA No 4 REGALO',36,'10','50',23,23,7,75,62.5,2,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (14.5, 14.5, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA BRAZO LOS HORNITOS',36,'10','51',32,12,9,50,44.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CJ SEGUNDA LOS HORNITOS P1',36,'10','52',38,38,12,62,53,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CJ SEGUNDA LOS HORNITOS P2',36,'10','53',38,38,12,62,52.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA No 3 REGALO',36,'10','54',6.2,19,19,31.5,53,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (12, 12, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA PEQUEÑA REGALO',36,'10','55',5.5,12.5,12.5,47.4,38,2,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (8, 8, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CJ AROMÁTICAS X 60 FRUTALIA',36,'10','56',16,12,8.5,82,49.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CJ HERBAL X 40 FRUTALIA',36,'10','57',13.1,14,7.5,79,48.8,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CJ TRADICIONAL X 120',36,'10','58',18,21,8,89.2,60,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CJ PEQUEÑA LAS MERCEDITAS',36,'10','59',18,12.5,6,59.2,39,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CJ ESTÁNDAR LAS MERCEDITAS',36,'10','60',19,15.4,7.5,68,48.2,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CJ GRANDE LAS MERCEDITAS',36,'10','61',20,20,9.4,38.8,60.8,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CJ AROMATICA HERBAL X 100',36,'10','62',21,20,7.5,46.4,62.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CJ COMBO VARIADITO',36,'10','63',34.7,25,7.8,47.8,68,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA WOK-IN BOX',36,'10','64',19.2,5.2,16.7,28,50.3,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA CUP CAKES PEQUEÑA',36,'10','65',11.5,11.5,9.5,31,44,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (15.9, 6.5, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA CUP CAKES Nº 3',36,'10','66',10.2,24,9.5,43.5,57,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (15.2, 13.3, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA CUP CAKES Nº 6',36,'10','67',18,24,9.5,43.5,81,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (20.2, 15.2, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA BROWNIE PEQUEÑA',36,'10','68',15.4,15.4,3.5,22.5,41.4,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (12, 12, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CJ 45 X 45 X 12 PARTE 1',36,'10','69',45,45,12,69,62.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CJ 45 X 45 X 12 PARTE 2',36,'10','70',45,45,12,69,57,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA PONQUECITO VENTANA',36,'10','71',13.5,13.5,10,33.5,49,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (16.5, 6.8, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA PIZZA 37X37X3',36,'10','72',37,37,3,43,83,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA  28X28X10',36,'10','73',28,28,10,48,78,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA PONQUE PARTE 1',36,'10','74',30,30,15,38.6,73.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CJ MEDIO POLLO USAQUEN',36,'10','75',18.2,13,5.6,58.8,39.2,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA 31X31X14',36,'10','76',31,31,14,58.8,92.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CJ POLLO USAQUEN',36,'10','77',19,14,7.9,70,49,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA PIZZA 24X24X3',36,'10','78',24,24,3,30.5,58,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('KRISPY / PUFFY´S',36,'11','1',24.7,8.5,6,37,34.3,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (17.8, 7.5, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CJ KRISPY KREME PEQUEÑA',36,'11','2',18.6,27,5.7,59.6,71,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CJ KRISPY KREME GRANDE',36,'11','3',36.5,27.5,5.7,48,72.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CJ KRISPY KREME PEQUEÑA CABIDA 1',36,'11','4',18.6,27,5.7,29.8,71,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA BROCHETA',36,'11','5',30,15,4,57.5,46.8,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA DESAYUNO',36,'11','6',25,25,5.5,36,66.6,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA PONQUE ESPECIAL CON VENTANA',36,'11','7',20,15,7,52,69,2,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (16.8, 12, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BURGER KING',36,'11','8',32,24.5,60,67,44.2,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PECHERAS HOMBRE',36,'12','1',38.4,22.5,0,84,22.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PECHERAS NIÑO',36,'12','2',32,19,0,64,19,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PECHERAS NIÑO',36,'12','3',19,29,0,19,64,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PECHERAS PK MODA',36,'12','4',32,20,0,20,70,0,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PECHERAS/ CARTON GRAFICAS',36,'12','5',32,21.8,3.3,21.8,70.7,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA MARISELA',36,'13','1',28,13.9,4,36.1,80.8,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BROWNIE X 6 AREQUIPE CHOCLATE',36,'13','2',20.5,17,4,57.5,92,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA PONQUE LAYER (CHOCOFIESTA MORA)',36,'13','3',23,15.5,4.5,32,89.1,2,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (11.5, 10.5, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BROWNIR AREQUIPE CAB 2',36,'13','4',20.5,17,4,57.5,46,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA REGALO 1/2 DOC.',36,'14','1',14.7,14.7,9.5,60.2,32.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PANETONES/CARREFOUR OLIMPICA',36,'14','2',17,17,18,69,46,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BIMBO PANETON ',36,'14','3',17,17,18,69,46,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BIMBO PANETON ',36,'14','3',17,17,18,69,46,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BIMBO MAMA INES/GUADALUPE',36,'14','4',15,15,16,68.7,45,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PANETTONE CARULLA-SURTIMAX',36,'14','5',17,17,18,67.8,45.4,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PANETTONECARREFOUR',36,'14','6',17,17,18,67.8,46,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PANETTONE MARK FRESH',36,'14','7',16.6,16.6,18.2,67,49.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA GRANDE MARRANO VOLADOR',36,'14','8',17.5,23,14.5,83,56,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA PEQUEÑA MARRANO VOLADOR',36,'14','9',11,17,11,58,40,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA MENU INFANTIL NIEVO',36,'14','10',16.7,20.5,7.5,76.4,35,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('1/2 POLLO',36,'15','1',15.5,15,4.6,49.8,44,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA CENEFA',36,'15','2',8.6,11.2,11.2,42.6,40.8,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('TAPITAS DANILO',36,'16','1',6.3,6.3,0,46.6,19.8,21,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('TAPAS 1 LT.',36,'16','2',10.8,10.8,1.3,19.8,52.8,7,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('TAPITAS',36,'16','3',6.5,6.5,0,40.5,20.2,18,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('TAPAS,LA CAMPIÑA',36,'16','4',20.7,20.7,2.4,51.5,25.4,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('TAPAS SKY   X 8 LITROS',36,'16','5',21.3,21.3,2.2,25.4,51.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('FONDOS X 2 LITROS',36,'16','6',15.8,0,0,15.8,66.5,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('SOLAPAS DE OBLEAS',36,'16','7',16.5,0,0,33.5,33.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('TAPITAS D.  NUEVO ',36,'16','8',6.4,6.4,0,46.5,18.9,21,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('OBLEaS DISEÑO NUEVO CELIO',36,'16','9',16,0,0,33,33,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('TAPITAS POPSY RUEDITAS',36,'16','10',0,0,0,32,21.3,6,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('MASCARAS MADAGASCAR 3',36,'16','11',0,0,0,38,52,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('FRUGALLETA MORA Y GUAYABA',36,'17','1',4.5,5.5,21.1,30,85.2,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('NATILLA DE KONFYT',36,'17','2',16.5,11,4,48.5,63.4,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('NATILLA RICURA DE LA CASA',36,'17','3',16,11,4.3,49,62.4,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA TORTA DE CHOCOLATE',36,'17','4',19,12,5,52,35.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA CEREAL IMPORCOL  230G, 240 G 250 G ',36,'17','5',18,5.7,28.1,74.5,49,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('HOJUELAS AZUCARADAS CARREFOUR X 730G',36,'17','6',24,6.8,36,46.6,63.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('ARROZ ACHOCOLATADO 700g',36,'17','7',24,9,36,48.8,67.3,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('ARROZ ACHOCOLATADO 550g',36,'17','8',22,7.8,34.5,48,60.8,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('HOJUELAS DE MAIZ X 500gr',36,'17','9',22,5.8,34.5,44,57,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('ARROZ ACHOCOLATADO X 320gR',36,'17','10',18,7.5,28.1,45.5,52.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA CERAL CAFAM PEQUEÑO',36,'17','11',16.3,5.4,25,32.5,45,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CORN FLAKES X 500GR',36,'17','12',20,8.3,33,43.9,58.1,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PONQUÉ X 500 GRS./PONQUE DE VINO Y NUEZ GUADALUPE',36,'18','1',17,17,7,50.4,63,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('ÉXITO naranja/Guadalupe 0% azucar',36,'18','2',17,17,7,62.5,50.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PONQUÉ X 1000 GRS./GUADALUPE',36,'18','3',20.5,20.5,8,59.5,74,2,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (13.5, 10, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PONQUE GUDALUPE MAMA INES LALO',36,'18','4',20.5,20.5,8.5,37.5,59.9,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (13.4, 10, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PONQUÉ X 500 GRS./PONQUE DE VINO Y NUEZ GUADALUPE',36,'18','5',17,17,7,50.5,63,2,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (11, 6, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('DISPLAY X 24 SANTILLANA',36,'18','6',15.5,20,7,64,47,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PONQUE VINO / FRUTAS NAVIDAD BIMBO',36,'18','7',20.5,20.5,8.5,76.5,60,2,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (10, 12.5, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PONQUE VINO / FRUTAS NAVIDAD BIMBO',36,'18','8',20.5,20.5,8.5,76.5,60,2,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (16, 15, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('DISPLAY X 24 SANTILLANA',36,'18','9',15.5,20,7,34,47.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA LOVERS LIBRA (GRANDE)',36,'18','10',12,12,12,58.8,52.8,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA LOVERS 1/4 LIBRA (PEQUEÑA)',36,'18','11',8,8,8,42.4,33.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA VELITAS',36,'18','13',7,7,13,24.4,29.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA LOVERS 1/2 LIBRA (mediana)',36,'18','12',9.8,9.8,10,43.6,48.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('TRIPACK VASOS MUNDIAL',36,'18','14',26.6,9,16.3,34.3,78.7,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PANETONE GUAD/EXIT COMA',36,'19','1',18,9.5,9.5,58.5,46.2,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('MONTAJE P NAVIDEÑO X 500gr / 1000',36,'19','2',0,0,0,54.5,92,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (14, 8.5, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('HEXAGONAL NAVIDAD LOS HORNITOS',36,'19','3',13.3,13.3,11,51.6,82.5,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (13.5, 13, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('HEXAGONAL CRISPETA X 46oz ',36,'19','4',6,6,17,69.3,37,3,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('HEXAGONAL CRISPETA X 130oz',36,'19','5',9.2,9.2,17.6,83.5,56,3,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('HEXAGONAL CRISPETA X 170oz',36,'19','6',11,11,17.6,58.5,65.2,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PONQUE NAVIDEÑO HEXAGONAL 500gr',36,'19','7',8.6,8.6,8,52.7,55.5,2,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (11, 6, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PANETTONES ÉXITO',36,'19','8',8.5,8.5,17.5,87.5,52.6,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PONQUE  NAVIDEÑO X 1000gr',36,'19','9',11.5,11.5,8.5,43.6,70.8,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (14, 8.5, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA CRISPETA PEQUEÑA',36,'19','10',10.5,10.5,14.7,63.6,42.7,3,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CRISPETA MEDIANA PAMPLONA',36,'19','11',10,10,19,84.6,55.8,3,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PLATANITO/ PROCOPA',36,'20','1',17.8,4.5,4.5,29.7,54,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PLATANO  PROCOPA',36,'20','2',24.7,4.5,4.5,36.7,52.4,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PLATANO DOMICILIO/ C.B.C',36,'20','3',23,4.5,4.5,49.2,69.4,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PLATANO A LA MESA',36,'20','4',23,4.5,4.5,34.7,27,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PLATANO DELIMA',36,'20','5',22.1,5,4.5,31.2,44,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PLATANO DOMICILIO C-MIO, C-VEA, BRASA',36,'20','6',0,0,0,34.5,73.5,3,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PLATANO DOMICILIO CM / CV',36,'20','7',23,4.5,4.5,69,49,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PLATANO A LA MESA',36,'20','8',24.7,4.5,4.5,69.2,27,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CUADRO INFANTÍL',36,'21','1',35,25,6,46.7,36.7,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('FRANCESAS/ AMERCA POLLO',36,'22','1',6,6,6.5,52.9,27.5,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('SORBIFLEX 650',36,'23','1',20.8,14,13,30,70.8,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('SORBIFLEX 705',36,'23','2',15.3,23.5,14,33.2,76.6,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BANDEJA MILHOJAS',36,'24','2',30,11,6,42,22.8,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BANDEJA GRANDE#10',36,'24','3',37.5,27.5,5.5,48.5,38.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA  # 11',36,'24','4',37.5,27.5,4,35.5,45.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('MUESTRA TSTIGO 2',36,'24','5',27.4,20.9,5.5,31.7,38.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('SABROSURA, PANELITAS',36,'24','6',9,9,3,30,30,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('KONFYT JALEAS',36,'24','7',12.5,6,3,25,53,3,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('KONFYT JALAEAS NUEVO TAMAÑ0',36,'24','8',10.5,5.5,6.5,37,79.8,3,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('KONFYT MUESTRA JALEA',36,'24','9',0,0,0,37,27,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BANDEJA SCHOTT No 10',36,'24','10',37.4,27.5,5.5,77,48.4,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('NIDO CJ COMBO VARIADITO',36,'24','11',25,8.5,7.2,39.5,46,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA BASE 11',36,'24','12',37.5,27.5,4,71,45.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BANDEJA PONQUE',36,'24','13',33.5,9.7,5,43.5,39.8,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('NIDO RUBIALES GRANDE',36,'24','14',0,0,0,25.1,20,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('SOPORTE PURA VIDA',36,'24','15',19.4,39,3.6,43.3,43.6,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('SOPORTE CAJA DOMICILIOS',36,'24','16',7.2,17.5,2.3,35,21.6,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA VELEÑO X 10',36,'24','17',11.2,10.2,2.5,39.6,32.8,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA AREPA',36,'24','18',19,19,3,50.4,28.8,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PORTAREPA-PERRO BANDEJA',36,'24','19',0,0,0,45.2,24.5,3,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('SEIS CAMISAS BASES',36,'25','1',33.8,22,18,70,58,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BANDEJA MANTECADA',36,'25','2',35.3,23.5,4,86.4,62.6,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BASE P, 19,5X14',36,'25','3',19.5,14,3,20,76.5,3,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BASE M23X14,5',36,'25','4',23,14.5,3,29,61.5,3,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BASE GRANDE 30X20',36,'25','5',30,20,2.9,26,72.2,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BANDEJA MEDIO POLLO TAYLOR',36,'25','6',15,11,4,23,38,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('NUGUETS SHOW PLACE',36,'25','7',10,6.5,3.5,34.5,27.5,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CASSATA',36,'26','1',12.3,8.4,18.8,42.7,36,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('MEDIO POLLO A LA MESA',36,'27','1',12.5,10.5,5,22.3,20.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('FRANCESA TRADICIONAL',36,'28','1',6,6,12,39.6,52.8,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CRISPETAS MED. ROYAL',36,'28','3',10,10,19,57.2,55.7,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CRISPETAS PEQ. ROYAL',36,'28','4',9,9,14.2,67.6,48.4,3,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CRISPETAS PEQ.',36,'28','5',9,9,14.2,87.4,48.4,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CRISPETAS MED.',36,'28','6',10,10,19,83.5,56,3,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CRISPETAS GRAND',36,'28','7',11,11,24.2,67,63.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CRISPETAS GRAND ROYAL',36,'28','8',0,0,24,33.9,63.7,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CRISPETA GRANDE CASANARE ARMAR',36,'28','9',11,11,24,33.9,63.7,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CRISPETA PEQUEÑA CASANARE',36,'28','9',8.5,8.5,14,21.5,47,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CRISPETA  PEQUEÑA',36,'28','10',8,8,14,21,55.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CRISPETA PEQUEÑA CASANARE X 3',36,'28','11',8.5,8.5,14,68.5,47,3,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CRISPETA MEDIANA CASANARE',36,'28','12',10,10,19,55.2,57.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('FRANCESA NUEVO DE LLEVAR C.B.C',36,'28','13',6,6,12,43.5,60.4,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA ANTOJOS MADRES',36,'28','14',13.5,13.5,17.6,67,57,2,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (21.5, 9, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA ACCESORIOS',36,'28','15',14.5,7.5,14.5,30,30,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CRISPETA MEDIANA PAMPLONA',36,'28','16',10,10,19,84.6,55.8,3,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CRISPETA GRANDE PAMPLONA',36,'28','17',11,11,24.2,64.5,64,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PAPAS FRANCESAS WIMPY',36,'29','1',8.2,1.5,13.9,27.7,28.7,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('FRANCESA C.B.C DISEÑO NUEVO',36,'29','2',8.8,3.7,12,92.4,36.9,6,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('FRANCESA TAMAÑO NUEVO C.B.C TRES REF',36,'29','3',8.8,3.7,13,84.5,35,6,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('FRANCESA PPC',36,'29','4',9.5,8,9.5,58.2,31.5,5,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('FRANCESA PPC',36,'29','5',9.6,8,9.5,33.1,66,6,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA POLLO ADRIANA DEVIA',36,'30','1',20.3,12,19,58,34.8,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('DIPROFOS VHF',36,'30','2',0,0,0,26.5,22.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA SNACK',36,'30','3',24,0,17.5,58.2,29.3,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PIRAMIDAL ARROZ',36,'31','1',9,7,8,58,35.7,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA PAPAS',36,'31','2',10,8.5,4.5,56.6,43.3,8,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CHINA WOK GRANDE',36,'31','3',9,7,14,59.5,47.8,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CHINA WOK PEQUEÑA',36,'31','4',9,7,10,59,39.8,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('FRANCESAS INV.RS.',36,'31','5',8,3.3,8.3,17.3,58.7,3,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PIRAMIDAL 2,5',36,'31','6',12,10,13.5,42.5,54,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PIRAMIDAL 3,5',36,'31','7',13.5,12,13.5,43.5,56.8,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('FRANSESA PROCOPA',36,'31','8',8,3,11,67.5,32.5,6,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('ARROZ y VERDURAS PIRAMIDAL TIRA ',36,'31','10',8.8,7,8,28.7,71.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('WOK',36,'31','11',7,9.2,11.4,39.5,39.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('WOK NUEVO',36,'31','12',0,0,0,35.5,36.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA GRANDE LOS POLLITOS',36,'31','13',12,16,15,61,61,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA PEQUEÑA LOS POLLITOS',36,'31','14',0,0,0,47.3,47,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA MEDIANA LOS POLLITOS',36,'31','15',0,0,0,54.7,56.3,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA ALITAS TOY EXPRESS',36,'31','16',0,0,0,67,37,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA MINI PIE',36,'31','17',0,0,0,39.5,69,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('LIANG CAJA ARROZ',36,'31','18',0,0,0,46.5,46.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA CAJA MEDIO ARROZ',36,'31','19',9.5,7,11.5,36.6,36.6,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PI ENTERO',36,'31','20',0,0,0,61.2,61.2,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA MEDIO ARROZ WOK-IN',36,'31','21',9.5,7,11.5,38.2,42,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PIRAMIDAL VERDURAS TOY WAN',36,'31','22',10.9,9,8,59,36,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA ALITAS TOY EXPRESS',36,'31','23',12,10,8,62.5,37,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA AREPAS BOYACENSES',36,'31','24',18.8,15.8,9.4,51.2,92.7,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA POSTRE TIPO LONCHERA',36,'31','25',13.5,13.5,9,42.5,40.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA 22X22X12 con manija',36,'31','26',22,22,12,56,55.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA 22X22X14 con manija',36,'31','27',22,22,14,58.4,58.4,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA 16x16x10 con manija',36,'31','28',16,16,10,43.5,43.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA 31x31x14 con manija',36,'31','29',31,31,14,43.2,75.8,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA 27x27x12 con manija',36,'31','30',27,27,12,62.9,62.9,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA 27x27x14 con manija',36,'31','31',27,27,14,64.2,64.2,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA 13x13x9 con manija',36,'31','32',13,13,9,39.2,39.2,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA 17x17x12 con manija',36,'31','33',17,17,12,47,47,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA 30*30*14 2 PARTES',36,'31','34',30,30,14,43,74.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA 20x14x12 con manija',36,'31','35',20,14,12,59.5,52.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA CUP CAKES',36,'31','36',9,9,7,33.5,32.5,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (7, 4, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA ESPECIAL 23x23x14',36,'31','37',23,23,14,64.6,64.6,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA MALETIN MEDIO BRAZO',36,'31','38',20,12,9,88.5,46.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA BROWNIE X 4',36,'31','39',17,17,4.5,44,42,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA 32x32x12',36,'31','40',32,32,12,70,70,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA 26,5x26,5x12',36,'31','41',26.5,26.5,12,63,63,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA 22x22x12',36,'31','42',22,22,12,56.5,56.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA18x18x12',36,'31','43',18,18,12,53,53,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA DOMICILIOS (DELIVERY)',36,'31','44',11,9.2,9.5,63,37.3,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('POSTRE DELITORTAS',36,'31','45',13,13,9,38.7,77.6,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CJ 25X25X14',36,'31','46',25,25,14,62.6,62.6,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA POSTRE ',36,'31','47',16,16,10,48.5,48,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA 27 X 17 X 14',36,'31','48',27,17,14,58.5,71.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('V.H.F EMPAQUE 9X9',36,'32','1',9.3,9.3,2.3,32,28.9,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PORTAPERROS',36,'33','1',17.5,5.5,4,66.4,53.6,12,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PORTAPERROS ROYAL FILMS',36,'33','2',19.3,6.4,4.5,29.5,52.3,3,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PORTAPERROS/ FRIAS',36,'33','3',18.1,4,4,57.2,23.9,5,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PORTAPERROS WIMPY',36,'33','4',20,6.1,4.4,57.4,30.3,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PORTAPERROS JAVERIANA',36,'33','5',17.8,5,3.9,38.4,44.2,6,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('LA CASONA Y CANOA',36,'34','1',13.5,8.4,5.4,38,49.2,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('HUESERA',36,'34','2',13.3,9.7,4.8,46,58,6,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA CENEFA OLIMPICA',36,'34','3',13.2,9.4,5.3,59.2,47.1,6,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BANDEJA PAPA SALADA',36,'34','4',13.5,8.5,5.3,38.2,49,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BANDEJA POLLO',36,'34','5',18.5,9.3,5.5,40.8,59,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA HUESERA',36,'34','6',13.7,8.5,5.2,37.8,73,6,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BANDEJA PROMOCIONAL',36,'34','7',16,12,4.5,75,47,3,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA OBSEQUIO POPSY',36,'35','1',13,10,12,31,47.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA X 24 STAR QUIMICOS',36,'35','2',11.4,11.6,7.6,49,57.3,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('EMPAQUE PERRUCHI',36,'36','1',4,4,21,30,34.5,2,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (2.3, 2.5, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('EMPAQUE PERRUCHI PEQUEÑO',36,'36','2',0,0,0,21,34.5,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (4, 4, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA PIE',36,'37','1',23.5,23.5,5,45.7,67.4,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CUBETA X 5 LTRS.',36,'38','1',27,0,12.5,87.5,30.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CUBETA X 3,5 LTRS./ DOBLES',36,'38','2',23,8,13.5,80.3,65.2,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CUBETAS X 5 DOBLES',36,'38','3',27,7.7,12.5,87.5,58.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CUBETA 3,5 LTS',36,'38','4',23,0,13.5,80,32,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CJ CUBETA',36,'38','5',23.4,13,12.3,70.4,30.4,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BASES BARRILES (7 LTROS)',36,'39','1',0,0,0,68,26.1,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('FONDO CUBETA SAN JERONIMO',36,'39','2',0,0,0,23.4,13,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('FONDO CUBETA SAN JERONINO 1',36,'39','3',23.5,13,0,50,70,5,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('ALMAS',36,'40','1',14.8,34.7,0,69.5,45,6,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('ALMAS X 8',36,'40','2',34.8,14.8,0,69.7,60,8,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('TIRILLA TIENDA',36,'40','3',52,17,0,34.5,52,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('ALMAS NUEVAS 2012',36,'40','4',40.6,15,0,79.2,51,6,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('ALMAS NUEVAS 2013',36,'40','5',40.2,14.9,0,50.4,74,6,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('ALMAS NUEVAS 2014',36,'40','6',37.2,14.1,0,52.1,74.5,7,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('ALMA NUEVA 2015',36,'40','7',40,14.9,0,80,59.6,8,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('UNA DOCENA',36,'41','1',26.5,13,9,82.4,31.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CORRALITO,MENU INFANTIL',36,'41','2',18.2,11,10.5,54.7,60,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('MENÚ INFANTIL7 american pollos',36,'41','3',14.9,9.8,9.8,28,51.3,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('MED.POLLO TODO BROASTER',36,'41','4',15,6.5,15.5,29.3,44.6,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CORRALITO,MENU INFANTIL',36,'41','5',18.2,11,10.5,27,60,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('medio pòllo maletin LOS POLLITOS',36,'41','6',15.5,7.2,15.5,30,46.9,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('MENU INFANTIL INV. ROSADO',36,'41','7',15,9.9,9.7,28,51,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CRISPETA CINEMARK COMBO',36,'41','8',19,14.5,22.5,44,68.4,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('MENU INFANTIL CHOPINAR',36,'41','9',32.5,10,9.5,86,54,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('MEDIA DOCENA NUTRIX',36,'41','10',14.7,14.7,9.5,32.5,60.2,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CORRALITO X 3',36,'41','11',18.2,11,10.5,79.3,60.1,3,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA MENÚ INFANTIL  PPC',36,'41','13',15.3,10,9.7,26.1,52.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('MALETÍN DOCENA NAVIDAD NUTRIX',36,'41','14',26.5,15,9.2,33,85,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('MALETÍN POLLO SAN ISIDRO',36,'41','15',20,12.2,12,34.6,65.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('MALETÍN MEDIO POLLO SAN ISIDRO',36,'41','16',17.4,9.6,9,27.6,55.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('MALETÍN ',36,'41','17',17.3,11.5,9.3,29.6,59.1,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('MENU INFANTIL Ed. ESPECIAL HALLOWEN',36,'41','18',13.3,10,12,43.2,48,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('MALETIN MENU INFANTIL ',36,'41','19',23.8,16.8,8,36.8,83.2,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('MENU INFANTIL Ed. ESPECIAL BLANCA',36,'41','20',13.3,10,12,43.2,48,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('MENU INFANTIL MUNDIALITO',36,'41','21',13.9,10.7,12,32.4,52.2,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('EMPANADITAS Y CO',36,'41','22',19.7,12.5,12,29.5,66.2,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA AREPAS SUMERCED',36,'41','23',20,10.3,11.6,54.4,63.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA AREPAS VENTAQUEMADA',36,'41','24',22.5,11.6,12,33.7,69.7,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('SOLAPAS EL CHEFF',36,'42','1',15.3,7.4,5.8,25.5,31,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('FAJA DE CHOCOLATE',36,'42','2',12.1,10.1,0,31.9,24,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA DE CD LEENA LOVE',36,'43','1',0,0,0,26.6,68.8,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CALENDARIOS SIERRA MAR /  CARTONGRAFICAS ',36,'44','1',22,5.7,14.3,44.5,39.4,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('DIDACTICAS Y MATEMATICAS CALCULIN 3',36,'45','1',21.5,0,31.5,31.5,43.2,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CARPETAS DIDACTICAS Y MATEMATICAS',36,'45','2',22.5,0,34,42.9,46.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('SOBRE CRAVATTE PUNTO MARINO',36,'45','3',14.5,0,39,49,62,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('FOLDER MOSTRARIO',36,'45','4',33,0,40,50,80,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BROCHURE CARTONGRAFICAS',36,'45','5',0,0,0,58.5,40,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CARPETA SU FACTURA SU INVENTARIO',36,'45','6',22.5,1.5,26.5,39.8,79.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('SOBRE JAMON SERRANO',36,'45','7',0,20.4,25.6,44.8,59.9,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BIT MIX',36,'45','8',19,8,9,52,57,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BABY TAPA',36,'46','1',59.5,30.3,15,60,89.8,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (36, 21, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BEBÉ CONSENTIDO',36,'46','2',51.8,20.5,22,64.5,96,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (42, 31.5, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CIELITO,tapa',36,'46','3',45,40,17,74,79,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (37, 30, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('cielito tapa Parte B (PROVICIONAL)',36,'46','5',45,0,16.8,17,79,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('JUNIOR COLECCIÓN',36,'46','6',23,0,30,88.5,57.3,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (30.5, 16, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('MEDIO POLLO NAVIDAD/PROCOPA',36,'47','1',15.8,15.4,5,52.3,45.8,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PROCOPA POLLO/IMPRESO',36,'47','2',24,16.1,4.8,33.7,46,0,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('MEDIO POLLO PROCOPA IMPRESO',36,'47','3',15.8,15.4,5,52.3,45.8,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BELLA PIZZA TAPA',36,'48','1',30,30,3,44,44,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BELLA PIZZA BASE',36,'48','2',29.8,29.8,3.8,46.5,46.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA DISCOVERY',36,'49','1',22,13.5,9.3,48.6,54.2,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA CROSSLANDER',36,'49','2',34,26,11,64,84,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA CARNE  X 500gr',36,'49','3',16,18.5,3,49.3,62,2,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (10.6, 12, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA CARNE  X 220gr',36,'49','4',16,18.5,2,51.8,50.5,2,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (10.6, 12, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('NIDO PIE OMA',36,'50','1',23,23,4,30.9,30.9,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('NIDO PONQUE X 500gr',36,'50','2',17.8,17.8,2.7,23.1,46.2,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('NIDO PONQUE X 300gr',36,'50','3',15.8,15.8,1.5,18.8,56.4,3,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('POLLO/ brasa ',36,'51','1',22,14.5,6,69.2,43,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('MEDIO POLLO',36,'51','2',16,14,5,52,39.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PLATO A LA CARTA',36,'51','3',19.8,13.5,4.5,58.7,38.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('APANADO',36,'51','4',20.4,14,9.5,78.4,49.4,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('MEDIO POLLO',36,'51','5',20,13.8,4.7,59,38.8,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('POLLO PPC',36,'51','6',19.9,15,6,64.1,43.8,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('MEDIO POLLO',36,'51','7',15,11,6,58.8,36.2,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA PAELLA',36,'51','8',18,14,6,42.5,29.8,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('COMBO INVERSIONES ADK LARGO',36,'51','10',17.7,15,4.6,26.9,83.7,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA NEUTRA',36,'51','11',13.5,13.7,3.7,63,36.7,3,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('ARROZ, tira express',36,'51','12',15.5,13.5,5,25.3,78.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('POLLO LA RIVERA',36,'51','13',19.8,14,7,68.8,43.8,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('MEDIO POLLO LA RIVERA',36,'51','14',16,13,5,51.8,38,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('NEUTRA LARGA',36,'51','15',13.5,13.7,4.6,21.2,73.4,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PLATO CARTA LARGO C.B.C',36,'51','16',19.8,13.5,4.5,28.7,77.4,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('medio pollo lago c.b.c,',36,'51','17',15.8,14,5,25.7,80.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('POLLO,cbc tira',36,'51','18',22.2,14.5,6,33.7,86,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('TOY WAN ADK, CLAN',36,'51','19',17,13,4,25,76.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('',36,'51','20',17,13,4,50.5,38,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('DORI POLLO DOMICILIO #3',36,'51','21',18.5,15,4,39.8,26.6,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA MEDIO POLLO CBC',36,'51','22',16,14,5,52.2,80.3,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('MEDIO POLLO PPC',36,'51','23',15,11,6,29.6,72.4,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CUARTO DE POLLO C.B. NUEVO',36,'51','24',15.5,9.5,5.3,52,31,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PONQUE COMA 250 G',36,'51','25',6,14.5,14.5,43.2,26.7,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (9, 5.5, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA BANDEJA TOY WAN',36,'51','26',20.5,13.5,3.8,28,73.8,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PUNTA DE ANCA SUPERHAMBURGESA',36,'51','27',30.5,10.5,6.5,35.8,43.6,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('COMBO INVERSIONES ADK ANCHO',36,'51','28',17.7,15,4.6,53.6,41.7,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('MEDIO POLLO JORGE QUINTERO',36,'51','29',0,0,0,55,50,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('POLLO JORGE QUINTERO',36,'51','30',0,0,0,67,68.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('DOMICILIO CHOPINAR',36,'51','31',10.2,20.5,7.2,33.8,73.8,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('MANTECADA SANJERONIMO',36,'51','32',15.8,8,8.4,41.8,67.8,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA ARROZ Y VERDURAS',36,'51','33',15.5,13.6,5,50.8,39.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA MEDIO POLLO PPC',36,'51','34',15,11,6,56.8,36.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CJ DOMICILIO GRANDE CHOPINAR',36,'51','35',30,103,72,43.2,74,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA CLAN EXPRESS INV. ADK',36,'51','36',17,13,4,50,36.4,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA POLLO',36,'51','37',20,15,6,64.2,44,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA MENU INFANTIL',36,'51','38',17,13,4,50.5,37.8,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA TIRAMISU',36,'51','39',34,10.4,5.9,45.8,34.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA POLLO No. 2',36,'51','40',21,13.2,5,31,38.9,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA PASTAS',36,'51','41',14.8,15.7,4.5,23.8,42.6,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA CUARTO DE POLLO',36,'51','42',12,10,5.3,67.8,32.1,3,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA BOCADILLO X 15',36,'51','43',11.5,11.5,2.3,41.8,45.5,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA CUARTO DE POLLO',36,'51','44',15.5,9.5,5.3,52.2,62.2,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA OJITOS',36,'51','45',13,13,1.8,48.1,41.2,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA MEDIO POLLO PPC',36,'51','46',15,11,6,56.7,72.4,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA PURA VIDA',36,'51','47',19.9,39.5,5,49.5,57.6,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA DOMICILIOS',36,'51','48',20,18,5,35,49,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PLATO NUEVO 2015',36,'51','49',14.3,17.3,4.7,55,82,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA PALETA',36,'51','50',14,24,5,42.1,34,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA PUDIN  40 PORCIONES',36,'51','51',37.9,28.5,9.9,80.8,57.7,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA PUDIN  25x25x10',36,'51','52',25,25,10,74,45,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA PUDIN 30x30x10',36,'51','53',30,30,10,84,50,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA PURA VIDA',36,'51','54',38.4,24,5,48.2,60.6,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('NIDO CAJA PURA VIDA',36,'51','55',37.9,23.6,4,32.6,46.9,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('DISCOVERY Nº 71',36,'51','56',32,14.5,12,65,63,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA X 20 GRS.',36,'52','1',5.2,1.5,7,32.3,29.3,6,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA X 125 GRS.',36,'52','2',7.7,3,10.3,34,45.2,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA X 200 GRS. ',36,'52','3',9.3,3.3,13.3,40.5,52.8,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PAGNOLI HR',36,'52','4',7.2,3,18,44,50.1,4,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (12.5, 4, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PAGNOLI RC',36,'52','5',5,2,15,22.2,45,3,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (12.5, 3, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PASTA LISTA ALIMENTICIA',36,'52','6',12,3.5,25,64.5,32.4,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('ALUMINIO DISCONFITES',36,'52','7',5,5,30.5,81.5,49.3,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA DIN DON',36,'52','8',9.5,4.5,15.7,58.9,28.1,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('GUANTES ESTERILES',36,'53','1',24.5,16.6,25,50.5,78.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CHUPITOS',36,'53','2',8,8,26,33.5,72.2,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA IMPRESA',36,'53','3',7.7,7.7,44.5,63,63.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('GUANTES CORTO ETERNA',36,'53','4',13,13,38,61.2,53.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('ROMPECABEZAS ROYAL FILMS',36,'54','1',0,0,0,24.6,24,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('NUTRICARITAS BANDEJA',36,'55','1',23,9,3,60,58,8,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('MINICALADITOS',36,'55','2',8,5,2,24,18,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BANDEJA MAN-KEKE',36,'55','3',20,15.5,2.5,25,82,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA# 4  BASES OVEJITA',36,'55','4',22,30,6.5,68,41.8,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA OVEJITA BASE N#2',36,'55','5',26,18.3,5.5,37,58.8,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('LAVERPIC 3 TAPA',36,'55','8',28.3,19.8,6.3,64.5,40.7,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('LAVERPIC 3 BASE',36,'55','9',28,19.8,6.3,64,40.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('LAVERPIC 5 TAPA ',36,'55','10',30,22,9,79.6,47.8,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('LAVERPIC 5 BASE',36,'55','11',29.7,21.7,9,39.8,47.7,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA # 4  TAPAS OVEJITA',36,'55','12',22.4,30.3,6.5,43.3,71.6,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA OVEJITA TAPA #2',36,'55','13',26.3,18.3,5.5,37.3,59.4,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('MEDIO POLLO A LA MESA/ PROCOPA',36,'55','14',12.4,10.5,5,41,22.6,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BANDEJA PEKITAS - PIPIOLO',36,'55','15',23,10.5,2,43.5,82.2,9,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('1/2 POLLO A LA MESA',36,'55','16',12.4,10.2,5,67.2,40.4,6,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BANDEJA BROWNIE',36,'55','17',8.3,8.3,1.2,21.4,21.4,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA CUNA',36,'55','18',10,19.5,3,32,45,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('DIVISION BODYS',36,'55','19',18.1,8,2,18.1,36,3,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('SEPARADORES BODYS',36,'55','20',26.7,2.5,19,26.7,26.7,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('1/4 DE POLLO ',36,'55','21',14.7,10.1,5.1,57.8,50.4,3,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('DIVISION BANDEJA',36,'55','22',1.8,13.5,3.7,22,27,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('TWINKIES',36,'58','1',26.3,12,2,60,48,8,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BANDEJA MR.BROWN',36,'58','2',16.5,13.5,1.5,53.8,39,8,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('DALMATA,gansito',36,'58','3',26.4,12,2.5,62.8,48,8,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PINGÜINO,mankeke',36,'58','4',20,14,2.4,49.5,56,8,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('SOLAPAS MARISELA',36,'58','5',27,12.5,2,50,61.8,8,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('DALMATA, GANSITO X 6',36,'58','6',26.4,12,2.5,38,63,6,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('TWINKIES X 6',36,'58','7',26.3,12,2,36,60,6,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('SOLAPA LONCHERITA',36,'58','8',30,13,2,34,78,6,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('FICHA TECNICA CARTONGRAFICAS',36,'58','9',0,0,0,19.5,48,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('TRUFAS',36,'58','10',6,17,0,25,70,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BANDEJA',36,'58','11',34,13,2,68,51,6,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BANDEJA THAI',36,'58','12',19.9,15,4,23,55.6,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BANDEJA PEQUEÑA  U. ROSARIO',36,'58','13',7.5,7.5,3,27.5,27,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BANDEJA GRANDE  U. ROSARIO',36,'58','14',7.5,15.5,3,21.5,54,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('ORALE GUEY TIRAS PEGUE',36,'59','1',20.6,7.2,5.8,17,37.3,3,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PAN BIMBO DISEÑO ÉXITO Y CARULLA',36,'60','1',26,13,4.5,81.8,42.6,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('VINO TINTO/PLATA/AZUL',36,'61','1',17.7,11.2,2.5,32.5,29.9,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (8.4, 13.5, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('NUGGETS',36,'61','2',10,6,4.5,19,23.6,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA DOCENA LIZA NUTRIX',36,'61','3',26.4,15,9.2,89.8,50.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA DOCENA LIZA NUTRIX',36,'61','4',26.4,15,9.2,44.8,50.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CHINA WOK cierre hermético',36,'62','1',9,7,10,35.7,35.7,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('ENSALADAS ANIMO',36,'62','2',8.5,6.5,10.8,33.1,33.1,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BIOOATEVIA',36,'65','1',12.7,5.5,15.3,52.8,38,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BIOSTEVIA X 50',36,'65','2',10.3,4.5,13.5,23.4,64.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BIOSTEVIA X 100',36,'65','3',11.3,4.5,14.4,23.4,64.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BIOSTEVIA 40 ',36,'65','4',9.5,3.8,12.5,58.7,21.4,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('LUDO BODY    ',36,'66','1',32,5,0,32,31,3,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('LUDO BODY GRANDE',36,'66','2',55,10,0,38,55,12,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('SEPARADORES',36,'66','3',14.5,3.2,0,29.4,13.5,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('SEPARADORES TOY',36,'66','4',21,8.8,0,32,24.8,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('SOLAPA INDIVIDUAL CC PLASTICO',36,'66','5',8.1,14.3,0,32.4,28.6,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('FAJA TOALLA GERSA',36,'68','1',0,58.8,20.5,58.8,20.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PORTACORBATAS',36,'69','1',14.4,1.7,39,49,31,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('DISPLAY PUNTO M',36,'69','2',7.7,0.7,6.6,29.1,31.9,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('SOLAPAS AMERICA/ FRESITA',36,'69','3',0,0,0,44.1,26,9,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('TAPA PONQUE ARBOL',36,'69','4',38.5,33.6,7.5,53.3,48.3,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (21, 26, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BASE PONQUE ARBOL',36,'69','5',38.5,33.6,7.5,52.5,47.7,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA PRMOCIONAL SEP TIGO',36,'69','6',0,0,0,64.5,45.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PORTARETRATO KANDU',36,'69','7',0,17,15,34,15,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (10, 7.3, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('NIDO CAJA ALITAS',36,'69','8',12.5,5,10.7,22.5,24.4,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CJ CHOCOLATES DULCE VALENTINA',36,'69','9',18,15,3,59.5,35.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('',36,'70','1',19,9.8,1.4,19,40,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('FUNDA PARA CAJA EDICION ESPECIAL',36,'70','2',12.3,12.7,8.9,28,43.8,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA  SUSHIBROWNIE',36,'70','3',22.4,7.3,6.1,44.3,49,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA EDICIÓN ESPECIAL BASE ',36,'70','4',0,0,0,50.5,54.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA  SUSHI WOKIN',36,'70','5',21.2,4.3,4.2,31,29.2,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA BROWNIE X 1 ',36,'70','6',8.5,8.5,4.5,32.5,27.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('FUNDA PLANTAS',36,'70','7',45.5,23.5,12.6,45.5,74.3,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('FUNDA BATERIAS',36,'70','8',44.4,27.4,12.5,44.4,81.7,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('GALLETAS NAVIDEÑAS',36,'70','9',15,4,26,69,40,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('GALLETAS NAVIDEÑAS DORADAS',36,'70','10',26,15,4,41,67,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('INDUSTRIAS TALYOR, 1/2 ROLLO',36,'71','1',6,6,22.1,35,37.6,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('SOBRE CARNE',36,'71','2',19.5,1,22,42,49.6,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('MAMA-INÉS',36,'72','1',15,8,6.1,33,50.5,2,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (9.4, 6, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PONQUÉ VINO NAVIDAD',36,'72','2',16.8,16.8,9.5,38.8,92.2,2,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (13, 11, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PONQUE VINO COMERCIAL',36,'72','3',15,15,9,37,83,2,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (10, 8, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('AREQUIPITOS, SANTILLANA',36,'75','1',16,10.2,1.3,24.6,32.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('MEDIO ROLLOS COLOMBINA',36,'76','1',5.6,5.6,20.7,35,39,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('ROLLO COLOMBINA',36,'76','2',5.5,5.5,31,35,48.8,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BOLSAS ROYAL FILMS',36,'77','1',9,17.4,6.4,64.5,44.5,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BOLSAS ROYAL FILMS REFUERZO',36,'77','2',9,17.4,6.4,47.7,65.5,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BOLSA CRISPETA GRANDE',36,'77','3',15.1,9.7,26,68.5,51.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BOLSA CRISPETA MEDIANA',36,'77','4',12.6,8.9,23.5,63.4,89.1,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BOLSA CRISPETA PEQUEÑA',36,'77','5',10,7,17.4,69.6,41.5,3,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('ETIQUETAS PLASTF. BACHELI/solapas yibu',36,'78','1',8.3,5.5,0.3,33.8,22,8,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('DIVISIONES BIMBOLETE',36,'78','2',12,10.4,0,24,31.2,6,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('SOLAPA LAVERPIC',36,'78','3',7,5,0,22,19.9,12,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('ETIQUETAS CASHMERE',36,'78','4',8.3,4.2,0,25,19.2,12,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('SOLAPA JUEGO DE ACCESORIOS INV',36,'78','5',0,0,0,32.5,63,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('COMBO X 3-PORTA ROLLO',36,'78','6',0,0,0,62.5,34,3,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('SOLAPA CEPILLERA-TOALLERO',36,'78','7',0,0,0,26,61,3,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('AQUA BLUE  GRICOL',36,'78','8',31,16,0,32.5,31,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('TAPA SILLA AQUA BLUE',36,'78','9',0,0,0,50,40,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('SOLAPA GLICOL 5 PIEZAS',36,'78','10',0,0,0,32.4,62,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('SOLAPA JUEGO X 3',36,'78','11',0,0,0,34,34.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('SOLAPA CEPILLERA',36,'78','12',0,15,17,34.4,30.5,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('SOLAPAS ENCANTAOSITOS',36,'78','13',11,8,0,22.4,40,10,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('MENÚ INFANTIL',36,'79','1',17,11,9,29.5,57.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('POLLO AMRECAN POLLO Y TODO BROASTER',36,'84','1',15.4,12.1,19.7,56,82.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('MEDIO POLLO MALETIN AMERKAN POLLO',36,'84','2',15.5,12,10.2,59.4,56.8,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('DOMICILIO GRANDE/CAJA MALETIN CASONA',36,'84','3',22,12,12,35.6,69.8,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('POLLO tropicana',36,'84','4',21,13,14.5,69.5,37.7,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('POLLO TODO BROASTER',36,'84','5',15.4,12,19.7,43.8,55.9,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('MALETIN MENU INFANTIL KANDU',36,'84','6',18,13,10,33.4,63.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA DOMICILIO PEQUEÑA',36,'84','7',18.2,11,10.5,57.3,62.8,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA AVENA',36,'84','8',15,8.5,12.5,59.6,49.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PANUCHAS  - DULCES SURTIDOS',36,'85','1',13,10.1,3.1,55.6,37.2,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PORTAPIZZAS',36,'86','1',24.4,17.5,1,53.3,24.4,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PORTAPIZZAS',36,'86','2',20.2,20,1.5,41.5,51.8,6,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('POLLO',36,'87','1',20.4,15,6,58,35,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('ALFA TRADING VINIL',36,'88','1',12.5,6,24,39.4,38.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA WRAP',36,'88','2',14,8,25,29.5,33,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA FAJA',36,'88','3',22,5.4,24,40,57,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA REGALO',36,'89','1',9,9,5.5,20.6,37.3,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BLOQUE INAVIGOR X 6',36,'90','1',14.5,11,6.3,69,47.6,6,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('NIDOS CAJA CUP CAKES INDIVIDUAL',36,'90','2',11.4,11.4,2.5,16.4,32.8,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('NIDO CAJA BROWNIE PEQUEÑA',36,'90','3',17,10,3.5,34.2,17.6,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('AISLADOR TERMICO',36,'90','4',0,0,0,25.8,25.6,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PORTAPERROS presto',36,'91','1',17.4,6.2,4.2,43.6,28.7,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('MINIPERROS presto',36,'91','2',15,5,3,37,22.5,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PORTA PERROS GENERICO',36,'91','3',0,0,0,64.5,26,6,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BURRITO',36,'91','4',20,6,5,25,32,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PORTAAREPAS GENERICO',36,'91','5',9,2,9.9,20,36,3,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PORTAHAMBURGUESA BIMBO',36,'91','6',9.5,4.8,9.5,41.3,48,6,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('EMPAQUE AREPA',36,'91','7',9.3,3.9,11.5,69,35.5,3,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('SNACK',36,'91','8',47,4,10.4,46.1,68.3,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('GUANTES EXAMENES',36,'93','1',24,14,10,48,49.4,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('DISPESADOR MARCEL FRANCE',36,'93','2',24.2,12.5,6.2,40.1,38.7,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PORTAVASOS',36,'95','1',28.7,9,6,44,29,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('COMBO PEQUEÑO ',36,'95','2',23,13,5,37.5,93,3,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('DISPLAY X 12 SANTILLANA',36,'95','3',11,4.5,16.5,49,32,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PORTAVASOS DESECHABLES',36,'95','4',17,8.7,5,37.9,47.6,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('FONDOS/ 5 LITROS CUBETAS',36,'96','1',32,13,0,26,32,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('FONDOS 7 LITROS',36,'96','2',21,21,0,64.2,42,3,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('FONDOS 5 LITROS',36,'96','3',31.8,13,0,52,31.8,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('FONDOS 3,5 LITROS',36,'96','4',0,0,0,26.5,28,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('FONDOS 7 LITROS (C6)',36,'96','5',21,21,0,69,42,6,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('FONDO BLOANDA JAVERIANA',36,'96','6',0,26,0,52.5,52.5,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BASES MORANGO',36,'96','7',0,0,0,58.7,46.2,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('FONDOS 1 LITRO',36,'96','8',11,11,0,34,22.5,6,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('MENU INFANTIL HAMBURGUESERIA',36,'97','1',11.8,10.7,16.5,55,66.7,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA BALON No. 2',36,'97','2',15,7,15.3,28.5,53,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('FOOTBALL #5 GAMA ALTA',39,'01','1',23,23,9,41.2,75.3,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('FOOTBALL #3 GAMA ALTA',39,'01','2',19,19,8.5,36,63.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('VOLLEYBALL',39,'01','3',20,20,10,40.2,72.3,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BASKETBALL GAMA ALTA',39,'01','4',24,24,13.5,51.1,90.4,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PARTE 1 CAJA JUANITA',39,'01','6',43.5,31,21,92.4,61.1,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (40, 33.5, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PARTE 2 CAJA JUANITA',39,'01','7',29,0,50,53.7,33.3,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PARTE 2 LESLY',39,'01','8',48.5,24.5,11.5,53,26,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PARTE 1 LESLY',39,'01','9',48.5,24,11.5,75.6,49.5,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (40, 26, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BEBE RONCADOR',39,'01','10',17.8,14,13.8,66,65.5,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (26.8, 32.8, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('ADORABLE BEBE PARTE 1',39,'01','11',0,0,0,38,79.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('ADORABLE BEBE PARTE 2',39,'01','12',0,0,0,56.5,79.5,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (28, 37, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('NIDOS RONCADOR',39,'01','13',0,0,0,35.3,60.2,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA BALON ',39,'01','15',23,23,10.5,42.6,78,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA BALON No. 5 ALTA',39,'01','16',22.9,22.9,10.3,43.5,76,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA BALON No. 5 ESTANDAR',39,'01','17',22.9,22.9,9,41,74.4,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA BALON No. 3',39,'01','18',19,19,8.8,36.5,66.4,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA BALON VOLLEYBALL',39,'01','19',20.2,10,20.5,69.1,40,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA BALON BALONCESTO',39,'01','20',24.5,10.3,20.5,44.8,81.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA SENSOR',39,'01','21',9,8,9,24.5,36,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA POLLO KOKORIKRONCH',39,'01','22',24.4,24.4,8,43,70.2,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('NIDO POLLO KOKORIKRONCH',39,'01','23',23.5,5.2,7.6,24,63.5,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PONQUE HEXAGONAL X 500 gr',39,'01','24',8.6,8.6,8,34.7,53.5,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (10.5, 6, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PONQUE HEXAGONAL X 1000 gr',39,'01','25',11.5,11.5,8.5,43.4,70.6,1,0,'0','0',null,default,default,2,null); 
	SET @idtroquel = (LAST_INSERT_ID());
	INSERT INTO produccion.troquel_ventana(largo, alto, activo, troquel_idtroquel)
	VALUES (14, 8.3, 1, @idtroquel);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA BALON X 4',39,'01','26',4.8,32.7,30.5,80,44,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA BALON BOTILITO',39,'01','27',7,30.3,24.8,44.5,70,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA BALON No. 2',39,'01','28',15.5,4.8,15,46.7,24.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CJ BALON BASQUET ECONOMICA',39,'01','29',24,13.7,24,51,86.8,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BASE BROWNIE AMERICAN',39,'02','3',0,0,0,45.2,33.3,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('TRIQUI DIDACTICAS Y MATEMATICAS',39,'02','4',21.5,28,0,21.5,56,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('NIDO PONQUE ARBOL',39,'02','5',37.5,32.8,0,32.5,37.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('MANTECADA MORANGO SIN TROQUELADO',39,'02','6',25,17,0,25,70,8,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('TARTALETA',39,'02','7',35,9.5,0,35,9.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('MANTECADA',39,'02','8',17,26,0,34,78,6,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('ZANAHORIA',39,'02','9',20.5,20.5,0,41,61.5,6,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BASE MUFFIN ',39,'02','10',20.4,13.9,0,20.4,55.6,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BLONDAS VARIAS',39,'02','11',0,0,0,58.8,46.2,5,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BLONDA TORTA',39,'02','12',0,0,0,29.5,29.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('NIDO COMBO JUEGO DE BAÑO REDONDO',39,'02','13',51.7,22.8,2.3,27.4,63,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BLONDA 23*23',39,'02','14',0,0,0,68,22.1,3,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CJ TONER',39,'02','15',34.6,23.8,14,88.5,62.9,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('NIDO HUECO REDONDO',39,'02','16',51.7,22.8,2.3,27.4,63,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('DISPLAY CABANO GRANDE X 250 GR',39,'03','1',21.5,25.7,16.5,58.8,92.3,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CJ PLANCHA',39,'03','2',12.5,8.7,20.2,68.2,44.3,2,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('Cj BASE MICRO PLANTA',39,'03','3',12.5,24,46,74.2,96.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('Cj BASE MICRO BATERIA',39,'03','4',12.5,27.5,44.5,78.2,95.6,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA CW2 - CW2P',39,'03','5',12,12,23.9,49.8,46,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA CW3',39,'03','6',12.5,12.5,30.5,51.8,53.2,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA PATINES',39,'41','1',34.5,10.5,40.9,60.7,92.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA CARTUCHOS',39,'41','2',38,10,13.8,97.5,34,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA EMBALAJE',39,'41','3',38.4,34.2,16,76,50.4,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA PANTUFLAS',39,'41','4',15,13,30,58,60.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BASES DIAMETRO 11 (FONDO 1 LITRO)',36,'96','8',11,11,0,34,22.5,6,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BASE DE TRUFA X 4',39,'02','12',6.4,6,0,19.2,60,30,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('TIRA BACHELLI',38,'01','1',48,3,0,48,33,11,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('BTG',39,'01','2',0,0,0,22,100,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('PECHERA BACHELI',40,'01','3',0,0,0,26.5,34,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('NIDOS CAJA BROWNIE REGALO',41,'01','4',15.2,15.2,0,35,31,4,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('ALMAS DE CARTON',42,'01','5',25,20,0,25,20,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('CAJA PICADA FAMILIA',43,'02','6',34.3,65,38,61.7,95.5,1,0,'0','0',null,default,default,2,null);
INSERT INTO produccion.troquel(descripcion,itemlista_iditemlista_material,modelo,tamanio,largo,ancho,alto,fibra,contrafibra,cabidafibra,cabidacontrafibra,ubicacion,marca,observaciones,fechacreacion,activo,empresa_idempresa,nombreimagen) 
VALUES('NIDO PICADA FAMILIA',44,'02','7',0,0,0,50.3,52.2,1,0,'0','0',null,default,default,2,null);