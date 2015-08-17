using System;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;

namespace Tier.Dto
{
    //[DataContract]
    public class Funcionalidad
    {
        //[DataMember]
        [Column(Name = "idfuncionalidad")]
        public Nullable<byte> idfuncionalidad { get; set; }

        //[DataMember]
        [Column(Name = "titulo")]
        public string titulo { get; set; }

        //[DataMember]
        [Column(Name = "mvccontroller")]
        public string mvccontroller { get; set; }

        //[DataMember]
        [Column(Name = "mvcaction")]
        public string mvcaction { get; set; }

        //[DataMember]
        [Column(Name = "idpadre")]
        public Nullable<byte> idpadre { get; set; }

        //[DataMember]
        [Column(Name = "visible")]
        public Nullable<bool> visible { get; set; }

        //[DataMember]
        [Column(Name = "activo")]
        public Nullable<bool> activo { get; set; }

        //[DataMember]
        [Column(Name = "uri")]
        public string uri { get; set; }
    }
}
