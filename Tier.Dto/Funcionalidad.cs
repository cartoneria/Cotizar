using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;

namespace Tier.Dto
{
    public partial class Funcionalidad
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

        [Column(Name = "icono")]
        public string icono { get; set; }

        public IEnumerable<Dto.Funcionalidad> funcionalidades { get; set; }

        public IEnumerable<Dto.Accion> acciones { get; set; }
    }
}
