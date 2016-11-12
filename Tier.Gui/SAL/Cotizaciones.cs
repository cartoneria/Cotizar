using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.SAL
{
    public static class Cotizaciones
    {
        public static IEnumerable<CotizarService.Cotizacion> RecuperarXCliente(int idCliente, bool objCompuesto)
        {
            return new clsCotizaciones().RecuperarFiltrados(new CotizarService.Cotizacion() { cliente_idcliente = idCliente }, objCompuesto);
        }

        public static CotizarService.Cotizacion RecuperarXId(int id, bool objCompuesto)
        {
            return new clsCotizaciones().RecuperarFiltrados(new CotizarService.Cotizacion() { idcotizacion = id }, objCompuesto).FirstOrDefault();
        }
    }

    internal class clsCotizaciones : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.Cotizacion> RecuperarFiltrados(CotizarService.Cotizacion obj, bool objCompuesto)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Cotizacion_RecuperarFiltros(obj, objCompuesto);
        }
    }
}