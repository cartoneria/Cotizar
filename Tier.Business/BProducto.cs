using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Business
{
    public class BProducto
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Crear(Dto.Producto obj)
        {
            return new Data.DProducto().Insertar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public IEnumerable<Dto.Producto> RecuperarFiltrado(Dto.Producto obj)
        {
            IEnumerable<Dto.Producto> lstResult = new Data.DProducto().RecuperarFiltrados(obj).ToList();
            foreach (var item in lstResult)
            {
                //item.VariacionesProduccion = this.RecuperarVPFiltrado(new Dto.MaquinaVariacionProduccion() { maquina_idmaquina = item.idmaquina }).ToList();
                //item.DatosPeriodicos = this.RecuperarDPFiltrado(new Dto.MaquinaDatoPeriodico() { maquina_idmaquina = item.idmaquina }).ToList();
            }

            return lstResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Actualizar(Dto.Producto obj)
        {
            return new Data.DProducto().Actualizar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Eliminar(Dto.Producto obj)
        {
            return new Data.DProducto().Eliminar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool ValidaCodigo(Dto.Producto obj)
        {
            Dto.Producto objExiste = new Data.DProducto().RecuperarFiltrados(obj).FirstOrDefault();
            if (objExiste != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //public IEnumerable<Dto.MaquinaVariacionProduccion> RecuperarVPFiltrado(Dto.MaquinaVariacionProduccion obj)
        //{
        //    return new Data.DMaquinaVariacionesProduccion().RecuperarFiltrados(obj).ToList();
        //}

        //public IEnumerable<Dto.MaquinaDatoPeriodico> RecuperarDPFiltrado(Dto.MaquinaDatoPeriodico obj)
        //{
        //    return new Data.DMaquinaDatosPeriodicos().RecuperarFiltrados(obj);
        //}
    }
}
