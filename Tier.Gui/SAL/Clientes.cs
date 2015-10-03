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
    }

    internal class clsClientes : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.Cliente> RecuperarTodos()
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Cliente_RecuperarFiltros(new CotizarService.Cliente());
        }
    }
}