using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.SAL
{
    public static class Empresas
    {
        public static IEnumerable<CotizarService.Empresa> RecuperarEmpresasTodas()
        {
            return new clsEmpresas().RecuperarEmpresasTodas();
        }

        public static IEnumerable<CotizarService.Empresa> RecuperarEmpresasActivas()
        {
            return new clsEmpresas().RecuperarEmpresasActivas();
        }

        public static CotizarService.Empresa RecuperarXId(byte id)
        {
            return new clsEmpresas().RecuperarXId(id);
        }
    }

    public class clsEmpresas : BaseServiceAccessParent
    {
        public IEnumerable<CotizarService.Empresa> RecuperarEmpresasTodas()
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Empresa_RecuperarFiltrado(new CotizarService.Empresa());
        }

        public IEnumerable<CotizarService.Empresa> RecuperarEmpresasActivas()
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Empresa_RecuperarFiltrado(new CotizarService.Empresa() { activo = true });
        }

        public CotizarService.Empresa RecuperarXId(byte id)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Empresa_RecuperarFiltrado(new CotizarService.Empresa() { idempresa = id }).FirstOrDefault();
        }
    }
}