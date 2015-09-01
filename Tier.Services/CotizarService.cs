using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Tier.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CotizarService" in both code and config file together.
    public class CotizarService : ICotizarService
    {
        #region [Gestión Empresas]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        public IEnumerable<Dto.Empresa> Empresa_RecuperarFiltrado(Dto.Empresa objFiltros)
        {
            return new Business.BEmpresa().RecuperarFiltrado(objFiltros);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="idEmpresa"></param>
        /// <returns></returns>
        public bool Empresa_Insertar(Dto.Empresa obj, out byte? idEmpresa)
        {
            bool blnRespuesta = new Business.BEmpresa().Crear(obj);

            if (blnRespuesta)
                idEmpresa = obj.idempresa;
            else
                idEmpresa = null;

            return blnRespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Empresa_Actualizar(Dto.Empresa obj)
        {
            return new Business.BEmpresa().Actualizar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Empresa_Eliminar(Dto.Empresa obj)
        {
            return new Business.BEmpresa().Eliminar(obj);
        }
        #endregion

        #region [Gestión Roles]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        public IEnumerable<Dto.Rol> Rol_RecuperarFiltros(Dto.Rol objFiltros)
        {
            return new Business.BRol().RecuperarFiltrado(objFiltros);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="idrol"></param>
        /// <returns></returns>
        public bool Rol_Insertar(Dto.Rol obj, short? idrol)
        {
            bool blnRespuesta = new Business.BRol().Crear(obj);

            if (blnRespuesta)
                idrol = obj.idrol;
            else
                idrol = null;

            return blnRespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Rol_Actualizar(Dto.Rol obj)
        {
            return new Business.BRol().Actualizar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Rol_Eliminar(Dto.Rol obj)
        {
            return new Business.BRol().Eliminar(obj);
        }
        #endregion

        #region [Gestión Listas]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        public IEnumerable<Dto.ItemLista> ItemLista_RecuperarFiltros(Dto.ItemLista objFiltros)
        {
            return new Business.BItemsLista().RecuperarFiltrado(objFiltros);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="iditemlista"></param>
        /// <returns></returns>
        public bool ItemLista_Insertar(Dto.ItemLista obj, out int? iditemlista)
        {
            bool blnRespuesta = new Business.BItemsLista().Crear(obj);

            if (blnRespuesta)
                iditemlista = obj.iditemlista;
            else
                iditemlista = null;

            return blnRespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool ItemLista_Actualizar(Dto.ItemLista obj)
        {
            return new Business.BItemsLista().Actualizar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool ItemLista_Eliminar(Dto.ItemLista obj)
        {
            return new Business.BItemsLista().Eliminar(obj);
        }

        #endregion

        #region [Gestión Usuarios]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        public IEnumerable<Dto.Usuario> Usuario_RecuperarFiltros(Dto.Usuario objFiltros)
        {
            return new Business.BUsuario().RecuperarFiltrado(objFiltros);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="idusuario"></param>
        /// <returns></returns>
        public bool Usuario_Insertar(Dto.Usuario obj, short? idusuario)
        {
            bool blnRespuesta = new Business.BUsuario().Crear(obj);

            if (blnRespuesta)
                idusuario = obj.idusuario;
            else
                idusuario = null;

            return blnRespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Usuario_Actualizar(Dto.Usuario obj)
        {
            return new Business.BUsuario().Actualizar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Usuario_Eliminar(Dto.Usuario obj)
        {
            return new Business.BUsuario().Eliminar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Usuario_RestablecerClave(Dto.Usuario obj)
        {
            return new Business.BUsuario().RestablecerClave(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Usuario_CambiarClave(Dto.Usuario obj)
        {
            return new Business.BUsuario().CambiarClave(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Usuario_ValidaNombreUsuario(Dto.Usuario obj)
        {
            return new Business.BUsuario().ValidaNombreUsuario(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Dto.Sesion Usuario_IniciarSesion(Dto.Usuario obj)
        {
            return new Business.BUsuario().IniciarSesion(obj);
        }
        #endregion

        #region [Gestión Maquinas]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        public IEnumerable<Dto.Maquina> Maquina_RecuperarFiltros(Dto.Maquina objFiltros)
        {
            return new Business.BMaquina().RecuperarFiltrado(objFiltros);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="idmaquina"></param>
        /// <returns></returns>
        public bool Maquina_Insertar(Dto.Maquina obj, short? idmaquina)
        {
            bool blnRespuesta = new Business.BMaquina().Crear(obj);

            if (blnRespuesta)
                idmaquina = obj.idmaquina;
            else
                idmaquina = null;

            return blnRespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Maquina_Actualizar(Dto.Maquina obj)
        {
            return new Business.BMaquina().Actualizar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Maquina_Eliminar(Dto.Maquina obj)
        {
            return new Business.BMaquina().Eliminar(obj);
        }
        #endregion

        #region [Gestión Asesores]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        public IEnumerable<Dto.Asesor> Asesor_RecuperarFiltros(Dto.Asesor objFiltros)
        {
            return new Business.BAsesor().RecuperarFiltrado(objFiltros);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="idasesor"></param>
        /// <returns></returns>
        public bool Asesor_Insertar(Dto.Asesor obj,out byte? idasesor)
        {
            bool blnRespuesta = new Business.BAsesor().Crear(obj);

            if (blnRespuesta)
                idasesor = obj.idasesor;
            else
                idasesor = null;

            return blnRespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Asesor_Actualizar(Dto.Asesor obj)
        {
            return new Business.BAsesor().Actualizar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Asesor_Eliminar(Dto.Asesor obj)
        {
            return new Business.BAsesor().Eliminar(obj);
        }
        #endregion

        #region [Funcionalidad]

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        public IEnumerable<Dto.Funcionalidad> Funcionalidad_RecuperarFiltros(Dto.Funcionalidad objFiltros)
        {
            return new Business.BFuncionalidad().RecuperarFiltrado(objFiltros);
        }

        #endregion

    }
}
