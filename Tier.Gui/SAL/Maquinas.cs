using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.SAL
{
    public static class Maquinas
    {
        public static IEnumerable<CotizarService.Maquina> RecuperarTodas(Nullable<byte> idEmpresa)
        {
            return new clsMaquinas().RecuperarTodas(new CotizarService.Maquina() { empresa_idempresa = idEmpresa });
        }

        public static CotizarService.Maquina RecuperarXId(short idMaquina, Nullable<byte> idEmpresa)
        {
            return new clsMaquinas().RecuperarXId(new CotizarService.Maquina() { idmaquina = idMaquina, empresa_idempresa = idEmpresa });
        }

        public static IEnumerable<CotizarService.Maquina> RecuperarActivas(Nullable<byte> idEmpresa)
        {
            return new clsMaquinas().RecuperarActivas(new CotizarService.Maquina() { activo = true });
        }
    }

    internal class clsMaquinas : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.Maquina> RecuperarTodas(CotizarService.Maquina obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Maquina_RecuperarFiltros(obj);
        }

        internal CotizarService.Maquina RecuperarXId(CotizarService.Maquina obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Maquina_RecuperarFiltros(obj).FirstOrDefault();
        }

        internal IEnumerable<CotizarService.Maquina> RecuperarActivas(CotizarService.Maquina obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Maquina_RecuperarFiltros(obj);
        }
    }

}