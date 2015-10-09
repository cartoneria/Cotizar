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
        public IEnumerable<Dto.Cliente> Cliente_RecuperarFiltros(Dto.Cliente objFiltros)
        {
            return new Business.BCliente().RecuperarFiltrado(objFiltros);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="idcliente"></param>
        /// <returns></returns>
        public bool Cliente_Insertar(Dto.Cliente obj, out int? idcliente)
        {
            bool blnRespuesta = new Business.BCliente().Crear(obj);

            if (blnRespuesta)
                idcliente = obj.idcliente;
            else
                idcliente = null;

            return blnRespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Cliente_Actualizar(Dto.Cliente obj)
        {
            return new Business.BCliente().Actualizar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Cliente_Eliminar(Dto.Cliente obj)
        {
            return new Business.BCliente().Eliminar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Cliente_ValidaNombre(Dto.Cliente obj)
        {
            return new Business.BCliente().ValidaNombre(obj);
        }
    }
}
