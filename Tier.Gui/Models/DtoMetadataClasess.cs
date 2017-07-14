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
    public partial class Empresa { }

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

    public partial class EmpresaModel : Empresa
    {
        [Display(Name = "Logo")]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase ImageUpload { get; set; }
    }
    #endregion

    #region [Asesor]
    [MetadataType(typeof(AsesorMetadata))]
    public partial class Asesor { }

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
        [Required(ErrorMessage = "Dato requerido.")]
        [Remote("ValidaCodigoAsesor", "Comercial", AdditionalFields = "empresa_idempresa, editando, codigoinicial")]
        [RegularExpression(@"^\S+\w{1,16}$", ErrorMessage = "Máximo 16 caracteres sin espacios")]
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
    public partial class Maquina { }

    public partial class MaquinaMetadata
    {
        [Display(Name = "ID")]
        public Nullable<Int16> idmaquina { get; set; }

        [Display(Name = "Código")]
        [Required(ErrorMessage = "Dato requerido")]
        [RegularExpression(@"^\S+\w{1,16}$", ErrorMessage = "Máximo 16 caracteres sin espacios")]
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
        [Range(1, 10, ErrorMessage = "Dato inválido")]
        public Nullable<Single> turnos { get; set; }

        [Display(Name = "Consumo (kWh)")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<Single> consumonominal { get; set; }

        [Display(Name = "Largo máx (MP)")]
        [Range(0, 1000, ErrorMessage = "Dato inválido")]
        public Nullable<Single> largomaxmp { get; set; }

        [Display(Name = "Largo mín (MP)")]
        [Range(0, 1000, ErrorMessage = "Dato inválido")]
        public Nullable<Single> largominmp { get; set; }

        [Display(Name = "Ancho máx (MP)")]
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

        [Display(Name = "Valor plancha")]
        [Range(0, 1000000, ErrorMessage = "Dato inválido")]
        public Nullable<Single> valorplancha { get; set; }

        public IEnumerable<CotizarService.MaquinaVariacionProduccion> VariacionesProduccion { get; set; }

        public IEnumerable<CotizarService.MaquinaDatoPeriodico> DatosPeriodicos { get; set; }

    }

    public partial class MaquinaModel : Maquina
    {
        public string hfdCfgProduccion { get; set; }

        public string hfdDatosPeriodicos { get; set; }
    }
    #endregion

    #region [Máquina variacion]
    public partial class MaquinaVariacionProdMetadata : MaquinaVariacionProduccion
    {
        public Nullable<short> idMaquina { get; set; }

        public Nullable<int> idMaquinaVariacion { get; set; }

        public Nullable<int> tipoMaquina { get; set; }

        public string nombreMaquina { get; set; }

        public string nombreVariacion { get; set; }

        public string nombreMezclado { get; set; }

        public Nullable<int> numeroTintas { get; set; }
    }
    #endregion

    #region [Usuario]
    [MetadataType(typeof(UsuarioMetadata))]
    public partial class Usuario { }

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
    public partial class Rol { }

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

    public partial class RolModel : Rol
    {
        public string hfdPermisosSeleccionados { get; set; }
    }
    #endregion

    #region [ItemLista]
    [MetadataType(typeof(ItemListaMetadata))]
    public partial class ItemLista { }

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
    public partial class Cliente { }

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
        public Nullable<byte> empresa_idempresa { get; set; }

        [Display(Name = "Asesor")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<byte> asesor_idasesor { get; set; }

        [Display(Name = "Nuevo")]
        public Nullable<bool> nuevo { get; set; }

        [Display(Name = "Calificacion")]
        [StringLength(4, ErrorMessage = "Dato demasiado largo")]
        [Required(ErrorMessage = "Dato requerido")]
        public string calificacion { get; set; }
    }
    #endregion

    #region [Troquel]
    [MetadataType(typeof(TroquelMetadata))]
    public partial class Troquel { }

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

        [Display(Name = "Cuchilla Fibra")]
        [Range(1, 1000, ErrorMessage = "Dato inválido")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<Single> fibra { get; set; }

        [Display(Name = "Cuchilla Contrafibra")]
        [Range(1, 1000, ErrorMessage = "Dato inválido")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<Single> contrafibra { get; set; }

        [Display(Name = "Cabida a fibra")]
        [Required(ErrorMessage = "Dato requerido")]
        [Range(1, 100, ErrorMessage = "Dato inválido")]
        public Nullable<Single> cabidafibra { get; set; }

        [Display(Name = "Cabida a Contrafibra")]
        [Required(ErrorMessage = "Dato requerido")]
        [Range(1, 100, ErrorMessage = "Dato inválido")]
        public Nullable<Single> cabidacontrafibra { get; set; }

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

        [Display(Name = "Estilo")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<int> estilo_idestilo { get; set; }
    }

    public partial class TroquelModel : Troquel
    {
        public string hfdVentanas { get; set; }
    }
    #endregion

    #region [Pantones]
    [MetadataType(typeof(PantoneMetadata))]
    public partial class Pantone { }

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
        [RegularExpression("^(([0-9a-fA-F]{2}){3}|([0-9a-fA-F]){3})$", ErrorMessage = "Color no es HEX")]
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
    public partial class Proveedor { }

    public partial class ProveedorMetadata
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

    public class ProveedorModel : Proveedor
    {
        public string hfdlineas { get; set; }
    }
    #endregion

    #region [Insumos]
    [MetadataType(typeof(InsumoMetadata))]
    public partial class Insumo { }

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
        [Required(ErrorMessage = "Dato requerido")]
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
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<Single> conversionflete { get; set; }
    }
    #endregion

    #region [Producto]
    [MetadataType(typeof(ProductoMetadata))]
    public partial class Producto { }

    public partial class ProductoMetadata
    {
        [Display(Name = "Id")]
        public Nullable<int> idproducto { get; set; }

        [Display(Name = "Referencia")]
        [Required(ErrorMessage = "Dato requerido")]
        [Remote("ValidarReferenciaCliente", "Produccion", AdditionalFields = "cliente_idcliente, editando, referenciaclienteinicial")]
        public string referenciacliente { get; set; } //OK

        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<int> cliente_idcliente { get; set; } //OK

        [Display(Name = "Observaciones")]
        public string observaciones { get; set; } //OK

        [Display(Name = "Factor precio")]
        public Nullable<Single> factorprecio { get; set; } //OK

        [Display(Name = "Cantidad predeterminada")]
        public Nullable<short> catidadpredeterminada { get; set; } //OK

        [Display(Name = "Precio predeterminado")]
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

        [Display(Name = "Cabida ancho")]
        [Required(ErrorMessage = "Dato requerido")]
        [Range(0, 127)]
        public Nullable<byte> cabidaancho { get; set; } //OK

        [Display(Name = "Cabida largo")]
        [Required(ErrorMessage = "Dato requerido")]
        [Range(0, 127)]
        public Nullable<byte> cabidalargo { get; set; } //OK

        [Display(Name = "Acetato")]
        public Nullable<int> insumo_idinsumo_acetato { get; set; } //OK

        [Display(Name = "Acabado derecho")]
        public Nullable<int> insumo_idinsumo_acabadoderecho { get; set; } //OK

        [Display(Name = "Ancho acabado derecho")]
        public Nullable<Single> anchomaquina_acabadoderecho { get; set; } //OK

        [Display(Name = "Recorrido acabado derecho")]
        public Nullable<Single> recorrido_acabadoderecho { get; set; } //OK

        [Display(Name = "Acabado reverso")]
        public Nullable<int> insumo_idinsumo_acabadoreverso { get; set; } //OK

        [Display(Name = "Ancho acabado reverso")]
        public Nullable<Single> anchomaquina_acabadoreverso { get; set; } //OK

        [Display(Name = "Recorrido acabado reverso")]
        public Nullable<Single> recorrido_acabadoreverso { get; set; } //OK

        [Display(Name = "Posición planchas ")]
        [StringLength(512, ErrorMessage = "Dato demasiado largo")]
        public string posicionplanchas { get; set; } //OK

        [Display(Name = "Pasadas litográficas")]
        [Range(0, 127)]
        public Nullable<byte> pasadaslitograficas { get; set; } //OK

        [Display(Name = "Imagen arte gráfico")]
        public string imagenartegrafico { get; set; } //OK

        [Display(Name = "Pinza litográfica")]
        public Nullable<bool> pinzalitografica { get; set; }

        [Display(Name = "Colaminado cartón")]
        public Nullable<int> insumo_idinsumo_colaminado { get; set; } //OK

        [Display(Name = "Colaminado pegante")]
        public Nullable<int> insumo_idinsumo_colaminadopegante { get; set; } //OK

        [Display(Name = "Colaminado ancho")]
        public Nullable<Single> colaminadoancho { get; set; } //OK

        [Display(Name = "Colaminado largo")]
        [Range(1, 1000)]
        public Nullable<Single> colaminadoalargo { get; set; } //OK

        [Display(Name = "Colaminado cabida largo")]
        public Nullable<byte> colaminadocabidalargo { get; set; } //OK

        [Display(Name = "Colaminado cabida ancho")]
        public Nullable<byte> colaminadocabidaancho { get; set; } //OK

        [Display(Name = "Reempaque")]
        public Nullable<int> insumo_idinsumo_reempaque { get; set; } //OK

        [Display(Name = "Reempaque factor rendimiento")]
        [Range(1, 32766)]
        public Nullable<short> factorrendimientoreempaque { get; set; } //OK

        [Display(Name = "Máquina ruta conversión")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<short> maquinavariprod_idVariacion_rutaconversion { get; set; }

        [Display(Name = "Máquina ruta guillotinado")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<short> maquinavariprod_idVariacion_rutaguillotinado { get; set; }

        [Display(Name = "Máquina ruta litografía")]
        public Nullable<short> maquinavariprod_idVariacion_rutalitografia { get; set; }

        [Display(Name = "Máquina ruta acabado derecho")]
        public Nullable<short> maquinavariprod_idVariacion_rutaacabadoderecho { get; set; }

        [Display(Name = "Máquina ruta acabado reverso")]
        public Nullable<short> maquinavariprod_idVariacion_rutaacabadoreverso { get; set; }

        [Display(Name = "Máquina ruta colaminado")]
        public Nullable<short> maquinavariprod_idVariacion_rutacolaminado { get; set; }

        [Display(Name = "Máquina ruta troquelado")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<short> maquinavariprod_idVariacion_rutatroquelado { get; set; }

        [Display(Name = "Nuevo")]
        public Nullable<bool> nuevo { get; set; }

        [Display(Name = "Activo")]
        public Nullable<bool> activo { get; set; }

        [Display(Name = "Fecha creación")]
        public Nullable<DateTime> fechacreacion { get; set; }

        [Display(Name = "Valor troquel")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<Single> costotroquel { get; set; }

        public IEnumerable<Tier.Gui.CotizarService.ProductoAccesorio> accesorios { get; set; }

        public IEnumerable<Tier.Gui.CotizarService.ProductoEspectro> espectro { get; set; }

        public IEnumerable<Tier.Gui.CotizarService.ProductoPegue> pegues { get; set; }
    }

    public partial class ProductoModel : Producto
    {
        public string hdfAccesorios { get; set; }

        public string hdfEspectro { get; set; }

        public string hdfPegues { get; set; }

        public HttpPostedFileBase imgPrdto { get; set; }
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
        [RegularExpression(@"^\S+\w{1,16}$", ErrorMessage = "Máximo 16 caracteres sin espacios")]
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
        [Remote("ValidaNombrePeriodo", "Administracion", AdditionalFields = "nombreinicial, empresa_idempresa, editando")]
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
        [Range(0, 100, ErrorMessage = "Dato inválido")]
        public Nullable<Single> porcenfinanciacion { get; set; }

        [Display(Name = "% Alza general")]
        [Required(ErrorMessage = "Dato requerido")]
        [Range(0, 100, ErrorMessage = "Dato inválido")]
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

    #region [Cotizacion]
    [MetadataType(typeof(CotizacionMetadata))]
    public partial class Cotizacion { }

    public partial class CotizacionMetadata
    {
        [Display(Name = "ID")]
        public Nullable<int> idcotizacion { get; set; }

        [Display(Name = "Activo")]
        public Nullable<bool> activo { get; set; }

        [Display(Name = "Fecha creación")]
        public Nullable<DateTime> fechacreacion { get; set; }

        [Display(Name = "Cliente")]
        public Nullable<int> cliente_idcliente { get; set; }

        [Display(Name = "Período")]
        public Nullable<int> periodo_idPeriodo { get; set; }

        [Display(Name = "Observaciones")]
        public string observaciones { get; set; }

        [Display(Name = "Costo planchas")]
        public Nullable<Single> costosplancha { get; set; }

        [Display(Name = "Costo troqueles")]
        public Nullable<Single> costostroqueles { get; set; }

        [Display(Name = "Estado")]
        public Nullable<int> itemlista_iditemlista_estado { get; set; }

        public IEnumerable<CotizacionDetalle> detalle { get; set; }
    }

    public partial class CotizacionModelo : Cotizacion
    {
        [Required]
        public string hdfProdCotizar { get; set; }
    }
    #endregion

    #region [CotizacionDetalle]
    [MetadataType(typeof(CotizacionDetalleMetadata))]
    public partial class CotizacionDetalle { }

    public partial class CotizacionDetalleMetadata
    {
        [Display(Name = "ID Detalle")]
        public Nullable<int> idcotizacion_detalle { get; set; }

        [Display(Name = "Fecha creación")]
        public Nullable<DateTime> fechacreacion { get; set; }

        [Display(Name = "Activo")]
        public Nullable<bool> activo { get; set; }

        [Display(Name = "Id Cotización")]
        public Nullable<int> cotizacion_idcotizacion { get; set; }

        [Display(Name = "Producto")]
        public Nullable<int> producto_idproducto { get; set; }

        [Display(Name = "Perímetro Flete")]
        public Nullable<int> insumo_idinsumo_flete { get; set; }

        [Display(Name = "Escala")]
        public Nullable<Single> escala { get; set; }

        [Display(Name = "Área cartón caja")]
        public Nullable<Single> areacartoncaja { get; set; }

        [Display(Name = "Área acabado derecho")]
        public Nullable<Single> areaacader { get; set; }

        [Display(Name = "Área acabado reverso")]
        public Nullable<Single> areaacarev { get; set; }

        [Display(Name = "Cabida conversión")]
        public Nullable<byte> cabidaconversion { get; set; }

        [Display(Name = "Cabida troquel")]
        public Nullable<byte> cabidatroquel { get; set; }

        [Display(Name = "Num tintas")]
        public Nullable<byte> canttintas { get; set; }

        [Display(Name = "Costo reempaque")]
        public Nullable<Single> costoreempaque { get; set; }

        [Display(Name = "Costo accesorios")]
        public Nullable<Single> costoaccesorios { get; set; }

        [Display(Name = "Costo flete")]
        public Nullable<Single> costoflete { get; set; }

        [Display(Name = "Costo acetato")]
        public Nullable<Single> costoacetato { get; set; }

        [Display(Name = "Costo cartón caja")]
        public Nullable<Single> costocartoncaja { get; set; }

        [Display(Name = "Costo cartón colaminado")]
        public Nullable<Single> costocartoncolaminado { get; set; }

        [Display(Name = "Costo tintas")]
        public Nullable<Single> costotintas { get; set; }

        [Display(Name = "Costo acabado derecho")]
        public Nullable<Single> costoacabadoder { get; set; }

        [Display(Name = "Costo acabado reverso")]
        public Nullable<Single> costoacabadorev { get; set; }

        [Display(Name = "Costo pegante")]
        public Nullable<Single> costopegante { get; set; }

        [Display(Name = "Costo pliegos desperdicio")]
        public Nullable<Single> costopliegosdesper { get; set; }

        [Display(Name = "Costo proceso pegue")]
        public Nullable<Single> costoprocpegue { get; set; }

        [Display(Name = "Costo proceso acabado derecho")]
        public Nullable<Single> costoprocacabadoder { get; set; }

        [Display(Name = "Costo proceso acabado reverso")]
        public Nullable<Single> costoprocacabadorev { get; set; }

        [Display(Name = "Costo proceso conversión")]
        public Nullable<Single> costoprocconversion { get; set; }

        [Display(Name = "Costo proceso litografía")]
        public Nullable<Single> costoproclitografia { get; set; }

        [Display(Name = "Costo proceso troqelado")]
        public Nullable<Single> costoproctroqelado { get; set; }

        [Display(Name = "Costo proceso colaminado")]
        public Nullable<Single> costoproccolaminado { get; set; }

        [Display(Name = "Costo proceso guillotinado")]
        public Nullable<Single> costoprocguillotinado { get; set; }

        [Display(Name = "Costo aporte gasto")]
        public Nullable<Single> costoaportegastounidad { get; set; }

        [Display(Name = "Costo total materiales")]
        public Nullable<Single> costototalmaterialunidad { get; set; }

        [Display(Name = "Costo total procesos")]
        public Nullable<Single> costototalprocesosunidad { get; set; }

        [Display(Name = "Costo total fabricación")]
        public Nullable<Single> costototalfabricacion { get; set; }

        [Display(Name = "Costo desperdicio caja")]
        public Nullable<Single> costodesperdiciocaja { get; set; }

        [Display(Name = "Porcentaje desperdicio caja")]
        public Nullable<Single> porcedesperdiciocaja { get; set; }

        [Display(Name = "Porcentaje alza general")]
        public Nullable<Single> porcealzageneral { get; set; }

        [Display(Name = "Porcentaje ica + cree")]
        public Nullable<Single> porceicacree { get; set; }

        [Display(Name = "Porcentaje comisión asesor")]
        public Nullable<Single> porcecomisionasesor { get; set; }

        [Display(Name = "Porcentaje admon financiación")]
        public Nullable<Single> porceadmfinanciacion { get; set; }

        [Display(Name = "Porcentaje alza precio")]
        public Nullable<Single> porceprecioproducto { get; set; }

        [Display(Name = "Costo neto")]
        public Nullable<Single> costonetocaja { get; set; }

        public string observaciones { get; set; }
    }
    #endregion

    #region [Pedido]
    [MetadataType(typeof(PedidoMetadata))]
    public partial class Pedido { }

    public partial class PedidoMetadata
    {
        [Display(Name = "ID")]
        public Nullable<int> idpedido { get; set; }

        [Display(Name = "Activo")]
        public Nullable<bool> activo { get; set; }

        [Display(Name = "Fecha creación")]
        public Nullable<DateTime> fechacreacion { get; set; }

        [Display(Name = "Cotización")]
        public Nullable<int> cotizacion_idcotizacion { get; set; }

        [Display(Name = "Costos planchas")]
        public Nullable<Single> costosplancha { get; set; }

        [Display(Name = "Costos troqueles")]
        public Nullable<Single> costostroqueles { get; set; }

        [Display(Name = "Observaciones")]
        public string observaciones { get; set; }

        [Display(Name = "Estado")]
        public Nullable<int> itemlista_iditemlista_estado { get; set; }

        public IEnumerable<CotizarService.PedidoDetalle> detalle { get; set; }

        [Display(Name = "# SIIGO")]
        [StringLength(16, ErrorMessage = "Dato demasiado largo")]
        public string identificadorsiigo { get; set; }
    }

    public partial class PedidoModel : Pedido
    {
        public string hfddetalle { get; set; }
    }

    [MetadataType(typeof(PedidoGestionMetadata))]
    public partial class PedidoGestion { }

    public partial class PedidoGestionMetadata
    {
        [Display(Name = "ID")]
        public Nullable<int> idpedido { get; set; }

        [Display(Name = "F. Pedido")]
        public Nullable<DateTime> fechapedido { get; set; }

        [Display(Name = "Cotización")]
        public Nullable<int> idcotizacion { get; set; }

        [Display(Name = "F. Cotización")]
        public Nullable<DateTime> fechacotizacion { get; set; }

        [Display(Name = "ID SIIGO")]
        public string identificadorsiigo { get; set; }

        [Display(Name = "Estado")]
        public string estadopedido { get; set; }

        [Display(Name = "Cliente")]
        public string cliente { get; set; }

        [Display(Name = "Asesor")]
        public string asesor { get; set; }
    }

    #endregion

    #region [PedidoDetalle]
    [MetadataType(typeof(PedidoDetalleMetadata))]
    public partial class PedidoDetalle { }

    public partial class PedidoDetalleMetadata
    {
        [Display(Name = "ID")]
        public Nullable<int> idpedido_detalle { get; set; }

        [Display(Name = "Ativo")]
        public Nullable<bool> activo { get; set; }

        [Display(Name = "Fecha creación")]
        public Nullable<DateTime> fechacreacion { get; set; }

        [Display(Name = "Pedido")]
        public Nullable<int> pedido_idpedido { get; set; }

        [Display(Name = "Cotización detalle")]
        public Nullable<int> cotizacion_detalle_idcotizacion_detalle { get; set; }

        [Display(Name = "Observaciones")]
        public string observaciones { get; set; }
    }
    #endregion

    #region [Cartera]
    [MetadataType(typeof(CarteraMetadata))]
    public partial class Cartera { }

    public partial class CarteraMetadata
    {
        [Display(Name = "Cliente")]
        public Nullable<int> cliente_idcliente { get; set; }

        [Display(Name = "Asesor")]
        public Nullable<int> asesor_idasesor { get; set; }

        [Display(Name = "Cuenta")]
        public string cuenta { get; set; }

        [Display(Name = "Factura")]
        public string documento { get; set; }

        [Display(Name = "Consecutivo")]
        public Nullable<byte> consecutivo { get; set; }

        [Display(Name = "Fecha factura")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<DateTime> fecha { get; set; }

        [Display(Name = "Fecha vencimiento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<DateTime> vencimiento { get; set; }

        [Display(Name = "Días")]
        public Nullable<double> dias { get; set; }

        [Display(Name = "Valor mora")]
        public Nullable<Single> valormora { get; set; }

        [Display(Name = "Valor saldo")]
        public Nullable<Single> valorsaldo { get; set; }

        [Display(Name = "Activo")]
        public Nullable<bool> activo { get; set; }

        [Display(Name = "Fecha cración")]
        public Nullable<DateTime> fechacracion { get; set; }

        [Display(Name = "Fila excel")]
        public Nullable<int> filaarchivo { get; set; }
    }

    public partial class CarteraModel : Cartera
    {
        [Display(Name = "Archivo excel cartera SIIGO:")]
        [Required(ErrorMessage = "Dato requerido")]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase DataFileUpload { get; set; }
    }
    #endregion

    #region [Estilo Troquel]
    [MetadataType(typeof(EstiloMetadata))]
    public partial class Estilo { }

    public partial class EstiloMetadata
    {
        [Display(Name = "ID")]
        public Nullable<int> idestilo { get; set; }

        [Display(Name = "Código")]
        [Required(ErrorMessage = "Dato requerido")]
        [RegularExpression(@"^\S+\w{1,8}$", ErrorMessage = "Máximo 8 caracteres sin espacios")]
        [Remote("ValidaCodigoEstilo", "Produccion", null, AdditionalFields = "empresa_idempresa, editando, codigoinicial")]
        public string codigo { get; set; }

        [Display(Name = "Nombre")]
        [StringLength(256, ErrorMessage = "Dato demasiado largo")]
        [Required(ErrorMessage = "Dato requerido")]
        public string nombre { get; set; }

        [Display(Name = "Corte troquel")]
        [StringLength(1024, ErrorMessage = "Dato demasiado largo")]
        public string nombreimagen { get; set; }

        [Display(Name = "Fecha creación")]
        public Nullable<DateTime> fechacreacion { get; set; }

        [Display(Name = "Activo")]
        public Nullable<bool> activo { get; set; }

        public IEnumerable<CotizarService.EstiloPegue> pegues { get; set; }
    }

    public partial class EstiloModel : Estilo
    {
        public string hfdpegues { get; set; }

        [Display(Name = "Imagen corte")]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase ImageUpload { get; set; }
    }
    #endregion
}