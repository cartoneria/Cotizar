using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.SAL
{
    public static class Insumos
    {
        public static IEnumerable<CotizarService.Insumo> RecuperarTodos()
        {
            return new clsInsumos().RecuperarTodos();
        }

        public static CotizarService.Insumo RecuperarXId(int intIdInsumo)
        {
            return new clsInsumos().RecuperarXId(intIdInsumo);
        }
    }

    internal class clsInsumos : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.Insumo> RecuperarTodos()
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Insumo_RecuperarFiltros(new CotizarService.Insumo());
        }

        internal CotizarService.Insumo RecuperarXId(int intIdInsumo)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Insumo_RecuperarFiltros(new CotizarService.Insumo() { idinsumo = intIdInsumo }).FirstOrDefault();
        }
    }
}