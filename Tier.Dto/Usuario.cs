using System;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;


namespace Tier.Dto
{
    //[DataContract]
    public class Usuario
    {
        //[DataMember]
        [Column(Name = "idusuario")]
        public Nullable<Int16> idusuario { get; set; }

        //[DataMember]
        [Column(Name = "usuario")]
        public string usuario { get; set; }

        //[DataMember]
        [Column(Name = "clave")]
        public string clave { get; set; }

        //[DataMember]
        [Column(Name = "nombrecompleto")]
        public string nombrecompleto { get; set; }

        //[DataMember]
        [Column(Name = "correoelectronico")]
        public string correoelectronico { get; set; }

        //[DataMember]
        [Column(Name = "celular")]
        public string celular { get; set; }

        //[DataMember]
        [Column(Name = "fechacreacion")]
        public Nullable<DateTime> fechacreacion { get; set; }

        //[DataMember]
        [Column(Name = "activo")]
        public Nullable<bool> activo { get; set; }

        //[DataMember]
        [Column(Name = "cargo")]
        public string cargo { get; set; }

        //[DataMember]
        [Column(Name = "rol_idrol")]
        public Nullable<Int16> rol_idrol { get; set; }

        //[DataMember]
        [Column(Name = "empresa_idempresa")]
        public Nullable<byte> empresa_idempresa { get; set; }

        //[DataMember]
        [Column(Name = "itemlista_iditemlistas_area")]
        public Nullable<int> itemlista_iditemlistas_area { get; set; }
    }
}
