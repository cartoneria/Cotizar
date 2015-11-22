using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.SAL
{
    public static class Accesorios
    {
        public static IEnumerable<CotizarService.Accesorio> RecuperarTodos()
        {
            return new clsAccesorios().RecuperarTodos();
        }

        public static CotizarService.Accesorio RecuperarXId(int idAccesorio)
        {
            return new clsAccesorios().RecuperarXId(idAccesorio);
        }
    }

    internal class clsAccesorios : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.Accesorio> RecuperarTodos()
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Accesorio_RecuperarFiltros(new CotizarService.Accesorio());
        }

        internal CotizarService.Accesorio RecuperarXId(int idAccesorio)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Accesorio_RecuperarFiltros(new CotizarService.Accesorio() { idaccesorio = idAccesorio }).FirstOrDefault();
        }
    }
}