using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Business
{
    public class BEspectroPantone
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public IEnumerable<Dto.EspectroPantone> RecuperarFiltrado(Dto.EspectroPantone obj)
        {
            return new Data.DEspectroPantone().RecuperarFiltrados(obj).ToList();
        }

    }
}
