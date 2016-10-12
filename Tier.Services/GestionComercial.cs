using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Tier.Services
{
    public partial class CotizarService : ICotizarService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Dto.ReporteGestionComercial GestionComercial_ObtenerReporteGestionComercial()
        {
            return new Business.BGestionComercial().ObtenerReporteGestionComercial();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="agrupacion"></param>
        /// <returns></returns>
        public IEnumerable<Dto.PedidoGestion> GestionComercial_ObtenerPedidosXAgrupacion(byte agrupacion)
        {
            return new Business.BGestionComercial().ObtenerPedidosXAgrupacion(agrupacion);
        }
    }
}
