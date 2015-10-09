using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.SAL
{
    public static class Troqueles
    {
        public static IEnumerable<CotizarService.Troquel> RecuperarTodos()
        {
            return new clsTroqueles().RecuperarTodos();
        }
    }

    internal class clsTroqueles : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.Troquel> RecuperarTodos()
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Troquel_RecuperarFiltros(new CotizarService.Troquel());
        }
    }
}