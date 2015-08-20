using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.SAL
{
    public static class Asesores
    {
        public static IEnumerable<CotizarService.Asesor> RecuperarTodos()
        {
            return new clsAsesores().RecuperarTodos();
        }
    }

    internal class clsAsesores : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.Asesor> RecuperarTodos()
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Asesor_RecuperarFiltros(new CotizarService.Asesor());
        }
    }
}