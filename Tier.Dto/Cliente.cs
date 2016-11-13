using System;
using System.Data.Linq.Mapping;

namespace Tier.Dto
{
    public partial class Cliente
    {
        [Column(Name = "idcliente")]
        public Nullable<int> idcliente { get; set; }

        [Column(Name = "identificacion")]
        public string identificacion { get; set; }

        [Column(Name = "itemlista_iditemlista_tipoidenti")]
        public Nullable<int> itemlista_iditemlista_tipoidenti { get; set; }

        [Column(Name = "itemlista_iditemlista_desctipoidenti")]
        public string itemlista_iditemlista_desctipoidenti { get; set; }

        [Column(Name = "nombre")]
        public string nombre { get; set; }

        [Column(Name = "direccion")]
        public string direccion { get; set; }

        [Column(Name = "municipio_idmunicipio")]
        public string municipio_idmunicipio { get; set; }

        [Column(Name = "municipio_desmunicipio")]
        public string municipio_desmunicipio { get; set; }

        [Column(Name = "municipio_departamento_iddepartamento")]
        public string municipio_departamento_iddepartamento { get; set; }

        [Column(Name = "municipio_departamento_descdepartamento")]
        public string municipio_departamento_descdepartamento { get; set; }

        [Column(Name = "diasplazo")]
        public Nullable<byte> diasplazo { get; set; }

        [Column(Name = "cupocredito")]
        public Nullable<Single> cupocredito { get; set; }

        [Column(Name = "itemlista_iditemlista_regimen")]
        public Nullable<int> itemlista_iditemlista_regimen { get; set; }

        [Column(Name = "itemlista_iditemlista_descregimen")]
        public string itemlista_iditemlista_descregimen { get; set; }

        [Column(Name = "itemlista_iditemlista_formapago")]
        public Nullable<int> itemlista_iditemlista_formapago { get; set; }

        [Column(Name = "itemlista_iditemlista_descformapago")]
        public string itemlista_iditemlista_descformapago { get; set; }

        [Column(Name = "contactos")]
        public string contactos { get; set; }

        [Column(Name = "observaciones")]
        public string observaciones { get; set; }

        [Column(Name = "activo")]
        public Nullable<bool> activo { get; set; }

        [Column(Name = "fechacreacion")]
        public Nullable<DateTime> fechacreacion { get; set; }

        [Column(Name = "empresa_idempresa")]
        public Nullable<byte> empresa_idempresa { get; set; }

        [Column(Name = "empresa_descempresa")]
        public string empresa_descempresa { get; set; }

        [Column(Name = "asesor_idasesor")]
        public Nullable<byte> asesor_idasesor { get; set; }

        [Column(Name = "asesor_descasesor")]
        public string asesor_descasesor { get; set; }

        [Column(Name = "nuevo")]
        public Nullable<bool> nuevo { get; set; }

        [Column(Name = "calificacion")]
        public string calificacion { get; set; }
    }
}
