using System;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;

namespace Tier.Dto
{
    public partial class Maquina
    {
        [Column(Name = "idmaquina")]
        public Nullable<Int16> idmaquina { get; set; }

        [Column(Name = "codigo")]
        public string codigo { get; set; }

        [Column(Name = "empresa_idempresa")]
        public Nullable<byte> empresa_idempresa { get; set; }

        [Column(Name = "itemlista_iditemlistas_tipo")]
        public Nullable<int> itemlista_iditemlistas_tipo { get; set; }

        [Column(Name = "nombre")]
        public string nombre { get; set; }

        [Column(Name = "avaluocomercial")]
        public Nullable<Single> avaluocomercial { get; set; }

        [Column(Name = "areaancho")]
        public Nullable<Single> areaancho { get; set; }

        [Column(Name = "arealargo")]
        public Nullable<Single> arealargo { get; set; }

        [Column(Name = "presupuesto")]
        public Nullable<Single> presupuesto { get; set; }

        [Column(Name = "produccionhora")]
        public Nullable<short> produccionhora { get; set; }

        [Column(Name = "itemlista_iditemlista_unimed")]
        public Nullable<int> itemlista_iditemlista_unimed { get; set; }

        [Column(Name = "tiempoalistamiento")]
        public Nullable<Single> tiempoalistamiento { get; set; }

        [Column(Name = "turnos")]
        public Nullable<byte> turnos { get; set; }

        [Column(Name = "consumonominal")]
        public Nullable<Single> consumonominal { get; set; }

        [Column(Name = "largomax")]
        public Nullable<Single> largomax { get; set; }

        [Column(Name = "largomin")]
        public Nullable<Single> largomin { get; set; }

        [Column(Name = "anchomax")]
        public Nullable<Single> anchomax { get; set; }

        [Column(Name = "anchomin")]
        public Nullable<Single> anchomin { get; set; }

        [Column(Name = "fechacreacion")]
        public Nullable<DateTime> fechacreacion { get; set; }

        [Column(Name = "activo")]
        public Nullable<bool> activo { get; set; }
    }
}
