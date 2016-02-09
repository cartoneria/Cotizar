using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.SAL
{
    public static class Cotizaciones
    {
        public static IEnumerable<CotizarService.Cotizacion> RecuperarXCliente(int idCliente)
        {
            return new clsCotizaciones().RecuperarXCliente(new CotizarService.Cotizacion() { cliente_idcliente = idCliente });
        }

        public static IEnumerable<CotizarService.Esacala> RecuperarEscalas()
        {
            return new clsCotizaciones().RecuperarEscalas();
        }
    }

    internal class clsCotizaciones : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.Cotizacion> RecuperarXCliente(CotizarService.Cotizacion obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Cotizacion_RecuperarFiltros(obj);
        }

        internal IEnumerable<CotizarService.Esacala> RecuperarEscalas()
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Cotizacion_RecuperarEscalas();
        }
    }
}