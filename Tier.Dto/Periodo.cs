using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Dto
{
    public partial class Periodo
    {
        [Column(Name = "idPeriodo")]
        public Nullable<int> idPeriodo { get; set; }

        [Column(Name = "nombre")]
        public string nombre { get; set; }

        [Column(Name = "fechainicio")]
        public Nullable<DateTime> fechainicio { get; set; }

        [Column(Name = "fechafin")]
        public Nullable<DateTime> fechafin { get; set; }

        [Column(Name = "vigente")]
        public Nullable<bool> vigente { get; set; }
    }
}
