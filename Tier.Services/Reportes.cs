using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Services
{
    public partial class CotizarService : ICotizarService
    {
        public byte[] Reportes_Cotizacion(int idCotizacion)
        {
            return new Business.BReportes().GenerarReporteCotizacion(idCotizacion);
        }
    }
}
