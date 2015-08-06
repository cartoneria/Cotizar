using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Dto
{
    public class Empresa
    {
        public Nullable<byte> idempresa { get; set; }
        public string razonsocial { get; set; }
        public string nit { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string representantelegal { get; set; }
        public Nullable<bool> activo { get; set; }
    }
}
