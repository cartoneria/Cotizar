﻿using System;
using System.Data.Linq.Mapping;

namespace Tier.Dto
{
    public class PedidoDetalle
    {
        [Column(Name = "idpedido_detalle")]
        public Nullable<int> idpedido_detalle { get; set; }

        [Column(Name = "activo")]
        public Nullable<bool> activo { get; set; }

        [Column(Name = "fechacreacion")]
        public Nullable<DateTime> fechacreacion { get; set; }

        [Column(Name = "pedido_idpedido")]
        public Nullable<int> pedido_idpedido { get; set; }

        [Column(Name = "cotizacion_detalle_idcotizacion_detalle")]
        public Nullable<int> cotizacion_detalle_idcotizacion_detalle { get; set; }

        [Column(Name = "observaciones")]
        public string observaciones { get; set; }

        [Column(Name = "cantidad")]
        public Nullable<int> cantidad { get; set; }
    }
}
