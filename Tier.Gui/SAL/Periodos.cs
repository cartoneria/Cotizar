using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.SAL
{
    public static class Periodos
    {
        public static IEnumerable<CotizarService.Periodo> RecuperarTodos()
        {
            return new clsPeriodos().RecuperarTodos();
        }
    }

    internal class clsPeriodos : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.Periodo> RecuperarTodos()
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Periodo_RecuperarFiltros(new CotizarService.Periodo());
        }
    }
}