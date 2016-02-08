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
            return new clsAsesores().RecuperarFiltrados(new CotizarService.Asesor() { empresa_idempresa = idEmpresa });
        }

        public static CotizarService.Asesor RecuperarXId(byte idAsesor, Nullable<byte> idEmpresa)
        {
            return new clsAsesores().RecuperarXId(new CotizarService.Asesor() { idasesor = idAsesor, empresa_idempresa = idEmpresa });
        }

        public static IEnumerable<CotizarService.Asesor> RecuperarActivos(Nullable<byte> idEmpresa)
        {
            return new clsAsesores().RecuperarFiltrados(new CotizarService.Asesor() { empresa_idempresa = idEmpresa, activo = true });
        }

        public static IEnumerable<CotizarService.Asesor> RecuperarFiltrados(CotizarService.Asesor obj)
        {
            return new clsAsesores().RecuperarFiltrados(obj);
        }
    }

    internal class clsAsesores : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.Asesor> RecuperarFiltrados(CotizarService.Asesor obj)
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