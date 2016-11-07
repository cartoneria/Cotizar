using System;
using System.Data.Linq.Mapping;

namespace Tier.Dto
{
    public class ProductoPegue
    {
        [Column(Name = "idproducto_pegue")]
        public Nullable<int> idproducto_pegue { get; set; }

        [Column(Name = "activo")]
        public Nullable<bool> activo { get; set; }

        public Dto.ProductoPegue pegue { get; set; }

        [Column(Name = "fechacreacion")]
        public Nullable<DateTime> fechacreacion { get; set; }

        [Column(Name = "producto_idproducto")]
        public Nullable<int> producto_idproducto { get; set; }

        [Column(Name = "producto_descproducto")]
        public string producto_descproducto { get; set; }

        [Column(Name = "insumo_idinsumo")]
        public Nullable<int> insumo_idinsumo { get; set; }

        [Column(Name = "insumo_descinsumo")]
        public string insumo_descinsumo { get; set; }

        [Column(Name = "largo")]
        public Nullable<Single> largo { get; set; }

        [Column(Name = "ancho")]
        public Nullable<Single> ancho { get; set; }

        [Column(Name = "maquinavariprod_idVariacion")]
        public Nullable<short> maquinavariprod_idVariacion { get; set; }

        [Column(Name = "maquinavariprod_descvariacion")]
        public string maquinavariprod_descvariacion { get; set; }
    }
}
