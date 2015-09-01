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
        bool Rol_Insertar(Dto.Rol obj, Nullable<Int16> idrol);

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
        bool Usuario_Insertar(Dto.Usuario obj, Nullable<Int16> idusuario);

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
        bool Maquina_Insertar(Dto.Maquina obj, Nullable<Int16> idmaquina);

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
        #endregion

        #region [Funcionalidad]
        
        [OperationContract]
        IEnumerable<Dto.Funcionalidad> Funcionalidad_RecuperarFiltros(Dto.Funcionalidad objFiltros);

        #endregion


    }
}
