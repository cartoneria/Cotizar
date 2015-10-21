using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.SAL
{
    public static class Insimos
    {
        public static IEnumerable<CotizarService.Insumo> RecuperarTodos()
        {
            return new clsInsimos().RecuperarTodos();
        }
    }

    internal class clsInsimos : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.Insumo> RecuperarTodos()
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Insumo_RecuperarFiltros(new CotizarService.Insumo());
        }
    }
}