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
            return new Data.DMaquina().RecuperarFiltrados(obj).ToList();
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
    }
}
