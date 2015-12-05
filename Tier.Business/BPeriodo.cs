using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Business
{
    public class BPeriodo
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Crear(Dto.Periodo obj)
        {
            return new Data.DPeriodo().Insertar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public IEnumerable<Dto.Periodo> RecuperarFiltrado(Dto.Periodo obj)
        {
            IEnumerable<Dto.Periodo> lst = new Data.DPeriodo().RecuperarFiltrados(obj).ToList();

            foreach (Dto.Periodo item in lst)
            {
                item.centros = new BMaquina().RecuperarDPFiltrado(new Dto.MaquinaDatoPeriodico() { periodo_idPeriodo = item.idPeriodo });
                item.parametros = this.RecuperarParametrosFiltrado((byte)item.idPeriodo);
            }

            return lst;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Actualizar(Dto.Periodo obj)
        {
            return new Data.DPeriodo().Actualizar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Eliminar(Dto.Periodo obj)
        {
            return new Data.DPeriodo().Eliminar(obj);
        }

        public IEnumerable<Dto.Parametro> RecuperarParametrosFiltrado(byte idPeriodo)
        {
            return new Data.DParametro().RecuperarFiltrados(new Dto.Parametro() { periodo_idPeriodo = idPeriodo });
        }
    }
}
