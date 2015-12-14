using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.SAL
{
    public static class Accesorios
    {
        public static IEnumerable<CotizarService.Accesorio> RecuperarTodos(Nullable<byte> idEmpresa)
        {
            return new clsAccesorios().RecuperarTodos(new CotizarService.Accesorio() { empresa_idempresa = idEmpresa });
        }

        public static CotizarService.Accesorio RecuperarXId(int idAccesorio, Nullable<byte> idEmpresa)
        {
            return new clsAccesorios().RecuperarXId(new CotizarService.Accesorio() { idaccesorio = idAccesorio, empresa_idempresa = idEmpresa });
        }
    }

    internal class clsAccesorios : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.Accesorio> RecuperarTodos(CotizarService.Accesorio obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Accesorio_RecuperarFiltros(obj);
        }

        internal CotizarService.Accesorio RecuperarXId(CotizarService.Accesorio obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Accesorio_RecuperarFiltros(obj).FirstOrDefault();
        }
    }
}