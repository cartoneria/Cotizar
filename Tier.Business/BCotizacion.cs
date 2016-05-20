using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Business
{
    public class BCotizacion : ParentBusiness
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public IEnumerable<Dto.CotizacionDetalle> RecuperarDetalle(Dto.CotizacionDetalle obj)
        {
            return new Data.DCotizacionDetalle().RecuperarFiltrados(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idproducto"></param>
        /// <param name="idperiodo"></param>
        /// <param name="idinsumoflete"></param>
        /// <returns></returns>
        public IEnumerable<Dto.CotizacionDetalle> Cotizar(int idproducto, int idperiodo, int idinsumoflete)
        {
            List<Dto.CotizacionDetalle> lstCotizacionProductoEscalas = new List<Dto.CotizacionDetalle>();

            int escalaFinal = 0;
            int cabidaTroquel = 0;

            IEnumerable<Dto.Esacala> lstEscalas = this.RecuperarEscalas();

            foreach (Dto.Esacala escala in lstEscalas)
            {
                escalaFinal = escala.Cantidad;

                Dto.Producto objProd = new Business.BProducto().RecuperarFiltrado(new Dto.Producto() { idproducto = idproducto }).FirstOrDefault();
                if (objProd != null && objProd.troquel_idtroquel != null)
                {
                    Dto.Troquel objTroq = new Business.BTroquel().RecuperarFiltrado(new Dto.Troquel() { idtroquel = objProd.troquel_idtroquel }).FirstOrDefault();
                    cabidaTroquel = (objTroq.cabidafibra.HasValue ? objTroq.cabidafibra.Value : 0) * (objTroq.cabidacontrafibra.HasValue ? objTroq.cabidacontrafibra.Value : 0);

                    if (cabidaTroquel > 0 && cabidaTroquel < 1)
                    {
                        escalaFinal = escala.Cantidad * cabidaTroquel * 2;
                    }
                    else
                    {
                        escalaFinal = escala.Cantidad * cabidaTroquel;
                    }
                }

                Dto.CotizacionDetalle CotizacionProductoEscalas = new Data.DCotizacion().Cotizar(idproducto, idperiodo, escalaFinal, idinsumoflete);
                CotizacionProductoEscalas.escala = escalaFinal;
                CotizacionProductoEscalas.producto_idproducto = idproducto;
                CotizacionProductoEscalas.insumo_idinsumo_flete = idinsumoflete;

                lstCotizacionProductoEscalas.Add(CotizacionProductoEscalas);
            }

            return lstCotizacionProductoEscalas;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Dto.Esacala> RecuperarEscalas()
        {
            return Utilidades.RecuperarEscalas();
        }
    }
}
