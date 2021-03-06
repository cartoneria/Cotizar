﻿using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;

namespace Tier.Dto
{
    public partial class Maquina
    {
        #region [Propiedades]
        [Column(Name = "idmaquina")]
        public Nullable<Int16> idmaquina { get; set; }

        [Column(Name = "codigo")]
        public string codigo { get; set; }

        [Column(Name = "nombre")]
        public string nombre { get; set; }

        [Column(Name = "empresa_idempresa")]
        public Nullable<byte> empresa_idempresa { get; set; }

        [Column(Name = "empresa_descempresa")]
        public string empresa_descempresa { get; set; }

        [Column(Name = "itemlista_iditemlistas_tipo")]
        public Nullable<int> itemlista_iditemlistas_tipo { get; set; }

        [Column(Name = "itemlista_iditemlistas_desctipo")]
        public string itemlista_iditemlistas_desctipo { get; set; }

        [Column(Name = "areaancho")]
        public Nullable<Single> areaancho { get; set; }

        [Column(Name = "arealargo")]
        public Nullable<Single> arealargo { get; set; }

        [Column(Name = "turnos")]
        public Nullable<Single> turnos { get; set; }

        [Column(Name = "consumonominal")]
        public Nullable<Single> consumonominal { get; set; }

        [Column(Name = "largomaxmp")]
        public Nullable<Single> largomaxmp { get; set; }

        [Column(Name = "largominmp")]
        public Nullable<Single> largominmp { get; set; }

        [Column(Name = "anchomaxmp")]
        public Nullable<Single> anchomaxmp { get; set; }

        [Column(Name = "anchominmp")]
        public Nullable<Single> anchominmp { get; set; }

        [Column(Name = "fechacreacion")]
        public Nullable<DateTime> fechacreacion { get; set; }

        [Column(Name = "activo")]
        public Nullable<bool> activo { get; set; }

        [Column(Name = "numerotintas")]
        public Nullable<byte> numerotintas { get; set; }

        [Column(Name = "valorplancha")]
        public Nullable<Single> valorplancha { get; set; }

        public IEnumerable<Dto.MaquinaVariacionProduccion> VariacionesProduccion { get; set; }

        public IEnumerable<Dto.MaquinaDatoPeriodico> DatosPeriodicos { get; set; }
        #endregion

        #region [Métodos]
        public void AsignarIdentificador()
        {
            if (this.DatosPeriodicos != null && this.DatosPeriodicos.Count() > 0)
            {
                foreach (Dto.MaquinaDatoPeriodico item in this.DatosPeriodicos)
                {
                    item.maquina_empresa_idempresa = this.empresa_idempresa;
                    item.maquina_idmaquina = this.idmaquina;
                }
            }

            if (this.VariacionesProduccion != null && this.VariacionesProduccion.Count() > 0)
            {
                foreach (Dto.MaquinaVariacionProduccion item in this.VariacionesProduccion)
                {
                    item.maquina_empresa_idempresa = this.empresa_idempresa;
                    item.maquina_idmaquina = this.idmaquina;
                }
            }
        }
        #endregion
    }
}
