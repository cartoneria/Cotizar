using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.SAL
{
    public static class Pantones
    {
        public static IEnumerable<CotizarService.Pantone> RecuperarTodos()
        {
            return new clsPantones().RecuperarTodos();
        }

        public static CotizarService.Pantone RecuperarXId(int id)
        {
            return new clsPantones().RecuperarXId(id);
        }
    }

    internal class clsPantones : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.Pantone> RecuperarTodos()
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Pantone_RecuperarFiltros(new CotizarService.Pantone());
        }

        internal CotizarService.Pantone RecuperarXId(int id)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Pantone_RecuperarFiltros(new CotizarService.Pantone() { idpantone = id }).FirstOrDefault();
        }
    }
}