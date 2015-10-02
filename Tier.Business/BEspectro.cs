using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Business
{
    public class BEspectro
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Crear(Dto.Espectro obj)
        {
            return new Data.DEspectro().Insertar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public IEnumerable<Dto.Espectro> RecuperarFiltrado(Dto.Espectro obj)
        {
            IEnumerable<Dto.Espectro> lst = new Data.DEspectro().RecuperarFiltrados(obj).ToList();
            foreach (Dto.Espectro item in lst)
            {
                item.pantones = new BEspectroPantone().RecuperarFiltrado(new Dto.EspectroPantone() { espectro_idespectro = item.idespectro });
            }

            return lst;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Actualizar(Dto.Espectro obj)
        {
            return new Data.DEspectro().Actualizar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Eliminar(Dto.Espectro obj)
        {
            return new Data.DEspectro().Eliminar(obj);
        }

    }
}
