using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Dto
{
    public partial class Pantone
    {
        [Column(Name = "idpantone")]
        public Nullable<int> idpantone { get; set; }

        [Column(Name = "nombre")]
        public string nombre { get; set; }

        [Column(Name = "hex")]
        public string hex { get; set; }

        [Column(Name = "r")]
        public Nullable<short> r { get; set; }

        [Column(Name = "g")]
        public Nullable<short> g { get; set; }

        [Column(Name = "b")]
        public Nullable<short> b { get; set; }

        [Column(Name = "valor")]
        public Nullable<Single> valor { get; set; }
    }
}
