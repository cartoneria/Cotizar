using System;
using System.Data.Linq.Mapping;

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
        
        public Nullable<Single> largomp { get; set; }

        public Nullable<Single> anchomp { get; set; }

    }
}
