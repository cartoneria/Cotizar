using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Dto
{
    public class Funcionalidad
    {
        public Nullable<byte> idfuncionalidad { get; set; }
        public string titulo { get; set; }
        public string mvccontroller { get; set; }
        public string mvcaction { get; set; }
        public Nullable<byte> idpadre { get; set; }
        public Nullable<bool> visible { get; set; }
        public Nullable<bool> activo { get; set; }
        public string uri { get; set; }
    }
}
