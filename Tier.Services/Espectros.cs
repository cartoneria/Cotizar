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
        public IEnumerable<Dto.Espectro> Espectro_RecuperarFiltros(Dto.Espectro objFiltros)
        {
            try
            {
                return new Business.BEspectro().RecuperarFiltrado(objFiltros);
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.Espectros);
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="idespectro"></param>
        /// <returns></returns>
        public bool Espectro_Insertar(Dto.Espectro obj, out int? idespectro)
        {
            try
            {
                bool blnRespuesta = new Business.BEspectro().Crear(obj);

                if (blnRespuesta)
                    idespectro = obj.idespectro;
                else
                    idespectro = null;

                return blnRespuesta;
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.Espectros);
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Espectro_Actualizar(Dto.Espectro obj)
        {
            try
            {
                return new Business.BEspectro().Actualizar(obj);
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.Espectros);
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Espectro_Eliminar(Dto.Espectro obj)
        {
            try
            {
                return new Business.BEspectro().Eliminar(obj);
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.Espectros);
                throw ex;
            }
        }
    }
}
