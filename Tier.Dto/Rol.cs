using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Dto
{
    public class Rol
    {
        public Nullable<Int16> idrol { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }

        public IEnumerable<Dto.Permiso> permisos { get; set; }

        public Nullable<bool> activo { get; set; }
        public Nullable<DateTime> fechacreacion { get; set; }
    }
}
