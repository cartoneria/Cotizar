using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Business
{
    public class BEstilo
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Crear(Dto.Estilo obj)
        {
            return new Data.DEstilo().Insertar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public IEnumerable<Dto.Estilo> RecuperarFiltrado(Dto.Estilo obj, bool objCompuesto)
        {
            IEnumerable<Dto.Estilo> lstResult = new Data.DEstilo().RecuperarFiltrados(obj);

            if (objCompuesto)
            {
                foreach (var item in lstResult)
                {
                    item.pegues = this.RecuperarPegues(new Dto.EstiloPegue() { estilo_idestilo = item.idestilo });
                } 
            }

            return lstResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Actualizar(Dto.Estilo obj)
        {
            return new Data.DEstilo().Actualizar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Eliminar(Dto.Estilo obj)
        {
            return new Data.DEstilo().Eliminar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool ValidaCodigo(Dto.Estilo obj)
        {
            Dto.Estilo objExiste = new Data.DEstilo().RecuperarFiltrados(obj).FirstOrDefault();

            if (objExiste != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public IEnumerable<Dto.EstiloPegue> RecuperarPegues(Dto.EstiloPegue obj)
        {
            return new Data.DEstiloPegue().RecuperarFiltrados(obj);
        }
    }
}
