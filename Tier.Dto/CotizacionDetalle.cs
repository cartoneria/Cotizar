using System;
using System.Data.Linq.Mapping;

namespace Tier.Dto
{
    public class CotizacionDetalle
    {
        [Column(Name = "idcotizacion_detalle")]
        public Nullable<int> idcotizacion_detalle { get; set; }

        [Column(Name = "fechacreacion")]
        public Nullable<DateTime> fechacreacion { get; set; }

        [Column(Name = "activo")]
        public Nullable<bool> activo { get; set; }

        [Column(Name = "cotizacion_idcotizacion")]
        public Nullable<int> cotizacion_idcotizacion { get; set; }

        [Column(Name = "producto_idproducto")]
        public Nullable<int> producto_idproducto { get; set; }

        [Column(Name = "producto_descproducto")]
        public string producto_descproducto { get; set; }
    
        [Column(Name = "insumo_idinsumo_flete")]
        public Nullable<int> insumo_idinsumo_flete { get; set; }
    
        [Column(Name = "insumo_idinsumo_descflete")]
        public string insumo_idinsumo_descflete { get; set; }
    
        [Column(Name = "escala")]
        public Nullable<Single> escala { get; set; }

        [Column(Name = "areacartoncaja")]
        public Nullable<Single> areacartoncaja { get; set; }

        [Column(Name = "areaacader")]
        public Nullable<Single> areaacader { get; set; }

        [Column(Name = "areaacarev")]
        public Nullable<Single> areaacarev { get; set; }

        [Column(Name = "cabidaconversion")]
        public Nullable<short> cabidaconversion { get; set; }

        [Column(Name = "cabidatroquel")]
        public Nullable<short> cabidatroquel { get; set; }

        [Column(Name = "canttintas")]
        public Nullable<byte> canttintas { get; set; }

        [Column(Name = "costoreempaque")]
        public Nullable<Single> costoreempaque { get; set; }

        [Column(Name = "costoaccesorios")]
        public Nullable<Single> costoaccesorios { get; set; }

        [Column(Name = "costoflete")]
        public Nullable<Single> costoflete { get; set; }

        [Column(Name = "costoacetato")]
        public Nullable<Single> costoacetato { get; set; }

        [Column(Name = "costocartoncaja")]
        public Nullable<Single> costocartoncaja { get; set; }

        [Column(Name = "costocartoncolaminado")]
        public Nullable<Single> costocartoncolaminado { get; set; }

        [Column(Name = "costotintas")]
        public Nullable<Single> costotintas { get; set; }

        [Column(Name = "costoacabadoder")]
        public Nullable<Single> costoacabadoder { get; set; }

        [Column(Name = "costoacabadorev")]
        public Nullable<Single> costoacabadorev { get; set; }

        [Column(Name = "costopegante")]
        public Nullable<Single> costopegante { get; set; }

        [Column(Name = "costopliegosdesper")]
        public Nullable<Single> costopliegosdesper { get; set; }

        [Column(Name = "costoprocpegue")]
        public Nullable<Single> costoprocpegue { get; set; }

        [Column(Name = "costoprocacabadoder")]
        public Nullable<Single> costoprocacabadoder { get; set; }

        [Column(Name = "costoprocacabadorev")]
        public Nullable<Single> costoprocacabadorev { get; set; }

        [Column(Name = "costoprocconversion")]
        public Nullable<Single> costoprocconversion { get; set; }

        [Column(Name = "costoproclitografia")]
        public Nullable<Single> costoproclitografia { get; set; }

        [Column(Name = "costoproctroqelado")]
        public Nullable<Single> costoproctroqelado { get; set; }

        [Column(Name = "costoproccolaminado")]
        public Nullable<Single> costoproccolaminado { get; set; }

        [Column(Name = "costoprocguillotinado")]
        public Nullable<Single> costoprocguillotinado { get; set; }

        [Column(Name = "costoaportegastounidad")]
        public Nullable<Single> costoaportegastounidad { get; set; }

        [Column(Name = "costototalmaterialunidad")]
        public Nullable<Single> costototalmaterialunidad { get; set; }

        [Column(Name = "costototalprocesosunidad")]
        public Nullable<Single> costototalprocesosunidad { get; set; }

        [Column(Name = "costototalfabricacion")]
        public Nullable<Single> costototalfabricacion { get; set; }

        [Column(Name = "costodesperdiciocaja")]
        public Nullable<Single> costodesperdiciocaja { get; set; }

        [Column(Name = "porcedesperdiciocaja")]
        public Nullable<Single> porcedesperdiciocaja { get; set; }

        [Column(Name = "porcealzageneral")]
        public Nullable<Single> porcealzageneral { get; set; }

        [Column(Name = "porceicacree")]
        public Nullable<Single> porceicacree { get; set; }

        [Column(Name = "porcecomisionasesor")]
        public Nullable<Single> porcecomisionasesor { get; set; }

        [Column(Name = "porceadmfinanciacion")]
        public Nullable<Single> porceadmfinanciacion { get; set; }

        [Column(Name = "porceprecioproducto")]
        public Nullable<Single> porceprecioproducto { get; set; }

        [Column(Name = "costonetocaja")]
        public Nullable<Single> costonetocaja { get; set; }

        [Column(Name = "observaciones")]
        public string observaciones { get; set; }
    }
}
