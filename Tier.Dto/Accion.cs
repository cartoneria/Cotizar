using System;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;

namespace Tier.Dto
{
    //[DataContract]
    public class Accion
    {
        ////[DataMember]
        [Column(Name = "idaccion")]
        public Nullable<Int16> idaccion { get; set; }

        //[DataMember]
        [Column(Name = "nombre")]
        public string nombre { get; set; }

        //[DataMember]
        [Column(Name = "activo")]
        public Nullable<bool> activo { get; set; }
    }
}
