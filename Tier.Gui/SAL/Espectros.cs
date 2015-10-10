using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.SAL
{
    public static class Espectros
    {
        public static IEnumerable<CotizarService.Espectro> RecuperarTodos()
        {
            return new clsEspectros().RecuperarTodos();
        }
    }

    internal class clsEspectros : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.Espectro> RecuperarTodos()
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Espectro_RecuperarFiltros(new CotizarService.Espectro());
        }
    }
}