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
        public IEnumerable<Dto.Pantone> Pantone_RecuperarFiltros(Dto.Pantone objFiltros)
        {
            return new Business.BPantone().RecuperarFiltrado(objFiltros);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="idpantone"></param>
        /// <returns></returns>
        public bool Pantone_Insertar(Dto.Pantone obj, out int? idpantone)
        {
            bool blnRespuesta = new Business.BPantone().Crear(obj);

            if (blnRespuesta)
                idpantone = obj.idpantone;
            else
                idpantone = null;

            return blnRespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Pantone_Actualizar(Dto.Pantone obj)
        {
            return new Business.BPantone().Actualizar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Pantone_Eliminar(Dto.Pantone obj)
        {
            return new Business.BPantone().Eliminar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Pantone_ValidaColor(Dto.Pantone obj)
        {
            return new Business.BPantone().ValidaColor(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Pantone_ValidaNombre(Dto.Pantone obj)
        {
            return new Business.BPantone().ValidaNombre(obj);
        }
    }
}
