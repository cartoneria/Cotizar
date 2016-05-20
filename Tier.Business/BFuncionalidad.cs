using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Business
{
    public class BFuncionalidad : ParentBusiness
    {
        public IEnumerable<Dto.Funcionalidad> RecuperarFiltrado(Dto.Funcionalidad obj)
        {
            IEnumerable<Dto.Funcionalidad> lstResultado = new Data.DFuncionalidad().RecuperarFiltrados(obj);

            foreach (var item in lstResultado)
            {
                item.acciones = this.RecuperarAccionesFuncionalidad(item);
            }

            return lstResultado;
        }

        public IEnumerable<Dto.Funcionalidad> GenerarMenu(IEnumerable<Dto.Funcionalidad> Funcionalidades)
        {
            IEnumerable<Dto.Funcionalidad> lstMenuPrincipal = Funcionalidades.Where(ee => ee.idpadre == null).ToList();
            foreach (Dto.Funcionalidad item in lstMenuPrincipal)
            {
                this.RecuperarFuncionalidadesHijas(item, Funcionalidades);
            }

            return lstMenuPrincipal;
        }

        private void RecuperarFuncionalidadesHijas(Dto.Funcionalidad obj, IEnumerable<Dto.Funcionalidad> Funcionalidades)
        {
            IEnumerable<Dto.Funcionalidad> lstFuncionalidadesHijas = Funcionalidades.Where(ee => ee.idpadre == obj.idfuncionalidad).ToList();

            if (lstFuncionalidadesHijas.Count() > 0)
            {
                foreach (Dto.Funcionalidad item in lstFuncionalidadesHijas)
                {
                    this.RecuperarFuncionalidadesHijas(item, Funcionalidades);
                }
            }

            obj.funcionalidades = lstFuncionalidadesHijas;
        }

        private IEnumerable<Dto.Accion> RecuperarAccionesFuncionalidad(Dto.Funcionalidad obj)
        {
            return new Data.DFuncionalidad().RecuperarAccionesFuncionalidad(obj);
        }
    }
}
