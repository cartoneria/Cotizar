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
        public IEnumerable<Dto.Asesor> Asesor_RecuperarFiltros(Dto.Asesor objFiltros)
        {
            try
            {
                return new Business.BAsesor().RecuperarFiltrado(objFiltros);
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.Asesores);
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="idasesor"></param>
        /// <returns></returns>
        public bool Asesor_Insertar(Dto.Asesor obj, out byte? idasesor)
        {
            try
            {
                bool blnRespuesta = new Business.BAsesor().Crear(obj);

                if (blnRespuesta)
                    idasesor = obj.idasesor;
                else
                    idasesor = null;

                return blnRespuesta;
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.Asesores);
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Asesor_Actualizar(Dto.Asesor obj)
        {
            try
            {
                return new Business.BAsesor().Actualizar(obj);
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.Asesores);
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Asesor_Eliminar(Dto.Asesor obj)
        {
            try
            {
                return new Business.BAsesor().Eliminar(obj);
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.Asesores);
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Asesor_ValidaCodigo(Dto.Asesor obj)
        {
            try
            {
                return new Business.BAsesor().ValidaCodigo(obj);
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.Asesores);
                throw ex;
            }
        }
    }
}
