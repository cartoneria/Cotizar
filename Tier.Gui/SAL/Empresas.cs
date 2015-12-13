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
            return new clsEmpresas().RecuperarEmpresasTodas(new CotizarService.Empresa());
        }

        public static IEnumerable<CotizarService.Empresa> RecuperarEmpresasActivas()
        {
            return new clsEmpresas().RecuperarEmpresasActivas(new CotizarService.Empresa() { activo = true });
        }

        public static CotizarService.Empresa RecuperarXId(byte id)
        {
            return new clsEmpresas().RecuperarXId(new CotizarService.Empresa() { idempresa = id });
        }
    }

    public class clsEmpresas : BaseServiceAccessParent
    {
        public IEnumerable<CotizarService.Empresa> RecuperarEmpresasTodas(CotizarService.Empresa obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Empresa_RecuperarFiltrado(obj);
        }

        public IEnumerable<CotizarService.Empresa> RecuperarEmpresasActivas(CotizarService.Empresa obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Empresa_RecuperarFiltrado(obj);
        }

        public CotizarService.Empresa RecuperarXId(CotizarService.Empresa obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Empresa_RecuperarFiltrado(obj).FirstOrDefault();
        }
    }
}