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

        [Column(Name = "maquinavariprod_idVariacion_rutapegue")]
        public Nullable<int> maquinavariprod_idVariacion_rutapegue { get; set; }

        [Column(Name = "maquinavariprod_idVariacion_descrutapegue")]
        public string maquinavariprod_idVariacion_descrutapegue { get; set; }

        [Column(Name = "cantidad")]
        public Nullable<byte> cantidad { get; set; }
    }
}
