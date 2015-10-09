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
        public IEnumerable<Dto.Empresa> Empresa_RecuperarFiltrado(Dto.Empresa objFiltros)
        {
            return new Business.BEmpresa().RecuperarFiltrado(objFiltros);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="idEmpresa"></param>
        /// <returns></returns>
        public bool Empresa_Insertar(Dto.Empresa obj, out byte? idEmpresa)
        {
            bool blnRespuesta = new Business.BEmpresa().Crear(obj);

            if (blnRespuesta)
                idEmpresa = obj.idempresa;
            else
                idEmpresa = null;

            return blnRespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Empresa_Actualizar(Dto.Empresa obj)
        {
            return new Business.BEmpresa().Actualizar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Empresa_Eliminar(Dto.Empresa obj)
        {
            return new Business.BEmpresa().Eliminar(obj);
        }
    }
}
