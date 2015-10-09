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
        public bool Asesor_Insertar(Dto.Asesor obj, out byte? idasesor)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Asesor_ValidaCodigo(Dto.Asesor obj)
        {
            return new Business.BAsesor().ValidaCodigo(obj);
        }
    }
}
