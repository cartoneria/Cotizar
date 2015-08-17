using System;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;

namespace Tier.Dto
{
    //[DataContract]
    public class Asesor
    {
        //[DataMember]
        [Column(Name = "idasesor")]
        public Nullable<byte> idasesor { get; set; }

        //[DataMember]
        [Column(Name = "nombre")]
        public string nombre { get; set; }

        //[DataMember]
        [Column(Name = "comision")]
        public Nullable<decimal> comision { get; set; }

        //[DataMember]
        [Column(Name = "telefono")]
        public string telefono { get; set; }

        //[DataMember]
        [Column(Name = "correoelectronico")]
        public string correoelectronico { get; set; }

        //[DataMember]
        [Column(Name = "codigo")]
        public string codigo { get; set; }

        //[DataMember]
        [Column(Name = "empresa_idempresa")]
        public Nullable<byte> empresa_idempresa { get; set; }

        //[DataMember]
        [Column(Name = "activo")]
        public Nullable<bool> activo { get; set; }

        //[DataMember]
        [Column(Name = "fechacreacion")]
        public Nullable<DateTime> fechacreacion { get; set; }
    }
}
