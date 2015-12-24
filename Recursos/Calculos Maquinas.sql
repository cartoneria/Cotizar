create temporary table if not exists maquina_costosproduccion engine = memory as (
	select
		@pvm2 := seguridad.ufnParamExVrNumero('VM2', tblPeri.idperiodo) as vm2,
		@ptotmaq := seguridad.ufnPeriodoExTotMaq(@pvm2, tblEmp.idempresa, tblPeri.idperiodo) as totmaqperiodo,
		@putil := seguridad.ufnPeriodoObtenerUtilidad(tblPeri.idperiodo) as utilperiodo,
		@pdtrabajados := seguridad.ufnParamExVrNumero('DHT', tblPeri.idperiodo) as dtrabajados,
		@phtrabajadas := (@pdtrabajados * 8) as htrabajadas,
		@phperemp := seguridad.ufnParamExVrNumero('HPEREMP', tblPeri.idperiodo) as hperemp, 
		@phcap := seguridad.ufnParamExVrNumero('HCAP', tblPeri.idperiodo) as hcap,
		@pvkwhe := seguridad.ufnParamExVrNumero('VKWHE', tblPeri.idperiodo) as vkwhe,
		tblEmp.idempresa,
		tblMaq.idmaquina,
		tblVP.idVariacion,
		tblPeri.idperiodo,
		tblMDP.avaluocomercial,
		tblMaq.areaancho,
		tblMaq.arealargo,
		@varea := (@pvm2 * tblMaq.areaancho * tblMaq.arealargo) as varea,        
		@vtotal := (tblMDP.avaluocomercial + @varea) as vtotal,
		@porcentparti := round((@vtotal / @ptotmaq) * 100, 4) as porcentparti,
		@utilidad := (@putil * (tblMDP.avaluocomercial + @varea) / @ptotmaq) as utilidad,
		tblMDP.presupuesto,
		tblVP.produccioncant as prodcant,
		tblVP.tiempoalistamiento as ta,
		tblMaq.turnos,
		tblMDP.tiempomtto,
		@mintraba := ((@phtrabajadas - tblMDP.tiempomtto - @phperemp - @phcap) * 60) as mintraba,    
		tblMaq.consumonominal,
		@vconsumohora := (@pvkwhe * tblMaq.consumonominal) as vconsumohora,
		@vhmaquina := ((@utilidad + tblMDP.presupuesto) / @mintraba * 60 + @vconsumohora) as vhmaquina,
		@vmtto := ((@utilidad + tblMDP.presupuesto) / @mintraba * tblVP.tiempoalistamiento) as vmtto,
		@vunidad := (@vhmaquina / (tblVP.produccioncant * tblMaq.turnos)) as vunidad
	from  produccion.maquina as tblMaq
		inner join seguridad.empresa as tblEmp on tblMaq.empresa_idempresa = tblEmp.idempresa
		inner join general.itemlista as tblILTipo on tblMaq.itemlista_iditemlistas_tipo = tblILTipo.iditemlista
		left join produccion.maquinadatosperiodos as tblMDP on tblMaq.idmaquina = tblMDP.maquina_idmaquina
		inner join seguridad.periodo as tblPeri on tblMDP.periodo_idPeriodo = tblPeri.idperiodo
		left join produccion.maquinavariprod as tblVP on tblMaq.idmaquina = tblVP.maquina_idmaquina
);

select vunidad + () from maquina_costosproduccion;

drop temporary table if exists maquina_costosproduccion;