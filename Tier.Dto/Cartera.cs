using System;
using System.Data.Linq.Mapping;

namespace Tier.Dto
{
    public class Cartera
    {
        [Column(Name = "cliente_idcliente")]
        public Nullable<int> cliente_idcliente { get; set; }

        [Column(Name = "asesor_idasesor")]
        public Nullable<int> asesor_idasesor { get; set; }

        [Column(Name = "cuenta")]
        public string cuenta { get; set; }

        [Column(Name = "documento")]
        public string documento { get; set; }

        [Column(Name = "consecutivo")]
        public Nullable<byte> consecutivo { get; set; }

        [Column(Name = "fecha")]
        public Nullable<DateTime> fecha { get; set; }

        [Column(Name = "vencimiento")]
        public Nullable<DateTime> vencimiento { get; set; }

        [Column(Name = "dias")]
        public Nullable<double> dias { get; set; }

        [Column(Name = "valormora")]
        public Nullable<Single> valormora { get; set; }

        [Column(Name = "valorsaldo")]
        public Nullable<Single> valorsaldo { get; set; }

        [Column(Name = "activo")]
        public Nullable<bool> activo { get; set; }

        [Column(Name = "fechacracion")]
        public Nullable<DateTime> fechacracion { get; set; }

        public Nullable<int> filaarchivo { get; set; }
    }
}
