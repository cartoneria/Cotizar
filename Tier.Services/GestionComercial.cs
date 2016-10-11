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
    }
}
