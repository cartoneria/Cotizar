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

        public static CotizarService.Troquel RecuperarXId(int idTroquel)
        {
            return new clsTroqueles().RecuperarXId(new CotizarService.Troquel() { idtroquel = idTroquel });
        }
    }

    internal class clsTroqueles : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.Troquel> RecuperarTodos()
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Troquel_RecuperarFiltros(new CotizarService.Troquel());
        }

        internal CotizarService.Troquel RecuperarXId(CotizarService.Troquel obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Troquel_RecuperarFiltros(obj).FirstOrDefault();
        }
    }
}