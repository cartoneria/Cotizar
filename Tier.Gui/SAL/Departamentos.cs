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
    }

    internal class clsDepartamentos : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.Departamento> RecuperarActivos()
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Departamento_RecuperarFiltros(new CotizarService.Departamento() { activo = true });
        }
    }
}