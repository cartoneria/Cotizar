using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.SAL
{
    public static class Departamentos
    {
        public static IEnumerable<CotizarService.Departamento> RecuperarActivos()
        {
            return new clsDepartamentos().RecuperarActivos(new CotizarService.Departamento() { activo = true });
        }

        public static CotizarService.Departamento RecuperarXId(string idDepartamento)
        {
            return new clsDepartamentos().RecuperarXId(new CotizarService.Departamento() { iddepartamento = idDepartamento });
        }
    }

    internal class clsDepartamentos : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.Departamento> RecuperarActivos(CotizarService.Departamento obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Departamento_RecuperarFiltros(obj);
        }

        internal CotizarService.Departamento RecuperarXId(CotizarService.Departamento obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Departamento_RecuperarFiltros(obj).FirstOrDefault();
        }
    }
}