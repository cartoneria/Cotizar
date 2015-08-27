using System;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;

namespace Tier.Dto
{
    public partial class Asesor
    {
        [Column(Name = "idasesor")]
        public Nullable<byte> idasesor { get; set; }

        [Column(Name = "nombre")]
        public string nombre { get; set; }

        [Column(Name = "comision")]
        public Nullable<decimal> comision { get; set; }

        [Column(Name = "telefono")]
        public string telefono { get; set; }

        [Column(Name = "correoelectronico")]
        public string correoelectronico { get; set; }

        [Column(Name = "codigo")]
        public string codigo { get; set; }

        [Column(Name = "empresa_idempresa")]
        public Nullable<byte> empresa_idempresa { get; set; }

        [Column(Name = "activo")]
        public Nullable<bool> activo { get; set; }

        [Column(Name = "fechacreacion")]
        public Nullable<DateTime> fechacreacion { get; set; }
    }
}
