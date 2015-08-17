using System;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;

namespace Tier.Dto
{
    //[DataContract]
    public class Empresa
    {
        //[DataMember]
        [Column(Name = "idempresa")]
        public Nullable<byte> idempresa { get; set; }

        //[DataMember]
        [Column(Name = "razonsocial")]
        public string razonsocial { get; set; }

        //[DataMember]
        [Column(Name = "nit")]
        public string nit { get; set; }

        //[DataMember]
        [Column(Name = "direccion")]
        public string direccion { get; set; }

        //[DataMember]
        [Column(Name = "telefono")]
        public string telefono { get; set; }

        //[DataMember]
        [Column(Name = "representantelegal")]
        public string representantelegal { get; set; }

        //[DataMember]
        [Column(Name = "activo")]
        public Nullable<bool> activo { get; set; }

        //[DataMember]
        [Column(Name = "urilogo")]
        public string urilogo { get; set; }
    }
}
