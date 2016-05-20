using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Business
{
    public class BRol : ParentBusiness
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Crear(Dto.Rol obj)
        {
            return new Data.DRol().Insertar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public IEnumerable<Dto.Rol> RecuperarFiltrado(Dto.Rol obj)
        {
            IEnumerable<Dto.Rol> lst = new Data.DRol().RecuperarFiltrados(obj);

            foreach (Dto.Rol item in lst)
            {
                item.permisos = new BPermiso().RecuperarFiltrado(new Dto.Permiso() { rol_idrol = item.idrol });
            }

            return lst;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Actualizar(Dto.Rol obj)
        {
            return new Data.DRol().Actualizar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Eliminar(Dto.Rol obj)
        {
            return new Data.DRol().Eliminar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public IEnumerable<Dto.Funcionalidad> RecuperarMenuRol(Dto.Rol obj)
        {
            IEnumerable<Dto.Funcionalidad> lst = new Data.DRol().RecuperarMenu(obj);

            return new Business.BFuncionalidad().GenerarMenu(lst);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool ValidaNombre(Dto.Rol obj)
        {
            Dto.Rol objExiste = new Data.DRol().RecuperarFiltrados(obj).FirstOrDefault();
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
