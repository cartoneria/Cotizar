using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Dto
{
    public class Rol
    {
        Nullable<Int16> _idrol;
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
        public string nombre { get; set; }
        public string descripcion { get; set; }

        public IEnumerable<Dto.Permiso> permisos { get; set; }

        public Nullable<bool> activo { get; set; }
        public Nullable<DateTime> fechacreacion { get; set; }
    }
}
