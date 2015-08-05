using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Tier.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CMCotizar" in both code and config file together.
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
                throw new FaultException(new FaultReason("El rol no pudo ser actualizado."), new FaultCode("002"));
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
                throw new FaultException(new FaultReason("El rol no pudo ser creado."), new FaultCode("001"));
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
                throw new FaultException(new FaultReason("El rol no pudo ser actualizado."), new FaultCode("002"));
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
                throw new FaultException(new FaultReason("El rol no pudo ser actualizado."), new FaultCode("002"));
            }
        }
        #endregion
    }
}
