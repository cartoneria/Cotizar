using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Business
{
    public class BRol
    {
        public bool Crear(Dto.Rol obj)
        {
            return new Data.DRol().Insertar(obj);
        }

        public IEnumerable<Dto.Rol> RecuperarFiltrado(Dto.Rol obj)
        {
            return new Data.DRol().RecuperarFiltrados(obj);
        }

        public bool Actualizar(Dto.Rol obj)
        {
            return new Data.DRol().Actualizar(obj);
        }

        public bool Eliminar(Dto.Rol obj)
        {
            return new Data.DRol().Eliminar(obj);
        }
    }
}
