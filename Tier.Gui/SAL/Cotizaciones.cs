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
    }

    internal class clsCotizaciones : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.Cotizacion> RecuperarXCliente(CotizarService.Cotizacion obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Cotizacion_RecuperarFiltros(obj);
        }
    }
}