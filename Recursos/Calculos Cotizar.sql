select
    @idproducto := 2 as idproducto
    , @idperiodo := 1 as idperiodo
    , @escala := 1000 as escala 
	, @idinsumoflete := 136 as insumoflete
    
	, @areacartoncaja := (tblprod.largobobina * tblprod.anchobobina) as areacartoncaja
    , @areaacader := (ifnull(tblprod.anchomaquina_acabadoderecho, 0) * ifnull(tblprod.recorrido_acabadoderecho, 0)) as areaacader
    , @areaacarev := (ifnull(tblprod.anchomaquina_acabadoreverso, 0) * ifnull(tblprod.recorrido_acabadoreverso, 0)) as areaacarev
    , @cabidaconversion := (tblprod.cabidaancho * tblprod.cabidalargo) as cabidaconversion
    , @cabidatroquel := (tbltroq.cabidafibra * tbltroq.cabidacontrafibra) as cabidatroquel
    
    , @canttintas := produccion.ufn_ProdCantTintas(tblprod.idproducto) as canttintas
    
	, @costoreempaque := ifnull(((produccion.ufn_insumocostototunidad(tblprod.insumo_idinsumo_reempaque) * 10000) / tblprod.factorrendimientoreempaque),0) as costoreempaque
	, @costoaccesorios := produccion.ufn_prodaccesorioscostototal(tblprod.idproducto) as costoaccesorios
    , @costoflete := ifnull((@areacartoncaja / @cabidaconversion) / ((produccion.ufn_insumocostototunidad(@idinsumoflete) * 10000) / @cabidatroquel), 0) as costoflete    
    , @costoacetato := produccion.ufn_prodacetatocostototal(tblprod.idproducto) as costoacetato
    , @costocartoncaja := (((@areacartoncaja / @cabidaconversion) * produccion.ufn_insumocostototunidad(tblprod.insumo_idinsumo_material)) / @cabidatroquel) as costocartoncaja
    , @costocartoncolaminado := ifnull((((@areacartoncaja/@cabidaconversion) * produccion.ufn_insumocostototunidad(tblprod.insumo_idinsumo_colaminado)) / @cabidatroquel), 0) as costocartoncolaminado
    , @costotintas := produccion.ufn_prodtintascostototal(tblprod.idproducto) as costotintas
    , @costoacabadoder := ifnull(((@areaacader * produccion.ufn_insumocostototunidad(tblprod.insumo_idinsumo_acabadoderecho)) / @cabidatroquel), 0) as costoacabadoder
    , @costoacabadorev := ifnull(((@areaacarev * produccion.ufn_insumocostototunidad(tblprod.insumo_idinsumo_acabadoreverso)) / @cabidatroquel), 0) as costoacabadorev
    , @costopegante := produccion.ufn_prodpegantecostototal(tblprod.idproducto) as costopegante
    , @costopliegosdesper := (((@costocartoncaja * 1.1) * (@canttintas * 50)) / @escala) as costopliegosdesper
    , @costodesperdiciocaja := ((@areacartoncaja * produccion.ufn_insumocostototunidad(tblprod.insumo_idinsumo_material)) / @cabidatroquel) as costodesperdiciocaja        
    
    , @costoprocpegue := produccion.ufn_prodprocpeguecostototal(@escala, @cabidatroquel, @idperiodo, tblprod.idproducto) as costoprocpegue
    , @costoprocacabadoder := ifnull(produccion.ufn_prodprocacabadocostototal(@escala, @cabidatroquel, @idperiodo, tblprod.recorrido_acabadoderecho, tblvpaca.idvariacion), 0) as costoprocacabadoder    
    , @costoprocacabadorev := ifnull(produccion.ufn_prodprocacabadocostototal(@escala, @cabidatroquel, @idperiodo, tblprod.recorrido_acabadoreverso, tblvpaca.idvariacion), 0) as costoprocacabadorev
    , @costoprocconversion := produccion.ufn_prodprocconversioncostototal(@escala, @cabidatroquel, @idperiodo, tblprod.largobobina, tblvpconv.idvariacion) as costoprocconversion    
    , @costoproclitografia := produccion.ufn_prodproclitografiacostototal(@escala, tblprod.pasadaslitograficas, @idperiodo, tblvplito.idvariacion) as costoproclitografia
    , @costoproctroqelado := produccion.ufn_prodproctroqueladocostototal(@escala, @cabidatroquel, @idperiodo, tblvptroq.idvariacion) as costoproctroqelado    
    , @costoproccolaminado := produccion.ufn_prodproccolaminadocostototal(@escala, @cabidatroquel, @idperiodo, tblvpcola.idvariacion) as costoproccolaminado
    , @costoprocguillotinado := (produccion.ufn_prodprocguillotinadocostototal(@escala, tblprod.idproducto, @idperiodo, tblvpguillo.idvariacion)) as costoprocguillotinado
    
    , @costoaportegastounidad := (ifnull(produccion.ufn_prodgastoaportetotal(@escala, @idperiodo) / @cabidatroquel, 1)) as costoaportegastounidad
    , @costototalmaterialunidad := (@costoreempaque + @costoaccesorios + @costoflete + @costoacetato + @costocartoncaja + @costocartoncolaminado + @costotintas + @costoacabadoder + @costoacabadorev + @costopegante + @costopliegosdesper) as costototalmaterialunidad
    , @costototalprocesosunidad := (@costoprocpegue + @costoprocacabadoder + @costoprocacabadorev + @costoprocconversion + @costoproclitografia + @costoproctroqelado + @costoproccolaminado + @costoprocguillotinado) as costototalprocesosunidad    
    , @costototalfabricacion := (@costototalmaterialunidad + @costototalprocesosunidad + @costoaportegastounidad) as costototalfabricacion
    
    , @porcedesperdiciocaja := ((@costodesperdiciocaja / @costocartoncaja) / 100) as porcedesperdiciocaja
    , @porcealzageneral := (1 + seguridad.ufnperiodoobteneralazageneral(@idperiodo)) / 100 as porcealzageneral
    , @porceicacree := (1 + seguridad.ufnperiodoobtenericacree(@idperiodo)) / 100 as porceicacree
    , @porcecomisionasesor := (1 + ifnull(produccion.ufn_prodcomisionasesor(tblprod.idproducto), 0)) / 100 as porcecomisionasesor
    , @proceadmfinanciacion := (1 + seguridad.ufnperiodoobteneradmfinanciacion(@idperiodo)) / 100 as proceadmfinanciacion
    , @proceprecioproducto := (1 + ifnull(tblprod.factorprecio, 0)) / 100 as proceprecioproducto
    
    , @costonetocaja := (((@costototalfabricacion * @porceicacree * @porcecomisionasesor) * @porcecomisionasesor) * @proceprecioproducto * @porcealzageneral) as costonetocaja
