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
        public IEnumerable<Dto.Periodo> Periodo_RecuperarFiltros(Dto.Periodo objFiltros)
        {
            try
            {
                return new Business.BPeriodo().RecuperarFiltrado(objFiltros);
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.Periodos);
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="idperiodo"></param>
        /// <returns></returns>
        public bool Periodo_Insertar(Dto.Periodo obj, out int? idperiodo)
        {
            try
            {
                bool blnRespuesta = new Business.BPeriodo().Crear(obj);

                if (blnRespuesta)
                    idperiodo = obj.idPeriodo;
                else
                    idperiodo = null;

                return blnRespuesta;
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.Periodos);
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Periodo_Actualizar(Dto.Periodo obj)
        {
            try
            {
                return new Business.BPeriodo().Actualizar(obj);
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.Periodos);
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Periodo_Eliminar(Dto.Periodo obj)
        {
            try
            {
                return new Business.BPeriodo().Eliminar(obj);
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.Periodos);
                throw ex;
            }
        }
    }
}
