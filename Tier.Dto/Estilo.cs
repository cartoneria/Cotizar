using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;

namespace Tier.Dto
{
    public partial class Estilo
    {
        #region [Propiedades]
        [Column(Name = "idestilo")]
        public Nullable<Int32> idestilo { get; set; }

        [Column(Name = "codigo")]
        public string codigo { get; set; }

        [Column(Name = "nombre")]
        public string nombre { get; set; }

        [Column(Name = "nombreimagen")]
        public string nombreimagen { get; set; }

        [Column(Name = "fechacreacion")]
        public Nullable<DateTime> fechacreacion { get; set; }

        [Column(Name = "activo")]
        public Nullable<bool> activo { get; set; }

        [Column(Name = "empresa_idempresa")]
        public Nullable<byte> empresa_idempresa { get; set; }

        [Column(Name = "empresa_descempresa")]
        public string empresa_descempresa { get; set; }

        public IEnumerable<Dto.EstiloPegue> pegues { get; set; }
        #endregion

        #region [Métodos]
        public void AsignarIdentificador()
        {
            foreach (Dto.EstiloPegue item in this.pegues)
            {
                item.estilo_idestilo = this.idestilo;
            }
        }
        #endregion
    }
}
