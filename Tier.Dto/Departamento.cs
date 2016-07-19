using System;
using System.Data.Linq.Mapping;

namespace Tier.Dto
{
    public partial class Departamento
    {
        [Column(Name = "iddepartamento")]
        public string iddepartamento { get; set; }

        [Column(Name = "nombre")]
        public string nombre { get; set; }

        [Column(Name = "activo")]
        public Nullable<bool> activo { get; set; }
    }
}
