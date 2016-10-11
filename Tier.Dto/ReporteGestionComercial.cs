using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;

namespace Tier.Dto
{
    public class ReporteGestionComercial
    {
        [Column(Name = "nuevasCotizaciones")]
        public Nullable<short> nuevasCotizaciones { get; set; }

        [Column(Name = "nuevosPedidos")]
        public Nullable<short> nuevosPedidos { get; set; }

        [Column(Name = "nuevosProductos")]
        public Nullable<short> nuevosProductos { get; set; }

        [Column(Name = "nuevosClientes")]
        public Nullable<short> nuevosClientes { get; set; }
    }
}
