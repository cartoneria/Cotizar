using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;

namespace Tier.Dto
{
    public class Rol
    {
        Nullable<Int16> _idrol;
        [Column(Name = "idrol")]
        public Nullable<Int16> idrol
        {
            get
            {
                return this._idrol;
            }

            set
            {
                this._idrol = value;
                if (this.permisos != null && this.permisos.Count() > 0)
                {
                    foreach (Dto.Permiso item in this.permisos)
                    {
                        item.rol_idrol = this._idrol;
                    }
                }
            }
        }
        [Column(Name = "nombre")]
        public string nombre { get; set; }
        [Column(Name = "descripcion")]
        public string descripcion { get; set; }
        [Column(Name = "activo")]
        public Nullable<bool> activo { get; set; }
        [Column(Name = "fechacreacion")]
        public Nullable<DateTime> fechacreacion { get; set; }

        public IEnumerable<Dto.Permiso> permisos { get; set; }
    }
}
