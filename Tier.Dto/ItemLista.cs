using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Dto
{
    public class ItemLista
    {
        public int iditemlista { get; set; }
        public string nombre { get; set; }
        public byte grupo { get; set; }
        public bool activo { get; set; }
        public int idpadre { get; set; }
    }
}
