using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;

namespace Tier.Dto
{
    public partial class Producto
    {
        #region [Propiedades]
        [Column(Name = "idproducto")]
        public Nullable<int> idproducto { get; set; }

        [Column(Name = "referenciacliente")]
        public string referenciacliente { get; set; }

        [Column(Name = "cliente_idcliente")]
        public Nullable<int> cliente_idcliente { get; set; }

        [Column(Name = "cliente_desccliente")]
        public string cliente_desccliente { get; set; }

        [Column(Name = "observaciones")]
        public string observaciones { get; set; }

        [Column(Name = "troquel_idtroquel")]
        public Nullable<int> troquel_idtroquel { get; set; }

        [Column(Name = "troquel_desctroquel")]
        public string troquel_desctroquel { get; set; }

        [Column(Name = "insumo_idinsumo_material")]
        public Nullable<int> insumo_idinsumo_material { get; set; }

        [Column(Name = "insumo_idinsumo_descmaterial")]
        public string insumo_idinsumo_descmaterial { get; set; }

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

        [Column(Name = "insumo_idinsumo_descacetato")]
        public string insumo_idinsumo_descacetato { get; set; }

        [Column(Name = "insumo_idinsumo_acabadoderecho")]
        public Nullable<int> insumo_idinsumo_acabadoderecho { get; set; }

        [Column(Name = "insumo_idinsumo_descacabadoderecho")]
        public string insumo_idinsumo_descacabadoderecho { get; set; }

        [Column(Name = "anchomaquina_acabadoderecho")]
        public Nullable<Single> anchomaquina_acabadoderecho { get; set; }

        [Column(Name = "recorrido_acabadoderecho")]
        public Nullable<Single> recorrido_acabadoderecho { get; set; }

        [Column(Name = "insumo_idinsumo_acabadoreverso")]
        public Nullable<int> insumo_idinsumo_acabadoreverso { get; set; }

        [Column(Name = "insumo_idinsumo_descacabadoreverso")]
        public string insumo_idinsumo_descacabadoreverso { get; set; }

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

        [Column(Name = "insumo_idinsumo_desccolaminado")]
        public string insumo_idinsumo_desccolaminado { get; set; }

        [Column(Name = "insumo_idinsumo_colaminadopegante")]
        public Nullable<int> insumo_idinsumo_colaminadopegante { get; set; }

        [Column(Name = "insumo_idinsumo_desccolaminadopegante")]
        public string insumo_idinsumo_desccolaminadopegante { get; set; }

        [Column(Name = "colaminadoancho")]
        public Nullable<Single> colaminadoancho { get; set; }

        [Column(Name = "colaminadoalargo")]
        public Nullable<Single> colaminadoalargo { get; set; }

        [Column(Name = "colaminadocabidalargo")]
        public Nullable<byte> colaminadocabidalargo { get; set; }

        [Column(Name = "colaminadocabidaancho")]
        public Nullable<byte> colaminadocabidaancho { get; set; }

        [Column(Name = "insumo_idinsumo_reempaque")]
        public Nullable<int> insumo_idinsumo_reempaque { get; set; }

        [Column(Name = "insumo_idinsumo_descreempaque")]
        public string insumo_idinsumo_descreempaque { get; set; }

        [Column(Name = "factorrendimientoreempaque")]
        public Nullable<byte> factorrendimientoreempaque { get; set; }

        [Column(Name = "maquinavariprod_idVariacion_rutaconversion")]
        public Nullable<short> maquinavariprod_idVariacion_rutaconversion { get; set; }

        [Column(Name = "maquinavariprod_idVariacion_descrutaconversion")]
        public string maquinavariprod_idVariacion_descrutaconversion { get; set; }

        [Column(Name = "maquinavariprod_idVariacion_rutaguillotinado")]
        public Nullable<short> maquinavariprod_idVariacion_rutaguillotinado { get; set; }

        [Column(Name = "maquinavariprod_idVariacion_descrutaguillotinado")]
        public string maquinavariprod_idVariacion_descrutaguillotinado { get; set; }

        [Column(Name = "maquinavariprod_idVariacion_rutalitografia")]
        public Nullable<short> maquinavariprod_idVariacion_rutalitografia { get; set; }

        [Column(Name = "maquinavariprod_idVariacion_descrutalitografia")]
        public string maquinavariprod_idVariacion_descrutalitografia { get; set; }

        [Column(Name = "maquinavariprod_idVariacion_rutacolaminado")]
        public Nullable<short> maquinavariprod_idVariacion_rutacolaminado { get; set; }

        [Column(Name = "maquinavariprod_idVariacion_descrutacolaminado")]
        public string maquinavariprod_idVariacion_descrutacolaminado { get; set; }

        [Column(Name = "maquinavariprod_idVariacion_rutatroquelado")]
        public Nullable<short> maquinavariprod_idVariacion_rutatroquelado { get; set; }

        [Column(Name = "maquinavariprod_idVariacion_descrutatroquelado")]
        public string maquinavariprod_idVariacion_descrutatroquelado { get; set; }

        [Column(Name = "maquinavariprod_idVariacion_rutaacabadoderecho")]
        public Nullable<short> maquinavariprod_idVariacion_rutaacabadoderecho { get; set; }

        [Column(Name = "maquinavariprod_idVariacion_descrutaacabadoderecho")]
        public string maquinavariprod_idVariacion_descrutaacabadoderecho { get; set; }

        [Column(Name = "maquinavariprod_idVariacion_rutaacabadoreverso")]
        public Nullable<short> maquinavariprod_idVariacion_rutaacabadoreverso { get; set; }

        [Column(Name = "maquinavariprod_idVariacion_descrutaacabadoreverso")]
        public string maquinavariprod_idVariacion_descrutaacabadoreverso { get; set; }

        [Column(Name = "nuevo")]
        public Nullable<bool> nuevo { get; set; }

        [Column(Name = "activo")]
        public Nullable<bool> activo { get; set; }

        [Column(Name = "fechacreacion")]
        public Nullable<DateTime> fechacreacion { get; set; }

        public IEnumerable<Dto.ProductoAccesorio> accesorios { get; set; }

        public IEnumerable<Dto.ProductoEspectro> espectro { get; set; }

        public IEnumerable<Dto.ProductoPegue> pegues { get; set; }
        #endregion

        #region [Métodos]
        public void AsignarIdentificador()
        {
            if (this.accesorios != null && this.accesorios.Count() > 0)
            {
                foreach (Dto.ProductoAccesorio item in this.accesorios)
                {
                    item.producto_idproducto = this.idproducto;
                }
            }

            if (this.espectro != null && this.espectro.Count() > 0)
            {
                foreach (Dto.ProductoEspectro item in this.espectro)
                {
                    item.producto_idproducto = this.idproducto;
                }
            }

            if (this.pegues != null && this.pegues.Count() > 0)
            {
                foreach (Dto.ProductoPegue item in this.pegues)
                {
                    item.producto_idproducto = this.idproducto;
                }
            }
        }
        #endregion
    }
}
