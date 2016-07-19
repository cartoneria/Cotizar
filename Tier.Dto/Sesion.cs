using System.Collections.Generic;
using System.Data.Linq.Mapping;

namespace Tier.Dto
{
    public partial class Sesion
    {
        [Column(Name = "identificadorsesion")]
        public string identificadorsesion { get; set; }

        [Column(Name = "usuario")]
        public Dto.Usuario usuario { get; set; }

        [Column(Name = "rol")]
        public Dto.Rol rol { get; set; }

        [Column(Name = "empresa")]
        public Dto.Empresa empresa { get; set; }

        public IEnumerable<Dto.Funcionalidad> menu { get; set; }
    }
}
