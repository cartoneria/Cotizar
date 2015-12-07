using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Tier.Gui.CotizarService
{
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
        [RegularExpression(@"^\S+\w{1,8}$", ErrorMessage = "Máximo 8 caracteres sin espacios")]
        [Remote("ValidaCodigoMaquina", "Produccion", AdditionalFields = "empresa_idempresa, editando, codigoinicial")]
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
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<Single> areaancho { get; set; }

        [Display(Name = "Largo  (Área)")]
        [Range(0, 1000, ErrorMessage = "Dato inválido")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<Single> arealargo { get; set; }

        [Display(Name = "Turnos")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<byte> turnos { get; set; }

        [Display(Name = "Consumo (kWh)")]
        [Required(ErrorMessage = "Dato requerido")]
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

        [Display(Name = "No. Tintas")]
        [Range(1, 10, ErrorMessage = "Dato inválido")]
        public Nullable<byte> numerotintas { get; set; }

        public IEnumerable<CotizarService.MaquinaVariacionProduccion> VariacionesProduccion { get; set; }

        public IEnumerable<CotizarService.MaquinaDatoPeriodico> DatosPeriodicos { get; set; }

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
        [RegularExpression(@"^\S+\w{5,16}$", ErrorMessage = "Minimo 5 caracteres sin espacios")]
        [StringLength(16, ErrorMessage = "Dato demasiado largo")]
        [Remote("ValidaNombreUsuario", "Administracion", AdditionalFields = "editando, usuarioinicial")]
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
        [Remote("ValidaNombreRol", "Administracion", AdditionalFields = "editando, nombreinicial")]
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
        public string hfdPermisosSeleccionados { get; set; }
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
        [Remote("ValidaNombreItemLista", "Administracion", AdditionalFields = "grupo, editando, nombreinicial")]
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

    #region [Cliente]
    [MetadataType(typeof(ClienteMetadata))]
    public partial class Cliente
    {

    }

    public partial class ClienteMetadata
    {
        [Display(Name = "ID")]
        public Nullable<int> idcliente { get; set; }

        [Display(Name = "Identificación")]
        [StringLength(16, ErrorMessage = "Dato demasiado largo")]
        public string identificacion { get; set; }

        [Display(Name = "Tipo")]
        public Nullable<int> itemlista_iditemlista_tipoidenti { get; set; }

        [Display(Name = "Nombre/Razón Social")]
        [Required(ErrorMessage = "Dato requerido")]
        [StringLength(512, ErrorMessage = "Dato demasiado largo")]
        [Remote("ValidaNombreCliente", "Comercial", AdditionalFields = "editando, nombreinicial")]
        public string nombre { get; set; }

        [Display(Name = "Dirección")]
        [StringLength(512, ErrorMessage = "Dato demasiado largo")]
        public string direccion { get; set; }

        [Display(Name = "Municipio")]
        public string municipio_idmunicipio { get; set; }

        [Display(Name = "Departamento")]
        public string municipio_departamento_iddepartamento { get; set; }

        [Display(Name = "Plazo pagos (Dias)")]
        [Range(0, 240, ErrorMessage = "Dato inválido")]
        public Nullable<byte> diasplazo { get; set; }

        [Display(Name = "Cupo de crédito")]
        [Range(0, 1000000000, ErrorMessage = "Dato inválido")]
        public Nullable<Single> cupocredito { get; set; }

        [Display(Name = "Regimen tributario")]
        public Nullable<int> itemlista_iditemlista_regimen { get; set; }

        [Display(Name = "Forma de pago")]
        public Nullable<int> itemlista_iditemlista_formapago { get; set; }

        public string contactos { get; set; }

        [Display(Name = "Observaciones")]
        public string observaciones { get; set; }

        [Display(Name = "Activo")]
        public Nullable<bool> activo { get; set; }

        [Display(Name = "Fecha creación")]
        public Nullable<DateTime> fechacreacion { get; set; }

        [Display(Name = "Empresa")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<int> empresa_idempresa { get; set; }
    }
    #endregion

    #region [Troquel]
    [MetadataType(typeof(TroquelMetadata))]
    public partial class Troquel
    {

    }

    public partial class TroquelMetadata
    {
        [Display(Name = "ID")]
        public Nullable<int> idtroquel { get; set; }

        [Display(Name = "Descripción")]
        [StringLength(512, ErrorMessage = "Dato demasiado largo")]
        [Required(ErrorMessage = "Dato requerido")]
        public string descripcion { get; set; }

        [Display(Name = "Material")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<int> itemlista_iditemlista_material { get; set; }

        [Display(Name = "Modelo")]
        [StringLength(8, ErrorMessage = "Dato demasiado largo")]
        [Required(ErrorMessage = "Dato requerido")]
        public string modelo { get; set; }

        [Display(Name = "Tamaño")]
        [Required(ErrorMessage = "Dato requerido")]
        public string tamanio { get; set; }

        [Display(Name = "Largo")]
        [Range(0, 1000, ErrorMessage = "Dato inválido")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<Single> largo { get; set; }

        [Display(Name = "Ancho")]
        [Range(0, 1000, ErrorMessage = "Dato inválido")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<Single> ancho { get; set; }

        [Display(Name = "Alto")]
        [Range(0, 1000, ErrorMessage = "Dato inválido")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<Single> alto { get; set; }

        [Display(Name = "Fibra")]
        [Range(0, 1000, ErrorMessage = "Dato inválido")]
        public Nullable<Single> fibra { get; set; }

        [Display(Name = "Contrafibra")]
        [Range(0, 1000, ErrorMessage = "Dato inválido")]
        public Nullable<Single> contrafibra { get; set; }

        [Display(Name = "Cabida a fibra")]
        [Range(0, 100, ErrorMessage = "Dato inválido")]
        public Nullable<byte> cabidafibra { get; set; }

        [Display(Name = "Cabida a Contrafibra")]
        [Range(0, 100, ErrorMessage = "Dato inválido")]
        public Nullable<byte> cabidacontrafibra { get; set; }

        public IEnumerable<Tier.Gui.CotizarService.TroquelVentana> ventanas { get; set; }

        [Display(Name = "Ubicación")]
        public string ubicacion { get; set; }

        [Display(Name = "Marcación")]
        public string marca { get; set; }

        [Display(Name = "Observaciones")]
        public string observaciones { get; set; }

        [Display(Name = "Fecha de creación")]
        public Nullable<DateTime> fechacreacion { get; set; }

        [Display(Name = "Activo")]
        public Nullable<bool> activo { get; set; }

        [Display(Name = "Empresa")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<byte> empresa_idempresa { get; set; }

        [Display(Name = "Imagen")]
        public string nombreimagen { get; set; }
    }

    public partial class TroquelModel : TroquelMetadata
    {
        public string hfdVentanas { get; set; }

        public HttpPostedFileBase imgFile { get; set; }

    }
    #endregion

    #region [Pantones]
    [MetadataType(typeof(PantoneMetadata))]
    public partial class Pantone
    {

    }

    public partial class PantoneMetadata
    {
        [Display(Name = "ID")]
        public Nullable<int> idpantone { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Dato requerido")]
        [StringLength(16, ErrorMessage = "Dato demasiado largo")]
        [Remote("ValidaNombrePantone", "Produccion", AdditionalFields = "nombreinicial, empresa_idempresa, editando")]
        public string nombre { get; set; }

        [Display(Name = "HEX")]
        [Required(ErrorMessage = "Dato requerido")]
        //[RegularExpression("/(^#[0-9A-F]{6}$)|(^#[0-9A-F]{3}$)/i.test('#ac3')", ErrorMessage = "Color no es HEX")]
        [Remote("ValidaColorHEXPantone", "Produccion", AdditionalFields = "hexinicial, empresa_idempresa, editando")]
        public string hex { get; set; }

        [Display(Name = "Red")]
        [Required(ErrorMessage = "Dato requerido")]
        [Range(0, 255, ErrorMessage = "Dato inválido")]
        public Nullable<short> r { get; set; }

        [Display(Name = "Green")]
        [Required(ErrorMessage = "Dato requerido")]
        [Range(0, 255, ErrorMessage = "Dato inválido")]
        public Nullable<short> g { get; set; }

        [Display(Name = "Blue")]
        [Required(ErrorMessage = "Dato requerido")]
        [Range(0, 255, ErrorMessage = "Dato inválido")]
        public Nullable<short> b { get; set; }

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "Dato requerido")]
        [Range(0, 500000, ErrorMessage = "Dato inválido")]
        public Nullable<Single> valor { get; set; }

        [Display(Name = "Empresa")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<byte> empresa_idempresa { get; set; }
    }
    #endregion

    #region [Proveedores]
    [MetadataType(typeof(ProveedorMetadata))]
    public partial class Proveedor
    {

    }

    public partial class ProveedorMetadata : Proveedor
    {
        [Display(Name = "ID")]
        public Nullable<int> idproveedor { get; set; }

        [Display(Name = "Nombre")]
        [StringLength(512, ErrorMessage = "Dato demasiado largo")]
        [Required(ErrorMessage = "Dato requerido")]
        public string nombre { get; set; }

        [Display(Name = "Fecha de creación")]
        public Nullable<DateTime> fechacreacion { get; set; }

        [Display(Name = "Activo")]
        public Nullable<bool> activo { get; set; }

        [Display(Name = "Empresa")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<byte> empresa_idempresa { get; set; }

        public IEnumerable<CotizarService.ProveedorLinea> lineas { get; set; }
    }

    public class ProveedorModel : ProveedorMetadata
    {
        public string hfdlineas { get; set; }
    }
    #endregion

    #region [Insumos]
    [MetadataType(typeof(InsumoMetadata))]
    public partial class Insumo
    {

    }

    public class InsumoMetadata
    {
        [Display(Name = "ID")]
        public Nullable<int> idinsumo { get; set; }

        [Display(Name = "Linea")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<int> proveedor_linea_idproveedor_linea { get; set; }

        [Display(Name = "Proveedor")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<int> proveedor_linea_proveedor_idproveedor { get; set; }

        [Display(Name = "Ancho")]
        [Range(0, 1000, ErrorMessage = "Dato inválido")]
        public Nullable<Single> ancho { get; set; }

        [Display(Name = "Tipo")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<int> itemlista_iditemlista_tipo { get; set; }

        [Display(Name = "Calibre")]
        [Range(0, 1000, ErrorMessage = "Dato inválido")]
        public Nullable<Single> calibre { get; set; }

        [Display(Name = "Unidad de compra")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<int> itemlista_iditemlista_unimedcomp { get; set; }

        [Display(Name = "Valor de compra")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<Single> valor { get; set; }

        [Display(Name = "Factor de rendimiento")]
        [Required(ErrorMessage = "Dato requerido")]
        [Range(0, 1000000, ErrorMessage = "Dato inválido")]
        public Nullable<Single> factorrendimiento { get; set; }

        [Display(Name = "Unidad de rendimiento")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<int> itemlista_iditemlista_unimedrendi { get; set; }

        [Display(Name = "Observaciones")]
        public string observaciones { get; set; }

        [Display(Name = "Fecha de creación")]
        public Nullable<DateTime> fechacreacion { get; set; }

        [Display(Name = "Activo")]
        public Nullable<bool> activo { get; set; }

        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Display(Name = "Valor flete")]
        [Range(0, 1000000, ErrorMessage = "Dato inválido")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<Single> valorflete { get; set; }

        [Display(Name = "Empresa")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<byte> empresa_idempresa { get; set; }

        [Display(Name = "Factor conv. flete")]
        [Range(0, 1000000, ErrorMessage = "Dato inválido")]
        public Nullable<Single> conversionflete { get; set; }
    }
    #endregion

    #region [Producto]
    [MetadataType(typeof(ProductoMetadata))]
    public partial class Producto
    {

    }

    public partial class ProductoMetadata
    {
        [Display(Name = "Id")]
        public Nullable<int> idproducto { get; set; }

        [Display(Name = "Referencia cliente")]
        [Required(ErrorMessage = "Dato requerido")]
        public string referenciacliente { get; set; } //OK

        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<int> cliente_idcliente { get; set; } //OK

        [Display(Name = "Observaciones")]
        [Required(ErrorMessage = "Dato requerido")]
        public string observaciones { get; set; } //OK

        [Display(Name = "Factor precio")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<Single> factorprecio { get; set; } //OK

        [Display(Name = "Cantidad predeterminada")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<short> catidadpredeterminada { get; set; } //OK

        [Display(Name = "Precio predeterminado")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<Single> preciopredeterminado { get; set; } //OK

        [Display(Name = "Troquel")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<int> troquel_idtroquel { get; set; }

        [Display(Name = "Material")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<int> insumo_idinsumo_material { get; set; }

        [Display(Name = "Largo de bobina")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<Single> largobobina { get; set; }

        [Display(Name = "Ancho de bobina")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<Single> anchobobina { get; set; }

        [Display(Name = "Ancho cabida")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<byte> cabidaancho { get; set; } //OK

        [Display(Name = "Largo cabida")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<byte> cabidalargo { get; set; } //OK

        [Display(Name = "Acetato")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<int> insumo_idinsumo_acetato { get; set; } //OK

        [Display(Name = "Acabado derecho")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<int> itemlista_iditemlista_acabadoderecho { get; set; } //OK

        [Display(Name = "Ancho maquina acabado derecho")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<Single> anchomaquina_acabadoderecho { get; set; } //OK

        [Display(Name = "Recorrido acabado derecho")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<Single> recorrido_acabadoderecho { get; set; } //OK

        [Display(Name = "Acabado reverso")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<int> itemlista_iditemlista_acabadoreverso { get; set; } //OK

        [Display(Name = "Acabado reverso")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<Single> anchomaquina_acabadoreverso { get; set; } //OK

        [Display(Name = "Recorrido acabado reverso")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<Single> recorrido_acabadoreverso { get; set; } //OK

        [Display(Name = "Posición planchas ")]
        [StringLength(512, ErrorMessage = "Dato demasiado largo")]
        [Required(ErrorMessage = "Dato requerido")]
        public string posicionplanchas { get; set; } //OK

        [Display(Name = "Pasadas litograficas")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<byte> pasadaslitograficas { get; set; } //OK

        [Display(Name = "Imagen arte gráfico")]
        public string imagenartegrafico { get; set; } //OK

        [Display(Name = "Pinza litografica")]
        public Nullable<bool> pinzalitografica { get; set; }

        [Display(Name = "Insumo colaminado")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<int> insumo_idinsumo_colaminado { get; set; } //OK

        [Display(Name = "Colaminado ancho")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<Single> colaminadoancho { get; set; } //OK

        [Display(Name = "Colaminado largo")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<Single> colaminadoalargo { get; set; } //OK

        [Display(Name = "Colaminado cabida largo")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<byte> colaminadocabidalargo { get; set; } //OK

        [Display(Name = "Insumo reempaque")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<int> insumo_idinsumo_reempaque { get; set; } //OK

        [Display(Name = "Factor rendimiento reempaque")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<byte> factorrendimientoreempaque { get; set; } //OK

        [Display(Name = "Maquina ruta conversión")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<short> maquina_idmaquina_rutaconversion { get; set; }

        [Display(Name = "Maquina ruta conversión")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<short> maquina_idmaquina_rutaguillotinado { get; set; }

        [Display(Name = "Maquina ruta conversión")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<short> maquina_idmaquina_rutalitografia { get; set; }

        [Display(Name = "Maquina ruta conversión")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<short> maquina_idmaquina_rutaplastificado { get; set; }

        [Display(Name = "Maquina ruta conversión")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<short> maquina_idmaquina_rutacolaminado { get; set; }

        [Display(Name = "Maquina ruta conversión")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<short> maquina_idmaquina_rutatroquelado { get; set; }

        [Display(Name = "Maquina ruta conversión")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<short> maquina_idmaquina_rutapegue { get; set; }

        [Display(Name = "Activo")]
        public Nullable<bool> activo { get; set; }

        [Display(Name = "Fecha creación")]
        public Nullable<DateTime> fechacreacion { get; set; }

        public IEnumerable<Tier.Gui.CotizarService.ProductoAccesorio> accesorios { get; set; }

        public IEnumerable<Tier.Gui.CotizarService.ProductoEspectro> espectro { get; set; }

        public IEnumerable<Tier.Gui.CotizarService.ProductoPegue> pegues { get; set; }
    }

    public partial class ProductoModel : ProductoMetadata
    {
        public HttpPostedFileBase imgProducto { get; set; }

        public string hdfAccesorios { get; set; }

        public string hdfEspectro { get; set; }

        public string hdfPegues { get; set; }
    }

    #endregion

    #region [Accesorio]
    [MetadataType(typeof(AccesorioMetadata))]
    public partial class Accesorio { }

    public partial class AccesorioMetadata
    {
        [Display(Name = "ID")]
        public Nullable<int> idaccesorio { get; set; }

        [Display(Name = "Activo")]
        public Nullable<bool> activo { get; set; }

        [Display(Name = "Fecha creación")]
        public Nullable<DateTime> fechacreacion { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Dato requerido")]
        public string nombre { get; set; }

        [Display(Name = "Observaciones")]
        public string observaciones { get; set; }

        [Display(Name = "Observaciones de produccion")]
        public string observacionesproduccion { get; set; }

        [Display(Name = "Código")]
        [Remote("ValidaCodigoAccesorio", "Produccion", null, AdditionalFields = "editando, codigoinicial")]
        [Required(ErrorMessage = "Dato requerido")]
        public string codigo { get; set; }

        [Display(Name = "Precio")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<Single> precio { get; set; }

        [Display(Name = "Costo mano obra")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<Single> costomanoobra { get; set; }

        [Display(Name = "Empresa")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<int> empresa_idempresa { get; set; }
    }
    #endregion

    #region [Periodo]
    [MetadataType(typeof(PeriodoMetadata))]
    public partial class Periodo { }

    public partial class PeriodoMetadata
    {
        [Display(Name = "ID")]
        public Nullable<int> idPeriodo { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Dato requerido")]
        public string nombre { get; set; }

        [Display(Name = "Fecha inicio")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<DateTime> fechainicio { get; set; }

        [Display(Name = "Fecha fin")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<DateTime> fechafin { get; set; }

        [Display(Name = "Vigente")]
        public Nullable<bool> vigente { get; set; }

        [Display(Name = "Empresa")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<byte> empresa_idempresa { get; set; }

        [Display(Name = "Imp. ICA + CREE")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<Single> impuestoicacree { get; set; }

        [Display(Name = "% Financiación")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<Single> porcenfinanciacion { get; set; }

        [Display(Name = "% Alza general")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<Single> porcenalzageneral { get; set; }

        [Display(Name = "Gasto")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<Single> gasto { get; set; }

        [Display(Name = "Utilidad")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<Single> utilidad { get; set; }

        public IEnumerable<CotizarService.MaquinaDatoPeriodico> centros { get; set; }

        public IEnumerable<CotizarService.Parametro> parametros { get; set; }
    }

    public partial class PeriodoModel : Periodo
    {
        public string hfdcentros { get; set; }

        public string hfdparametros { get; set; }
    }

    public partial class ParametroPredefinido
    {
        public string nombre { get; set; }

        public byte tipo { get; set; }

        public string descripcion { get; set; }
    }
    #endregion
}