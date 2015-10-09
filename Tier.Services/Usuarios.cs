using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Tier.Services
{
    public partial class CotizarService : ICotizarService
    {
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
        public bool Usuario_Insertar(Dto.Usuario obj, out short? idusuario)
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
    }
}
