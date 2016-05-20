using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Business
{
    public class BAccesorio : ParentBusiness
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Crear(Dto.Accesorio obj)
        {
            return new Data.DAccesorio().Insertar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public IEnumerable<Dto.Accesorio> RecuperarFiltrado(Dto.Accesorio obj)
        {
            return new Data.DAccesorio().RecuperarFiltrados(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Actualizar(Dto.Accesorio obj)
        {
            return new Data.DAccesorio().Actualizar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Eliminar(Dto.Accesorio obj)
        {
            return new Data.DAccesorio().Eliminar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool ValidaCodigo(Dto.Accesorio obj)
        {
            Dto.Accesorio objExiste = new Data.DAccesorio().RecuperarFiltrados(obj).FirstOrDefault();
            if (objExiste != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
