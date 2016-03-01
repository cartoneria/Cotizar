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
        public IEnumerable<Dto.Accesorio> Accesorio_RecuperarFiltros(Dto.Accesorio objFiltros)
        {
            try
            {
                return new Business.BAccesorio().RecuperarFiltrado(objFiltros);
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.Accesorios);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="idaccesorio"></param>
        /// <returns></returns>
        public bool Accesorio_Insertar(Dto.Accesorio obj, out int? idaccesorio)
        {
            try
            {
                bool blnRespuesta = new Business.BAccesorio().Crear(obj);

                if (blnRespuesta)
                    idaccesorio = obj.idaccesorio;
                else
                    idaccesorio = null;

                return blnRespuesta;
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.Accesorios);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Accesorio_Actualizar(Dto.Accesorio obj)
        {
            try
            {
                return new Business.BAccesorio().Actualizar(obj);
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.Accesorios);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Accesorio_Eliminar(Dto.Accesorio obj)
        {
            try
            {
                return new Business.BAccesorio().Eliminar(obj);
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.Accesorios);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Accesorio_ValidaCodigo(Dto.Accesorio obj)
        {
            try
            {
                return new Business.BAccesorio().ValidaCodigo(obj);
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.Accesorios);
                throw;
            }
        }
    }
}
