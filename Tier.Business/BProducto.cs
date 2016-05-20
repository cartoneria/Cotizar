using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Business
{
    public class BProducto : ParentBusiness
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Crear(Dto.Producto obj)
        {
            return new Data.DProducto().Insertar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public IEnumerable<Dto.Producto> RecuperarFiltrado(Dto.Producto obj)
        {
            IEnumerable<Dto.Producto> lstResult = new Data.DProducto().RecuperarFiltrados(obj);

            foreach (var item in lstResult)
            {
                item.espectro = this.RecuperarPEFiltrado(new Dto.ProductoEspectro() { producto_idproducto = item.idproducto });
                item.accesorios = this.RecuperarPAFiltrado(new Dto.ProductoAccesorio() { producto_idproducto = item.idproducto });
                item.pegues = this.RecuperarPGFiltrado(new Dto.ProductoPegue() { producto_idproducto = item.idproducto });
            }

            return lstResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Actualizar(Dto.Producto obj)
        {
            return new Data.DProducto().Actualizar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Eliminar(Dto.Producto obj)
        {
            return new Data.DProducto().Eliminar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool ValidaCodigo(Dto.Producto obj)
        {
            Dto.Producto objExiste = new Data.DProducto().RecuperarFiltrados(obj).FirstOrDefault();
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
        public IEnumerable<Dto.ProductoEspectro> RecuperarPEFiltrado(Dto.ProductoEspectro obj)
        {
            IEnumerable<Dto.ProductoEspectro> lst = new Data.DProductoEspectro().RecuperarFiltrados(obj);

            foreach (Dto.ProductoEspectro item in lst)
            {
                item.pantone = new BPantone().RecuperarFiltrado(new Dto.Pantone() { idpantone = item.pantone_idpantone }).FirstOrDefault();
            }

            return lst;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public IEnumerable<Dto.ProductoAccesorio> RecuperarPAFiltrado(Dto.ProductoAccesorio obj)
        {
            IEnumerable<Dto.ProductoAccesorio> lst = new Data.DProductoAccesorio().RecuperarFiltrados(obj);

            foreach (Dto.ProductoAccesorio item in lst)
            {
                item.accesorio = new BAccesorio().RecuperarFiltrado(new Dto.Accesorio() { idaccesorio = item.accesorio_idaccesorio }).FirstOrDefault();
            }

            return lst;
        }

        public IEnumerable<Dto.ProductoPegue> RecuperarPGFiltrado(Dto.ProductoPegue obj)
        {
            IEnumerable<Dto.ProductoPegue> lst = new Data.DProductoPegue().RecuperarFiltrados(obj);

            return lst;
        }
    }
}
