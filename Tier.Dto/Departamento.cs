using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
