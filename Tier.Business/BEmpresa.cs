using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Business
{
    public class BEmpresa
    {
        public bool Crear(Dto.Empresa obj)
        {
            return new Data.DEmpresa().Insertar(obj);
        }

        public IEnumerable<Dto.Empresa> RecuperarFiltrado(Dto.Empresa obj)
        {
            return new Data.DEmpresa().RecuperarFiltrados(obj).ToList();
        }

        public bool Actualizar(Dto.Empresa obj)
        {
            return new Data.DEmpresa().Actualizar(obj);
        }

        public bool Eliminar(Dto.Empresa obj)
        {
            return new Data.DEmpresa().Eliminar(obj);
        }
    }
}
