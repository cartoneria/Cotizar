using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.SAL
{
    public static class Municipios
    {
        public static IEnumerable<CotizarService.Municipio> RecuperarActivos()
        {
            return new clsMunicipios().RecuperarActivos();
        }

        public static IEnumerable<CotizarService.Municipio> RecuperarXDepartamento(string idDepartamento)
        {
            return new clsMunicipios().RecuperarXDepartamento(new CotizarService.Municipio() { activo = true, departamento_iddepartamento = idDepartamento });
        }
    }

    internal class clsMunicipios : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.Municipio> RecuperarActivos()
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Municipio_RecuperarFiltros(new CotizarService.Municipio() { activo = true });
        }

        internal IEnumerable<CotizarService.Municipio> RecuperarXDepartamento(CotizarService.Municipio obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Municipio_RecuperarFiltros(obj);
        }
    }
}