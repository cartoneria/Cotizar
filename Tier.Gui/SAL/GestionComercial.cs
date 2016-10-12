using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.SAL
{
    public static class GestionComercial
    {
        public static CotizarService.ReporteGestionComercial ObtenerReporteGestionComercial()
        {
            return new clsGestionComercial().ObtenerReporteGestionComercial();
        }

        public static IEnumerable<CotizarService.PedidoGestion> ObtenerPedidosGestionXAgrupacion(byte agrupacion)
        {
            return new clsGestionComercial().ObtenerPedidosGestionXAgrupacion(agrupacion);
        }
    }

    internal class clsGestionComercial : BaseServiceAccessParent
    {
        internal CotizarService.ReporteGestionComercial ObtenerReporteGestionComercial()
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.GestionComercial_ObtenerReporteGestionComercial();
        }

        internal IEnumerable<CotizarService.PedidoGestion> ObtenerPedidosGestionXAgrupacion(byte agrupacion)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.GestionComercial_ObtenerPedidosXAgrupacion(agrupacion);
        }
    }
}