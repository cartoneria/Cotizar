using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.SAL
{
    public static class Maquinas
    {
        public static IEnumerable<CotizarService.Maquina> RecuperarTodas()
        {
            return new clsMaquinas().RecuperarTodas();
        }
    }

    internal class clsMaquinas : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.Maquina> RecuperarTodas()
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Maquina_RecuperarFiltros(new CotizarService.Maquina());
        }
    }

}