using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.SAL
{
    public static class Periodos
    {
        public static IEnumerable<CotizarService.Periodo> RecuperarActivos()
        {
            return new clsPeriodos().RecuperarActivos();
        }
    }

    internal class clsPeriodos : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.Periodo> RecuperarActivos()
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Periodo_RecuperarFiltros(new CotizarService.Periodo());
        }
    }
}