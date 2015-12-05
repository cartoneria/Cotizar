using System;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Tier.Dto
{
    public partial class Producto
    {
        [Column(Name = "idproducto")]
        public Nullable<int> idproducto { get; set; }

        [Column(Name = "referenciacliente")]
        public string referenciacliente { get; set; }

        [Column(Name = "cliente_idcliente")]
        public Nullable<int> cliente_idcliente { get; set; }

        [Column(Name = "observaciones")]
        public string observaciones { get; set; }

        [Column(Name = "troquel_idtroquel")]
        public Nullable<int> troquel_idtroquel { get; set; }

        [Column(Name = "insumo_idinsumo_material")]
        public Nullable<int> insumo_idinsumo_material { get; set; }

        [Column(Name = "largobobina")]
        public Nullable<Single> largobobina { get; set; }

        [Column(Name = "anchobobina")]
        public Nullable<Single> anchobobina { get; set; }

        [Column(Name = "cabidaancho")]
        public Nullable<byte> cabidaancho { get; set; }

        [Column(Name = "cabidalargo")]
        public Nullable<byte> cabidalargo { get; set; }

        [Column(Name = "insumo_idinsumo_acetato")]
        public Nullable<int> insumo_idinsumo_acetato { get; set; }

        [Column(Name = "itemlista_iditemlista_acabadoderecho")]
        public Nullable<int> itemlista_iditemlista_acabadoderecho { get; set; }

        [Column(Name = "anchomaquina_acabadoderecho")]
        public Nullable<Single> anchomaquina_acabadoderecho { get; set; }

        [Column(Name = "recorrido_acabadoderecho")]
        public Nullable<Single> recorrido_acabadoderecho { get; set; }

        [Column(Name = "itemlista_iditemlista_acabadoreverso")]
        public Nullable<int> itemlista_iditemlista_acabadoreverso { get; set; }

        [Column(Name = "anchomaquina_acabadoreverso")]
        public Nullable<Single> anchomaquina_acabadoreverso { get; set; }

        [Column(Name = "recorrido_acabadoreverso")]
        public Nullable<Single> recorrido_acabadoreverso { get; set; }

        [Column(Name = "posicionplanchas")]
        public string posicionplanchas { get; set; }

        [Column(Name = "pasadaslitograficas")]
        public Nullable<byte> pasadaslitograficas { get; set; }

        [Column(Name = "imagenartegrafico")]
        public string imagenartegrafico { get; set; }

        [Column(Name = "pinzalitografica")]
        public Nullable<bool> pinzalitografica { get; set; }

        [Column(Name = "factorprecio")]
        public Nullable<Single> factorprecio { get; set; }

        [Column(Name = "catidadpredeterminada")]
        public Nullable<short> catidadpredeterminada { get; set; }

        [Column(Name = "preciopredeterminado")]
        public Nullable<Single> preciopredeterminado { get; set; }

        [Column(Name = "insumo_idinsumo_colaminado")]
        public Nullable<int> insumo_idinsumo_colaminado { get; set; }

        [Column(Name = "colaminadoancho")]
        public Nullable<Single> colaminadoancho { get; set; }

        [Column(Name = "colaminadoalargo")]
        public Nullable<Single> colaminadoalargo { get; set; }

        [Column(Name = "colaminadocabidalargo")]
        public Nullable<byte> colaminadocabidalargo { get; set; }

        [Column(Name = "insumo_idinsumo_reempaque")]
        public Nullable<int> insumo_idinsumo_reempaque { get; set; }

        [Column(Name = "factorrendimientoreempaque")]
        public Nullable<byte> factorrendimientoreempaque { get; set; }

        [Column(Name = "maquina_idmaquina_rutaconversion")]
        public Nullable<short> maquina_idmaquina_rutaconversion { get; set; }

        [Column(Name = "maquina_idmaquina_rutaguillotinado")]
        public Nullable<short> maquina_idmaquina_rutaguillotinado { get; set; }

        [Column(Name = "maquina_idmaquina_rutalitografia")]
        public Nullable<short> maquina_idmaquina_rutalitografia { get; set; }

        [Column(Name = "maquina_idmaquina_rutaplastificado")]
        public Nullable<short> maquina_idmaquina_rutaplastificado { get; set; }

        [Column(Name = "maquina_idmaquina_rutacolaminado")]
        public Nullable<short> maquina_idmaquina_rutacolaminado { get; set; }

        [Column(Name = "maquina_idmaquina_rutatroquelado")]
        public Nullable<short> maquina_idmaquina_rutatroquelado { get; set; }

        [Column(Name = "maquina_idmaquina_rutapegue")]
        public Nullable<short> maquina_idmaquina_rutapegue { get; set; }

        [Column(Name = "activo")]
        public Nullable<bool> activo { get; set; }

        [Column(Name = "fechacreacion")]
        public Nullable<DateTime> fechacreacion { get; set; }

        public IEnumerable<Dto.ProductoAccesorio> accesorios { get; set; }

        public IEnumerable<Dto.ProductoEspectro> espectro { get; set; }

        public IEnumerable<Dto.ProductoPegue> pegues { get; set; }     
    }
}
