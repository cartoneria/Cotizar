using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Dto
{
    public class ReporteOrdenProduccion
    {
        [Column(Name = "clienteRazonSocial")]
        public string clienteRazonSocial { get; set; }

        [Column(Name = "clienteCalificacion")]
        public string clienteCalificacion { get; set; }

        [Column(Name = "pedidoIdSIIGO")]
        public string pedidoIdSIIGO { get; set; }

        [Column(Name = "productoRefCliente")]
        public string productoRefCliente { get; set; }

        [Column(Name = "productoId")]
        public int productoId { get; set; }

        [Column(Name = "pedidoCatidad")]
        public int pedidoCatidad { get; set; }

        [Column(Name = "pedidoFechaCreacion")]
        public DateTime pedidoFechaCreacion { get; set; }

        [Column(Name = "productoMaterialCaja")]
        public string productoMaterialCaja { get; set; }

        [Column(Name = "productoKilosMaterialCaja")]
        public string productoKilosMaterialCaja { get; set; }

        [Column(Name = "troquelCorte")]
        public string troquelCorte { get; set; }

        [Column(Name = "productoPinzaLito")]
        public string productoPinzaLito { get; set; }

        [Column(Name = "productoCorteConversion")]
        public string productoCorteConversion { get; set; }

        [Column(Name = "productoPliegosConversion")]
        public string productoPliegosConversion { get; set; }

        [Column(Name = "productoLargoBobina")]
        public string productoLargoBobina { get; set; }

        [Column(Name = "productoAnchoBobina")]
        public string productoAnchoBobina { get; set; }

        [Column(Name = "productoCabidaLargo")]
        public string productoCabidaLargo { get; set; }

        [Column(Name = "productoCabidaAncho")]
        public string productoCabidaAncho { get; set; }

        [Column(Name = "productoPosicionPlanchas")]
        public string productoPosicionPlanchas { get; set; }

        [Column(Name = "productoCantTintas")]
        public string productoCantTintas { get; set; }

        [Column(Name = "productoPantonesTiro")]
        public string productoPantonesTiro { get; set; }

        [Column(Name = "productoPantonesRetiro")]
        public string productoPantonesRetiro { get; set; }

        [Column(Name = "productoAcabDer")]
        public string productoAcabDer { get; set; }

        [Column(Name = "productoKilosAcabDer")]
        public string productoKilosAcabDer { get; set; }

        [Column(Name = "productoAcabRev")]
        public string productoAcabRev { get; set; }

        [Column(Name = "productoKilosAcabRev")]
        public string productoKilosAcabRev { get; set; }

        [Column(Name = "productoColaminado")]
        public string productoColaminado { get; set; }

        [Column(Name = "productoKilosMaterialColaminado")]
        public string productoKilosMaterialColaminado { get; set; }

        [Column(Name = "productoColaminadoLargo")]
        public string productoColaminadoLargo { get; set; }

        [Column(Name = "productoColaminadoAncho")]
        public string productoColaminadoAncho { get; set; }

        [Column(Name = "productoCorteColaminado")]
        public string productoCorteColaminado { get; set; }

        [Column(Name = "productoPliegosConversionColaminado")]
        public string productoPliegosConversionColaminado { get; set; }

        [Column(Name = "productoColaminadoCabidaLargo")]
        public string productoColaminadoCabidaLargo { get; set; }

        [Column(Name = "productoColaminadoCabidaAncho")]
        public string productoColaminadoCabidaAncho { get; set; }

        [Column(Name = "productoTroquel")]
        public string productoTroquel { get; set; }

        [Column(Name = "troquelUbicacion")]
        public string troquelUbicacion { get; set; }

        [Column(Name = "productoPegues")]
        public string productoPegues { get; set; }

        [Column(Name = "productoAcetatoVentanas")]
        public string productoAcetatoVentanas { get; set; }

        [Column(Name = "productoAccesorios")]
        public string productoAccesorios { get; set; }

        [Column(Name = "productoReempaque")]
        public string productoReempaque { get; set; }

        [Column(Name = "clienteObservaciones")]
        public string clienteObservaciones { get; set; }

        [Column(Name = "productoObservaciones")]
        public string productoObservaciones { get; set; }

        [Column(Name = "pedidoObservaciones")]
        public string pedidoObservaciones { get; set; }
    }
}
