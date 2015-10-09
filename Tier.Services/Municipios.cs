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
        public IEnumerable<Dto.Municipio> Municipio_RecuperarFiltros(Dto.Municipio objFiltros)
        {
            return new Business.BMunicipio().RecuperarFiltrado(objFiltros);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Municipio_Insertar(Dto.Municipio obj)
        {
            return new Business.BMunicipio().Crear(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Municipio_ValidaId(Dto.Municipio obj)
        {
            return new Business.BMunicipio().ValidaId(obj);
        }
    }
}
