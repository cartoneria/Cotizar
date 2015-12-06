using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Dto
{
    public class ProductoPegue
    {
        [Column(Name = "idproducto_pegue")]
        public Nullable<int> idproducto_pegue { get; set; }

        [Column(Name = "activo")]
        public Nullable<bool> activo { get; set; }

        [Column(Name = "fechacreacion")]
        public Nullable<DateTime> fechacreacion { get; set; }

        [Column(Name = "producto_idproducto")]
        public Nullable<int> producto_idproducto { get; set; }

        [Column(Name = "insumo_idinsumo")]
        public Nullable<int> insumo_idinsumo { get; set; }

        [Column(Name = "largopegue")]
        public Nullable<Single> largopegue { get; set; }

        [Column(Name = "anchopegue")]
        public Nullable<Single> anchopegue { get; set; }

        [Column(Name = "maquina_idmaquina")]
        public Nullable<short> maquina_idmaquina { get; set; }
    }
}
