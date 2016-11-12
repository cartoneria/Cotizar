using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Business
{
    public class BTroquel : ParentBusiness
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Crear(Dto.Troquel obj)
        {
            return new Data.DTroquel().Insertar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public IEnumerable<Dto.Troquel> RecuperarFiltrado(Dto.Troquel obj, bool objCompuesto)
        {
            IEnumerable<Dto.Troquel> lst = new Data.DTroquel().RecuperarFiltrados(obj);

            if (objCompuesto)
            {
                foreach (Dto.Troquel item in lst)
                {
                    item.ventanas = this.RecuperarVentanasFiltrado(new Dto.TroquelVentana() { troquel_idtroquel = item.idtroquel });
                }
            }

            return lst;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Actualizar(Dto.Troquel obj)
        {
            return new Data.DTroquel().Actualizar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Eliminar(Dto.Troquel obj)
        {
            return new Data.DTroquel().Eliminar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool ValidaCodigo(Dto.Troquel obj)
        {
            Dto.Troquel objExiste = new Data.DTroquel().RecuperarFiltrados(obj).FirstOrDefault();
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
        public IEnumerable<Dto.TroquelVentana> RecuperarVentanasFiltrado(Dto.TroquelVentana obj)
        {
            return new Data.DTroquelVentana().RecuperarFiltrados(obj);
        }

    }
}
