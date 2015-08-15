using System;
using System.Data.Linq.Mapping;

namespace Tier.Dto
{
    public class Maquina
    {
        [Column(Name = "idmaquina")]
        public Nullable<Int16> idmaquina { get; set; }
        [Column(Name = "codigo")]
        public string codigo { get; set; }
        [Column(Name = "nombre")]
        public string nombre { get; set; }
        [Column(Name = "descripcion")]
        public string descripcion { get; set; }
        [Column(Name = "largomax")]
        public Nullable<decimal> largomax { get; set; }
        [Column(Name = "largomin")]
        public Nullable<decimal> largomin { get; set; }
        [Column(Name = "anchomax")]
        public Nullable<decimal> anchomax { get; set; }
        [Column(Name = "anchomin")]
        public Nullable<decimal> anchomin { get; set; }
        [Column(Name = "fechacreacion")]
        public Nullable<DateTime> fechacreacion { get; set; }
        [Column(Name = "activo")]
        public Nullable<bool> activo { get; set; }
        [Column(Name = "empresa_idempresa")]
        public Nullable<byte> empresa_idempresa { get; set; }
        [Column(Name = "itemlista_iditemlistas_tipo")]
        public Nullable<int> itemlista_iditemlistas_tipo { get; set; }
    }
}
