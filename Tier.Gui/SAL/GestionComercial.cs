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
    }

    internal class clsGestionComercial : BaseServiceAccessParent
    {
        internal CotizarService.ReporteGestionComercial ObtenerReporteGestionComercial()
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.GestionComercial_ObtenerReporteGestionComercial();
        }
    }
}