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

        public static CotizarService.Pedido RecuperarXId(int idPedido)
        {
            return new clsPedidos().RecuperarFiltros(new CotizarService.Pedido() { idpedido = idPedido }).FirstOrDefault();
        }
    }

    internal class clsPedidos : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.Pedido> RecuperarXCliente(int idCliente)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Pedido_RecuperarXCliente(idCliente);
        }

        internal IEnumerable<CotizarService.Pedido> RecuperarFiltros(CotizarService.Pedido obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Pedido_RecuperarFiltros(obj);
        }
    }
}