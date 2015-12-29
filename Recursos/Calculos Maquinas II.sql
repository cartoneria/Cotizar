select 
	tblemp.idempresa
    , tblmaq.idmaquina
    , tblvp.idvariacion
    , (tblmaq.areaancho * tblmaq.arealargo * tblparamvm2.valornumero) as varea
    , (tblmdp.avaluocomercial + (tblmaq.areaancho * tblmaq.arealargo * tblparamvm2.valornumero)) as vtotal
    , round(((tblmdp.avaluocomercial + (tblmaq.areaancho * tblmaq.arealargo * tblparamvm2.valornumero)) / seguridad.ufnperiodoextotmaq(tblparamvm2.valornumero, tblemp.idempresa, tblperi.idperiodo)) * 100, 4) as porcentparti
	, (seguridad.ufnperiodoobtenerutilidad(tblperi.idperiodo) * (tblmdp.avaluocomercial + (tblmaq.areaancho * tblmaq.arealargo * tblparamvm2.valornumero)) / seguridad.ufnperiodoextotmaq(tblparamvm2.valornumero, tblemp.idempresa, tblperi.idperiodo)) as utilidad
    , (((tblparamdht.valornumero * 8) - tblmdp.tiempomtto - tblparamhperemp.valornumero - tblparamhcap.valornumero) * 60) as mintraba
    , (tblparamvkwhe.valornumero * tblmaq.consumonominal) as vconsumohora
    , (((seguridad.ufnperiodoobtenerutilidad(tblperi.idperiodo) * (tblmdp.avaluocomercial + (tblmaq.areaancho * tblmaq.arealargo * tblparamvm2.valornumero)) / seguridad.ufnperiodoextotmaq(tblparamvm2.valornumero, tblemp.idempresa, tblperi.idperiodo)) + tblmdp.presupuesto) / (((tblparamdht.valornumero * 8) - tblmdp.tiempomtto - tblparamhperemp.valornumero - tblparamhcap.valornumero) * 60) * 60 + (tblparamvkwhe.valornumero * tblmaq.consumonominal)) as vhmaquina
    , (((seguridad.ufnperiodoobtenerutilidad(tblperi.idperiodo) * (tblmdp.avaluocomercial + (tblmaq.areaancho * tblmaq.arealargo * tblparamvm2.valornumero)) / seguridad.ufnperiodoextotmaq(tblparamvm2.valornumero, tblemp.idempresa, tblperi.idperiodo)) + tblmdp.presupuesto) / (((tblparamdht.valornumero * 8) - tblmdp.tiempomtto - tblparamhperemp.valornumero - tblparamhcap.valornumero) * 60) * tblvp.tiempoalistamiento) as vmtto
    , ((((seguridad.ufnperiodoobtenerutilidad(tblperi.idperiodo) * (tblmdp.avaluocomercial + (tblmaq.areaancho * tblmaq.arealargo * tblparamvm2.valornumero)) / seguridad.ufnperiodoextotmaq(tblparamvm2.valornumero, tblemp.idempresa, tblperi.idperiodo)) + tblmdp.presupuesto) / (((tblparamdht.valornumero * 8) - tblmdp.tiempomtto - tblparamhperemp.valornumero - tblparamhcap.valornumero) * 60) * 60 + (tblparamvkwhe.valornumero * tblmaq.consumonominal)) / 60 * tblvp.tiempoalistamiento) as vta
    , ((((seguridad.ufnperiodoobtenerutilidad(tblperi.idperiodo) * (tblmdp.avaluocomercial + (tblmaq.areaancho * tblmaq.arealargo * tblparamvm2.valornumero)) / seguridad.ufnperiodoextotmaq(tblparamvm2.valornumero, tblemp.idempresa, tblperi.idperiodo)) + tblmdp.presupuesto) / (((tblparamdht.valornumero * 8) - tblmdp.tiempomtto - tblparamhperemp.valornumero - tblparamhcap.valornumero) * 60) * 60 + (tblparamvkwhe.valornumero * tblmaq.consumonominal)) / (tblvp.produccioncant * tblmaq.turnos)) as vunidad
from produccion.maquina as tblmaq
	inner join seguridad.empresa as tblemp on tblmaq.empresa_idempresa = tblemp.idempresa
    inner join produccion.maquinavariprod as tblvp on tblmaq.idmaquina = tblvp.maquina_idmaquina
    inner join produccion.maquinadatosperiodos as tblmdp on tblmaq.idmaquina = tblmdp.maquina_idmaquina
    inner join seguridad.periodo as tblperi on tblmdp.periodo_idperiodo = tblperi.idperiodo
    inner join seguridad.parametro as tblparamvm2 on tblperi.idperiodo = tblparamvm2.periodo_idperiodo and tblparamvm2.nombre = 'vm2'
    inner join seguridad.parametro as tblparamdht on tblperi.idperiodo = tblparamdht.periodo_idperiodo and tblparamdht.nombre = 'dht'
    inner join seguridad.parametro as tblparamhperemp on tblperi.idperiodo = tblparamhperemp.periodo_idperiodo and tblparamhperemp.nombre = 'hperemp'
    inner join seguridad.parametro as tblparamhcap on tblperi.idperiodo = tblparamhcap.periodo_idperiodo and tblparamhcap.nombre = 'hcap'
    inner join seguridad.parametro as tblparamvkwhe on tblperi.idperiodo = tblparamvkwhe.periodo_idperiodo and tblparamvkwhe.nombre = 'vkwhe'