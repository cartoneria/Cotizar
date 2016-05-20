using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Business
{
    public class BRutaProduccion : ParentBusiness
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public IEnumerable<Dto.RutaProduccion> RecuperarFiltrado(Dto.RutaProduccion obj)
        {
            return new Data.DRutaProduccion().RecuperarFiltrados(obj);
        }
    }
}
