using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.SAL
{
    public static class Empresas
    {
        public static IEnumerable<CotizarService.Empresa> RecuperarEmpresasActivas()
        {
            return new clsEmpresas().RecuperarEmpresasActivas();
        }

    }

    public class clsEmpresas : BaseServiceAccessParent
    {
        public IEnumerable<CotizarService.Empresa> RecuperarEmpresasActivas()
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Empresa_RecuperarFiltrado(new CotizarService.Empresa() { activo = true });
        }
    }
}