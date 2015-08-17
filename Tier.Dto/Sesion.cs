using System;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;

namespace Tier.Dto
{
    //[DataContract]
    public class Sesion
    {
        //[DataMember]
        [Column(Name = "identificadorsesion")]
        public string identificadorsesion { get; set; }

        //[DataMember]
        [Column(Name = "usuario")]
        public Dto.Usuario usuario { get; set; }

        //[DataMember]
        [Column(Name = "rol")]
        public Dto.Rol rol { get; set; }

        //[DataMember]
        [Column(Name = "empresa")]
        public Dto.Empresa empresa { get; set; }
    }
}
