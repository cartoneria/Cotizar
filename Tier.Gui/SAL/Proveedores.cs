using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.SAL
{
    public static class Proveedores
    {
        public static IEnumerable<CotizarService.Proveedor> RecuperarProveedoresTodos()
        {
            return new clsProveedores().RecuperarProveedoresTodas();
        }

        public static IEnumerable<CotizarService.Proveedor> RecuperarProveedoresActivos()
        {
            return new clsProveedores().RecuperarProveedoresActivas();
        }

        public static CotizarService.Proveedor RecuperarXId(int id)
        {
            return new clsProveedores().RecuperarXId(id);
        }

        public static CotizarService.ProveedorLinea RecuperarLineaXId(int id)
        {
            return new clsProveedores().RecuperarLienaXId(id);
        }
    }

    public class clsProveedores : BaseServiceAccessParent
    {
        public IEnumerable<CotizarService.Proveedor> RecuperarProveedoresTodas()
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Proveedor_RecuperarFiltros(new CotizarService.Proveedor());
        }

        public IEnumerable<CotizarService.Proveedor> RecuperarProveedoresActivas()
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Proveedor_RecuperarFiltros(new CotizarService.Proveedor() { activo = true });
        }

        public CotizarService.Proveedor RecuperarXId(int id)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Proveedor_RecuperarFiltros(new CotizarService.Proveedor() { idproveedor = id }).FirstOrDefault();
        }

        public CotizarService.ProveedorLinea RecuperarLienaXId(int id)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Proveedor_RecuperarLineasFiltros(new CotizarService.ProveedorLinea() { idproveedor_linea = id }).FirstOrDefault();
        }
    }
}