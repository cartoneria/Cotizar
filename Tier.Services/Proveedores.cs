using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Services
{
    public partial class CotizarService : ICotizarService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        public IEnumerable<Dto.Proveedor> Proveedor_RecuperarFiltros(Dto.Proveedor objFiltros)
        {
            try
            {
                return new Business.BProveedor().RecuperarFiltrado(objFiltros);
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.Asesores);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="idproveedor"></param>
        /// <returns></returns>
        public bool Proveedor_Insertar(Dto.Proveedor obj, out int? idproveedor)
        {
            try
            {
                bool blnRespuesta = new Business.BProveedor().Crear(obj);

                if (blnRespuesta)
                    idproveedor = obj.idproveedor;
                else
                    idproveedor = null;

                return blnRespuesta;
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.Asesores);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Proveedor_Actualizar(Dto.Proveedor obj)
        {
            try
            {
                return new Business.BProveedor().Actualizar(obj);
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.Asesores);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Proveedor_Eliminar(Dto.Proveedor obj)
        {
            try
            {
                return new Business.BProveedor().Eliminar(obj);
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.Asesores);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        public IEnumerable<Dto.ProveedorLinea> Proveedor_RecuperarLineasFiltros(Dto.ProveedorLinea objFiltros)
        {
            try
            {
                return new Business.BProveedor().RecuperarLineasFiltrado(objFiltros);
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.Asesores);
                throw;
            }
        }
    }
}
