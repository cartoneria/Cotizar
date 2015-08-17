using System;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;

namespace Tier.Dto
{
    //[DataContract]
    public class Permiso
    {
        //[DataMember]
        [Column(Name = "rol_idrol")]
        public Nullable<Int16> rol_idrol { get; set; }

        //[DataMember]
        [Column(Name = "funcionalidad_idfuncionalidad")]
        public Nullable<byte> funcionalidad_idfuncionalidad { get; set; }

        //[DataMember]
        [Column(Name = "accion_idaccion")]
        public Nullable<Int16> accion_idaccion { get; set; }
    }
}
