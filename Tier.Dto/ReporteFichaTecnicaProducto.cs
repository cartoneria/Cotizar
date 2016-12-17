using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Dto
{
    public class ReporteFichaTecnicaProducto
    {
        [Column(Name = "productoId")]
        public int productoId { get; set; }

        [Column(Name = "clienteRazonSocial")]
        public string clienteRazonSocial { get; set; }

        [Column(Name = "clienteIdentificacion")]
        public string clienteIdentificacion { get; set; }

        [Column(Name = "clienteDireccion")]
        public string clienteDireccion { get; set; }

        [Column(Name = "clienteMunicipio")]
        public string clienteMunicipio { get; set; }

        [Column(Name = "clienteContacto")]
        public string clienteContacto { get; set; }

        [Column(Name = "clienteAsesor")]
        public string clienteAsesor { get; set; }

        [Column(Name = "clienteObservaciones")]
        public string clienteObservaciones { get; set; }

        [Column(Name = "productoCorte")]
        public string productoCorte { get; set; }

        [Column(Name = "productoConversion")]
        public string productoConversion { get; set; }

        [Column(Name = "productoGuillotinado")]
        public string productoGuillotinado { get; set; }

        [Column(Name = "productoReferencia")]
        public string productoReferencia { get; set; }

        [Column(Name = "productoCantTintas")]
        public string productoCantTintas { get; set; }

        [Column(Name = "productoTroquel")]
        public string productoTroquel { get; set; }

        [Column(Name = "productoCabidaTroquel")]
        public int productoCabidaTroquel { get; set; }

        [Column(Name = "productoMaterial")]
        public string productoMaterial { get; set; }

        [Column(Name = "productoPantonesTiro")]
        public string productoPantonesTiro { get; set; }

        [Column(Name = "productoPantonesRetiro")]
        public string productoPantonesRetiro { get; set; }

        [Column(Name = "productoPegues")]
        public string productoPegues { get; set; }

        [Column(Name = "productoAcetatoVentanas")]
        public string productoAcetatoVentanas { get; set; }

        [Column(Name = "productoAcabadoDer")]
        public string productoAcabadoDer { get; set; }

        [Column(Name = "productoAcabadoRev")]
        public string productoAcabadoRev { get; set; }

        [Column(Name = "productoDimenciones")]
        public string productoDimenciones { get; set; }

        [Column(Name = "productoAccesorios")]
        public string productoAccesorios { get; set; }

        [Column(Name = "productoObservaiones")]
        public string productoObservaiones { get; set; }

        [Column(Name = "productoPlanchas")]
        public string productoPlanchas { get; set; }

        [Column(Name = "productoArchivoArteGrafico")]
        public string productoArchivoArteGrafico { get; set; }
    }
}