from produccion.producto as tblprod
	inner join produccion.troquel as tbltroq on tblprod.troquel_idtroquel = tbltroq.idtroquel
	inner join produccion.insumo as tblimcaja on tblprod.insumo_idinsumo_material = tblimcaja.idinsumo
    
    inner join produccion.maquinavariprod as tblvpconv on tblprod.maquinavariprod_idvariacion_rutaconversion =  tblvpconv.idvariacion
	inner join produccion.maquina as tblmrconv on tblvpconv.maquina_idmaquina = tblmrconv.idmaquina
    
	inner join produccion.maquinavariprod as tblvptroq on tblprod.maquinavariprod_idvariacion_rutatroquelado =  tblvptroq.idvariacion
	inner join produccion.maquina as tblmrtroq on tblvptroq.maquina_idmaquina = tblmrtroq.idmaquina
    
	inner join produccion.maquinavariprod as tblvplito on tblprod.maquinavariprod_idvariacion_rutalitografia =  tblvplito.idvariacion
	inner join produccion.maquina as tblmrlito on tblvplito.maquina_idmaquina = tblmrlito.idmaquina
    
    inner join produccion.maquinavariprod as tblvpguillo on tblprod.maquinavariprod_idvariacion_rutaguillotinado =  tblvpguillo.idvariacion
	inner join produccion.maquina as tblmrguillo on tblvpguillo.maquina_idmaquina = tblmrguillo.idmaquina
    
    left join produccion.maquinavariprod as tblvpaca on tblprod.maquinavariprod_idvariacion_rutaplastificado =  tblvpaca.idvariacion
	left join produccion.maquina as tblmraca on tblvpaca.maquina_idmaquina = tblmraca.idmaquina
    
    left join produccion.maquinavariprod as tblvpcola on tblprod.maquinavariprod_idvariacion_rutacolaminado =  tblvpcola.idvariacion
	left join produccion.maquina as tblmrcola on tblvpcola.maquina_idmaquina = tblmrcola.idmaquina
    
	left join produccion.insumo as tblimreem on tblprod.insumo_idinsumo_reempaque = tblimreem.idinsumo
	left join produccion.insumo as tblimcola on tblprod.insumo_idinsumo_colaminado = tblimcola.idinsumo
	left join produccion.insumo as tblimacabder on tblprod.insumo_idinsumo_acabadoderecho = tblimacabder.idinsumo
	left join produccion.insumo as tblimacabrev on tblprod.insumo_idinsumo_acabadoreverso = tblimacabrev.idinsumo
where tblprod.idproducto = 2488;