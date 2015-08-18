using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Business
{
    public class BPermiso
    {
        public IEnumerable<Dto.Permiso> RecuperarFiltrado(Dto.Permiso obj)
        {
            return new Data.DPermiso().RecuperarFiltrados(obj).ToList();
        }
    }
}
