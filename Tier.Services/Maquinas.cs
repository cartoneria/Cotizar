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
            try
            {
                return new Business.BMaquina().RecuperarFiltrado(objFiltros);
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.Maquinas);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="idmaquina"></param>
        /// <returns></returns>
        public bool Maquina_Insertar(Dto.Maquina obj, out short? idmaquina)
        {
            try
            {
                bool blnRespuesta = new Business.BMaquina().Crear(obj);

                if (blnRespuesta)
                    idmaquina = obj.idmaquina;
                else
                    idmaquina = null;

                return blnRespuesta;
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.Maquinas);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Maquina_Actualizar(Dto.Maquina obj)
        {
            try
            {
                return new Business.BMaquina().Actualizar(obj);
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.Maquinas);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Maquina_Eliminar(Dto.Maquina obj)
        {
            try
            {
                return new Business.BMaquina().Eliminar(obj);
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.Maquinas);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Maquina_ValidaCodigo(Dto.Maquina obj)
        {
            try
            {
                return new Business.BMaquina().ValidaCodigo(obj);
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.Maquinas);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        public IEnumerable<Dto.RutaProduccion> Maquina_RecuperarRutasProduccionFiltros(Dto.RutaProduccion objFiltros)
        {
            try
            {
                return new Business.BRutaProduccion().RecuperarFiltrado(objFiltros);
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.Maquinas);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        public IEnumerable<Dto.MaquinaVariacionProduccion> Maquina_RecuperarVariacionesProduccionFiltros(Dto.MaquinaVariacionProduccion objFiltros)
        {
            try
            {
                return new Business.BMaquina().RecuperarVPFiltrado(objFiltros);
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.Maquinas);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        public IEnumerable<Dto.MaquinaDatoPeriodico> Maquina_RecuperarDatosPeriodicosFiltros(Dto.MaquinaDatoPeriodico objFiltros)
        {
            try
            {
                return new Business.BMaquina().RecuperarDPFiltrado(objFiltros);
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.Maquinas);
                throw;
            }
        }
    }
}
