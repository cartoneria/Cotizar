using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.SAL
{
    public static class Clientes
    {
        public static IEnumerable<CotizarService.Cliente> RecuperarTodos()
        {
            return new clsClientes().RecuperarTodos();
        }
        public static CotizarService.Cliente RecuperarXId(int idCliente)
        {
            return new clsClientes().RecuperarXId(new CotizarService.Cliente() { idcliente = idCliente });
        }
    }

    internal class clsClientes : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.Cliente> RecuperarTodos()
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Cliente_RecuperarFiltros(new CotizarService.Cliente());
        }

        internal CotizarService.Cliente RecuperarXId(CotizarService.Cliente obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Cliente_RecuperarFiltros(obj).FirstOrDefault();
        }
    }
}