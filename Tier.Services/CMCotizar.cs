﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;

namespace Tier.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CMCotizar" in both code and config file together.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class CMCotizar : ICMCotizar
    {
        #region [Gestión Roles]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        Dto.Rol ICMCotizar.Rol_Insertar(Dto.Rol obj)
        {
            if (new Business.BRol().Crear(obj))
            {
                return obj;
            }
            else
            {
                throw new FaultException(new FaultReason("El rol no pudo ser creado."), new FaultCode("001"));
            }
        }

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
        /// <returns></returns>
        Dto.Rol ICMCotizar.Rol_Actualizar(Dto.Rol obj)
        {
            if (new Business.BRol().Actualizar(obj))
            {
                return obj;
            }
            else
            {
                throw new FaultException(new FaultReason("El rol no pudo ser actualizado."), new FaultCode("002"));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        Dto.Rol ICMCotizar.Rol_Eliminar(Dto.Rol obj)
        {
            if (new Business.BRol().Eliminar(obj))
            {
                return obj;
            }
            else
            {
                throw new FaultException(new FaultReason("El rol no pudo ser aliminado."), new FaultCode("003"));
            }
        }
        #endregion

        #region [Gestión Empresas]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Dto.Empresa Empresa_Insertar(Dto.Empresa obj)
        {
            if (new Business.BEmpresa().Crear(obj))
            {
                return obj;
            }
            else
            {
                throw new FaultException(new FaultReason("La empresa no pudo ser creada."), new FaultCode("001"));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        public IEnumerable<Dto.Empresa> Empresa_RecuperarFiltros(Dto.Empresa objFiltros)
        {
            return new Business.BEmpresa().RecuperarFiltrado(objFiltros);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Dto.Empresa Empresa_Actualizar(Dto.Empresa obj)
        {
            if (new Business.BEmpresa().Actualizar(obj))
            {
                return obj;
            }
            else
            {
                throw new FaultException(new FaultReason("La empresa no pudo ser actualizada."), new FaultCode("002"));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Dto.Empresa Empresa_Eliminar(Dto.Empresa obj)
        {
            if (new Business.BEmpresa().Eliminar(obj))
            {
                return obj;
            }
            else
            {
                throw new FaultException(new FaultReason("La empresa no pudo ser eliminada."), new FaultCode("003"));
            }
        }
        #endregion

        #region [Gestión Listas]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Dto.ItemLista ItemLista_Insertar(Dto.ItemLista obj)
        {
            if (new Business.BItemsLista().Crear(obj))
            {
                return obj;
            }
            else
            {
                throw new FaultException(new FaultReason("El elemento no pudo ser creado."), new FaultCode("001"));
            }
        }

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
        /// <returns></returns>
        public Dto.ItemLista ItemLista_Actualizar(Dto.ItemLista obj)
        {
            if (new Business.BItemsLista().Actualizar(obj))
            {
                return obj;
            }
            else
            {
                throw new FaultException(new FaultReason("El elemento no pudo ser actualizado."), new FaultCode("002"));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Dto.ItemLista ItemLista_Eliminar(Dto.ItemLista obj)
        {
            if (new Business.BItemsLista().Eliminar(obj))
            {
                return obj;
            }
            else
            {
                throw new FaultException(new FaultReason("El elemento no pudo ser eliminado."), new FaultCode("003"));
            }
        }
        #endregion

        #region [Gestión Usuarios]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Dto.Usuario Usuario_Insertar(Dto.Usuario obj)
        {
            if (new Business.BUsuario().Crear(obj))
            {
                return obj;
            }
            else
            {
                throw new FaultException(new FaultReason("El elemento no pudo ser creado."), new FaultCode("001"));
            }
        }

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
        /// <returns></returns>
        public Dto.Usuario Usuario_Actualizar(Dto.Usuario obj)
        {
            if (new Business.BUsuario().Actualizar(obj))
            {
                return obj;
            }
            else
            {
                throw new FaultException(new FaultReason("El usuario no pudo ser actualizado."), new FaultCode("002"));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Dto.Usuario Usuario_Eliminar(Dto.Usuario obj)
        {
            if (new Business.BUsuario().Eliminar(obj))
            {
                return obj;
            }
            else
            {
                throw new FaultException(new FaultReason("El usuario no pudo ser eliminado."), new FaultCode("003"));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Dto.Usuario Usuario_RestablecerClave(Dto.Usuario obj)
        {
            if (new Business.BUsuario().RestablecerClave(obj))
            {
                return obj;
            }
            else
            {
                throw new FaultException(new FaultReason("La solicitud no pudo ser procesada."), new FaultCode("003"));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Dto.Usuario Usuario_CambiarClave(Dto.Usuario obj)
        {
            if (new Business.BUsuario().CambiarClave(obj))
            {
                return obj;
            }
            else
            {
                throw new FaultException(new FaultReason("La solicitud no pudo ser procesada."), new FaultCode("003"));
            }
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
        Dto.Sesion ICMCotizar.Usuario_IniciarSesion(Dto.Usuario obj)
        {
            return new Business.BUsuario().IniciarSesion(obj);
        }
        #endregion

        #region [Gestión Maquinas]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Dto.Maquina Maquina_Insertar(Dto.Maquina obj)
        {
            if (new Business.BMaquina().Crear(obj))
            {
                return obj;
            }
            else
            {
                throw new FaultException(new FaultReason("La maquina no pudo ser creada."), new FaultCode("001"));
            }
        }

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
        /// <returns></returns>
        public Dto.Maquina Maquina_Actualizar(Dto.Maquina obj)
        {
            if (new Business.BMaquina().Actualizar(obj))
            {
                return obj;
            }
            else
            {
                throw new FaultException(new FaultReason("La maquina no pudo ser actualizada."), new FaultCode("002"));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Dto.Maquina Maquina_Eliminar(Dto.Maquina obj)
        {
            if (new Business.BMaquina().Eliminar(obj))
            {
                return obj;
            }
            else
            {
                throw new FaultException(new FaultReason("La maquina no pudo ser eliminada."), new FaultCode("003"));
            }
        }
        #endregion

        #region [Gestión Asesores]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Dto.Asesor Asesor_Insertar(Dto.Asesor obj)
        {
            if (new Business.BAsesor().Crear(obj))
            {
                return obj;
            }
            else
            {
                throw new FaultException(new FaultReason("El asesor no pudo ser creado."), new FaultCode("001"));
            }
        }

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
        /// <returns></returns>
        public Dto.Asesor Asesor_Actualizar(Dto.Asesor obj)
        {
            if (new Business.BAsesor().Actualizar(obj))
            {
                return obj;
            }
            else
            {
                throw new FaultException(new FaultReason("El asesor no pudo ser actualizado."), new FaultCode("002"));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Dto.Asesor Asesor_Eliminar(Dto.Asesor obj)
        {
            if (new Business.BAsesor().Eliminar(obj))
            {
                return obj;
            }
            else
            {
                throw new FaultException(new FaultReason("El asesor no pudo ser eliminado."), new FaultCode("003"));
            }
        }
        #endregion
    }
}
