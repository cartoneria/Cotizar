using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Business
{
    public class BMaquina
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Crear(Dto.Maquina obj)
        {
            return new Data.DMaquina().Insertar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public IEnumerable<Dto.Maquina> RecuperarFiltrado(Dto.Maquina obj)
        {
            IEnumerable<Dto.Maquina> lstResult = new Data.DMaquina().RecuperarFiltrados(obj).ToList();
            foreach (var item in lstResult)
            {
                item.VariacionesProduccion = this.RecuperarVPFiltrado(new Dto.MaquinaVariacionProduccion() { maquina_idmaquina = item.idmaquina }).ToList();
                item.DatosPeriodicos = this.RecuperarDPFiltrado(new Dto.MaquinaDatoPeriodico() { maquina_idmaquina = item.idmaquina }).ToList();
            }
            return lstResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Actualizar(Dto.Maquina obj)
        {
            return new Data.DMaquina().Actualizar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Eliminar(Dto.Maquina obj)
        {
            return new Data.DMaquina().Eliminar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool ValidaCodigo(Dto.Maquina obj)
        {
            Dto.Maquina objExiste = new Data.DMaquina().RecuperarFiltrados(obj).FirstOrDefault();
            if (objExiste != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public IEnumerable<Dto.MaquinaVariacionProduccion> RecuperarVPFiltrado(Dto.MaquinaVariacionProduccion obj)
        {
            return new Data.DMaquinaVariacionesProduccion().RecuperarFiltrados(obj).ToList();
        }

        public IEnumerable<Dto.MaquinaDatoPeriodico> RecuperarDPFiltrado(Dto.MaquinaDatoPeriodico obj)
        {
            return new Data.DMaquinaDatosPeriodicos().RecuperarFiltrados(obj);
        }
    }
}
