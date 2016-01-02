using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Business
{
    public class BProveedor
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Crear(Dto.Proveedor obj)
        {
            return new Data.DProveedor().Insertar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public IEnumerable<Dto.Proveedor> RecuperarFiltrado(Dto.Proveedor obj)
        {
            IEnumerable<Dto.Proveedor> lstResult = new Data.DProveedor().RecuperarFiltrados(obj);

            foreach (var item in lstResult)
            {
                item.lineas = this.RecuperarLineasFiltrado(new Dto.ProveedorLinea() { proveedor_idproveedor = item.idproveedor });
            }
            return lstResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public IEnumerable<Dto.ProveedorLinea> RecuperarLineasFiltrado(Dto.ProveedorLinea obj)
        {
            return new Data.DProveedorLinea().RecuperarFiltrados(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Actualizar(Dto.Proveedor obj)
        {
            return new Data.DProveedor().Actualizar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Eliminar(Dto.Proveedor obj)
        {
            return new Data.DProveedor().Eliminar(obj);
        }
    }
}
