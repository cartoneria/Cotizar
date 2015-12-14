using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.SAL
{
    public static class Insumos
    {
        public static IEnumerable<CotizarService.Insumo> RecuperarTodos(Nullable<byte> idEmpresa)
        {
            return new clsInsumos().RecuperarTodos(new CotizarService.Insumo() { empresa_idempresa = idEmpresa });
        }

        public static CotizarService.Insumo RecuperarXId(int intIdInsumo, Nullable<byte> idEmpresa)
        {
            return new clsInsumos().RecuperarXId(new CotizarService.Insumo() { idinsumo = intIdInsumo, empresa_idempresa = idEmpresa });
        }
    }

    internal class clsInsumos : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.Insumo> RecuperarTodos(CotizarService.Insumo obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Insumo_RecuperarFiltros(obj);
        }

        internal CotizarService.Insumo RecuperarXId(CotizarService.Insumo obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Insumo_RecuperarFiltros(obj).FirstOrDefault();
        }
    }
}