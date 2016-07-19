using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Business
{
    public class BCartera : ParentBusiness
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        public bool ActualizarCarteraLote(IEnumerable<Dto.Cartera> lst)
        {
            return new Data.DCartera().ActualizarCarteraLote(lst);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public IEnumerable<Dto.Cartera> RecuperarFiltrado(Dto.Cartera obj)
        {
            return new Data.DCartera().RecuperarFiltrados(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Actualizar(Dto.Cartera obj)
        {
            return new Data.DCartera().Actualizar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Eliminar(Dto.Cartera obj)
        {
            return new Data.DCartera().Eliminar(obj);
        }
    }
}
