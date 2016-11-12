using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.SAL
{
    public static class Proveedores
    {
        public static IEnumerable<CotizarService.Proveedor> RecuperarTodos(Nullable<byte> idEmpresa, bool objCompuesto)
        {
            return new clsProveedores().RecuperarFiltrados(new CotizarService.Proveedor() { empresa_idempresa = idEmpresa }, objCompuesto);
        }

        public static IEnumerable<CotizarService.Proveedor> RecuperarActivos(Nullable<byte> idEmpresa, bool objCompuesto)
        {
            return new clsProveedores().RecuperarFiltrados(new CotizarService.Proveedor() { activo = true, empresa_idempresa = idEmpresa }, objCompuesto);
        }

        public static CotizarService.Proveedor RecuperarXId(int id, Nullable<byte> idEmpresa, bool objCompuesto)
        {
            return new clsProveedores().RecuperarFiltrados(new CotizarService.Proveedor() { idproveedor = id, empresa_idempresa = idEmpresa }, objCompuesto).FirstOrDefault();
        }

        public static CotizarService.ProveedorLinea RecuperarLineaXId(int id)
        {
            return new clsProveedores().RecuperarLineaXId(new CotizarService.ProveedorLinea() { idproveedor_linea = id });
        }

        public static IEnumerable<CotizarService.ProveedorLinea> RecuperarLineasXProveedor(int idProveedor)
        {
            return new clsProveedores().RecuperarLineasFiltrados(new CotizarService.ProveedorLinea() { proveedor_idproveedor = idProveedor });
        }
    }

    public class clsProveedores : BaseServiceAccessParent
    {
        public CotizarService.ProveedorLinea RecuperarLineaXId(CotizarService.ProveedorLinea obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Proveedor_RecuperarLineasFiltros(obj).FirstOrDefault();
        }

        public IEnumerable<CotizarService.Proveedor> RecuperarFiltrados(CotizarService.Proveedor obj, bool objCompuesto)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Proveedor_RecuperarFiltros(obj, objCompuesto);
        }

        public IEnumerable<CotizarService.ProveedorLinea> RecuperarLineasFiltrados(CotizarService.ProveedorLinea obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Proveedor_RecuperarLineasFiltros(obj);
        }
    }
}