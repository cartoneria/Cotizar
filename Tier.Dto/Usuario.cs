using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Dto
{
    public class Usuario
    {
        public Nullable<Int16> idusuario { get; set; }
        public string usuario { get; set; }
        public string clave { get; set; }
        public string nombrecompleto { get; set; }
        public string correoelectronico { get; set; }
        public string celular { get; set; }
        public Nullable<DateTime> fechacreacion { get; set; }
        public Nullable<bool> activo { get; set; }
        public string cargo { get; set; }
        public Nullable<Int16> rol_idrol { get; set; }
        public Nullable<byte> empresa_idempresa { get; set; }
        public Nullable<int> itemlista_iditemlistas_area { get; set; }
    }
}
