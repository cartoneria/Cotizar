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

        [Column(Name = "largominmp")]
        public Nullable<Single> largominmp { get; set; }

        [Column(Name = "largomaxmp")]
        public Nullable<Single> largomaxmp { get; set; }

        [Column(Name = "anchominmp")]
        public Nullable<Single> anchominmp { get; set; }

        [Column(Name = "anchomaxmp")]
        public Nullable<Single> anchomaxmp { get; set; }

        public Nullable<Single> largomp { get; set; }

        public Nullable<Single> anchomp { get; set; }

    }
}
