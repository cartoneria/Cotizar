select 
	tblProd.idproducto
    , tblTroq.idtroquel
    , tblIMC.idinsumo
    , tblProd.cabidaancho
    , tblProd.largobobina
    , tblProd.anchobobina
    , tblProd.cabidalargo
from produccion.producto as tblProd
	inner join produccion.troquel as tblTroq on tblProd.troquel_idtroquel = tblTroq.idtroquel
    inner join produccion.insumo as tblIMC on tblProd.insumo_idinsumo_material = tblIMC.idinsumo;