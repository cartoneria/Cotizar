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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool ItemLista_ValidaNombre(Dto.ItemLista obj)
        {
            return new Business.BItemsLista().ValidaNombre(obj);
        }
    }
}
