using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;

namespace Tier.Dto
{
    public class ReporteCotizacion
    {
        [Column(Name = "clienteRazonSocial")]
        public string clienteRazonSocial { get; set; }

        [Column(Name = "fechaCotizacion")]
        public DateTime fechaCotizacion { get; set; }

        [Column(Name = "clienteContactoDireccion")]
        public string clienteContactoDireccion { get; set; }

        [Column(Name = "clienteContactoCiudad")]
        public string clienteContactoCiudad { get; set; }

        [Column(Name = "observacionesCotizacion")]
        public string observacionesCotizacion { get; set; }

        [Column(Name = "costosplanchaCotizacion")]
        public Single costosplanchaCotizacion { get; set; }

        [Column(Name = "costostroquelesCotizacion")]
        public Single costostroquelesCotizacion { get; set; }

        [Column(Name = "clienteContactos")]
        public string clienteContactos { get; set; }

        [Column(Name = "idCotizacion")]
        public int idCotizacion { get; set; }

        public IEnumerable<Dto.ReporteCotizacionProductos> productos { get; set; }

        public IEnumerable<Dto.ReporteCotizacionValores> valores { get; set; }
    }

    public class ReporteCotizacionProductos
    {
        [Column(Name = "idProducto")]
        public Nullable<int> idProducto { get; set; }

        [Column(Name = "referenciaCliente")]
        public string referenciaCliente { get; set; }

        [Column(Name = "descMaterialCaja")]
        public string descMaterialCaja { get; set; }

        [Column(Name = "codMaterialCaja")]
        public string codMaterialCaja { get; set; }

        [Column(Name = "cantTintasDerecho")]
        public Nullable<byte> cantTintasDerecho { get; set; }

        [Column(Name = "cantTintasReverso")]
        public Nullable<byte> cantTintasReverso { get; set; }

        [Column(Name = "descPantones")]
        public string descPantones { get; set; }

        [Column(Name = "largo")]
        public Nullable<Single> largo { get; set; }

        [Column(Name = "ancho")]
        public Nullable<Single> ancho { get; set; }

        [Column(Name = "alto")]
        public Nullable<Single> alto { get; set; }

        [Column(Name = "cantVentanas")]
        public byte cantVentanas { get; set; }

        [Column(Name = "descAcabadoDerecho")]
        public string descAcabadoDerecho { get; set; }

        [Column(Name = "descAcabadoReverso")]
        public string descAcabadoReverso { get; set; }

        [Column(Name = "descAccesorios")]
        public string descAccesorios { get; set; }

        [Column(Name = "codTroquel")]
        public string codTroquel { get; set; }

        [Column(Name = "productoNuevo")]
        public bool productoNuevo { get; set; }
    }

    public class ReporteCotizacionValores
    {
        [Column(Name = "escala")]
        public short escala { get; set; }

        [Column(Name = "costonetocaja")]
        public Single costonetocaja { get; set; }

        [Column(Name = "producto_idproducto")]
        public int producto_idproducto { get; set; }
    }
}
