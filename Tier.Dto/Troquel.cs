﻿using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Dto
{
    public partial class Troquel
    {
        Nullable<int> _idtroquel;

        [Column(Name = "idtroquel")]
        public Nullable<int> idtroquel
        {
            get
            {
                return this._idtroquel;
            }

            set
            {
                this._idtroquel = value;
                if (this.ventanas != null && this.ventanas.Count() > 0)
                {
                    foreach (Dto.TroquelVentana item in this.ventanas)
                    {
                        item.troquel_idtroquel = this._idtroquel;
                    }
                }
            }
        }

        [Column(Name = "descripcion")]
        public string descripcion { get; set; }

        [Column(Name = "itemlista_iditemlista_material")]
        public Nullable<int> itemlista_iditemlista_material { get; set; }

        [Column(Name = "modelo")]
        public string modelo { get; set; }

        [Column(Name = "tamanio")]
        public string tamanio { get; set; }

        [Column(Name = "largo")]
        public Nullable<Single> largo { get; set; }

        [Column(Name = "ancho")]
        public Nullable<Single> ancho { get; set; }

        [Column(Name = "alto")]
        public Nullable<Single> alto { get; set; }

        [Column(Name = "fibra")]
        public Nullable<Single> fibra { get; set; }

        [Column(Name = "contrafibra")]
        public Nullable<Single> contrafibra { get; set; }

        [Column(Name = "cabidafibra")]
        public Nullable<byte> cabidafibra { get; set; }

        [Column(Name = "cabidacontrafibra")]
        public Nullable<byte> cabidacontrafibra { get; set; }

        public IEnumerable<Dto.TroquelVentana> ventanas { get; set; }

        [Column(Name = "ubicacion")]
        public string ubicacion { get; set; }

        [Column(Name = "marca")]
        public string marca { get; set; }

        [Column(Name = "observaciones")]
        public string observaciones { get; set; }

        [Column(Name = "fechacreacion")]
        public Nullable<DateTime> fechacreacion { get; set; }

        [Column(Name = "activo")]
        public Nullable<bool> activo { get; set; }

        [Column(Name = "empresa_idempresa")]
        public Nullable<byte> empresa_idempresa { get; set; }

        [Column(Name = "nombreimagen")]
        public string nombreimagen { get; set; }
    }
}
