using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Dto
{
    public class Sesion
    {
        public string identificadorsesion { get; set; }
        public Dto.Usuario usuario { get; set; }
        public Dto.Rol rol { get; set; }
        public Dto.Empresa empresa { get; set; }
    }
}
