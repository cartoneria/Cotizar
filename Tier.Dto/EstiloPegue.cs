using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Dto
{
    public class EstiloPegue
    {
        [Column(Name = "idestilo_pegue")]
        public Nullable<int> idestilo_pegue { get; set; }

        [Column(Name = "fechacreacion")]
        public Nullable<DateTime> fechacreacion { get; set; }

        [Column(Name = "activo")]
        public Nullable<bool> activo { get; set; }

        [Column(Name = "estilo_idestilo")]
        public Nullable<int> estilo_idestilo { get; set; }

        [Column(Name = "itemlista_iditemlista_tipopegue")]
        public Nullable<int> itemlista_iditemlista_tipopegue { get; set; }
    }
}
