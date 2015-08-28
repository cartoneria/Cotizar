using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.CotizarService
{
    using System.Runtime.Serialization;
    using System;
    using System.ComponentModel.DataAnnotations;

    #region [Empresa]
    [MetadataType(typeof(EmpresaMetadata))]
    public partial class Empresa
    {

    }

    public partial class EmpresaMetadata
    {
        [Display(Name = "ID")]
        public Nullable<byte> idempresa { get; set; }

        [Display(Name = "Razón social")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string razonsocial { get; set; }

        [Display(Name = "Nit")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string nit { get; set; }

        [Display(Name = "Dirección")]
        public string direccion { get; set; }

        [Display(Name = "Teléfono")]
        public string telefono { get; set; }

        [Display(Name = "Representante legal")]
        public string representantelegal { get; set; }

        [Display(Name = "Estado")]
        [Required]
        public Nullable<bool> activo { get; set; }

        [Display(Name = "Logo")]
        public string urilogo { get; set; }
    }

    public partial class EmpresaModel : EmpresaMetadata
    {
        [DataType(DataType.Upload)]
        public HttpPostedFileBase ImageUpload { get; set; }
    }

    #endregion

    #region [Asesor]
    [MetadataType(typeof(AsesorMetadata))]
    public partial class Asesor
    {

    }

    public partial class AsesorMetadata
    {
        [Display(Name = "ID")]
        public Nullable<byte> idasesor { get; set; }

        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Display(Name = "Comición")]
        public Nullable<decimal> comision { get; set; }

        [Display(Name = "Teléfono")]
        public string telefono { get; set; }

        [Display(Name = "Email")]
        public string correoelectronico { get; set; }

        [Display(Name = "Código")]
        public string codigo { get; set; }

        [Display(Name = "Empresa")]
        public Nullable<byte> empresa_idempresa { get; set; }

        [Display(Name = "Estado")]
        public Nullable<bool> activo { get; set; }

        [Display(Name = "Fecha creación")]
        public Nullable<DateTime> fechacreacion { get; set; }
    }
    #endregion

    #region [Máquina]
    [MetadataType(typeof(MaquinaMetadata))]
    public partial class Maquina
    {

    }

    public partial class MaquinaMetadata
    {
        [Display(Name = "ID")]
        public Nullable<Int16> idmaquina { get; set; }

        [Display(Name = "Código")]
        public string codigo { get; set; }

        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Display(Name = "Descripción")]
        public string descripcion { get; set; }

        [Display(Name = "Largo máx")]
        public Nullable<decimal> largomax { get; set; }

        [Display(Name = "Largo mín")]
        public Nullable<decimal> largomin { get; set; }

        [Display(Name = "Ancho máx")]
        public Nullable<decimal> anchomax { get; set; }

        [Display(Name = "Ancho mín")]
        public Nullable<decimal> anchomin { get; set; }

        [Display(Name = "Fecha creación")]
        public Nullable<DateTime> fechacreacion { get; set; }

        [Display(Name = "Estado")]
        public Nullable<bool> activo { get; set; }

        [Display(Name = "Empresa")]
        public Nullable<byte> empresa_idempresa { get; set; }

        [Display(Name = "Tipo")]
        public Nullable<int> itemlista_iditemlistas_tipo { get; set; }
    }
    #endregion

    #region [Usuario]
    [MetadataType(typeof(UsuarioMetadata))]
    public partial class Usuario
    {

    }

    public partial class UsuarioMetadata
    {
        [Display(Name = "ID")]
        public Nullable<Int16> idusuario { get; set; }

        [Display(Name = "Alias")]
        public string usuario { get; set; }

        [Display(Name = "Clave")]
        public string clave { get; set; }

        [Display(Name = "Nombre")]
        public string nombrecompleto { get; set; }

        [Display(Name = "Email")]
        public string correoelectronico { get; set; }

        [Display(Name = "Celular")]
        public string celular { get; set; }

        [Display(Name = "Fecha creación")]
        public Nullable<DateTime> fechacreacion { get; set; }

        [Display(Name = "Estado")]
        public Nullable<bool> activo { get; set; }

        [Display(Name = "Cargo")]
        public string cargo { get; set; }

        [Display(Name = "Rol")]
        public Nullable<Int16> rol_idrol { get; set; }

        [Display(Name = "Empresa")]
        public Nullable<byte> empresa_idempresa { get; set; }

        [Display(Name = "Área")]
        public Nullable<int> itemlista_iditemlistas_area { get; set; }
    }
    #endregion

    #region [Rol]
    [MetadataType(typeof(RolMetadata))]
    public partial class Rol
    {

    }

    public partial class RolMetadata
    {
        [Display(Name = "ID")]
        public Nullable<Int16> idrol { get; set; }

        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Display(Name = "Descripción")]
        public string descripcion { get; set; }

        [Display(Name = "Estado")]
        public Nullable<bool> activo { get; set; }

        [Display(Name = "Fecha creación")]
        public Nullable<DateTime> fechacreacion { get; set; }

        public IEnumerable<CotizarService.Permiso> permisos { get; set; }
    }
    #endregion

    #region [ItemLista]
    [MetadataType(typeof(ItemListaMetadata))]
    public partial class ItemLista
    {

    }

    public partial class ItemListaMetadata
    {
        [Display(Name = "ID")]
        public Nullable<int> iditemlista { get; set; }

        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Display(Name = "Grupo")]
        public Nullable<byte> grupo { get; set; }

        [Display(Name = "Estado")]
        public Nullable<bool> activo { get; set; }

        [Display(Name = "Padre")]
        public Nullable<int> idpadre { get; set; }

        public IEnumerable<ItemLista> items { get; set; }
    }
    #endregion
}