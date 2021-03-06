﻿using System;
using System.Data.Linq.Mapping;

namespace Tier.Dto
{
    public partial class Insumo
    {
        [Column(Name = "idinsumo")]
        public Nullable<int> idinsumo { get; set; }

        [Column(Name = "proveedor_linea_idproveedor_linea")]
        public Nullable<int> proveedor_linea_idproveedor_linea { get; set; }

        [Column(Name = "proveedor_linea_descproveedor_linea")]
        public string proveedor_linea_descproveedor_linea { get; set; }

        [Column(Name = "proveedor_linea_proveedor_idproveedor")]
        public Nullable<int> proveedor_linea_proveedor_idproveedor { get; set; }

        [Column(Name = "proveedor_linea_proveedor_descproveedor")]
        public string proveedor_linea_proveedor_descproveedor { get; set; }

        [Column(Name = "ancho")]
        public Nullable<Single> ancho { get; set; }

        [Column(Name = "itemlista_iditemlista_tipo")]
        public Nullable<int> itemlista_iditemlista_tipo { get; set; }

        [Column(Name = "itemlista_iditemlista_desctipo")]
        public string itemlista_iditemlista_desctipo { get; set; }

        [Column(Name = "calibre")]
        public Nullable<Single> calibre { get; set; }

        [Column(Name = "itemlista_iditemlista_unimedcomp")]
        public Nullable<int> itemlista_iditemlista_unimedcomp { get; set; }

        [Column(Name = "itemlista_iditemlista_descunimedcomp")]
        public string itemlista_iditemlista_descunimedcomp { get; set; }

        [Column(Name = "valor")]
        public Nullable<Single> valor { get; set; }

        [Column(Name = "factorrendimiento")]
        public Nullable<Single> factorrendimiento { get; set; }

        [Column(Name = "itemlista_iditemlista_unimedrendi")]
        public Nullable<int> itemlista_iditemlista_unimedrendi { get; set; }

        [Column(Name = "itemlista_iditemlista_descunimedrendi")]
        public string itemlista_iditemlista_descunimedrendi { get; set; }

        [Column(Name = "observaciones")]
        public string observaciones { get; set; }

        [Column(Name = "fechacreacion")]
        public Nullable<DateTime> fechacreacion { get; set; }

        [Column(Name = "activo")]
        public Nullable<bool> activo { get; set; }

        [Column(Name = "nombre")]
        public string nombre { get; set; }

        [Column(Name = "valorflete")]
        public Nullable<Single> valorflete { get; set; }

        [Column(Name = "empresa_idempresa")]
        public Nullable<byte> empresa_idempresa { get; set; }

        [Column(Name = "empresa_descempresa")]
        public string empresa_descempresa { get; set; }

        [Column(Name = "conversionflete")]
        public Nullable<Single> conversionflete { get; set; }
    }
}
