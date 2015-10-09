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
        public IEnumerable<Dto.Departamento> Departamento_RecuperarFiltros(Dto.Departamento objFiltros)
        {
            return new Business.BDepartamento().RecuperarFiltrado(objFiltros);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Departamento_Insertar(Dto.Departamento obj)
        {
            return new Business.BDepartamento().Crear(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Departamento_ValidaId(Dto.Departamento obj)
        {
            return new Business.BDepartamento().ValidaId(obj);
        }
    }
}
