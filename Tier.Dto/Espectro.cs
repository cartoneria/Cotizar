using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Dto
{
    public partial class Espectro
    {
        [Column(Name = "idespectro")]
        public Nullable<int> idespectro { get; set; }

        [Column(Name = "activo")]
        public Nullable<bool> activo { get; set; }

        [Column(Name = "fechacreacion")]
        public Nullable<DateTime> fechacreacion { get; set; }

        [Column(Name = "producto_idproducto")]
        public Nullable<int> producto_idproducto { get; set; }

        [Column(Name = "producto_cliente_idcliente")]
        public Nullable<int> producto_cliente_idcliente { get; set; }

        public IEnumerable<Dto.EspectroPantone> pantones { get; set; }
    }
}
