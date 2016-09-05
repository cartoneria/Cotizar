using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;

namespace Tier.Dto
{
    public partial class Proveedor
    {
        #region [Propiedades]
        [Column(Name = "idproveedor")]
        public Nullable<int> idproveedor { get; set; }

        [Column(Name = "nombre")]
        public string nombre { get; set; }

        [Column(Name = "fechacreacion")]
        public Nullable<DateTime> fechacreacion { get; set; }

        [Column(Name = "activo")]
        public Nullable<bool> activo { get; set; }

        [Column(Name = "empresa_idempresa")]
        public Nullable<byte> empresa_idempresa { get; set; }

        public IEnumerable<Dto.ProveedorLinea> lineas { get; set; }
        #endregion

        #region [Métodos]
        public void AsignarIdentificador()
        {
            if (this.lineas != null && this.lineas.Count() > 0)
            {
                foreach (Dto.ProveedorLinea item in this.lineas)
                {
                    item.proveedor_idproveedor = this.idproveedor;
                }
            }
        }
        #endregion
    }
}
