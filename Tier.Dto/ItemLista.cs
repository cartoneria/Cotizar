using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;

namespace Tier.Dto
{
    public class ItemLista
    {
        [Column(Name = "iditemlista")]
        public Nullable<int> iditemlista { get; set; }
        [Column(Name = "nombre")]
        public string nombre { get; set; }
        [Column(Name = "grupo")]
        public Nullable<byte> grupo { get; set; }
        [Column(Name = "activo")]
        public Nullable<bool> activo { get; set; }
        [Column(Name = "idpadre")]
        public Nullable<int> idpadre { get; set; }

        public IEnumerable<ItemLista> items { get; set; }
    }
}
