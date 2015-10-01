using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Dto
{
    public partial class EspectroPantone
    {
        [Column(Name = "idespectro_pantone")]
        public Nullable<int> idespectro_pantone { get; set; }

        [Column(Name = "activo")]
        public Nullable<bool> activo { get; set; }

        [Column(Name = "pantone_idpantone")]
        public Nullable<int> pantone_idpantone { get; set; }

        [Column(Name = "espectro_idespectro")]
        public Nullable<int> espectro_idespectro { get; set; }
    }
}
