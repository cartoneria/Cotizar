using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Dto
{
    public partial class Parametro
    {
        [Column(Name = "idparametro")]
        public Nullable<int> idparametro { get; set; }

        [Column(Name = "periodo_idPeriodo")]
        public Nullable<int> periodo_idPeriodo { get; set; }

        [Column(Name = "nombre")]
        public string nombre { get; set; }

        [Column(Name = "tipo")]
        public Nullable<byte> tipo { get; set; }

        [Column(Name = "valortexto")]
        public string valortexto { get; set; }

        [Column(Name = "valornumero")]
        public Nullable<Single> valornumero { get; set; }

        [Column(Name = "valorfecha")]
        public Nullable<DateTime> valorfecha { get; set; }

        [Column(Name = "valorboleano")]
        public Nullable<bool> valorboleano { get; set; }
    }
}
