using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Dto
{
    public class ProductoEspectro
    {
        [Column(Name = "idproducto_espectro")]
        public Nullable<int> idproducto_espectro { get; set; }

        [Column(Name = "activo")]
        public Nullable<bool> activo { get; set; }

        [Column(Name = "fechacreacion")]
        public Nullable<DateTime> fechacreacion { get; set; }

        [Column(Name = "producto_idproducto")]
        public Nullable<int> producto_idproducto { get; set; }

        [Column(Name = "pantone_idpantone")]
        public Nullable<short> pantone_idpantone { get; set; }

        public Dto.Pantone pantone { get; set; }

        [Column(Name = "porcentajecubrimiento")]
        public Nullable<Single> porcentajecubrimiento { get; set; }

        [Column(Name = "derechoreverso")]
        public Nullable<bool> derechoreverso { get; set; }
    }
}
