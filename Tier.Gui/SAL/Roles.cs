using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.SAL
{
    public static class Roles
    {
        public static IEnumerable<CotizarService.Rol> RecuperarTodos(bool objCompuesto)
        {
            return new clsRoles().RecuperarFiltrados(new CotizarService.Rol(), objCompuesto);
        }

        public static IEnumerable<CotizarService.Rol> RecuperarActivos(bool objCompuesto)
        {
            return new clsRoles().RecuperarFiltrados(new CotizarService.Rol() { activo = true }, objCompuesto);
        }

        public static CotizarService.Rol RecuperarXId(short id, bool objCompuesto)
        {
            return new clsRoles().RecuperarFiltrados(new CotizarService.Rol() { idrol = id }, objCompuesto).FirstOrDefault();
        }
    }

    internal class clsRoles : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.Rol> RecuperarFiltrados(CotizarService.Rol obj, bool objCompuesto)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Rol_RecuperarFiltros(obj, objCompuesto);
        }
    }
}