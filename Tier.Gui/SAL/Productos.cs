using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.SAL
{
    public static class Productos
    {
        public static IEnumerable<CotizarService.Producto> RecuperarTodos(Nullable<int> idCliente, bool objCompuesto)
        {
            return new clsProductos().RecuperarTodos(new CotizarService.Producto() { cliente_idcliente = idCliente }, objCompuesto);
        }

        public static CotizarService.Producto RecuperarXId(int idProducto, bool objCompuesto)
        {
            return new clsProductos().RecuperarXId(new CotizarService.Producto() { idproducto = idProducto }, objCompuesto);
        }
    }

    internal class clsProductos : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.Producto> RecuperarTodos(CotizarService.Producto obj, bool objCompuesto)
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