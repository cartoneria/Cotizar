using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Services
{
    public partial class CotizarService : ICotizarService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idCotizacion"></param>
        /// <returns></returns>
        public byte[] Reportes_Cotizacion(int idCotizacion)
        {
            return new Business.BReportes().GenerarReporteCotizacion(idCotizacion);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPedido"></param>
        /// <returns></returns>
        public byte[] Reportes_OrdenProduccion(int idPedido)
        {
            return new Business.BReportes().GenerarReporteOrdenProduccion(idPedido);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idProducto"></param>
        /// <returns></returns>
        public byte[] Reportes_FichaTecnicaProducto(int idProducto)
        {
            return new Business.BReportes().GenerarReporteFichaTecnicaProducto(idProducto);
        }
    }
}
