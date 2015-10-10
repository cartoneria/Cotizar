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
        #region [Gestión Empresas]
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

        #region [Gestión Roles]
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

        #region [Gestión Listas]
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

        #region [Gestión Usuarios]
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
        #endregion

        #region [Gestión Maquinas]
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
        #endregion

        #region [Gestión Asesores]
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

        #region [Espectros]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<Dto.Espectro> Espectro_RecuperarFiltros(Dto.Espectro objFiltros);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="idespectro"></param>
        /// <returns></returns>
        [OperationContract]
        bool Espectro_Insertar(Dto.Espectro obj, out Nullable<int> idespectro);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool Espectro_Actualizar(Dto.Espectro obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool Espectro_Eliminar(Dto.Espectro obj);
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
    }
}
