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
            return new clsDepartamentos().RecuperarActivos();
        }

        public static CotizarService.Departamento RecuperarXId(string idDepartamento)
        {
            return new clsDepartamentos().RecuperarXId(new CotizarService.Departamento() { iddepartamento = idDepartamento });
        }
    }

    internal class clsDepartamentos : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.Departamento> RecuperarActivos()
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Departamento_RecuperarFiltros(new CotizarService.Departamento() { activo = true });
        }

        internal CotizarService.Departamento RecuperarXId(CotizarService.Departamento obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Departamento_RecuperarFiltros(obj).FirstOrDefault();
        }
    }
}