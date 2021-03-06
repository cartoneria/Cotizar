﻿using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;

namespace Tier.Dto
{
    public class Cotizacion
    {
        #region [Propiedades]
        [Column(Name = "idcotizacion")]
        public Nullable<int> idcotizacion { get; set; }

        [Column(Name = "activo")]
        public Nullable<bool> activo { get; set; }

        [Column(Name = "fechacreacion")]
        public Nullable<DateTime> fechacreacion { get; set; }

        [Column(Name = "cliente_idcliente")]
        public Nullable<int> cliente_idcliente { get; set; }

        [Column(Name = "cliente_desccliente")]
        public string cliente_desccliente { get; set; }

        [Column(Name = "periodo_idPeriodo")]
        public Nullable<int> periodo_idPeriodo { get; set; }

        [Column(Name = "periodo_descperiodo")]
        public string periodo_descperiodo { get; set; }

        [Column(Name = "observaciones")]
        public string observaciones { get; set; }

        [Column(Name = "costosplancha")]
        public Nullable<Single> costosplancha { get; set; }

        [Column(Name = "costostroqueles")]
        public Nullable<Single> costostroqueles { get; set; }

        [Column(Name = "itemlista_iditemlista_estado")]
        public Nullable<int> itemlista_iditemlista_estado { get; set; }

        [Column(Name = "itemlista_iditemlista_descestado")]
        public string itemlista_iditemlista_descestado { get; set; }

        public IEnumerable<CotizacionDetalle> detalle { get; set; } 
        #endregion

        #region [Métodos]
        public void AsignarIdentificador()
        {
            if (this.detalle != null && this.detalle.Count() > 0)
            {
                foreach (Dto.CotizacionDetalle item in this.detalle)
                {
                    item.cotizacion_idcotizacion = this.idcotizacion;
                }
            }
        }
        #endregion
    }
}
