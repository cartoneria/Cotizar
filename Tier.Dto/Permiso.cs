using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Dto
{
    public class Permiso
    {
        public Nullable<Int16> rol_idrol { get; set; }
        public Nullable<byte> funcionalidad_idfuncionalidad { get; set; }
        public Nullable<Int16> accion_idaccion { get; set; }
    }
}
