select 
	@idInsumoFlete := 2
    , @escala := 1000
    , @idperiodo := 4
    , @idproducto := 1
    
	, tblProd.idproducto    
	, @cantTintas := produccion.ufn_ProdCantTintas(tblProd.idproducto) as cantTintas
    , @cabidaConversion := (tblProd.cabidaancho * tblProd.cabidalargo) as cabidaConversion
	, @cabidaTroquel := (tblTroq.cabidafibra * tblTroq.cabidacontrafibra) as cabidaTroquel
    , tblProd.largobobina
    , tblProd.anchobobina
    , @areaCartonCaja := (tblProd.largobobina * tblProd.anchobobina) as areaCartonCaja
    , @anchoAcaDer := ifnull(tblProd.anchomaquina_acabadoderecho, 0) as anchoAcaDer
    , @largoAcaDer := ifnull(tblProd.recorrido_acabadoderecho, 0) as largoAcaDer
    , @areaAcaDer := (@anchoAcaDer * @largoAcaDer) as areaAcaDer
    , @anchoAcaRev := ifnull(tblProd.anchomaquina_acabadoreverso, 0) as anchoAcaRev
    , @largoAcaRev := ifnull(tblProd.recorrido_acabadoreverso, 0) as largoAcaRev
    , @areaAcaRev := (@anchoAcaRev * @largoAcaRev) as areaAcaRev
    
	, @costoReempaque := ((produccion.ufn_InsumoCostoTotUnidad(tblProd.insumo_idinsumo_reempaque) * 10000) / tblProd.factorrendimientoreempaque) as costoReempaque
	, @costoAccesorios := produccion.ufn_ProdAccesoriosCostoTotal(tblProd.idproducto) as costoAccesorios
    , @costoFlete := ifnull((@areaCartonCaja / @cabidaConversion) / ((produccion.ufn_InsumoCostoTotUnidad(@idInsumoFlete) * 10000) / @cabidaTroquel), 0) as costoFlete    
    , @costoAcetato := produccion.ufn_ProdAcetatoCostoTotal(tblProd.idproducto) as costoAcetato
    , @costoCartonCaja := (((@areaCartonCaja/@cabidaConversion) * produccion.ufn_InsumoCostoTotUnidad(tblProd.insumo_idinsumo_material)) / @cabidaTroquel) as costoCarton
    , @costoCartonColaminado := ifnull((((@areaCartonCaja/@cabidaConversion) * produccion.ufn_InsumoCostoTotUnidad(tblProd.insumo_idinsumo_colaminado)) / @cabidaTroquel), 0) as costoColaminado
    , @costoTintas := produccion.ufn_ProdTintasCostoTotal(tblProd.idproducto) as costoTintas
    , @costoAcabadoDer := ifnull((((tblProd.anchomaquina_acabadoderecho * tblProd.recorrido_acabadoderecho) * produccion.ufn_InsumoCostoTotUnidad(tblProd.insumo_idinsumo_acabadoderecho)) / @cabidaTroquel), 0) as costoAcabadoDer
    , @costoAcabadoRev := ifnull((((tblProd.anchomaquina_acabadoreverso * tblProd.recorrido_acabadoreverso) * produccion.ufn_InsumoCostoTotUnidad(tblProd.insumo_idinsumo_acabadoreverso)) / @cabidaTroquel), 0) as costoAcabadoRev
    , @costoPegante := produccion.ufn_ProdPeganteCostoTotal(tblProd.idproducto) as costoPegante
    , @costoPliegosDesper := (((@costoCartonCaja * 1.1) * (@cantTintas * 50)) / @escala) as costoPliegosDesper
    , @costoDesperdicioCaja := (@costoCartonCaja - ((@areaCartonCaja * produccion.ufn_InsumoCostoTotUnidad(tblProd.insumo_idinsumo_material)) / @cabidaTroquel)) as costoDesperdicioCaja        
    
    , @costoProcPegue := produccion.ufn_ProdProcPegueCostoTotal(@escala, @cabidaTroquel, @idperiodo, tblProd.idproducto) as costoProcPegue
    , @costoProcAcabadoDer := ifnull(produccion.ufn_ProdProcAcabadoCostoTotal(@escala, @cabidaTroquel, @idperiodo, tblProd.recorrido_acabadoderecho, tblVPAca.idVariacion), 0) as costoProcAcabadoDer    
    , @costoProcAcabadoRev := ifnull(produccion.ufn_ProdProcAcabadoCostoTotal(@escala, @cabidaTroquel, @idperiodo, tblProd.recorrido_acabadoreverso, tblVPAca.idVariacion), 0) as costoProcAcabadoRev
    , @costoProcConversion := produccion.ufn_ProdProcConversionCostoTotal(@escala, @cabidaTroquel, @idperiodo, tblProd.largobobina, tblVPConv.idVariacion) as costoProcConversion    
    , @costoProcLitografia := produccion.ufn_ProdProcLitografiaCostoTotal(@escala, tblProd.pasadaslitograficas, @idperiodo, tblVPConv.idVariacion) as costoProcLitografia
    , @costoProcTroqelado := produccion.ufn_ProdProcTroqueladoCostoTotal(@escala, @cabidaTroquel, @idperiodo, tblVPTroq.idVariacion) as costoProcTroqelado    
    , @costoProcColaminado := produccion.ufn_ProdProcColaminadoCostoTotal(@escala, @cabidaTroquel, @idperiodo, tblVPCola.idVariacion) as costoProcColaminado
    , @costoProcGuillotinado := (0) as costoProcGuillotinado
    
    , @costoAporteGastoUnidad := (ifnull(produccion.ufn_ProdGastoAporteTotal(@escala, @idperiodo) / @cabidaTroquel, 1)) as costoAporteGastoUnidad
    , @costoTotalMaterialUnidad := (@costoReempaque + @costoAccesorios + @costoFlete + @costoAcetato + @costoCartonCaja + @costoCartonColaminado + @costoTintas + @costoAcabadoDer + @costoAcabadoRev + @costoPegante + @costoPliegosDesper) as costoTotalMaterialUnidad
    , @costoTotalProcesosUnidad := (@costoProcPegue + @costoProcAcabadoDer + @costoProcAcabadoRev + @costoProcConversion + @costoProcLitografia + @costoProcTroqelado + @costoProcColaminado) as costoTotalProcesosUnidad    
    , @costoTotalFabricacion := (@costoTotalMaterialUnidad + @costototalProcesosUnidad + @costoAporteGastoUnidad) as costoTotalFabricacion
    
    , @porceDesperdicioCaja := ((@costoDesperdicioCaja / @costoCartonCaja) / 100) as porceDesperdicioCaja
    , @porceAlzaGeneral := (seguridad.ufnPeriodoObtenerAlazaGeneral(@idperiodo) / 100) as porceAlzaGeneral
    , @porceIcaCree := (seguridad.ufnPeriodoObtenerIcaCree(@idperiodo) / 100) as porceIcaCree
    , @porceComisionAsesor := (1 / 100) as porceComisionAsesor
    , @proceAdmFinanciacion := (seguridad.ufnPeriodoObtenerAdmFinanciacion(@idperiodo) /100) as proceAdmFinanciacion
    , @procePrecioProducto := ((ifnull(tblProd.factorprecio, 0) / 100)) as procePrecioProducto
    
    , @costoNetoCaja := @costoTotalFabricacion - (@porceAlzaGeneral * @porceIcaCree * @porceComisionAsesor * @proceAdmFinanciacion * @procePrecioProducto) as costoNetoCaja
