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
            return new clsRoles().RecuperarActivos();
        }
    }

    internal class clsRoles : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.Rol> RecuperarTodos()
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Rol_RecuperarFiltros(new CotizarService.Rol());
        }

        internal IEnumerable<CotizarService.Rol> RecuperarActivos()
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Rol_RecuperarFiltros(new CotizarService.Rol() { activo = true });
        }
    }
}