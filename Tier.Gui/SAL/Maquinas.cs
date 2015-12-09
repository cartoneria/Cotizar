using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.SAL
{
    public static class Maquinas
    {
        public static IEnumerable<CotizarService.Maquina> RecuperarTodas()
        {
            return new clsMaquinas().RecuperarTodas();
        }

        public static CotizarService.Maquina RecuperarXId(short idMaquina)
        {
            return new clsMaquinas().RecuperarXId(idMaquina);
        }

        public static IEnumerable<CotizarService.Maquina> RecuperarActivas()
        {
            return new clsMaquinas().RecuperarActivas();
        }
    }

    internal class clsMaquinas : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.Maquina> RecuperarTodas()
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Maquina_RecuperarFiltros(new CotizarService.Maquina());
        }

        internal CotizarService.Maquina RecuperarXId(short idMaquina)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Maquina_RecuperarFiltros(new CotizarService.Maquina() { idmaquina = idMaquina }).FirstOrDefault();
        }

        internal IEnumerable<CotizarService.Maquina> RecuperarActivas()
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Maquina_RecuperarFiltros(new CotizarService.Maquina() { activo = true });
        }
    }

}