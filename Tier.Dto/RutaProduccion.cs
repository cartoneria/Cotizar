using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Dto
{
    public class RutaProduccion
    {
        [Column(Name = "idvariacion")]
        public Nullable<int> idvariacion { get; set; }

        [Column(Name = "nombre")]
        public string nombre { get; set; }

        [Column(Name = "idtipomaquina")]
        public Nullable<int> idtipomaquina { get; set; }

        [Column(Name = "idempresa")]
        public Nullable<byte> idempresa { get; set; }
    }
}
