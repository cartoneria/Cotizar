using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Dto
{
    public partial class MaquinaDatoPeriodico
    {
        [Column(Name = "idmaquinadatosperiodos")]
        public Nullable<int> idmaquinadatosperiodos { get; set; }

        [Column(Name = "periodo_idPeriodo")]
        public Nullable<int> periodo_idPeriodo { get; set; }

        [Column(Name = "avaluocomercial")]
        public Nullable<Single> avaluocomercial { get; set; }

        [Column(Name = "presupuesto")]
        public Nullable<Single> presupuesto { get; set; }

        [Column(Name = "tiempomtto")]
        public Nullable<Single> tiempomtto { get; set; }

        [Column(Name = "maquina_idmaquina")]
        public Nullable<short> maquina_idmaquina { get; set; }

        [Column(Name = "maquina_empresa_idempresa")]
        public Nullable<byte> maquina_empresa_idempresa { get; set; }

        [Column(Name = "activo")]
        public Nullable<bool> activo { get; set; }
    }
}