from produccion.producto as tblProd
	inner join produccion.troquel as tblTroq on tblProd.troquel_idtroquel = tblTroq.idtroquel
	inner join produccion.insumo as tblIMCaja on tblProd.insumo_idinsumo_material = tblIMCaja.idinsumo
    
    inner join produccion.maquinavariprod as tblVPConv on tblProd.maquinavariprod_idVariacion_rutaconversion =  tblVPConv.idVariacion
	inner join produccion.maquina as tblMRConv on tblVPConv.maquina_idmaquina = tblMRConv.idmaquina
	inner join produccion.maquinavariprod as tblVPTroq on tblProd.maquinavariprod_idVariacion_rutatroquelado =  tblVPTroq.idVariacion
	inner join produccion.maquina as tblMRTroq on tblVPTroq.maquina_idmaquina = tblMRTroq.idmaquina
	inner join produccion.maquinavariprod as tblVPLito on tblProd.maquinavariprod_idVariacion_rutalitografia =  tblVPLito.idVariacion
	inner join produccion.maquina as tblMRLito on tblVPLito.maquina_idmaquina = tblMRLito.idmaquina
    left join produccion.maquinavariprod as tblVPAca on tblProd.maquinavariprod_idVariacion_rutaplastificado =  tblVPAca.idVariacion
	left join produccion.maquina as tblMRAca on tblVPAca.maquina_idmaquina = tblMRAca.idmaquina
    left join produccion.maquinavariprod as tblVPCola on tblProd.maquinavariprod_idVariacion_rutacolaminado =  tblVPCola.idVariacion
	left join produccion.maquina as tblMRCola on tblVPCola.maquina_idmaquina = tblMRCola.idmaquina
    
	left join produccion.insumo as tblIMReem on tblProd.insumo_idinsumo_reempaque = tblIMReem.idinsumo
	left join produccion.insumo as tblIMCola on tblProd.insumo_idinsumo_colaminado = tblIMCola.idinsumo
	left join produccion.insumo as tblIMAcabDer on tblProd.insumo_idinsumo_acabadoderecho = tblIMAcabDer.idinsumo
	left join produccion.insumo as tblIMAcabRev on tblProd.insumo_idinsumo_acabadoreverso = tblIMAcabRev.idinsumo
where tblProd.idproducto = 1;