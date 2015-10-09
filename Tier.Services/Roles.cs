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
        public bool Rol_Insertar(Dto.Rol obj, out short? idrol)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Rol_ValidaNombre(Dto.Rol obj)
        {
            return new Business.BRol().ValidaNombre(obj);
        }
    }
}
