using System;
using System.Data.Linq.Mapping;

namespace Tier.Dto
{
    public class ProductoAccesorio
    {
        [Column(Name = "idproducto_accesorio")]
        public Nullable<int> idproducto_accesorio { get; set; }

        [Column(Name = "activo")]
        public Nullable<bool> activo { get; set; }

        [Column(Name = "fechacreacion")]
        public Nullable<DateTime> fechacreacion { get; set; }

        [Column(Name = "accesorio_idaccesorio")]
        public Nullable<int> accesorio_idaccesorio { get; set; }

        [Column(Name = "accesorio_descaccesorio")]
        public string accesorio_descaccesorio { get; set; }

        [Column(Name = "accesorio")]
        public Dto.Accesorio accesorio { get; set; }

        [Column(Name = "producto_idproducto")]
        public Nullable<int> producto_idproducto { get; set; }

        [Column(Name = "producto_descproducto")]
        public string producto_descproducto { get; set; }

        [Column(Name = "cantidad")]
        public Nullable<int> cantidad { get; set; }

    }
}
