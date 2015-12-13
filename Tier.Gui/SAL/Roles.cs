using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.SAL
{
    public static class Roles
    {
        public static IEnumerable<CotizarService.Rol> RecuperarTodos()
        {
            return new clsRoles().RecuperarTodos();
        }

        public static IEnumerable<CotizarService.Rol> RecuperarActivos()
        {
            return new clsRoles().RecuperarActivos(new CotizarService.Rol() { activo = true });
        }

        public static CotizarService.Rol RecuperarXId(short id)
        {
            return new clsRoles().RecuperarXId(new CotizarService.Rol() { idrol = id });
        }
    }

    internal class clsRoles : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.Rol> RecuperarTodos()
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Rol_RecuperarFiltros(new CotizarService.Rol());
        }

        internal IEnumerable<CotizarService.Rol> RecuperarActivos(CotizarService.Rol obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Rol_RecuperarFiltros(obj);
        }

        internal CotizarService.Rol RecuperarXId(CotizarService.Rol obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Rol_RecuperarFiltros(obj).FirstOrDefault();
        }
    }
}