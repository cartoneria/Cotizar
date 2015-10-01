using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Dto
{
    public partial class Troquel
    {
        [Column(Name = "idtroquel")]
        public Nullable<int> idtroquel { get; set; }

        [Column(Name = "codigo")]
        public string codigo { get; set; }

        [Column(Name = "referencia")]
        public string referencia { get; set; }

        [Column(Name = "largo")]
        public Nullable<Single> largo { get; set; }

        [Column(Name = "ancho")]
        public Nullable<Single> ancho { get; set; }

        [Column(Name = "alto")]
        public Nullable<Single> alto { get; set; }

        [Column(Name = "cortea")]
        public Nullable<Single> cortea { get; set; }

        [Column(Name = "corteb")]
        public Nullable<Single> corteb { get; set; }

        [Column(Name = "cabida")]
        public Nullable<Single> cabida { get; set; }

        [Column(Name = "acetatoa")]
        public Nullable<Single> acetatoa { get; set; }

        [Column(Name = "acetatob")]
        public Nullable<Single> acetatob { get; set; }

        [Column(Name = "observaciones")]
        public string observaciones { get; set; }

        [Column(Name = "fechacreacion")]
        public Nullable<DateTime> fechacreacion { get; set; }

        [Column(Name = "activo")]
        public Nullable<bool> activo { get; set; }
    }
}
