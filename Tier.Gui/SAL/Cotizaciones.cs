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
            return new clsCotizaciones().RecuperarFiltrados(new CotizarService.Cotizacion() { cliente_idcliente = idCliente });
        }

        public static CotizarService.Cotizacion RecuperarXId(int id)
        {
            return new clsCotizaciones().RecuperarFiltrados(new CotizarService.Cotizacion() { idcotizacion = id }).FirstOrDefault();
        }
    }

    internal class clsCotizaciones : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.Cotizacion> RecuperarFiltrados(CotizarService.Cotizacion obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Cotizacion_RecuperarFiltros(obj);
        }
    }
}