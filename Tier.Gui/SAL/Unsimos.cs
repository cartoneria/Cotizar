using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.SAL
{
    public static class Insimos
    {
        public static IEnumerable<CotizarService.Insumo> RecuperarTodos()
        {
            return new clsInsimos().RecuperarTodos();
        }

        public static IEnumerable<CotizarService.Insumo> RecuperarXProveedor(Nullable<int> idProveedor)
        {
            return new clsInsimos().RecuperarXProveedor(new CotizarService.Insumo() { proveedor_linea_proveedor_idproveedor = idProveedor });
        }
    }

    internal class clsInsimos : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.Insumo> RecuperarTodos()
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Insumo_RecuperarFiltros(new CotizarService.Insumo());
        }

        internal IEnumerable<CotizarService.Insumo> RecuperarXProveedor(CotizarService.Insumo obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Insumo_RecuperarFiltros(obj);
        }
    }
}