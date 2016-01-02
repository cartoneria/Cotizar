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
        public IEnumerable<Dto.Insumo> Insumo_RecuperarFiltros(Dto.Insumo objFiltros)
        {
            try
            {
                return new Business.BInsumo().RecuperarFiltrado(objFiltros);
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
        /// <param name="idinsumo"></param>
        /// <returns></returns>
        public bool Insumo_Insertar(Dto.Insumo obj, out int? idinsumo)
        {
            try
            {
                bool blnRespuesta = new Business.BInsumo().Crear(obj);

                if (blnRespuesta)
                    idinsumo = obj.idinsumo;
                else
                    idinsumo = null;

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
        public bool Insumo_Actualizar(Dto.Insumo obj)
        {
            try
            {
                return new Business.BInsumo().Actualizar(obj);
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
        public bool Insumo_Eliminar(Dto.Insumo obj)
        {
            try
            {
                return new Business.BInsumo().Eliminar(obj);
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.Asesores);
                throw;
            }
        }
    }
}
