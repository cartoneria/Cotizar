using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Dto
{
    public class Pedido
    {
        [Column(Name = "idpedido")]
        public Nullable<int> idpedido { get; set; }

        [Column(Name = "activo")]
        public Nullable<bool> activo { get; set; }

        [Column(Name = "fechacreacion")]
        public Nullable<DateTime> fechacreacion { get; set; }

        [Column(Name = "cotizacion_idcotizacion")]
        public Nullable<int> cotizacion_idcotizacion { get; set; }

        [Column(Name = "costosplancha")]
        public Nullable<Single> costosplancha { get; set; }

        [Column(Name = "costostroqueles")]
        public Nullable<Single> costostroqueles { get; set; }

        [Column(Name = "observaciones")]
        public string observaciones { get; set; }

        [Column(Name = "itemlista_iditemlista_estado")]
        public Nullable<int> itemlista_iditemlista_estado { get; set; }

        public IEnumerable<Dto.PedidoDetalle> detalle { get; set; }
    }
}
