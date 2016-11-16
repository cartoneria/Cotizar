using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.SAL
{
    public static class Productos
    {
        public static IEnumerable<CotizarService.Producto> RecuperarXCliente(Nullable<int> idCliente, bool objCompuesto)
        {
            return new clsProductos().RecuperarFiltrados(new CotizarService.Producto() { cliente_idcliente = idCliente }, objCompuesto);
        }

        public static CotizarService.Producto RecuperarXId(int idProducto, bool objCompuesto)
        {
            return new clsProductos().RecuperarXId(new CotizarService.Producto() { idproducto = idProducto }, objCompuesto);
        }

        public static IEnumerable<CotizarService.Producto> RecuperarFiltrados(CotizarService.Producto obj, bool objCompuesto)
        {
            return new clsProductos().RecuperarFiltrados(obj, objCompuesto);
        }
    }

    internal class clsProductos : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.Producto> RecuperarFiltrados(CotizarService.Producto obj, bool objCompuesto)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Producto_RecuperarFiltros(obj, objCompuesto);
        }

        internal CotizarService.Producto RecuperarXId(CotizarService.Producto obj, bool objCompuesto)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Producto_RecuperarFiltros(obj, objCompuesto).FirstOrDefault();
        }
    }
}