using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Tier.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICotizarService" in both code and config file together.
    [ServiceContract]
    public interface ICotizarService
    {
        #region [Empresas]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<Dto.Empresa> Empresa_RecuperarFiltrado(Dto.Empresa objFiltros);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="idempresa"></param>
        /// <returns></returns>
        [OperationContract]
        bool Empresa_Insertar(Dto.Empresa obj, out Nullable<byte> idempresa);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool Empresa_Actualizar(Dto.Empresa obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool Empresa_Eliminar(Dto.Empresa obj);
        #endregion

        #region [Roles]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<Dto.Rol> Rol_RecuperarFiltros(Dto.Rol objFiltros);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="idrol"></param>
        /// <returns></returns>
        [OperationContract]
        bool Rol_Insertar(Dto.Rol obj, out Nullable<Int16> idrol);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool Rol_Actualizar(Dto.Rol obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool Rol_Eliminar(Dto.Rol obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool Rol_ValidaNombre(Dto.Rol obj);
        #endregion

        #region [Listas]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<Dto.ItemLista> ItemLista_RecuperarFiltros(Dto.ItemLista objFiltros);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="iditemlista"></param>
        /// <returns></returns>
        [OperationContract]
        bool ItemLista_Insertar(Dto.ItemLista obj, out Nullable<int> iditemlista);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool ItemLista_Actualizar(Dto.ItemLista obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool ItemLista_Eliminar(Dto.ItemLista obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool ItemLista_ValidaNombre(Dto.ItemLista obj);
        #endregion

        #region [Usuarios]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<Dto.Usuario> Usuario_RecuperarFiltros(Dto.Usuario objFiltros);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="idusuario"></param>
        /// <returns></returns>
        [OperationContract]
        bool Usuario_Insertar(Dto.Usuario obj, out Nullable<Int16> idusuario);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool Usuario_Actualizar(Dto.Usuario obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool Usuario_Eliminar(Dto.Usuario obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool Usuario_RestablecerClave(Dto.Usuario obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool Usuario_CambiarClave(Dto.Usuario obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool Usuario_ValidaNombreUsuario(Dto.Usuario obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        Dto.Sesion Usuario_IniciarSesion(Dto.Usuario obj);

        [OperationContract]
        Dto.Sesion Usuario_ActualizarMenuUsuario(Dto.Usuario obj);
        #endregion

        #region [Maquinas]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<Dto.Maquina> Maquina_RecuperarFiltros(Dto.Maquina objFiltros);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="idmaquina"></param>
        /// <returns></returns>
        [OperationContract]
        bool Maquina_Insertar(Dto.Maquina obj, out Nullable<Int16> idmaquina);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool Maquina_Actualizar(Dto.Maquina obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool Maquina_Eliminar(Dto.Maquina obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool Maquina_ValidaCodigo(Dto.Maquina obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<Dto.RutaProduccion> Maquina_RecuperarRutasProduccionFiltros(Dto.RutaProduccion objFiltros);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<Dto.MaquinaVariacionProduccion> Maquina_RecuperarVariacionesProduccionFiltros(Dto.MaquinaVariacionProduccion objFiltros);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<Dto.MaquinaDatoPeriodico> Maquina_RecuperarDatosPeriodicosFiltros(Dto.MaquinaDatoPeriodico objFiltros);
        #endregion

        #region [Asesores]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<Dto.Asesor> Asesor_RecuperarFiltros(Dto.Asesor objFiltros);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="idasesor"></param>
        /// <returns></returns>
        [OperationContract]
        bool Asesor_Insertar(Dto.Asesor obj, out Nullable<byte> idasesor);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool Asesor_Actualizar(Dto.Asesor obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool Asesor_Eliminar(Dto.Asesor obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool Asesor_ValidaCodigo(Dto.Asesor obj);
        #endregion

        #region [Funcionalidad]

        [OperationContract]
        IEnumerable<Dto.Funcionalidad> Funcionalidad_RecuperarFiltros(Dto.Funcionalidad objFiltros);

        #endregion

        #region [Periodos]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<Dto.Periodo> Periodo_RecuperarFiltros(Dto.Periodo objFiltros);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="idperiodo"></param>
        /// <returns></returns>
        [OperationContract]
        bool Periodo_Insertar(Dto.Periodo obj, out Nullable<int> idperiodo);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool Periodo_Actualizar(Dto.Periodo obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool Periodo_Eliminar(Dto.Periodo obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool Periodo_ValidaNombre(Dto.Periodo obj);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        string Periodo_RecuperarParametrosPredefinidos();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<Dto.Parametro> Periodo_RecuperarParametrosFiltros(Dto.Parametro objFiltros);
        #endregion

        #region [Clientes]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<Dto.Cliente> Cliente_RecuperarFiltros(Dto.Cliente objFiltros);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="idcliente"></param>
        /// <returns></returns>
        [OperationContract]
        bool Cliente_Insertar(Dto.Cliente obj, out Nullable<int> idcliente);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool Cliente_Actualizar(Dto.Cliente obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool Cliente_Eliminar(Dto.Cliente obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool Cliente_ValidaNombre(Dto.Cliente obj);
        #endregion

        #region [Pantones]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<Dto.Pantone> Pantone_RecuperarFiltros(Dto.Pantone objFiltros);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="idpantone"></param>
        /// <returns></returns>
        [OperationContract]
        bool Pantone_Insertar(Dto.Pantone obj, out Nullable<int> idpantone);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool Pantone_Actualizar(Dto.Pantone obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool Pantone_Eliminar(Dto.Pantone obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool Pantone_ValidaColor(Dto.Pantone obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool Pantone_ValidaNombre(Dto.Pantone obj);
        #endregion

        #region [Troqueles]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<Dto.Troquel> Troquel_RecuperarFiltros(Dto.Troquel objFiltros);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="idtroquel"></param>
        /// <returns></returns>
        [OperationContract]
        bool Troquel_Insertar(Dto.Troquel obj, out Nullable<int> idtroquel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool Troquel_Actualizar(Dto.Troquel obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool Troquel_Eliminar(Dto.Troquel obj);
        #endregion

        #region [Municipios]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<Dto.Municipio> Municipio_RecuperarFiltros(Dto.Municipio objFiltros);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool Municipio_Insertar(Dto.Municipio obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool Municipio_ValidaId(Dto.Municipio obj);
        #endregion

        #region [Departamentos]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<Dto.Departamento> Departamento_RecuperarFiltros(Dto.Departamento objFiltros);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool Departamento_Insertar(Dto.Departamento obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool Departamento_ValidaId(Dto.Departamento obj);
        #endregion

        #region [Proveedores]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<Dto.Proveedor> Proveedor_RecuperarFiltros(Dto.Proveedor objFiltros);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="idproveedor"></param>
        /// <returns></returns>
        [OperationContract]
        bool Proveedor_Insertar(Dto.Proveedor obj, out Nullable<int> idproveedor);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool Proveedor_Actualizar(Dto.Proveedor obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool Proveedor_Eliminar(Dto.Proveedor obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<Dto.ProveedorLinea> Proveedor_RecuperarLineasFiltros(Dto.ProveedorLinea objFiltros);
        #endregion

        #region [Insumos]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<Dto.Insumo> Insumo_RecuperarFiltros(Dto.Insumo objFiltros);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="idinsumo"></param>
        /// <returns></returns>
        [OperationContract]
        bool Insumo_Insertar(Dto.Insumo obj, out Nullable<int> idinsumo);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool Insumo_Actualizar(Dto.Insumo obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool Insumo_Eliminar(Dto.Insumo obj);

        #endregion

        #region [Productos]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<Dto.Producto> Producto_RecuperarFiltros(Dto.Producto objFiltros);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="idmaquina"></param>
        /// <returns></returns>
        [OperationContract]
        bool Producto_Insertar(Dto.Producto obj, out Nullable<int> idproducto);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool Producto_Actualizar(Dto.Producto obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool Producto_Eliminar(Dto.Producto obj);
        #endregion

        #region [Accesorio]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<Dto.Accesorio> Accesorio_RecuperarFiltros(Dto.Accesorio objFiltros);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="idaccesorio"></param>
        /// <returns></returns>
        [OperationContract]
        bool Accesorio_Insertar(Dto.Accesorio obj, out Nullable<int> idaccesorio);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool Accesorio_Actualizar(Dto.Accesorio obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool Accesorio_Eliminar(Dto.Accesorio obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool Accesorio_ValidaCodigo(Dto.Accesorio obj);
        #endregion

        #region [Cotizaciones]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<Dto.Cotizacion> Cotizacion_RecuperarFiltros(Dto.Cotizacion objFiltros);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="idmaquina"></param>
        /// <returns></returns>
        [OperationContract]
        bool Cotizacion_Insertar(Dto.Cotizacion obj, out Nullable<Int32> idcotizacion);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool Cotizacion_Actualizar(Dto.Cotizacion obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool Cotizacion_Eliminar(Dto.Cotizacion obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<Dto.CotizacionDetalle> Cotizacion_RecuperarDetalle(Dto.CotizacionDetalle objFiltros);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idproducto"></param>
        /// <param name="idperiodo"></param>
        /// <param name="escala"></param>
        /// <param name="idinsumoflete"></param>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<Dto.CotizacionDetalle> Cotizacion_Cotizar(int idproducto, int idperiodo, int idinsumoflete);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<Dto.Esacala> Cotizacion_RecuperarEscalas();
        #endregion

        #region [Pedidos]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<Dto.Pedido> Pedido_RecuperarFiltros(Dto.Pedido objFiltros);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="idmaquina"></param>
        /// <returns></returns>
        [OperationContract]
        bool Pedido_Insertar(Dto.Pedido obj, out Nullable<Int32> idpedido);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool Pedido_Actualizar(Dto.Pedido obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool Pedido_Eliminar(Dto.Pedido obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<Dto.PedidoDetalle> Pedido_RecuperarDetalle(Dto.PedidoDetalle objFiltros);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<Dto.Pedido> Pedido_RecuperarXCliente(int idCliente);
        #endregion

        #region [Reportes]
        [OperationContract]
        byte[] Reportes_Cotizacion(int idCotizacion);        
        #endregion

        #region [Cartera]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<Dto.Cartera> Cartera_RecuperarFiltros(Dto.Cartera objFiltros);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        [OperationContract]
        bool Cartera_ActualizarCarteraLote(IEnumerable<Dto.Cartera> lst);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool Cartera_Actualizar(Dto.Cliente obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool Cartera_Eliminar(Dto.Cliente obj);
        #endregion

        #region [Estilo Troquel]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<Dto.Estilo> Estilo_RecuperarFiltros(Dto.Estilo objFiltros);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="idestilo"></param>
        /// <returns></returns>
        [OperationContract]
        bool Estilo_Insertar(Dto.Estilo obj, out Nullable<int> idestilo);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool Estilo_Actualizar(Dto.Estilo obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool Estilo_Eliminar(Dto.Estilo obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool Estilo_ValidaCodigo(Dto.Estilo obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<Dto.EstiloPegue> Estilo_RecuperarPegues(Dto.EstiloPegue objFiltros);
        #endregion

        #region [Gestión Comercial]
        [OperationContract]
        Dto.ReporteGestionComercial GestionComercial_ObtenerReporteGestionComercial();

        [OperationContract]
        IEnumerable<Dto.PedidoGestion> GestionComercial_ObtenerPedidosXAgrupacion(byte agrupacion);
        #endregion
    }
}
