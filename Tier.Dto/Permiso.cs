﻿using System;
using System.Data.Linq.Mapping;

namespace Tier.Dto
{
    public partial class Permiso
    {
        [Column(Name = "rol_idrol")]
        public Nullable<Int16> rol_idrol { get; set; }

        [Column(Name = "rol_descrol")]
        public string rol_descrol { get; set; }

        [Column(Name = "funcionalidad_idfuncionalidad")]
        public Nullable<byte> funcionalidad_idfuncionalidad { get; set; }

        [Column(Name = "funcionalidad_descfuncionalidad")]
        public string funcionalidad_descfuncionalidad { get; set; }

        [Column(Name = "accion_idaccion")]
        public Nullable<Int16> accion_idaccion { get; set; }

        [Column(Name = "accion_descaccion")]
        public string accion_descaccion { get; set; }
    }
}
