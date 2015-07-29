using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Dto
{
    public class Accion
    {
        public Nullable<Int16> idaccion { get; set; }
        public string nombre { get; set; }
        public Nullable<bool> activo { get; set; }
    }
}
