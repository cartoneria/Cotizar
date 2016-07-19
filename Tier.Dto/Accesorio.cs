using System;
using System.Data.Linq.Mapping;

namespace Tier.Dto
{
    public class Accesorio
    {
        [Column(Name = "idaccesorio")]
        public Nullable<int> idaccesorio { get; set; }

        [Column(Name = "activo")]
        public Nullable<bool> activo { get; set; }

        [Column(Name = "fechacreacion")]
        public Nullable<DateTime> fechacreacion { get; set; }

        [Column(Name = "nombre")]
        public string nombre { get; set; }

        [Column(Name = "observaciones")]
        public string observaciones { get; set; }

        [Column(Name = "observacionesproduccion")]
        public string observacionesproduccion { get; set; }

        [Column(Name = "codigo")]
        public string codigo { get; set; }

        [Column(Name = "precio")]
        public Nullable<Single> precio { get; set; }

        [Column(Name = "costomanoobra")]
        public Nullable<Single> costomanoobra { get; set; }

        [Column(Name = "empresa_idempresa")]
        public Nullable<byte> empresa_idempresa { get; set; }
    }
}
