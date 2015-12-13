using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.SAL
{
    public static class Troqueles
    {
        public static IEnumerable<CotizarService.Troquel> RecuperarTodos(Nullable<byte> idEmpresa)
        {
            return new clsTroqueles().RecuperarTodos(new CotizarService.Troquel() { empresa_idempresa = idEmpresa });
        }

        public static CotizarService.Troquel RecuperarXId(int idTroquel, Nullable<byte> idEmpresa)
        {
            return new clsTroqueles().RecuperarXId(new CotizarService.Troquel() { idtroquel = idTroquel, empresa_idempresa = idEmpresa });
        }
    }

    internal class clsTroqueles : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.Troquel> RecuperarTodos(CotizarService.Troquel obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Troquel_RecuperarFiltros(obj);
        }

        internal CotizarService.Troquel RecuperarXId(CotizarService.Troquel obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Troquel_RecuperarFiltros(obj).FirstOrDefault();
        }
    }
}