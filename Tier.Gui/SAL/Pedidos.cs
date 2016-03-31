using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.SAL
{
    public static class Pedidos
    {
        public static IEnumerable<CotizarService.Pedido> RecuperarXCliente(int idCliente)
        {
            return new clsPedidos().RecuperarXCliente(idCliente);
        }
    }

    internal class clsPedidos : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.Pedido> RecuperarXCliente(int idCliente)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Pedido_RecuperarXCliente(idCliente);
        }
    }
}