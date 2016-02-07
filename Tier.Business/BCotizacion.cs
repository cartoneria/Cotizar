using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Business
{
    public class BCotizacion
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Crear(Dto.Cotizacion obj)
        {
            return new Data.DCotizacion().Insertar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public IEnumerable<Dto.Cotizacion> RecuperarFiltrado(Dto.Cotizacion obj)
        {
            IEnumerable<Dto.Cotizacion> lstResult = new Data.DCotizacion().RecuperarFiltrados(obj);
            foreach (var item in lstResult)
            {
                item.detalle = this.RecuperarDetalle(new Dto.CotizacionDetalle() { cotizacion_idcotizacion = item.idcotizacion });
            }

            return lstResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Actualizar(Dto.Cotizacion obj)
        {
            return new Data.DCotizacion().Actualizar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Eliminar(Dto.Cotizacion obj)
        {
            return new Data.DCotizacion().Eliminar(obj);
        }

        public IEnumerable<Dto.CotizacionDetalle> RecuperarDetalle(Dto.CotizacionDetalle obj)
        {
            return new Data.DCotizacionDetalle().RecuperarFiltrados(obj);
        }

        public Dto.CotizacionDetalle Cotizar(int idproducto, int idperiodo, short escala, int idinsumoflete)
        {
            return new Data.DCotizacion().Cotizar(idproducto, idperiodo, escala, idinsumoflete);
        }
    }
}
