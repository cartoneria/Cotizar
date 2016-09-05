using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;

namespace Tier.Dto
{
    public partial class Rol
    {
        #region [Propiedades]
        [Column(Name = "idrol")]
        public Nullable<Int16> idrol { get; set; }

        [Column(Name = "nombre")]
        public string nombre { get; set; }

        [Column(Name = "descripcion")]
        public string descripcion { get; set; }

        [Column(Name = "activo")]
        public Nullable<bool> activo { get; set; }

        [Column(Name = "fechacreacion")]
        public Nullable<DateTime> fechacreacion { get; set; }

        public IEnumerable<Dto.Permiso> permisos { get; set; }
        #endregion

        #region [Métodos]
        public void AsignarIdentificador()
        {
            if (this.permisos != null && this.permisos.Count() > 0)
            {
                foreach (Dto.Permiso item in this.permisos)
                {
                    item.rol_idrol = this.idrol;
                }
            }
        }
        #endregion
    }
}
