using System;
using System.Data.Linq.Mapping;

namespace Tier.Dto
{
    public partial class TroquelVentana
    {
        [Column(Name = "idtroquel_ventana")]
        public Nullable<int> idtroquel_ventana { get; set; }

        [Column(Name = "largo")]
        public Nullable<Single> largo { get; set; }

        [Column(Name = "alto")]
        public Nullable<Single> alto { get; set; }

        [Column(Name = "activo")]
        public Nullable<bool> activo { get; set; }

        [Column(Name = "troquel_idtroquel")]
        public Nullable<int> troquel_idtroquel { get; set; }
    }
}
