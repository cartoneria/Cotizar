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
        public bool Maquina_Insertar(Dto.Maquina obj, out short? idmaquina)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Maquina_ValidaCodigo(Dto.Maquina obj)
        {
            return new Business.BMaquina().ValidaCodigo(obj);
        }
    }
}
