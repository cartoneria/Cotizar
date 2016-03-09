using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
