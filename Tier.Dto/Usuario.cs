using System;
using System.Data.Linq.Mapping;


namespace Tier.Dto
{
    public class Usuario
    {
        [Column(Name = "idusuario")]
        public Nullable<Int16> idusuario { get; set; }
        [Column(Name = "usuario")]
        public string usuario { get; set; }
        [Column(Name = "clave")]
        public string clave { get; set; }
        [Column(Name = "nombrecompleto")]
        public string nombrecompleto { get; set; }
        [Column(Name = "correoelectronico")]
        public string correoelectronico { get; set; }
        [Column(Name = "celular")]
        public string celular { get; set; }
        [Column(Name = "fechacreacion")]
        public Nullable<DateTime> fechacreacion { get; set; }
        [Column(Name = "activo")]
        public Nullable<bool> activo { get; set; }
        [Column(Name = "cargo")]
        public string cargo { get; set; }
        [Column(Name = "rol_idrol")]
        public Nullable<Int16> rol_idrol { get; set; }
        [Column(Name = "empresa_idempresa")]
        public Nullable<byte> empresa_idempresa { get; set; }
        [Column(Name = "itemlista_iditemlistas_area")]
        public Nullable<int> itemlista_iditemlistas_area { get; set; }
    }
}
