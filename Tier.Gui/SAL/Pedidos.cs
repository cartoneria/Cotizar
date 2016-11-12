using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.SAL
{
    public static class Pedidos
    {
        public static IEnumerable<CotizarService.Pedido> RecuperarXCliente(int idCliente, bool objCompuesto)
        {
            return new clsPedidos().RecuperarXCliente(idCliente, objCompuesto);
        }

        public static CotizarService.Pedido RecuperarXId(int idPedido, bool objCompuesto)
        {
            return new clsPedidos().RecuperarFiltros(new CotizarService.Pedido() { idpedido = idPedido }, objCompuesto).FirstOrDefault();
        }
    }

    internal class clsPedidos : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.Pedido> RecuperarXCliente(int idCliente, bool objCompuesto)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Pedido_RecuperarXCliente(idCliente, objCompuesto);
        }

        internal IEnumerable<CotizarService.Pedido> RecuperarFiltros(CotizarService.Pedido obj, bool objCompuesto)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Pedido_RecuperarFiltros(obj, objCompuesto);
        }
    }
}