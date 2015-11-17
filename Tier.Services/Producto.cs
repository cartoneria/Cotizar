using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Tier.Services
{
    public partial class CotizarService : ICotizarService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        public IEnumerable<Dto.Producto> Producto_RecuperarFiltros(Dto.Producto objFiltros)
        {
            try
            {
                return new Business.BProducto().RecuperarFiltrado(objFiltros);
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.Maquinas);
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="idproducto"></param>
        /// <returns></returns>
        public bool Producto_Insertar(Dto.Producto obj, out int? idproducto)
        {
            try
            {
                bool blnRespuesta = new Business.BProducto().Crear(obj);

                if (blnRespuesta)
                    idproducto = obj.idproducto;
                else
                    idproducto = null;

                return blnRespuesta;
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.Maquinas);
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Producto_Actualizar(Dto.Producto obj)
        {
            try
            {
                return new Business.BProducto().Actualizar(obj);
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.Maquinas);
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Producto_Eliminar(Dto.Producto obj)
        {
            try
            {
                return new Business.BProducto().Eliminar(obj);
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.Maquinas);
                throw ex;
            }
        }
    }
}
