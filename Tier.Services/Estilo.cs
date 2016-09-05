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
        public IEnumerable<Dto.Estilo> Estilo_RecuperarFiltros(Dto.Estilo objFiltros)
        {
            try
            {
                return new Business.BEstilo().RecuperarFiltrado(objFiltros);
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.EstilosTroquel);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="idestilo"></param>
        /// <returns></returns>
        public bool Estilo_Insertar(Dto.Estilo obj, out int? idestilo)
        {
            try
            {
                bool blnRespuesta = new Business.BEstilo().Crear(obj);

                if (blnRespuesta)
                    idestilo = obj.idestilo;
                else
                    idestilo = null;

                return blnRespuesta;
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.EstilosTroquel);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Estilo_Actualizar(Dto.Estilo obj)
        {
            try
            {
                return new Business.BEstilo().Actualizar(obj);
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.EstilosTroquel);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Estilo_Eliminar(Dto.Estilo obj)
        {
            try
            {
                return new Business.BEstilo().Eliminar(obj);
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.EstilosTroquel);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Estilo_ValidaCodigo(Dto.Estilo obj)
        {
            try
            {
                return new Business.BEstilo().ValidaCodigo(obj);
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.EstilosTroquel);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        public IEnumerable<Dto.EstiloPegue> Estilo_RecuperarPegues(Dto.EstiloPegue objFiltros)
        {
            try
            {
                return new Business.BEstilo().RecuperarPegues(objFiltros);
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.EstilosTroquel);
                throw;
            }
        }
    }
}
