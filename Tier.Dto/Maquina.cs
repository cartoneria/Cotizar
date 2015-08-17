using System;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;

namespace Tier.Dto
{
    //[DataContract]
    public class Maquina
    {
        //[DataMember]
        [Column(Name = "idmaquina")]
        public Nullable<Int16> idmaquina { get; set; }

        //[DataMember]
        [Column(Name = "codigo")]
        public string codigo { get; set; }

        //[DataMember]
        [Column(Name = "nombre")]
        public string nombre { get; set; }

        //[DataMember]
        [Column(Name = "descripcion")]
        public string descripcion { get; set; }

        //[DataMember]
        [Column(Name = "largomax")]
        public Nullable<decimal> largomax { get; set; }

        //[DataMember]
        [Column(Name = "largomin")]
        public Nullable<decimal> largomin { get; set; }

        //[DataMember]
        [Column(Name = "anchomax")]
        public Nullable<decimal> anchomax { get; set; }

        //[DataMember]
        [Column(Name = "anchomin")]
        public Nullable<decimal> anchomin { get; set; }

        //[DataMember]
        [Column(Name = "fechacreacion")]
        public Nullable<DateTime> fechacreacion { get; set; }

        //[DataMember]
        [Column(Name = "activo")]
        public Nullable<bool> activo { get; set; }

        //[DataMember]
        [Column(Name = "empresa_idempresa")]
        public Nullable<byte> empresa_idempresa { get; set; }

        //[DataMember]
        [Column(Name = "itemlista_iditemlistas_tipo")]
        public Nullable<int> itemlista_iditemlistas_tipo { get; set; }
    }
}
