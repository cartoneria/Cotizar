using System;
using System.Data.Linq.Mapping;

namespace Tier.Dto
{
    public class Accion
    {
        [Column(Name = "idaccion")]
        public Nullable<Int16> idaccion { get; set; }
        [Column(Name = "nombre")]
        public string nombre { get; set; }
        [Column(Name = "activo")]
        public Nullable<bool> activo { get; set; }
    }
}
