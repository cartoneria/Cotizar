using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Dto
{
    public class ItemLista
    {
        public Nullable<int> iditemlista { get; set; }
        public string nombre { get; set; }
        public Nullable<byte> grupo { get; set; }
        public Nullable<bool> activo { get; set; }
        public Nullable<int> idpadre { get; set; }

        public IEnumerable<ItemLista> items { get; set; }
    }
}
