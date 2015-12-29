create temporary table if not exists tbltemp_gastoproduccion engine = MEMORY as (
	select 
		@gasto := avg(tblperi.gasto) as gasto
		, @promprod := avg(tblmvp.produccioncant) as promprod
		, @promta := avg(tblmvp.tiempoalistamiento) as promta
		, @sumturnos := sum(tblmaq.turnos) as sumturnos
		, @tmtto := avg(tblmdp.tiempomtto) as tmtto
		, @HPEREMP := avg(tblparamHPEREMP.valornumero) as HPEREMP    
		, @HCAP := avg(tblparamHCAP.valornumero) as HCAP 
		, @DHT := avg(tblparamDHT.valornumero) as DHT
		, @mintrab := (((((@DHT * 8) - @tmtto) - @HPEREMP) - @HCAP) * 60) as mintrab
		, @promvconsumohora := avg((tblparamVKWHE.valornumero * tblmaq.consumonominal)) as vconsumohora
		, @vhmaq := (((@gasto / @mintrab) * 60) + @promvconsumohora) as vhmaq
		, @vta := ((@gasto / @mintrab) * @promta)as vta
		, @vunidad := (@vhmaq / (@promprod * @sumturnos)) as vunidad
	from produccion.maquinavariprod as tblmvp
		inner join produccion.maquina as tblmaq on tblmvp.maquina_idmaquina = tblmaq.idmaquina
		inner join produccion.maquinadatosperiodos as tblmdp on tblmaq.idmaquina = tblmdp.maquina_idmaquina
		inner join seguridad.periodo as tblperi on tblmdp.periodo_idPeriodo = tblperi.idperiodo
		inner join seguridad.parametro as tblparamHPEREMP on tblperi.idperiodo =  tblparamHPEREMP.periodo_idperiodo and tblparamHPEREMP.nombre = 'HPEREMP'
		inner join seguridad.parametro as tblparamHCAP on tblperi.idperiodo =  tblparamHCAP.periodo_idperiodo and tblparamHCAP.nombre = 'HCAP'
		inner join seguridad.parametro as tblparamDHT on tblperi.idperiodo =  tblparamDHT.periodo_idperiodo and tblparamDHT.nombre = 'DHT'
		inner join seguridad.parametro as tblparamVKWHE on tblperi.idperiodo =  tblparamVKWHE.periodo_idperiodo and tblparamVKWHE.nombre = 'VKWHE'
	where tblmaq.itemlista_iditemlistas_tipo = 7 and tblmdp.periodo_idPeriodo = 4
);

select ((vta / 1000) + vunidad) from tbltemp_gastoproduccion;

drop temporary table if exists tbltemp_gastoproduccion;