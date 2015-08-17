using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;

namespace Tier.Dto
{
    //[DataContract]
    public class ItemLista
    {
        //[DataMember]
        [Column(Name = "iditemlista")]
        public Nullable<int> iditemlista { get; set; }

        //[DataMember]
        [Column(Name = "nombre")]
        public string nombre { get; set; }

        //[DataMember]
        [Column(Name = "grupo")]
        public Nullable<byte> grupo { get; set; }

        //[DataMember]
        [Column(Name = "activo")]
        public Nullable<bool> activo { get; set; }

        //[DataMember]
        [Column(Name = "idpadre")]
        public Nullable<int> idpadre { get; set; }

        //[DataMember]
        public IEnumerable<ItemLista> items { get; set; }
    }
}
