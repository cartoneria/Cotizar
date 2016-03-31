using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Dto
{
    public class Cotizacion
    {
        Nullable<int> _idcotizacion;

        [Column(Name = "idcotizacion")]
        public Nullable<int> idcotizacion
        {
            get
            {
                return this._idcotizacion;
            }

            set
            {
                this._idcotizacion = value;
                if (this.detalle != null && this.detalle.Count() > 0)
                {
                    foreach (Dto.CotizacionDetalle item in this.detalle)
                    {
                        item.cotizacion_idcotizacion = this._idcotizacion;
                    }
                }
            }
        }

        [Column(Name = "activo")]
        public Nullable<bool> activo { get; set; }

        [Column(Name = "fechacreacion")]
        public Nullable<DateTime> fechacreacion { get; set; }

        [Column(Name = "cliente_idcliente")]
        public Nullable<int> cliente_idcliente { get; set; }

        [Column(Name = "periodo_idPeriodo")]
        public Nullable<int> periodo_idPeriodo { get; set; }

        [Column(Name = "observaciones")]
        public string observaciones { get; set; }

        [Column(Name = "costosplancha")]
        public Nullable<Single> costosplancha { get; set; }

        [Column(Name = "costostroqueles")]
        public Nullable<Single> costostroqueles { get; set; }

        [Column(Name = "itemlista_iditemlista_estado")]
        public Nullable<int> itemlista_iditemlista_estado { get; set; }

        public IEnumerable<CotizacionDetalle> detalle { get; set; }
    }
}
