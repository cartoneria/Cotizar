using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Dto
{
    public class Asesor
    {
        public Nullable<byte> idasesor { get; set; }
        public string nombre { get; set; }
        public Nullable<decimal> comision { get; set; }
        public string telefono { get; set; }
        public string correoelectronico { get; set; }
        public string codigo { get; set; }
        public Nullable<byte> empresa_idempresa { get; set; }
        public Nullable<bool> activo { get; set; }
        public Nullable<DateTime> fechacreacion { get; set; }
    }
}
