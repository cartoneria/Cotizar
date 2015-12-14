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
            return new clsMunicipios().RecuperarActivos(new CotizarService.Municipio() { activo = true });
        }

        public static IEnumerable<CotizarService.Municipio> RecuperarXDepartamento(string idDepartamento)
        {
            return new clsMunicipios().RecuperarXDepartamento(new CotizarService.Municipio() { activo = true, departamento_iddepartamento = idDepartamento });
        }

        public static CotizarService.Municipio RecuperarXId(string idMunicipio)
        {
            return new clsMunicipios().RecuperarXId(new CotizarService.Municipio() { idmunicipio = idMunicipio });
        }
    }

    internal class clsMunicipios : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.Municipio> RecuperarActivos(CotizarService.Municipio obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Municipio_RecuperarFiltros(obj);
        }

        internal IEnumerable<CotizarService.Municipio> RecuperarXDepartamento(CotizarService.Municipio obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Municipio_RecuperarFiltros(obj);
        }

        internal CotizarService.Municipio RecuperarXId(CotizarService.Municipio obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Municipio_RecuperarFiltros(obj).FirstOrDefault();
        }
    }
}