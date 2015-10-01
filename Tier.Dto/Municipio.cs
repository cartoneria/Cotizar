using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Dto
{
    public partial class Municipio
    {
        [Column(Name = "idmunicipio")]
        public string idmunicipio { get; set; }

        [Column(Name = "nombre")]
        public string nombre { get; set; }

        [Column(Name = "activo")]
        public Nullable<bool> activo { get; set; }

        [Column(Name = "departamento_iddepartamento")]
        public string departamento_iddepartamento { get; set; }
    }
}
