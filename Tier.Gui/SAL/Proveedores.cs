using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.SAL
{
    public static class Proveedores
    {
        public static IEnumerable<CotizarService.Proveedor> RecuperarTodos(Nullable<byte> idEmpresa)
        {
            return new clsProveedores().RecuperarTodos(new CotizarService.Proveedor() { empresa_idempresa = idEmpresa });
        }

        public static IEnumerable<CotizarService.Proveedor> RecuperarActivos(Nullable<byte> idEmpresa)
        {
            return new clsProveedores().RecuperarActivos(new CotizarService.Proveedor() { activo = true, empresa_idempresa = idEmpresa });
        }

        public static CotizarService.Proveedor RecuperarXId(int id, Nullable<byte> idEmpresa)
        {
            return new clsProveedores().RecuperarXId(new CotizarService.Proveedor() { idproveedor = id, empresa_idempresa = idEmpresa });
        }

        public static CotizarService.ProveedorLinea RecuperarLineaXId(int id)
        {
            return new clsProveedores().RecuperarLienaXId(new CotizarService.ProveedorLinea() { idproveedor_linea = id });
        }
    }

    public class clsProveedores : BaseServiceAccessParent
    {
        public IEnumerable<CotizarService.Proveedor> RecuperarTodos(CotizarService.Proveedor obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Proveedor_RecuperarFiltros(obj);
        }

        public IEnumerable<CotizarService.Proveedor> RecuperarActivos(CotizarService.Proveedor obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Proveedor_RecuperarFiltros(obj);
        }

        public CotizarService.Proveedor RecuperarXId(CotizarService.Proveedor obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Proveedor_RecuperarFiltros(obj).FirstOrDefault();
        }

        public CotizarService.ProveedorLinea RecuperarLienaXId(CotizarService.ProveedorLinea obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Proveedor_RecuperarLineasFiltros(obj).FirstOrDefault();
        }
    }
}