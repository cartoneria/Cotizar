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
        public IEnumerable<Dto.Cotizacion> Cotizacion_RecuperarFiltros(Dto.Cotizacion objFiltros)
        {
            try
            {
                return new Business.BCotizacion().RecuperarFiltrado(objFiltros);
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
        /// <param name="idcotizacion"></param>
        /// <returns></returns>
        public bool Cotizacion_Insertar(Dto.Cotizacion obj, out int? idcotizacion)
        {
            try
            {
                bool blnRespuesta = new Business.BCotizacion().Crear(obj);

                if (blnRespuesta)
                    idcotizacion = obj.idcotizacion;
                else
                    idcotizacion = null;

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
        public bool Cotizacion_Actualizar(Dto.Cotizacion obj)
        {
            try
            {
                return new Business.BCotizacion().Actualizar(obj);
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
        public bool Cotizacion_Eliminar(Dto.Cotizacion obj)
        {
            try
            {
                return new Business.BCotizacion().Eliminar(obj);
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
        public IEnumerable<Dto.CotizacionDetalle> Cotizacion_RecuperarDetalle(Dto.CotizacionDetalle objFiltros)
        {
            try
            {
                return new Business.BCotizacion().RecuperarDetalle(objFiltros);
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
        /// <param name="idproducto"></param>
        /// <param name="idperiodo"></param>
        /// <param name="escala"></param>
        /// <param name="idinsumoflete"></param>
        /// <returns></returns>
        public Dto.CotizacionDetalle Cotizacion_Cotizar(int idproducto, int idperiodo, short escala, int idinsumoflete)
        {
            try
            {
                return new Business.BCotizacion().Cotizar(idproducto, idperiodo, escala, idinsumoflete);
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.Maquinas);
                throw;
            }
        }
    }
}
