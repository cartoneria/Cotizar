using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.SAL
{
    public static class Pantones
    {
        public static IEnumerable<CotizarService.Pantone> RecuperarTodos(Nullable<byte> idEmpresa)
        {
            return new clsPantones().RecuperarFiltrados(new CotizarService.Pantone() { empresa_idempresa = idEmpresa });
        }

        public static CotizarService.Pantone RecuperarXId(int id)
        {
            return new clsPantones().RecuperarXId(new CotizarService.Pantone() { idpantone = id });
        }

        public static IEnumerable<CotizarService.Pantone> RecuperarFiltrados(CotizarService.Pantone obj)
        {
            return new clsPantones().RecuperarFiltrados(obj);
        }
    }

    internal class clsPantones : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.Pantone> RecuperarFiltrados(CotizarService.Pantone obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Pantone_RecuperarFiltros(obj);
        }

        internal CotizarService.Pantone RecuperarXId(CotizarService.Pantone obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Pantone_RecuperarFiltros(obj).FirstOrDefault();
        }
    }
}