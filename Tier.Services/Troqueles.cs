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
        public IEnumerable<Dto.Troquel> Troquel_RecuperarFiltros(Dto.Troquel objFiltros)
        {
            return new Business.BTroquel().RecuperarFiltrado(objFiltros);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="idtroquel"></param>
        /// <returns></returns>
        public bool Troquel_Insertar(Dto.Troquel obj, out int? idtroquel)
        {
            bool blnRespuesta = new Business.BTroquel().Crear(obj);

            if (blnRespuesta)
                idtroquel = obj.idtroquel;
            else
                idtroquel = null;

            return blnRespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Troquel_Actualizar(Dto.Troquel obj)
        {
            return new Business.BTroquel().Actualizar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Troquel_Eliminar(Dto.Troquel obj)
        {
            return new Business.BTroquel().Eliminar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Troquel_ValidaCodigo(Dto.Troquel obj)
        {
            return new Business.BTroquel().ValidaCodigo(obj);
        }
    }
}
