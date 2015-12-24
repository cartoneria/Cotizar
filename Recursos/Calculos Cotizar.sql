select 
	@idInsumoFlete := 2 as idInsuFlete
	, tblProd.idproducto
	-- , tblTroq.idtroquel
	-- , tblIMCaja.idinsumo as idInsuMatCaja
	-- , tblProd.largobobina
	-- , tblProd.anchobobina
	-- , tblProd.cabidalargo
	-- , tblProd.cabidaancho
	-- , tblVPTroq.idVariacion as idVariProdTroq
	-- , tblVPTroq.nombre_variacion_produccion
	-- , tblMRTroq.idmaquina as idMaqRutaTroq
	-- , tblMRTroq.nombre
	-- , tblVPLito.idVariacion as idVariProdLito
	-- , tblVPLito.nombre_variacion_produccion
	-- , tblMRLito.idmaquina as idMaqRutaLito
	-- , tblMRLito.nombre
	, @cantTintas := produccion.ufn_ProdCantTintas(tblProd.idproducto) as cantTintas
	-- , tblProd.referenciacliente
	-- , tblIMReem.idinsumo as idInsuMatReem
	-- , tblIMR.nombre
	-- , tblIMCola.idinsumo as idInsuMatColam
	-- , tblIMCola.nombre
	-- , tblProd.colaminadoancho
	-- , tblProd.colaminadoalargo
	-- , tblProd.colaminadocabidalargo
	-- , tblProd.colaminadocabidaancho
    , @cabidaConversion := (tblProd.cabidaancho * tblProd.cabidalargo) as cabidaConversion
	, @cabidaTroquel := (tblTroq.cabidafibra * tblTroq.cabidacontrafibra) as cabidaTroquel
    , @areaCartonCaja := (tblProd.largobobina * tblProd.anchobobina) as areaCartonCaja
	-- , tblIMAcabDer.idinsumo as idInsuMatAcabDer
	-- , tblProd.anchomaquina_acabadoderecho
	-- , tblProd.recorrido_acabadoderecho
	-- , tblIMAcabRev.idinsumo as idInsuMatAcabRev
	-- , tblProd.anchomaquina_acabadoreverso
	-- , tblProd.recorrido_acabadoreverso
	, @factorPrecio := (tblProd.factorprecio / 100) as factorPrecio
	, (tblMRLito.valorplancha * @cantTintas) as costoPlanchas -- esto se debe validar si tiene ya pedidos o si es primera vez del producto
	, @costoReempaque := ((produccion.ufn_InsumoCostoTotUnidad(tblProd.insumo_idinsumo_reempaque) * 10000) / tblProd.factorrendimientoreempaque) as costoReempaque
	, @costoAccesorios := produccion.ufn_ProdAccesoriosCostoTotal(tblProd.idproducto) as costoAccesorios
    , @costoFlete := ifnull(((tblProd.largobobina * tblProd.anchobobina) / @cabidaConversion) / ((produccion.ufn_InsumoCostoTotUnidad(@idInsumoFlete) * 10000) / @cabidaTroquel), 0) as costoFlete
    , @costoAcetato := produccion.ufn_ProdAcetatoCostoTotal(tblProd.idproducto) as costoAcetato
    , @costoCartonCaja := (((@areaCartonCaja/@cabidaConversion) * produccion.ufn_InsumoCostoTotUnidad(tblProd.insumo_idinsumo_material)) / @cabidaTroquel) as costoCarton
    , @costoCartonColaminado := (((@areaCartonCaja/@cabidaConversion) * produccion.ufn_InsumoCostoTotUnidad(tblProd.insumo_idinsumo_colaminado)) / @cabidaTroquel) as costoColaminado
    , @costoTintas := produccion.ufn_ProdTintasCostoTotal(tblProd.idproducto) as costoTintas
    , @costoAcabadoDer := (((tblProd.anchomaquina_acabadoderecho * tblProd.recorrido_acabadoderecho) * produccion.ufn_InsumoCostoTotUnidad(tblProd.insumo_idinsumo_acabadoderecho)) / @cabidaTroquel) as costoAcabadoDer
    , @costoAcabadoRev := (((tblProd.anchomaquina_acabadoreverso * tblProd.recorrido_acabadoreverso) * produccion.ufn_InsumoCostoTotUnidad(tblProd.insumo_idinsumo_acabadoreverso)) / @cabidaTroquel) as costoAcabadoRev
    , @costoPegante := produccion.ufn_ProdPeganteCostoTotal(tblProd.idproducto) as costoPegante
    
    
    
    , @costoTotalMaterialUnidad := (@costoReempaque + @costoFlete + @costoAcetato + @costoCartonCaja + @costoCartonColaminado + @costoTintas + @costoAcabadoDer + @costoAcabadoRev) as costoTotalMaterialUnidad
    , @costototalProcesosUnidad := 0 as costototalProcesosUnidad
    , @costoNetoCaja := @costoTotalMaterialUnidad + @costototalProcesosUnidad as costoNetoCaja
from produccion.producto as tblProd
	inner join produccion.troquel as tblTroq on tblProd.troquel_idtroquel = tblTroq.idtroquel
	inner join produccion.insumo as tblIMCaja on tblProd.insumo_idinsumo_material = tblIMCaja.idinsumo
	inner join produccion.maquinavariprod as tblVPTroq on tblProd.maquinavariprod_idVariacion_rutatroquelado =  tblVPTroq.idVariacion
	inner join produccion.maquina as tblMRTroq on tblVPTroq.maquina_idmaquina = tblMRTroq.idmaquina
	inner join produccion.maquinavariprod as tblVPLito on tblProd.maquinavariprod_idVariacion_rutalitografia =  tblVPLito.idVariacion
	inner join produccion.maquina as tblMRLito on tblVPLito.maquina_idmaquina = tblMRLito.idmaquina
	left join produccion.insumo as tblIMReem on tblProd.insumo_idinsumo_reempaque = tblIMReem.idinsumo
	left join produccion.insumo as tblIMCola on tblProd.insumo_idinsumo_colaminado = tblIMCola.idinsumo
	left join produccion.insumo as tblIMAcabDer on tblProd.insumo_idinsumo_acabadoderecho = tblIMAcabDer.idinsumo
	left join produccion.insumo as tblIMAcabRev on tblProd.insumo_idinsumo_acabadoreverso = tblIMAcabRev.idinsumo


