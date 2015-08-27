using System;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;

namespace Tier.Dto
{
    public partial class Empresa
    {
        [Column(Name = "idempresa")]
        public Nullable<byte> idempresa { get; set; }

        [Column(Name = "razonsocial")]
        public string razonsocial { get; set; }

        [Column(Name = "nit")]
        public string nit { get; set; }

        [Column(Name = "direccion")]
        public string direccion { get; set; }

        [Column(Name = "telefono")]
        public string telefono { get; set; }

        [Column(Name = "representantelegal")]
        public string representantelegal { get; set; }

        [Column(Name = "activo")]
        public Nullable<bool> activo { get; set; }

        [Column(Name = "urilogo")]
        public string urilogo { get; set; }
    }
}
