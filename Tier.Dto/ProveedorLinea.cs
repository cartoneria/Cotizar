﻿using System;
using System.Data.Linq.Mapping;

namespace Tier.Dto
{
    public partial class ProveedorLinea
    {
        [Column(Name = "idproveedor_linea")]
        public Nullable<int> idproveedor_linea { get; set; }

        [Column(Name = "nombre")]
        public string nombre { get; set; }

        [Column(Name = "fechacreacion")]
        public Nullable<DateTime> fechacreacion { get; set; }

        [Column(Name = "activo")]
        public Nullable<bool> activo { get; set; }

        [Column(Name = "proveedor_idproveedor")]
        public Nullable<int> proveedor_idproveedor { get; set; }

        [Column(Name = "proveedor_descproveedor")]
        public string proveedor_descproveedor { get; set; }
    }
}
