select 
	tblProd.idproducto
    , tblTroq.idtroquel
    , tblIMCaja.idinsumo as idInsuMatCaja
    , tblProd.largobobina
    , tblProd.anchobobina
    , tblProd.cabidalargo
    , tblProd.cabidaancho
    , tblVPTroq.idVariacion as idVariProdTroq
    -- , tblVPTroq.nombre_variacion_produccion
    , tblMRTroq.idmaquina as idMaqRutaTroq
    -- , tblMRTroq.nombre
    , tblVPLito.idVariacion as idVariProdLito
    -- , tblVPLito.nombre_variacion_produccion
    , tblMRLito.idmaquina as idMaqRutaLito
    -- , tblMRLito.nombre
    , @cantTintas := (select count(idproducto_espectro) 
					  from produccion.producto_espectro 
                      where produccion.producto_espectro.producto_idproducto = tblProd.idproducto) as cantTintas
    , @porcTintas := (select sum(porcentajecubrimiento) 
					  from produccion.producto_espectro 
                      where produccion.producto_espectro.producto_idproducto = tblProd.idproducto) as porcTintas
    , tblProd.referenciacliente
    , tblIMReem.idinsumo as idInsuMatReem
    -- , tblIMR.nombre
    , tblIMCola.idinsumo as idInsuMatColam
    -- , tblIMCola.nombre
    , tblProd.colaminadoancho
    , tblProd.colaminadoalargo
    , tblProd.colaminadocabidalargo
    -- , tblProd.colaminadocabidaancho
    , (tblProd.cabidaancho * tblProd.cabidalargo) as cabidaTroquel
    , tblIMAcabDer.idinsumo as idInsuMatAcabDer
    , tblProd.anchomaquina_acabadoderecho
    , tblProd.recorrido_acabadoderecho
    , tblIMAcabRev.idinsumo as idInsuMatAcabRev
    , tblProd.anchomaquina_acabadoreverso
    , tblProd.recorrido_acabadoreverso
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