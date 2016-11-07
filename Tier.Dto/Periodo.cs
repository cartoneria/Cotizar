using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;

namespace Tier.Dto
{
    public partial class Periodo
    {
        #region [Propiedades]
        [Column(Name = "idPeriodo")]
        public Nullable<int> idPeriodo { get; set; }

        [Column(Name = "nombre")]
        public string nombre { get; set; }

        [Column(Name = "fechainicio")]
        public Nullable<DateTime> fechainicio { get; set; }

        [Column(Name = "fechafin")]
        public Nullable<DateTime> fechafin { get; set; }

        [Column(Name = "vigente")]
        public Nullable<bool> vigente { get; set; }

        [Column(Name = "empresa_idempresa")]
        public Nullable<byte> empresa_idempresa { get; set; }

        [Column(Name = "empresa_descempresa")]
        public string empresa_descempresa { get; set; }

        [Column(Name = "impuestoicacree")]
        public Nullable<Single> impuestoicacree { get; set; }

        [Column(Name = "porcenfinanciacion")]
        public Nullable<Single> porcenfinanciacion { get; set; }

        [Column(Name = "porcenalzageneral")]
        public Nullable<Single> porcenalzageneral { get; set; }

        [Column(Name = "gasto")]
        public Nullable<Single> gasto { get; set; }

        [Column(Name = "utilidad")]
        public Nullable<Single> utilidad { get; set; }

        public IEnumerable<Dto.MaquinaDatoPeriodico> centros { get; set; }

        public IEnumerable<Dto.Parametro> parametros { get; set; }
        #endregion

        #region [Métodos]
        public void AsignarIdentificador()
        {
            if (this.centros != null && this.centros.Count() > 0)
            {
                foreach (Dto.MaquinaDatoPeriodico item in this.centros)
                {
                    item.periodo_idPeriodo = this.idPeriodo;
                }
            }

            if (this.parametros != null && this.parametros.Count() > 0)
            {
                foreach (Dto.Parametro item in this.parametros)
                {
                    item.periodo_idPeriodo = this.idPeriodo;
                }
            }
        }
        #endregion
    }
}
