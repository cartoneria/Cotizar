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
        public IEnumerable<Dto.Pantone> Pantone_RecuperarFiltros(Dto.Pantone objFiltros)
        {
            try
            {
                return new Business.BPantone().RecuperarFiltrado(objFiltros);
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.Pantones);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="idpantone"></param>
        /// <returns></returns>
        public bool Pantone_Insertar(Dto.Pantone obj, out int? idpantone)
        {
            try
            {
                bool blnRespuesta = new Business.BPantone().Crear(obj);

                if (blnRespuesta)
                    idpantone = obj.idpantone;
                else
                    idpantone = null;

                return blnRespuesta;
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.Pantones);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Pantone_Actualizar(Dto.Pantone obj)
        {
            try
            {
                return new Business.BPantone().Actualizar(obj);
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.Pantones);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Pantone_Eliminar(Dto.Pantone obj)
        {
            try
            {
                return new Business.BPantone().Eliminar(obj);
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.Pantones);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Pantone_ValidaColor(Dto.Pantone obj)
        {
            try
            {
                return new Business.BPantone().ValidaColor(obj);
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.Pantones);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Pantone_ValidaNombre(Dto.Pantone obj)
        {
            try
            {
                return new Business.BPantone().ValidaNombre(obj);
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.Pantones);
                throw;
            }
        }
    }
}
