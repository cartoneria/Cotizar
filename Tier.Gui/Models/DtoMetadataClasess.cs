using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.CotizarService
{
    using System.Runtime.Serialization;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

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
        [Required(ErrorMessage = "Dato requerido")]
        [StringLength(512, ErrorMessage = "Dato demasiado largo")]
        public string razonsocial { get; set; }

        [Display(Name = "Nit")]
        [Required(ErrorMessage = "Dato requerido")]
        [StringLength(16, ErrorMessage = "Dato demasiado largo")]
        public string nit { get; set; }

        [Display(Name = "Dirección")]
        [StringLength(512, ErrorMessage = "Dato demasiado largo")]
        public string direccion { get; set; }

        [Display(Name = "Teléfono")]
        [StringLength(16, ErrorMessage = "Dato demasiado largo")]
        public string telefono { get; set; }

        [Display(Name = "Representante legal")]
        [StringLength(128, ErrorMessage = "Dato demasiado largo")]
        public string representantelegal { get; set; }

        [Display(Name = "Estado")]
        [Required]
        public Nullable<bool> activo { get; set; }

        [Display(Name = "Logo")]
        [StringLength(512, ErrorMessage = "Dato demasiado largo")]
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
        [StringLength(256, ErrorMessage = "Dato demasiado largo")]
        [Required(ErrorMessage = "Dato requerido")]
        public string nombre { get; set; }

        [Display(Name = "Comisión")]
        [Required(ErrorMessage = "Dato requerido")]
        [Range(0, 99.99, ErrorMessage = "Dato inválido")]
        public Nullable<decimal> comision { get; set; }

        [Display(Name = "Teléfono")]
        [StringLength(16, ErrorMessage = "Dato demasiado largo")]
        public string telefono { get; set; }

        [Display(Name = "Email")]
        [StringLength(256, ErrorMessage = "Dato demasiado largo")]
        [EmailAddress(ErrorMessage = "Formato de correo inválido")]
        public string correoelectronico { get; set; }

        [Display(Name = "Código")]
        [StringLength(8, ErrorMessage = "Dato demasiado largo")]
        [Required(ErrorMessage = "Dato requerido.")]
        [Remote("ValidaCodigoAsesor", "Comercial", AdditionalFields = "empresa_idempresa, editando")]
        public string codigo { get; set; }

        [Display(Name = "Empresa")]
        [Required(ErrorMessage = "Dato requerido")]
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
        [Required(ErrorMessage = "Dato requerido")]
        [StringLength(8, ErrorMessage = "Dato demasiado largo")]
        [Remote("ValidaCodigoMaquina", "Produccion", AdditionalFields = "empresa_idempresa, editando")]
        public string codigo { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Dato requerido")]
        [StringLength(128, ErrorMessage = "Dato demasiado largo")]
        public string nombre { get; set; }

        [Display(Name = "Empresa")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<byte> empresa_idempresa { get; set; }

        [Display(Name = "Tipo")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<int> itemlista_iditemlistas_tipo { get; set; }

        [Display(Name = "Ancho  (Área)")]
        [Range(0, 1000, ErrorMessage = "Dato inválido")]
        public Nullable<Single> areaancho { get; set; }

        [Display(Name = "Largo  (Área)")]
        [Range(0, 1000, ErrorMessage = "Dato inválido")]
        public Nullable<Single> arealargo { get; set; }

        [Display(Name = "Turnos")]
        public Nullable<byte> turnos { get; set; }

        [Display(Name = "Consumo (kWh)")]
        public Nullable<Single> consumonominal { get; set; }

        [Display(Name = "Largo máx (MP)")]
        [Range(0, 1000, ErrorMessage = "Dato inválido")]
        public Nullable<Single> largomaxmp { get; set; }

        [Display(Name = "Ancho máx (MP)")]
        [Range(0, 1000, ErrorMessage = "Dato inválido")]
        public Nullable<Single> largominmp { get; set; }

        [Display(Name = "Largo mín (MP)")]
        [Range(0, 1000, ErrorMessage = "Dato inválido")]
        public Nullable<Single> anchomaxmp { get; set; }

        [Display(Name = "Ancho mín (MP)")]
        [Range(0, 1000, ErrorMessage = "Dato inválido")]
        public Nullable<Single> anchominmp { get; set; }

        [Display(Name = "Fecha creación")]
        public Nullable<DateTime> fechacreacion { get; set; }

        [Display(Name = "Estado")]
        public Nullable<bool> activo { get; set; }
    }

    public partial class MaquinaModel : MaquinaMetadata
    {
        public string hfdCfgProduccion { get; set; }

        public string hfdDatosPeriodicos { get; set; }
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
        [Required(ErrorMessage = "Dato requerido")]
        [StringLength(16, ErrorMessage = "Dato demasiado largo")]
        [Remote("ValidaNombreUsuario", "Administracion", AdditionalFields = "editando")]
        public string usuario { get; set; }

        [Display(Name = "Clave")]
        public string clave { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Dato requerido")]
        [StringLength(256, ErrorMessage = "Dato demasiado largo")]
        public string nombrecompleto { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Formato de correo inválido")]
        [StringLength(256, ErrorMessage = "Dato demasiado largo")]
        public string correoelectronico { get; set; }

        [Display(Name = "Celular")]
        [StringLength(16, ErrorMessage = "Dato demasiado largo")]
        public string celular { get; set; }

        [Display(Name = "Fecha creación")]
        public Nullable<DateTime> fechacreacion { get; set; }

        [Display(Name = "Estado")]
        public Nullable<bool> activo { get; set; }

        [Display(Name = "Cargo")]
        [StringLength(64, ErrorMessage = "Dato demasiado largo")]
        public string cargo { get; set; }

        [Display(Name = "Rol")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<Int16> rol_idrol { get; set; }

        [Display(Name = "Empresa")]
        [Required(ErrorMessage = "Dato requerido")]
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
        [Required(ErrorMessage = "Dato requerido")]
        [StringLength(32, ErrorMessage = "Dato demasiado largo")]
        [Remote("ValidaNombreRol", "Administracion", AdditionalFields = "editando")]
        public string nombre { get; set; }

        [Display(Name = "Descripción")]
        [StringLength(512, ErrorMessage = "Dato demasiado largo")]
        public string descripcion { get; set; }

        [Display(Name = "Estado")]
        public Nullable<bool> activo { get; set; }

        [Display(Name = "Fecha creación")]
        public Nullable<DateTime> fechacreacion { get; set; }

        public IEnumerable<CotizarService.Permiso> permisos { get; set; }
    }

    public partial class RolModel : RolMetadata
    {
        public string permisosseleccionados { get; set; }
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
        [Required(ErrorMessage = "Dato requerido")]
        [StringLength(32, ErrorMessage = "Dato demasiado largo")]
        [Remote("ValidaNombreItemLista", "Administracion", AdditionalFields = "grupo, editando")]
        public string nombre { get; set; }

        [Display(Name = "Grupo")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<byte> grupo { get; set; }

        [Display(Name = "Estado")]
        public Nullable<bool> activo { get; set; }

        [Display(Name = "Padre")]
        public Nullable<int> idpadre { get; set; }

        public IEnumerable<ItemLista> items { get; set; }
    }
    #endregion
}