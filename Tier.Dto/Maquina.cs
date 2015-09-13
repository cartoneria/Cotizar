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

        [Column(Name = "nombre")]
        public string nombre { get; set; }

        [Column(Name = "empresa_idempresa")]
        public Nullable<byte> empresa_idempresa { get; set; }

        [Column(Name = "itemlista_iditemlistas_tipo")]
        public Nullable<int> itemlista_iditemlistas_tipo { get; set; }

        [Column(Name = "areaancho")]
        public Nullable<Single> areaancho { get; set; }

        [Column(Name = "arealargo")]
        public Nullable<Single> arealargo { get; set; }

        [Column(Name = "turnos")]
        public Nullable<byte> turnos { get; set; }

        [Column(Name = "consumonominal")]
        public Nullable<Single> consumonominal { get; set; }

        [Column(Name = "largomaxmp")]
        public Nullable<Single> largomax { get; set; }

        [Column(Name = "anchomaxmp")]
        public Nullable<Single> largomin { get; set; }

        [Column(Name = "largominmp")]
        public Nullable<Single> anchomax { get; set; }

        [Column(Name = "anchominmp")]
        public Nullable<Single> anchomin { get; set; }

        [Column(Name = "fechacreacion")]
        public Nullable<DateTime> fechacreacion { get; set; }

        [Column(Name = "activo")]
        public Nullable<bool> activo { get; set; }

        [Column(Name = "dataperiodos")]
        public string dataperiodos { get; set; }

        [Column(Name = "dataproduccion")]
        public string dataproduccion { get; set; }
    }
}
