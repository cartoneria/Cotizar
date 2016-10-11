using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Business
{
    public class BGestionComercial
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Dto.ReporteGestionComercial ObtenerReporteGestionComercial()
        {
            return new Data.DGestionComercial().RecuperarDatosReporteGestionComercial();
        }
    }
}
