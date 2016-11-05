using System;
using System.Data.Linq.Mapping;

namespace Tier.Dto
{
    public partial class MaquinaVariacionProduccion
    {
        [Column(Name = "idVariacion")]
        public Nullable<int> idVariacion { get; set; }

        [Column(Name = "produccioncant")]
        public Nullable<Single> produccioncant { get; set; }

        [Column(Name = "itemlista_iditemlista_produnimed")]
        public Nullable<int> itemlista_iditemlista_produnimed { get; set; }

        [Column(Name = "itemlista_iditemlista_descunimed")]
        public string itemlista_iditemlista_descunimed { get; set; }

        [Column(Name = "tiempoalistamiento")]
        public Nullable<Single> tiempoalistamiento { get; set; }

        [Column(Name = "maquina_idmaquina")]
        public Nullable<short> maquina_idmaquina { get; set; }

        [Column(Name = "maquina_empresa_idempresa")]
        public Nullable<byte> maquina_empresa_idempresa { get; set; }

        [Column(Name = "maquina_empresa_descempresa")]
        public string maquina_empresa_descempresa { get; set; }

        [Column(Name = "activo")]
        public Nullable<bool> activo { get; set; }

        [Column(Name = "nombre_variacion_produccion")]
        public string nombre_variacion_produccion { get; set; }
    }
}
