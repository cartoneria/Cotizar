using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Dto
{
    public class Maquina
    {
        public Nullable<Int16> idmaquina { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public Nullable<decimal> largomax { get; set; }
        public Nullable<decimal> largomin { get; set; }
        public Nullable<decimal> anchomax { get; set; }
        public Nullable<decimal> anchomin { get; set; }
        public Nullable<DateTime> fechacreacion { get; set; }
        public Nullable<bool> activo { get; set; }
        public Nullable<byte> empresa_idempresa { get; set; }
        public Nullable<int> itemlista_iditemlistas_tipo { get; set; }
    }
}
