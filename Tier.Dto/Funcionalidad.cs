using System;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;

namespace Tier.Dto
{
    public class Funcionalidad
    {
        [Column(Name = "idfuncionalidad")]
        public Nullable<byte> idfuncionalidad { get; set; }

        [Column(Name = "titulo")]
        public string titulo { get; set; }

        [Column(Name = "mvccontroller")]
        public string mvccontroller { get; set; }

        [Column(Name = "mvcaction")]
        public string mvcaction { get; set; }

        [Column(Name = "idpadre")]
        public Nullable<byte> idpadre { get; set; }

        [Column(Name = "visible")]
        public Nullable<bool> visible { get; set; }

        [Column(Name = "activo")]
        public Nullable<bool> activo { get; set; }

        [Column(Name = "uri")]
        public string uri { get; set; }
    }
}
