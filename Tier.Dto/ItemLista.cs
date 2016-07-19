using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;

namespace Tier.Dto
{
    public partial class ItemLista
    {
        Nullable<int> _iditemlista;

        [Column(Name = "iditemlista")]
        public Nullable<int> iditemlista
        {
            get
            {
                return this._iditemlista;
            }

            set
            {
                this._iditemlista = value;
                if (this.items != null && this.items.Count() > 0)
                {
                    foreach (Dto.ItemLista item in this.items)
                    {
                        item.idpadre = this._iditemlista;
                    }
                }
            }
        }

        [Column(Name = "nombre")]
        public string nombre { get; set; }

        [Column(Name = "grupo")]
        public Nullable<byte> grupo { get; set; }

        [Column(Name = "activo")]
        public Nullable<bool> activo { get; set; }

        [Column(Name = "idpadre")]
        public Nullable<int> idpadre { get; set; }

        public IEnumerable<ItemLista> items { get; set; }
    }
}
