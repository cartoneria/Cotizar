using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.SAL
{
    public static class Asesores
    {
        public static IEnumerable<CotizarService.Asesor> RecuperarTodos(Nullable<byte> idEmpresa)
        {
            return new clsAsesores().RecuperarTodos(new CotizarService.Asesor() { empresa_idempresa = idEmpresa });
        }

        public static CotizarService.Asesor RecuperarXId(byte idAsesor, Nullable<byte> idEmpresa)
        {
            return new clsAsesores().RecuperarXId(new CotizarService.Asesor() { idasesor = idAsesor, empresa_idempresa = idEmpresa });
        }
    }

    internal class clsAsesores : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.Asesor> RecuperarTodos(CotizarService.Asesor obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Asesor_RecuperarFiltros(obj);
        }

        internal CotizarService.Asesor RecuperarXId(CotizarService.Asesor obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Asesor_RecuperarFiltros(obj).FirstOrDefault();
        }
    }
}