﻿using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Dto
{
    public class Cotizacion
    {
        [Column(Name = "idcotizacion")]
        public Nullable<int> idcotizacion { get; set; }

        [Column(Name = "activo")]
        public Nullable<bool> activo { get; set; }

        [Column(Name = "fechacreacion")]
        public Nullable<DateTime> fechacreacion { get; set; }

        [Column(Name = "cliente_idcliente")]
        public Nullable<int> cliente_idcliente { get; set; }

        [Column(Name = "periodo_idPeriodo")]
        public Nullable<int> periodo_idPeriodo { get; set; }

        [Column(Name = "observaciones")]
        public string observaciones { get; set; }

        [Column(Name = "valoresplancha")]
        public string valoresplancha { get; set; }

        [Column(Name = "valorestroqueles")]
        public string valorestroqueles { get; set; }

        [Column(Name = "itemlista_iditemlista_estado")]
        public Nullable<int> itemlista_iditemlista_estado { get; set; }

        public IEnumerable<CotizacionDetalle> detalle { get; set; }
    }
}
