using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Dto
{
    public partial class Insumo
    {
        [Column(Name = "idinsumo")]
        public Nullable<int> idinsumo { get; set; }

        [Column(Name = "proveedor_linea_idproveedor_linea")]
        public Nullable<int> proveedor_linea_idproveedor_linea { get; set; }

        [Column(Name = "proveedor_linea_proveedor_idproveedor")]
        public Nullable<int> proveedor_linea_proveedor_idproveedor { get; set; }

        [Column(Name = "ancho")]
        public Nullable<Single> ancho { get; set; }

        [Column(Name = "itemlista_iditemlista_tipo")]
        public Nullable<int> itemlista_iditemlista_tipo { get; set; }

        [Column(Name = "calibre")]
        public Nullable<Single> calibre { get; set; }

        [Column(Name = "itemlista_iditemlista_unimedcomp")]
        public Nullable<int> itemlista_iditemlista_unimedcomp { get; set; }

        [Column(Name = "valor")]
        public Nullable<Single> valor { get; set; }

        [Column(Name = "factorrendimiento")]
        public Nullable<Single> factorrendimiento { get; set; }

        [Column(Name = "itemlista_iditemlista_unimedrendi")]
        public Nullable<int> itemlista_iditemlista_unimedrendi { get; set; }

        [Column(Name = "observaciones")]
        public string observaciones { get; set; }

        [Column(Name = "fechacreacion")]
        public Nullable<DateTime> fechacreacion { get; set; }

        [Column(Name = "activo")]
        public Nullable<bool> activo { get; set; }
    }
}
