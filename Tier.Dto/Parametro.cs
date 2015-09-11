using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Dto
{
    public partial class Parametro
    {
        public Nullable<int> idparametro { get; set; }

        public Nullable<byte> periodo_idPeriodo { get; set; }

        public string nombre { get; set; }

        public Nullable<byte> tipo { get; set; }

        public string valortexto { get; set; }

        public Nullable<Single> valornumero { get; set; }

        public Nullable<DateTime> valorfecha { get; set; }

        public Nullable<bool> valorboleano { get; set; }
    }
}
