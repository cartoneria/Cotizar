using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.SAL
{
    public static class Productos
    {
        public static IEnumerable<CotizarService.Producto> RecuperarTodos(Nullable<int> idCliente)
        {
            return new clsProductos().RecuperarTodos(new CotizarService.Producto() { cliente_idcliente = idCliente });
        }

        public static CotizarService.Producto RecuperarXId(int idProducto)
        {
            return new clsProductos().RecuperarXId(new CotizarService.Producto() { idproducto = idProducto });
        }
    }

    internal class clsProductos : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.Producto> RecuperarTodos(CotizarService.Producto obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Producto_RecuperarFiltros(obj);
        }

        internal CotizarService.Producto RecuperarXId(CotizarService.Producto obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Producto_RecuperarFiltros(obj).FirstOrDefault();
        }
    }
}